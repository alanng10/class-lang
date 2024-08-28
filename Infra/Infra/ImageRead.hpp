#pragma once

#include <QImageReader>

#include "Pronate.hpp"

struct ImageRead
{
    Int Stream;
    Int Image;
    QImageReader* Intern;
};

#define CP(a) ((ImageRead*)(a))
