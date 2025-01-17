// GPS Serial Parse Test

#include <Adafruit_GPS.h>

// SD Library
#include <SD.h>

const uint16_t GLOBAL_SAMPLERATE_DELAY_MS = 100;
const int BAUDRATE = 9600;

// GPS param
SoftwareSerial gpsSerial(9, 8);
unsigned long date = 010100;  // default date: 01/01/2000
enum NMEAtype {None = 0, RMC, GGA};
char gpsBuf[64] = {0};
bool gpsComplete = false;
bool readingGPS = true;

// SD
const int pinCS = 10; // Chip Select for UNO, Used for SD card port
const char* filePath = "log.csv";

// Bluetooth
SoftwareSerial hc06(2,3);


void setup() 
{
  Serial.begin(BAUDRATE); // Usb out
  hc06.begin(BAUDRATE);   // bluetooth module

  SetupGPS();
  SetupLogFile();
}

void loop() 
{
  //EchoGPS();
  PollGPS();
  if(!readingGPS && gpsComplete)
  {
    MultiWrite(gpsBuf);
    MultiWrite(F("IMUDATA,X,X,X,X,X,X,X,X\n"));
    //PollIMU();
    // TODO: delay could cause lost gps message
    // change to timer and flag system
    delay(GLOBAL_SAMPLERATE_DELAY_MS);
  }
}

void SetupLogFile()
{
  pinMode(pinCS, OUTPUT);

  // SD Card Initialization
  if (!SD.begin())
  {
    Serial.println(F("SD NOT FOUND"));
    return;
  }

  if (!SD.exists(filePath))  //write first line to log file
  {
    File logFile = SD.open(filePath, FILE_WRITE);
    logFile.println(F("Date,Time,Latiude,Longitude,Satellites,Elevation (m),X Accel (m/s^2),Y Accel (m/s^2),Z Accel (m/s^2),X Gyro (rps),Y Gyro (rps),Z Gyro (rps),X Mag (uT),Y Mag (uT),Z Mag (uT)"));
    logFile.close(); 
  }
}

void SDWrite(String &data)
{
  File logFile = SD.open(filePath, FILE_WRITE);

  if(logFile) 
  {
    logFile.print(data);
    logFile.close();
  }
}

void SDWrite(__FlashStringHelper* data)
{
  File logFile = SD.open(filePath, FILE_WRITE);

  if(logFile) 
  {
    logFile.print(data);
    logFile.close();
  }
}

void SDWrite(char* data)
{
  File logFile = SD.open(filePath, FILE_WRITE);

  if(logFile) 
  {
    logFile.print(data);
    logFile.close();
  }
}

// Writes to each output method
void MultiWrite(String &str)
{
  SDWrite(str);
  Serial.print(str);
  hc06.print(str);
}

void MultiWrite(__FlashStringHelper* str)
{
  SDWrite(str);
  Serial.print(str);
  hc06.print(str);
}

void MultiWrite(char* str)
{
  SDWrite(str);
  Serial.print(str);
  hc06.print(str);
}

void SetupGPS()
{
  gpsSerial.begin(BAUDRATE);  // should be 9600
  delay(2000);

  // use RMC and GGA NMEA protocols
  gpsSerial.println(F(PMTK_SET_NMEA_OUTPUT_RMCGGA));

  // Set the update rate
  gpsSerial.println(F(PMTK_SET_NMEA_UPDATE_10HZ));
  
  // Ask for firmware version
  gpsSerial.println(F(PMTK_Q_RELEASE));
}

void EchoGPS()
{
  if(gpsSerial.available())
  {
    char c = gpsSerial.read();
    Serial.print(c);
  }
}

// lightweight serial parsing for GPS
// utilizes a buffer of 16 bytes
// + another 16 for formatting and printing special cases
void PollGPS()
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
  if(gpsComplete && gpsSerial.available())
  {
    memset(gpsBuf, 0, sizeof(gpsBuf));
    gpsComplete = false;
  }

  //Date,Time,Latiude,Longitude,Satellites,Elevation (m),
  while(gpsSerial.available())
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
void PrintDate()
{
  // dd/mm/20yy
  const char* dateFormat = "%u/%u/20%u,";
  char str[16] = {0};

  // prevent char overflow on sprintf
  if (date > 999999) date = 010100;
  uint8_t day = date / 10000;
  uint8_t month = (date / 100) % 100;
  uint8_t year = date % 100;
  sprintf(str, dateFormat, day, month, year);
  strcat(gpsBuf, str); //MultiWrite(str);
}

void PrintGPS(char* str, NMEAtype type, uint8_t index, bool end)
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
      // date is at GGA index 1
      if (index == 1) PrintTime(str);
      else if (indexMask & latLonMask) PrintLatLon(str, index == 4);
      else strcat(gpsBuf, str); //MultiWrite(str);

      // Don't print ',' after lat or lon,
      // To concat lat/lon and N/E/S/W
      if (!(indexMask & latLonMask)) 
        strcat(gpsBuf, ","); //MultiWrite(F(","));
    }

    //TEMP
    //if (end) MultiWrite(F("\n"));
  }

  // get date from RMC, everything else prints in GGA
  // stored to print at beginning of message
  else if (type == RMC && (indexMask & printRMC))
    date = strtol(str, sizeof(str), 10);
}

// Handle formatting for time
void PrintTime(char* oldStr)
{
  char str[16] = {0}; // new string to prevent memory problems
  strcpy(str, oldStr);

  memmove(str + 5, str + 4, 7);
  str[4] = ':';
  //hhmm:ss.sss

  memmove(str + 2, str + 1, 11);
  str[2] = ':';
  //hh:mm:ss.sss

  str[12] = '\0'; //HOTFIX to prevent mutable array

  strcat(gpsBuf, str); //MultiWrite(str);
}

void PrintLatLon(char* oldStr, bool isLon)
{
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

  strcat(gpsBuf, str); //MultiWrite(str);
}