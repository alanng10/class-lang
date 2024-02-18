#include "Process.hpp"




CppClassNew(Process)






Int Process_Init(Int o)
{
    Process* m;

    m = CP(o);



    m->Intern = new ProcessIntern;


    m->Intern->Process = o;


    m->Intern->Init();




    return true;
}




Int Process_Final(Int o)
{
    Process* m;

    m = CP(o);



    delete m->Intern;



    return true;
}






Int Process_GetProgram(Int o)
{
    Process* m;

    m = CP(o);


    return m->Program;
}




Int Process_SetProgram(Int o, Int value)
{
    Process* m;

    m = CP(o);


    m->Program = value;


    return true;
}





Int Process_GetArgue(Int o)
{
    Process* m;

    m = CP(o);


    return m->Argue;
}




Int Process_SetArgue(Int o, Int value)
{
    Process* m;

    m = CP(o);


    m->Argue = value;


    return true;
}






Int Process_GetWorkFold(Int o)
{
    Process* m;

    m = CP(o);


    return m->WorkFold;
}




Int Process_SetWorkFold(Int o, Int value)
{
    Process* m;

    m = CP(o);


    m->WorkFold = value;


    return true;
}







Int Process_GetEnvironment(Int o)
{
    Process* m;

    m = CP(o);


    return m->Environment;
}




Int Process_SetEnvironment(Int o, Int value)
{
    Process* m;

    m = CP(o);


    m->Environment = value;


    return true;
}






Int Process_Execute(Int o)
{
    Process* m;

    m = CP(o);




    Int program;

    program = m->Program;



    Int argue;

    argue = m->Argue;



    Int workFold;

    workFold = m->WorkFold;



    Int environment;

    environment = m->Environment;





    QString programU;


    Int ua;

    ua = CastInt(&programU);



    String_SetQString(ua, program);





    QStringList argueU;


    Int ub;

    ub = CastInt(&argueU);



    Process_InternSetArgue(ub, argue);





    QString workFoldU;



    Bool ba;

    ba = (workFold == null);



    if (ba)
    {
        workFoldU = "";
    }



    if (!ba)
    {
        Int uc;

        uc = CastInt(&workFoldU);



        String_SetQString(uc, workFold);
    }





    QProcessEnvironment environmentU;


    environmentU = QProcessEnvironment::systemEnvironment();



    Bool bb;

    bb = (environment == null);


    if (!bb)
    {
        Int ud;

        ud = CastInt(&environmentU);



        Process_InternSetEnvironment(ud, environment);
    }





    m->Intern->setProgram(programU);



    m->Intern->setArguments(argueU);



    m->Intern->setWorkingDirectory(workFoldU);



    m->Intern->setProcessEnvironment(environmentU);




    m->Intern->start();




    return true;
}






Int Process_GetIdent(Int o)
{
    Process* m;

    m = CP(o);



    qint64 u;

    u = m->Intern->processId();



    Int a;

    a = u;


    return a;
}






Int Process_Wait(Int o)
{
    Process* m;

    m = CP(o);



    m->Intern->waitForFinished();



    return true;
}





Int Process_Terminate(Int o)
{
    Process* m;

    m = CP(o);



    m->Intern->kill();



    return true;
}






Int Process_GetStatus(Int o)
{
    Process* m;

    m = CP(o);



    int u;

    u = m->Intern->exitCode();



    Int a;

    a = u;


    return a;
}





Int Process_GetExitKind(Int o)
{
    Process* m;

    m = CP(o);



    QProcess::ExitStatus u;

    u = m->Intern->exitStatus();



    Int a;

    a = u;


    return a;
}







Int Process_GetStartedState(Int o)
{
    Process* m;

    m = CP(o);


    return m->StartedState;
}




Int Process_SetStartedState(Int o, Int value)
{
    Process* m;

    m = CP(o);


    m->StartedState = value;


    return true;
}







Int Process_GetFinishedState(Int o)
{
    Process* m;

    m = CP(o);


    return m->FinishedState;
}




Int Process_SetFinishedState(Int o, Int value)
{
    Process* m;

    m = CP(o);


    m->FinishedState = value;


    return true;
}







Int Process_Started(Int o)
{
    Process* m;

    m = CP(o);



    Int state;

    state = m->StartedState;



    Int aa;

    aa = State_GetMaide(state);


    Int arg;

    arg = State_GetArg(state);




    Process_Started_Maide maide;

    maide = (Process_Started_Maide)aa;



    if (!(maide == null))
    {
        maide(o, arg);
    }




    return true;
}






Int Process_Finished(Int o)
{
    Process* m;

    m = CP(o);



    Int state;

    state = m->FinishedState;



    Int aa;

    aa = State_GetMaide(state);


    Int arg;

    arg = State_GetArg(state);




    Process_Finished_Maide maide;

    maide = (Process_Finished_Maide)aa;



    if (!(maide == null))
    {
        maide(o, arg);
    }




    return true;
}






Int Process_InternSetArgue(Int result, Int argue)
{
    QStringList* uu;

    uu = (QStringList*)result;



    *uu = QStringList();




    Int count;

    count = Array_GetCount(argue);



    qsizetype countU;

    countU = count;


    uu->reserve(countU);



    Int item;

    item = null;



    Int i;

    i = 0;


    while (i < count)
    {
        item = Array_GetItem(argue, i);



        QString aa;



        Int ua;

        ua = CastInt(&aa);



        String_SetQString(ua, item);



        uu->append(aa);




        i = i + 1;
    }



    return true;
}






Int Process_InternSetEnvironment(Int result, Int environment)
{
    QProcessEnvironment* uu;

    uu = (QProcessEnvironment*)result;




    Int count;

    count = Array_GetCount(environment);



    Int i;

    i = 0;


    while (i < count)
    {
        Int entry;

        entry = Array_GetItem(environment, i);




        Int index;

        index = Entry_GetIndex(entry);


        Int value;

        value = Entry_GetValue(entry);




        QString indexU;


        Int ua;

        ua = CastInt(&indexU);


        String_SetQString(ua, index);




        QString valueU;


        Int ub;

        ub = CastInt(&valueU);


        String_SetQString(ub, value);





        uu->insert(indexU, valueU);





        i = i + 1;
    }




    return true;
}

