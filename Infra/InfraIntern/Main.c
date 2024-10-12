#include "Main.h"

Int Intern_Init(Int entryClass, Int entryModuleInit)
{
    Main_Init();

    Intern_ModuleInit_Maide moduleInit;
    moduleInit = (Intern_ModuleInit_Maide)entryModuleInit;
    moduleInit();

    Int ka;
    ka = Intern_InitMainThread();

    Eval* eval;
    eval = CastPointer(ka);

    Intern_New(RefKindAny, entryClass, eval);

    Int entry;
    entry = eval->S[eval->N - 1];

    eval->S[eval->N] = entry;

    eval->N = eval->N + 1;

    Intern_Call(eval, 1, 3, 0);

    Int a;
    a = ka;
    return a;
}

Int Intern_Execute(Int eval)
{
    Eval* e;
    e = CastPointer(eval);

    Intern_Call(e, 1, 3, 1);

    return true;
}

Int Intern_Final(Int eval)
{
    Main_Final();

    return true;
}