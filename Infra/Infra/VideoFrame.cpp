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







Int VideoFrame_GetSize(Int o)
{
    VideoFrame* m;

    m = CP(o);


    return m->Size;
}




Int VideoFrame_SetSize(Int o, Int value)
{
    VideoFrame* m;

    m = CP(o);


    m->Size = value;


    return true;
}







Int VideoFrame_GetImage(Int o, Int image)
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






Int VideoFrame_GetIntern(Int o)
{
    VideoFrame* m;

    m = CP(o);



    Int u;

    u = CastInt(m->Intern);



    return u;
}



