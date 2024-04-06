#include "Stream.hpp"

CppClassNew(Stream)

#define StreamKindCount (4)

Int Stream_HasPos_Array[StreamKindCount] =
{
    false,
    true,
    true,
    false,
};

Int Stream_HasCount_Array[StreamKindCount] =
{
    false,
    true,
    true,
    false,
};

Stream_Flush_Maide Stream_Flush_MaideArray[StreamKindCount] =
{
    null,
    null,
    &Stream_FlushStorage,
    &Stream_FlushNetwork,
};

Int Stream_Init(Int o)
{
    return true;
}

Int Stream_Final(Int o)
{
    return true;
}

CppFieldGet(Stream, Kind)

Int Stream_KindSet(Int o, Int value)
{
    Stream* m;
    m = CP(o);
    Int kind;
    kind = value;
    m->Kind = kind;

    m->HasPos = Stream_HasPos_Array[kind];
    m->HasCount = Stream_HasCount_Array[kind];
    m->CanRead = false;
    m->CanWrite = false;
    return true;
}

CppFieldGet(Stream, Value)

Int Stream_ValueSet(Int o, Int value)
{
    Stream* m;
    m = CP(o);

    m->Value = value;

    m->Status = 0;

    m->Intern = (QIODevice*)(m->Value);
    return true;
}

Int Stream_CountGet(Int o)
{
    Stream* m;
    m = CP(o);

    if (!(m->HasCount))
    {
        SInt oo;
        oo = -1;
        Int ooa;
        ooa = oo;
        return ooa;
    }

    QIODevice* ua;
    ua = m->Intern;

    qint64 ub;
    ub = ua->size();

    Int a;
    a = ub;
    return a;
}

Int Stream_PosGet(Int o)
{
    Stream* m;
    m = CP(o);

    if (!(m->HasPos))
    {
        SInt oo;
        oo = -1;
        Int ooa;
        ooa = oo;
        return ooa;
    }

    QIODevice* ua;
    ua = m->Intern;

    qint64 ub;
    ub = ua->pos();

    Int a;
    a = ub;
    return a;
}






Bool Stream_PosSet(Int o, Int value)
{
    Stream* m;

    m = CP(o);




    if (!(m->HasPos))
    {
        return true;
    }




    Int count;

    count = Stream_CountGet(o);



    if (count < value)
    {
        return true;
    }





    qint64 ua;

    ua = value;





    bool bu;


    bu = m->Intern->seek(ua);




    Bool bo;

    bo = bu;




    Int status;


    status = 0;




    if (!bo)
    {
        status = 150;
    }





    m->Status = status;





    return true;
}





Bool Stream_HasPos(Int o)
{
    Stream* m;

    m = CP(o);



    return m->HasPos;
}





Bool Stream_HasCount(Int o)
{
    Stream* m;

    m = CP(o);



    return m->HasCount;
}






Int Stream_CanRead(Int o)
{
    Stream* m;

    m = CP(o);



    return m->CanRead;
}







Int Stream_CanWrite(Int o)
{
    Stream* m;

    m = CP(o);



    return m->CanWrite;
}

CppFieldSet(Stream, CanRead)
CppFieldSet(Stream, CanWrite)
CppFieldGet(Stream, Status)

Int Stream_StatusSet(Int o, Int value)
{
    return true;
}

Int Stream_Read(Int o, Int data, Int range)
{
    Stream* m;
    m = CP(o);

    if (!(m->CanRead))
    {
        return true;
    }

    Int dataValue;
    dataValue = Data_ValueGet(data);
    Int dataCount;
    dataCount = Data_CountGet(data);

    Int index;
    Int count;
    index = Range_IndexGet(range);
    count = Range_CountGet(range);

    if (!Stream_CheckRange(dataCount, index, count))
    {
        m->Status = 100;
        return true;
    }

    Int aaa;
    aaa = dataValue + index;

    char* dataU;
    dataU = (char*)aaa;

    qint64 maxSize;
    maxSize = count;

    qint64 oo;
    oo = m->Intern->read(dataU, maxSize);

    Int status;
    status = 0;

    Bool b;
    b = false;
    if ((!b) & (oo < 0))
    {
        status = 210;
        b = true;
    }
    if ((!b) & (!(oo == maxSize)))
    {
        status = 200;
        b = true;
    }

    m->Status = status;
    return true;
}

Int Stream_Write(Int o, Int data, Int range)
{
    Stream* m;
    m = CP(o);

    if (!(m->CanWrite))
    {
        return true;
    }

    Int dataValue;
    dataValue = Data_ValueGet(data);
    Int dataCount;
    dataCount = Data_CountGet(data);

    Int index;
    Int count;
    index = Range_IndexGet(range);
    count = Range_CountGet(range);

    if (!Stream_CheckRange(dataCount, index, count))
    {
        m->Status = 100;
        return true;
    }

    Int aaa;
    aaa = dataValue + index;

    const char* dataU;
    dataU = (const char*)aaa;

    qint64 maxSize;
    maxSize = count;

    qint64 oo;
    oo = m->Intern->write(dataU, maxSize);

    Int status;
    status = 0;

    Bool b;
    b = false;
    if ((!b) & (oo < 0))
    {
        status = 310;
        b = true;
    }
    if ((!b) & (!(oo == maxSize)))
    {
        status = 300;
        b = true;
    }

    if (!b)
    {
        Int uoo;
        uoo = Stream_InternFlush(o);

        if (uoo == 1)
        {
            status = 330;
        }
    }

    m->Status = status;
    return true;
}

Int Stream_InternFlush(Int o)
{
    Stream* m;

    m = CP(o);




    Int kind;

    kind = m->Kind;


    Int value;

    value = m->Value;




    Stream_Flush_Maide maide;

    maide = Stream_Flush_MaideArray[kind];



    if (maide == null)
    {
        return 2;
    }




    Bool b;

    b = maide(value);



    b = (!b);



    Int aa;

    aa = b;


    return aa;
}

Int Stream_CheckRange(Int dataCount, Int index, Int count)
{
    return ((!(dataCount < index)) & (!(dataCount < index + count)));
}

Int Stream_Intern(Int o)
{
    Stream* m;

    m = CP(o);



    Int u;

    u = CastInt(m->Intern);



    return u;
}
