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
    p = CastPointer(dataValue);

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
    p = CastPointer(dataValue);

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
    a = k * sizeof(Int16);
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
    Int dataCount;
    Int dataValue;
    dataCount = Data_CountGet(data);
    dataValue = Data_ValueGet(data);

    Byte* p;
    p = CastPointer(dataValue);

    Int k;
    k = 0;

    Bool b;
    b = true;

    Int count;
    count = dataCount;

    Int i;
    i = 0;
    while (b & (i < count))
    {
        b = false;

        Byte ooa;
        ooa = p[i];

        Int aaa;
        aaa = ooa;

        if ((aaa >> 7) == 0)
        {
            i = i + 1;

            k = k + 1;

            b = true;
        }

        if ((aaa >> 5) == 0x6)
        {
            Int akb;
            akb = i + 2;

            if (!(count < akb))
            {
                i = akb;

                k = k + 1;

                b = true;
            }
        }

        if ((aaa >> 4) == 0xe)
        {
            Int akc;
            akc = i + 3;

            if (!(count < akc))
            {
                i = akc;

                k = k + 1;

                b = true;
            }
        }

        if ((aaa >> 3) == 0x1e)
        {
            Int akd;
            akd = i + 4;

            if (!(count < akd))
            {
                i = akd;

                k = k + 1;

                b = true;
            }
        }
    }

    Int a;
    a = k * sizeof(Char);
    return a;
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
    p = CastPointer(dataValue);

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

        Write8;

        i = i + 1;
    }

    return true;
}


Int TextEncode_ExecuteResult32To16(Int o, Int result, Int data)
{
    Int dataCount;
    Int dataValue;
    dataCount = Data_CountGet(data);
    dataValue = Data_ValueGet(data);

    Int resultValue;
    resultValue = Data_ValueGet(result);

    Char* p;
    p = CastPointer(dataValue);

    Int16* dest;
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

        Write16;

        i = i + 1;
    }

    return true;
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
    Int dataCount;
    Int dataValue;
    dataCount = Data_CountGet(data);
    dataValue = Data_ValueGet(data);

    Int resultValue;
    resultValue = Data_ValueGet(result);

    Byte* p;
    p = CastPointer(dataValue);

    Char* dest;
    dest = CastPointer(resultValue);

    Int k;
    k = 0;

    Bool b;
    b = true;

    Int count;
    count = dataCount;

    Int i;
    i = 0;
    while (b & (i < count))
    {
        b = false;

        Byte ooa;
        ooa = p[i];

        Int aaa;
        aaa = ooa;

        Char oc;
        oc = 0;

        if ((aaa >> 7) == 0)
        {
            Int akaa;
            akaa = aaa;

            oc = akaa;

            i = i + 1;

            b = true;
        }

        if ((aaa >> 5) == 0x6)
        {
            Int akb;
            akb = i + 2;

            if (!(count < akb))
            {
                Byte akoa;
                Byte akob;
                akoa = p[i + 1];
                akob = ooa;

                Int akba;
                Int akbb;
                Int akbc;
                akba = akoa & 0xf;
                akbb = ((akoa >> 4) & 0x3) | ((akob & 0x3) << 2);
                akbc = (akob >> 2) & 0x7;

                Int kkb;
                kkb = 0;
                kkb = kkb | (akba << (4 * 0));
                kkb = kkb | (akbb << (4 * 1));
                kkb = kkb | (akbc << (4 * 2));

                oc = kkb;

                i = akb;

                b = true;
            }
        }

        if ((aaa >> 4) == 0xe)
        {
            Int akc;
            akc = i + 3;

            if (!(count < akc))
            {
                i = akc;

                b = true;
            }
        }

        if ((aaa >> 3) == 0x1e)
        {
            Int akd;
            akd = i + 4;

            if (!(count < akd))
            {
                i = akd;

                b = true;
            }
        }

        if (b)
        {
            Write32;
        }
    }

    Int a;
    a = k * sizeof(Char);
    return a;
}