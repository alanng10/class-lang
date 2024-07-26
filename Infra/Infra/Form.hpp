#pragma once

#include <QTransform>

#include "FormIntern.hpp"

#include "Probate.hpp"

struct Form
{
    QTransform* Intern;
};

#define CP(a) ((Form*)(a))
