#pragma once

#include <QString>
#include <QLatin1String>
#include <QFont>

#include "Pronate.hpp"

struct Font
{
    Int Name;
    Int Size;
    Int Weight;
    Int Italic;
    Int Underline;
    Int Overline;
    Int Strikeout;
    QFont* Intern;
};

#define CP(a) ((Font*)(a))
