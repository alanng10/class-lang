#include "ThreadIntern.hpp"

Bool ThreadIntern::Init()
{
    return true;
}





void ThreadIntern::run()
{
    Qt::HANDLE uu;


    uu = QThread::currentThreadId();




    Int threadId;

    threadId = CastInt(uu);




    Int thread;

    thread = this->Thread;





    Int handle;

    handle = Thread_OS_OpenHandle(threadId);




    Thread_HandleSet(thread, handle);




    Thread_OS_Set();





    Int share;

    share = Infra_Share();




    Int stat;

    stat = Share_Stat(share);




    Int executeCase;

    executeCase = Stat_ThreadCaseExecute(stat);




    Thread_CaseSet(thread, executeCase);





    Int ua;

    ua = Thread_GetInternHandleSemaphore(thread);




    QSemaphore* handleSemaphore;


    handleSemaphore = (QSemaphore*)ua;



    handleSemaphore->release();







    Thread_StoreSetThread(thread);






    Main_CurrentThreadSignalHandleSet();




    Int state;

    state = Thread_ExecuteStateGet(thread);



    Int aa;

    aa = State_MaideGet(state);


    Int ab;

    ab = State_ArgGet(state);




    Thread_Execute_Maide maide;

    maide = (Thread_Execute_Maide)aa;



    Int status;

    status = 0;


    if (!(maide == null))
    {
        status = maide(thread, ab);
    }





    Thread_StatusSet(thread, status);








    Int finishCase;

    finishCase = Stat_ThreadCaseFinish(stat);





    Int uc;

    uc = Thread_GetInternCaseMutex(thread);




    QMutex* caseMutex;


    caseMutex = (QMutex*)uc;




    caseMutex->lock();



    Thread_CaseSet(thread, finishCase);



    caseMutex->unlock();
}






int ThreadIntern::ExecuteEventLoop()
{
    return this->exec();
}
