#include "ImageRead.hpp"




CppClassNew(ImageRead)







Bool ImageRead_Init(Int o)
{
    ImageRead* m;

    m = CP(o);




    QImageReader* u;


    u = new QImageReader();



    m->Intern = u;



    return true;
}





Bool ImageRead_Final(Int o)
{
    ImageRead* m;

    m = CP(o);



    delete m->Intern;



    return true;
}







Int ImageRead_GetStream(Int o)
{
    ImageRead* m;

    m = CP(o);


    return m->Stream;
}





Bool ImageRead_SetStream(Int o, Int value)
{
    ImageRead* m;

    m = CP(o);


    m->Stream = value;


    return true;
}







Int ImageRead_GetImage(Int o)
{
    ImageRead* m;

    m = CP(o);


    return m->Image;
}





Bool ImageRead_SetImage(Int o, Int value)
{
    ImageRead* m;

    m = CP(o);


    m->Image = value;


    return true;
}









Bool ImageRead_Execute(Int o)
{
    ImageRead* m;

    m = CP(o);




    Int stream;

    stream = m->Stream;




    Int image;

    image = m->Image;




    Int ua;

    ua = Stream_GetIntern(stream);



    QIODevice* ub;

    ub = (QIODevice*)ua;



    m->Intern->setDevice(ub);





    QImage oo;



    bool bu;


    bu = m->Intern->read(&oo);



    Bool bo;

    bo = bu;


    if (!bo)
    {
        return false;
    }





    m->Intern->setDevice(null);





    QImage::Format format;

    format = QImage::Format_ARGB32;



    if (!(oo.format() == format))
    {
        oo.convertTo(format);
    }




    Int oa;

    oa = CastInt(&oo);



    Image_SetReadIntern(image, oa);





    return true;
}

