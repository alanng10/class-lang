#pragma once

#include <QVideoFrame>

#include "Pronate.hpp"

struct VideoFrame
{
    Int Size;
    QVideoFrame* Intern;
};

#define CP(a) ((VideoFrame*)(a))
