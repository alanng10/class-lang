#include "Program.hpp"

CppClassNew(Program)

Int Program_Init(Int o)
{
    Program* m;
    m = CP(o);
    m->Intern = new ProgramIntern;
    m->Intern->Program = o;
    m->Intern->Init();
    return true;
}

Int Program_Final(Int o)
{
    Program* m;
    m = CP(o);

    delete m->Intern;
    return true;
}

CppField(Program, Name)
CppField(Program, Argue)
CppField(Program, WorkFold)
CppField(Program, Environment)

Int Program_Execute(Int o)
{
    Program* m;
    m = CP(o);
    Int name;
    name = m->Name;
    Int argue;
    argue = m->Argue;
    Int workFold;
    workFold = m->WorkFold;
    Int environment;
    environment = m->Environment;

    QString nameU;
    Int ua;
    ua = CastInt(&nameU);
    String_QStringSet(ua, name);

    QStringList argueU;
    Int ub;
    ub = CastInt(&argueU);
    Program_InternArgueSet(ub, argue);

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
        String_QStringSet(uc, workFold);
    }

    QProcessEnvironment environmentU;
    environmentU = QProcessEnvironment::systemEnvironment();
    Bool bb;
    bb = (environment == null);
    if (!bb)
    {
        Int ud;
        ud = CastInt(&environmentU);
        Program_InternEnvironmentSet(ud, environment);
    }

    m->Intern->setProgram(nameU);
    m->Intern->setArguments(argueU);
    m->Intern->setWorkingDirectory(workFoldU);
    m->Intern->setProcessEnvironment(environmentU);
    m->Intern->start();
    return true;
}

Int Program_IdentGet(Int o)
{
    Program* m;
    m = CP(o);
    qint64 u;
    u = m->Intern->processId();
    Int a;
    a = u;
    return a;
}

FieldDefaultSet(Program, Ident)

Int Program_Wait(Int o)
{
    Program* m;
    m = CP(o);
    m->Intern->waitForFinished();
    return true;
}

Int Program_Terminate(Int o)
{
    Program* m;
    m = CP(o);
    m->Intern->kill();
    return true;
}

Int Program_StatusGet(Int o)
{
    Program* m;
    m = CP(o);
    int u;
    u = m->Intern->exitCode();
    Int a;
    a = u;
    return a;
}

FieldDefaultSet(Program, Status)

Int Program_ExitKindGet(Int o)
{
    Program* m;
    m = CP(o);
    QProcess::ExitStatus u;
    u = m->Intern->exitStatus();
    Int a;
    a = u;
    return a;
}

FieldDefaultSet(Program, ExitKind)
CppField(Program, StartState)
CppField(Program, FinishState)

Int Program_Start(Int o)
{
    Program* m;
    m = CP(o);
    Int state;
    state = m->StartState;

    if (state == null)
    {
        return true;
    }

    Int aa;
    aa = State_MaideGet(state);
    Int arg;
    arg = State_ArgGet(state);

    if (aa == null)
    {
        return true;
    }

    Program_Start_Maide maide;
    maide = (Program_Start_Maide)aa;
    
    maide(o, arg);
    
    return true;
}

Int Program_Finish(Int o)
{
    Program* m;
    m = CP(o);
    Int state;
    state = m->FinishState;

    if (state == null)
    {
        return true;
    }

    Int aa;
    aa = State_MaideGet(state);
    Int arg;
    arg = State_ArgGet(state);

    if (aa == null)
    {
        return true;
    }

    Program_Finish_Maide maide;
    maide = (Program_Finish_Maide)aa;
    
    maide(o, arg);
    
    return true;
}

Int Program_InternArgueSet(Int result, Int argue)
{
    QStringList* uu;
    uu = (QStringList*)result;

    Int count;
    count = Array_CountGet(argue);

    qsizetype countU;
    countU = count;

    uu->reserve(countU);

    Int i;
    i = 0;
    while (i < count)
    {
        Int item;
        item = Array_ItemGet(argue, i);

        QString aa;
        Int ua;
        ua = CastInt(&aa);
        String_QStringSet(ua, item);

        uu->append(aa);
        i = i + 1;
    }
    return true;
}

Int Program_InternEnvironmentSet(Int result, Int environment)
{
    QProcessEnvironment* uu;
    uu = (QProcessEnvironment*)result;

    Int count;
    count = Array_CountGet(environment);

    Int i;
    i = 0;
    while (i < count)
    {
        Int entry;
        entry = Array_ItemGet(environment, i);

        Int index;
        index = Entry_IndexGet(entry);
        Int value;
        value = Entry_ValueGet(entry);

        QString indexU;
        Int ua;
        ua = CastInt(&indexU);
        String_QStringSet(ua, index);

        QString valueU;
        Int ub;
        ub = CastInt(&valueU);
        String_QStringSet(ub, value);

        uu->insert(indexU, valueU);
        i = i + 1;
    }
    return true;
}