#include "GradientLinear.hpp"

CppClassNew(GradientLinear)

Int GradientLinear_Init(Int o)
{
    GradientLinear* m;
    m = CP(o);

    Int startPos;
    startPos = m->StartPos;
    Int endPos;
    endPos = m->EndPos;

    PosValue(start);
    PosValue(end);

    InternPosValue(start);
    InternPosValue(end);

    InternPos(start);
    InternPos(end);

    QLinearGradient* linearGradient;
    linearGradient = new QLinearGradient(startPosU, endPosU);
    m->Intern = linearGradient;
    return true;
}

Int GradientLinear_Final(Int o)
{
    GradientLinear* m;
    m = CP(o);

    delete m->Intern;
    return true;
}

CppField(GradientLinear, StartPos)
CppField(GradientLinear, EndPos)

Int GradientLinear_Intern(Int o)
{
    GradientLinear* m;
    m = CP(o);
    Int a;
    a = CastInt(m->Intern);
    return a;
}