#include "TextEncode.h"

InfraClassNew(TextEncode)

TextEncode_CountMaide CountMaideArray[3][3] =
{
    { null, TextEncode_ExecuteCount8To16, TextEncode_ExecuteCount8To32},
    { TextEncode_ExecuteCount16To8, null, TextEncode_ExecuteCount16To32},
    { TextEncode_ExecuteCount32To8, TextEncode_ExecuteCount32To16, null}
};

TextEncode_ResultMaide ResultMaideArray[3][3] =
{
    { null, TextEncode_ExecuteResult8To16, TextEncode_ExecuteResult8To32},
    { TextEncode_ExecuteResult16To8, null, TextEncode_ExecuteResult16To32},
    { TextEncode_ExecuteResult32To8, TextEncode_ExecuteResult32To16, null}
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

        if (oc < 0x10000)
        {
            k = k + 1;
        }

        if (!(oc < 0x10000))
        {
            k = k + 2;
        }

        i = i + 1;
    }

    Int a;
    a = k;
    return a;
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

Int TextEncode_ExecuteResult32To8(Int o, Int result, Int data)
{
    Int dataCount;
    Int dataValue;
    dataCount = Data_CountGet(data);
    dataValue = Data_ValueGet(data);

    Int resultValue;
    resultValue = Data_ValueGet(result);

    Char* p;
    p = CastPonter(dataValue);

    Byte* dest;
    dest = CastPointer(resultValue);

    Int countA;
    countA = 4;

    Int k;
    k = 0;

    Int count;
    count = dataCount / countA;
    Int i;
    i = 0;
    while (i < count)
    {
        Char oc;
        oc = p[i];

        Int ka;
        Int kb;
        Int kc;
        Int kd;
        Int ke;
        Int kf;

        ka = (oc >> (4 * 0)) & 0xf;
        kb = (oc >> (4 * 1)) & 0xf;
        kc = (oc >> (4 * 2)) & 0xf;
        kd = (oc >> (4 * 3)) & 0xf;
        ke = (oc >> (4 * 4)) & 0xf;
        kf = (oc >> (4 * 5)) & 0x1;

        if (oc < 0x80)
        {
            Int kaa;
            kaa = ka;
            kaa = kaa | (kb << 4);
            kaa = kaa & 0x7f; 

            Byte oaa;
            oaa = kaa;

            dest[k] = oaa;

            k = k + 1;
        }

        if (!(oc < 0x80) & oc < 0x800)
        {
            Int kba;
            kba = ka;
            kba = kba | ((kb << 4) & 0x3);
            kba = kba | 0x80;

            Int kbb;
            kbb = kbb | (kb >> 2);
            kbb = kbb | ((kc << 2) & 0x7);
            kbb = kbb | 0xc0;

            Byte oba;
            Byte obb;

            oba = kba;
            obb = kbb;

            dest[k] = obb;
            dest[k + 1] = oba;

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


Int TextEncode_ExecuteResult32To16(Int o, Int result, Int data)
{

}

Int TextEncode_ExecuteResult16To8(Int o, Int result, Int data)
{

}

Int TextEncode_ExecuteResult16To32(Int o, Int result, Int data)
{

}

Int TextEncode_ExecuteResult8To16(Int o, Int result, Int data)
{

}

Int TextEncode_ExecuteResult8To32(Int o, Int result, Int data)
{

}