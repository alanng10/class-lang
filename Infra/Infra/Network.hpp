#pragma once




#include <QString>



#include "NetworkHandle.hpp"




#include "Probate.hpp"





struct Network
{
    Int HostName;


    Int Port;


    Int Stream;




    Int CaseChangedState;


    Int ErrorState;


    Int ReadyReadState;



    NetworkHandle* Handle;



    Int OpenSocket;
};






#define CP(a) ((Network*)(a))

