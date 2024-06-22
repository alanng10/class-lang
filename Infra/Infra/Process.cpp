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

CppField(Process, Program)
CppField(Process, Argue)
CppField(Process, WorkFold)
CppField(Process, Environment)

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
    String_QStringSet(ua, program);

    QStringList argueU;
    Int ub;
    ub = CastInt(&argueU);
    Process_InternArgueSet(ub, argue);

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
        Process_InternEnvironmentSet(ud, environment);
    }

    m->Intern->setProgram(programU);
    m->Intern->setArguments(argueU);
    m->Intern->setWorkingDirectory(workFoldU);
    m->Intern->setProcessEnvironment(environmentU);
    m->Intern->start();
    return true;
}

Int Process_IdentGet(Int o)
{
    Process* m;
    m = CP(o);
    qint64 u;
    u = m->Intern->processId();
    Int a;
    a = u;
    return a;
}

FieldDefaultSet(Process, Ident)

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

Int Process_StatusGet(Int o)
{
    Process* m;
    m = CP(o);
    int u;
    u = m->Intern->exitCode();
    Int a;
    a = u;
    return a;
}

FieldDefaultSet(Process, Status)

Int Process_ExitKindGet(Int o)
{
    Process* m;
    m = CP(o);
    QProcess::ExitStatus u;
    u = m->Intern->exitStatus();
    Int a;
    a = u;
    return a;
}

FieldDefaultSet(Process, ExitKind)
CppField(Process, StartState)
CppField(Process, FinishState)

Int Process_Start(Int o)
{
    Process* m;
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

    Process_Start_Maide maide;
    maide = (Process_Start_Maide)aa;
    if (!(maide == null))
    {
        maide(o, arg);
    }
    return true;
}

Int Process_Finish(Int o)
{
    Process* m;
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

    Process_Finish_Maide maide;
    maide = (Process_Finish_Maide)aa;
    if (!(maide == null))
    {
        maide(o, arg);
    }
    return true;
}

Int Process_InternArgueSet(Int result, Int argue)
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

Int Process_InternEnvironmentSet(Int result, Int environment)
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