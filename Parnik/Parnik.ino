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
unsigned long currentTime = millis();
//unsigned long maxTime = millis(30000); // maximum runtime of sprinklers

float humidity;
int light;
float temp;
int state = 0;

//windows variables
bool windowsCheck;

float windowsUpperTH = 18.00;
float windowsLowerTH = 16.00;

//shades variables

bool shadesCheck;

int shadesUpperTH =  300;
int shadesLowerTH =  150;


//sprinkler variables

bool sprinklersCheck;

float sprinklersUpperTH = 45.00;
float sprinklersLowerTH = 42.00;


void setup() {
  Display.clear();
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
  light = analogRead(LDR);
  //getting the sensor values
  temp = DHT11.getTemperature();
  //Sprinklers();
  //using a sequence state pattern here
  Shades(); // shades are state 2
  Windows(); // windows are state 1

  //do the display feature here (button only)
  
  //Serial.println(humidity);
  Serial.println(temp);
}

//

void Windows(){
 float temp = DHT11.getTemperature();
  int windowsAngle = analogRead(POTPIN);

 windowsAngle = map(windowsAngle, 0, 1023, 0, 20);
  

 if(temp >= windowsUpperTH && windowsAngle >= 1){
    digitalWrite(LED_GREEN, HIGH);
    windowsCheck = true;
    
    Display.show(windowsAngle);
    }
   else if(temp <= windowsLowerTH){
      windowsCheck = false;
      digitalWrite(LED_GREEN, LOW);
      windowsAngle = map(windowsAngle, 0, 1023, 0, 20);
      Display.show(windowsAngle);
   }
   else if(temp >= windowsUpperTH && windowsAngle == 0){
      windowsCheck = false;
      digitalWrite(LED_GREEN, LOW);
       windowsAngle = map(windowsAngle, 0, 1023, 0, 20);
      Display.show(windowsAngle);
    }
 }

void Shades(){
    light = analogRead(LDR);

    if(light >= shadesUpperTH){
        shadesCheck = true;
        digitalWrite(LED_YELLOW, HIGH);
      }
    else if(light <= shadesLowerTH){
        shadesCheck = false;
        digitalWrite(LED_YELLOW, LOW);
      }
   
  }

void Sprinklers(){
   unsigned long currentTime = millis();
   humidity = DHT11.getHumidity();

   if(humidity <= sprinklersUpperTH){
      sprinklersCheck = true;
      
    }
  }
