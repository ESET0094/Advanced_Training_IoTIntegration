#include"data_refresh.h"
#include <string.h>
#include"MeterReadings.h"
#include"MeterInfo.h"
#include "inc\storage.h"
#include <stdio.h>
#include <time.h>
#include "security.h"
#include <stdlib.h>
#include <stdint.h>
#include <stm32f3xx_hal.h>

int main(void) {
    // Initialize system
    HAL_Init();
    // Initialize storage
    SystemClock_Config();

    storage_init();
    // Initialize data refresh module
    data_refresh_init(); 
    // Initialize meter info and readings
    

    while (1) {
        // Main loop
        // Example: Add a daily data entry
    daily_data_t new_entry = { .timestamp = 1627849200, .consumption = 15.5 };
    data_refresh_add_entry(&new_entry);

    // Send report (placeholder function)
    data_refresh_send_report();
    }
    return 0;
}