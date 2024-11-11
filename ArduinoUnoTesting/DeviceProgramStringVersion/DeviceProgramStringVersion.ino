// This program saves the serial ouput to a large string
// to be serial printed by each device.
// This is horribly inefficient for memory usage.

// Save accelerometer data and print to serial
//#include <SoftwareSerial.h>
#include <Adafruit_GPS.h>

// SD Libraries
#include <SD.h>
//#include <SPI.h>

// IMU Libraries
//#include <Wire.h>
//#include <Adafruit_Sensor.h>
#include <Adafruit_BNO055.h>
//#include <utility/imumaths.h>

// TODO probably get rid of global log file variable
// since i have to open and close it each tile
//
// TODO make handling for plugging in sd card during runtime
//File logFile;

const int pinCS = 10; // Chip Select for UNO, Used for SD card port

const uint16_t GLOBAL_SAMPLERATE_DELAY_MS = 100;
const int BAUDRATE = 9600;

// Bluetooth
SoftwareSerial hc06(2,3);

// GPS param
SoftwareSerial mySerial(9, 8);
Adafruit_GPS GPS(&mySerial);

// Check I2C device address and correct line below (by default address is 0x29 or 0x28)
//                                   id, address
Adafruit_BNO055 bno = Adafruit_BNO055(55, 0x28, &Wire);

void setup() 
{
  Serial.begin(BAUDRATE); // Usb out
  hc06.begin(BAUDRATE);   // bluetooth module
  delay(2000);

  SetupLogFile();
  SetupIMU();
  SetupGPS();
}

void loop() 
{
  String serialOut = "";
  PollIMU(serialOut);
  PollGPS(serialOut);
  
  SDWrite(serialOut);
  Serial.print(serialOut);
  hc06.print(serialOut);
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

  // TODO Figure out units for elevation
  if (!SD.exists(F("log.csv")))  //write first line to log file
  {
    File logFile = SD.open(F("log.csv"), FILE_WRITE);
    logFile.println(F("Date,Time,Satellites,Latiude,Longitude,Elevation (units?),X Accel (m/s^2),Y Accel (m/s^2),Z Accel (m/s^2),X Gyro (rps),Y Gyro (rps),Z Gyro (rps),X Mag (uT),Y Mag (uT),Z Mag (uT)"));
    logFile.close(); 
  }
  
}

void SetupIMU()
{
  while (!Serial) delay(10);  // wait for serial port to open!

  // Initialise the sensor
  if (!bno.begin())
  {
    Serial.print(F("IMU ERROR"));
    while (1);
  }
}

void SetupGPS()
{
  // 9600 NMEA is the default baud rate for Adafruit MTK GPS's- some use 4800
  GPS.begin(BAUDRATE);

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

void PollIMU(String &serialOut)
{
  // could add VECTOR_ACCELEROMETER, VECTOR_MAGNETOMETER,VECTOR_GRAVITY...
  sensors_event_t accelerometerData, angVelocityData, magnetometerData;
  bno.getEvent(&accelerometerData, Adafruit_BNO055::VECTOR_ACCELEROMETER);
  bno.getEvent(&angVelocityData, Adafruit_BNO055::VECTOR_GYROSCOPE);
  bno.getEvent(&magnetometerData, Adafruit_BNO055::VECTOR_MAGNETOMETER);

  printEvent(&accelerometerData, serialOut, false);
  printEvent(&angVelocityData, serialOut, false);
  printEvent(&magnetometerData, serialOut, true);

  delay(GLOBAL_SAMPLERATE_DELAY_MS);
}

void printEvent(sensors_event_t* event, String &serialOut, bool last) {
  double x = -1000000, y = -1000000 , z = -1000000; // dumb values, easy to spot problem
  if (event->type == SENSOR_TYPE_ACCELEROMETER) {
    x = event->acceleration.x;
    y = event->acceleration.y;
    z = event->acceleration.z;
  }
  else if (event->type == SENSOR_TYPE_GYROSCOPE) {
    x = event->gyro.x;
    y = event->gyro.y;
    z = event->gyro.z;
  }
  else if (event->type == SENSOR_TYPE_MAGNETIC_FIELD) {
    x = event->magnetic.x;
    y = event->magnetic.y;
    z = event->magnetic.z;
  }

  serialOut += String(x, 3) + ',' + String(y, 3) + ',' + String(z, 3);
  char lastChar = last ? '\n' : ',';
  serialOut += lastChar;
}

void PollGPS(String &serialOut)
{
  char c = GPS.read();

  // if a sentence is received, we can check the checksum, parse it...
  if (GPS.newNMEAreceived()) 
  {
    if (!GPS.parse(GPS.lastNMEA()))   // this also sets the newNMEAreceived() flag to false
      return;  // we can fail to parse a sentence in which case we should just wait for another
  }

  // Date
  serialOut += String(GPS.day) + '/' + String(GPS.month) + F("/20") + String(GPS.year) + ',';

  // Time
  if (GPS.hour < 10) serialOut += '0';
  serialOut += String(GPS.hour) + ':';

  if (GPS.minute < 10) serialOut += '0';
  serialOut += String(GPS.minute) + ':';

  if (GPS.seconds < 10) serialOut += '0';
  serialOut += String(GPS.seconds) + '.';

  if (GPS.milliseconds < 10) serialOut += F("00");
  else if (GPS.milliseconds > 9 && GPS.milliseconds < 100) 
    serialOut += '0';

  serialOut += String(GPS.milliseconds) + ',';

  // Satellites
  serialOut += String((int)GPS.satellites) + ',';
  //Serial.print("Fix: "); Serial.print((int)GPS.fix); might still need this

  //Lat / Long
  serialOut += String(GPS.latitude, 4) + ','; //Serial.print(GPS.lat); idk what this does
  serialOut += String(GPS.longitude, 4)+ ','; //Serial.print(GPS.lon); idk what this does

  // Elevation 
  Serial.print(GPS.altitude);
  Serial.print('\n');
}

void SDWrite(String &data)
{
  File logFile = SD.open(F("log.csv"), FILE_WRITE);

  if(logFile) 
  {
    logFile.print(data);
    logFile.close();
  }
}