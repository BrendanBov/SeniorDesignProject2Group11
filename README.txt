Brendan Bovenschen
Kobe Goree
Ashley Holland
Jacob Riley

This repository contains: 
1. An arduino program for collecting data from a GPS module and a 9-axis IMU and
displaying this data through serial, bluetooth, and storing to SD (csv) 
2. A desktop application to recieve this information through bluetooth and serial (USB)

Program files that were developed over the course of this project can be found in these locations:

DESKTOP APPLICATION
.\Apps\ActiveBuild - Contains the most recent release build of the data collection app
.\Apps\TestUSBAPP - Dependencies for the applications Windows Forms development environment

ARDUINO PROGRAM
.\DeviceProgram\DeviceProgram.ino - Final program flashed to the Arduino Uno Microcontroller

GPS LIBRARY
This lightweight serial parsing library for the PA1010D was developed for this project to account
for the limited memory available on the ATmega328P
.\PA1010D_Lightweight_Parsing\src - Contains header and program files for the PA1010D class definition
.\PA1010D_Lightweight_Parsing\example\gpsExample - Example program for usage of PA1010D object

EXTERNAL LIBRARIES IMPLEMENTED IN THIS PROJECT
https://github.com/adafruit/Adafruit_BNO055 - Interupt based system used to interface with BNO055 IMU
https://github.com/adafruit/Adafruit_GPS - initally used to interface with GPS, discarded due to high memory usage