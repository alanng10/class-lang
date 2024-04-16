#pragma once

#include <QAbstractSocket>
#include <QTcpSocket>

#include "Probate.hpp"

class NetworkHandle : public QObject
{
    Q_OBJECT

public:
    Bool Init();
    Int Network;

public slots:

    void CaseChangedHandle(QAbstractSocket::SocketState socketState);
    void ErrorHandle(QAbstractSocket::SocketError socketError);
    void ReadyReadHandle();
};
