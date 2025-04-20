#include "Main.h"

Int ModuleArray;
Int ModuleArrayCount;

Int ModuleIndex;

Int ArgArray;

Int ArgCount;

Int Intern_Init(Int entryModule, Int entryClassIndex, Int entryModuleInit, Int moduleCount)
{
    Intern_ArgInit();

    Intern_NewInit();

    Int count;
    count = moduleCount;

    Int dataCount;
    dataCount = count * Constant_IntByteCount();

    ModuleArray = Environ_New(dataCount);
    ModuleArrayCount = count;

    Intern_Module_State moduleInit;
    moduleInit = (Intern_Module_State)entryModuleInit;

    moduleInit();

    Intern_Module* pModule;
    pModule = CastPointer(entryModule);

    Int entryClass;
    entryClass = pModule->Class[entryClassIndex].Var;

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

    eval->N = eval->N - 1;

    Int a;
    a = ka;
    return a;
}

Int Intern_Execute(Int ka)
{
    Eval* eval;
    eval = CastPointer(ka);

    Intern_Call(eval, 1, 3, 1);

    Int a;
    a = eval->S[eval->N - 1];

    eval->N = eval->N - 1;

    RefKindClear(a);

    return a;
}

Int Intern_Final(Int eval)
{
    return true;
}

Bool Intern_ClassSharePhoreInit()
{
    Int array;
    array = ModuleArray;

    Int count;
    count = ModuleArrayCount;

    Int* p;
    p = CastPointer(array);

    Int i;
    i = 0;
    while (i < count)
    {
        Int module;
        module = p[i];

        Intern_ClassSharePhoreInitModule(module);

        i = i + 1;
    }

    return true;
}

Bool Intern_ClassSharePhoreInitModule(Int module)
{
    Intern_Module* kk;
    kk = CastPointer(module);

    Intern_Class* array;
    array = kk->Class;

    Int count;
    count = kk->Count;

    Int i;
    i = 0;
    while (i < count)
    {
        Intern_Class* a;
        a = &(array[i]);

        Int phore;
        phore = Phore_New();

        Phore_InitCountSet(phore, 1);

        Phore_Init(phore);

        (a->Data)[4] = phore;

        i = i + 1;
    } 

    return true;
}

Bool Intern_NewInit()
{
    Int phore;
    phore = Phore_New();

    Phore_InitCountSet(phore, 1);

    Phore_Init(phore);

    Intern_New_PhoreSet(phore);

    Int count;
    count = 2 * 1024 * 1024;

    Intern_New_AllocCapSet(count);

    return true;
}

Bool Intern_ArgInit()
{
    Int array;
    array = Main_Arg();

    Int count;
    count = Array_CountGet(array);

    count = count - 1;

    Int intCount;
    intCount = count * 2;

    Int ka;
    ka = intCount * Constant_IntByteCount();

    Int k;
    k = Environ_New(ka);

    Int* p;
    p = CastPointer(k);

    Int i;
    i = 0;
    while (i < count)
    {
        Int index;
        index = i + 1;

        Int a;
        a = Array_ItemGet(array, index);

        Int value;
        value = String_ValueGet(a);

        Int count;
        count = String_CountGet(a);

        RefKindSet(value, RefKindStringValueData);

        RefKindClear(count);
        RefKindSet(count, RefKindInt);

        Int kaa;
        kaa = i * 2;

        p[kaa] = value;

        p[kaa + 1] = count;

        i = i + 1;
    }

    ArgArray = k;

    ArgCount = count;
    return true;
}

Int Intern_Base_Set(Intern_Class* varClass, Intern_Class* baseClass, Int count)
{
    Int dest;
    dest = varClass->Data[0];

    Int source;
    source = baseClass->Data[0];

    Int dataCount;
    dataCount = count * Constant_IntByteCount();

    Environ_Copy(dest, source, dataCount);

    Int* p;
    p = CastPointer(dest);

    p[count] = CastInt(varClass->BaseItem);
    return 0;
}

Int Intern_Module_Set(Intern_Module* module)
{
    Int* p;
    p = CastPointer(ModuleArray);

    Int k;
    k = CastInt(module);

    p[ModuleIndex] = k;

    ModuleIndex = ModuleIndex + 1;

    return 0;
}