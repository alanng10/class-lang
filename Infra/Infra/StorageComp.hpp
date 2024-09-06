#pragma once

#include <QString>
#include <QFile>
#include <QIODevice>
#include <QDir>
#include <QStringList>

#include "Pronate.hpp"

struct StorageComp
{
};

#define CP(a) ((StorageOrder*)(a))

Int StorageComp_FoldCopyRecurse(Int o, Int path, Int destPath);

Int StorageComp_EntryList(Int o, Int path, Int filter);

Int StorageComp_StringCreate(Int o, Int u);
