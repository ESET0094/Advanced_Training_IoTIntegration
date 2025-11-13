#include <stdio.h>
#include <stdlib.h>
#include "iot.h"

int main() {
    init_meter();
    print_cosem_objects();

    ObisCode* query = (ObisCode*)malloc(sizeof(ObisCode));
    make_obis_code(query, 1, 1, 1, 1, 1, 3);

    printf("\nSearching for OBIS: %d.%d.%d.%d.%d.%d\n",
           query->a, query->b, query->c, query->d, query->e, query->f);

    CosemObject result;
    get_cosem_object(&result, query);

    if (result.code != NULL) {
        printf("Found: Data = %.6f\n", result.data);
    } else {
        printf("COSEM object not found.\n");
    }

    // cleanup (optional)
    for (int i = 0; i < MAX_OBJECTS; i++) {
        free(objects[i].code);
    }
    free(objects);
    free(query);

    return 0;
}