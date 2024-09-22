#include "PolateRadial.hpp"

CppClassNew(PolateRadial)

Int PolateRadial_Init(Int o)
{
    PolateRadial* m;
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

Int PolateRadial_Final(Int o)
{
    PolateRadial* m;
    m = CP(o);

    delete m->Intern;
    return true;
}

CppField(PolateRadial, CenterPos)
CppField(PolateRadial, CenterRadius)
CppField(PolateRadial, FocusPos)
CppField(PolateRadial, FocusRadius)

Int PolateRadial_Intern(Int o)
{
    PolateRadial* m;
    m = CP(o);
    Int a;
    a = CastInt(m->Intern);
    return a;
}