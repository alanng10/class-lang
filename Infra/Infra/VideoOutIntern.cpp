#include "VideoOutIntern.hpp"

Bool VideoOutIntern::Init()
{
    connect(this, &QVideoSink::videoFrameChanged, this, &VideoOutIntern::FrameChangeHandle);
    return true;
}

void VideoOutIntern::FrameChangeHandle(const QVideoFrame& frame)
{
    Int videoOut;
    videoOut = this->VideoOut;

    Int aa;
    aa = VideoOut_FrameGet(videoOut);

    Int oo;
    oo = VideoFrame_Intern(aa);

    QVideoFrame* u;
    u = (QVideoFrame*)oo;
    *u = frame;

    VideoOut_FrameChange(videoOut);
}