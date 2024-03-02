#include "Draw.hpp"

CppClassNew(Draw)

Int Draw_Init(Int o)
{
    Draw* m;

    m = CP(o);






    m->InternIdentityTransform = new QTransform();






    QString* uu;

    uu = new QString();


    uu->setRawData(null, 0);



    m->InternText = uu;





    QFont* ua;

    ua = new QFont(QApplication::font());



    m->InternDefaultFont = ua;





    QPainter* u;

    u = new QPainter();



    m->Intern = u;




    return true;
}

Int Draw_Final(Int o)
{
    Draw* m;

    m = CP(o);




    delete m->Intern;




    delete m->InternDefaultFont;




    delete m->InternText;




    delete m->InternIdentityTransform;





    return true;
}

CppField(Draw, Size)
CppFieldGet(Draw, Out)

Int Draw_OutSet(Int o, Int value)
{
    Draw* m;

    m = CP(o);




    Int oa;

    oa = value;



    Int alphaFlag;

    alphaFlag = 1;

    alphaFlag = alphaFlag << 59;




    Bool b;

    b = !((oa & alphaFlag) == 0);




    Int ob;

    ob = alphaFlag;

    ob = ~ob;




    oa = oa & ob;



    m->OutAlpha = b;



    m->Out = oa;




    return true;
}

CppField(Draw, Area)

Int Draw_Start(Int o)
{
    Draw* m;

    m = CP(o);





    Int out;

    out = m->Out;





    QPaintDevice* uu;


    uu = (QPaintDevice*)(out);



    m->Intern->begin(uu);





    return true;
}

Int Draw_End(Int o)
{
    Draw* m;

    m = CP(o);



    m->Intern->end();




    return true;
}

CppFieldGet(Draw, Brush)

Int Draw_BrushSet(Int o, Int value)
{
    Draw* m;

    m = CP(o);




    m->Brush = value;




    if (m->Brush == null)
    {
        m->Intern->setBrush(Qt::NoBrush);


        return true;
    }





    Int u;

    u = Brush_Intern(m->Brush);



    QBrush* uu;

    uu = (QBrush*)u;




    m->Intern->setBrush(*uu);




    return true;
}

CppFieldGet(Draw, Pen)

Int Draw_PenSet(Int o, Int value)
{
    Draw* m;

    m = CP(o);




    m->Pen = value;




    if (m->Pen == null)
    {
        m->Intern->setPen(Qt::NoPen);


        return true;
    }




    Int u;

    u = Pen_Intern(m->Pen);



    QPen* uu;

    uu = (QPen*)u;




    m->Intern->setPen(*uu);




    return true;
}

CppFieldGet(Draw, Font)

Int Draw_FontSet(Int o, Int value)
{
    Draw* m;

    m = CP(o);




    m->Font = value;




    if (m->Font == null)
    {
        m->Intern->setFont(*(m->InternDefaultFont));


        return true;
    }




    Int u;

    u = Font_Intern(m->Font);



    QFont* uu;

    uu = (QFont*)u;




    m->Intern->setFont(*uu);




    return true;
}

CppFieldGet(Draw, Transform)

Int Draw_TransformSet(Int o, Int value)
{
    Draw* m;

    m = CP(o);




    m->Transform = value;




    if (m->Transform == null)
    {
        m->Intern->setWorldTransform((*(m->InternIdentityTransform)), false);


        return true;
    }





    Int u;

    u = Transform_Intern(m->Transform);



    QTransform* uu;


    uu = (QTransform*)u;





    m->Intern->setWorldTransform(*uu, false);




    return true;
}

CppField(Draw, FillPos)
CppFieldGet(Draw, Composite)

Int Draw_CompositeSet(Int o, Int value)
{
    Draw* m;

    m = CP(o);




    m->Composite = value;



    if (m->Composite == null)
    {
        m->Intern->setCompositionMode(QPainter::CompositionMode_SourceOver);


        return true;
    }




    Int k;

    k = m->Composite - 1;



    QPainter::CompositionMode u;

    u = (QPainter::CompositionMode)k;




    if (!(m->OutAlpha))
    {
        if (!((u < QPainter::CompositionMode_Source) | (QPainter::CompositionMode_DestinationAtop < u)))
        {
            m->Intern->setCompositionMode(QPainter::CompositionMode_SourceOver);


            return true;
        }
    }



    m->Intern->setCompositionMode(u);




    return true;
}

Int Draw_SetDrawFillPos(Int o)
{
    Draw* m;

    m = CP(o);




    Int left;

    Int up;


    left = Pos_LeftGet(m->FillPos);

    up = Pos_UpGet(m->FillPos);




    int leftU;

    int upU;



    leftU = left;

    upU = up;




    m->Intern->setBrushOrigin(leftU, upU);




    return true;
}






