#pragma once

#include <QMediaPlayer>
#include <QAudioOutput>

#include "VideoOutIntern.hpp"

#include "Probate.hpp"

struct Play
{
    Int Source;
    Int VideoOut;
    Int AudioOut;
    QMediaPlayer* Intern;
};

#define CP(a) ((Play*)(a))
