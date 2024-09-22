#include "PolateLinear.hpp"

CppClassNew(PolateLinear)

Int PolateLinear_Init(Int o)
{
    PolateLinear* m;
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

Int PolateLinear_Final(Int o)
{
    PolateLinear* m;
    m = CP(o);

    delete m->Intern;
    return true;
}

CppField(PolateLinear, StartPos)
CppField(PolateLinear, EndPos)

Int PolateLinear_Intern(Int o)
{
    PolateLinear* m;
    m = CP(o);
    Int a;
    a = CastInt(m->Intern);
    return a;
}