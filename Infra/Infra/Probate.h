#pragma once

#include "Prudate.h"

Int String_QStringSet(Int result, Int a);
Int String_QStringSetRaw(Int result, Int a);

Int Stream_FlushStorage(Int device);
Int Stream_FlushNetwork(Int device);
Int Stream_ValueGet(Int o);
Int Stream_ValueSet(Int o, Int value);
Int Stream_CanReadSet(Int o, Int value);
Int Stream_CanWriteSet(Int o, Int value);
Int Stream_Intern(Int o);

Int Network_GetOpenSocket(Int o);
Int Network_ServerOpen(Int o, Int socket);
Int Network_ServerClose(Int o);
Int Network_StatusChange(Int o);
Int Network_CaseChange(Int o);
Int Network_ReadyRead(Int o);

Int NetworkServer_NewPeer(Int o);

Int NetworkPort_InternAddress(Int o);

Int Draw_Intern(Int o);

Int Brush_Intern(Int o);

Int Pen_Intern(Int o);

Int Image_Intern(Int o);
Int Image_SetReadIntern(Int o, Int value);

Int Font_Intern(Int o);

Int Transform_Intern(Int o);

Int Gradient_Intern(Int o);

Int GradientLinear_Intern(Int o);

Int GradientRadial_Intern(Int o);

Int GradientStop_Intern(Int o);

Int VideoOut_Intern(Int o);
Int VideoOut_FrameChange(Int o);

Int VideoFrame_Intern(Int o);

Int AudioOut_Intern(Int o);

Int InternValueGet(Int a);
Int ValueGetFromInternValue(Int a);

Int Math_GetInternValue(Int o, Int a);
Int Math_GetValueFromInternValue(Int o, Int a);

Int Thread_HandleGet(Int o);
Int Thread_HandleSet(Int o, Int value);
Int Thread_GetInternCaseMutex(Int o);
Int Thread_GetInternHandleSemaphore(Int o);
Int Thread_InitMainThread(Int o);
Int Thread_FinalMainThread(Int o);
Int Thread_OS_OpenHandle(Int threadId);
Int Thread_OS_CloseHandle(Int handle);
Int Thread_OS_Set();
Int Thread_OS_Pause(Int handle);
Int Thread_OS_Resume(Int handle);
Int Thread_CreateStore();
Int Thread_DeleteStore(Int a);
Int Thread_StoreSetThread(Int thread);

Int Interval_Elapse(Int o);

Int Post_ExecuteHandle(Int o);

Int Process_Start(Int o);
Int Process_Finish(Int o);

Int Main_CurrentThreadSignalHandleSet();

Int Console_OS_Init();

Int HasFlag(Int value, Int flag);

Int Share_New();
Int Share_Delete(Int o);
Int Share_Init(Int o);
Int Share_Final(Int o);
Int Share_ThreadStorage(Int o);

Int Stat_New();
Int Stat_Delete(Int o);
Int Stat_Init(Int o);
Int Stat_Final(Int o);
Int Stat_TimeInit(Int o);
Int Stat_ConsolePhore(Int o);

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

