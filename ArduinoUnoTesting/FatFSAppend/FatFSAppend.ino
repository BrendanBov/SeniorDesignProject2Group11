// Test appending a file using the Petit FS library
// adapted from PetitFS.ino in PetitFS library

// Petit FS SD Library
#include "PetitFS.h"

#include "string.h"

// SD
const int pinCS = 10; // Chip Select for UNO, Used for SD card port
const char* filePath = "log.csv";
FATFS fatFS;

// Test param
int counter = 0;

void SetupLogFile()
{
  uint8_t buf[32];
  unsigned int fileCounter = 0;
  bool endFile = false;

  pinMode(pinCS, OUTPUT);

  if (pf_mount(&fatFS)) errorHalt("pf_mount");
  if (pf_open(filePath)) errorHalt("pf_open");

  //read to the end of the file
  while (!endFile) {
    UINT nr;
    if (pf_read(buf, sizeof(buf), &nr)) errorHalt("pf_read");
    if (nr == 0) errorHalt("out of file space");
    Serial.write(buf, nr);

    // check for end of written data, "\n "
    for(int i = 0; i < sizeof(buf) - 1; i++)
    {
      char symbol[2] = {buf[i], buf[i+1]};
      if(symbol == "\n ")
      {
        Serial.write("End of file found!");
        fileCounter += i; // set new offset to write at
        endFile = true;
        break;
      }
    }
    if (!endFile) fileCounter += sizeof(buf);
  }

  // set read/write pointer
  pf_lseek(fileCounter);
}

// Append at current read/write pointer position
void SDWrite(String &data)
{
  UINT bw;
  char buf[32]; // shouldn't need to write more than 32 at once
  unsigned int len = data.length();
  data.toCharArray(buf, len);

  pf_write(buf, len, &bw);    // write at curr r/w pointer position
  pf_write(0, 0, &bw);        // end write operation
  pf_lseek(fatFS.fptr + len); // move read write pointer

}

void errorHalt(char* msg) {
  Serial.print(F("Error: "));
  Serial.println(msg);
  while(1);
}

void setup() {
  SetupLogFile();
}

void loop() {
  counter++;
  String str = "Count: " + String(counter) + "\n";
  SDWrite(str);
}
