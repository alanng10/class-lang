#include "Network.hpp"




CppClassNew(Network)






Int Network_Init(Int o)
{
    return true;
}




Int Network_Final(Int o)
{
    return true;
}





Int Network_GetHostName(Int o)
{
    Network* m;

    m = CP(o);


    return m->HostName;
}





Int Network_SetHostName(Int o, Int value)
{
    Network* m;

    m = CP(o);


    m->HostName = value;


    return true;
}







Int Network_GetPort(Int o)
{
    Network* m;

    m = CP(o);


    return m->Port;
}




Int Network_SetPort(Int o, Int value)
{
    Network* m;

    m = CP(o);


    m->Port = value;


    return true;
}






Int Network_GetStream(Int o)
{
    Network* m;

    m = CP(o);


    return m->Stream;
}




Int Network_SetStream(Int o, Int value)
{
    Network* m;

    m = CP(o);


    m->Stream = value;


    return true;
}






Int Network_GetStatus(Int o)
{
    Network* m;

    m = CP(o);



    Int socket;

    socket = m->OpenSocket;



    QIODevice* uu;

    uu = (QIODevice*)socket;



    QTcpSocket* u;

    u = (QTcpSocket*)uu;




    QAbstractSocket::SocketError error;

    error = u->error();



    int ua;

    ua = error;

    ua = ua + 2;



    Int a;

    a = ua;


    return a;
}






Int Network_SetStatus(Int o, Int value)
{
    return true;
}







Int Network_GetCase(Int o)
{
    Network* m;

    m = CP(o);



    Int socket;

    socket = m->OpenSocket;



    QIODevice* uu;

    uu = (QIODevice*)socket;



    QTcpSocket* u;

    u = (QTcpSocket*)uu;



    QAbstractSocket::SocketState state;

    state = u->state();



    Int oo;

    oo = state;

    oo = oo + 1;



    Int a;

    a = oo;


    return a;
}






Int Network_SetCase(Int o, Int value)
{
    return true;
}





Int Network_Open(Int o)
{
    Network* m;

    m = CP(o);



    Int hostName;

    hostName = m->HostName;



    Int port;

    port = m->Port;





    QString hostNameU;



    Int uu;

    uu = CastInt(&hostNameU);




    String_SetQString(uu, hostName);




    quint16 portU;

    portU = port;





    QTcpSocket* socket;


    socket = new QTcpSocket;




    QIODevice* ua;

    ua = socket;




    Int oa;

    oa = CastInt(ua);




    m->OpenSocket = oa;





    NetworkHandle* handle;

    handle = new NetworkHandle;


    handle->Network = o;


    handle->Init();




    m->Handle = handle;





    socket->connectToHost(hostNameU, portU);





    return true;
}






Int Network_ConnectedOpen(Int o)
{
    Network* m;

    m = CP(o);




    Int stream;

    stream = m->Stream;



    Int socket;

    socket = m->OpenSocket;




    Int share;


    share = Infra_Share();



    Int stat;

    stat = Share_Stat(share);




    Int kind;

    kind = Stat_StreamKindNetwork(stat);




    Bool canRead;

    canRead = true;



    Bool canWrite;

    canWrite = true;




    Stream_SetKind(stream, kind);


    Stream_SetValue(stream, socket);



    Stream_SetCanRead(stream, canRead);


    Stream_SetCanWrite(stream, canWrite);





    return true;
}






Int Network_Close(Int o)
{
    Network* m;

    m = CP(o);




    Int stream;

    stream = m->Stream;




    Int openSocket;

    openSocket = m->OpenSocket;




    QIODevice* oo;


    oo = (QIODevice*)openSocket;




    QTcpSocket* socket;


    socket = (QTcpSocket*)oo;



    socket->close();




    delete socket;




    delete m->Handle;





    Stream_SetKind(stream, null);



    Stream_SetValue(stream, null);




    m->OpenSocket = null;



    m->Handle = null;





    return true;
}






