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

Int Intern_StatusWrite(Int status)
{
    if (status == 0)
    {
        return status;
    }

    Int formatBase;
    formatBase = String_ConstantCreate(CastInt("Status: \n"));
    
    Int formatArg;
    formatArg = FormatArg_New();
    FormatArg_Init(formatArg);

    FormatArg_PosSet(formatArg, 8);
    FormatArg_KindSet(formatArg, 1);
    FormatArg_ValueSet(formatArg, status);
    FormatArg_AlignLeftSet(formatArg, false);
    FormatArg_FieldWidthSet(formatArg, 0);
    FormatArg_MaxWidthSet(formatArg, -1);
    FormatArg_BaseSet(formatArg, 10);
    FormatArg_FillCharSet(formatArg, 0);
    FormatArg_FormSet(formatArg, null);

    Int formatArgList;
    formatArgList = Array_New();
    Array_CountSet(formatArgList, 1);
    Array_Init(formatArgList);

    Array_ItemSet(formatArgList, 0, formatArg);

    Int format;
    format = Format_New();
    Format_Init(format);

    Int formatCount;
    formatCount = Format_ExecuteCount(format, formatBase, formatArgList);

    Int formatByteCount;
    formatByteCount = formatCount * Constant_CharByteCount();

    Int formatResultValue;
    formatResultValue = Environ_New(formatByteCount);

    Int formatResult;
    formatResult = String_New();
    String_Init(formatResult);

    String_ValueSet(formatResult, formatResultValue);
    String_CountSet(formatResult, formatCount);

    Format_ExecuteResult(format, formatBase, formatArgList, formatResult);

    Console_ErrWrite(0, formatResult);

    String_Final(formatResult);
    String_Delete(formatResult);

    Environ_Delete(formatResultValue);

    Format_Final(format);
    Format_Delete(format);

    Array_Final(formatArgList);
    Array_Delete(formatArgList);

    FormatArg_Final(formatArg);
    FormatArg_Delete(formatArg);

    String_ConstantDelete(formatBase);

    return 1;
}