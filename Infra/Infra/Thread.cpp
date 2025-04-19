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

Int Thread_InternCaseMutex(Int o)
{
    Thread* m;
    m = CP(o);
    QMutex* ua;
    ua = m->InternCaseMutex;
    Int a;
    a = CastInt(ua);
    return a;
}

Int Thread_InternHandleSemaphore(Int o)
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
        Bool b;
        b = Thread_OS_Pause(m->Handle);
        if (!b)
        {
            Exit(151);
        }

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
        Bool b;
        b = Thread_OS_Resume(m->Handle);
        if (!b)
        {
            Exit(152);
        }

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

Int Thread_ExecuteMain(Int o)
{
    Thread* m;
    m = CP(o);

    Bool b;
    b = Thread_IsMain(o);
    if (b)
    {
        Int oa;
        oa = Main_ExecuteMain();
        return oa;
    }

    Int a;
    a = m->InternThread->ExecuteMain();
    return a;
}

Int Thread_Exit(Int o, Int status)
{
    Thread* m;
    m = CP(o);

    Bool b;
    b = Thread_IsMain(o);
    if (b)
    {
        Bool oa;
        oa = Main_Exit(status);
        return oa;
    }

    int u;
    u = status;

    m->InternThread->exit(u);
    return true;
}

Int Thread_IsMain(Int o)
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

Int Thread_ExecuteHandle(Int o)
{
    Qt::HANDLE uu;
    uu = QThread::currentThreadId();

    Int threadId;
    threadId = CastInt(uu);

    Int handle;
    handle = Thread_OS_OpenHandle(threadId);

    Thread_HandleSet(o, handle);

    Thread_OS_Set();

    Int share;
    share = Infra_Share();
    Int stat;
    stat = Share_Stat(share);

    Int executeCase;
    executeCase = Stat_ThreadCaseExecute(stat);
    Thread_CaseSet(o, executeCase);

    Thread_StoreSetThread(o);

    Main_CurrentThreadSignalHandleSet();

    Int ua;
    ua = Thread_InternHandleSemaphore(o);

    QSemaphore* handleSemaphore;
    handleSemaphore = (QSemaphore*)ua;
    handleSemaphore->release();

    Int status;
    status = 0;

    Int state;
    state = Thread_ExecuteStateGet(o);

    if (!(state == null))
    {
        Int aa;
        aa = State_MaideGet(state);
        Int ab;
        ab = State_ArgGet(state);

        if (!(aa == null))
        {
            Thread_Execute_Maide maide;
            maide = (Thread_Execute_Maide)aa;

            status = maide(o, ab);
        }
    }

    Thread_StatusSet(o, status);

    Int finishCase;
    finishCase = Stat_ThreadCaseFinish(stat);

    Int uc;
    uc = Thread_InternCaseMutex(o);
    QMutex* caseMutex;
    caseMutex = (QMutex*)uc;

    caseMutex->lock();

    Thread_CaseSet(o, finishCase);

    caseMutex->unlock();

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

Int Thread_This()
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