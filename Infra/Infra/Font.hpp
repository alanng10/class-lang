#pragma once

#include <QString>
#include <QLatin1String>
#include <QFont>

#include "Pronate.hpp"

struct Font
{
    Int Name;
    Int Size;
    Int Strong;
    Int Tenden;
    Int Staline;
    Int Midline;
    Int Endline;
    QFont* Intern;
};

#define CP(a) ((Font*)(a))
