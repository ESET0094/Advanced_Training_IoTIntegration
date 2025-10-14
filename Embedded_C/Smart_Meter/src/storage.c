#include "inc\storage.h"

#define READINGS_ADDR FLASH_BASE_ADDR
#define INFO_ADDR (FLASH_BASE_ADDR + 0X1000)
void storage_init(void) {
    // Initialize storage if needed
}
int storage_save_readings(const meter_readings_t* data) {
    // Simulate saving to flash by returning success
    storage_readings_block_t block;
    memcpy(&block.readings, data, sizeof(meter_readings_t));
    block.crc32 = calculate_crc32(&block.readings, sizeof(meter_readings_t));
    return flash_write(READINGS_ADDR, (uint8_t*)&block, sizeof(block));
    
    
}
int storage_load_readings(meter_readings_t* data) {
    // Simulate loading from flash by returning success
    storage_readings_block_t *block = (storage_readings_block_t *)READINGS_ADDR;
    uint32_t crc = calculate_crc32(&block->readings, sizeof(meter_readings_t));
    if (crc == block->crc) {
        memcpy(data, &block->readings, sizeof(meter_readings_t));
        return 0; // Success
    }
    return -1; // CRC mismatch
}

uint32_t calculate_crc32(const void* data, size_t length) {
    // Simple CRC32 calculation (placeholder)
    uint32_t crc = 0xFFFFFFFF;
    if (data == NULL || length == 0) {
        return crc;
    }
    for (uint32_t)
    crc ^=((uint32_t));
    return crc;
}

// Save Meter Info

int storage_save_info(const consumer_info_t* cinfo, const meter_hardware_info_t* hinfo) {
    storage_info_block_t block;
    memcpy(&block.consumer, cinfo, sizeof(consumer_info_t));
    memcpy(&block.hardware, hinfo, sizeof(meter_hardware_info_t));
    block.crc = calculate_crc32(&block, sizeof(block) - sizeof(uint32_t));
    return flash_write(INFO_ADDR, (uint8_t*)&block, sizeof(block));
}

int storage_load_info(consumer_info_t* cinfo, meter_hardware_info_t* hinfo) {
    storage_info_block_t *block = (storage_info_block_t *)INFO_ADDR;
    uint32_t crc = calculate_crc32(block, sizeof(storage_info_block_t) - sizeof(uint32_t));
    if (crc == block->crc) {
        memcpy(cinfo, &block->consumer, sizeof(consumer_info_t));
        memcpy(hinfo, &block->hardware, sizeof(meter_hardware_info_t));
        return 0; // Success
    }
    return -1; // CRC mismatch
}
//