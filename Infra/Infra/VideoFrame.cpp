#include "VideoFrame.hpp"




CppClassNew(VideoFrame)







Int VideoFrame_Init(Int o)
{
    VideoFrame* m;

    m = CP(o);



    m->Intern = new QVideoFrame;



    return true;
}





Int VideoFrame_Final(Int o)
{
    VideoFrame* m;

    m = CP(o);



    delete m->Intern;



    return true;
}

CppField(VideoFrame, Size)






Int VideoFrame_Image(Int o, Int image)
{
    VideoFrame* m;

    m = CP(o);




    QImage ua;

    ua = m->Intern->toImage();




    QImage::Format format;

    format = QImage::Format_ARGB32;



    if (!(ua.format() == format))
    {
        ua.convertTo(format);
    }




    Int ub;

    ub = CastInt(&ua);




    Image_SetReadIntern(image, ub);





    return true;
}

Int VideoFrame_Intern(Int o)
{
    VideoFrame* m;

    m = CP(o);



    Int u;

    u = CastInt(m->Intern);



    return u;
}