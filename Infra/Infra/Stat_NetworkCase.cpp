#include "Stat.hpp"




Int Stat_Var_NetworkCaseUnconnected = QAbstractSocket::UnconnectedState + 1;

Int Stat_Var_NetworkCaseHostLookup = QAbstractSocket::HostLookupState + 1;

Int Stat_Var_NetworkCaseConnecting = QAbstractSocket::ConnectingState + 1;

Int Stat_Var_NetworkCaseConnected = QAbstractSocket::ConnectedState + 1;

Int Stat_Var_NetworkCaseBound = QAbstractSocket::BoundState + 1;

Int Stat_Var_NetworkCaseListening = QAbstractSocket::ListeningState + 1;

Int Stat_Var_NetworkCaseClosing = QAbstractSocket::ClosingState + 1;






Int Stat_NetworkCaseUnconnected(Int o)
{
    return Stat_Var_NetworkCaseUnconnected;
}


Int Stat_NetworkCaseHostLookup(Int o)
{
    return Stat_Var_NetworkCaseHostLookup;
}


Int Stat_NetworkCaseConnecting(Int o)
{
    return Stat_Var_NetworkCaseConnecting;
}


Int Stat_NetworkCaseConnected(Int o)
{
    return Stat_Var_NetworkCaseConnected;
}


Int Stat_NetworkCaseBound(Int o)
{
    return Stat_Var_NetworkCaseBound;
}


Int Stat_NetworkCaseListening(Int o)
{
    return Stat_Var_NetworkCaseListening;
}


Int Stat_NetworkCaseClosing(Int o)
{
    return Stat_Var_NetworkCaseClosing;
}


