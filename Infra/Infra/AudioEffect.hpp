#pragma once

#include <QSoundEffect>
#include <QUrl>
#include <QString>

#include "Probate.hpp"

struct AudioEffect
{
    Int Source;
    Int Volume;
    QSoundEffect* Intern;
};

#define CP(a) ((AudioEffect*)(a))
