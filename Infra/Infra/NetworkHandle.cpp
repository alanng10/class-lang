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

    connect(u, &QTcpSocket::errorOccurred, this, &NetworkHandle::StatusChangeHandle);
    connect(u, &QTcpSocket::stateChanged, this, &NetworkHandle::CaseChangeHandle);
    connect(uu, &QIODevice::readyRead, this, &NetworkHandle::ReadyReadHandle);
    return true;
}

void NetworkHandle::StatusChangeHandle(QAbstractSocket::SocketError socketError)
{
    Int network;
    network = this->Network;
    Network_StatusChange(network);
}

void NetworkHandle::CaseChangeHandle(QAbstractSocket::SocketState socketState)
{
    Int network;
    network = this->Network;
    Network_CaseChange(network);
}

void NetworkHandle::ReadyReadHandle()
{
    Int network;
    network = this->Network;
    Network_ReadyRead(network);
}