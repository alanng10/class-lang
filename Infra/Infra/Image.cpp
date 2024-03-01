#include "Image.hpp"

CppClassNew(Image)

QImage::Format Image_Var_Format = QImage::Format_ARGB32;

Int Image_Init(Int o)
{
    Image* m;

    m = CP(o);





    m->Intern = new QImage(0, 0, Image_Var_Format);



    Image_SetVideoOut(o);




    return true;
}

Int Image_Final(Int o)
{
    Image* m;

    m = CP(o);




    delete m->Intern;




    return true;
}

Int Image_CreateData(Int o)
{
    Image* m;

    m = CP(o);




    Int size;

    size = m->Size;



    Int data;

    data = m->Data;




    Int width;


    Int height;


    width = Size_WidthGet(size);


    height = Size_HeightGet(size);




    int widthU;


    int heightU;


    widthU = width;


    heightU = height;





    Int dataValue;


    dataValue = Data_ValueGet(data);



    uchar* dataValueU;

    dataValueU = (uchar*)dataValue;





    Int pixelByteCount;

    pixelByteCount = 4;




    Int stride;

    stride = width * pixelByteCount;




    qsizetype bytePerLine;

    bytePerLine = stride;




    QImage::Format format;

    format = Image_Var_Format;





    QImage u;

    u = QImage(dataValueU, widthU, heightU, bytePerLine, format);



    (*(m->Intern)) = u;




    return true;
}

Int Image_SetReadIntern(Int o, Int value)
{
    Image* m;

    m = CP(o);




    QImage* u;

    u = (QImage*)value;




    (*(m->Intern)) = *u;




    int widthU;

    int heightU;


    widthU = m->Intern->width();


    heightU = m->Intern->height();




    const uchar* dataValueU;

    dataValueU = m->Intern->constBits();



    qsizetype dataCountU;

    dataCountU = m->Intern->sizeInBytes();




    Int width;

    Int height;


    width = widthU;

    height = heightU;



    Int size;

    size = m->Size;


    Size_WidthSet(size, width);


    Size_HeightSet(size, height);




    Int dataCount;

    dataCount = dataCountU;



    Int dataValue;

    dataValue = CastInt(dataValueU);




    Int data;

    data = m->Data;




    Data_CountSet(data, dataCount);



    Data_ValueSet(data, dataValue);





    return true;
}

CppField(Image, Size)
CppField(Image, Data)

Int Image_GetVideoOut(Int o)
{
    Image* m;

    m = CP(o);



    return m->VideoOut;
}

Int Image_GetRowByteCount(Int o)
{
    Image* m;

    m = CP(o);



    qsizetype u;

    u = m->Intern->bytesPerLine();



    Int a;

    a = u;


    return a;
}







Int Image_SetVideoOut(Int o)
{
    Image* m;

    m = CP(o);



    QPaintDevice* uu;

    uu = m->Intern;



    Int ua;

    ua = CastInt(uu);




    Int alphaFlag;

    alphaFlag = 1;

    alphaFlag = alphaFlag << 59;



    ua = ua | alphaFlag;



    m->VideoOut = ua;




    return true;
}





Int Image_Intern(Int o)
{
    Image* m;

    m = CP(o);



    Int u;

    u = CastInt(m->Intern);



    return u;
}

