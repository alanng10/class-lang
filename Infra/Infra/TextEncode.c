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

Int TextEncode_ExecuteCount(Int o, Int innKind, Int outKind, Int dataCount, Int dataValue)
{
    Int ka;
    Int kb;
    ka = innKind - 1;
    kb = outKind - 1;

    TextEncode_CountMaide maide;
    maide = CountMaideArray[ka][kb];

    Int a;
    a = maide(o, dataCount, dataValue);
    return a;
}

Int TextEncode_ExecuteResult(Int o, Int result, Int innKind, Int outKind, Int dataCount, Int dataValue)
{
    Int ka;
    Int kb;
    ka = innKind - 1;
    kb = outKind - 1;

    TextEncode_ResultMaide maide;
    maide = ResultMaideArray[ka][kb];

    Int a;
    a = maide(o, result, dataCount, dataValue);
    return a;
}

Int TextEncode_ExecuteCount32To8(Int o, Int data)
{
    Start(Char);
    While
    {
        Char oc;
        oc = 0;

        Read32;

        Count8;
    }

    Int a;
    a = k * sizeof(Byte);
    return a;
}

Int TextEncode_ExecuteCount32To16(Int o, Int data)
{
    Start(Char);
    While
    {
        Char oc;
        oc = 0;

        Read32;

        Count16;
    }

    Int a;
    a = k * sizeof(Int16);
    return a;
}

Int TextEncode_ExecuteCount16To8(Int o, Int data)
{
    Start(Int16);
    While
    {
        Char oc;
        oc = 0;

        Read16;

        if (b)
        {
            Count8;
        }
    }

    Int a;
    a = k * sizeof(Byte);
    return a;
}

Int TextEncode_ExecuteCount16To32(Int o, Int data)
{
    Start(Int16);
    While
    {
        Read16ForCount32;

        if (b)
        {
            Count32;
        }
    }

    Int a;
    a = k * sizeof(Char);
    return a;
}

Int TextEncode_ExecuteCount8To16(Int o, Int data)
{
    Start(Byte);
    While
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
    Start(Byte);
    While
    {
        Read8ForCount32;

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
    StartDest(Byte);
    Start(Char);
    While
    {
        Char oc;
        oc = 0;

        Read32;

        Write8;
    }

    return true;
}


Int TextEncode_ExecuteResult32To16(Int o, Int result, Int data)
{
    StartDest(Int16);
    Start(Char);
    While
    {
        Char oc;
        oc = 0;

        Read32;

        Write16;
    }

    return true;
}

Int TextEncode_ExecuteResult16To8(Int o, Int result, Int data)
{
    StartDest(Byte);
    Start(Int16);
    While
    {
        Char oc;
        oc = 0;

        Read16;
        
        if (b)
        {
            Write8;
        }
    }

    return true;
}

Int TextEncode_ExecuteResult16To32(Int o, Int result, Int data)
{
    StartDest(Char);
    Start(Int16);
    While
    {
        Char oc;
        oc = 0;

        Read16;
        
        if (b)
        {
            Write32;
        }
    }

    return true;
}

Int TextEncode_ExecuteResult8To16(Int o, Int result, Int data)
{
    StartDest(Int16);
    Start(Byte);
    While
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
    StartDest(Char);
    Start(Byte);
    While
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