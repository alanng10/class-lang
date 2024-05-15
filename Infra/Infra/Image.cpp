#include "Image.hpp"

CppClassNew(Image)

QImage::Format Image_Var_Format = QImage::Format_ARGB32;

Int Image_Init(Int o)
{
    Image* m;
    m = CP(o);

    Int dataCount;
    dataCount = 0;

    Int dataValue;
    dataValue = New(dataCount);

    Data_CountSet(m->Data, dataCount);
    Data_ValueSet(m->Data, dataValue);

    uchar* dataValueU;
    dataValueU = (uchar*)dataValue;

    int width;
    int height;
    width = 0;
    height = 0;

    qsizetype bytePerLine;
    bytePerLine = 0;

    QImage::Format format;
    format = Image_Var_Format;

    m->Intern = new QImage(dataValueU, width, height, bytePerLine, format);

    Image_VideoOutSet(o);
    return true;
}

Int Image_Final(Int o)
{
    Image* m;
    m = CP(o);

    delete m->Intern;

    Int oa;
    oa = Data_ValueGet(m->Data);
    Delete(oa);
    
    return true;
}

Int Image_DataCreate(Int o)
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

    Int pixelByteCount;
    pixelByteCount = 4;

    Int stride;
    stride = width * pixelByteCount;

    Int dataCount;
    dataCount = height * stride;

    Int dataValue;
    dataValue = New(dataCount);

    Data_CountSet(data, dataCount);
    Data_ValueSet(data, dataValue);

    uchar* dataValueU;
    dataValueU = (uchar*)dataValue;

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

    int widthU;
    int heightU;
    widthU = u->width();
    heightU = u->height();

    const uchar* bits;
    bits = u->constBits();

    qsizetype bytePerLine;
    bytePerLine = u->bytesPerLine();

    qsizetype countU;
    countU = heightU * bytePerLine;

    Int count;
    count = countU;

    Int source;
    source = CastInt(bits);

    Int dataValue;
    dataValue = New(count);

    Copy(dataValue, source, count);
    
    Int width;
    Int height;
    width = widthU;
    height = heightU;
    Int size;
    size = m->Size;
    Size_WidthSet(size, width);
    Size_HeightSet(size, height);

    Int data;
    data = m->Data;
    Data_CountSet(data, count);
    Data_ValueSet(data, dataValue);

    uchar* dataValueU;
    dataValueU = (uchar*)dataValue;

    QImage::Format format;
    format = Image_Var_Format;

    QImage ua;
    ua = QImage(dataValueU, widthU, heightU, bytePerLine, format);

    (*(m->Intern)) = ua;
    return true;
}

CppField(Image, Size)
CppField(Image, Data)

Int Image_VideoOut(Int o)
{
    Image* m;
    m = CP(o);
    return m->VideoOut;
}

Int Image_RowByteCountGet(Int o)
{
    Image* m;
    m = CP(o);
    qsizetype u;
    u = m->Intern->bytesPerLine();
    Int a;
    a = u;
    return a;
}

FieldDefaultSet(Image, RowByteCount);

Int Image_VideoOutSet(Int o)
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
    Int a;
    a = CastInt(m->Intern);
    return a;
}