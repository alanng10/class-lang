#pragma once

#include <QHostAddress>

#include "Probate.hpp"

struct NetworkAddress
{
    Int Kind;
    Int ValueA;
    Int ValueB;
    Int ValueC;
    QHostAddress* Intern;
};

#define CP(a) ((NetworkAddress*)(a))

Int NetworkAddress_ValueSet(Int o, Int pointer, Int index, Int value, Int count);
