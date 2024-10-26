// Save accelerometer data and print to serial

// SD Libraries
#include <SD.h>
#include <SPI.h>

// IMU Libraries
#include <Wire.h>
#include <Adafruit_Sensor.h>
#include <Adafruit_BNO055.h>
#include <utility/imumaths.h>

// TODO probably get rid of global log file variable
// since i have to open and close it each tile
//
// TODO make handling for plugging in sd card during runtime
File logFile;

int pinCS = 10; // Chip Select for UNO

uint16_t GLOBAL_SAMPLERATE_DELAY_MS = 100;

// Check I2C device address and correct line below (by default address is 0x29 or 0x28)
//                                   id, address
Adafruit_BNO055 bno = Adafruit_BNO055(55, 0x28, &Wire);

void setup() 
{
  Serial.begin(9600);
  SetupLogFile();
  SetupIMU();
}

void loop() 
{
  String serialOut = "";
  PollIMU(serialOut);
  
  SDWrite(serialOut);
  Serial.print(serialOut);
}

void SetupLogFile()
{
  pinMode(pinCS, OUTPUT);

  // SD Card Initialization
  if (!SD.begin())
  {
    Serial.println("SD NOT FOUND");
    return;
  }

  if (!SD.exists("log.csv"))  //write first line to log file
  {
    logFile = SD.open("log.csv", FILE_WRITE);
    logFile.println("X Accel (m/s^2),Y Accel (m/s^2),Z Accel (m/s^2),X Gyro (rps),Y Gyro (rps),Z Gyro (rps),X Mag (uT),Y Mag (uT),Z Mag (uT)");
    logFile.close(); 
  }
  
}

void SetupIMU()
{
  while (!Serial) delay(10);  // wait for serial port to open!

  /* Initialise the sensor */
  if (!bno.begin())
  {
    /* There was a problem detecting the BNO055 ... check your connections */
    Serial.print("IMU ERROR");
    while (1);
  }

  delay(1000);
}

void PollIMU(String &serialOut)
{
  //could add VECTOR_ACCELEROMETER, VECTOR_MAGNETOMETER,VECTOR_GRAVITY...
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
  double x = -1000000, y = -1000000 , z = -1000000; //dumb values, easy to spot problem
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

void SDWrite(String &data)
{
  logFile = SD.open("log.csv", FILE_WRITE);

  if(logFile) 
  {
    logFile.print(data);
    logFile.close();
  }
}