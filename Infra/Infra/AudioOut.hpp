#pragma once

#include <QAudioOutput>

#include "Pronate.hpp"

struct AudioOut
{
    Int Muted;
    Int Volume;
    QAudioOutput* Intern;
};

#define CP(a) ((AudioOut*)(a))
