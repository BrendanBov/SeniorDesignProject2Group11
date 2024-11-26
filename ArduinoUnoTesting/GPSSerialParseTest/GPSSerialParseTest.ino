// GPS Serial Parse Test

#include <Adafruit_GPS.h>

const uint16_t GLOBAL_SAMPLERATE_DELAY_MS = 100;
const int BAUDRATE = 9600;

// GPS param
SoftwareSerial gpsSerial(9, 8);
unsigned long date = 010100;
enum NMEAtype {None = 0, RMC, GGA};

void setup() 
{
  Serial.begin(BAUDRATE); // Usb out

  SetupGPS();
}

void loop() 
{
  //EchoGPS();
  PollGPS();
}

// Writes to each output method
void MultiWrite(String &str)
{
  //SDWrite(str);
  Serial.print(str);
  //hc06.print(str);
}

void MultiWrite(__FlashStringHelper* flash)
{
  String str = String(flash);
  MultiWrite(str);
}

void MultiWrite(char* cArr)
{
  String str = String(cArr);
  MultiWrite(str);
}

void SetupGPS()
{
  gpsSerial.begin(BAUDRATE);  // should be 9600
  delay(2000);

  // uncomment this line to turn on RMC (recommended minimum) and GGA (fix data) including altitude
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

void PollGPS() // lightweight serial parsing
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

  //Time,Latiude,Longitude,Satellites,Elevation (m),Date
  while(gpsSerial.available())
  {
    char c = gpsSerial.read();

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

        // print date at start of gps string
        if(currNMEA == GGA) MultiWrite(String(date) + ',');
      }

      //MultiWrite(gpsStr);
      //MultiWrite(F(","));
      //if (c == msgEnd) MultiWrite(F("\n"));
      PrintGPS(gpsStr, currNMEA, msgIndex, c == msgEnd);

      msgIndex++;
    }
    else
    {
      gpsStr[index] = c;
      index++;
      // prevent out of index, overwrite last character
      if (index >= gpsStrLen) index = gpsStrLen - 1;
    }

  }

  /*
  GPS.read();

  // if a sentence is received, we can check the checksum, parse it...
  if (GPS.newNMEAreceived() && !GPS.parse(GPS.lastNMEA())) 
    return;

  // Date
  MultiWrite(String(GPS.day) + '/');
  MultiWrite(String(GPS.month) + F("/20"));
  MultiWrite(String(GPS.year) + ',');

  // Time
  if (GPS.hour < 10) MultiWrite(F("0"));
  MultiWrite(String(GPS.hour) + ':');


  if (GPS.minute < 10) MultiWrite(F("0"));
  MultiWrite(String(GPS.minute) + ':');

  if (GPS.seconds < 10) MultiWrite(F("0"));
  MultiWrite(String(GPS.seconds) + '.');

  if (GPS.milliseconds < 10) MultiWrite(F("00"));
  else if (GPS.milliseconds > 9 && GPS.milliseconds < 100) 
    MultiWrite(F("0"));

  MultiWrite(String(GPS.milliseconds) + ',');

  // Satellites
  MultiWrite(String((int)GPS.satellites) + ',');
  //Serial.print("Fix: "); Serial.print((int)GPS.fix); might still need this

  //Lat / Long and Elevation
  MultiWrite(String(GPS.latitude, 4) + ','); //Serial.print(GPS.lat); idk what this does
  MultiWrite(String(GPS.longitude, 4) + ','); //Serial.print(GPS.lon); idk what this does

  // Elevation 
  MultiWrite(String(GPS.altitude) + ',');
  */
}

void PrintGPS(char* str, NMEAtype type, uint8_t index, bool end)
{
  // handle which elements in GPS serial are printed
  // bit position of mask determies if index is printed
  //                           index <16   ------>   0>
  const uint16_t printRMC = 0x200; // 0000001000000000
  const uint16_t printGGA = 0x2BE; // 0000001010111110

  if (type == GGA)
  {
    if ((1 << index) & printGGA)
    {
      MultiWrite(str);
      if (!end) MultiWrite(F(",")); //GET RID OF if (!end)
    }

    //TEMP
    if (end) MultiWrite(F("\n"));
  }

  // get date from RMC, everything else prints in GGA
  else if (type == RMC && ((1 << index) & printGGA))
    date = strtol(str, sizeof(str), 10);
  
    
  
}