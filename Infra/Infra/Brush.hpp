#pragma once

#include <QBrush>
#include <QGradient>

#include "Pronate.hpp"

struct Brush
{
    Int Kind;
    Int Color;
    Int Polate;
    Int Image;
    QBrush* Intern;
};

#define CP(a) ((Brush*)(a))
