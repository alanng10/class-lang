#include "Draw.hpp"

CppClassNew(Draw)

Int Draw_TextAlignCol_Array[3] =
{
    Qt::AlignLeft, Qt::AlignHCenter, Qt::AlignRight
};

Int Draw_TextAlignRow_Array[3] =
{
    Qt::AlignTop, Qt::AlignVCenter, Qt::AlignBottom
};


Int Draw_Init(Int o)
{
    Draw* m;
    m = CP(o);

    Int count;
    count = TextCountMax * 2 * sizeof(Int16);
    Int p;
    p = Environ_New(count);
    m->TextData = p;

    m->InternIdentityForm = new QTransform;

    QString* uu;
    uu = new QString;
    uu->setRawData(null, 0);
    m->InternText = uu;

    QFont* ua;
    ua = new QFont(QApplication::font());
    m->InternDefaultFont = ua;

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
    delete m->InternDefaultFont;
    delete m->InternText;
    delete m->InternIdentityForm;

    Environ_Delete(m->TextData);
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
    u = Brush_Intern(m->Fill);
    QBrush* uu;
    uu = (QBrush*)u;
    m->Intern->setBrush(*uu);
    return true;
}

CppFieldGet(Draw, Line)

Int Draw_LineSet(Int o, Int value)
{
    Draw* m;
    m = CP(o);
    m->Line = value;
    if (m->Line == null)
    {
        m->Intern->setPen(Qt::NoPen);
        return true;
    }

    Int u;
    u = Slash_Intern(m->Line);    
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
    l = aCol;
    u = aRow;
    w = aWed;
    h = aHet;
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
    Int wed;
    Int het;
    wed = Size_WedGet(size);
    het = Size_HetGet(size);

    int w;
    int h;
    w = wed;
    h = het;

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

Int Draw_ExecuteRoundLine(Int o, Int rect, Int angleRange)
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

Int Draw_ExecuteRoundShape(Int o, Int rect, Int angleRange)
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

Int Draw_ExecuteRoundPart(Int o, Int rect, Int angleRange)
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

Int Draw_ExecuteRound(Int o, Int rect)
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

Int Draw_ExecuteRectRound(Int o, Int rect, Int horizRadius, Int vertRadius)
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

Int Draw_ExecuteShape(Int o, Int pointListCount, Int pointListData)
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

Int Draw_ExecuteShapeLine(Int o, Int pointListCount, Int pointListData)
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

Int Draw_ExecuteText(Int o, Int text, Int colAlign, Int rowAlign, Int wordWrap, Int destRect, Int boundRect)
{
    Draw* m;
    m = CP(o);

    Int textValue;
    Int textCount;
    textValue = String_ValueGet(text);
    textCount = String_CountGet(text);

    if (TextCountMax < textCount)
    {
        return false;
    }

    RectValue(dest);

    InternRectValue(dest);

    InternRect(dest);

    Int flag;
    flag = 0;
    flag = flag | Draw_TextAlignCol_Array[colAlign - 1];
    flag = flag | Draw_TextAlignRow_Array[rowAlign - 1];

    if (wordWrap)
    {
        flag = flag | Qt::TextWordWrap;
    }

    int flagU;
    flagU = (int)flag;

    Draw_TextSet(o, textValue, textCount);

    QRectF boundRectA;

    m->Intern->drawText(destRectU, flagU, *(m->InternText), &boundRectA);

    m->InternText->setRawData(null, 0);

    qreal boundC;
    qreal boundR;
    qreal boundW;
    qreal boundH;
    boundC = boundRectA.left();
    boundR = boundRectA.top();
    boundW = boundRectA.width();
    boundH = boundRectA.height();

    ValueFromInternValue(boundC);
    ValueFromInternValue(boundR);
    ValueFromInternValue(boundW);
    ValueFromInternValue(boundH);
    
    Int boundPos;
    boundPos = Rect_PosGet(boundRect);
    Int boundSize;
    boundSize = Rect_SizeGet(boundRect);
    Pos_ColSet(boundPos, boundCA);
    Pos_RowSet(boundPos, boundRA);
    Size_WedSet(boundSize, boundWA);
    Size_HetSet(boundSize, boundHA);
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

Int Draw_TextSet(Int o, Int textValue, Int textCount)
{
    Draw* m;
    m = CP(o);

    Int dataValue;
    Int dataCount;
    dataValue = textValue;
    dataCount = textCount * sizeof(Char);

    Int share;
    Int stat;
    share = Infra_Share();
    stat = Share_Stat(share);

    Int innKind;
    Int outKind;
    innKind = Stat_TextCodeKindUtf32(stat);
    outKind = Stat_TextCodeKindUtf16(stat);

    Int resultCount;
    resultCount = TextCode_ExecuteCount(null, innKind, outKind, dataValue, dataCount);

    TextCode_ExecuteResult(null, m->TextData, innKind, outKind, dataValue, dataCount);

    Int ka;
    ka = resultCount / sizeof(Int16);

    Int ua;
    ua = CastInt(m->InternText);
    Draw_QStringSetRaw(ua, m->TextData, ka);

    return true;
}

Int Draw_QStringSetRaw(Int result, Int data, Int count)
{
    const QChar* dataU;
    dataU = (const QChar*)data;
    qsizetype countU;
    countU = count;

    QString* u;
    u = (QString*)result;
    u->setRawData(dataU, countU);
    return true;
}