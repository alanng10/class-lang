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
    Int Face;
    Int Form;
    Int Comp;
    Int FillPos;
    Int Area;
    Int OutAlpha;
    Int TextData;
    QPainter* Intern;
    QFont* InternDefaultFace;
    QString* InternText;
    QTransform* InternIdentityForm;
};

#define CP(a) ((Draw*)(a))

#define TextCountMax 4096

Int Draw_TextSet(Int o, Int textData, Int textCount);
Int Draw_QStringSetRaw(Int result, Int data, Int count);
