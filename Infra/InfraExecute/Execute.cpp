#include "Execute.hpp"

Int Execute()
{
    Main_Init();

    Int argArray;
    argArray = Main_Arg();

    Int argCount;
    argCount = Array_CountGet(argArray);

    if (!(argCount == 1))
    {
        return 270;
    }

    Int arg;
    arg = Array_ItemGet(argArray, 0);

    QString moduleRef;
    Int pModuleRef;
    pModuleRef = CastInt(&moduleRef);
    
    Int ba;
    ba = ExecuteArg(pModuleRef, arg);

    if (!ba)
    {
        return 271;
    }



    Int eval;

    eval = Intern_Init();

    Int a;
    a = Intern_Execute(eval);

    Intern_Final(eval);

    Main_Final();

    return a;
}

Int ExecuteArg(Int result, Int arg)
{
    QString k;

    Int value;
    value = String_ValueGet(arg);
    Int count;
    count = String_CountGet(arg);

    Char* p;
    p = (Char*)value;

    Int i;
    i = 0;
    while (i < count)
    {
        Char n;
        n = p[i];

        if (!(n < 0x100))
        {
            return false;
        }

        QChar kk;
        kk = (QChar)n;

        k.append(kk);

        i = i + 1;
    }

    QString* ke;
    ke = (QString*)result;

    *ke = k;
    return true;
}

Int ExecuteModuleString(Int result, Int moduleRef)
{
    QString k;

    QString* ka;
    ka = (QString*)moduleRef;

    k.append('C');
    k.append('_');

    qsizetype naa;
    naa = ka->indexOf('-');

    QString kaa;
    kaa = ka->mid(0, naa);

    QString kab;
    kab = ka->mid(naa + 1);

    
}

Int ExecuteModuleVer(Int result, Int moduleVer)
{
    QString* k;
    k = (QString*)moduleVer;

    qsizetype na;
    na = k->indexOf('.');

    qsizetype nb;
    nb = k->indexOf('.', na + 1);

    QString ka;
    ka = k->mid(0, na);

    qsizetype countA;
    countA = nb - (na + 1);

    QString kb;
    kb = k->mid(na + 1, countA);

    QString kc;
    kc = k->mid(nb + 1);

    if (!(kb.length() == 2))
    {
        return false;
    }

    if (!(kc.length() == 2))
    {
        return false;
    }

    bool b;
    b = false;

    Int major;
    major = ka.toULongLong(&b);

    if (!b)
    {
        return false;
    }

    Int minor;
    minor = kb.toULongLong(&b);

    if (!b)
    {
        return false;
    }

    Int revise;
    revise = kc.toULongLong(&b);

    if (!b)
    {
        return false;
    }

    Int a;
    a = 0;
    a = a | (major << 16);
    a = a | (minor << 8);
    a = a | revise;

    Int* ke;
    ke = (Int*)result;

    *ke = a;

    return true;
}