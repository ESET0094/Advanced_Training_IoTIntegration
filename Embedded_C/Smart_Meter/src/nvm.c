#include "nvm.h"
#include "stm32f3xx_hal.h"
#include "string.h"

#define NVM_BASE_ADDR 0x08080000U // EEPROM / FLASH ADDDRESS

void NVM_Init(void) {
    // Initialize NVM if needed
}

void NVM_SaveGPSData(const gps_data_t* data) {
  HAL_FLASH_Unlock();
  uint32_t *ptr =(uint32_t *)NVM_BASE_ADDR;
  HAL_FLASH_PROGRAM(FLASH_TYPEPROGRAM_WORD, (uint32_t)ptr, *((uint32_t*)&data->latitude));
    HAL_FLASH_PROGRAM(FLASH_TYPEPROGRAM_WORD, (uint32_t)(ptr + 1), *((uint32_t*)&data->longitude));
    HAL_FLASH_Lock();
}
