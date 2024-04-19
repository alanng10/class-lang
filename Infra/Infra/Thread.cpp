#include "Thread.hpp"

CppClassNew(Thread)

Int Thread_Init(Int o)
{
    Thread* m;
    m = CP(o);

    m->InternHandleSemaphore = new QSemaphore;

    m->InternCaseMutex = new QMutex;

    m->InternThread = new ThreadIntern;
    m->InternThread->Thread = o;
    m->InternThread->Init();

    m->Intern = m->InternThread;

    Int share;
    share = Infra_Share();
    Int stat;
    stat = Share_Stat(share);

    m->Case = Stat_ThreadCaseReady(stat);
    return true;
}

Int Thread_Final(Int o)
{
    Thread* m;
    m = CP(o);

    delete m->Intern;
    delete m->InternCaseMutex;
    delete m->InternHandleSemaphore;

    Int share;
    share = Infra_Share();
    Int stat;
    stat = Share_Stat(share);

    Int readyCase;
    readyCase = Stat_ThreadCaseReady(stat);
    if (!(m->Case == readyCase))
    {
        Int handle;
        handle = m->Handle;
        Thread_OS_CloseHandle(handle);
    }
    return true;
}

Int Thread_InitMainThread(Int o)
{
    Thread* m;
    m = CP(o);

    m->InternCaseMutex = new QMutex;

    m->Intern = QThread::currentThread();

    Int share;
    share = Infra_Share();
    Int stat;
    stat = Share_Stat(share);

    Int executeCase;
    executeCase = Stat_ThreadCaseExecute(stat);
    m->Case = executeCase;

    Qt::HANDLE uu;
    uu = QThread::currentThreadId();
    
    Int threadId;
    threadId = CastInt(uu);

    Int thread;
    thread = o;

    Int handle;
    handle = Thread_OS_OpenHandle(threadId);

    Thread_HandleSet(thread, handle);

    Thread_StoreSetThread(thread);

    Main_CurrentThreadSignalHandleSet();
    return true;
}

Int Thread_FinalMainThread(Int o)
{
    Thread* m;
    m = CP(o);

    delete m->InternCaseMutex;

    Int handle;
    handle = m->Handle;
    Thread_OS_CloseHandle(handle);
    return true;
}

CppField(Thread, Ident)
CppField(Thread, ExecuteState)
CppField(Thread, Status)
CppField(Thread, Case)
CppField(Thread, Handle)

Int Thread_GetInternCaseMutex(Int o)
{
    Thread* m;
    m = CP(o);
    QMutex* ua;
    ua = m->InternCaseMutex;
    Int a;
    a = CastInt(ua);
    return a;
}

Int Thread_GetInternHandleSemaphore(Int o)
{
    Thread* m;
    m = CP(o);
    QSemaphore* ua;
    ua = m->InternHandleSemaphore;
    Int a;
    a = CastInt(ua);
    return a;
}

Int Thread_Execute(Int o)
{
    Thread* m;
    m = CP(o);
    Int share;
    share = Infra_Share();
    Int stat;
    stat = Share_Stat(share);

    Int readyCase;
    readyCase = Stat_ThreadCaseReady(stat);
    if (!(m->Case == readyCase))
    {
        return true;
    }

    m->Intern->start();

    m->InternHandleSemaphore->acquire();
    return true;
}

Int Thread_Terminate(Int o)
{
    Thread* m;
    m = CP(o);

    Int share;
    share = Infra_Share();
    Int stat;
    stat = Share_Stat(share);

    Int executeCase;
    executeCase = Stat_ThreadCaseExecute(stat);
    Int pauseCase;
    pauseCase = Stat_ThreadCasePause(stat);

    m->InternCaseMutex->lock();

    if ((m->Case == executeCase) | (m->Case == pauseCase))
    {
        m->Intern->terminate();

        Int terminateCase;
        terminateCase = Stat_ThreadCaseTerminate(stat);

        m->Case = terminateCase;
    }

    m->InternCaseMutex->unlock();
    return true;
}

Int Thread_Pause(Int o)
{
    Thread* m;
    m = CP(o);

    Int share;
    share = Infra_Share();
    Int stat;
    stat = Share_Stat(share);

    Int executeCase;
    executeCase = Stat_ThreadCaseExecute(stat);

    m->InternCaseMutex->lock();

    if (m->Case == executeCase)
    {
        Thread_OS_Pause(m->Handle);

        Int pauseCase;
        pauseCase = Stat_ThreadCasePause(stat);
        m->Case = pauseCase;
    }

    m->InternCaseMutex->unlock();
    return true;
}

Int Thread_Resume(Int o)
{
    Thread* m;
    m = CP(o);
    Int share;
    share = Infra_Share();
    Int stat;
    stat = Share_Stat(share);

    Int pauseCase;
    pauseCase = Stat_ThreadCasePause(stat);

    m->InternCaseMutex->lock();

    if (m->Case == pauseCase)
    {
        Thread_OS_Resume(m->Handle);

        Int executeCase;
        executeCase = Stat_ThreadCaseExecute(stat);
        m->Case = executeCase;
    }

    m->InternCaseMutex->unlock();
    return true;
}

Int Thread_Wait(Int o)
{
    Thread* m;
    m = CP(o);
    m->Intern->wait();
    return true;
}

Int Thread_ExecuteEventLoop(Int o)
{
    Thread* m;
    m = CP(o);

    Bool b;
    b = Thread_IsMainThread(o);
    if (b)
    {
        Int oa;
        oa = Main_ExecuteEventLoop();
        return oa;
    }

    Int a;
    a = m->InternThread->ExecuteEventLoop();
    return a;
}

Int Thread_ExitEventLoop(Int o, Int code)
{
    Thread* m;
    m = CP(o);

    Bool b;
    b = Thread_IsMainThread(o);
    if (b)
    {
        Bool oa;
        oa = Main_ExitEventLoop(code);
        return oa;
    }

    int u;
    u = code;

    m->InternThread->exit(u);
    return true;
}

Int Thread_IsMainThread(Int o)
{
    Thread* m;
    m = CP(o);
    Bool a;
    a = (m->InternThread == null);
    return a;
}

Int Thread_Sleep(Int time)
{
    unsigned long u;
    u = time;

    QThread::msleep(u);
    return true;
}

Int Thread_CreateStore()
{
    QThreadStorage<ThreadStoreValue>* threadStorage;
    threadStorage = new QThreadStorage<ThreadStoreValue>();
    Int a;
    a = CastInt(threadStorage);
    return a;
}

Int Thread_DeleteStore(Int a)
{
    QThreadStorage<ThreadStoreValue>* threadStorage;
    threadStorage = (QThreadStorage<ThreadStoreValue>*)a;

    delete threadStorage;
    return true;
}

Int Thread_StoreSetThread(Int thread)
{
    ThreadStoreValue o;
    o = { };
    o.Thread = thread;

    Int share;
    share = Infra_Share();
    Int u;
    u = Share_ThreadStorage(share);

    QThreadStorage<ThreadStoreValue>* threadStorage;
    threadStorage = (QThreadStorage<ThreadStoreValue>*)u;
    threadStorage->setLocalData(o);
    return true;
}

Int Thread_CurrentThread()
{
    Int share;
    share = Infra_Share();

    Int u;
    u = Share_ThreadStorage(share);

    QThreadStorage<ThreadStoreValue>* threadStorage;
    threadStorage = (QThreadStorage<ThreadStoreValue>*)u;

    ThreadStoreValue o;
    o = threadStorage->localData();

    Int a;
    a = o.Thread;
    return a;
}