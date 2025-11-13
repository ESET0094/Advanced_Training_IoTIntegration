#include "iot.h"
#include <stdlib.h>
#include <stdio.h>

// Allocate global pointer for all COSEM objects
CosemObject* objects = NULL;

void make_obis_code(ObisCode* code, int a, int b, int c, int d, int e, int f) {
    if (code == NULL) return;
    code->a = a;
    code->b = b;
    code->c = c;
    code->d = d;
    code->e = e;
    code->f = f;
}

void make_cosem_object(CosemObject* object, ObisCode* code, float data) {
    if (object == NULL || code == NULL) return;
    object->code = code;
    object->data = data;
}

int compare_obis_code(const ObisCode* a, const ObisCode* b) {
    if (a == NULL || b == NULL) return 0;
    return (a->a == b->a &&
            a->b == b->b &&
            a->c == b->c &&
            a->d == b->d &&
            a->e == b->e &&
            a->f == b->f);
}

void init_meter() {
    // Allocate memory for all objects
    objects = (CosemObject*)malloc(sizeof(CosemObject) * MAX_OBJECTS);
    if (!objects) {
        fprintf(stderr, "Memory allocation failed for COSEM objects\n");
        exit(EXIT_FAILURE);
    }

    for (int i = 0; i < MAX_OBJECTS; i++) {
        ObisCode* code = (ObisCode*)malloc(sizeof(ObisCode));
        if (!code) {
            fprintf(stderr, "Memory allocation failed for OBIS code %d\n", i);
            exit(EXIT_FAILURE);
        }

        make_obis_code(code, 1, 1, 1, 1, 1, i + 1);
        make_cosem_object(&objects[i], code, (float)(i + 1) * 10.5f);
    }
}

void print_cosem_objects() {
    if (objects == NULL) {
        printf("No COSEM objects initialized.\n");
        return;
    }
    for (int i = 0; i < MAX_OBJECTS; i++) {
        ObisCode* c = objects[i].code;
        printf("COSEM[%d]: OBIS=%d.%d.%d.%d.%d.%d\tData=%.6f\n",
               i, c->a, c->b, c->c, c->d, c->e, c->f, objects[i].data);
    }
}

void get_cosem_object(CosemObject* result, ObisCode* code) {
    if (objects == NULL || result == NULL || code == NULL) return;

    for (int i = 0; i < MAX_OBJECTS; i++) {
        if (compare_obis_code(objects[i].code, code)) {
            result->code = objects[i].code;
            result->data = objects[i].data;
            return;
        }
    }

    // If not found
    result->code = NULL;
    result->data = 0.0f;
}