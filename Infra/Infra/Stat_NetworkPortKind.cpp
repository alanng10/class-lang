#include "Stat.hpp"

Int Stat_Var_NetworkPortKindIPv6 = 1;
Int Stat_Var_NetworkPortKindIPv4 = 2;
Int Stat_Var_NetworkPortKindBroadcast = QHostAddress::Broadcast + 2;
Int Stat_Var_NetworkPortKindLocalHost = QHostAddress::LocalHost + 2;
Int Stat_Var_NetworkPortKindLocalHostIPv6 = QHostAddress::LocalHostIPv6 + 2;
Int Stat_Var_NetworkPortKindAny = QHostAddress::Any + 2;
Int Stat_Var_NetworkPortKindAnyIPv6 = QHostAddress::AnyIPv6 + 2;
Int Stat_Var_NetworkPortKindAnyIPv4 = QHostAddress::AnyIPv4 + 2;

Int Stat_NetworkPortKindIPv6(Int o)
{
    return Stat_Var_NetworkPortKindIPv6;
}
Int Stat_NetworkPortKindIPv4(Int o)
{
    return Stat_Var_NetworkPortKindIPv4;
}
Int Stat_NetworkPortKindBroadcast(Int o)
{
    return Stat_Var_NetworkPortKindBroadcast;
}
Int Stat_NetworkPortKindLocalHost(Int o)
{
    return Stat_Var_NetworkPortKindLocalHost;
}
Int Stat_NetworkPortKindLocalHostIPv6(Int o)
{
    return Stat_Var_NetworkPortKindLocalHostIPv6;
}
Int Stat_NetworkPortKindAny(Int o)
{
    return Stat_Var_NetworkPortKindAny;
}
Int Stat_NetworkPortKindAnyIPv6(Int o)
{
    return Stat_Var_NetworkPortKindAnyIPv6;
}
Int Stat_NetworkPortKindAnyIPv4(Int o)
{
    return Stat_Var_NetworkPortKindAnyIPv4;
}
