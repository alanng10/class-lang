#pragma once

#include <QHostAddress>

#include "Pronate.hpp"

struct NetworkPort
{
    Int Kind;
    Int ValueA;
    Int ValueB;
    Int ValueC;
    Int Host;
    QHostAddress* InternAddress;
};

#define CP(a) ((NetworkPort*)(a))

Int NetworkPort_ValueSet(Int o, Int pointer, Int index, Int value, Int count);
