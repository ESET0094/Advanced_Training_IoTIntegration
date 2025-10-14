#include "data_refresh.h"
#include "inc\storage.h"
#include <string.h>
#include <stdio.h>
#include <security.h>
#include "Meter_Info.h" 
#include "Meter_Readings.h"

#define MAX_DAYS 90
#define REPORT_TOPIC "meter/report/90days"

#ifndef REFRESH_LOG
#define REFRESH_LOG(fmt, ...) printf("DATA_REFRESH: " fmt "\n", ##__VA_ARGS__)
#endif

static daily_data_t data_store[MAX_DAYS];
static uint8_t entry_count = 0;
static uint8_t head_index = 0;

static uint32_t get_current_timestamp(void) {
#ifndef HAL_EXISTS    // Placeholder for actual timestamp retrieval logic
    return (uint32_t)time(NULL);
    sync();
#else
    return HAL_GetTick() / 1000; // Example: using system tick as seconds
#endif

}

static size_t serialize_report(uint8_t *out_buf, size_t max_len) {
    size_t offset = 0;
    for (uint8_t i = 0; i < entry_count; i++) {
        uint8_t idx = (head_index + i) % MAX_DAYS;
        if (offset + sizeof(daily_data_t) > max_len) {
            break; // Prevent overflow
        }
        memcpy(out_buf + offset, &data_store[idx], sizeof(daily_data_t));
        offset += sizeof(daily_data_t);
    }
    return offset;
}
void data_refresh_init(void){
    memset(data_store, 0, sizeof(data_store));
    entry_count = 0;
    head_index = 0;
    REFRESH_LOG("Initialized daily data score (max %d entries)", MAX_DAYS);

}

void data_refresh_add_entry(const daily_data_t* entry){
    if (entry == NULL) {
        REFRESH_LOG("Invalid entry (NULL)");
        return;
    }
    if (entry_count < MAX_DAYS) {
        data_store[(head_index + entry_count) % MAX_DAYS] = *entry;
        uint8_t insert_index = (head_index + entry_count) % MAX_DAYS;
        entry_count++;
    } else {
        head_index = (head_index + 1) % MAX_DAYS;
        data_store[(head_index + entry_count - 1) % MAX_DAYS] = *entry;
    }
    REFRESH_LOG("Added entry for day %u", entry->day_timestamp);
}
void data_refresh_send_report(void){
    if (entry_count == 0) {
        REFRESH_LOG("No data to send");
        return;
    }
    uint8_t report_buf[sizeof(daily_data_t) * MAX_DAYS];
    size_t report_len = serialize_report(report_buf, sizeof(report_buf));
    if (report_len == 0) {
        REFRESH_LOG("Failed to serialize report");
        return;
    }
    // Simulate sending the report (e.g., via MQTT)
    REFRESH_LOG("Sending report with %d entries (%d bytes)", entry_count, report_len);
    // mqtt_publish(REPORT_TOPIC, report_buf, report_len);
    REFRESH_LOG("Report sent to topic: %s", REPORT_TOPIC);

}