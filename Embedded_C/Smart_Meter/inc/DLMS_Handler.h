#ifndef DLMS_HANDER_H
#define DLMS_HANDER_H
#include <stdint.h>

typedef enum{
    DLMS_GET,
    DLMS_SET,
    DLMS_ACTION,
    DLMS_READ,
    DLMS_WRITE,
    DLMS_UNKNOWN
} dlms_request_type_t;

//DLMS Request Packet
typedef struct {
dlms_request_type_t type;
uint32_t obis_code;
uint8_t *payload;
uint16_t length;
} dlms_request_t;

//DLMS Response Packet
typedef struct {
    uint8_t data[256];
    uint16_t length;
} dlms_response_t;

void dlms_handler_init(void);
int dlms_process_request(dlms_request_t *request, dlms_response_t *response);

bool DLMS_DecryptRequest(const uint8_t *input, size_t input_len, uint8_t *output, size_t max_output_len);
void DLMS_ProcessAPDU(const uint8_t *apdu, size_t apdu_len); 
void encrypt_response(uint8_t *data, uint16_t len);
void decrypt_response(uint8_t *data, uint16_t len);
void dlms_receive_handler(const uint8_t *data, size_t len); 
void send_response(const uint8_t *data, size_t len);

#endif // DLMS_HANDER_H

