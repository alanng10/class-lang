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
    Console* m;
    m = CP(o);

    Int share;
    share = Infra_Share();
    Int stat;
    stat = Share_Stat(share);

    Int phore;
    phore = Stat_ConsolePhore(stat);

    Phore_Acquire(phore);

    QString oa;
    Int ua;
    ua = CastInt(&oa);
    String_QStringSetRaw(ua, text);

    std::ostream* ob;
    ob = (std::ostream*)stream;

    std::string oo;
    oo = oa.toStdString();

    (*ob) << oo;

    ob->flush();

    Phore_Release(phore);
    return true;
}

Int Console_InnRead(Int o)
{
    Console* m;
    m = CP(o);

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