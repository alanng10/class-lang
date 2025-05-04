#include "NetworkHost.hpp"

CppClassNew(NetworkHost)

Int NetworkHost_Init(Int o)
{
    return true;
}

Int NetworkHost_Final(Int o)
{
    return true;
}

CppField(NetworkHost, Port)
CppField(NetworkHost, NewPeerState)

Int NetworkHost_Open(Int o)
{
    NetworkHost* m;
    m = CP(o);

    m->Intern = new NetworkHostIntern;
    m->Intern->NetworkHost = o;
    m->Intern->Init();

    m->Intern->Open();

    Int ka;
    ka = NetworkPort_InternAddress(m->Port);
    QHostAddress* ua;
    ua = (QHostAddress*)ka;

    Int kb;
    kb = NetworkPort_HostGet(m->Port);
    quint16 ub;
    ub = kb;

    bool bu;
    bu = m->Intern->listen(*ua, ub);

    Bool a;
    a = bu;
    return a;
}

Int NetworkHost_Close(Int o)
{
    NetworkHost* m;
    m = CP(o);
    m->Intern->close();

    m->Intern->Close();

    delete m->Intern;
    m->Intern = null;
    return true;
}

Int NetworkHost_OpenPeer(Int o)
{
    NetworkHost* m;
    m = CP(o);
    QTcpSocket* socket;
    socket = m->Intern->nextPendingConnection();

    Int stream;
    stream = Stream_New();
    Stream_Init(stream);
    Int network;
    network = Network_New();
    Network_Init(network);
    Network_StreamSet(network, stream);

    Int uu;
    uu = CastInt(socket);
    Network_HostOpen(network, uu);
    return network;
}

Int NetworkHost_ClosePeer(Int o, Int network)
{
    Int stream;
    stream = Network_StreamGet(network);

    Network_HostClose(network);

    Network_Final(network);
    Network_Delete(network);

    Stream_Final(stream);
    Stream_Delete(stream);
    return true;
}

Int NetworkHost_NewPeer(Int o)
{
    NetworkHost* m;
    m = CP(o);
    Int state;
    state = m->NewPeerState;

    if (state == null)
    {
        return true;
    }

    Int aa;
    aa = State_MaideGet(state);
    Int arg;
    arg = State_ArgGet(state);

    if (aa == null)
    {
        return true;
    }

    NetworkHost_NewPeer_Maide maide;
    maide = (NetworkHost_NewPeer_Maide)aa;

    maide(o, arg);
    
    return true;
}