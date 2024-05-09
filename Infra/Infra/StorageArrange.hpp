#pragma once

#include <QString>
#include <QFile>
#include <QIODevice>
#include <QDir>
#include <QStringList>

#include "Probate.hpp"

struct StorageArrange
{
};

#define CP(a) ((StorageOrder*)(a))

Int StorageArrange_FoldCopyRecurse(Int o, Int path, Int destPath);