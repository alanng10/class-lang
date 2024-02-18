#include "TextEncode.hpp"




CppClassNew(TextEncode)





Int TextEncode_Init(Int o)
{
    TextEncode* m;

    m = CP(o);



    Int kind;

    kind = m->Kind;




    if (kind == null)
    {
        return true;
    }




    Int oa;

    oa = kind - 1;



    QStringConverter::Encoding encoding;

    encoding = (QStringConverter::Encoding)oa;




    QStringConverter::Flags flag;

    flag = QStringConverter::Flag::Default;



    if (m->WriteBom)
    {
        flag = flag | QStringConverter::Flag::WriteBom;
    }




    m->InternEncode = new QStringEncoder(encoding, flag);


    m->InternDecode = new QStringDecoder(encoding, flag);




    return true;
}





Int TextEncode_Final(Int o)
{
    TextEncode* m;

    m = CP(o);



    delete m->InternEncode;


    delete m->InternDecode;



    return true;
}






Int TextEncode_GetKind(Int o)
{
    TextEncode* m;

    m = CP(o);


    return m->Kind;
}




Int TextEncode_SetKind(Int o, Int value)
{
    TextEncode* m;

    m = CP(o);


    m->Kind = value;


    return true;
}





Int TextEncode_GetWriteBom(Int o)
{
    TextEncode* m;

    m = CP(o);


    return m->WriteBom;
}




Int TextEncode_SetWriteBom(Int o, Int value)
{
    TextEncode* m;

    m = CP(o);


    m->WriteBom = value;


    return true;
}





Int TextEncode_GetStringCountMax(Int o, Int count)
{
    TextEncode* m;

    m = CP(o);



    qsizetype countU;

    countU = count;



    qsizetype u;

    u = m->InternDecode->requiredSpace(countU);


    Int a;

    a = u;


    return a;
}





Int TextEncode_GetString(Int o, Int result, Int data)
{
    TextEncode* m;

    m = CP(o);




    QChar* ou;

    ou = (QChar*)result;




    Int dataCount;

    dataCount = Data_GetCount(data);



    Int dataValue;

    dataValue = Data_GetValue(data);



    const Byte* oa;

    oa = (const Byte*)dataValue;



    qsizetype ob;

    ob = dataCount;




    QByteArrayView oo(oa, ob);



    QChar* uu;

    uu = m->InternDecode->appendToBuffer(ou, oo);




    Int aa;

    aa = uu - ou;




    Int count;

    count = aa;



    return count;
}







Int TextEncode_GetDataCountMax(Int o, Int count)
{
    TextEncode* m;

    m = CP(o);



    qsizetype countU;

    countU = count;



    qsizetype u;

    u = m->InternEncode->requiredSpace(countU);


    Int a;

    a = u;


    return a;
}





Int TextEncode_GetData(Int o, Int result, Int fromString)
{
    TextEncode* m;

    m = CP(o);




    char* ou;

    ou = (char*)result;





    Int fromCount;

    fromCount = String_GetCount(fromString);


    Int fromData;

    fromData = String_GetData(fromString);




    const QChar* oa;

    oa = (const QChar*)fromData;



    qsizetype ob;

    ob = fromCount;




    QStringView oo(oa, ob);




    char* uu;

    uu = m->InternEncode->appendToBuffer(ou, oo);




    Int aa;

    aa = uu - ou;




    Int count;

    count = aa;



    return count;
}


