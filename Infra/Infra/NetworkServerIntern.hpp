#pragma once

#include <QTcpServer>

#include "Probate.hpp"

class NetworkServerIntern : public QTcpServer
{
    Q_OBJECT

public:
    Bool Init();
    Bool Final();
    
    Int NetworkServer;

private slots:

    void NewPeerHandle();
};

