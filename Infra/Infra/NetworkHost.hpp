#pragma once

#include <QHostAddress>

#include "NetworkServerIntern.hpp"

#include "Probate.hpp"

struct NetworkServer
{
    Int Port;
    Int NewPeerState;
    NetworkServerIntern* Intern;
};

#define CP(a) ((NetworkServer*)(a))
