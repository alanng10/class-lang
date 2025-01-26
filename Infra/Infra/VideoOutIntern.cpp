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

    Int k;
    k = VideoOut_FrameGet(videoOut);

    Int ka;
    ka = VideoFrame_Intern(k);

    QVideoFrame* u;
    u = (QVideoFrame*)ka;
    *u = frame;

    VideoOut_FrameEvent(videoOut);
}