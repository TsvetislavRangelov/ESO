#include "Display.h"
#include "DHT11.h"

// testing again


//testing again 2


int test = 1;

const int LED_YELLOW = 7;
const int LED_GREEN = 5;
const int LED_BLUE = 6;
const int POTPIN = A0;
const int rightButton = 9;
const int leftButton = 8;
const int LDR = A2;
const int NTC = A1;

bool windowsCheck = false;


int windowsUpperTH = analogRead(DHT11.getTemperature()) + 2;
int windowsLowerTH = analogRead(DHT11.getTemperature()) - 2;

void setup() {
  
  pinMode(LED_YELLOW, OUTPUT);
  pinMode(LED_GREEN, OUTPUT);
  pinMode(LED_BLUE, OUTPUT);
  pinMode(POTPIN, INPUT);
  pinMode(rightButton, INPUT_PULLUP);
  pinMode(leftButton, INPUT_PULLUP);
}

void loop() {
  int windowsAngle = analogRead(POTPIN);

  windowsAngle = map(windowsAngle, 0, 1023, 0, 20);
  Display.show(windowsAngle);
  
  

   
  
  

}

void Temperature(){
    float temp = DHT11.getTemperature();
    Serial.println(temp);
  }
