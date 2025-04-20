#include "Main_Linux.h"

Int Main_OS_Arg(Int argc, Int argv)
{
    Int count;
    count = argc;

    count = count - 1;

    Int array;
    array = Array_New();

    Array_CountSet(array, count);

    Array_Init(array);

    Int* pa;
    pa = (Int*)argv;

    Int i;
    i = 0;

    while (i < count)
    {
        Int index;
        index = i + 1;

        Int ka;
        ka = pa[index];

        Int kk;
        kk = String_ConstantCreate(ka);

        Array_ItemSet(array, i, kk);

        i = i + 1;
    }

    return array;
}