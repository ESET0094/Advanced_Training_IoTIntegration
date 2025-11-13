#define LED_PIN 2

String inputString = ""; // Use 'String' (capital S) for the Arduino String class
bool stringComplete = false;


void setup() {
  // put your setup code here, to run once:
  Serial.begin(115200);
  pinMode(LED_PIN, OUTPUT);
  digitalWrite(LED_PIN, LOW);
}


void loop() {
  // --- Process incoming serial data ---
  // The 'serialEvent' function (defined below) handles the input and sets 'stringComplete' to true when a line ends.

  if (stringComplete) {
    inputString.trim(); // Remove leading/trailing whitespace

    if (inputString.equalsIgnoreCase("on")) {
      digitalWrite(LED_PIN, HIGH);
      Serial.println("LED ON");
    }
    else if (inputString.equalsIgnoreCase("off")) {
      digitalWrite(LED_PIN, LOW); // Add the logic to turn the LED off
      Serial.println("LED OFF");
    }
    else {
      Serial.println("Unknown Command");
    }

    // Clear the string and flag for the next command
    inputString = "";
    stringComplete = false;
  }
}


/*
  SerialEvent occurs whenever new data comes in the hardware serial RX. This
  routine is run between each time loop() runs, so using delay() in loop()
  might cause it to be missed.
*/
void serialEvent() {
  while (Serial.available()) {
    // get the new byte:
    char inChar = (char)Serial.read();

    // add it to the inputString:
    inputString += inChar;

    // if the incoming character is a newline or a carriage return, set a flag so the main loop can do something about it:
    if (inChar == '\n' || inChar == '\r') {
      stringComplete = true;
    }
  }
}
