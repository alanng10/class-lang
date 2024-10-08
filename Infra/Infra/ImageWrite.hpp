#pragma once

#include <QImageWriter>
#include <QImage>
#include <QIODevice>

#include "Pronate.hpp"

struct ImageWrite
{
    Int Stream;
    Int Binary;
    Int Image;
    Int Quality;
    QImageWriter* Intern;
};

#define CP(a) ((ImageWrite*)(a))
