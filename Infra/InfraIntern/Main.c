#include "Main.h"

Int Intern_ModuleInitStageIndex;

Int Intern_ModuleInitStageMaide;

Int Intern_ModuleInitArgIndex;

Int ModuleArray;

Int Intern_Init(Int entryClass, Int entryModuleInit)
{
    Main_Init();

    Intern_NewInit();

    Intern_ModuleInit(entryModuleInit);

    Intern_ClassSharePhoreInit();

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

Bool Intern_ClassSharePhoreInit()
{
    Int array;
    array = ModuleArray;

    Int count;
    count = Array_CountGet(array);
    Int i;
    i = 0;
    while (i < count)
    {
        Int a;
        a = Array_ItemGet(array, i);

        Module* module;
        module = CastPointer(a);

        Intern_ClassSharePhoreInitModule(module);

        i = i + 1;
    }

    return true;
}

Bool Intern_ClassSharePhoreInitModule(Module* module)
{
    Int* array;
    array = CastPointer(module->ClassArray);

    Int count;
    count = module->ClassArrayCount;

    Int i;
    i = 0;
    while (i < count)
    {
        Int a;
        a = array[i];

        Int* p;
        p = CastPointer(a);

        Int phore;
        phore = Phore_New();

        Phore_InitCountSet(phore, 1);

        Phore_Init(phore);

        p[4] = phore;

        i = i + 1;
    } 

    return true;
}

Int Intern_ModuleInitStage()
{
    return Intern_ModuleInitStageIndex;
}

Int Intern_ModuleInitMaide()
{
    return Intern_ModuleInitStageMaide;
}

Bool Intern_ModuleInit(Int entryModuleInit)
{
    Intern_ModuleInit_Maide moduleInit;
    moduleInit = (Intern_ModuleInit_Maide)entryModuleInit;

    Int maide;
    maide = 0;

    maide = CastInt(Intern_ModuleInit_ModuleCount);

    Intern_ModuleInitStageMaide = maide;
    Intern_ModuleInitStageIndex = 0;
    Intern_ModuleInitArgIndex = 0;

    moduleInit();

    Int count;
    count = Intern_ModuleInitArgIndex;

    Int array;
    array = Array_New();
    Array_CountSet(array, count);
    Array_Init(array);
    ModuleArray = array;

    maide = CastInt(Intern_ModuleInit_ModuleSet);

    Intern_ModuleInitStageMaide = maide;
    Intern_ModuleInitStageIndex = 1;
    Intern_ModuleInitArgIndex = 0;

    moduleInit();

    return true;
}

Int Intern_ModuleInit_ModuleCount(Int module)
{
    Intern_ModuleInitArgIndex = Intern_ModuleInitArgIndex + 1;
    return true;
}

Int Intern_ModuleInit_ModuleSet(Int module)
{
    Int index;
    index = Intern_ModuleInitArgIndex;

    Array_ItemSet(ModuleArray, index, module);

    Intern_ModuleInitArgIndex = index + 1;
    return true;
}

Bool Intern_NewInit()
{
    Int phore;
    phore = Phore_New();

    Phore_InitCountSet(phore, 1);

    Phore_Init(phore);

    Intern_New_PhoreSet(phore);

    return true;
}