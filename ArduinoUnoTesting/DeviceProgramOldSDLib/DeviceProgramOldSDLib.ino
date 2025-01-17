// Device Program Final
// Group 11
// Writes 9-axis Accelerometer and GPS data to 3 locations:
// SD, USB, and bluetooth

#include <SoftwareSerial.h>

// GPS Library
#include <Adafruit_GPS.h> 

// SD Library
#include <SD.h>

// IMU Library
#include <Adafruit_BNO055.h>

const int pinCS = 10; // Chip Select for UNO, Used for SD card port

const uint16_t GLOBAL_SAMPLERATE_DELAY_MS = 100;
const int BAUDRATE = 9600;

// SD
const auto filePath = "log.csv";

// Bluetooth
SoftwareSerial hc06(2,3);

// GPS param
SoftwareSerial gpsSerial(9, 8);
Adafruit_GPS GPS(&gpsSerial);

// Check I2C device address and correct line below (by default address is 0x29 or 0x28)
//                                   id, address
Adafruit_BNO055 bno = Adafruit_BNO055(55, 0x28, &Wire);

void setup() 
{
  Serial.begin(BAUDRATE); // Usb out
  hc06.begin(BAUDRATE);   // bluetooth module
  delay(2000);

  SetupLogFile();
  SetupGPS();
  SetupIMU();
}

void loop() 
{
  PollGPS();
  PollIMU();
}

// Writes to each output method
void MultiWrite(String &str)
{
  SDWrite(str);
  Serial.print(str);
  hc06.print(str);
}

void MultiWrite(__FlashStringHelper* flash)
{
  String str = String(flash);
  SDWrite(str);
  Serial.print(str);
  hc06.print(str);
}

/*void MultiWrite(char c)
{
  MultiWrite(String(c));
}*/

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
  if (!SD.exists(filePath))  //write first line to log file
  {
    File logFile = SD.open(filePath, FILE_WRITE);
    logFile.println(F("Date,Time,Satellites,Latiude,Longitude,Elevation (units?),X Accel (m/s^2),Y Accel (m/s^2),Z Accel (m/s^2),X Gyro (rps),Y Gyro (rps),Z Gyro (rps),X Mag (uT),Y Mag (uT),Z Mag (uT)"));
    logFile.close(); 
  }
}

void SetupIMU()
{
  while (!Serial) delay(10);  // wait for serial port to open

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
  gpsSerial.println(PMTK_Q_RELEASE);
}

void PollIMU()
{
  // could add VECTOR_ACCELEROMETER, VECTOR_MAGNETOMETER,VECTOR_GRAVITY...
  sensors_event_t accelerometerData, angVelocityData, magnetometerData;
  bno.getEvent(&accelerometerData, Adafruit_BNO055::VECTOR_ACCELEROMETER);
  bno.getEvent(&angVelocityData, Adafruit_BNO055::VECTOR_GYROSCOPE);
  bno.getEvent(&magnetometerData, Adafruit_BNO055::VECTOR_MAGNETOMETER);

  printEvent(&accelerometerData, false);
  printEvent(&angVelocityData, false);
  printEvent(&magnetometerData, true);

  delay(GLOBAL_SAMPLERATE_DELAY_MS);
}

void printEvent(sensors_event_t* event, bool last) {
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

  //char str[32];
  char lastChar = last ? '\n' : ',';
  //snprintf(str, sizeof(str), "%.3f,%.3f,%.3f%c", x, y, z, lastChar);
  String str = String(x, 3) + ',' + String(y, 3) + ',' + String(z, 3) + lastChar;
  MultiWrite(str);
}

void PollGPS()
{
  GPS.read();

  // if a sentence is received, we can check the checksum, parse it...
  if (GPS.newNMEAreceived() && !GPS.parse(GPS.lastNMEA())) 
    return;

  //char str[64];

  // Date
  MultiWrite(String(GPS.day) + '/');
  MultiWrite(String(GPS.month) + F("/20"));
  MultiWrite(String(GPS.year) + ',');
  //snprintf(str, sizeof(str), "%u/%u/20%u,", GPS.day, GPS.month, GPS.year);
  //MultiWrite(str);

  // Time
  if (GPS.hour < 10) MultiWrite(F("0"));
  //snprintf(str, sizeof(str), "%u%c,", GPS.hour, ':');
  //MultiWrite(str);
  MultiWrite(String(GPS.hour) + ':');


  if (GPS.minute < 10) MultiWrite(F("0"));
  MultiWrite(String(GPS.minute) + ':');
  //snprintf(str, sizeof(str), "%u%c,", GPS.minute, ':');
  //MultiWrite(str);

  if (GPS.seconds < 10) MultiWrite(F("0"));
  MultiWrite(String(GPS.seconds) + '.');
  //snprintf(str, sizeof(str), "%u%c,", GPS.seconds, '.');
  //MultiWrite(str);

  if (GPS.milliseconds < 10) MultiWrite(F("00"));
  else if (GPS.milliseconds > 9 && GPS.milliseconds < 100) 
    MultiWrite(F("0"));

  MultiWrite(String(GPS.milliseconds) + ',');
  //snprintf(str, sizeof(str), "%u%c,", GPS.milliseconds, ',');
  //MultiWrite(str);

  // Satellites
  MultiWrite(String((int)GPS.satellites) + ',');
  //snprintf(str, sizeof(str), "%u%c,", GPS.satellites, ',');
  //MultiWrite(str);
  //Serial.print("Fix: "); Serial.print((int)GPS.fix); might still need this

  //Lat / Long and Elevation
  MultiWrite(String(GPS.latitude, 4) + ','); //Serial.print(GPS.lat); idk what this does
  MultiWrite(String(GPS.longitude, 4) + ','); //Serial.print(GPS.lon); idk what this does
  //snprintf(str, sizeof(str), "%.3f,%.3f,%.3f,", GPS.latitude, GPS.longitude, GPS.altitude);
 // MultiWrite(str);

  // Elevation 
  MultiWrite(String(GPS.altitude) + ',');

  //MultiWrite(F(","));
}

// TODO make handling for plugging in sd card during runtime
void SDWrite(String &data)
{
  File logFile = SD.open(filePath, FILE_WRITE);

  if(logFile) 
  {
    logFile.print(data);
    logFile.close();
  }
}