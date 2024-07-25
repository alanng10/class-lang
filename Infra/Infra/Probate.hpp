#pragma once

extern "C"
{
#include "Probate.h"
}

#define CppClassNew(varClass) \
Int varClass##_New()\
{\
    Int o;\
    o = CastInt(new varClass());\
    return o;\
}\
Int varClass##_Delete(Int o)\
{\
    varClass* k;\
    k = (varClass*)(o);\
    delete k;\
    return true;\
}\


#define CastDoubleToInt(a)   (*((Int*)&a))
#define CastIntToDouble(a)   (*((double*)&a))

#define CastInt32ToFloat(a)   (*((float*)&a))

#define InternQReal(a) \
    SInt a##_u;\
    a##_u = a;\
    a##_u = a##_u << 4;\
    a##_u = a##_u >> 4;\
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


#define PosValue(prefix) \
Int prefix##Left;\
prefix##Left = Pos_LeftGet(prefix##Pos);\
Int prefix##Up;\
prefix##Up = Pos_UpGet(prefix##Pos);\


#define SizeValue(prefix) \
Int prefix##Width;\
prefix##Width = Size_WidthGet(prefix##Size);\
Int prefix##Height;\
prefix##Height = Size_HeightGet(prefix##Size);\


#define RectValue(prefix) \
Int prefix##Pos;\
prefix##Pos = Rect_PosGet(prefix##Rect);\
Int prefix##Size;\
prefix##Size = Rect_SizeGet(prefix##Rect);\
PosValue(prefix);\
SizeValue(prefix);\


#define InternValue(a) \
Int a##_u;\
a##_u = Math_GetInternValue(0, a);\
qreal a##U;\
a##U = CastIntToDouble(a##_u);\


#define InternPosValue(prefix) \
InternValue(prefix##Left);\
InternValue(prefix##Up);\


#define InternSizeValue(prefix) \
InternValue(prefix##Width);\
InternValue(prefix##Height);\


#define InternRectValue(prefix) \
InternPosValue(prefix);\
InternSizeValue(prefix);\


#define InternPos(prefix) QPointF prefix##PosU(prefix##LeftU, prefix##UpU);

#define InternRect(prefix) QRectF prefix##RectU(prefix##LeftU, prefix##UpU, prefix##WidthU, prefix##HeightU);

#define ValueFromInternValue(a) \
Int a##_u;\
a##_u = CastDoubleToInt(a);\
Int a##A;\
a##A = Math_GetValueFromInternValue(0, a##_u);\

