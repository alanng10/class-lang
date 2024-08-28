#pragma once

#include <QTcpServer>

#include "Pronate.hpp"

class NetworkHostIntern : public QTcpServer
{
    Q_OBJECT

public:
    Bool Init();

    Bool Open();
    Bool Close();
    
    Int NetworkHost;

private slots:

    void NewPeerHandle();
};

