#pragma once

#include <QThread>

#include "Pronate.hpp"

class ThreadIntern : public QThread
{
    Q_OBJECT

public:
    Bool Init();

    Int Thread;

    Int ExecuteEventLoop();

protected:

    void run() override;
};
