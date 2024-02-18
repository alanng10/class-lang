#pragma once





#include <QFileDialog>




#include "Probate.hpp"




struct DialogFile
{
    Int Save;


    Int FileMode;


    Int Fold;



    QFileDialog* Intern;
};





#define CP(a) ((DialogFile*)(a))

