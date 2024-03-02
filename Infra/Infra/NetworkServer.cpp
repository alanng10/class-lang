#include "NetworkServer.hpp"




CppClassNew(NetworkServer)






Int NetworkServer_Init(Int o)
{
    NetworkServer* m;

    m = CP(o);




    m->Intern = new NetworkServerIntern;


    m->Intern->NetworkServer = o;




    return true;
}






Int NetworkServer_Final(Int o)
{
    NetworkServer* m;

    m = CP(o);




    delete m->Intern;




    return true;
}

CppField(NetworkServer, Address)
CppField(NetworkServer, Port)

Int NetworkServer_Listen(Int o)
{
    NetworkServer* m;

    m = CP(o);




    Int uu;

    uu = NetworkAddress_Intern(m->Address);



    QHostAddress* ua;

    ua = (QHostAddress*)uu;



    quint16 ub;

    ub = m->Port;




    bool bu;

    bu = m->Intern->listen(*ua, ub);



    Bool a;

    a = bu;



    return a;
}

Int NetworkServer_Close(Int o)
{
    NetworkServer* m;

    m = CP(o);



    m->Intern->close();



    return true;
}

CppField(NetworkServer, NewPeerState)

Int NetworkServer_NextPendingPeer(Int o)
{
    NetworkServer* m;

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



    Network_ServerSet(network, uu);



    return network;
}

Int NetworkServer_ClosePeer(Int o, Int network)
{
    Int stream;

    stream = Network_StreamGet(network);



    Network_Close(network);



    Network_Final(network);


    Network_Delete(network);



    Stream_Final(stream);


    Stream_Delete(stream);




    return true;
}

Int NetworkServer_NewPeer(Int o)
{
    NetworkServer* m;

    m = CP(o);



    Int state;

    state = m->NewPeerState;



    Int aa;

    aa = State_MaideGet(state);


    Int arg;

    arg = State_ArgGet(state);




    NetworkServer_NewPeer_Maide maide;

    maide = (NetworkServer_NewPeer_Maide)aa;



    if (!(maide == null))
    {
        maide(o, arg);
    }




    return true;
}