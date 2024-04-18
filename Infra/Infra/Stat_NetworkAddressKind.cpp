#include "Stat.hpp"

Int Stat_Var_NetworkAddressKindIPv6 = 1;
Int Stat_Var_NetworkAddressKindIPv4 = 2;
Int Stat_Var_NetworkAddressKindBroadcast = QHostAddress::Broadcast + 2;
Int Stat_Var_NetworkAddressKindLocalHost = QHostAddress::LocalHost + 2;
Int Stat_Var_NetworkAddressKindLocalHostIPv6 = QHostAddress::LocalHostIPv6 + 2;
Int Stat_Var_NetworkAddressKindAny = QHostAddress::Any + 2;
Int Stat_Var_NetworkAddressKindAnyIPv6 = QHostAddress::AnyIPv6 + 2;
Int Stat_Var_NetworkAddressKindAnyIPv4 = QHostAddress::AnyIPv4 + 2;

Int Stat_NetworkAddressKindIPv6(Int o)
{
    return Stat_Var_NetworkAddressKindIPv6;
}
Int Stat_NetworkAddressKindIPv4(Int o)
{
    return Stat_Var_NetworkAddressKindIPv4;
}
Int Stat_NetworkAddressKindBroadcast(Int o)
{
    return Stat_Var_NetworkAddressKindBroadcast;
}
Int Stat_NetworkAddressKindLocalHost(Int o)
{
    return Stat_Var_NetworkAddressKindLocalHost;
}
Int Stat_NetworkAddressKindLocalHostIPv6(Int o)
{
    return Stat_Var_NetworkAddressKindLocalHostIPv6;
}
Int Stat_NetworkAddressKindAny(Int o)
{
    return Stat_Var_NetworkAddressKindAny;
}
Int Stat_NetworkAddressKindAnyIPv6(Int o)
{
    return Stat_Var_NetworkAddressKindAnyIPv6;
}
Int Stat_NetworkAddressKindAnyIPv4(Int o)
{
    return Stat_Var_NetworkAddressKindAnyIPv4;
}
