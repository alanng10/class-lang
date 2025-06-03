#pragma once

#include "Prusate.h"

Int Main_ExecuteMain();
Int Main_Exit(Int status);

Int String_QStringSet(Int result, Int a);

Int Stream_FlushStorage(Int device);
Int Stream_FlushNetwork(Int device);
Int Stream_ValueGet(Int o);
Int Stream_ValueSet(Int o, Int value);
Int Stream_CanReadSet(Int o, Int value);
Int Stream_CanWriteSet(Int o, Int value);
Int Stream_Intern(Int o);

Int Network_GetOpenSocket(Int o);
Int Network_HostOpen(Int o, Int socket);
Int Network_HostClose(Int o);
Int Network_StatusEvent(Int o);
Int Network_CaseEvent(Int o);
Int Network_DataEvent(Int o);

Int NetworkHost_NewPeer(Int o);

Int NetworkPort_InternAddress(Int o);

Int Draw_Intern(Int o);

Int Brush_Intern(Int o);
Int Slash_Intern(Int o);

Int Image_Intern(Int o);
Int Image_SetReadIntern(Int o, Int value);

Int Font_Intern(Int o);

Int Form_Intern(Int o);

Int Polate_Intern(Int o);

Int PolateLinear_Intern(Int o);

Int PolateRadial_Intern(Int o);

Int PolateStop_Intern(Int o);

Int Frame_TypeEvent(Int o, Int index, Int field);
Int Frame_DrawEvent(Int o);

Int VideoOut_Intern(Int o);
Int VideoOut_FrameEvent(Int o);

Int VideoFrame_Intern(Int o);

Int AudioOut_Intern(Int o);

Int Math_GetInternValue(Int o, Int a);
Int Math_GetValueFromInternValue(Int o, Int a);

Int Thread_InitMainThread(Int o);
Int Thread_FinalMainThread(Int o);
Int Thread_ExecuteHandle(Int o);
Int Thread_OS_OpenHandle(Int threadId);
Int Thread_OS_CloseHandle(Int handle);
Int Thread_OS_Set();
Int Thread_OS_Pause(Int handle);
Int Thread_OS_Resume(Int handle);
Int Thread_CreateStore();
Int Thread_DeleteStore(Int a);

Int TimeEvent_Elapse(Int o);

Int Post_ExecuteHandle(Int o);

Int Program_Start(Int o);
Int Program_Finish(Int o);

Int Main_CurrentThreadSignalHandleSet();

Int Main_Screen();
Int Main_Compute();
Int Main_ThreadStorage(Int o);

Int Console_OS_Init();

Int Environ_OS_System(Int compute);

Int Main_OS_Arg(Int argc, Int argv);

Int Environ_HasFlag(Int value, Int flag);

Int Share_New();
Int Share_Delete(Int o);
Int Share_Init(Int o);
Int Share_Final(Int o);

Int Stat_New();
Int Stat_Delete(Int o);
Int Stat_Init(Int o);
Int Stat_Final(Int o);
Int Stat_TimeInit(Int o);
Int Stat_ConsolePhore(Int o);
Int Stat_ScreenSize(Int o);
Int Stat_ScreenDimend(Int o);

#define FieldGet(varClass, name) \
Int varClass##_##name##Get(Int o)\
{\
    varClass* m;\
    m = CastPointer(o);\
    return m->name;\
}\


#define FieldSet(varClass, name) \
Int varClass##_##name##Set(Int o, Int value)\
{\
    varClass* m;\
    m = CastPointer(o);\
    m->name = value;\
    return true;\
}\


#define Field(varClass, name) \
FieldGet(varClass, name)\
FieldSet(varClass, name)


#define FieldDefaultGet(varClass, name) \
Int varClass##_##name##Get(Int o)\
{\
    return true;\
}\


#define FieldDefaultSet(varClass, name) \
Int varClass##_##name##Set(Int o, Int value)\
{\
    return true;\
}\

