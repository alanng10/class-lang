#pragma once




#include <QLibrary>




#include "Probate.hpp"




struct Library
{
    Int File;



    QLibrary* Intern;
};





#define CP(a) ((Library*)(a))
