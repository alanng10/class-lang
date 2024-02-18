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





Int Return_GetString(Int o)
{
    Return* m;

    m = CP(o);



    Int a;

    a = CastInt(m->String);


    return a;
}





Int Return_SetString(Int o, Int value)
{
    Return* m;

    m = CP(o);



    m->String = (QString*)value;



    return true;
}





Int Return_GetStringList(Int o)
{
    Return* m;

    m = CP(o);



    Int a;

    a = CastInt(m->StringList);


    return a;
}





Int Return_SetStringList(Int o, Int value)
{
    Return* m;

    m = CP(o);



    m->StringList = (QStringList*)value;



    return true;
}






Int Return_StringStart(Int o)
{
    return true;
}




Int Return_StringEnd(Int o)
{
    Return* m;

    m = CP(o);




    delete m->String;



    m->String = null;




    return true;
}






Int Return_StringCount(Int o)
{
    Return* m;

    m = CP(o);



    qsizetype u;

    u = m->String->length();



    Int a;

    a = u;



    return a;
}






Int Return_StringResult(Int o, Int result)
{
    Return* m;

    m = CP(o);




    const QChar* sourceU;

    sourceU = m->String->constData();




    Int source;

    source = CastInt(sourceU);




    Int dest;

    dest = String_GetData(result);



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




    delete m->StringList;



    m->StringList = null;




    return true;
}






Int Return_StringListCount(Int o)
{
    Return* m;

    m = CP(o);



    qsizetype u;

    u = m->StringList->size();



    Int a;

    a = u;


    return a;
}





Int Return_StringListItem(Int o, Int index)
{
    Return* m;

    m = CP(o);



    qsizetype u;

    u = index;




    QString aa;

    aa = m->StringList->at(u);



    QString* oa;

    oa = new QString(aa);



    Int a;

    a = CastInt(oa);


    return a;
}


