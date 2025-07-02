#pragma once

#include <QString>

#include "NetworkHandle.hpp"

#include "Pronate.hpp"

struct Network
{
    Int HostName;
    Int HostPort;
    Int Stream;
    Int StatusEventState;
    Int CaseEventState;
    Int DataEventState;
    NetworkHandle* Handle;
    Int Open;
    QTcpSocket* Intern;
};

#define CP(a) ((Network*)(a))
