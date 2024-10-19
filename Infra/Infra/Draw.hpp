#pragma once

#include <QPainter>
#include <QPaintDevice>
#include <QBrush>
#include <QPen>
#include <QFont>
#include <QString>
#include <QTransform>
#include <QApplication>

#include "Pronate.hpp"

struct Draw
{
    Int Size;
    Int Out;
    Int Fill;
    Int Line;
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

#define TextCountMax 1024

Int Draw_TextSet(Int o, Int textData, Int textCount);
Int Draw_QStringSetRaw(Int result, Int data, Int count);
