/*
  GPS_Parsing.h - Library for parsing data from the PA1010D.
  Only includes information from the GGA and RMC NMEA protocols.
  Created By: Brendan Bovenschen, November 28, 2024
  Last Modified By: Brendan Bovenschen, December 6, 2024
*/

#include "Arduino.h"
#include "GPS_Parsing_Lite.h"
#include <SoftwareSerial.h>

#define PMTK_SET_NMEA_OUTPUT_RMCGGA "$PMTK314,0,1,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0*28"
/*#define PMTK_SET_NMEA_UPDATE_10HZ "$PMTK220,100*2F"
#define PMTK_SET_NMEA_UPDATE_5HZ "$PMTK220,200*2C"
#define PMTK_SET_NMEA_UPDATE_4HZ "$PMTK220,250*29"
#define PMTK_SET_NMEA_UPDATE_2HZ "$PMTK220,500*2B"
#define PMTK_SET_NMEA_UPDATE_1HZ "$PMTK220,1000*1F"*/
#define PMTK_Q_RELEASE "$PMTK605*31"

// command for sample period saved as flash string
const char periodCmdHead[] PROGMEM = "$PMTK220,";

SoftwareSerial gpsSerial(9,8);  // default values (tx, rx)

PA1010D::PA1010D(uint8_t tx, uint8_t rx, uint16_t pollPeriodMS = 1000, bool endLine = false)
{
  gpsSerial = SoftwareSerial(tx, rx);
  _pollPeriodMS = pollPeriodMS;
  _endLine = endLine;
}

void PA1010D::SetupGPS()
{
  gpsSerial.begin(9600);
  delay(2000);

  // use RMC and GGA NMEA protocols
  gpsSerial.println(F(PMTK_SET_NMEA_OUTPUT_RMCGGA));


  // Set the update rate
  char cmd[32] = {0};
  char buf[8] = {0};
  strcpy_P(cmd, periodCmdHead);

  // Convert pollPeriodMS to string
  sprintf(buf, "%u*", _pollPeriodMS);
  strcat(cmd, buf);

  // start after '$' character
  int i = 1;
  char c = cmd[i];
  //checksum
  char checksum = 0x0;
  while (c != '*')
  {
    checksum ^= c;
    i++;
    c = cmd[i];
  }
  // append checksum in hexidecimal
  sprintf(buf, "%0X", checksum);
  strcat(cmd, buf);

  gpsSerial.println(cmd);
  
  //Serial.begin(115200);
  //Serial.println(cmd);
  //gpsSerial.println(F(PMTK_SET_NMEA_UPDATE_10HZ));
  
  // Ask for firmware version
  gpsSerial.println(F(PMTK_Q_RELEASE));
}

// lightweight serial parsing for GPS
// utilizes a buffer of 16 bytes
// + another 16 for formatting and printing special cases
void PA1010D::PollGPS()
{
  const uint8_t gpsStrLen = 16;
  const char msgStart = '$';
  const char msgEnd = '\n';
  const char msgKey = ',';
  const char* RMCcode = "GNRMC";
  const char* GGAcode = "GNGGA";

  static NMEAtype currNMEA = None;
  static bool checkNMEA = false;
  static uint8_t index = 0;
  static char gpsStr[gpsStrLen] = {0};
  static uint8_t msgIndex = 0;

  //New data available, clear buffer
  if(gpsComplete && (gpsSerial.available() > 0))
  {
    memset(gpsBuf, 0, sizeof(gpsBuf));
    gpsComplete = false;
  }

  //Date,Time,Latiude,Longitude,Satellites,Elevation (m),
  while(gpsSerial.available() > 0)
  {
    char c = gpsSerial.read();

    if (!readingGPS) readingGPS = true;

    if (c == msgStart) 
    {
      index = 0;
      msgIndex = 0;
      //memset(gpsStr, '\0', gpsStrLen); //clear string
      checkNMEA = true;
    }
    else if (c == msgEnd || c == msgKey)
    {
      gpsStr[index] = '\0';
      index = 0;

      if (checkNMEA) // set current NMEA type
      {
        if (!strcmp(gpsStr, GGAcode)) currNMEA = GGA;
        else if (!strcmp(gpsStr, RMCcode)) currNMEA = RMC;
        else currNMEA = None;
        checkNMEA = false;

        // print date at start of gps string (while checking for NMEA type)
        if(currNMEA == GGA) PrintDate();
      }

      PrintGPS(gpsStr, currNMEA, msgIndex, c == msgEnd);
      msgIndex++;

      if(c == msgEnd)
      {
        readingGPS = false; // end reading at endline
        // GPS message is complete at the end of GGA
        if (currNMEA == GGA) gpsComplete = true;
      }
    }
    else
    {
      gpsStr[index] = c;
      index++;
      // prevent out of index, overwrite last character
      if (index >= gpsStrLen) index = gpsStrLen - 1;
    }
  }
}

