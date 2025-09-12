#include "StorageEntry.h"

InfraClassNew(StorageEntry)

Int StorageEntry_Init(Int o)
{
    return true;
}

Int StorageEntry_Final(Int o)
{
    return true;
}

Field(StorageEntry, Name)
Field(StorageEntry, Exist)
Field(StorageEntry, Fold)
Field(StorageEntry, Size);
Field(StorageEntry, CreateTime)
Field(StorageEntry, ModifyTime)
Field(StorageEntry, Owner)
Field(StorageEntry, Group)
Field(StorageEntry, Permit)