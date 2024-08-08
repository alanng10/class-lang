#include "TextEncode.h"

InfraClassNew(TextEncode)

TextEncode_CountMaide CountMaideArray[3][3] =
{
    { null, TextEncode_ExecuteCount8To16, TextEncode_ExecuteCount8To32},
    { TextEncode_ExecuteCount16To8, null, TextEncode_ExecuteCount16To32},
    { TextEncode_ExecuteCount32To8, TextEncode_ExecuteCount32To16, null}
};

Int TextEncode_Init(Int o)
{
    return true;
}

Int TextEncode_Final(Int o)
{
    return true;
}

Int TextEncode_ExecuteCount(Int o, Int innKind, Int outKind, Int data)
{
    TextEncode_CountMaide maide;
    maide = CountMaideArray[innKind][outKind];

    Int a;
    a = maide(o, data);
    return a;
}

Int TextEncode_ExecuteResult(Int o, Int result, Int innKind, Int outKind, Int data)
{
    return 0;
}


Int TextEncode_ExecuteCount32To8(Int o, Int data)
{
    Int dataCount;
    Int dataValue;
    dataCount = Data_CountGet(data);
    dataValue = Data_ValueGet(data);

    Char* p;
    p = CastPonter(dataValue);

    Int ka;
    ka = 4;

    Int k;
    k = 0;

    Int count;
    count = dataCount / ka;
    Int i;
    i = 0;
    while (i < count)
    {
        Char oc;
        oc = p[i];

        if (oc < 0x80)
        {
            k = k + 1;
        }

        if (!(oc < 0x80) & oc < 0x800)
        {
            k = k + 2;
        }

        if (!(oc < 0x800) & oc < 0x10000)
        {
            k = k + 3;
        }

        if (!(oc < 0x10000) & oc < 0x110000)
        {
            k = k + 4;
        }

        i = i + 1;
    }

    Int a;
    a = k;
    return a;
}

Int TextEncode_ExecuteCount32To16(Int o, Int data)
{
    return 0;
}

Int TextEncode_ExecuteCount16To8(Int o, Int data)
{
    return 0;
}

Int TextEncode_ExecuteCount16To32(Int o, Int data)
{
    return 0;
}

Int TextEncode_ExecuteCount8To16(Int o, Int data)
{
    return 0;
}

Int TextEncode_ExecuteCount8To32(Int o, Int data)
{
    return 0;
}
