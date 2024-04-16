#include "NetworkServerIntern.hpp"

Bool NetworkServerIntern::Init()
{
    connect(this, &QTcpServer::newConnection, this, &NetworkServerIntern::NewPeerHandle);
    return true;
}

void NetworkServerIntern::NewPeerHandle()
{
    Int networkServer;
    networkServer = this->NetworkServer;
    NetworkServer_NewPeer(networkServer);
}