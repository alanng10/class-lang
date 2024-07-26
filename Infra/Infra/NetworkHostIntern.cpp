#include "NetworkHostIntern.hpp"

Bool NetworkHostIntern::Init()
{
    return true;
}

Bool NetworkHostIntern::Open()
{
    connect(this, &QTcpServer::newConnection, this, &NetworkHostIntern::NewPeerHandle);
    return true;
}

Bool NetworkHostIntern::Close()
{
    disconnect(this, &QTcpServer::newConnection, this, &NetworkHostIntern::NewPeerHandle);
    return true;
}

void NetworkHostIntern::NewPeerHandle()
{
    Int networkServer;
    networkServer = this->NetworkHost;
    NetworkHost_NewPeer(networkServer);
}