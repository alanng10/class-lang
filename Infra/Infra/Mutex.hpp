#pragma once




#include <QMutex>




#include "Probate.hpp"





struct Mutex
{
    QMutex* Intern;
};





#define CP(a) ((Mutex*)(a))
