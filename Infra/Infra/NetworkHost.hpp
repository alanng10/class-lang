#pragma once

#include <QHostAddress>

#include "NetworkHostIntern.hpp"

#include "Probate.hpp"

struct NetworkServer
{
    Int Port;
    Int NewPeerState;
    NetworkServerIntern* Intern;
};

#define CP(a) ((NetworkServer*)(a))
