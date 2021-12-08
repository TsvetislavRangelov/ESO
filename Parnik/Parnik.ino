#include "Display.h"
#include "DHT11.h"

//pins
const int LED_YELLOW = 7;
const int LED_GREEN = 5;
const int LED_BLUE = 6;
const int POTPIN = A0;
const int Button = 9;
const int LDR = A2;
const int NTC = A1;

//global variables
unsigned long sprinkleTime;
const int maxTime = 30000; // maximum runtime of sprinklers (in milliseconds)

float humidity;
int light;
float temp;
int state = 0;
int lastButtonState = HIGH;

//windows variables
int windowsAngle;
bool windowsCheck;

float windowsUpperTH = 18.00;
float windowsLowerTH = 16.00;

//shades variables

bool shadesCheck;

int shadesUpperTH =  300;
int shadesLowerTH =  150;


//sprinkler variables

bool sprinklersCheck = false;
float sprinklersLowerTH = 45.00;


void setup() {
  Display.clear();
  Serial.begin(9600);

  pinMode(LED_YELLOW, OUTPUT);
  pinMode(LED_GREEN, OUTPUT);
  pinMode(LED_BLUE, OUTPUT);
  pinMode(POTPIN, INPUT);
  pinMode(Button, INPUT_PULLUP);
  pinMode(NTC, INPUT);
  pinMode(LDR, INPUT);
}

void loop() {
  humidity = DHT11.getHumidity();
  int windowsAngle = analogRead(POTPIN);
  unsigned long currentTime = millis();
  int button = digitalRead(Button);
  light = analogRead(LDR);
  //getting the sensor values
  temp = DHT11.getTemperature();
  //Sprinklers();  sprinklers are state 2
  //Shades();  shades are state 1
  //Windows();  windows are state 0
  Serial.println(humidity);

    temp = DHT11.getTemperature();
  windowsAngle = analogRead(POTPIN);

  windowsAngle = map(windowsAngle, 0, 1023, 0, 20);


  if (temp >= windowsUpperTH && windowsAngle >= 1) {
    digitalWrite(LED_GREEN, HIGH);
    windowsCheck = true;

  
  }
   if (temp <= windowsLowerTH) {
    windowsCheck = false;
    digitalWrite(LED_GREEN, LOW);
    windowsAngle = map(windowsAngle, 0, 1023, 0, 20);
   
  }
   if (temp >= windowsUpperTH && windowsAngle == 0) {
    windowsCheck = false;
    digitalWrite(LED_GREEN, LOW);
    windowsAngle = map(windowsAngle, 0, 1023, 0, 20);
   
  }

  if (light >= shadesUpperTH) {
    shadesCheck = true;
    digitalWrite(LED_YELLOW, HIGH);
  }
  else if (light <= shadesLowerTH) {
    shadesCheck = false;
    digitalWrite(LED_YELLOW, LOW);
  }
  humidity = DHT11.getHumidity();

//problem 1
  if (humidity <= sprinklersLowerTH) {
    if (currentTime - sprinkleTime > maxTime) {
      digitalWrite(LED_BLUE, HIGH);
      sprinklersCheck = true;

      sprinkleTime = currentTime;
      
    }
    if(humidity > sprinklersLowerTH){
      digitalWrite(LED_BLUE, LOW);
      sprinklersCheck = false;
      }
  }
  //do the display feature here (button only)

  Serial.println(light);

  if (lastButtonState != button) {
    lastButtonState = button;
    if (button == LOW) {
     int lastPotPinState = windowsAngle;
     int currentPotPinState = map(currentPotPinState, 0, 1023, 0, 20);
      state++;
      if (state > 3) {
        Display.clear();
        state = 0;
      }
      //problem 2
//      if(currentPotPinState != lastPotPinState){
//          Display.clear();
//          state = 3;
//        }
    }
    lastButtonState = button;
    delay(40);
  }
  if (state == 0) {
    Display.clear();
    Display.show(temp);
  }
  else if (state == 1) {
    Display.clear();
    Display.show(light);
  }
  else if (state == 2) {
    Display.clear();
    Display.show(humidity);
  }
  else if (state == 3) {
    Display.clear();
    Display.show(windowsAngle);
  }

}


//void Windows() {
//  temp = DHT11.getTemperature();
//  windowsAngle = analogRead(POTPIN);
//
//  windowsAngle = map(windowsAngle, 0, 1023, 0, 20);
//
//
//  if (temp >= windowsUpperTH && windowsAngle >= 1) {
//    digitalWrite(LED_GREEN, HIGH);
//    windowsCheck = true;
//
//    Display.show(windowsAngle);
//  }
//  else if (temp <= windowsLowerTH) {
//    windowsCheck = false;
//    digitalWrite(LED_GREEN, LOW);
//    windowsAngle = map(windowsAngle, 0, 1023, 0, 20);
//    Display.show(windowsAngle);
//  }
//  else if (temp >= windowsUpperTH && windowsAngle == 0) {
//    windowsCheck = false;
//    digitalWrite(LED_GREEN, LOW);
//    windowsAngle = map(windowsAngle, 0, 1023, 0, 20);
//    Display.show(windowsAngle);
//  }
//}

//void Shades() {
////  light = analogRead(LDR);
////
////  if (light >= shadesUpperTH) {
////    shadesCheck = true;
////    digitalWrite(LED_YELLOW, HIGH);
////  }
////  else if (light <= shadesLowerTH) {
////    shadesCheck = false;
////    digitalWrite(LED_YELLOW, LOW);
////  }
//
//}

void Sprinklers() {
//  unsigned long currentTime = millis();
//  humidity = DHT11.getHumidity();
//
//  if (humidity >= sprinklersUpperTH) {
//    if (currentTime - sprinkleTime > maxTime) {
//      digitalWrite(LED_BLUE, HIGH);
//      sprinklersCheck = true;
//
//      sprinkleTime = currentTime;
//    }
//
//  }
}
