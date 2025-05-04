#include "Stat.hpp"

Int Stat_Var_StorageModeRead = QIODeviceBase::ReadOnly;
Int Stat_Var_StorageModeWrite = QIODeviceBase::WriteOnly;
Int Stat_Var_StorageModeNew = QIODeviceBase::NewOnly;
Int Stat_Var_StorageModeExist = QIODeviceBase::ExistingOnly;

Int Stat_StorageModeRead(Int o)
{
    return Stat_Var_StorageModeRead;
}
Int Stat_StorageModeWrite(Int o)
{
    return Stat_Var_StorageModeWrite;
}
Int Stat_StorageModeNew(Int o)
{
    return Stat_Var_StorageModeNew;
}
Int Stat_StorageModeExist(Int o)
{
    return Stat_Var_StorageModeExist;
}
