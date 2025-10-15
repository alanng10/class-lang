#pragma once

#include "Prusate.h"

#define RefMaskMemory (0x000fffffffffffff)

#define RefMaskBase (0x0ff0000000000000)
#define RefMaskBaseClear (0xf00fffffffffffff)

#define RefKindMaskAny (RefKindAny << 60)

#define BoolFalse 0x2000000000000000

#define BoolTrue 0x2000000000000001

#define VarSetDeref(dest, var, pos) (dest = *(((Int*)var) + pos));

#define MaskClear(name, mask) (name = name & mask);

#define MaskSet(name, mask) (name = name | mask);

#define RefKindClear(name) name = name & 0x0fffffffffffffff;

#define RefKindSet(name, kind) name = name | (kind << 60);

#define ThreadCountMax (1024)

typedef struct
{
    Int Index;
    Int Thread;
    Int ThreadAny;
    Int Eval;
    Int Flag;
}
ThreadData;


extern Int ModuleArray;

extern Int ModuleArrayCount;

extern Int ThreadArray;

extern Int ArgArray;

extern Int ArgCount;

Int Intern_New_Open();

Int Intern_New_Close();

Int Intern_New_PhoreSet(Int value);

Int Intern_New_AllocCapSet(Int value);

Int Intern_InitThread(Int thread, Int threadAny);

Int Intern_FinalThread(Int thread);

Int Intern_InitMainThread();

Int Intern_Call(Eval* eval, Int thisEvalIndex, Int stateKind, Int stateIndex);

Int Intern_State_Thread_Execute(Int thread, Int arg);

Int Intern_State_TimeEvent_Elapse(Int timeEvent, Int arg);

Int Intern_State_Network_StatusEvent(Int network, Int arg);

Int Intern_State_Network_CaseEvent(Int network, Int arg);

Int Intern_State_Network_DataEvent(Int network, Int arg);

Int Intern_State_NetworkHost_NewPeer(Int networkHost, Int arg);

Int Intern_State_Frame_TypeEvent(Int frame, Int arg, Int index, Int value);

Int Intern_State_Frame_DrawEvent(Int frame, Int arg);

Int Intern_State_VideoOut_FrameEvent(Int videoOut, Int arg);
