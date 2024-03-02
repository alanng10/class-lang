#include "Return.hpp"




CppClassNew(Return)






Int Return_Init(Int o)
{
    return true;
}




Int Return_Final(Int o)
{
    return true;
}

CppField(Return, String)
CppField(Return, StringList)

Int Return_StringStart(Int o)
{
    return true;
}

Int Return_StringEnd(Int o)
{
    Return* m;
    m = CP(o);

    QString* u;
    u = (QString*)(m->String);

    delete u;

    m->String = null;
    return true;
}






Int Return_StringCount(Int o)
{
    Return* m;
    m = CP(o);

    QString* u;
    u = (QString*)(m->String);

    qsizetype ua;
    ua = u->length();

    Int a;
    a = ua;
    return a;
}

Int Return_StringResult(Int o, Int result)
{
    Return* m;
    m = CP(o);

    QString* u;
    u = (QString*)(m->String);


    const QChar* sourceU;

    sourceU = u->constData();




    Int source;

    source = CastInt(sourceU);




    Int dest;

    dest = String_DataGet(result);



    Int oa;

    oa = Return_StringCount(o);



    Int count;

    count = oa * Constant_CharByteCount();




    Copy(dest, source, count);





    return true;
}








Int Return_StringListStart(Int o)
{
    return true;
}





Int Return_StringListEnd(Int o)
{
    Return* m;
    m = CP(o);

    QStringList* u;
    u = (QStringList*)(m->StringList);

    delete u;

    m->StringList = null;
    return true;
}






Int Return_StringListCount(Int o)
{
    Return* m;
    m = CP(o);

    QStringList* u;
    u = (QStringList*)(m->StringList);

    qsizetype ua;
    ua = u->size();

    Int a;
    a = ua;
    return a;
}

Int Return_StringListItem(Int o, Int index)
{
    Return* m;
    m = CP(o);

    QStringList* u;
    u = (QStringList*)(m->StringList);

    qsizetype ua;
    ua = index;

    QString aa;
    aa = u->at(ua);

    QString* oa;
    oa = new QString(aa);

    Int a;
    a = CastInt(oa);
    return a;
}