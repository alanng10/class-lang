#pragma once

#include <QTcpServer>

#include "Probate.hpp"

class NetworkServerIntern : public QTcpServer
{
    Q_OBJECT

public:
    Bool Init();

    Bool Open();
    Bool Close();
    
    Int NetworkServer;

private slots:

    void NewPeerHandle();
};

