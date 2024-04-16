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

    Int centerLeft;
    Int centerUp;
    centerLeft = Pos_LeftGet(centerPos);
    centerUp = Pos_UpGet(centerPos);
    Int focusLeft;
    Int focusUp;
    focusLeft = Pos_LeftGet(focusPos);
    focusUp = Pos_UpGet(focusPos);

    InternQReal(centerLeft)
    InternQReal(centerUp)
    InternQReal(focusLeft)
    InternQReal(focusUp)
    InternQReal(centerRadius)
    InternQReal(focusRadius)

    QRadialGradient* radialGradient;
    radialGradient = new QRadialGradient(centerLeftU, centerUpU, centerRadiusU, focusLeftU, focusUpU, focusRadiusU);
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