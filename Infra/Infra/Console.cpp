#include "Console.hpp"

CppClassNew(Console)

Int Console_Init(Int o)
{
    return true;
}

Int Console_Final(Int o)
{
    return true;
}

Int Console_OutWrite(Int o, Int text)
{
    std::ostream* uu;
    uu = &(std::cout);
    Int ua;
    ua = CastInt(uu);
    return Console_StreamWrite(o, text, ua);
}

Int Console_ErrWrite(Int o, Int text)
{
    std::ostream* uu;
    uu = &(std::cerr);
    Int ua;
    ua = CastInt(uu);
    return Console_StreamWrite(o, text, ua);
}

Int Console_StreamWrite(Int o, Int text, Int stream)
{
    Int share;
    share = Infra_Share();
    Int stat;
    stat = Share_Stat(share);

    Int phore;
    phore = Stat_ConsolePhore(stat);

    Phore_Acquire(phore);

    Int ka;
    Int kb;
    ka = String_CountGet(text);
    kb = String_DataGet(text);

    Int dataCount;
    Int dataValue;
    dataCount = ka * sizeof(Char);
    dataValue = kb;

    Int share;
    share = Infra_Share();
    Int stat;
    stat = Share_Stat(share);

    Int innKind;
    Int outKind;
    innKind = Stat_TextEncodeKindUtf32(stat);
    outKind = Stat_TextEncodeKindUtf8(stat);

    Int k;
    k = TextEncode_ExecuteCount(0, innKind, outKind, dataCount, dataValue);

    Int result;
    result = New(k);

    TextEncode_ExecuteResult(0, result, innKind, outKind, dataCount, dataValue);

    const char* p;
    p = (const char*)result;
    std::size_t uu;
    uu = k;

    {
        std::ostream* ob;
        ob = (std::ostream*)stream;

        std::string oo(p, uu);

        (*ob) << oo;

        ob->flush();
    }

    Delete(result);

    Phore_Release(phore);
    return true;
}

Int Console_InnRead(Int o)
{
    Int share;
    share = Infra_Share();
    Int stat;
    stat = Share_Stat(share);

    Int phore;
    phore = Stat_ConsolePhore(stat);

    Phore_Acquire(phore);

    std::string u;
    std::getline(std::cin, u);

    QString oa;
    oa = QString::fromStdString(u);

    QString* ob;
    ob = new QString(oa);

    Int a;
    a = CastInt(ob);

    Phore_Release(phore);
    return a;
}