#include "NetworkPort.hpp"

CppClassNew(NetworkPort)

Int NetworkPort_Init(Int o)
{
    NetworkPort* m;
    m = CP(o);
    m->InternAddress = new QHostAddress;
    return true;
}

Int NetworkPort_Final(Int o)
{
    NetworkPort* m;
    m = CP(o);

    delete m->InternAddress;
    return true;
}

Int NetworkPort_Set(Int o)
{
    NetworkPort* m;
    m = CP(o);
    Int kind;
    kind = m->Kind;
    if (kind == null)
    {
        return true;
    }

    Int share;
    share = Infra_Share();
    Int stat;
    stat = Share_Stat(share);

    Bool b;
    b = false;
    if ((!b) & (kind == Stat_NetworkPortKindIPv6(stat)))
    {
        Q_IPV6ADDR u;
        u = { };

        quint8* ua;
        ua = &(u.c[0]);

        Int uu;
        uu = CastInt(ua);

        NetworkPort_ValueSet(o, uu, 0, m->ValueA, 6);
        NetworkPort_ValueSet(o, uu, 6, m->ValueB, 6);
        NetworkPort_ValueSet(o, uu, 12, m->ValueC, 4);

        m->InternAddress->setAddress(u);
        b = true;
    }

    if ((!b) & (kind == Stat_NetworkPortKindIPv4(stat)))
    {
        quint32 u;
        u = m->ValueA;

        m->InternAddress->setAddress(u);
        b = true;
    }

    if (!b)
    {
        QHostAddress::SpecialAddress uu;
        uu = (QHostAddress::SpecialAddress)(kind - 2);
        m->InternAddress->setAddress(uu);
    }
    return true;
}

CppField(NetworkPort, Kind)
CppField(NetworkPort, ValueA)
CppField(NetworkPort, ValueB)
CppField(NetworkPort, ValueC)
CppField(NetworkPort, Server)

Int NetworkPort_ValueSet(Int o, Int pointer, Int index, Int value, Int count)
{
    Int* sourceU;
    sourceU = &value;
    Int source;
    source = CastInt(sourceU);
    Int dest;
    dest = pointer + index;
    Copy(dest, source, count);
    return true;
}

Int NetworkPort_InternAddress(Int o)
{
    NetworkPort* m;
    m = CP(o);
    Int a;
    a = CastInt(m->InternAddress);
    return a;
}