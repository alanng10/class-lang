#include "Thread_Unix.h"







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
    struct sigaction act = { };



    sigemptyset(&act.sa_mask);


    act.sa_flags = 0;


    act.sa_handler = Thread_Unix_SignalHandle;




    int u;



    u = sigaction(SIGUSR1, &act, NULL);


    if (u == -1)
    {
        return false;
    }



    u = sigaction(SIGUSR2, &act, NULL);

    if (u == -1)
    {
        return false;
    }



    return true;
}




Int Thread_OS_Pause(Int handle)
{
    pthread_t ua;

    ua = (pthread_t)handle;



    int u;

    u = pthread_kill(ua, SIGUSR1);



    Bool a;

    a = (u == 0);


    return a;
}





Int Thread_OS_Resume(Int handle)
{
    pthread_t ua;

    ua = (pthread_t)handle;



    int u;

    u = pthread_kill(ua, SIGUSR2);



    Bool a;

    a = (u == 0);


    return a;
}






void Thread_Unix_SignalHandle(int signal)
{
    if (signal == SIGUSR1)
    {
        pause();
    }

    if (signal == SIGUSR2)
    {
    }
}
