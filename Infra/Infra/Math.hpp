#pragma once

#include <cmath>

#include "Probate.hpp"

struct Math
{
};

#define CP(a) ((Math*)(a))

#define ValidValue(a) \
if (a == CastInt(-1))\
{\
    return a;\
}\


#define ValidDouble(a) \
if (std::isnan(a))\
{\
    return CastInt(-1);\
}\


#define Start \
    Int ua;\
    ua = Math_GetInternValue(o, value);\
    ValidValue(ua);\
    double u;\
    u = CastIntToDouble(ua);\


#define End \
    Int ub;\
    ub = CastDoubleToInt(oo);\
    Int a;\
    a = Math_GetValueFromInternValue(o, ub);\
    return a;\


#define MathMaide(name, f) \
Int Math_##name(Int o, Int value)\
{\
    Start\
    double oo;\
    oo = std::f(u);\
    ValidDouble(oo);\
    End\
}\


Int Math_GetValueFromCompose(Int o, Int significand, Int exponent);
