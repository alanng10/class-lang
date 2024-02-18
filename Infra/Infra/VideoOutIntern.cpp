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

    aa = VideoOut_GetFrame(videoOut);



    Int oo;

    oo = VideoFrame_GetIntern(aa);




    QVideoFrame* u;

    u = (QVideoFrame*)oo;


    *u = frame;




    VideoOut_FrameChange(videoOut);
}





