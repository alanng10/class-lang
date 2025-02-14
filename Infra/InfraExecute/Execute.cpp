#include "Execute.hpp"

Int Execute()
{
    Main_Init();

    Int argArray;
    argArray = Main_Arg();

    Int argCount;
    argCount = Array_CountGet(argArray);

    if (argCount < 1)
    {
        return 270;
    }

    Int arg;
    arg = Array_ItemGet(argArray, 0);

    QString moduleRef;
    Int pModuleRef;
    pModuleRef = CastInt(&moduleRef);
    
    Bool ba;
    ba = ExecuteArg(pModuleRef, arg);

    if (!ba)
    {
        return 271;
    }

    QString moduleString;
    Int pModuleString;
    pModuleString = CastInt(&moduleString);

    Bool bb;
    bb = ExecuteModuleString(pModuleString, pModuleRef);

    if (!bb)
    {
        return 272;
    }

    QString initString;
    initString = moduleString;
    initString.append("_Init");

    QString varString;
    varString = moduleString;
    varString.append("_Var");

    QString entryString;
    entryString = moduleString;
    entryString.append("_Entry");

    QString countString;
    countString = moduleString;
    countString.append("_Count");

    Int libPath;
    libPath = String_ConstantCreate(CastInt("Module"));

    Bool bc;
    bc = StorageComp_ThisFoldSet(0, libPath);

    if (!bc)
    {
        return 273;
    }

    QLibrary library;
    library.setFileName(moduleRef);
    
    bool bu;
    bu = library.load();

    Bool bd;
    bd = bu;

    if (!bd)
    {
        return 280;
    }

    QByteArray initStringK;
    initStringK = initString.toLatin1();

    const char* initStringU;
    initStringU = initStringK.constData();

    QByteArray varStringK;
    varStringK = varString.toLatin1();

    const char* varStringU;
    varStringU = varStringK.constData();

    QByteArray entryStringK;
    entryStringK = entryString.toLatin1();

    const char* entryStringU;
    entryStringU = entryStringK.constData();

    QByteArray countStringK;
    countStringK = countString.toLatin1();

    const char* countStringU;
    countStringU = countStringK.constData();

    Intern_Module_State initState;
    initState = (Intern_Module_State)library.resolve(initStringU);

    if (initState == null)
    {
        return 281;
    }

    Intern_Module_State varState;
    varState = (Intern_Module_State)library.resolve(varStringU);

    if (varState == null)
    {
        return 282;
    }

    Intern_Module_State entryState;
    entryState = (Intern_Module_State)library.resolve(entryStringU);

    if (entryState == null)
    {
        return 283;
    }

    Intern_Module_State countState;
    countState = (Intern_Module_State)library.resolve(countStringU);

    if (countState == null)
    {
        return 284;
    }

    Int entryModule;
    entryModule = varState();

    Int entryClassIndex;
    entryClassIndex = entryState();

    Int moduleCount;
    moduleCount = countState();

    Int intNull;
    intNull = ((Int)((SInt)-1));

    if (entryClassIndex == intNull)
    {
        return 285;
    }

    Int entryModuleInit;
    entryModuleInit = CastInt(initState);

    Int eval;

    eval = Intern_Init(entryModule, entryClassIndex, entryModuleInit, moduleCount);

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
        kk = QChar(n);

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
    QString* k;
    k = (QString*)moduleRef;

    qsizetype na;
    na = k->indexOf('-');

    QString ka;
    ka = k->mid(0, na);

    QString kb;
    kb = k->mid(na + 1);

    Int pka;
    pka = CastInt(&ka);

    QString moduleNameString;
    
    Int pkka;
    pkka = CastInt(&moduleNameString);

    Bool b;
    b = ExecuteModuleNameString(pkka, pka);

    if (!b)
    {
        return false;
    }

    Int pkb;
    pkb = CastInt(&kb);

    Int moduleVer;
    moduleVer = 0;

    Int paa;
    paa = CastInt(&moduleVer);

    b = ExecuteModuleVer(paa, pkb);

    if (!b)
    {
        return false;
    }

    QString moduleVerString;
    
    Int pkkb;
    pkkb = CastInt(&moduleVerString);

    b = ExecuteModuleVerString(pkkb, moduleVer);

    if (!b)
    {
        return false;
    }

    QString a;

    a.append(QChar('C'));
    a.append(QChar('_'));

    a.append(moduleNameString);

    a.append(QChar('_'));

    a.append(moduleVerString);

    QString* ke;
    ke = (QString*)result;

    *ke = a;

    return true;
}

Int ExecuteModuleVer(Int result, Int moduleRefVer)
{
    QString* k;
    k = (QString*)moduleRefVer;

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

Int ExecuteModuleNameString(Int result, Int moduleName)
{
    QString a;

    QString* k;
    k = (QString*)moduleName;

    Int count;
    count = k->length();

    Int i;
    i = 0;
    while (i < count)
    {
        QChar na;
        na = k->at(i);

        Byte ka;
        ka = na.toLatin1();

        Bool b;
        b = ExecuteValidModuleNameChar(ka);

        if (!b)
        {
            return false;
        }

        Int kk;
        kk = ka;

        Int upper;
        Int lower;
        upper = kk >> 4;
        lower = kk & 0xf;

        Int upperChar;
        upperChar = ExecuteHexDigitChar(upper);

        Int lowerChar;
        lowerChar = ExecuteHexDigitChar(lower);

        Byte kaa;
        Byte kab;
        kaa = upperChar;
        kab = lowerChar;

        QChar kba;
        QChar kbb;
        kba = QChar(kaa);
        kbb = QChar(kab);

        a.append(kba);
        a.append(kbb);

        i = i + 1;
    }

    QString* ke;
    ke = (QString*)result;

    *ke = a;
    return true;
}

Int ExecuteModuleVerString(Int result, Int moduleVer)
{
    QString a;

    Int count;
    count = 15;

    Int i;
    i = 0;
    while (i < count)
    {
        Int index;
        index = count - 1 - i;

        Int shift;
        shift = index * 4;

        Int k;
        k = moduleVer;
        k = k >> shift;
        k = k & 0xf;

        Int n;
        n = ExecuteHexDigitChar(k);

        Byte kk;
        kk = n;

        QChar ka;
        ka = QChar(kk);

        a.append(ka);

        i = i + 1;
    }

    QString* ke;
    ke = (QString*)result;

    *ke = a;
    return true;
}

Int ExecuteValidModuleNameChar(Int n)
{
    Bool ba;
    ba = !((n < '0') | ('9' < n));

    Bool bb;
    bb = !((n < 'A') | ('Z' < n));

    Bool bc;
    bc = !((n < 'a') | ('z' < n));

    Bool bd;
    bd = (n == '_');

    Bool be;
    be = (n == '.');
    
    Bool b;
    b = ba | bb | bc | bd | be;

    Bool a;
    a = b;
    return a;
}

Int ExecuteHexDigitChar(Int value)
{
    if (value < 10)
    {
        Int aa;
        aa = '0' + value;
        return aa;
    }

    Int k;
    k = value - 10;

    Int a;
    a = 'a' + k;
    return a;
}