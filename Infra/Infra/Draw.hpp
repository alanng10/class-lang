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

#define RectValue(prefix) \
Int prefix##Pos;\
prefix##Pos = Rect_PosGet(prefix##Rect);\
Int prefix##Left;\
prefix##Left = Pos_LeftGet(prefix##Pos);\
Int prefix##Up;\
prefix##Up = Pos_UpGet(prefix##Pos);\
Int prefix##Size;\
prefix##Size = Rect_SizeGet(prefix##Rect);\
Int prefix##Width;\
prefix##Width = Size_WidthGet(prefix##Size);\
Int prefix##Height;\
prefix##Height = Size_HeightGet(prefix##Size);\


#define InternRectValue(prefix) \
    Int prefix##_u_l;\
    Int prefix##_u_u;\
    Int prefix##_u_w;\
    Int prefix##_u_h;\
    prefix##_u_l = InternValueGet(prefix##Left);\
    prefix##_u_u = InternValueGet(prefix##Up);\
    prefix##_u_w = InternValueGet(prefix##Width);\
    prefix##_u_h = InternValueGet(prefix##Height);\
    qreal prefix##LeftU;\
    qreal prefix##UpU;\
    qreal prefix##WidthU;\
    qreal prefix##HeightU;\
    prefix##LeftU = CastIntToDouble(prefix##_u_l);\
    prefix##UpU = CastIntToDouble(prefix##_u_u);\
    prefix##WidthU = CastIntToDouble(prefix##_u_w);\
    prefix##HeightU = CastIntToDouble(prefix##_u_h);\

