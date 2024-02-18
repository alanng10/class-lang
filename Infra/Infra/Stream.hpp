#pragma once




#include <QIODevice>




#include "Probate.hpp"




struct Stream
{
    Int Kind;


    Int Value;


    Int Status;




    Int HasPos;


    Int HasCount;



    Int CanRead;


    Int CanWrite;



    QIODevice* Intern;
};





typedef Bool (*Stream_SetCount_Maide)(Int device, Int value);




typedef Bool (*Stream_Flush_Maide)(Int device);




typedef Int (*Stream_GetStatus_Maide)(Int device);






Bool Stream_CheckRange(Int dataCount, Int start, Int end);





Int Stream_InternGetStatus(Int o);




Int Stream_InternFlush(Int o);

