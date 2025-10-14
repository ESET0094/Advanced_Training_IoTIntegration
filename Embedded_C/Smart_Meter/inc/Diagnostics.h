typedef enum {
    TAMPER_NONE = 0,
    TAMPER_MAGNETIC = 1,
    TAMPER_OPEN_COVER = 2, 
    TAMPER_REVERSE_CONNECTION = 3
} tamper_event_t;
#ifndef DIAGNOSTICS_H
#define DIAGNOSTICS_H
#include <stdint.h>
#include <stddef.h>
#include "MeterReadings.h"
#include "MeterInfo.h"
#include <time.h>
typedef struct {
    time_t timestamp; // Unix timestamp
    double consumption; // kWh consumed that day
} daily_data_t;
typedef struct {
    uint32_t uptime_seconds; // Total uptime in seconds
    uint32_t power_failures; // Number of power failures
    tamper_event_t last_tamper_event; // Last tamper event
    time_t last_tamper_timestamp; // Timestamp of last tamper event
} diagnostics_info_t;
// Global Instance
extern diagnostics_info_t g_diagnostics_info;
// API
void diagnostics_init(void);
void diagnostics_log_power_failure(void);
void diagnostics_log_tamper_event(tamper_event_t event);
void diagnostics_update_uptime(uint32_t seconds);
int tamper_monitor_force_event(tamper_event_t code);
#endif // DIAGNOSTICS_H

