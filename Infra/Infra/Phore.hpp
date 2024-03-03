#pragma once

#include <QSemaphore>

#include "Probate.hpp"

struct Phore
{
    Int InitCount;
    QSemaphore* Intern;
};

#define CP(a) ((Phore*)(a))
