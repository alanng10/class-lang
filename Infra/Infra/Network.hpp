#pragma once

#include <QString>

#include "NetworkHandle.hpp"

#include "Probate.hpp"

struct Network
{
    Int HostName;
    Int ServerPort;
    Int Stream;
    Int StatusChangeState;
    Int CaseChangeState;
    Int ReadyReadState;
    NetworkHandle* Handle;
    Int OpenSocket;
};

#define CP(a) ((Network*)(a))
