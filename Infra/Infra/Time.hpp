#pragma once




#include <QDateTime>
#include <QDate>
#include <QTime>



#include "Probate.hpp"





struct Time
{
    QDateTime* Intern;
};






#define CP(a) ((Time*)(a))

