#pragma once




#include <QMutex>
#include <QSemaphore>
#include <QThreadStorage>



#include "ThreadIntern.hpp"



#include "Probate.hpp"





struct Thread
{
    Int Ident;


    Int ExecuteState;



    Int Case;



    Int Status;




    Int Handle;




    ThreadIntern* InternThread;



    QThread* Intern;


    QMutex* InternCaseMutex;


    QSemaphore* InternHandleSemaphore;
};





struct ThreadStoreValue
{
    Int Thread;
};
