#ifndef
#define GPS_H

#include <stdint.h>
#include <stdbbool.h>
#define FILE_PATH "C:\\Logs\\gps_log.txt"



void GPS_Init(void);
bool GPS_GetData(gps_data_t* data);

#endif 
