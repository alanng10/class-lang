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
    Int Brush;
    Int Pen;
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

