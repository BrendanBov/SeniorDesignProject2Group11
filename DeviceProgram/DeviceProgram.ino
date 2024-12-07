// Device Program
// Group 11
// Writes GPS and 9-axis accelerometer data to 3 locations:
// SD, USB, and Bluetooth

// Custom gps library
#include <GPS_Parsing_Lite.h>

// SD Library
#include <SD.h>

// IMU Libraries
#include <Adafruit_BNO055.h>

const uint16_t PRINT_DELAY_MS = 100;
const unsigned long BAUDRATE = 115200; //9600; //19200; 

// GPS param
PA1010D gps(9, 8);

//IMU Obj
Adafruit_BNO055 bno = Adafruit_BNO055(55, 0x28, &Wire);

// SD
const int pinCS = 10; // Chip Select for UNO, Used for SD card port
const char* filePath = "log.csv";
File logFile;

// Bluetooth
SoftwareSerial hc06(2,3);

// Timer
unsigned long startTime = 0;

void setup() 
{
  Serial.begin(BAUDRATE); // Usb out
  hc06.begin(BAUDRATE);

  gps.SetupGPS();
  SetupIMU();
  SetupLogFile();
  SetupTimer();
}

void loop() 
{
  gps.PollGPS();

  bool printFlag = (millis() - startTime) >= PRINT_DELAY_MS;
  if(!gps.readingGPS && gps.gpsComplete && printFlag)
  {

    MultiWrite(gps.gpsBuf);
    PollIMU();

    startTime = millis();
    //delay(GLOBAL_SAMPLERATE_DELAY_MS);
  }
}

void SetupTimer()
{
  startTime = millis();
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
    logFile = SD.open(filePath, FILE_WRITE);
    logFile.println(F("Date,Time,Latiude,Longitude,Satellites,Elevation (m),X Accel (m/s^2),Y Accel (m/s^2),Z Accel (m/s^2),X Gyro (rps),Y Gyro (rps),Z Gyro (rps),X Mag (uT),Y Mag (uT),Z Mag (uT)"));
    logFile.close(); 
  }
}

void SDWrite(String &data)
{
  logFile = SD.open(filePath, FILE_WRITE);

  if(logFile) 
  {
    logFile.print(data);
    logFile.close();
  }
}

void SDWrite(__FlashStringHelper* data)
{
  logFile = SD.open(filePath, FILE_WRITE);

  if(logFile) 
  {
    logFile.print(data);
    logFile.close();
  }
}

void SDWrite(char* data)
{
  logFile = SD.open(filePath, FILE_WRITE);

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

 //delay(GLOBAL_SAMPLERATE_DELAY_MS);
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

  char lastChar = last ? '\n' : ',';
  String str = String(x, 3) + ',' + String(y, 3) + ',' + String(z, 3) + lastChar;
  MultiWrite(str);
}