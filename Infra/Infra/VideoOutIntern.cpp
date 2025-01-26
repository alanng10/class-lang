#include "VideoOutIntern.hpp"

Bool VideoOutIntern::Init()
{
    connect(this, &QVideoSink::videoFrameChanged, this, &VideoOutIntern::FrameEventHandle);
    return true;
}

void VideoOutIntern::FrameEventHandle(const QVideoFrame& frame)
{
    Int videoOut;
    videoOut = this->VideoOut;

    VideoOut_FrameEvent(videoOut);
}