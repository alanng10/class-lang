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

#define QueueNode \
{\
        Int refKind;\
        refKind = ka >> 60;\
\
        if (refKind == 1 | refKind == 4 | refKind == 6 | refKind == 7)\
        {\
            Int puu;\
            puu = ka & RefMaskMemoryClear;\
\
            puu = puu - 3 * Constant_IntByteCount();\
\
            Int node;\
            node = puu;\
\
            Int flagE;\
            flagE = NodeFieldFlag(node);\
\
            if ((flagE & 0x10000) == 0)\
            {\
                flagE = flagE | 0x10000;\
\
                NodeFieldFlag(node) = flagE;\
\
                if (!(m->QueueLastNode == null))\
                {\
                    NodeFieldPrevious(node) = m->QueueLastNode;\
\
                    NodeFieldNext(m->QueueLastNode) = node;\
                }\
\
                if (m->QueueFirstNode == null)\
                {\
                    m->QueueFirstNode = node;\
                }\
\
                m->QueueLastNode = node;\
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
