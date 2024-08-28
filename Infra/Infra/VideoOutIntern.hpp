#pragma once

#include <QVideoSink>
#include <QVideoFrame>

#include "Pronate.hpp"

class VideoOutIntern : public QVideoSink
{
    Q_OBJECT

public:
    Bool Init();

    Int VideoOut;

private slots:

    void FrameChangeHandle(const QVideoFrame &frame);
};

