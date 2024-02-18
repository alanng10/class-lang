#pragma once




#include <QString>
#include <QLatin1String>
#include <QFont>




#include "Probate.hpp"





struct Font
{
    Int Family;


    Int Size;


    Int Weight;


    Bool Italic;


    Bool Underline;


    Bool Overline;


    Bool Strikeout;



    QFont* Intern;
};




#define CP(a) ((Font*)(a))



