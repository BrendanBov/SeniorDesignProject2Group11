// SDWriteTest
// Adapted from code by How To Mechatronics
// https://howtomechatronics.com/tutorials/arduino/arduino-sd-card-data-logging-excel-tutorial/#h-arduino-sd-card-module-code

#include <SD.h>
#include <SPI.h>

File myFile;

int pinCS = 10;

void setup() {
    
  Serial.begin(9600);
  pinMode(pinCS, OUTPUT);
  
  // SD Card Initialization
  if (SD.begin())
  {
    Serial.println("SD card is ready to use.");
  } else
  {
    Serial.println("SD card initialization failed");
    return;
  }
  
  // Create/Open file 
  myFile = SD.open("test.csv", FILE_WRITE);
  
  // if the file opened okay, write to it:
  if (myFile) {
    Serial.println("Writing to file...");
    // Write to file
    myFile.println("Testing text 1, 2 ,3...");
    myFile.close(); // close the file
    Serial.println("Done.");
  }
  // if the file didn't open, print an error:
  else {
    Serial.println("error opening test.csv");
  }

  // Reading the file
  myFile = SD.open("test.csv");
  if (myFile) {
    Serial.println("Read:");
    // Reading the whole file
    while (myFile.available()) {
      Serial.write(myFile.read());
   }
    myFile.close();
  }
  else {
    Serial.println("error opening test.csv");
  }
  
}
void loop() {}