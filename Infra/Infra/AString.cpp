#include "AString.hpp"

CppClassNew(String)

Int String_Init(Int o)
{
    return true;
}

Int String_Final(Int o)
{
    return true;
}

CppField(String, Count)
CppField(String, Data)

Int String_Char(Int o, Int index)
{
    String* m;
    m = CP(o);
    Char* u;
    u = (Char*)(m->Data);
    return u[index];
}

Int String_Equal(Int o, Int other)
{
    String* m;
    m = CP(o);
    String* d;
    d = (String*)(other);

    Bool ba;    
    ba = (m->Count == d->Count);
    if (!ba)
    {
        return false;
    }

    Char* mf;    
    mf = (Char*)(m->Data);
    Char* df;
    df = (Char*)(d->Data);

    Int count;
    count = m->Count;
    Int i;
    i = 0;
    while (i < count)
    {
        if (!(mf[i] == df[i]))
        {
            return false;
        }



        i = i + 1;
    }




    return true;
}

Int String_ConstantCount(Int o)
{
    Byte* p;

    p = (Byte*)o;




    Int k;

    k = 0;



    while (!((*p) == '\0'))
    {
        k = k + 1;


        p = p + 1;
    }




    return k;
}

Int String_ConstantCreate(Int o)
{
    Int count;

    count = String_ConstantCount(o);



    Int share;

    share = Infra_Share();



    Int stat;

    stat = Share_Stat(share);




    Int encode;

    encode = TextEncode_New();


    TextEncode_KindSet(encode, Stat_TextEncodeKindUtf8(stat));


    TextEncode_Init(encode);




    Int k;

    k = TextEncode_StringCountMax(encode, count);




    Int byteCount;

    byteCount = k * Constant_CharByteCount();



    Int stringData;

    stringData = New(byteCount);




    Int data;


    data = Data_New();


    Data_Init(data);


    Data_CountSet(data, count);


    Data_ValueSet(data, o);




    Int stringCount;

    stringCount = TextEncode_String(encode, stringData, data);



    Data_Final(data);


    Data_Delete(data);




    TextEncode_Final(encode);


    TextEncode_Delete(encode);





    Int a;


    a = String_New();


    String_Init(a);


    String_CountSet(a, stringCount);


    String_DataSet(a, stringData);




    return a;
}





Int String_ConstantDelete(Int o)
{
    Int data;

    data = String_DataGet(o);



    String_Final(o);


    String_Delete(o);



    Delete(data);




    return true;
}






Int String_QStringSet(Int result, Int a)
{
    Int count;

    count = String_CountGet(a);


    Int data;

    data = String_DataGet(a);




    const QChar* dataU;

    dataU = (const QChar*)data;



    qsizetype countU;

    countU = count;





    QString* u;


    u = (QString*)result;


    *u = QString(dataU, countU);





    return true;
}







Int String_QStringSetRaw(Int result, Int a)
{
    Int count;
    count = String_CountGet(a);
    Int data;
    data = String_DataGet(a);

    const QChar* dataU;
    dataU = (const QChar*)data;
    qsizetype countU;
    countU = count;

    QString* u;
    u = (QString*)result;
    u->setRawData(dataU, countU);
    return true;
}
