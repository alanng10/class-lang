#include "Draw.hpp"

CppClassNew(Draw)

Int Draw_Init(Int o)
{
    Draw* m;
    m = CP(o);

    m->InternIdentityForm = new QTransform;

    QString* uu;
    uu = new QString;
    uu->setRawData(null, 0);
    m->InternText = uu;

    QFont* ua;
    ua = new QFont(QApplication::font());
    m->InternDefaultFace = ua;

    QPainter* u;
    u = new QPainter;
    m->Intern = u;
    return true;
}

Int Draw_Final(Int o)
{
    Draw* m;
    m = CP(o);

    delete m->Intern;
    delete m->InternDefaultFace;
    delete m->InternText;
    delete m->InternIdentityForm;
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

CppFieldGet(Draw, Fill)

Int Draw_FillSet(Int o, Int value)
{
    Draw* m;
    m = CP(o);
    m->Fill = value;
    if (m->Fill == null)
    {
        m->Intern->setBrush(Qt::NoBrush);
        return true;
    }

    Int u;
    u = Brush_InternBrush(m->Fill);
    QBrush* uu;
    uu = (QBrush*)u;
    m->Intern->setBrush(*uu);
    return true;
}

CppFieldGet(Draw, Stroke)

Int Draw_StrokeSet(Int o, Int value)
{
    Draw* m;
    m = CP(o);
    m->Stroke = value;
    if (m->Stroke == null)
    {
        m->Intern->setPen(Qt::NoPen);
        return true;
    }

    Int u;
    u = Brush_Intern(m->Stroke);

    if (u == null)
    {
        m->Intern->setPen(Qt::NoPen);
        return true;
    }
    
    QPen* uu;
    uu = (QPen*)u;
    m->Intern->setPen(*uu);
    return true;
}

CppFieldGet(Draw, Face)

Int Draw_FaceSet(Int o, Int value)
{
    Draw* m;
    m = CP(o);
    m->Face = value;
    if (m->Face == null)
    {
        m->Intern->setFont(*(m->InternDefaultFace));
        return true;
    }

    Int u;
    u = Font_Intern(m->Face);
    QFont* uu;
    uu = (QFont*)u;
    m->Intern->setFont(*uu);
    return true;
}

CppFieldGet(Draw, Form)

Int Draw_FormSet(Int o, Int value)
{
    Draw* m;
    m = CP(o);
    m->Form = value;
    if (m->Form == null)
    {
        m->Intern->setWorldTransform((*(m->InternIdentityForm)), false);
        return true;
    }

    Int u;
    u = Form_Intern(m->Form);
    QTransform* uu;
    uu = (QTransform*)u;
    m->Intern->setWorldTransform(*uu, false);
    return true;
}

CppField(Draw, FillPos)
CppFieldGet(Draw, Comp)

Int Draw_CompSet(Int o, Int value)
{
    Draw* m;
    m = CP(o);
    m->Comp = value;
    if (m->Comp == null)
    {
        m->Intern->setCompositionMode(QPainter::CompositionMode_SourceOver);
        return true;
    }

    Int k;
    k = m->Comp - 1;
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

Int Draw_FillPosThisSet(Int o)
{
    Draw* m;
    m = CP(o);
    Int aPos;
    aPos = m->FillPos;

    PosValue(a);

    InternPosValue(a);

    InternPos(a);

    m->Intern->setBrushOrigin(aPosU);
    return true;
}

Int Draw_AreaThisSet(Int o)
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

    InternColor(color);

    m->Intern->fillRect(0, 0, w, h, colorU);
    return true;
}

Int Draw_ExecuteLine(Int o, Int startPos, Int endPos)
{
    Draw* m;
    m = CP(o);

    PosValue(start);
    PosValue(end);

    InternPosValue(start);
    InternPosValue(end);

    InternPos(start);
    InternPos(end);

    m->Intern->drawLine(startPosU, endPosU);
    return true;
}

Int Draw_ExecuteArc(Int o, Int rect, Int angleRange)
{
    Draw* m;
    m = CP(o);
    Int aRect;
    aRect = rect;
    RectValue(a);

    InternRectValue(a);

    InternRect(a);
    
    Int angleStart;
    Int angleCount;
    Int angleEnd;
    angleStart = Range_IndexGet(angleRange);
    angleCount = Range_CountGet(angleRange);
    angleEnd = angleStart + angleCount;

    int startA;
    int spanA;
    startA = (int)angleStart;
    spanA = (int)angleEnd;

    m->Intern->drawArc(aRectU, startA, spanA);
    return true;
}

Int Draw_ExecuteChord(Int o, Int rect, Int angleRange)
{
    Draw* m;
    m = CP(o);
    Int aRect;
    aRect = rect;
    RectValue(a);

    InternRectValue(a);

    InternRect(a);
    
    Int angleStart;
    Int angleCount;
    Int angleEnd;
    angleStart = Range_IndexGet(angleRange);
    angleCount = Range_CountGet(angleRange);
    angleEnd = angleStart + angleCount;

    int startA;
    int spanA;
    startA = (int)angleStart;
    spanA = (int)angleEnd;

    m->Intern->drawChord(aRectU, startA, spanA);
    return true;
}

Int Draw_ExecutePie(Int o, Int rect, Int angleRange)
{
    Draw* m;
    m = CP(o);
    Int aRect;
    aRect = rect;
    RectValue(a);

    InternRectValue(a);

    InternRect(a);
    
    Int angleStart;
    Int angleCount;
    Int angleEnd;
    angleStart = Range_IndexGet(angleRange);
    angleCount = Range_CountGet(angleRange);
    angleEnd = angleStart + angleCount;

    int startA;
    int spanA;
    startA = (int)angleStart;
    spanA = (int)angleEnd;

    m->Intern->drawPie(aRectU, startA, spanA);
    return true;
}

Int Draw_ExecuteEllipse(Int o, Int rect)
{
    Draw* m;
    m = CP(o);
    Int aRect;
    aRect = rect;
    RectValue(a);

    InternRectValue(a);

    InternRect(a);

    m->Intern->drawEllipse(aRectU);
    return true;
}

Int Draw_ExecuteRect(Int o, Int rect)
{
    Draw* m;
    m = CP(o);
    Int aRect;
    aRect = rect;
    RectValue(a);

    InternRectValue(a);

    InternRect(a);

    m->Intern->drawRect(aRectU);
    return true;
}

Int Draw_ExecuteRoundRect(Int o, Int rect, Int horizRadius, Int vertRadius)
{
    Draw* m;
    m = CP(o);
    Int aRect;
    aRect = rect;
    RectValue(a);

    InternRectValue(a);

    InternRect(a);

    InternValue(horizRadius);
    InternValue(vertRadius);
    
    m->Intern->drawRoundedRect(aRectU, horizRadiusU, vertRadiusU);
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
    QPointF* u;
    u = (QPointF*)dataValue;

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
    QPointF* u;
    u = (QPointF*)dataValue;

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

    InternRectValue(dest);
    InternRectValue(source);

    InternRect(dest);
    InternRect(source);

    m->Intern->drawImage(destRectU, *ub, sourceRectU);
    return true;
}

Int Draw_ExecuteText(Int o, Int destRect, Int flag, Int text, Int boundRect)
{
    Draw* m;
    m = CP(o);
    RectValue(dest);

    InternRectValue(dest);

    InternRect(dest);

    int flagU;
    flagU = (int)flag;

    Int ua;
    ua = CastInt(m->InternText);
    String_QStringSetRaw(ua, text);

    QRectF boundRectA;

    m->Intern->drawText(destRectU, flagU, *(m->InternText), &boundRectA);

    m->InternText->setRawData(null, 0);

    qreal boundL;
    qreal boundU;
    qreal boundW;
    qreal boundH;
    boundL = boundRectA.left();
    boundU = boundRectA.top();
    boundW = boundRectA.width();
    boundH = boundRectA.height();

    ValueFromInternValue(boundL);
    ValueFromInternValue(boundU);
    ValueFromInternValue(boundW);
    ValueFromInternValue(boundH);
    
    Int boundPos;
    boundPos = Rect_PosGet(boundRect);
    Int boundSize;
    boundSize = Rect_SizeGet(boundRect);
    Pos_LeftSet(boundPos, boundLA);
    Pos_UpSet(boundPos, boundUA);
    Size_WidthSet(boundSize, boundWA);
    Size_HeightSet(boundSize, boundHA);
    return true;
}

Int Draw_Intern(Int o)
{
    Draw* m;
    m = CP(o);
    Int a;
    a = CastInt(m->Intern);
    return a;
}