Int Draw_SetDrawArea(Int o)
{
    Draw* m;

    m = CP(o);





    Int aRect;

    aRect = m->Area;




    RectValue(a);





    int l;

    int u;

    int w;

    int h;



    l = aLeft;

    u = aUp;

    w = aWidth;

    h = aHeight;



    if (l < 0)
    {
        l = 0;
    }


    if (u < 0)
    {
        u = 0;
    }


    if (w < 0)
    {
        w = 0;
    }


    if (h < 0)
    {
        h = 0;
    }




    m->Intern->setWorldMatrixEnabled(false);



    m->Intern->setClipRect(l, u, w, h, Qt::ReplaceClip);



    m->Intern->setWorldMatrixEnabled(true);




    return true;
}

Int Draw_Clear(Int o, Int color)
{
    Draw* m;

    m = CP(o);




    Int size;

    size = m->Size;



    Int width;

    Int height;


    width = Size_WidthGet(size);

    height = Size_HeightGet(size);



    int w;

    int h;


    w = width;

    h = height;





    Int32 uu;

    uu = (Int32)color;



    QRgb kk;

    kk = uu;



    QColor colorU;

    colorU = QColor(kk);





    m->Intern->fillRect(0, 0, w, h, colorU);






    return true;
}

Int Draw_ExecuteLine(Int o, Int startPos, Int endPos)
{
    Draw* m;

    m = CP(o);




    Int startLeft;

    Int startUp;


    startLeft = Pos_LeftGet(startPos);

    startUp = Pos_UpGet(startPos);




    Int endLeft;

    Int endUp;


    endLeft = Pos_LeftGet(endPos);

    endUp = Pos_UpGet(endPos);





    int sl;

    int su;

    int el;

    int eu;



    sl = (int)startLeft;

    su = (int)startUp;

    el = (int)endLeft;

    eu = (int)endUp;




    m->Intern->drawLine(sl, su, el, eu);




    return true;
}

Int Draw_ExecuteArc(Int o, Int rect, Int angleRange)
{
    Draw* m;

    m = CP(o);




    Int aRect;

    aRect = rect;



    RectValue(a);




    int l;

    int u;

    int w;

    int h;



    l = (int)aLeft;

    u = (int)aUp;

    w = (int)aWidth;

    h = (int)aHeight;




    Int angleStart;

    Int angleEnd;


    angleStart = Range_StartGet(angleRange);

    angleEnd = Range_EndGet(angleRange);




    int startA;

    int spanA;


    startA = (int)angleStart;

    spanA = (int)angleEnd;




    m->Intern->drawArc(l, u, w, h, startA, spanA);





    return true;
}

Int Draw_ExecuteChord(Int o, Int rect, Int angleRange)
{
    Draw* m;

    m = CP(o);





    Int aRect;

    aRect = rect;



    RectValue(a);




    int l;

    int u;

    int w;

    int h;



    l = (int)aLeft;

    u = (int)aUp;

    w = (int)aWidth;

    h = (int)aHeight;




    Int angleStart;

    Int angleEnd;


    angleStart = Range_StartGet(angleRange);

    angleEnd = Range_EndGet(angleRange);




    int startA;

    int spanA;


    startA = (int)angleStart;

    spanA = (int)angleEnd;




    m->Intern->drawChord(l, u, w, h, startA, spanA);





    return true;
}







Int Draw_ExecutePie(Int o, Int rect, Int angleRange)
{
    Draw* m;

    m = CP(o);





    Int aRect;

    aRect = rect;



    RectValue(a);




    int l;

    int u;

    int w;

    int h;



    l = (int)aLeft;

    u = (int)aUp;

    w = (int)aWidth;

    h = (int)aHeight;




    Int angleStart;

    Int angleEnd;


    angleStart = Range_StartGet(angleRange);

    angleEnd = Range_EndGet(angleRange);



    int startA;

    int spanA;


    startA = (int)angleStart;

    spanA = (int)angleEnd;




    m->Intern->drawPie(l, u, w, h, startA, spanA);





    return true;
}

Int Draw_ExecuteEllipse(Int o, Int rect)
{
    Draw* m;

    m = CP(o);





    Int aRect;

    aRect = rect;



    RectValue(a);




    int l;

    int u;

    int w;

    int h;



    l = (int)aLeft;

    u = (int)aUp;

    w = (int)aWidth;

    h = (int)aHeight;






    m->Intern->drawEllipse(l, u, w, h);





    return true;
}

