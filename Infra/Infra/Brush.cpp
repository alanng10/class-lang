#include "Brush.hpp"

CppClassNew(Brush)

Int Brush_Init(Int o)
{
    Brush* m;
    m = CP(o);

    Int kind;
    kind = m->Kind;
    Int color;
    color = m->Color;
    Int gradient;
    gradient = m->Gradient;
    Int image;
    image = m->Image;
    Int line;
    line = m->Line;
    Int width;
    width = m->Width;
    Int cap;
    cap = m->Cap;
    Int join;
    join = m->Join;

    Int share;
    share = Infra_Share();
    Int stat;
    stat = Share_Stat(share);

    if (kind == Stat_BrushKindColor(stat))
    {
        Int32 uu;
        uu = (Int32)color;

        QRgb kk;
        kk = uu;

        QColor colorU;
        colorU = QColor(kk);
        
        m->InternBrush = new QBrush(colorU);
    }

    if (kind == Stat_BrushKindGradient(stat))
    {
        Int gradientU;
        gradientU = Gradient_Intern(gradient);

        QGradient* ua;
        ua = (QGradient*)gradientU;

        m->InternBrush = new QBrush(*ua);
    }
    
    if (kind == Stat_BrushKindImage(stat))
    {
        Int imageU;
        imageU = Image_Intern(image);

        QImage* ub;
        ub = (QImage*)imageU;

        m->InternBrush = new QBrush(*ub);
    }

    if (line == null)
    {
        return true;
    }

    Qt::PenStyle styleU;
    styleU = (Qt::PenStyle)line;

    int widthU;
    widthU = (int)width;
    qreal widthUu;
    widthUu = widthU;

    Qt::PenCapStyle capStyleU;
    capStyleU = (Qt::PenCapStyle)(cap - 1);

    Qt::PenJoinStyle joinStyleU;
    joinStyleU = (Qt::PenJoinStyle)(join - 1);

    QPen* u;
    u = new QPen(*(m->InternBrush), widthUu, styleU, capStyleU, joinStyleU);
    m->Intern = u;
    return true;
}

Int Brush_Final(Int o)
{
    Brush* m;
    m = CP(o);

    delete m->Intern;

    delete m->InternBrush;

    return true;
}

CppField(Brush, Kind)
CppField(Brush, Color)
CppField(Brush, Gradient)
CppField(Brush, Image)
CppField(Brush, Line)
CppField(Brush, Width)
CppField(Brush, Cap)
CppField(Brush, Join)

Int Brush_Intern(Int o)
{
    Brush* m;
    m = CP(o);
    Int a;
    a = CastInt(m->Intern);
    return a;
}

Int Brush_InternBrush(Int o)
{
    Brush* m;
    m = CP(o);
    Int a;
    a = CastInt(m->InternBrush);
    return a;
}