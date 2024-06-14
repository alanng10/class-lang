#pragma once

#include <QAbstractSocket>
#include <QTcpSocket>

#include "Probate.hpp"

class NetworkHandle : public QObject
{
    Q_OBJECT

public:
    Bool Init();
    Bool Final();
    
    Int Network;

public slots:

    void StatusChangeHandle(QAbstractSocket::SocketError socketError);
    void CaseChangeHandle(QAbstractSocket::SocketState socketState);
    void ReadyReadHandle();
};