Int Draw_ExecuteRect(Int o, Int rect)
{
    Draw* m;

    m = CP(o);




    Int aRect;

    aRect = rect;



    RectValue(a);




    int l;

    int u;

    int w;

    int h;



    l = (int)aLeft;

    u = (int)aUp;

    w = (int)aWidth;

    h = (int)aHeight;



    m->Intern->drawRect(l, u, w, h);




    return true;
}

Int Draw_ExecuteRoundRect(Int o, Int rect, Int horizRadius, Int vertRadius)
{
    Draw* m;

    m = CP(o);




    Int aRect;

    aRect = rect;



    RectValue(a);




    int l;

    int u;

    int w;

    int h;



    l = (int)aLeft;

    u = (int)aUp;

    w = (int)aWidth;

    h = (int)aHeight;





    Int ua;

    ua = GetInternValue(horizRadius);



    qreal horizRadiusU;

    horizRadiusU = CastIntToDouble(ua);




    Int ub;

    ub = GetInternValue(vertRadius);



    qreal vertRadiusU;

    vertRadiusU = CastIntToDouble(ub);




    m->Intern->drawRoundedRect(l, u, w, h, horizRadiusU, vertRadiusU);




    return true;
}

Int Draw_ExecutePolygon(Int o, Int pointListCount, Int pointListData)
{
    Draw* m;

    m = CP(o);




    int countU;

    countU = pointListCount;




    Int dataValue;

    dataValue = Data_ValueGet(pointListData);




    QPoint* u;

    u = (QPoint*)dataValue;




    m->Intern->drawConvexPolygon(u, countU);




    return true;
}

Int Draw_ExecutePolyline(Int o, Int pointListCount, Int pointListData)
{
    Draw* m;

    m = CP(o);




    int countU;

    countU = pointListCount;




    Int dataValue;

    dataValue = Data_ValueGet(pointListData);




    QPoint* u;

    u = (QPoint*)dataValue;




    m->Intern->drawPolyline(u, countU);




    return true;
}

Int Draw_ExecuteImage(Int o, Int image, Int destRect, Int sourceRect)
{
    Draw* m;

    m = CP(o);





    Int ua;

    ua = Image_Intern(image);



    QImage* ub;

    ub = (QImage*)ua;






    RectValue(dest);



    RectValue(source);






    int dl;

    int du;

    int dw;

    int dh;



    dl = (int)destLeft;

    du = (int)destUp;

    dw = (int)destWidth;

    dh = (int)destHeight;




    int sl;

    int su;

    int sw;

    int sh;



    sl = (int)sourceLeft;

    su = (int)sourceUp;

    sw = (int)sourceWidth;

    sh = (int)sourceHeight;





    QRect destRectA(dl, du, dw, dh);



    QRect sourceRectA(sl, su, sw, sh);




    m->Intern->drawImage(destRectA, *ub, sourceRectA);





    return true;
}

Int Draw_ExecuteText(Int o, Int destRect, Int flag, Int text, Int boundRect)
{
    Draw* m;

    m = CP(o);






    RectValue(dest);




    int l;

    int u;

    int w;

    int h;



    l = (int)destLeft;

    u = (int)destUp;

    w = (int)destWidth;

    h = (int)destHeight;



    int flagU;

    flagU = (int)flag;






    Int ua;

    ua = CastInt(m->InternText);



    String_QStringSetRaw(ua, text);






    QRect boundRectA;




    m->Intern->drawText(l, u, w, h, flagU, *(m->InternText), &boundRectA);




    m->InternText->setRawData(null, 0);





    int boundL;

    int boundU;

    int boundW;

    int boundH;



    boundL = boundRectA.left();

    boundU = boundRectA.top();

    boundW = boundRectA.width();

    boundH = boundRectA.height();



    SInt boundSL;

    SInt boundSU;


    boundSL = boundL;

    boundSU = boundU;



    Int boundLeft;

    Int boundUp;

    Int boundWidth;

    Int boundHeight;



    boundLeft = boundSL;

    boundUp = boundSU;

    boundWidth = boundW;

    boundHeight = boundH;




    Int boundPos;

    boundPos = Rect_PosGet(boundRect);

    Int boundSize;

    boundSize = Rect_SizeGet(boundRect);



    Pos_LeftSet(boundPos, boundLeft);

    Pos_UpSet(boundPos, boundUp);


    Size_WidthSet(boundSize, boundWidth);

    Size_HeightSet(boundSize, boundHeight);




    return true;
}

Int Draw_Intern(Int o)
{
    Draw* m;

    m = CP(o);



    Int u;

    u = CastInt(m->Intern);



    return u;
}