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

    QCoreApplication::addLibraryPath(".");

    m->Intern = new QApplication(argc, argv);

    m->MainThread = Thread_New();
    Thread_InitMainThread(m->MainThread);

    Console_OS_Init();

    Main_InitArg();
    return true;
}

Int Main_Final()
{
    Main* m;
    m = &D_Var;

    Main_FinalArg();

    Thread_FinalMainThread(m->MainThread);
    Thread_Delete(m->MainThread);

    delete m->Intern;

    Share_Final(m->Share);
    Share_Delete(m->Share);
    return true;
}

Int Main_IsCSharpSet(Int value)
{
    Main* m;
    m = &D_Var;
    m->IsCSharp = value;
    return true;
}

Int Main_Arg()
{
    Main* m;
    m = &D_Var;

    Int a;
    a = m->Arg;
    return a;
}

Int Main_InitArg()
{
    Main* m;
    m = &D_Var;

    Int a;
    a = Main_OS_Arg();

    m->Arg = a;

    return true;
}

Int Main_FinalArg()
{
    Main* m;
    m = &D_Var;

    Int array;
    array = m->Arg;

    Int count;
    count = Array_CountGet(array);

    Int i;
    i = 0;
    while (i < count)
    {
        Int index;
        index = count - 1 - i;

        Int a;
        a = Array_ItemGet(array, index);

        Int data;
        data = String_DataGet(a);

        String_Final(a);

        String_Delete(a);

        Delete(data);

        i = i + 1;
    }

    Array_Final(array);

    Array_Delete(array);

    return true;
}



Int Main_ExecuteEventLoop()
{
    int u;
    u = QApplication::exec();
    Int a;
    a = u;
    return a;
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

Int Main_CurrentThreadSignalHandleSet()
{
    // Main* m;
    // m = &D_Var;

    // if (!(m->IsCSharp))
    // {
    //     signal(SIGSEGV, Main_SignalHandle);
    // }
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