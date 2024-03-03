#include "Main.hpp"






Main D_Var;




Int Main_Init()
{
    Main* m;

    m = &D_Var;




    m->Share = Share_New();



    Share_Init(m->Share);







    m->Argv[0] = (char*)"Application";





    int argc;

    argc = 1;



    char** argv;

    argv = m->Argv;





    m->Intern = new QApplication(argc, argv);






    m->MainThread = Thread_New();



    Thread_InitMainThread(m->MainThread);






    Console_OS_Init();






    return true;
}





Int Main_Final()
{
    Main* m;

    m = &D_Var;




    Thread_FinalMainThread(m->MainThread);



    Thread_Delete(m->MainThread);




    delete m->Intern;






    Share_Final(m->Share);


    Share_Delete(m->Share);





    return true;
}





Bool Main_IsCSharpSet(Bool value)
{
    Main* m;

    m = &D_Var;



    m->IsCSharp = value;



    return true;
}






Int Main_ExecuteEventLoop()
{
    int u;

    u = QApplication::exec();



    Int o;

    o = u;


    return o;
}




Int Main_ExitEventLoop(Int code)
{
    int u;

    u = code;



    QApplication::exit(u);



    return true;
}






Int Main_TerminateStateGet()
{
    Main* m;

    m = &D_Var;



    return m->TerminateState;
}





Int Main_TerminateStateSet(Int value)
{
    Main* m;

    m = &D_Var;



    m->TerminateState = value;


    return true;
}





Int Main_SetCurrentThreadSignalHandle()
{
    Main* m;

    m = &D_Var;



    if (!(m->IsCSharp))
    {
        signal(SIGSEGV, Main_SignalHandle);
    }



    return true;
}






void Main_SignalHandle(int signo)
{
    Main* m;

    m = &D_Var;



    Int state;

    state = m->TerminateState;



    Int a;

    a = State_MaideGet(state);


    Int arg;

    arg = State_ArgGet(state);



    Main_Terminate_Maide maide;

    maide = (Main_Terminate_Maide)a;



    if (!(maide == null))
    {
        maide(arg);
    }
}





Int Infra_Share()
{
    Main* m;

    m = &D_Var;



    return m->Share;
}
