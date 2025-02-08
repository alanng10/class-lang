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