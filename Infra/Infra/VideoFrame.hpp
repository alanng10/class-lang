#pragma once




#include <QVideoFrame>




#include "Probate.hpp"





struct VideoFrame
{
    Int Size;



    QVideoFrame* Intern;
};






#define CP(a) ((VideoFrame*)(a))

