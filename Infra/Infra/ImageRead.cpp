#include "ImageRead.hpp"

CppClassNew(ImageRead)

Int ImageRead_Init(Int o)
{
    ImageRead* m;
    m = CP(o);
    QImageReader* u;
    u = new QImageReader;
    m->Intern = u;
    return true;
}

Int ImageRead_Final(Int o)
{
    ImageRead* m;
    m = CP(o);

    delete m->Intern;
    return true;
}

CppField(ImageRead, Stream)
CppField(ImageRead, Image)

Int ImageRead_Execute(Int o)
{
    ImageRead* m;
    m = CP(o);
    Int stream;
    stream = m->Stream;
    Int image;
    image = m->Image;

    Int ua;
    ua = Stream_Intern(stream);
    QIODevice* ub;
    ub = (QIODevice*)ua;
    m->Intern->setDevice(ub);

    QImage oo;

    bool bu;
    bu = m->Intern->read(&oo);

    m->Intern->setDevice(null);

    Bool bo;
    bo = bu;
    if (!bo)
    {
        return false;
    }

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