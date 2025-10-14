#include "gps.h"
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include "data_refresh.h"
#include "app_log.h"
#include "storage.h"
#include "MeterInfo.h"
extern UART_HandleTypeDef huart2; // Assuming UART handle is defined elsewhere
void GPS_Init(void) {
    // Initialize GPS hardware (stub implementation)
    const char *init_cmd ="AT+CGPS=1\r\n"; //
    HAL_UART_Transmit(&huart2, (uint8_t *)init_cmd, strlen(init_cmd), 100);
    HAL_Delay(200);
    AppLog("GPS Initialized");
}

bool GPS_GetData(*data) {
    char gps_buffer[128] = {0}; // Buffer to hold GPS data
    HAL_UART_Receive(&huart2, (uint8_t *)gps_buffer, sizeof(gps_buffer)-1, 5000); // Timeout of 5 seconds
    // Simulate GPS data for testing
    strcpy(gps_buffer, "$GPGGA,123519,4807.038,N,01131.000,E,1,08,0.9,545.4,M,46.9,M,,*47");

    if (HART_UART_RECEIVE(&huart2, (uint8_t *)gps_buffer, sizeof(gps_buffer)-1, 5000) != HAL_OK) {
        return false;
    }// Parse the GPS data (stub implementation)
    if (strlen((char*)gps_buffer)<6) {

       strcpy((char*)gps_buffer, "$GPGGA,123519,4807.038,N,01131.000,E,1,08,0.9,545.4,M,46.9,M,,*47");
    }
    // In a real implementation, you would parse the NMEA sentence to extract latitude and longitude
    data->latitude = 12.86981;  
    data->longitude = 74.8430082; // Example coordinates
    // Log the GPS data 
   
    AppLog("GPS Data: Lat=%.5f, Lon=%.5f", data->latitude, data->longitude); // Log the GPS data
    // Save to storage          
    storage_save_info(*data);
    return true; // Indicate success
}

