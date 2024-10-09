#pragma once

#include "Pronate.h"

struct InternNewNode_T;

typedef struct InternNewNode_T
{
    struct InternNewNode_T* Next;
    struct InternNewNode_T* Previous;
    Int Flag;
}
InternNewNode;

typedef struct
{
    Int TotalAllocCount;
    Int Phore;
    InternNewNode* FirstNode;
    InternNewNode* LastNode;
}
InternNewData;
