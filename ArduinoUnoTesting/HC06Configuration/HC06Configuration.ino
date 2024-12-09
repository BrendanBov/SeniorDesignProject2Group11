#include <SoftwareSerial.h>

const unsigned long BAUDRATE = 115200;

// Bluetooth
//SoftwareSerial hc06(1,2);

void setup() {
  Serial.begin(BAUDRATE);
  delay(1500);
  //SetupBluetooth();
  //DefaultCommand();
}

void loop() {
  // put your main code here, to run repeatedly:

}

void DefaultCommand()
{
  //hc06.begin(115200);
  delay(1500);

  //hc06.print("AT+VERSION?\r\n");
  Serial.print("AT");

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

}

/*
void SetupBluetooth()
{
  const unsigned long rates[] = {1200, 2400, 4800, 9600, 19200, 38400, 57600, 115200, 230400, 460800, 921600, 1382400};
  //const unsigned long rates[] = {9600,19200,38400,57600,115200,230400,460800};
  //const unsigned long rates[] = {115200};
  //hc06.begin(38400); // start at hc06 default baudrate

  //delay(1500);
  
  // BAUD5 = 19200
  //hc06.print(F("AT"));  // Test Echo
  //hc06.print(F("AT+BAUD8"));  // configure baudrate
  //hc06.print(F("AT+PIN1987"));  // configure PIN

  //delay(1500);

  for(int i = 0; i < sizeof(rates) / sizeof(rates[0]); i++)
  {
    hc06.begin(rates[i]);
    delay(1500);

    hc06.print(F("AT"));  // Test Echo
    delay(1500);

    if (hc06.available()) 
    {
      Serial.print("baurate is ");
      Serial.println(rates[i]);
      Serial.println("Response="+ hc06.readString());
      break;
    }

    Serial.print("baudrate not ");
    Serial.println(rates[i]);

    hc06.end();
    delay(1500);
  }

  //Serial.println("Response="+ hc06.readString());

  // restart software serial
  //hc06.end();
  //hc06.begin(BAUDRATE);
}
*/
