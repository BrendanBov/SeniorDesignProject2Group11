/*
  GPS_Parsing.h - Library for parsing data from the PA1010D.
  Only includes information from the GGA and RMC NMEA protocols.
  Created by Brendan, Bovenschen, November 28, 2024.
*/

#ifndef GPS_Parsing_h
#define GPS_Parsing_h
#include "Arduino.h"
#include <SoftwareSerial.h>

class PA1010D
{
  enum NMEAtype {None = 0, RMC, GGA};

  public:
    PA1010D(uint8_t tx, uint8_t rx);
    void SetupGPS();
    void PollGPS();
    char gpsBuf[64] = {0};
    bool gpsComplete = false;
    bool readingGPS = true;   
    
  private:
    void PrintDate();
    void PrintGPS(char* str, NMEAtype type, uint8_t index, bool end);
    void PrintTime(char* oldStr);
    void PrintLatLon(char* oldStr, bool isLon);
    unsigned long _date = 010100;  // default date: 01/01/2000
};

#endif