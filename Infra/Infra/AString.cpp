#include "AString.hpp"

CppClassNew(String)

Int String_Init(Int o)
{
    return true;
}

Int String_Final(Int o)
{
    return true;
}

CppField(String, Count)
CppField(String, Data)

Int String_Char(Int o, Int index)
{
    String* m;
    m = CP(o);
    Char* u;
    u = (Char*)(m->Data);
    return u[index];
}

Int String_Equal(Int o, Int other)
{
    String* m;
    m = CP(o);
    String* d;
    d = (String*)(other);

    Bool ba;    
    ba = (m->Count == d->Count);
    if (!ba)
    {
        return false;
    }

    Char* mf;    
    mf = (Char*)(m->Data);
    Char* df;
    df = (Char*)(d->Data);

    Int count;
    count = m->Count;
    Int i;
    i = 0;
    while (i < count)
    {
        if (!(mf[i] == df[i]))
        {
            return false;
        }
        i = i + 1;
    }
    return true;
}

Int String_ConstantCount(Int o)
{
    Byte* p;
    p = (Byte*)o;

    Int k;
    k = 0;
    while (!((*p) == '\0'))
    {
        k = k + 1;
        p = p + 1;
    }
    return k;
}

Int String_ConstantCreate(Int o)
{
    Int count;
    count = String_ConstantCount(o);

    Int share;
    share = Infra_Share();
    Int stat;
    stat = Share_Stat(share);

    Int innKind;
    innKind = Stat_TextEncodeKindUtf8(stat);
    Int outKind;
    outKind = Stat_TextEncodeKindUtf32(stat);

    Int innDataValue;
    Int innDataCount;
    innDataValue = o;
    innDataCount = count;

    Int k;
    k = TextEncode_ExecuteCount(0, innKind, outKind, innDataValue, innDataCount);

    Int outDataValue;
    Int outDataCount;
    outDataValue = New(k);
    outDataCount = k;

    TextEncode_ExecuteResult(0, outDataValue, innKind, outKind, innDataValue, innDataCount);

    Int stringCount;
    stringCount = outDataCount / sizeof(Char);

    Int kk;
    kk = String_New();
    String_Init(kk);
    String_DataSet(kk, outDataValue);
    String_CountSet(kk, stringCount);

    Int a;
    a = kk;
    return a;
}

Int String_ConstantDelete(Int o)
{
    Int data;
    data = String_DataGet(o);

    String_Final(o);
    String_Delete(o);

    Delete(data);
    return true;
}

Int String_QStringSet(Int result, Int a)
{
    Int count;
    count = String_CountGet(a);
    Int data;
    data = String_DataGet(a);

    const char32_t* dataU;
    dataU = (const char32_t*)data;
    qsizetype countU;
    countU = count;

    QString* u;
    u = (QString*)result;
    *u = QString::fromUcs4(dataU, countU);
    return true;
}