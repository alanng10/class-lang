#include "Main.h"

Int ModuleArray;
Int ModuleArrayCount;

Int ArgArray;

Int ArgCount;

Int Intern_Init(Int entryClass, Int entryModuleArray, Int entryModuleArrayCount)
{
    Main_Init();

    Intern_ArgInit();

    Intern_NewInit();

    ModuleArray = entryModuleArray;
    ModuleArrayCount = entryModuleArrayCount;

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
    Int* kk;
    kk = CastPointer(module);

    Int ka;
    ka = kk[0];

    Int* array;
    array = CastPointer(ka);

    Int count;
    count = kk[1];

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

    Int intCount;
    intCount = count * 2;

    Int ka;
    ka = intCount * Constant_IntByteCount();

    Int k;
    k = New(ka);

    Int* p;
    p = CastPointer(k);

    Int i;
    i = 0;
    while (i < count)
    {
        Int a;
        a = Array_ItemGet(array, i);

        Int value;
        value = String_DataGet(a);

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