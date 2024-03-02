#pragma once



extern "C"
{
#include "Probate.h"
}





#define CppClassNew(c) \
Int c##_New()\
{\
    Int o;\
\
    o = (Int)(new c());\
\
\
    return o;\
}\
\
\
\
Int c##_Delete(Int o)\
{\
    c* k;\
\
    k = (c*)(o);\
\
\
    delete k;\
\
\
    return true;\
}\







#define CastDoubleToInt(a)   (*((Int*)&a))



#define CastIntToDouble(a)   (*((double*)&a))




#define CastInt32ToFloat(a)   (*((float*)&a))





#define InternQReal(a) \
    SInt a##_u;\
    a##_u = a;\
\
    a##_u = a##_u << 4;\
\
    a##_u = a##_u >> 4;\
\
    qreal a##U;\
    a##U = a##_u;\


#define CppFieldGet(varClass, name) \
Int varClass##_##name##Get(Int o)\
{\
    varClass* m;\
    m = (varClass*)o;\
    return m->name;\
}\


#define CppFieldSet(varClass, name) \
Int varClass##_##name##Set(Int o, Int value)\
{\
    varClass* m;\
    m = (varClass*)o;\
    m->name = value;\
    return true;\
}\


#define CppField(varClass, name) \
CppFieldGet(varClass, name)\
CppFieldSet(varClass, name)
