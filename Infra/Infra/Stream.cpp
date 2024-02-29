#include "Stream.hpp"




CppClassNew(Stream)





#define CP(a) ((Stream*)(a))




#define StreamKindCount (4)


#define StreamStatusNoMaide (0x10000)





Bool Stream_HasPos_Array[StreamKindCount] =
{
    false,
    true,
    true,
    false,
};



Bool Stream_HasCount_Array[StreamKindCount] =
{
    false,
    true,
    true,
    false,
};





Stream_SetCount_Maide Stream_SetCount_MaideArray[StreamKindCount] =
{
    null,
    null,
    &Stream_SetStorageCount,
    null,
};





Stream_Flush_Maide Stream_Flush_MaideArray[StreamKindCount] =
{
    null,
    null,
    &Stream_FlushStorage,
    &Stream_FlushNetwork,
};




Stream_GetStatus_Maide Stream_GetStatus_MaideArray[StreamKindCount] =
{
    null,
    null,
    &Stream_GetStorageStatus,
    null,
};







Bool Stream_Init(Int o)
{
    return true;
}



Bool Stream_Final(Int o)
{
    return true;
}





Int Stream_GetKind(Int o)
{
    Stream* m;

    m = CP(o);


    return m->Kind;
}




Bool Stream_SetKind(Int o, Int value)
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





Int Stream_GetValue(Int o)
{
    Stream* m;

    m = CP(o);


    return m->Value;
}





Bool Stream_SetValue(Int o, Int value)
{
    Stream* m;

    m = CP(o);




    m->Value = value;



    m->Status = 0;



    m->Intern = (QIODevice*)(m->Value);




    return true;
}





Int Stream_GetCount(Int o)
{
    Stream* m;

    m = CP(o);




    if (!(m->HasCount))
    {
        return 0;
    }



    QIODevice* ua;

    ua = m->Intern;



    qint64 ub;

    ub = ua->size();



    Int oa;

    oa = CastInt(ub);



    return oa;
}





Bool Stream_SetCount(Int o, Int value)
{
    Stream* m;

    m = CP(o);



    if (!(m->HasCount))
    {
        return true;
    }




    Int kind;

    kind = m->Kind;



    Int va;

    va = m->Value;




    Stream_SetCount_Maide maide;

    maide = Stream_SetCount_MaideArray[kind];


    if (maide == null)
    {
        return true;
    }




    Bool bo;

    bo = maide(va, value);




    Int status;

    status = 0;




    if (!bo)
    {
        status = Stream_InternGetStatus(o);
    }





    m->Status = status;





    return true;
}






Int Stream_GetPos(Int o)
{
    Stream* m;

    m = CP(o);




    if (!(m->HasPos))
    {
        return 0;
    }




    QIODevice* ua;

    ua = m->Intern;



    qint64 ub;

    ub = ua->pos();



    Int oa;

    oa = CastInt(ub);



    return oa;
}






Bool Stream_SetPos(Int o, Int value)
{
    Stream* m;

    m = CP(o);




    if (!(m->HasPos))
    {
        return true;
    }




    Int count;

    count = Stream_GetCount(o);



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
        status = Stream_InternGetStatus(o);
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






Int Stream_SetCanRead(Int o, Int value)
{
    Stream* m;

    m = CP(o);



    m->CanRead = value;



    return true;
}





Int Stream_SetCanWrite(Int o, Int value)
{
    Stream* m;

    m = CP(o);



    m->CanWrite = value;



    return true;
}






Int Stream_GetStatus(Int o)
{
    Stream* m;

    m = CP(o);


    return m->Status;
}






Bool Stream_Read(Int o, Int data, Int range)
{
    Stream* m;

    m = CP(o);




    if (!(m->CanRead))
    {
        return true;
    }




    Int dataValue;

    dataValue = Data_GetValue(data);



    Int dataCount;

    dataCount = Data_GetCount(data);




    Int start;

    Int end;


    start = Range_GetStart(range);

    end = Range_GetEnd(range);




    if (!Stream_CheckRange(dataCount, start, end))
    {
        m->Status = 100;


        return true;
    }




    Int count;

    count = end - start;




    Int aaa;

    aaa = dataValue + start;




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
        status = Stream_InternGetStatus(o);


        if (status == StreamStatusNoMaide)
        {
            status = 210;
        }



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






Bool Stream_Write(Int o, Int data, Int range)
{
    Stream* m;

    m = CP(o);




    if (!(m->CanWrite))
    {
        return true;
    }




    Int dataValue;

    dataValue = Data_GetValue(data);



    Int dataCount;

    dataCount = Data_GetCount(data);




    Int start;

    Int end;


    start = Range_GetStart(range);

    end = Range_GetEnd(range);




    if (!Stream_CheckRange(dataCount, start, end))
    {
        m->Status = 100;


        return true;
    }




    Int count;

    count = end - start;




    Int aaa;

    aaa = dataValue + start;




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
        status = Stream_InternGetStatus(o);


        if (status == StreamStatusNoMaide)
        {
            status = 310;
        }



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
            status = Stream_InternGetStatus(o);

            if (status == StreamStatusNoMaide)
            {
                status = 330;
            }
        }
    }




    m->Status = status;




    return true;
}







Int Stream_InternGetStatus(Int o)
{
    Stream* m;

    m = CP(o);



    Int kind;

    kind = m->Kind;


    Int value;

    value = m->Value;



    Stream_GetStatus_Maide maide;

    maide = Stream_GetStatus_MaideArray[kind];



    if (maide == null)
    {
        return StreamStatusNoMaide;
    }




    Int status;

    status = maide(value);


    return status;
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






Bool Stream_CheckRange(Int dataCount, Int start, Int end)
{
    return ((!(dataCount < start)) & (!(dataCount < end)));
}







Int Stream_GetIntern(Int o)
{
    Stream* m;

    m = CP(o);



    Int u;

    u = CastInt(m->Intern);



    return u;
}
