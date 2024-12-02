#include <SoftwareSerial.h>

const unsigned long BAUDRATE = 115200;

// Bluetooth
SoftwareSerial hc06(2,3);

void setup() {
  Serial.begin(BAUDRATE);
  SetupBluetooth();

}

void loop() {
  // put your main code here, to run repeatedly:

}

void SetupBluetooth()
{
  hc06.begin(115200); // start at hc06 default baudrate

  delay(1500);
  
  // BAUD5 = 19200
  hc06.print(F("AT"));  // Test Echo
  //hc06.print(F("AT+BAUD8"));  // configure baudrate
  //hc06.print(F("AT+PIN1987"));  // configure PIN

  delay(1500);

  if (hc06.available()) 
  {
    Serial.println("hc06 is available");
    Serial.println("Response="+ hc06.readString());
  }
  else
  {
    Serial.println("hc06 not available");
  }

  /*while(!hc06.available())
  {
    Serial.println(F("Waiting..."));
    hc06.print(F("AT+BAUD5"));  // configure baudrate
    delay(1000);
  }*/
  
  //Serial.println("Response="+ hc06.readString());

  // restart software serial
  hc06.end();
  hc06.begin(BAUDRATE);
}
