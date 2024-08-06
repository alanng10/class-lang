#pragma once

#include <QTransform>

#include "Probate.hpp"

struct Form
{
    QTransform* Intern;
};

#define CP(a) ((Form*)(a))
