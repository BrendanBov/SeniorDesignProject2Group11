#include <SoftwareSerial.h>

SoftwareSerial hc06(2,3);

void setup() {
  Serial.begin(9600);
  hc06.begin(9600);
}

void loop() {
  hc06.write("test\n");
  delay(100);
}
