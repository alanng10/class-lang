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

Int Brush_Intern(Int o)
{
    Brush* m;
    m = CP(o);
    Int a;
    a = CastInt(m->Intern);
    return a;
}