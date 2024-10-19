#include "Slash.hpp"

CppClassNew(Slash)

Int Slash_Init(Int o)
{
    Slash* m;
    m = CP(o);

    Int brush;
    brush = m->Brush;
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

    Int brushU;
    brushU = Brush_Intern(brush);
    QBrush* brushUu;
    brushUu = (QBrush*)brushU;

    Qt::PenStyle styleU;
    styleU = (Qt::PenStyle)line;

    InternValue(width);

    Qt::PenCapStyle capStyleU;
    capStyleU = (Qt::PenCapStyle)(cap - 1);

    Qt::PenJoinStyle joinStyleU;
    joinStyleU = (Qt::PenJoinStyle)(join - 1);

    QPen* u;
    u = new QPen(*brushUu, widthU, styleU, capStyleU, joinStyleU);
    m->Intern = u;
    return true;
}

Int Slash_Final(Int o)
{
    Slash* m;
    m = CP(o);

    delete m->Intern;
    return true;
}

CppField(Slash, Brush)
CppField(Slash, Line)
CppField(Slash, Width)
CppField(Slash, Cap)
CppField(Slash, Join)

Int Slash_Intern(Int o)
{
    Slash* m;
    m = CP(o);
    Int a;
    a = CastInt(m->Intern);
    return a;
}