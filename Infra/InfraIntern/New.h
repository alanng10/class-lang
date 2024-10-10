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

#define NodeFieldSize(n) NodeField(n, 2)

#define NodeFieldFlag(n) NodeField(n, 3)

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
        if (refKindU == 1 | refKindU == 4 | refKindU == 6 | refKindU == 7)\
        {\
            puu = ka & RefMaskMemoryClear;\
\
            puu = puu - 3 * Constant_IntByteCount();\
\
            nodeU = puu;\
\
            flagU = NodeFieldFlag(nodeU);\
\
            if ((flagU & 0x10000) == 0)\
            {\
                flagU = flagU | 0x10000;\
\
                NodeFieldFlag(nodeU) = flagU;\
\
                if (!(m->QueueLastNode == null))\
                {\
                    NodeFieldPrevious(nodeU) = m->QueueLastNode;\
\
                    NodeFieldNext(m->QueueLastNode) = nodeU;\
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



Bool Intern_New_PauseOtherThread();

Bool Intern_New_ResumeOtherThread();

Bool Intern_New_QueueAllRoot();

Bool Intern_New_QueueAllThreadEvalStack();

Bool Intern_New_QueueEvalStack(Eval* eval);

Bool Intern_New_QueueClassShare();

Bool Intern_New_QueueClassShareModule(Module* module);

Bool Intern_New_Traverse();
