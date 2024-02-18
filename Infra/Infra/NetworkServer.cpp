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








Int NetworkServer_GetAddress(Int o)
{
    NetworkServer* m;

    m = CP(o);


    return m->Address;
}




Int NetworkServer_SetAddress(Int o, Int value)
{
    NetworkServer* m;

    m = CP(o);


    m->Address = value;


    return true;
}





Int NetworkServer_GetPort(Int o)
{
    NetworkServer* m;

    m = CP(o);


    return m->Port;
}




Int NetworkServer_SetPort(Int o, Int value)
{
    NetworkServer* m;

    m = CP(o);


    m->Port = value;


    return true;
}






Int NetworkServer_Listen(Int o)
{
    NetworkServer* m;

    m = CP(o);




    Int uu;

    uu = NetworkAddress_GetIntern(m->Address);



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






Int NetworkServer_GetNewPeerState(Int o)
{
    NetworkServer* m;

    m = CP(o);


    return m->NewPeerState;
}




Int NetworkServer_SetNewPeerState(Int o, Int value)
{
    NetworkServer* m;

    m = CP(o);


    m->NewPeerState = value;


    return true;
}







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


    Network_SetStream(network, stream);




    Int uu;

    uu = CastInt(socket);



    Network_ServerSet(network, uu);



    return network;
}







Int NetworkServer_ClosePeer(Int o, Int network)
{
    Int stream;

    stream = Network_GetStream(network);



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

    aa = State_GetMaide(state);


    Int arg;

    arg = State_GetArg(state);




    NetworkServer_NewPeer_Maide maide;

    maide = (NetworkServer_NewPeer_Maide)aa;



    if (!(maide == null))
    {
        maide(o, arg);
    }




    return true;
}
