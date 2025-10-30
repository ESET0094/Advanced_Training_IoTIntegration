#include<stdio.h>
#include "iot.h"
#include<stdlib.h>
int main(){
    init_meter();
    ObisCode* obisCode = (ObisCode*)malloc(sizeof(ObisCode));
    make_obis_code(obisCode, 1,2,3,4,5,6);
    printf("ObisCode: %d.%d.%d.%d.%d.%d", obisCode->a, obisCode->b, obisCode->c, obisCode->d, obisCode->e,obisCode->f);
    
    
    CosemObject *cosem = NULL;
    get_cosem_object(cosem,obisCode);
    if (cosem!=NULL){
        printf("cosem->value: %f", cosem->data);

    } else {
        printf("cosem object was null");
    }
}