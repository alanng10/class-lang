#include "Main_Windows.h"


Int Main_OS_Arg()
{
    LPWSTR sa;
    sa = 0;

    sa = GetCommandLineW();

    int countA;
    countA = 0;

    LPWSTR* argv;
    argv = 0;

    argv = CommandLineToArgvW(sa, &countA);

    if (argv == NULL)
    {
        return null;
    }

    Int count;
    count = countA;

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
        LPWSTR arg;
        arg = argv[i];

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
        result = New(resultCount);

        TextCode_ExecuteResult(0, result, innKind, outKind, data, dataCount);

        Int stringCount;
        stringCount = resultCount / Constant_CharByteCount();

        Int a;
        a = String_New();
        
        String_Init(a);
        
        String_DataSet(a, result);

        String_CountSet(a, stringCount);

        Array_ItemSet(array, i, a);

        i = i + 1;
    }

    return array;
}