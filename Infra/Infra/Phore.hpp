#pragma once

#include <QSemaphore>

#include "Pronate.hpp"

struct Phore
{
    Int InitCount;
    QSemaphore* Intern;
};

#define CP(a) ((Phore*)(a))
