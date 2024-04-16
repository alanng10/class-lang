#include "NetworkHandle.hpp"

Bool NetworkHandle::Init()
{
    Int network;
    network = this->Network;
    Int socket;
    socket = Network_GetOpenSocket(network);
    QIODevice* uu;
    uu = (QIODevice*)socket;
    QTcpSocket* u;
    u = (QTcpSocket*)uu;

    connect(u, &QTcpSocket::stateChanged, this, &NetworkHandle::CaseChangedHandle);
    connect(u, &QTcpSocket::errorOccurred, this, &NetworkHandle::ErrorHandle);
    connect(uu, &QIODevice::readyRead, this, &NetworkHandle::ReadyReadHandle);
    return true;
}

void NetworkHandle::CaseChangedHandle(QAbstractSocket::SocketState socketState)
{
    Int network;
    network = this->Network;
    if (socketState == QAbstractSocket::ConnectedState)
    {
        Network_ConnectedOpen(network);
    }
    Network_CaseChanged(network);
}

void NetworkHandle::ErrorHandle(QAbstractSocket::SocketError socketError)
{
    Int network;
    network = this->Network;
    Network_Error(network);
}

void NetworkHandle::ReadyReadHandle()
{
    Int network;
    network = this->Network;
    Network_ReadyRead(network);
}