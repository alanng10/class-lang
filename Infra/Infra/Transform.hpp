#pragma once

#include <QTransform>

#include "TransformIntern.hpp"

#include "Probate.hpp"

struct Transform
{
    QTransform* Intern;
};

#define CP(a) ((Transform*)(a))
