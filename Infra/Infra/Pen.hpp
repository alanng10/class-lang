#pragma once






#include <QPen>




#include "Probate.hpp"





struct Pen
{
    Int Kind;


    Int Width;


    Int Brush;


    Int Cap;


    Int Join;




    QPen* Intern;
};




#define CP(a) ((Pen*)(a))
