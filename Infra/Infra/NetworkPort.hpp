#pragma once

#include <QHostAddress>

#include "Probate.hpp"

struct NetworkPort
{
    Int Kind;
    Int ValueA;
    Int ValueB;
    Int ValueC;
    Int Server;
    QHostAddress* InternAddress;
};

#define CP(a) ((NetworkPort*)(a))

Int NetworkPort_ValueSet(Int o, Int pointer, Int index, Int value, Int count);
