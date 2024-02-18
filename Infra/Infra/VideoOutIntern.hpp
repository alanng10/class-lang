#pragma once





#include <QVideoSink>
#include <QVideoFrame>



#include "Probate.hpp"






class VideoOutIntern : public QVideoSink
{
    Q_OBJECT


public:

    Bool Init();


    Int VideoOut;



private slots:

    void FrameChangeHandle(const QVideoFrame &frame);
};

