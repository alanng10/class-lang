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





Int Image_SetVideoOut(Int o);



