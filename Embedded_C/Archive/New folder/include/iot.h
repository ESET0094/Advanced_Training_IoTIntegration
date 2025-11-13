#ifndef IOT_H
#define IOT_H

#define MAX_OBJECTS 3

typedef struct {
    int a, b, c, d, e, f;
} ObisCode;

typedef struct {
    ObisCode* code;
    float data;
} CosemObject;

// Global list of objects
extern CosemObject* objects;

void init_meter();
void make_obis_code(ObisCode* code, int a, int b, int c, int d, int e, int f);
void make_cosem_object(CosemObject* object, ObisCode* code, float data);
void get_cosem_object(CosemObject* object, ObisCode* code);
int compare_obis_code(const ObisCode* a, const ObisCode* b);
void print_cosem_objects();

#endif