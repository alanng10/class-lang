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
    QPainter* Intern;
    QFont* InternDefaultFace;
    QString* InternText;
    QTransform* InternIdentityForm;
};

#define CP(a) ((Draw*)(a))
