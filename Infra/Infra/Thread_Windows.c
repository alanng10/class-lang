#include "Thread_Windows.h"

Int Thread_OS_OpenHandle(Int threadId)
{
    DWORD ua;
    ua = threadId;
    DWORD ub;
    ub = THREAD_ALL_ACCESS;

    BOOL uc;
    uc = FALSE;

    HANDLE uu;
    uu = OpenThread(ub, uc, ua);

    Int a;
    a = CastInt(uu);
    return a;
}

Int Thread_OS_CloseHandle(Int handle)
{
    HANDLE uu;
    uu = (HANDLE)handle;

    BOOL ua;
    ua = CloseHandle(uu);

    Bool a;
    a = !(ua == 0);
    return a;
}

Int Thread_OS_Set()
{
    return true;
}

Int Thread_OS_Pause(Int handle)
{
    HANDLE ua;
    ua = (HANDLE)handle;

    DWORD uu;
    uu = SuspendThread(ua);

    if (uu == -1)
    {
        return false;
    }

    return true;
}

Int Thread_OS_Resume(Int handle)
{
    HANDLE ua;
    ua = (HANDLE)handle;

    DWORD uu;
    uu = ResumeThread(ua);

    if (uu == -1)
    {
        return false;
    }

    return true;
}