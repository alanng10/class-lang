#include "Pen.hpp"

CppClassNew(Pen)

Int Pen_Init(Int o)
{
    Pen* m;
    m = CP(o);
    Int kind;
    kind = m->Kind;
    Int width;
    width = m->Width;
    Int brush;
    brush = m->Brush;
    Int cap;
    cap = m->Cap;
    Int join;
    join = m->Join;

    if ((kind == null) | (brush == null) | (cap == null) | (join == null))
    {
        return true;
    }

    Qt::PenStyle styleU;
    styleU = (Qt::PenStyle)kind;

    int widthU;
    widthU = (int)width;
    qreal widthUu;
    widthUu = widthU;

    Int ua;
    ua = Brush_Intern(brush);
    QBrush* brushU;
    brushU = (QBrush*)ua;

    Qt::PenCapStyle capStyleU;
    capStyleU = (Qt::PenCapStyle)(cap - 1);

    Qt::PenJoinStyle joinStyleU;
    joinStyleU = (Qt::PenJoinStyle)(join - 1);

    QPen* u;
    u = new QPen(*brushU, widthUu, styleU, capStyleU, joinStyleU);
    m->Intern = u;
    return true;
}

Int Pen_Final(Int o)
{
    Pen* m;
    m = CP(o);

    delete m->Intern;
    return true;
}

CppField(Pen, Kind)
CppField(Pen, Width)
CppField(Pen, Brush)
CppField(Pen, Cap)
CppField(Pen, Join)

Int Pen_Intern(Int o)
{
    Pen* m;
    m = CP(o);
    Int a;
    a = CastInt(m->Intern);
    return a;
}