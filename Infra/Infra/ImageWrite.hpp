#pragma once

#include <QImageWriter>
#include <QImage>
#include <QIODevice>

#include "Pronate.hpp"

struct ImageWrite
{
    Int Stream;
    Int Format;
    Int Image;
    Int Quality;
    QImageWriter* Intern;
};

#define CP(a) ((ImageWrite*)(a))
