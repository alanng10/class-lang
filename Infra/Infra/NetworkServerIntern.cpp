#include "NetworkServerIntern.hpp"

Bool NetworkServerIntern::Init()
{
    return true;
}

Bool NetworkServerIntern::Open()
{
    connect(this, &QTcpServer::newConnection, this, &NetworkServerIntern::NewPeerHandle);
    return true;
}

Bool NetworkServerIntern::Close()
{
    disconnect(this, &QTcpServer::newConnection, this, &NetworkServerIntern::NewPeerHandle);
    return true;
}

void NetworkServerIntern::NewPeerHandle()
{
    Int networkServer;
    networkServer = this->NetworkServer;
    NetworkServer_NewPeer(networkServer);
}