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

    Bool k;
    k = (m->InitIntern == null);

    if (k)
    {
        QTcpSocket* socket;
        socket = new QTcpSocket;
        m->Intern = socket;
    }

    if (!k)
    {
        m->Intern = (QTcpSocket*)m->InitIntern;
    }

    return true;
}

Int Network_Final(Int o)
{
    Network* m;
    m = CP(o);
    
    delete m->Intern;

    delete m->Handle;
    return true;
}

CppField(Network, HostName)
CppField(Network, HostPort)
CppField(Network, Stream)
CppField(Network, InitIntern)

Int Network_StatusGet(Int o)
{
    Network* m;
    m = CP(o);

    QAbstractSocket::SocketError error;
    error = m->Intern->error();

    int ka;
    ka = error;
    ka = ka + 1;

    Int a;
    a = ka;
    return a;
}

FieldDefaultSet(Network, Status)

Int Network_CaseGet(Int o)
{
    Network* m;
    m = CP(o);

    QAbstractSocket::SocketState state;
    state = m->Intern->state();

    Int ka;
    ka = state;
    ka = ka + 1;

    Int a;
    a = ka;
    return a;
}

FieldDefaultSet(Network, Case)

Int Network_Open(Int o)
{
    Network* m;
    m = CP(o);

    if (m->Open)
    {
        return true;
    }

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

    m->Open = true;

    m->Handle->Open();

    m->Intern->connectToHost(hostNameU, portU);
    return true;
}

Int Network_OpenConnect(Int o)
{
    Network* m;
    m = CP(o);

    Int stream;
    stream = m->Stream;
    Int socket;
    socket = CastInt(m->Intern);

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

    Stream_KindSet(stream, null);
    Stream_ValueSet(stream, null);

    m->Intern->close();

    m->Open = false;

    return true;
}

Int Network_HostOpen(Int o)
{
    Network* m;
    m = CP(o);

    m->Open = true;

    m->Handle->Open();

    QIODevice* ka;
    ka = m->Intern;

    Int stream;
    stream = m->Stream;
    Int streamValue;
    streamValue = CastInt(ka);

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

Int Network_Intern(Int o)
{
    Network* m;
    m = CP(o);

    return CastInt(m->Intern);
}

Int Network_ReadyCountGet(Int o)
{
    Network* m;
    m = CP(o);

    qint64 ka;
    ka = m->Intern->bytesAvailable();

    Int a;
    a = ka;
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

    QAbstractSocket::SocketState ka;
    ka = m->Intern->state();

    if (ka == QAbstractSocket::ConnectedState)
    {
        Network_OpenConnect(o);
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