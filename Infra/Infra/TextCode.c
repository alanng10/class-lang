#include "TextCode.h"

InfraClassNew(TextCode)

TextCode_CountMaide CountMaideArray[3][3] =
{
    { null, TextCode_ExecuteCount8To16, TextCode_ExecuteCount8To32},
    { TextCode_ExecuteCount16To8, null, TextCode_ExecuteCount16To32},
    { TextCode_ExecuteCount32To8, TextCode_ExecuteCount32To16, null}
};

TextCode_ResultMaide ResultMaideArray[3][3] =
{
    { null, TextCode_ExecuteResult8To16, TextCode_ExecuteResult8To32},
    { TextCode_ExecuteResult16To8, null, TextCode_ExecuteResult16To32},
    { TextCode_ExecuteResult32To8, TextCode_ExecuteResult32To16, null}
};


Int TextCode_Init(Int o)
{
    return true;
}

Int TextCode_Final(Int o)
{
    return true;
}

Int TextCode_ExecuteCount(Int o, Int innKind, Int outKind, Int dataValue, Int dataCount)
{
    Int ka;
    Int kb;
    ka = innKind - 1;
    kb = outKind - 1;

    TextCode_CountMaide maide;
    maide = CountMaideArray[ka][kb];

    Int a;
    a = maide(o, dataValue, dataCount);
    return a;
}

Int TextCode_ExecuteResult(Int o, Int result, Int innKind, Int outKind, Int dataValue, Int dataCount)
{
    Int ka;
    Int kb;
    ka = innKind - 1;
    kb = outKind - 1;

    TextCode_ResultMaide maide;
    maide = ResultMaideArray[ka][kb];

    Int a;
    a = maide(o, result, dataValue, dataCount);
    return a;
}

Int TextCode_ExecuteCount32To8(Int o, Int dataValue, Int dataCount)
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

Int TextCode_ExecuteCount32To16(Int o, Int dataValue, Int dataCount)
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

Int TextCode_ExecuteCount16To8(Int o, Int dataValue, Int dataCount)
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

Int TextCode_ExecuteCount16To32(Int o, Int dataValue, Int dataCount)
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

Int TextCode_ExecuteCount8To16(Int o, Int dataValue, Int dataCount)
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

Int TextCode_ExecuteCount8To32(Int o, Int dataValue, Int dataCount)
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

Int TextCode_ExecuteResult32To8(Int o, Int result, Int dataValue, Int dataCount)
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


Int TextCode_ExecuteResult32To16(Int o, Int result, Int dataValue, Int dataCount)
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

Int TextCode_ExecuteResult16To8(Int o, Int result, Int dataValue, Int dataCount)
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

Int TextCode_ExecuteResult16To32(Int o, Int result, Int dataValue, Int dataCount)
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

Int TextCode_ExecuteResult8To16(Int o, Int result, Int dataValue, Int dataCount)
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

Int TextCode_ExecuteResult8To32(Int o, Int result, Int dataValue, Int dataCount)
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