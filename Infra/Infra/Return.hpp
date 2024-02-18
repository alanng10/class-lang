#pragma once



#include <QString>
#include <QStringList>


#include "Probate.hpp"




struct Return
{
    QString* String;


    QStringList* StringList;
};




#define CP(a) ((Return*)(a))
