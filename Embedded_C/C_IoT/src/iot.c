#include "iot.h"
#include<stdlib.h>
#include<stdio.h>
#define MAX_OBJECTS 3
CosemObject *objects;
void init_meter()
{

    // CosemObject temp_objects ={
    //     {
    //         {1,1,1,1,1,1},3.3

    //     },
    //      {
    //         {2,1,1,1,1,1},6.6

    //     }}

    objects = (CosemObject*)malloc(sizeof(CosemObject)*MAX_OBJECTS);
    for (int i=0; i<MAX_OBJECTS; i++)
    {
        ObisCode obis = {1,1,1,1,1,1};
        CosemObject object = {&obis,3.3};
        objects[i] = object;
        printf("cosem object initialized : index:%d value: %f\n",i,  objects[i].data);
    
    }
}


void make_obis_code(ObisCode* code, int a, int b, int c, int d, int e, int f){

code->a = a;
code->b = b;
code->c = c;
code->d = d;
code->e = e;
code->f = f;

}

void make_cosem_object(CosemObject* object, ObisCode* code, float data){
    object->code = code;
    object->data = data;

}     

void get_cosem_object(CosemObject* object, ObisCode* code){

    for(int i=0; i<sizeof(objects)/sizeof(CosemObject);i++)
    {
        if (compare_obis_code(objects[i].code, code))
        {
            object = &objects[i];
            printf("\nobis matched: value: %f \n", object->data);
            return;
        }
    }
}
int compare_obis_code(ObisCode* a, ObisCode* b)
{
    if (a->a==b->a && a->b==b->b && a->c==b->c && a->d == b->d && a->e==b->e && a->f==b->f)
    {
        return 1;
    }
    else{
        return 0;
    }
}