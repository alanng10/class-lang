#pragma once





#include "NetworkServerIntern.hpp"
#include <QHostAddress>




#include "Probate.hpp"





struct NetworkServer
{
    Int Address;


    Int Port;



    Int NewPeerState;



    NetworkServerIntern* Intern;
};






#define CP(a) ((NetworkServer*)(a))

