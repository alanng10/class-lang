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
    Int polate;
    polate = m->Polate;
    Int image;
    image = m->Image;

    Int share;
    share = Infra_Share();
    Int stat;
    stat = Share_Stat(share);

    if (kind == Stat_BrushKindColor(stat))
    {
        InternColor(color);
        
        m->Intern = new QBrush(colorU);
    }

    if (kind == Stat_BrushKindPolate(stat))
    {
        Int polateU;
        polateU = Polate_Intern(polate);

        QGradient* ua;
        ua = (QGradient*)polateU;

        m->Intern = new QBrush(*ua);
    }
    
    if (kind == Stat_BrushKindImage(stat))
    {
        Int imageU;
        imageU = Image_Intern(image);

        QImage* ub;
        ub = (QImage*)imageU;

        m->Intern = new QBrush(*ub);
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
CppField(Brush, Polate)
CppField(Brush, Image)

Int Brush_Intern(Int o)
{
    Brush* m;
    m = CP(o);
    Int a;
    a = CastInt(m->Intern);
    return a;
}