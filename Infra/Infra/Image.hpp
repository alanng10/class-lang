#pragma once

#include <QImage>

#include "Pronate.hpp"

struct Image
{
    Int Size;
    Int Data;
    Int Out;
    QImage* Intern;
};

#define CP(a) ((Image*)(a))

Int Image_OutSet(Int o);
Int Image_DataCopy(Int o, Int dest, Int source, Int width, Int height, Int rowByteCount);