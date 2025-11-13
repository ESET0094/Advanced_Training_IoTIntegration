#include <PubSubClient.h>    
#include <WiFi.h>     // Correct include for ESP32
#include <stdlib.h>
#include <stdio.h>
#include <string.h> // Include string.h for memcpy

#define MAX_OBJECTS 3
#define MQTT_BROKER "172.16.103.90" // Replace with your MQTT Broker IP address
#define MQTT_PORT 1883
#define MQTT_SUBSCRIBE_TOPIC "test/temperature"  
#define MQTT_PUBLISH_TOPIC   "test/temperature" 

char ssid[] = "Esya-Training"; 
char password[] = "P@$$w0rd@123"; 

typedef struct {
    int a, b, c, d, e, f;
} ObisCode;

typedef struct {
    ObisCode* code;
    float data;
} CosemObject;

// Global list of objects
CosemObject* objects = NULL; // Defined here, as this is the main file

WiFiClient espClient;
PubSubClient client(espClient);

// // --- Function Prototypes ---
// void make_obis_code(ObisCode* code, int a, int b, int c, int d, int e, int f);
// void make_cosem_object(CosemObject* object, ObisCode* code, float data);
// int compare_obis_code(const ObisCode* a, const ObisCode* b);
// void init_meter();
// void print_cosem_objects();
// void get_cosem_object(CosemObject* result, ObisCode* code);
// void reconnect_mqtt();
// void callback (char* topic, byte* payload, unsigned int length);


// -----------------------------------------------------------------
// Implementation of meter functions (moved above setup/loop for clarity)
// -----------------------------------------------------------------
void make_obis_code(ObisCode* code, int a, int b, int c, int d, int e, int f) {
    if (code == NULL) return;
    code->a = a;
    code->b = b;
    code->c = c;
    code->d = d;
    code->e = e;
    code->f = f;
}

void make_cosem_object(CosemObject* object, ObisCode* code, float data) {
    if (object == NULL || code == NULL) return;
    object->code = code;
    object->data = data;
}

int compare_obis_code(const ObisCode* a, const ObisCode* b) {
    if (a == NULL || b == NULL) return 0;
    return (a->a == b->a &&
            a->b == b->b &&
            a->c == b->c &&
            a->d == b->d &&
            a->e == b->e &&
            a->f == b->f);
}

void init_meter() {
    // Allocate memory for all objects
    objects = (CosemObject*)malloc(sizeof(CosemObject) * MAX_OBJECTS);
    if (!objects) {
        fprintf(stderr, "Memory allocation failed for COSEM objects\n");
        // In an Arduino environment, we just halt execution
        while(1); 
    }

    for (int i = 0; i < MAX_OBJECTS; i++) {
        ObisCode* code = (ObisCode*)malloc(sizeof(ObisCode));
        if (!code) {
            fprintf(stderr, "Memory allocation failed for OBIS code %d\n", i);
            while(1);
        }

        make_obis_code(code, 1, 1, 1, 1, 1, i + 1);
        make_cosem_object(&objects[i], code, (float)(i + 1) * 10.5f);
    }
}

void print_cosem_objects() {
    if (objects == NULL) {
        Serial.println("No COSEM objects initialized.");
        return;
    }
    for (int i = 0; i < MAX_OBJECTS; i++) {
        ObisCode* c = objects[i].code;
        // Use Serial.printf for easier printing in Arduino environment
        Serial.printf("COSEM[%d]: OBIS=%d.%d.%d.%d.%d.%d\tData=%.6f\n",
               i, c->a, c->b, c->c, c->d, c->e, c->f, objects[i].data);
    }
}

void get_cosem_object(CosemObject* result, ObisCode* code) {
    if (objects == NULL || result == NULL || code == NULL) return;

    for (int i = 0; i < MAX_OBJECTS; i++) {
        if (compare_obis_code(objects[i].code, code)) {
            // Copy the data found into the result struct
            result->code = objects[i].code; 
            result->data = objects[i].data;
            return;
        }
    }

    // If not found
    result->code = NULL;
    result->data = 0.0f;
}


// -----------------------------------------------------------------
// Setup Function
// -----------------------------------------------------------------
void setup() {
    Serial.begin(115200);
    delay(100);
    Serial.println("\nStarting up...");

    init_meter(); 
    Serial.println("COSEM objects initialized.");

    WiFi.begin(ssid, password);
    while (WiFi.status() != WL_CONNECTED) {
        delay(500);
        Serial.print(".");
    }
    Serial.println("\nWiFi connected successfully ");

    client.setServer(MQTT_BROKER, MQTT_PORT);
    client.setCallback(callback); 

    reconnect_mqtt();
}

// -----------------------------------------------------------------
// Loop Function
// -----------------------------------------------------------------
void loop() {
    if (!client.connected()) {
        reconnect_mqtt();
    }
    client.loop(); 
}

// -----------------------------------------------------------------
// MQTT Implementation Functions
// -----------------------------------------------------------------

void reconnect_mqtt() {
    while (!client.connected()) {
        Serial.print("Attempting MQTT connection...");
        String clientId = "ESPClient-";
        clientId += String(random(0xffff), HEX);
        
        if (client.connect(clientId.c_str())) {
            Serial.println("connected");
            client.subscribe(MQTT_SUBSCRIBE_TOPIC);
            Serial.print("Subscribed to topic: ");
            Serial.println(MQTT_SUBSCRIBE_TOPIC);
        } else {
            Serial.print("failed, rc=");
            Serial.print(client.state());
            Serial.println(" trying again in 5 seconds");
            delay(5000);
        }
    }
}

void callback (char* topic, byte* payload, unsigned int length) {
    Serial.print("Message arrived on topic: ");
    Serial.println(topic);

    // Make sure to use string functions (memcpy, strlen) if needed
    // char message[length + 1];
    // memcpy(message, payload, length);
    // message[length] = '\0';
    // Serial.printf("Payload: %s\n", message);
    String message;
    for (int i=0; i<length; i++)
    {
        message+= (char)payload[i];
    }
    Serial.println(message);
    const char* charPointer = message.c_str();
    ObisCode query_code; 

    // delay(100);
    // // Check if exactly 6 arguments were successfully parsed
    if (sscanf(charPointer, "%d.%d.%d.%d.%d.%d", 
            &query_code.a, &query_code.b, &query_code.c, 
               &query_code.d, &query_code.e, &query_code.f) == 6) {
        
    char result = "ObisCode :- "
    //   if (result_obj.code != NULL) {
    //          char response_payload[32]; // Increase buffer size for sprintf
    //          // Use sprintf which is more standard than dtostrf
    //          sprintf(response_payload, "%.3f", result_obj.data); 
    //          client.publish(MQTT_PUBLISH_TOPIC, response_payload);
    //      } else {
    //          client.publish(MQTT_PUBLISH_TOPIC, "Not Found");
    //      }

    } else {
     client.publish(MQTT_PUBLISH_TOPIC, "Parse Error");
     }
}
