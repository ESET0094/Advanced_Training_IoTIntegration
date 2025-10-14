// DLMS_Handler.c
#include "DLMS_Handler.h"
#include "meter_readings.h"
#include "meter_info.h"
#include <string.h>
#include <stdio.h>
#include <stdbool.h>

// Example XOR key for encryption/decryption
static const uint8_t xor_key_stream[] = {0xAA, 0x55, 0xF0, 0x0F};

// Initialization
void dlms_handler_init(void) {
    meter_info_init();
    meter_readings_init();
}

// --- Core DLMS Request Processor ---
int dlms_process_request(dlms_request_t *req, dlms_response_t *resp) {
    memset(resp, 0, sizeof(dlms_response_t));

    switch(req->type) {
        case DLMS_GET:
        case DLMS_READ:
            if (req->obis_code == 0x01000100) {
                resp->length = snprintf((char*)resp->data, sizeof(resp->data),
                                        "kWh Import: %.2f",
                                        g_meter_readings.kWh_import);
            } else {
                resp->length = snprintf((char*)resp->data, sizeof(resp->data),
                                        "Unknown OBIS: 0x%08lX",
                                        (unsigned long)req->obis_code);
            }
            break;

        case DLMS_SET:
        case DLMS_WRITE:
            if (req->obis_code == 0x01000400 && req->payload != NULL) {
                strncpy(g_consumer_info.tariff_plan,
                        (char*)req->payload,
                        sizeof(g_consumer_info.tariff_plan));
                resp->length = snprintf((char*)resp->data, sizeof(resp->data),
                                        "Tariff Updated: %s",
                                        g_consumer_info.tariff_plan);
            }
            break;

        case DLMS_ACTION:
            if (req->obis_code == 0x02000100) {
                g_meter_readings.kWh_import = 0;
                resp->length = snprintf((char*)resp->data, sizeof(resp->data),
                                        "Energy counter reset");
            }
            break;

        default:
            resp->length = snprintf((char*)resp->data, sizeof(resp->data),
                                    "Invalid Request");
            break;
    }

    // Encrypt response before sending
    encrypt_response(resp->data, resp->length);
    return 0; // success
}

// --- XOR Encryption ---
void encrypt_response(uint8_t *data, uint16_t len) {
    if (!data || len == 0) return;
    uint8_t keylen = sizeof(xor_key_stream);
    for (uint16_t i = 0; i < len; i++) {
        data[i] ^= xor_key_stream[i % keylen];
    }
}

// --- XOR Decryption ---
void decrypt_response(uint8_t *data, uint16_t len) {
    encrypt_response(data, len); // symmetric XOR
}

// --- Decrypt Incoming DLMS Request ---
bool DLMS_DecryptRequest(const uint8_t *input, size_t input_len,
                         uint8_t *output, size_t max_output_len) {
    if (!input || !output || input_len == 0 || input_len > max_output_len)
        return false;

    memcpy(output, input, input_len);
    decrypt_response(output, (uint16_t)input_len);

    // Optional sanity check: DLMS APDUs start with 0xE6 or 0xC4
    if (output[0] != 0xE6 && output[0] != 0xC4) {
        AppLog("DLMS decrypt: invalid APDU header 0x%02X", output[0]);
        return false;
    }

    return true;
}

// --- DLMS APDU Processor (Dispatcher) ---
void DLMS_ProcessAPDU(uint8_t *apdu, size_t len) {
    dlms_request_t req = {0};
    dlms_response_t resp = {0};

    // Simplified APDU parser: first byte = type, next 4 bytes = OBIS code
    if (len < 5) return;

    req.type = apdu[0]; // e.g., DLMS_GET / DLMS_SET
    req.obis_code = (apdu[1] << 24) | (apdu[2] << 16) | (apdu[3] << 8) | apdu[4];
    req.payload = (len > 5) ? &apdu[5] : NULL;
    req.length = (len > 5) ? (len - 5) : 0;

    dlms_process_request(&req, &resp);

    // Send response over MQTT or UART
    send_response(resp.data, resp.length);
}

// --- DLMS Receive Handler (Entry Point) ---
void dlms_receive_handler(const uint8_t *payload, size_t len) {
    uint8_t decrypted[512] = {0};
    if (DLMS_DecryptRequest(payload, len, decrypted, sizeof(decrypted))) {
        DLMS_ProcessAPDU(decrypted, len);
    } else {
        AppLog("DLMS receive: decryption failed");
    }
}

// --- Example stub to send response ---
void send_response(uint8_t *data, size_t len) {
    // Replace with MQTT publish or UART send
    AppLog("Sending Response: %.*s", (int)len, data);
}