#pragma once

#include <QString>
#include <QFile>
#include <QIODevice>
#include <QDir>
#include <QFileInfo>
#include <QDateTime>
#include <QStringList>

#include "Pronate.hpp"

struct StorageComp
{
};

#define CP(a) ((StorageComp*)(a))

Int StorageComp_FoldCopyRecurse(Int o, Int path, Int destPath);

Int StorageComp_EntryQFileInfo(Int o, Int result, Int fileInfo);

Int StorageComp_StringCreate(Int o, Int u);

Int StorageComp_FlagSet(Int value, Int shift, Int bit);