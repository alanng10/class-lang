#pragma once

extern "C"
{
#include "Pronate.h"
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
Int prefix##Col;\
prefix##Col = Pos_ColGet(prefix##Pos);\
Int prefix##Row;\
prefix##Row = Pos_RowGet(prefix##Pos);\


#define SizeValue(prefix) \
Int prefix##Wed;\
prefix##Wed = Size_WedGet(prefix##Size);\
Int prefix##Het;\
prefix##Het = Size_HetGet(prefix##Size);\


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
InternValue(prefix##Col);\
InternValue(prefix##Row);\


#define InternSizeValue(prefix) \
InternValue(prefix##Wed);\
InternValue(prefix##Het);\


#define InternRectValue(prefix) \
InternPosValue(prefix);\
InternSizeValue(prefix);\


#define InternPos(prefix) QPointF prefix##PosU(prefix##ColU, prefix##RowU);

#define InternRect(prefix) QRectF prefix##RectU(prefix##ColU, prefix##RowU, prefix##WedU, prefix##HetU);

#define ValueFromInternValue(a) \
Int a##_u;\
a##_u = CastDoubleToInt(a);\
Int a##A;\
a##A = Math_GetValueFromInternValue(0, a##_u);\


#define InternColor(a) \
Int32 a##_u;\
a##_u = (Int32)a;\
QRgb a##_k;\
a##_k = a##_u;\
QColor a##U;\
a##U = QColor::fromRgba(a##_k);\

