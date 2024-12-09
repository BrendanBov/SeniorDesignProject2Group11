/*
  GPS Example - Example program for GPS_Parsing_Lite
  Demonstrates how to implement GPS object in a CSV stream
  Created By: Brendan Bovenschen, December 6, 2024
  Last Modified By: Brendan Bovenschen, December 6, 2024
*/

// Custom gps library
#include <GPS_Parsing_Lite.h>

const uint16_t PRINT_DELAY_MS = 100;
const unsigned long BAUDRATE = 115200;

// GPS obj
// PA1010D(uint8_t tx, uint8_t rx, uint16_t pollPeriodMS = 1000, bool endLine = false)
PA1010D gps(9, 8, 100, false);

// Timer
unsigned long startTime = 0;

void setup() 
{
  Serial.begin(BAUDRATE); // Usb out

  gps.SetupGPS();
  startTime = millis();
}

void loop() 
{
  gps.PollGPS();

  bool printFlag = (millis() - startTime) >= PRINT_DELAY_MS;
  if(!gps.readingGPS && gps.gpsComplete && printFlag)
  {
    // Buffer stored in format:
    // Date,Time,Latiude,Longitude,Satellites,Elevation (m)<',' or '\n'> based on endLine parameter
    Serial.print(gps.gpsBuf);
    PrintOther();

    startTime = millis();
  }
}

// Where polling and printing of other devices would go
void PrintOther()
{
  Serial.print(F("OTHER,DATA,HERE\n"));
}