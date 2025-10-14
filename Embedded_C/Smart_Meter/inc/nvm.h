#ifndef NVM_H
#define NVM_H

#include <stdint.h>
#include "gps.h"

void NVM_Init(void);
int NVM_SaveGPSData(const gps_data_t* data);

#endif