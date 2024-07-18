#include "Gradient.hpp"

CppClassNew(Gradient)

Int Gradient_Init(Int o)
{
    Gradient* m;
    m = CP(o);

    Int kind;
    kind = m->Kind;
    Int value;
    value = m->Value;
    Int stop;
    stop = m->Stop;
    Int spread;
    spread = m->Spread;

    if ((kind == null) | (spread == null))
    {
        return true;
    }

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

Int Gradient_Final(Int o)
{
    return true;
}

CppField(Gradient, Kind)
CppField(Gradient, Value)
CppField(Gradient, Stop)
CppField(Gradient, Spread)

Int Gradient_Intern(Int o)
{
    Gradient* m;
    m = CP(o);
    Int a;
    a = CastInt(m->Intern);
    return a;
}