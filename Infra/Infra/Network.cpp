#include "Network.hpp"

CppClassNew(Network)

Int Network_Init(Int o)
{
    Network* m;
    m = CP(o);

    NetworkHandle* handle;
    handle = new NetworkHandle;
    handle->Network = o;
    handle->Init();
    m->Handle = handle;
    return true;
}

Int Network_Final(Int o)
{
    Network* m;
    m = CP(o);
    
    delete m->Handle;
    return true;
}

CppField(Network, HostName)
CppField(Network, HostPort)
CppField(Network, Stream)

Int Network_StatusGet(Int o)
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
    ua = ua + 1;

    Int a;
    a = ua;
    return a;
}

FieldDefaultSet(Network, Status)

Int Network_CaseGet(Int o)
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

FieldDefaultSet(Network, Case)

Int Network_Open(Int o)
{
    Network* m;
    m = CP(o);
    Int hostName;
    hostName = m->HostName;
    Int hostPort;
    hostPort = m->HostPort;

    QString hostNameU;
    Int uu;
    uu = CastInt(&hostNameU);
    String_QStringSet(uu, hostName);

    quint16 portU;
    portU = hostPort;

    QTcpSocket* socket;
    socket = new QTcpSocket;
    
    QIODevice* ua;
    ua = socket;
    Int oa;
    oa = CastInt(ua);
    m->OpenSocket = oa;

    m->Handle->Open();

    socket->connectToHost(hostNameU, portU);
    return true;
}

Int Network_OpenConnected(Int o)
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

    Stream_KindSet(stream, kind);
    Stream_ValueSet(stream, socket);
    Stream_CanReadSet(stream, canRead);
    Stream_CanWriteSet(stream, canWrite);
    return true;
}

Int Network_Close(Int o)
{
    Network* m;
    m = CP(o);

    m->Handle->Close();
    
    Int stream;
    stream = m->Stream;
    Int openSocket;
    openSocket = m->OpenSocket;

    Stream_KindSet(stream, null);
    Stream_ValueSet(stream, null);

    QIODevice* oo;
    oo = (QIODevice*)openSocket;

    QTcpSocket* socket;
    socket = (QTcpSocket*)oo;

    socket->close();

    socket->deleteLater();

    m->OpenSocket = null;
    return true;
}

Int Network_HostOpen(Int o, Int socket)
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

    m->Handle->Open();

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

    Stream_KindSet(stream, kind);
    Stream_ValueSet(stream, streamValue);
    Stream_CanReadSet(stream, canRead);
    Stream_CanWriteSet(stream, canWrite);
    return true;
}

Int Network_HostClose(Int o)
{
    Network_Close(o);
    return true;
}

Int Network_GetOpenSocket(Int o)
{
    Network* m;
    m = CP(o);
    return m->OpenSocket;
}

Int Network_ReadyCountGet(Int o)
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

FieldDefaultSet(Network, ReadyCount)
CppField(Network, StatusEventState)
CppField(Network, CaseEventState)
CppField(Network, DataEventState)

Int Network_StatusEvent(Int o)
{
    Network* m;
    m = CP(o);
    Int state;
    state = m->StatusEventState;

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

    Network_StatusEvent_Maide maide;
    maide = (Network_StatusEvent_Maide)aa;

    maide(o, arg);
    
    return true;
}

Int Network_CaseEvent(Int o)
{
    Network* m;
    m = CP(o);
    Int openSocket;
    openSocket = m->OpenSocket;

    QIODevice* oo;
    oo = (QIODevice*)openSocket;

    QTcpSocket* socket;
    socket = (QTcpSocket*)oo;

    QAbstractSocket::SocketState oa;
    oa = socket->state();

    if (oa == QAbstractSocket::ConnectedState)
    {
        Network_OpenConnected(o);
    }

    Int state;
    state = m->CaseEventState;
    if (!(state == null))
    {
        Int aa;
        aa = State_MaideGet(state);
        Int arg;
        arg = State_ArgGet(state);

        Network_CaseEvent_Maide maide;
        maide = (Network_CaseEvent_Maide)aa;
        if (!(maide == null))
        {
            maide(o, arg);
        }
    }

    return true;
}

Int Network_DataEvent(Int o)
{
    Network* m;
    m = CP(o);

    Int state;
    state = m->DataEventState;

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

    Network_DataEvent_Maide maide;
    maide = (Network_DataEvent_Maide)aa;

    maide(o, arg);

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