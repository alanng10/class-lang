#pragma once

#include "Pronate.h"

typedef struct
{
    Int AllocCap;
    Int TotalAllocCount;
    Int Phore;
    Int FirstNode;
    Int LastNode;
    Int QueueFirstNode;
    Int QueueLastNode;
}
InternNewData;

#define NodeField(n, index) (((Int*)(n))[index])

#define NodeFieldNext(n) NodeField(n, 0)

#define NodeFieldPrevious(n) NodeField(n, 1)

#define NodeFieldFlag(n) NodeField(n, 2)