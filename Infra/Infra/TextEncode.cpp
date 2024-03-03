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

CppField(TextEncode, Kind)
CppField(TextEncode, WriteBom)

Int TextEncode_StringCountMax(Int o, Int count)
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

Int TextEncode_String(Int o, Int result, Int data)
{
    TextEncode* m;

    m = CP(o);




    QChar* ou;

    ou = (QChar*)result;




    Int dataCount;

    dataCount = Data_CountGet(data);



    Int dataValue;

    dataValue = Data_ValueGet(data);



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







Int TextEncode_DataCountMax(Int o, Int count)
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





Int TextEncode_Data(Int o, Int result, Int fromString)
{
    TextEncode* m;

    m = CP(o);




    char* ou;

    ou = (char*)result;





    Int fromCount;

    fromCount = String_CountGet(fromString);


    Int fromData;

    fromData = String_DataGet(fromString);




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