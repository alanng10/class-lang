#include "GradientRadial.hpp"

CppClassNew(GradientRadial)

Int GradientRadial_Init(Int o)
{
    GradientRadial* m;
    m = CP(o);
    Int centerPos;
    centerPos = m->CenterPos;
    Int centerRadius;
    centerRadius = m->CenterRadius;
    Int focusPos;
    focusPos = m->FocusPos;
    Int focusRadius;
    focusRadius = m->FocusRadius;

    PosValue(center);
    PosValue(focus);

    InternPosValue(center);
    InternPosValue(focus);

    InternPos(center);
    InternPos(focus);

    InternValue(centerRadius);
    InternValue(focusRadius);

    QRadialGradient* radialGradient;
    radialGradient = new QRadialGradient(centerPosU, centerRadiusU, focusPosU, focusRadiusU);
    m->Intern = radialGradient;
    return true;
}

Int GradientRadial_Final(Int o)
{
    GradientRadial* m;
    m = CP(o);

    delete m->Intern;
    return true;
}

CppField(GradientRadial, CenterPos)
CppField(GradientRadial, CenterRadius)
CppField(GradientRadial, FocusPos)
CppField(GradientRadial, FocusRadius)

Int GradientRadial_Intern(Int o)
{
    GradientRadial* m;
    m = CP(o);
    Int a;
    a = CastInt(m->Intern);
    return a;
}