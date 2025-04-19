#include "Thread_Linux.h"

Int Thread_OS_OpenHandle(Int threadId)
{
}

Int Thread_OS_CloseHandle(Int handle)
{
}

Int Thread_OS_Set()
{
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


// Since I have only 2 threads so using two variables, 
// array of bools will be more useful for `n` number of threads.
static int is_th1_ready = 0;
static int is_th2_ready = 0;

static void SignalHandle(int signal)
{
    if (signal == SIGUSR1)
    {
        pause();
    }
    
    if (signal == SIGUSR2)
    {
    }
}

static void *thread_job(void *t_id)
{
        int i = 0;
        struct sigaction act;

        pthread_detach(pthread_self());

        sigemptyset(&act.sa_mask);
        act.sa_flags = 0;
        act.sa_handler = SignalHandle;

        if (sigaction(SIGUSR1, &act, NULL) == -1) 
                printf("unable to handle siguser1\n");
        if (sigaction(SIGUSR2, &act, NULL) == -1) 
                printf("unable to handle siguser2\n");

        if (t_id == (void *)1)
            is_th1_ready = 1;
        if (t_id == (void *)2)
            is_th2_ready = 1;

        while (1) {
                printf("thread id: %p, counter: %d\n", t_id, i++);
                sleep(1);
        }

        return NULL;
}
