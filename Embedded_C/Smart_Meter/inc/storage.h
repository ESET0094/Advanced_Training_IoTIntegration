#ifndef STORAGE_H
#define  STORAGE_H

#include<stdint.h>
#include "inc\MeterReadings.h"
#include "inc\MeterInfo.h"

// storage addresses in flash 
#define FLASH_BASE_AADDR 0x08060000U
#define STORAGE_SIZE 0X2000

//Data blocks 
typedef struct {
    meter_readings_t readings;
    uint32_t crc;

} storage_readings_block_t;

typedef struct {
    consumer_info_t consumer;
    meter_hardware_info_t hardware;
    uint32_t crc;
} storage_info_block_t;
 // APIs

 void storage_init(void);
 int storage_save_readings(const meter_readings_t* data);
 int storage_load_readings(meter_readings_t* data);
int storage_save_info(const consumer_info_t* cinfo, const meter_hardware_info_t* hinfo);
int storage_load_info(consumer_info_t* cinfo, meter_hardware_info_t* hinfo);

// Utility
uint32_t calculate_crc32(const void* data, size_t length);

#endif