Int Network_ServerSet(Int o, Int socket)
{
    Network* m;

    m = CP(o);






    QTcpSocket* uu;

    uu = (QTcpSocket*)socket;




    QIODevice* ua;

    ua = uu;




    Int oa;

    oa = CastInt(ua);




    m->OpenSocket = oa;





    NetworkHandle* handle;

    handle = new NetworkHandle;


    handle->Network = o;


    handle->Init();




    m->Handle = handle;






    Int stream;


    stream = m->Stream;





    Int streamValue;

    streamValue = m->OpenSocket;





    Int share;


    share = Infra_Share();



    Int stat;

    stat = Share_Stat(share);




    Int kind;

    kind = Stat_StreamKindNetwork(stat);




    Bool canRead;

    canRead = true;



    Bool canWrite;

    canWrite = true;




    Stream_SetKind(stream, kind);


    Stream_SetValue(stream, streamValue);



    Stream_SetCanRead(stream, canRead);


    Stream_SetCanWrite(stream, canWrite);




    return true;
}






Int Network_Abort(Int o)
{
    Network* m;

    m = CP(o);



    Int socket;

    socket = m->OpenSocket;



    QIODevice* uu;

    uu = (QIODevice*)socket;



    QTcpSocket* u;

    u = (QTcpSocket*)uu;



    u->abort();




    return true;
}






Int Network_GetOpenSocket(Int o)
{
    Network* m;

    m = CP(o);



    return m->OpenSocket;
}





Int Network_GetReadyCount(Int o)
{
    Network* m;

    m = CP(o);



    Int socket;

    socket = m->OpenSocket;



    QIODevice* uu;

    uu = (QIODevice*)socket;



    QTcpSocket* u;

    u = (QTcpSocket*)uu;



    qint64 ua;

    ua = u->bytesAvailable();



    Int a;

    a = ua;



    return a;
}





Int Network_SetReadyCount(Int o, Int value)
{
    return true;
}






Int Network_GetCaseChangedState(Int o)
{
    Network* m;

    m = CP(o);


    return m->CaseChangedState;
}





Int Network_SetCaseChangedState(Int o, Int value)
{
    Network* m;

    m = CP(o);


    m->CaseChangedState = value;


    return true;
}







Int Network_GetErrorState(Int o)
{
    Network* m;

    m = CP(o);


    return m->ErrorState;
}





Int Network_SetErrorState(Int o, Int value)
{
    Network* m;

    m = CP(o);


    m->ErrorState = value;


    return true;
}






Int Network_GetReadyReadState(Int o)
{
    Network* m;

    m = CP(o);


    return m->ReadyReadState;
}





Int Network_SetReadyReadState(Int o, Int value)
{
    Network* m;

    m = CP(o);


    m->ReadyReadState = value;


    return true;
}







Int Network_CaseChanged(Int o)
{
    Network* m;

    m = CP(o);




    Int state;

    state = m->CaseChangedState;



    Int aa;

    aa = State_GetMaide(state);



    Int arg;

    arg = State_GetArg(state);




    Network_CaseChanged_Maide maide;

    maide = (Network_CaseChanged_Maide)aa;



    if (!(maide == null))
    {
        maide(o, arg);
    }




    return true;
}





Int Network_Error(Int o)
{
    Network* m;

    m = CP(o);




    Int state;

    state = m->ErrorState;



    Int aa;

    aa = State_GetMaide(state);



    Int arg;

    arg = State_GetArg(state);




    Network_Error_Maide maide;

    maide = (Network_Error_Maide)aa;



    if (!(maide == null))
    {
        maide(o, arg);
    }




    return true;
}






Int Network_ReadyRead(Int o)
{
    Network* m;

    m = CP(o);




    Int state;

    state = m->ReadyReadState;



    Int aa;

    aa = State_GetMaide(state);



    Int arg;

    arg = State_GetArg(state);




    Network_ReadyRead_Maide maide;

    maide = (Network_ReadyRead_Maide)aa;



    if (!(maide == null))
    {
        maide(o, arg);
    }




    return true;
}

Int Stream_FlushNetwork(Int device)
{
    QIODevice* ua;
    ua = (QIODevice*)device;

    QTcpSocket* socket;
    socket = (QTcpSocket*)ua;
    socket->flush();
    return true;
}