#include "MeterReadings.h"
#include <string.h>

meter_readings_t g_meter_readings;

void meter_readings_init(void) {
    memset(&g_meter_readings, 0, sizeof(g_meter_readings));

}

void meter_readings_update_energy(double delta_kwh) {
    g_meter_readings.kWh_import += delta_kwh;
    g_meter_readings.kVAh += delta_kwh;
}

void meter_readings_update_quality(float voltage, float current, float pf, float freq)
{
    g_meter_readings.voltage_avg = (g_meter_readings.voltage_avg + voltage)/2.0f;
    
    if (voltage <g_meter_readings.voltage_min || g_meter_readings.voltage_min == 0)
    {
        g_meter_readings.voltage_min = voltage;
    }

    if (voltage > g_meter_readings.voltage_max)
    {
        g_meter_readings.voltage_max = voltage;
    }


    g_meter_readings.power_factor_avg = (g_meter_readings.power_factor_avg + pf)/2.0f;

    if (pf<g_meter_readings.power_factor_min || g_meter_readings.power_factor_min == 0)
    {
        g_meter_readings.power_factor_min = pf;
    }

    if (pf > g_meter_readings.voltage_max)
    {
        g_meter_readings.power_factor_max = pf;
    }


    g_meter_readings.current_avg = (g_meter_readings.current_avg + current)/2.0f;
    
    if (current>g_meter_readings.current_peak)
    {
        g_meter_readings.current_peak = current;
    }

    g_meter_readings.frequency = freq;
}