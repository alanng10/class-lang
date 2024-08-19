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
    ka = String_DataGet(text);
    kb = String_CountGet(text);

    Int dataValue;
    Int dataCount;
    dataValue = ka;
    dataCount = kb * sizeof(Char);

    Int innKind;
    Int outKind;
    innKind = Stat_TextCodeKindUtf32(stat);
    outKind = Stat_TextCodeKindUtf8(stat);

    Int k;
    k = TextCode_ExecuteCount(0, innKind, outKind, dataValue, dataCount);

    Int result;
    result = New(k);

    TextCode_ExecuteResult(0, result, innKind, outKind, dataValue, dataCount);

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

    char* p;
    p = u.data();

    std::size_t uu;
    uu = u.length();

    Int ka;
    Int kb;
    ka = CastInt(p);
    kb = uu;

    Int dataValue;
    Int dataCount;
    dataValue = ka;
    dataCount = kb;

    Int innKind;
    Int outKind;
    innKind = Stat_TextCodeKindUtf8(stat);
    outKind = Stat_TextCodeKindUtf32(stat);

    Int resultCount;
    resultCount = TextCode_ExecuteCount(0, innKind, outKind, dataValue, dataCount);

    Int result;
    result = New(resultCount);

    TextCode_ExecuteResult(0, result, innKind, outKind, dataValue, dataCount);

    Int count;
    count = resultCount / sizeof(Char);

    Int k;
    k = String_New();
    String_Init(k);
    String_DataSet(k, result);
    String_CountSet(k, count);

    Int a;
    a = k;

    Phore_Release(phore);
    return a;
}