// Unique print function due to msg position and formatting
void PA1010D::PrintDate()
{
  // dd/mm/20yy
  const char* dateFormat = "%u/%u/20%u,";
  char str[16] = {0};

  // prevent char overflow on sprintf
  if (_date > 999999) _date = 010100;
  uint8_t day = _date / 10000;
  uint8_t month = (_date / 100) % 100;
  uint8_t year = _date % 100;
  sprintf(str, dateFormat, day, month, year);
  strcat(gpsBuf, str);
}

void PA1010D::PrintGPS(char* str, NMEAtype type, uint8_t index, bool end)
{
  // handle which elements in GPS serial are printed
  // bit position of mask determies if index is printed
  //                           index <16   ------>   0>
  const uint16_t printRMC = 0x200; // 0000001000000000
  const uint16_t printGGA = 0x2BE; // 0000001010111110
  const uint16_t latLonMask = 0x14;// 0000000000010100

  uint16_t indexMask = 1 << index;

  if (type == GGA)
  {
    if (indexMask & printGGA)
    {
      // time is at GGA index 1
      if (index == 1) PrintTime(str);
      else if (indexMask & latLonMask) PrintLatLon(str, index == 4);
      else strcat(gpsBuf, str);

      // Don't print ',' after lat or lon,
      // To concat lat/lon and N/E/S/W
      if (!(indexMask & latLonMask)) 
      {
        if (index == 9 && _endLine) strcat(gpsBuf, "\n");
        else strcat(gpsBuf, ",");
      }
    }
  }

  // get date from RMC, everything else prints in GGA
  // stored to print at beginning of message
  else if (type == RMC && (indexMask & printRMC))
    _date = strtol(str, sizeof(str), 10);
}

// Handle formatting for time
void PA1010D::PrintTime(char* oldStr)
{
  //TODO: should reference old string to prevent new memory allocation
  char str[16] = {0}; // new string to prevent memory problems
  strcpy(str, oldStr);

  memmove(str + 5, str + 4, 7);
  str[4] = ':';
  //hhmm:ss.sss

  memmove(str + 2, str + 1, 11);
  str[2] = ':';
  //hh:mm:ss.sss

  str[12] = '\0'; //HOTFIX to prevent mutable array

  strcat(gpsBuf, str);
}

void PA1010D::PrintLatLon(char* oldStr, bool isLon)
{
  //TODO: should reference old string to prevent new memory allocation
  char str[16] = {0}; // new string to prevent memory problems
  strcpy(str, oldStr);
  //lat: ddmm.mmmm      lon: dddmm.mmmm
  
  str[9 + isLon] = '\"';
  //lat: ddmm.mmmm"     lon: dddmm.mmmm"
  
  memmove(str + 7 + isLon, str + 6 + isLon, 4 + isLon);
  str[7 + isLon] = '.';
  //lat: ddmm.mm.mm"    lon: dddmm.mm.mm"

  str[4 + isLon] = '\'';
  //lat: ddmm'mm.mm"    lon: dddmm'mm.mm"
  
  memmove(str + 2 + isLon, str + 1 + isLon, 10 + isLon);
  str[2 + isLon] = char(176); // degrees character
  //lat: dd°mm'mm.mm"   lon: dd°mm'mm.mm"

  str[12 + isLon] = '\0'; //HOTFIX to prevent mutable array

  strcat(gpsBuf, str); 
}