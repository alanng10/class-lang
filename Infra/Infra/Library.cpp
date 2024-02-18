#include "Library.hpp"




CppClassNew(Library)





Int Library_Init(Int o)
{
    Library* m;

    m = CP(o);



    m->Intern = new QLibrary;



    return true;
}




Int Library_Final(Int o)
{
    Library* m;

    m = CP(o);



    delete m->Intern;



    return true;
}





Int Library_GetFile(Int o)
{
    Library* m;

    m = CP(o);


    return m->File;
}




Int Library_SetFile(Int o, Int value)
{
    Library* m;

    m = CP(o);


    m->File = value;


    return true;
}





Int Library_SetLibraryFile(Int o)
{
    Library* m;

    m = CP(o);



    Int file;

    file = m->File;




    QString ao;



    Int ua;

    ua = CastInt(&ao);



    String_SetQString(ua, file);



    m->Intern->setFileName(ao);



    return true;
}






Int Library_Load(Int o)
{
    Library* m;

    m = CP(o);



    m->Intern->load();


    return true;
}





Int Library_Unload(Int o)
{
    Library* m;

    m = CP(o);



    m->Intern->unload();


    return true;
}





Int Library_GetLoaded(Int o)
{
    Library* m;

    m = CP(o);



    bool bu;

    bu = m->Intern->isLoaded();



    Bool a;

    a = bu;


    return a;
}




Int Library_SetLoaded(Int o, Int value)
{
    return true;
}






Int Library_GetAddress(Int o, Int name)
{
    Library* m;

    m = CP(o);



    const char* u;

    u = (const char*)name;



    QFunctionPointer oa;

    oa = m->Intern->resolve(u);



    Int a;

    a = CastInt(oa);


    return a;
}



