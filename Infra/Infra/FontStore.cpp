#include "FontStore.hpp"

CppClassNew(FontStore)

Int FontStore_Init(Int o)
{
    return true;
}

Int FontStore_Final(Int o)
{
    return true;
}

Int FontStore_Add(Int o, Int data)
{
    Int value;
    value = Data_ValueGet(data);
    Int count;
    count = Data_CountGet(data);

    const char* ka;
    ka = (const char*)value;

    qsizetype kb;
    kb = count;

    QByteArray k(ka, kb);

    int kk;
    kk = QFontDatabase::addApplicationFontFromData(k);

    SInt ke;
    ke = kk;

    Int a;
    a = ke;
    return a;
}

Int FontStore_Rem(Int o, Int ident)
{
    int ka;
    ka = ident;

    bool ba;
    ba = QFontDatabase::removeApplicationFont(ka);

    Bool a;
    a = ba;
    return a;
}

Int FontStore_NameList(Int o)
{
    return false;
}

Int FontStore_NameListIdent(Int o, Int ident)
{
    return false;
}