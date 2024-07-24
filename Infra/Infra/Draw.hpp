#pragma once

#include <QPainter>
#include <QPaintDevice>
#include <QBrush>
#include <QPen>
#include <QFont>
#include <QString>
#include <QTransform>
#include <QApplication>

#include "Probate.hpp"

struct Draw
{
    Int Size;
    Int Out;
    Int Fill;
    Int Stroke;
    Int Font;
    Int Transform;
    Int Composite;
    Int FillPos;
    Int Area;
    Int OutAlpha;
    QPainter* Intern;
    QFont* InternDefaultFont;
    QString* InternText;
    QTransform* InternIdentityTransform;
};

#define CP(a) ((Draw*)(a))

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
a##_u = InternValueGet(a);\
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
a##A = ValueGetFromInternValue(a##_u);\

