#include "NetworkHandle.hpp"

Bool NetworkHandle::Init()
{
    return true;
}

Bool NetworkHandle::Open()
{
    Int network;
    network = this->Network;
    Int socket;
    socket = Network_GetOpenSocket(network);
    QTcpSocket* u;
    u = (QTcpSocket*)socket;
    QIODevice* uu;
    uu = (QIODevice*)u;

    connect(u, &QTcpSocket::errorOccurred, this, &NetworkHandle::StatusEventHandle);
    connect(u, &QTcpSocket::stateChanged, this, &NetworkHandle::CaseEventHandle);
    connect(uu, &QIODevice::readyRead, this, &NetworkHandle::DataEventHandle);
    return true;
}

Bool NetworkHandle::Close()
{
    Int network;
    network = this->Network;
    Int socket;
    socket = Network_GetOpenSocket(network);
    QTcpSocket* u;
    u = (QTcpSocket*)socket;
    QIODevice* uu;
    uu = (QIODevice*)u;

    disconnect(uu, &QIODevice::readyRead, this, &NetworkHandle::DataEventHandle);
    disconnect(u, &QTcpSocket::stateChanged, this, &NetworkHandle::CaseEventHandle);
    disconnect(u, &QTcpSocket::errorOccurred, this, &NetworkHandle::StatusEventHandle);
    return true;
}

void NetworkHandle::StatusEventHandle(QAbstractSocket::SocketError socketError)
{
    Int network;
    network = this->Network;
    Network_StatusEvent(network);
}

void NetworkHandle::CaseEventHandle(QAbstractSocket::SocketState socketState)
{
    Int network;
    network = this->Network;
    Network_CaseEvent(network);
}

void NetworkHandle::DataEventHandle()
{
    Int network;
    network = this->Network;
    Network_DataEvent(network);
}