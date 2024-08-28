#pragma once

#include <QHostAddress>

#include "NetworkHostIntern.hpp"

#include "Pronate.hpp"

struct NetworkHost
{
    Int Port;
    Int NewPeerState;
    NetworkHostIntern* Intern;
};

#define CP(a) ((NetworkHost*)(a))
