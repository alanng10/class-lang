#pragma once

#include "Prusate.h"

Intern_Api Int Intern_Intern_Memory(Eval* eval, Int frame);
Intern_Api Int Intern_Intern_StringNew(Eval* eval, Int frame);
Intern_Api Int Intern_Intern_StringValueGet(Eval* eval, Int frame);
Intern_Api Int Intern_Intern_StringValueSet(Eval* eval, Int frame);
Intern_Api Int Intern_Intern_StringCountGet(Eval* eval, Int frame);
Intern_Api Int Intern_Intern_StringCountSet(Eval* eval, Int frame);
Intern_Api Int Intern_Intern_DataNew(Eval* eval, Int frame);
Intern_Api Int Intern_Intern_DataGet(Eval* eval, Int frame);
Intern_Api Int Intern_Intern_DataSet(Eval* eval, Int frame);
Intern_Api Int Intern_Intern_ArrayNew(Eval* eval, Int frame);
Intern_Api Int Intern_Intern_ArrayGet(Eval* eval, Int frame);
Intern_Api Int Intern_Intern_ArraySet(Eval* eval, Int frame);
Intern_Api Int Intern_Intern_RefLess(Eval* eval, Int frame);
Intern_Api Int Intern_Intern_ThisThread(Eval* eval, Int frame);
Intern_Api Int Intern_Intern_MainThreadSet(Eval* eval, Int frame);
Intern_Api Int Intern_Intern_InitThread(Eval* eval, Int frame);
Intern_Api Int Intern_Intern_FinalThread(Eval* eval, Int frame);
Intern_Api Int Intern_Intern_ArgCount(Eval* eval, Int frame);
Intern_Api Int Intern_Intern_Arg(Eval* eval, Int frame);
Intern_Api Int Intern_Intern_StateThreadExecute(Eval* eval, Int frame);
Intern_Api Int Intern_Intern_StateTimeEventElapse(Eval* eval, Int frame);
Intern_Api Int Intern_Intern_StateNetworkStatusEvent(Eval* eval, Int frame);
Intern_Api Int Intern_Intern_StateNetworkCaseEvent(Eval* eval, Int frame);
Intern_Api Int Intern_Intern_StateNetworkDataEvent(Eval* eval, Int frame);
Intern_Api Int Intern_Intern_StateNetworkHostNewPeer(Eval* eval, Int frame);
Intern_Api Int Intern_Intern_StateFrameTypeEvent(Eval* eval, Int frame);
Intern_Api Int Intern_Intern_StateFrameDrawEvent(Eval* eval, Int frame);
Intern_Api Int Intern_Intern_StateVideoOutFrameEvent(Eval* eval, Int frame);
