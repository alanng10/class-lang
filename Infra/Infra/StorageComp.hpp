#pragma once

#include <QString>
#include <QFile>
#include <QIODevice>
#include <QDir>
#include <QFileInfo>
#include <QStringList>

#include "Pronate.hpp"

struct StorageComp
{
};

#define CP(a) ((StorageComp*)(a))

Int StorageComp_FoldCopyRecurse(Int o, Int path, Int destPath);

Int StorageComp_StringCreate(Int o, Int u);
