#pragma once

#include <QBrush>
#include <QPen>

#include "Pronate.hpp"

struct Slash
{
    Int Brush;
    Int Line;
    Int Width;
    Int Cap;
    Int Join;
    QPen* Intern;
};

#define CP(a) ((Slash*)(a))
