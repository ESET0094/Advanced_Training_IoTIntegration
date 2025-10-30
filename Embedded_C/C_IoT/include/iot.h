#ifndef IOT_H
#define IOT_H

typedef struct{
    int a,b,c,d,e,f;
}ObisCode;

typedef struct{
    ObisCode *code;
    float data;
}CosemObject;

void init_meter();

void make_obis_code(ObisCode* code, int a, int b, int c, int d, int e, int f);

void make_cosem_object(CosemObject* object, ObisCode* code, float data);

void get_cosem_object(CosemObject* object, ObisCode* code);

int compare_obis_code(ObisCode* a, ObisCode* b);

#endif 