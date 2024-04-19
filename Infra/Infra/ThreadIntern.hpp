#pragma once





#include <QThread>
#include <QSemaphore>
#include <QMutex>
#include <QThreadStorage>




#include "Probate.hpp"






class ThreadIntern : public QThread
{
    Q_OBJECT


public:
    Bool Init();
    
    Int Thread;


    int ExecuteEventLoop();


protected:

    void run() override;
};

