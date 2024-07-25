#pragma once

#include <QLinearGradient>

#include "Probate.hpp"

struct GradientLinear
{
    Int StartPos;
    Int EndPos;
    QLinearGradient* Intern;
};

#define CP(a) ((GradientLinear*)(a))


#define PosValue(prefix) \
Int prefix##Left;\
prefix##Left = Pos_LeftGet(prefix##Pos);\
Int prefix##Up;\
prefix##Up = Pos_UpGet(prefix##Pos);\


#define InternValue(a) \
Int a##_u;\
a##_u = Math_GetInternValue(0, a);\
qreal a##U;\
a##U = CastIntToDouble(a##_u);\


#define InternPosValue(prefix) \
InternValue(prefix##Left);\
InternValue(prefix##Up);\


#define InternPos(prefix) QPointF prefix##PosU(prefix##LeftU, prefix##UpU);
