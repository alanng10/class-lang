#include "Thread_Linux.h"

Int Thread_OS_OpenHandle(Int threadId)
{
    return threadId;
}

Int Thread_OS_CloseHandle(Int handle)
{
    return true;
}

Int Thread_OS_Set()
{
    struct sigaction act;
    memset(&act, 0, sizeof(sigaction));

    int k;
    k = sigemptyset(&act.sa_mask);

    if (!(k == 0))
    {
        return false;
    }

    act.sa_flags = 0;
    act.sa_handler = SignalHandle;

    k = sigaction(SIGUSR1, &act, NULL);

    if (!(k == 0))
    {
        return false;
    }
    
    k = sigaction(SIGUSR2, &act, NULL);

    if (!(k == 0)) 
    {
        return false;
    }

    return true;
}

Int Thread_OS_Pause(Int handle)
{
    int k;
    k = pthread_kill(handle, SIGUSR1);

    if (!(k == 0))
    {
        return false;
    }

    return true;
}


Int Thread_OS_Resume(Int handle)
{
    int k;
    k = pthread_kill(handle, SIGUSR2);

    if (!(k == 0))
    {
        return false;
    }

    return true;
}

void SignalHandle(int signal)
{
    if (signal == SIGUSR1)
    {
        pause();
    }
    
    if (signal == SIGUSR2)
    {
    }
}
