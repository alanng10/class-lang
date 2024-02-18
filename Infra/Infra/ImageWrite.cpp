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







Int ImageWrite_GetStream(Int o)
{
    ImageWrite* m;

    m = CP(o);


    return m->Stream;
}





Int ImageWrite_SetStream(Int o, Int value)
{
    ImageWrite* m;

    m = CP(o);


    m->Stream = value;


    return true;
}






Int ImageWrite_GetImage(Int o)
{
    ImageWrite* m;

    m = CP(o);


    return m->Image;
}





Int ImageWrite_SetImage(Int o, Int value)
{
    ImageWrite* m;

    m = CP(o);


    m->Image = value;


    return true;
}






Int ImageWrite_GetFormat(Int o)
{
    ImageWrite* m;

    m = CP(o);


    return m->Format;
}





Int ImageWrite_SetFormat(Int o, Int value)
{
    ImageWrite* m;

    m = CP(o);


    m->Format = value;


    return true;
}







Int ImageWrite_GetQuality(Int o)
{
    ImageWrite* m;

    m = CP(o);


    return m->Quality;
}





Int ImageWrite_SetQuality(Int o, Int value)
{
    ImageWrite* m;

    m = CP(o);


    m->Quality = value;


    return true;
}






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

    streamU = Stream_GetIntern(m->Stream);



    Int imageU;

    imageU = Image_GetIntern(m->Image);




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

