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

#define NodeFieldQueueNext(n) NodeField(n, 1)

#define NodeFieldSize(n) NodeField(n, 2)

#define NodeFieldFlag(n) NodeField(n, 3)

#define NodeFieldCount (4)

#define QueueFlag (0x10000)

#define QueueNodeVar \
Int refKindU;\
refKindU = 0;\
Int puu;\
puu = 0;\
Int nodeU;\
nodeU = 0;\
Int flagU;\
flagU = 0;\
\


#define QueueNode \
{\
        refKindU = ka >> 60;\
\
        if ((refKindU == RefKindAny) | (refKindU == RefKindString) | (refKindU == RefKindData) | (refKindU == RefKindArray))\
        {\
            puu = ka & RefMaskMemory;\
\
            puu = puu - NodeFieldCount * Constant_IntByteCount();\
\
            nodeU = puu;\
\
            flagU = NodeFieldFlag(nodeU);\
\
            if ((flagU & QueueFlag) == 0)\
            {\
                flagU = flagU | QueueFlag;\
\
                NodeFieldFlag(nodeU) = flagU;\
\
                if (!(m->QueueLastNode == null))\
                {\
                    NodeFieldQueueNext(m->QueueLastNode) = nodeU;\
                }\
\
                if (m->QueueFirstNode == null)\
                {\
                    m->QueueFirstNode = nodeU;\
                }\
\
                m->QueueLastNode = nodeU;\
            }\
        }\
}\

Bool Intern_New_AutoDelete();

Int Intern_New_DeleteUnused();

Bool Intern_New_PauseOtherThread(Int thisThreadIdent);

Bool Intern_New_ResumeOtherThread(Int thisThreadIdent);

Bool Intern_New_QueueAllRoot();

Bool Intern_New_QueueAllThreadEvalStack();

Bool Intern_New_QueueEvalStack(Eval* eval);

Bool Intern_New_QueueClassShare();

Bool Intern_New_QueueClassShareModule(Int module);

Bool Intern_New_QueueAllThreadAny();

Bool Intern_New_Traverse();
