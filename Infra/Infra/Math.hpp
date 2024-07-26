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
if (std::isnan(a) | std::isinf(a))\
{\
    return CastInt(-1);\
}\


#define Start(value, aa) \
    Int aa##_u;\
    aa##_u = Math_GetInternValue(o, value);\
    ValidValue(aa##_u);\
    double aa;\
    aa = CastIntToDouble(aa##_u);\


#define End \
    Int a_u;\
    a_u = CastDoubleToInt(oo);\
    Int a;\
    a = Math_GetValueFromInternValue(o, a_u);\
    return a;\


#define MathMaide(name, f) \
Int Math_##name(Int o, Int value)\
{\
    Start(value, ua);\
    double oo;\
    oo = f(ua);\
    ValidDouble(oo);\
    End;\
}\


#define MathMaideTwo(name, f) \
Int Math_##name(Int o, Int valueA, Int valueB)\
{\
    Start(valueA, ua);\
    Start(valueB, ub);\
    double oo;\
    oo = f(ua, ub);\
    ValidDouble(oo);\
    End;\
}\


Int Math_GetValueFromCompose(Int o, Int significand, Int exponent);
