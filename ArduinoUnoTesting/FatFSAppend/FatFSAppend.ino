// Test appending a file using the Petit FS library
// adapted from PetitFS.ino in PetitFS library

// Petit FS SD Library
#include "PetitFS.h"

#include "string.h"

// SD
const char* filePath = "LOG.CSV";
FATFS fatFS;

// Test param
unsigned int counter = 0;

bool sdReady = false;

void WaitForSDReady()
{
  unsigned int i = 0;

  FRESULT res = 1;
  while (res != 0)
  {
    res = pf_mount(&fatFS);
    i++;
    if (i % 100 == 0)
    {
      Serial.println(F("Scanning for SD..."));
    }
    delay(10);
  }
  Serial.print(F("SD card mounted in "));
  Serial.print(i);
  Serial.println(F(" tries"));
}

void SetupLogFile()
{
  uint8_t buf[32];
  unsigned long int fileCounter = 0;
  bool endFile = false;
  FRESULT res;

  //delay(1000);

  //pinMode(10, OUTPUT);
  //res = pf_mount(&fatFS);
  //if (res) errorHalt("pf_mount", res);
  WaitForSDReady();

  res = pf_open(filePath);
  if (res) errorHalt("pf_open", res);

  //read to the end of the file
  while (!endFile) {
    UINT nr;
    res = pf_read(buf, sizeof(buf), &nr);
    if (res) errorHalt("pf_read", res);
    if (nr == 0) errorHalt("out of file space", res);
    //Serial.write(buf, nr);

    // check for end of written data, "\n "
    for(int i = 0; i < sizeof(buf) - 1; i++)
    {
      char symbol[] = {buf[i], buf[i+1]};
      //char
      if(symbol[0] == '\n' && symbol[1] == ' ')
      {
        Serial.println(F("End of file found!"));
        fileCounter += i + 1; // set new offset to write at
        endFile = true;
        break;
      }
    }
    if (!endFile) fileCounter += sizeof(buf);
  }

  // set read/write pointer
  res = pf_lseek(fileCounter);
  if (res) errorHalt("pf_lseek", res);

  Serial.println(F("Finished setup sequence!"));
  sdReady = true;
}

// Append at current read/write pointer position
void SDWrite(String &data)
{
  UINT bw;
  FRESULT res;
  char buf[32]; // shouldn't need to write more than 32 at once
  unsigned int len = data.length();
  
  data.toCharArray(buf, len);

  //fatFS.fptr += len;
  res = pf_write(buf, len, &bw);      // write at curr r/w pointer position
  if(res) errorHalt("pf_write", res);
  //pf_write(0, 0, &bw);        // end write operation
  res = pf_lseek(fatFS.fptr + len);   // move read write pointer
  if(res) errorHalt("pf_lseek", res);
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
  if(!sdReady)
  {
    Serial.println(F("loop called before setup is finished! berry bad!"));
    while(1);
  }
  counter++;
  String str = "Count: " + String(counter) + "\n ";
  SDWrite(str);
  Serial.print(str);
  //Serial.println(", fptr: " + fatFS.fptr);
  delay(1000);
}
