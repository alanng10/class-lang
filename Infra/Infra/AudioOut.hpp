#pragma once




#include <QAudioOutput>



#include "Probate.hpp"





struct AudioOut
{
    Int Muted;


    Int Volume;




    QAudioOutput* Intern;
};






#define CP(a) ((AudioOut*)(a))