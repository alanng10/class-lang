#pragma once

#include "Pronate.h"

#define StateCall \
    Int thread;\
    thread = Thread_This();\
\
    Int index;\
    index = Thread_IdentGet(thread);\
\
    Int* array;\
    array = CastPointer(ThreadArray);\
\
    Int kk;\
    kk = array[index];\
\
    ThreadData* threadData;\
    threadData = CastPointer(kk);\
\
    Int pa;\
    pa = threadData->Eval;\
\
    Eval* eval;\
    eval = CastPointer(pa);\
\
    Int ka;\
    ka = arg;\
    RefKindSet(ka, RefKindAny);\


Int Intern_State_Call(Int o, Int arg, Int stateIndex);
