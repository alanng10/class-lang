#pragma once

#include <QStringEncoder>
#include <QStringDecoder>
#include <QByteArrayView>
#include <QStringView>

#include "Probate.hpp"

struct TextEncode
{
    Int Kind;
    Int WriteBom;
    QStringEncoder* InternEncode;
    QStringDecoder* InternDecode;
};

#define CP(a) ((TextEncode*)(a))
