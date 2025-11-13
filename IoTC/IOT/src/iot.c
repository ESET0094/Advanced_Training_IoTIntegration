#include "iot.h"
#include<stdlib.h>
#include<stdio.h>

#define MAX_OBJECTS 3

 ObisCode obis1 = {1,1,1,1,1,1};
  ObisCode obis2 = {1,1,1,1,1,2};
   ObisCode obis3 = {1,1,1,1,1,3};

CosemObject objects[] = {
    {&obis1,1.1 },
    {&obis2,2.1 },
    {&obis3,33434.435342345 },
};

void init_meter(){
    // objects = (CosemObject*) malloc(sizeof(CosemObject)*MAX_OBJECTS);
    // for (int i=0;i<MAX_OBJECTS;i++){
    //     ObisCode obis = {1,1,1,1,1,i};
    //     CosemObject object = {&obis,3.3};
    //     objects[i] = object;
    // }

    // for (int i=0;i<MAX_OBJECTS;i++){
    //     printf("intialized obis code for %d: %d\n",i,objects[i].code->f);
    // }
}

// void print_cosem_objects(){
//     for (int i=0;i<MAX_OBJECTS;i++){
//         printf("intialized obis code for %d: %d\tdata: %f\n",i,(objects[i].code->f), objects[i].data);
//     }
// }

void make_obis_code(ObisCode* code, int a, int b, int c, int d, int e, int f){
    code->a = a;
    code->b = b;
    code->c = c;
    code->d = d;
    code->e = e;
    code->f = f;
}

void make_cosem_object(CosemObject* object,ObisCode* code, float data){
    object->code = code;
    object->data = data;
}

void get_cosem_object(CosemObject* object,ObisCode* code){
    for (int i = 0; i < MAX_OBJECTS; i++){
        if ( objects[i].code->a == code->a 
            && objects[i].code->b == code->b 
            && objects[i].code->c == code->c 
            && objects[i].code->d == code->d 
            && objects[i].code->e == code->e 
            && objects[i].code->f == code->f)
        {
           object->data = objects[i].data;
           return;
        }
    }
}


int compare_obis_code(ObisCode* a, ObisCode* b){
    if (a->a == b->a && a->b == b->b && a->c == b->c && a->d == b->d && a->e == b->e && a->f == b->f){
        return 1;
    }else{
        return 0;
    }
    
}