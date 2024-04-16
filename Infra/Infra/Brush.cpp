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
    Int image;
    image = m->Image;
    Int gradient;
    gradient = m->Gradient;

    Int share;
    share = Infra_Share();
    Int stat;
    stat = Share_Stat(share);

    Bool b;
    b = false;
    if ((!b) & (kind == Stat_BrushKindTexture(stat)))
    {
        Int imageU;
        imageU = Image_Intern(image);

        QImage* ua;
        ua = (QImage*)imageU;

        m->Intern = new QBrush(*ua);
        b = true;
    }

    if ((!b) & ((kind == Stat_BrushKindLinearGradient(stat)) | (kind == Stat_BrushKindRadialGradient(stat))))
    {
        Int gradientU;
        gradientU = Gradient_Intern(gradient);

        QGradient* ub;
        ub = (QGradient*)gradientU;

        m->Intern = new QBrush(*ub);
        b = true;
    }

    if (!b)
    {
        Int32 uu;
        uu = (Int32)color;

        QRgb kk;
        kk = uu;

        QColor colorU;
        colorU = QColor(kk);

        Qt::BrushStyle brushStyle;
        brushStyle = (Qt::BrushStyle)kind;
        m->Intern = new QBrush(colorU, brushStyle);
    }
    return true;
}

Int Brush_Final(Int o)
{
    Brush* m;
    m = CP(o);

    delete m->Intern;
    return true;
}

CppField(Brush, Kind)
CppField(Brush, Color)
CppField(Brush, Image)
CppField(Brush, Gradient)

Int Brush_Intern(Int o)
{
    Brush* m;
    m = CP(o);
    Int a;
    a = CastInt(m->Intern);
    return a;
}