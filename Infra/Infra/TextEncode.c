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
        oc = 0;

        Read32;

        Count8;

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
        oc = 0;

        Read32;

        Count16;

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
        Char oc;
        oc = 0;

        Read8;

        if (b)
        {
            Count16;
        }
    }

    Int a;
    a = k * sizeof(Int16);
    return a;
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
        Char oc;
        oc = 0;

        Read8;

        if (b)
        {
            Count32;
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
    countA = sizeof(Char);

    Int k;
    k = 0;

    Int count;
    count = dataCount / countA;
    Int i;
    i = 0;
    while (i < count)
    {
        Char oc;
        oc = 0;

        Read32;

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
    countA = sizeof(Char);

    Int k;
    k = 0;

    Int count;
    count = dataCount / countA;
    Int i;
    i = 0;
    while (i < count)
    {
        Char oc;
        oc = 0;

        Read32;

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
    Int dataCount;
    Int dataValue;
    dataCount = Data_CountGet(data);
    dataValue = Data_ValueGet(data);

    Int resultValue;
    resultValue = Data_ValueGet(result);

    Int16* p;
    p = CastPointer(dataValue);

    Char* dest;
    dest = CastPointer(resultValue);

    Int countA;
    countA = sizeof(Int16);

    Int k;
    k = 0;

    Bool b;
    b = true;
    
    Int count;
    count = dataCount / countA;
    
    Int i;
    i = 0;
    while (b & i < count)
    {
        Char oc;
        oc = 0;


        
        if (b)
        {
            Write32;
        }
    }

    return true;
}

Int TextEncode_ExecuteResult8To16(Int o, Int result, Int data)
{
    Int dataCount;
    Int dataValue;
    dataCount = Data_CountGet(data);
    dataValue = Data_ValueGet(data);

    Int resultValue;
    resultValue = Data_ValueGet(result);

    Byte* p;
    p = CastPointer(dataValue);

    Int16* dest;
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
        Char oc;
        oc = 0;

        Read8;

        if (b)
        {
            Write16;
        }
    }

    return true;
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
        Char oc;
        oc = 0;

        Read8;

        if (b)
        {
            Write32;
        }
    }

    return true;
}