#include "Console.hpp"



CppClassNew(Console)





Int Console_Init(Int o)
{
    Console* m;

    m = CP(o);




    Int initCount;

    initCount = 1;



    m->Semaphore = Semaphore_New();


    Semaphore_SetInitCount(m->Semaphore, initCount);


    Semaphore_Init(m->Semaphore);




    return true;
}





Int Console_Final(Int o)
{
    Console* m;

    m = CP(o);



    Semaphore_Final(m->Semaphore);


    Semaphore_Delete(m->Semaphore);




    return true;
}








Int Console_Write(Int o, Int text)
{
    std::ostream* uu;

    uu = &(std::cout);



    Int ua;

    ua = CastInt(uu);



    return Console_StreamWrite(o, text, ua);
}







Int Console_ErrWrite(Int o, Int text)
{
    std::ostream* uu;

    uu = &(std::cerr);



    Int ua;

    ua = CastInt(uu);



    return Console_StreamWrite(o, text, ua);
}







Int Console_StreamWrite(Int o, Int text, Int stream)
{
    Console* m;

    m = CP(o);




    Semaphore_Acquire(m->Semaphore);




    QString oa;


    Int ua;

    ua = CastInt(&oa);



    String_SetQStringRaw(ua, text);




    std::ostream* ob;

    ob = (std::ostream*)stream;





    std::string oo;

    oo = oa.toStdString();




    (*ob) << oo;



    ob->flush();





    Semaphore_Release(m->Semaphore);





    return true;
}







Int Console_Read(Int o)
{
    Console* m;

    m = CP(o);




    Semaphore_Acquire(m->Semaphore);




    std::string u;


    std::getline(std::cin, u);




    QString oa;

    oa = QString::fromStdString(u);




    QString* ob;

    ob = new QString(oa);




    Int a;

    a = CastInt(ob);




    Semaphore_Release(m->Semaphore);





    return a;
}





