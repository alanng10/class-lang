#pragma once

#include <QString>
#include <QFile>
#include <QIODevice>
#include <QDir>
#include <QStringList>

#include "Pronate.hpp"

struct StorageArrange
{
};

#define CP(a) ((StorageOrder*)(a))

Int StorageArrange_FoldCopyRecurse(Int o, Int path, Int destPath);

Int StorageArrange_StringCreate(Int o, Int u);
