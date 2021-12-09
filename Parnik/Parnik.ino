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

const int humidityInterval = 2000;
unsigned long humidityTime;
unsigned long tempTime;
unsigned long sprinkleTime = millis();
unsigned long currentTime = millis();
const int sprinklersRunTime = 30000; // runtime of sprinklers (in milliseconds)
const int TempInterval = 2000; // getting the temperature every half second to increase performance of the program

float temp;
float humidity;

int state = 0;
int lastButtonState = HIGH;

//windows variables
int windowsAngle;
bool windowsCheck;

float windowsUpperTH = 27.00;
float windowsLowerTH = 25.00;

//shades variables

bool shadesCheck;

int shadesUpperTH =  300;
int shadesLowerTH =  150;


//sprinkler variables

bool sprinklersCheck = false;
float sprinklersLowerTH = 50.00;


void setup() {
  getHumidity();
  getTemperature();
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
  currentTime = millis();
  int button = digitalRead(Button);
  int light = analogRead(LDR);

  windowsAngle = analogRead(POTPIN);
  windowsAngle = map(windowsAngle, 0, 1023, 0, 20);
  if (currentTime - humidityTime > humidityInterval) {
    getHumidity();
    humidityTime = currentTime;
  }

  if (currentTime - tempTime > TempInterval) {
    getTemperature();
    tempTime = currentTime;
  }

  // windows
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
  // shades
  if (light >= shadesUpperTH) {
    shadesCheck = true;
    digitalWrite(LED_YELLOW, HIGH);
  }
  else if (light <= shadesLowerTH) {
    shadesCheck = false;
    digitalWrite(LED_YELLOW, LOW);
  }


  //problem 1
  if (humidity <= sprinklersLowerTH) {
    //    Serial.println(sprinkleTime);
    //    Serial.println(currentTime);
    //    Serial.println(sprinkleTime - sprinklersRunTime);
    digitalWrite(LED_BLUE, HIGH);
    sprinklersCheck = true;
    sprinkleTime = currentTime;
  }

else {

//if statement shorthanded
  //unsigned long asd = sprinkleTime > sprinklersRunTime ? sprinkleTime - sprinklersRunTime : 0;
  if (sprinkleTime + sprinklersRunTime < currentTime  ) {
    digitalWrite(LED_BLUE, LOW);
    sprinklersCheck = false;

  }
}
//do the display feature here (button only)

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
    //do bools here
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
void getTemperature() {
  temp = DHT11.getTemperature();
}
void getHumidity() {
  humidity = DHT11.getHumidity();
}
