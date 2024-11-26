// Test appending a file using the Petit FS library
// adapted from PetitFS.ino in PetitFS library

// Petit FS SD Library
#include "PetitFS.h"

// SD
const char* filePath = "LOG.CSV";
FATFS fatFS;


void SetupLogFile()
{
  uint8_t buf[32];
  FRESULT res;

  //delay(1000);
  res = pf_mount(&fatFS);
  if (res) errorHalt("pf_mount", res);

  //res = pf_open(filePath);
  //if (res) errorHalt("pf_open", res);

  errorHalt("end", 0);
}

void errorHalt(char* msg, FRESULT res) {
  Serial.print(F("Error: "));
  Serial.println(msg);
  Serial.print(F("Result: "));
  Serial.println(res);
  while(1);
}

void setup() {
  Serial.begin(9600);
  SetupLogFile();
}

void loop() {

}
