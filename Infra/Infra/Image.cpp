#include "Image.hpp"

CppClassNew(Image)

QImage::Format Image_Var_Format = QImage::Format_ARGB32;

Int Image_Init(Int o)
{
    Image* m;
    m = CP(o);

    Size_WidthSet(m->Size, 0);
    Size_HegthSet(m->Size, 0);

    Int dataCount;
    dataCount = 0;

    Int dataValue;
    dataValue = Environ_New(dataCount);

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

    Image_OutSet(o);
    return true;
}

Int Image_Final(Int o)
{
    Image* m;
    m = CP(o);

    delete m->Intern;

    Int oa;
    oa = Data_ValueGet(m->Data);
    Environ_Delete(oa);
    
    return true;
}

Int Image_DataCreate(Int o)
{
    Image* m;
    m = CP(o);

    Int oa;
    oa = Data_ValueGet(m->Data);
    Environ_Delete(oa);

    Int size;
    size = m->Size;
    Int data;
    data = m->Data;

    Int width;
    Int hegth;
    width = Size_WidthGet(size);
    hegth = Size_HegthGet(size);
    int widthU;
    int hegthU;
    widthU = width;
    hegthU = hegth;

    Int pixelByteCount;
    pixelByteCount = 4;

    Int rowByteCount;
    rowByteCount = width * pixelByteCount;

    Int dataCount;
    dataCount = hegth * rowByteCount;

    Int dataValue;
    dataValue = Environ_New(dataCount);

    Data_CountSet(data, dataCount);
    Data_ValueSet(data, dataValue);

    uchar* dataValueU;
    dataValueU = (uchar*)dataValue;

    qsizetype bytePerLine;
    bytePerLine = rowByteCount;

    QImage::Format format;
    format = Image_Var_Format;

    QImage u;
    u = QImage(dataValueU, widthU, hegthU, bytePerLine, format);

    (*(m->Intern)) = u;
    return true;
}

Int Image_SetReadIntern(Int o, Int value)
{
    Image* m;
    m = CP(o);

    Int oa;
    oa = Data_ValueGet(m->Data);
    Environ_Delete(oa);
    
    QImage* u;
    u = (QImage*)value;

    int widthU;
    int hegthU;
    widthU = u->width();
    hegthU = u->height();

    const uchar* bits;
    bits = u->constBits();

    qsizetype bytePerLine;
    bytePerLine = u->bytesPerLine();

    Int width;
    Int hegth;
    width = widthU;
    hegth = hegthU;
    
    Int rowByteCount;
    rowByteCount = bytePerLine;

    Int pixelByteCount;
    pixelByteCount = 4;

    Int dataCount;
    dataCount = width * hegth * pixelByteCount;

    Int dataValue;
    dataValue = Environ_New(dataCount);

    Int source;
    source = CastInt(bits);

    Image_DataCopy(o, dataValue, source, width, hegth, rowByteCount);

    Int size;
    size = m->Size;
    Size_WidthSet(size, width);
    Size_HegthSet(size, hegth);

    Int data;
    data = m->Data;
    Data_ValueSet(data, dataValue);
    Data_CountSet(data, dataCount);

    uchar* dataValueU;
    dataValueU = (uchar*)dataValue;

    Int ka;
    ka = width * pixelByteCount;
    qsizetype uua;
    uua = ka;

    QImage::Format format;
    format = Image_Var_Format;

    QImage ua;
    ua = QImage(dataValueU, widthU, hegthU, uua, format);

    (*(m->Intern)) = ua;
    return true;
}

Int Image_DataCopy(Int o, Int dest, Int source, Int width, Int height, Int rowByteCount)
{
    Byte* destU;
    Byte* sourceU;
    destU = (Byte*)dest;
    sourceU = (Byte*)source;

    Int kk;
    kk = 4;

    Int count;
    Int countA;
    count = height;
    countA = width;
    
    Int i;
    Int j;
    i = 0;
    j = 0;
    while (i < count)
    {
        j = 0;
        while (j < countA)
        {
            Byte* p;
            Byte* pa;
            
            p = destU + (i * width + j) * kk;
            pa = sourceU + (i * rowByteCount) + j * kk;

            Int32* d;
            Int32* da;

            d = (Int32*)p;
            da = (Int32*)pa;

            *d = *da;

            j = j + 1;
        }

        i = i + 1;
    }
    return true;
}

CppField(Image, Size)
CppField(Image, Data)

Int Image_Out(Int o)
{
    Image* m;
    m = CP(o);
    return m->Out;
}

Int Image_OutSet(Int o)
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

    m->Out = ua;
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