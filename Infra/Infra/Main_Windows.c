#include "Main_Windows.h"

Int Main_OS_Arg(Int argc, Int argv)
{
    LPWSTR sa;
    sa = 0;

    sa = GetCommandLineW();

    int countA;
    countA = 0;

    LPWSTR* kk;
    kk = 0;

    kk = CommandLineToArgvW(sa, &countA);

    if (kk == NULL)
    {
        return null;
    }

    if (countA < 1)
    {
        return null;
    }

    Int count;
    count = countA;

    count = count - 1;

    Int array;
    array = Array_New();

    Array_CountSet(array, count);

    Array_Init(array);

    Int share;
    share = Infra_Share();

    Int stat;
    stat = Share_Stat(share);

    Int innKind;
    innKind = Stat_TextCodeKindUtf16(stat);
    Int outKind;
    outKind = Stat_TextCodeKindUtf32(stat);

    Int i;
    i = 0;

    while (i < count)
    {
        Int index;
        index = i + 1;

        LPWSTR arg;
        arg = kk[index];

        int kaa;
        kaa = lstrlenW(arg);
    
        Int ka;
        ka = kaa;

        Int dataCount;
        dataCount = ka * sizeof(Int16);

        Int data;
        data = CastInt(arg);

        Int resultCount;
        resultCount = TextCode_ExecuteCount(0, innKind, outKind, data, dataCount);

        Int result;
        result = Environ_New(resultCount);

        TextCode_ExecuteResult(0, result, innKind, outKind, data, dataCount);

        Int stringCount;
        stringCount = resultCount / Constant_CharByteCount();

        Int a;
        a = String_New();

        String_Init(a);

        String_ValueSet(a, result);

        String_CountSet(a, stringCount);

        Array_ItemSet(array, i, a);

        i = i + 1;
    }

    LocalFree(kk);

    return array;
}