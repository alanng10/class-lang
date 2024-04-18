#include "Stat.hpp"

Int Stat_Var_StorageStatusNoError = QFileDevice::NoError;
Int Stat_Var_StorageStatusReadError = QFileDevice::ReadError;
Int Stat_Var_StorageStatusWriteError = QFileDevice::WriteError;
Int Stat_Var_StorageStatusFatalError = QFileDevice::FatalError;
Int Stat_Var_StorageStatusResourceError = QFileDevice::ResourceError;
Int Stat_Var_StorageStatusOpenError = QFileDevice::OpenError;
Int Stat_Var_StorageStatusAbortError = QFileDevice::AbortError;
Int Stat_Var_StorageStatusTimeOutError = QFileDevice::TimeOutError;
Int Stat_Var_StorageStatusUnspecifiedError = QFileDevice::UnspecifiedError;
Int Stat_Var_StorageStatusRemoveError = QFileDevice::RemoveError;
Int Stat_Var_StorageStatusRenameError = QFileDevice::RenameError;
Int Stat_Var_StorageStatusPositionError = QFileDevice::PositionError;
Int Stat_Var_StorageStatusResizeError = QFileDevice::ResizeError;
Int Stat_Var_StorageStatusPermissionsError = QFileDevice::PermissionsError;
Int Stat_Var_StorageStatusCopyError = QFileDevice::CopyError;

Int Stat_StorageStatusNoError(Int o)
{
    return Stat_Var_StorageStatusNoError;
}
Int Stat_StorageStatusReadError(Int o)
{
    return Stat_Var_StorageStatusReadError;
}
Int Stat_StorageStatusWriteError(Int o)
{
    return Stat_Var_StorageStatusWriteError;
}
Int Stat_StorageStatusFatalError(Int o)
{
    return Stat_Var_StorageStatusFatalError;
}
Int Stat_StorageStatusResourceError(Int o)
{
    return Stat_Var_StorageStatusResourceError;
}
Int Stat_StorageStatusOpenError(Int o)
{
    return Stat_Var_StorageStatusOpenError;
}
Int Stat_StorageStatusAbortError(Int o)
{
    return Stat_Var_StorageStatusAbortError;
}
Int Stat_StorageStatusTimeOutError(Int o)
{
    return Stat_Var_StorageStatusTimeOutError;
}
Int Stat_StorageStatusUnspecifiedError(Int o)
{
    return Stat_Var_StorageStatusUnspecifiedError;
}
Int Stat_StorageStatusRemoveError(Int o)
{
    return Stat_Var_StorageStatusRemoveError;
}
Int Stat_StorageStatusRenameError(Int o)
{
    return Stat_Var_StorageStatusRenameError;
}
Int Stat_StorageStatusPositionError(Int o)
{
    return Stat_Var_StorageStatusPositionError;
}
Int Stat_StorageStatusResizeError(Int o)
{
    return Stat_Var_StorageStatusResizeError;
}
Int Stat_StorageStatusPermissionsError(Int o)
{
    return Stat_Var_StorageStatusPermissionsError;
}
Int Stat_StorageStatusCopyError(Int o)
{
    return Stat_Var_StorageStatusCopyError;
}
