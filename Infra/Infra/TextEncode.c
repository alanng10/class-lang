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
            kaa = 0;
            kaa = kaa | ka;
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
            kba = 0;
            kba = kba | ka;
            kba = kba | ((kb & 0x3) << 4);
            kba = kba | 0x80;

            Int kbb;
            kbb = 0;
            kbb = kbb | (kb >> 2);
            kbb = kbb | ((kc & 0x7) << 2);
            kbb = kbb | 0xc0;

            Byte oba;
            Byte obb;

            oba = kba;
            obb = kbb;

            dest[k + 0] = obb;
            dest[k + 1] = oba;

            k = k + 2;
        }

        if (!(oc < 0x800) & oc < 0x10000)
        {
            Int kca;
            kca = 0;
            kca = kca | ka;
            kca = kca | ((kb & 0x3) << 4);
            kca = kca | 0x80;

            Int kcb;
            kcb = 0;
            kcb = kcb | (kb >> 2);
            kcb = kcb | (kc << 2);
            kcb = kcb | 0x80;

            Int kcc;
            kcc = 0;
            kcc = kcc | kd;
            kcc = kcc | 0xe0;

            Byte oca;
            Byte ocb;
            Byte occ;

            oca = kca;
            ocb = kcb;
            occ = kcc;

            dest[k + 0] = occ;
            dest[k + 1] = ocb;
            dest[k + 2] = oca;

            k = k + 3;
        }

        if (!(oc < 0x10000) & oc < 0x110000)
        {
            Int kda;
            kda = 0;
            kda = kda | ka;
            kda = kda | ((kb & 0x3) << 4);
            kda = kda | 0x80;

            Int kdb;
            kdb = 0;
            kdb = kdb | (kb >> 2);
            kdb = kdb | (kc << 2);
            kdb = kdb | 0x80;

            Int kdc;
            kdc = 0;
            kdc = kdc | kd;
            kdc = kdc | ((ke & 0x3) << 4);
            kdc = kdc | 0x80;

            Int kdd;
            kdd = 0;
            kdd = kdd | (ke >> 2);
            kdd = kdd | (kf << 2);
            kdd = kdd | 0xf0;

            Byte oda;
            Byte odb;
            Byte odc;
            Byte odd;

            oda = kda;
            odb = kdb;
            odc = kdc;
            odd = kdd;

            dest[k + 0] = odd;
            dest[k + 1] = odc;
            dest[k + 2] = odb;
            dest[k + 3] = oda;

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