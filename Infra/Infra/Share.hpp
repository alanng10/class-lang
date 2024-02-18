#pragma once





#include <QThreadStorage>





#include "Probate.hpp"





struct Share
{
    Int Stat;


    Int ThreadStorage;
};






#define CP(a) ((Share*)(a))
