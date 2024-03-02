#include "ImageWrite.hpp"

CppClassNew(ImageWrite)

const char* ImageWrite_Var_Format[] =
{
    "BMP",
    "JPG",
    "PNG",
};

Int ImageWrite_Init(Int o)
{
    ImageWrite* m;

    m = CP(o);




    m->Quality = 100;




    QImageWriter* u;


    u = new QImageWriter;



    m->Intern = u;



    return true;
}

Int ImageWrite_Final(Int o)
{
    ImageWrite* m;

    m = CP(o);



    delete m->Intern;



    return true;
}

CppField(ImageWrite, Stream)
CppField(ImageWrite, Image)
CppField(ImageWrite, Format)
CppField(ImageWrite, Quality)

Int ImageWrite_Execute(Int o)
{
    ImageWrite* m;

    m = CP(o);




    Int format;

    format = m->Format;



    if (format == null)
    {
        return false;
    }



    Int streamU;

    streamU = Stream_Intern(m->Stream);



    Int imageU;

    imageU = Image_Intern(m->Image);




    Int formatU;

    formatU = format - 1;



    int qualityU;

    qualityU = m->Quality;





    QIODevice* oa;

    oa = (QIODevice*)streamU;





    const char* ooa;

    ooa = ImageWrite_Var_Format[formatU];



    QByteArray ob;

    ob = QByteArray(ooa);




    QImage* oc;

    oc = (QImage*)imageU;







    m->Intern->setDevice(oa);



    m->Intern->setFormat(ob);



    m->Intern->setQuality(qualityU);




    bool bu;

    bu = m->Intern->write(*oc);




    Bool a;

    a = bu;


    return a;
}

