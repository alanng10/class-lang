#pragma once





#include <QSemaphore>




#include "Probate.hpp"





struct Semaphore
{
    Int InitCount;


    QSemaphore* Intern;
};






#define CP(a) ((Semaphore*)(a))