#pragma once





#include <QImageReader>





#include "Probate.hpp"





struct ImageRead
{
    Int Stream;


    Int Image;



    QImageReader* Intern;
};






#define CP(a) ((ImageRead*)(a))
