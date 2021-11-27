#include "Display.h"
#include "DHT11.h"

//pins
const int LED_YELLOW = 7;
const int LED_GREEN = 5;
const int LED_BLUE = 6;
const int POTPIN = A0;
const int rightButton = 9;
const int leftButton = 8;
const int LDR = A2;
const int NTC = A1;

//global variables
int state = 0;

//windows variables
bool windowsCheck;

float windowsUpperTH = 22.00;
float windowsLowerTH = 19.00;

int closedWindows = 0;

void setup() {


  Serial.begin(9600);
  
  pinMode(LED_YELLOW, OUTPUT);
  pinMode(LED_GREEN, OUTPUT);
  pinMode(LED_BLUE, OUTPUT);
  pinMode(POTPIN, INPUT);
  pinMode(rightButton, INPUT_PULLUP);
  pinMode(leftButton, INPUT_PULLUP);
  pinMode(NTC, INPUT);
  pinMode(LDR, INPUT);
}

void loop() {
  //getting the sensor values
  float temp = DHT11.getTemperature();
  int light = analogRead(LDR);
  Windows();

  Serial.println(temp);



}

void Windows(){
  float temp = DHT11.getTemperature();
  int windowsAngle = analogRead(POTPIN);

  windowsAngle = map(windowsAngle, 0, 1023, 0, 20);
  Display.show(windowsAngle);

  if(temp >= windowsUpperTH || windowsAngle >= 1 && windowsAngle <= 20){
      windowsCheck = true;
      digitalWrite(LED_GREEN, HIGH);
    }
   else if(temp <= windowsLowerTH || windowsAngle == 0 ){
      windowsCheck = false;
      digitalWrite(LED_GREEN, LOW);
    }
  
  }
