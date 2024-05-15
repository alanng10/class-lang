#pragma once

#include <QImage>

#include "Probate.hpp"

struct Image
{
    Int Size;
    Int Data;
    Int VideoOut;
    QImage* Intern;
};

#define CP(a) ((Image*)(a))

Int Image_VideoOutSet(Int o);
Int Image_DataCopy(Int o, Int dest, Int source, Int width, Int height, Int rowByteCount);