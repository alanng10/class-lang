#include "Polate.hpp"

CppClassNew(Polate)

Int Polate_Init(Int o)
{
    Polate* m;
    m = CP(o);

    Int kind;
    kind = m->Kind;
    Int value;
    value = m->Value;
    Int stop;
    stop = m->Stop;
    Int spread;
    spread = m->Spread;

    Int share;
    share = Infra_Share();
    Int stat;
    stat = Share_Stat(share);

    QGradient* u;
    u = null;

    Int uo;
    uo = 0;
    if (kind == Stat_GradientKindLinear(stat))
    {
        uo = GradientLinear_Intern(value);

        QLinearGradient* ua;
        ua = (QLinearGradient*)uo;

        u = ua;
    }
    if (kind == Stat_GradientKindRadial(stat))
    {
        uo = GradientRadial_Intern(value);

        QRadialGradient* ua;
        ua = (QRadialGradient*)uo;

        u = ua;
    }

    Int uaa;
    uaa = GradientStop_Intern(stop);

    QGradientStops* stopU;
    stopU = (QGradientStops*)uaa;

    QGradient::Spread spreadU;
    spreadU = (QGradient::Spread)(spread - 1);

    u->setStops(*stopU);

    u->setSpread(spreadU);

    m->Intern = u;
    return true;
}

Int Polate_Final(Int o)
{
    return true;
}

CppField(Polate, Kind)
CppField(Polate, Value)
CppField(Polate, Stop)
CppField(Polate, Spread)

Int Polate_Intern(Int o)
{
    Polate* m;
    m = CP(o);
    Int a;
    a = CastInt(m->Intern);
    return a;
}