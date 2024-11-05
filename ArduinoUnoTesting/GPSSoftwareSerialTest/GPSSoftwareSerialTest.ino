// Adapted from Adafruit_GPS library script:
// Software_Serial_Parsing

#include <Adafruit_GPS.h>
#include <SoftwareSerial.h>

// you can change the pin numbers to match your wiring:
SoftwareSerial mySerial(9, 8);
Adafruit_GPS GPS(&mySerial);

void setup()
{

  // connect at 115200 so we can read the GPS fast enough and echo without dropping chars
  // also spit it out
  Serial.begin(115200);
  delay(5000);

  // 9600 NMEA is the default baud rate for Adafruit MTK GPS's- some use 4800
  GPS.begin(9600);

  // uncomment this line to turn on RMC (recommended minimum) and GGA (fix data) including altitude
  GPS.sendCommand(PMTK_SET_NMEA_OUTPUT_RMCGGA);

  // Set the update rate
  GPS.sendCommand(PMTK_SET_NMEA_UPDATE_1HZ);   // 1 Hz update rate

  // Request updates on antenna status, comment out to keep quiet
  GPS.sendCommand(PGCMD_ANTENNA);

  delay(1000);
  // Ask for firmware version
  mySerial.println(PMTK_Q_RELEASE);
}

uint32_t timer = millis();
void loop()                     // run over and over again
{
  char c = GPS.read();

  // if a sentence is received, we can check the checksum, parse it...
  if (GPS.newNMEAreceived()) {

    if (!GPS.parse(GPS.lastNMEA()))   // this also sets the newNMEAreceived() flag to false
      return;  // we can fail to parse a sentence in which case we should just wait for another
  }

  // approximately every 2 seconds or so, print out the current stats
  if (millis() - timer > 2000) {
    timer = millis(); // reset the timer

    // Date
    Serial.print(GPS.day, DEC); Serial.print('/');
    Serial.print(GPS.month, DEC); Serial.print("/20");
    Serial.print(GPS.year, DEC); Serial.print(',');

    // Time
    if (GPS.hour < 10) { Serial.print('0'); }
    Serial.print(GPS.hour, DEC); Serial.print(':');
    if (GPS.minute < 10) { Serial.print('0'); }
    Serial.print(GPS.minute, DEC); Serial.print(':');
    if (GPS.seconds < 10) { Serial.print('0'); }
    Serial.print(GPS.seconds, DEC); Serial.print('.');
    if (GPS.milliseconds < 10) {
      Serial.print("00");
    } else if (GPS.milliseconds > 9 && GPS.milliseconds < 100) {
      Serial.print("0");
    }
    Serial.print(GPS.milliseconds); Serial.print(',');

    // Satellites
    Serial.print((int)GPS.satellites); Serial.print(',');
    //Serial.print("Fix: "); Serial.print((int)GPS.fix); might still need this

    //Lat / Long
    Serial.print(GPS.latitude, 4); //Serial.print(GPS.lat); idk what this does
    Serial.print(',');
    Serial.print(GPS.longitude, 4); //Serial.print(GPS.lon); idk what this does
    Serial.print(',');

    // Elevation 
    Serial.print(GPS.altitude);
    Serial.print('\n');
    
  }
}
