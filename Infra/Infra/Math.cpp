#include "Math.hpp"

CppClassNew(Math)

Int Math_Init(Int o)
{
    return true;
}

Int Math_Final(Int o)
{
    return true;
}

Int Math_GetInternValue(Int o, Int value)
{
    Int aa;
    Int ab;
    aa = 0;
    ab = 0;
    Int uoa;
    Int uob;
    uoa = CastInt(&aa);
    uob = CastInt(&ab);

    Math_Comp(o, value, uoa, uob);

    SInt oaa;
    SInt oab;
    oaa = aa;
    oab = ab;

    double uaa;
    uaa = oaa;
    int uab;
    uab = oab;

    double ou;
    ou = std::ldexp(uaa, uab);

    ValidDouble(ou);

    Int a;
    a = CastDoubleToInt(ou);
    return a;
}

Int Math_GetValueFromInternValue(Int o, Int u)
{
    double ou;
    ou = CastIntToDouble(u);

    int exp;
    exp = 0;

    double uu;
    uu = std::frexp(ou, &exp);

    ValidDouble(uu);

    double uua;
    uua = std::ldexp(uu, 49);

    ValidDouble(uua);

    int expa;
    expa = exp - 49;

    SInt aa;
    aa = uua;

    SInt ab;
    ab = expa;

    Int oa;
    Int ob;
    oa = aa;
    ob = ab;

    Int a;
    a = Math_GetValueFromComp(o, oa, ob);
    return a;
}

Int Math_GetValueFromComp(Int o, Int cand, Int exponent)
{
    SInt aa;
    aa = cand;
    aa = aa << 4;
    aa = aa >> 4;

    SInt ab;
    ab = exponent;
    ab = ab << 4;
    ab = ab >> 4;

    Int ka;
    ka = 1;
    ka = ka << 50;
    Int kaa;
    kaa = ka - 1;

    Int kb;
    kb = 1;
    kb = kb << 10;
    Int kab;
    kab = kb - 1;

    Int ku;
    ku = ab;
    ku = ku & kab;
    ku = ku << 50;

    Int k;
    k = aa;
    k = k & kaa;
    k = k | ku;
    return k;
}

Int Math_Comp(Int o, Int value, Int cand, Int exponent)
{
    SInt aa;
    aa = value;
    aa = aa << 14;
    aa = aa >> 14;

    SInt ab;
    ab = value;
    ab = ab << 4;
    ab = ab >> 54;

    Int oa;
    Int ob;
    oa = aa;
    ob = ab;

    Int* ua;
    ua = (Int*)cand;
    Int* ub;
    ub = (Int*)exponent;

    *ua = oa;
    *ub = ob;
    return true;
}

Int Math_Value(Int o, Int cand, Int exponent)
{
    SInt aa;
    aa = cand;
    aa = aa << 4;
    aa = aa >> 4;
    SInt ab;
    ab = exponent;
    ab = ab << 4;
    ab = ab >> 4;

    double uaa;
    uaa = aa;

    ValidDouble(uaa);
    
    int uab;
    uab = ab;

    double oo;
    oo = std::ldexp(uaa, uab);

    ValidDouble(oo);

    End
}


Int Math_ValueTen(Int o, Int cand, Int exponentTen)
{
    SInt aa;
    aa = cand;
    aa = aa << 4;
    aa = aa >> 4;
    SInt ab;
    ab = exponentTen;
    ab = ab << 4;
    ab = ab >> 4;

    double u;
    u = aa;

    double au;
    au = ab;

    ValidDouble(u);

    ValidDouble(au);

    double uua;
    uua = 10;

    double uu;
    uu = std::pow(uua, au);

    ValidDouble(uu);

    u = u * uu;

    double oo;
    oo = u;

    ValidDouble(oo);

    End
}

Int Math_Less(Int o, Int valueA, Int valueB)
{
    ValidValue(valueA);
    ValidValue(valueB);
    Start(valueA, ua);
    Start(valueB, ub);
    
    bool b;
    b = ua < ub;

    Int a;
    a = b;
    return a;
}