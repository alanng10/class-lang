#pragma once

#include "Pronate.h"

typedef struct
{
    Int AllocCap;
    Int TotalAllocCount;
    Int Phore;
    Int ThisThreadIdent;
    Int FirstNode;
    Int LastNode;
    Int QueueFirstNode;
    Int QueueLastNode;
    Int Thread[1024 * 2];
}
InternNewData;

#define NodeField(n, index) (((Int*)(n))[index])

#define NodeFieldNext(n) NodeField(n, 0)

#define NodeFieldPrevious(n) NodeField(n, 1)

#define NodeFieldFlag(n) NodeField(n, 2)

Bool Intern_New_PauseOtherThread();

Bool Intern_New_QueueAllRoot();

Bool Intern_New_QueueEvalStack(Eval* eval);

Bool Intern_New_QueueClassShare();

Bool Intern_New_QueueClassShareModule(Module* module);

