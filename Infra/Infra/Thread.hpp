#pragma once

#include <QThread>
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

#define CP(a) ((Thread*)(a))

Int Thread_HandleGet(Int o);
Int Thread_HandleSet(Int o, Int value);
Int Thread_StoreSetThread(Int thread);
