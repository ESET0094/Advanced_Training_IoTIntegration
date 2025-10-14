#include<MeterInfo.h>
#include<string.h>

consumer_info_t g_consumer_info;
meter_hardware_info_t g_meter_hw_info;

void meter_info_init(void){

    strcpy(g_consumer_info.consumer_id, "CUST12345");
    strcpy(g_consumer_info.consumer_name, "John Doe");
    strcpy(g_consumer_info.tariff_plan, "Domestic");
    strcpy(g_consumer_info.address, "123 Main St, City");

    // Hardware Info 

    strcpy(g_meter_hw_info.meter_serial, "Meter_01");
    strcpy(g_meter_hw_info.firmware_version, "v1.0.1");
    strcpy(g_meter_hw_info.hardware_version, "RevA");
    g_meter_hw_info.voltage_calibration = 1.002f;
    g_meter_hw_info.current_calibration = 0.998f;
    g_meter_hw_info.power_calibration = 1.001f;

}