#include<SoftwareSerial.h>

SoftwareSerial microUSB(5,4);

void setup() {
  // put your setup code here, to run once:
  microUSB.begin(115200);
  delay(1000);
}

void loop() {
  // put your main code here, to run repeatedly:
  microUSB.print(F("26/11/2024,21:04:07.000,36"));
  microUSB.print(char(176));
  microUSB.print(F("10'01.69\"N,097"));
  microUSB.print(char(176));
  microUSB.print(F("04'09.96\"W,5,316.7,0.180,-0.090,9.510,-0.002,0.003,0.001,54.688,-16.875,-76.875\n"));
  delay(200);
}
