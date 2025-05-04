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
    Int size;
    size = m->Size;
    Int cape;
    cape = m->Cape;
    Int join;
    join = m->Join;

    Int brushU;
    brushU = Brush_Intern(brush);
    QBrush* brushUu;
    brushUu = (QBrush*)brushU;

    Qt::PenStyle styleU;
    styleU = (Qt::PenStyle)line;

    InternValue(size);

    Qt::PenCapStyle capStyleU;
    capStyleU = (Qt::PenCapStyle)(cape - 1);

    Qt::PenJoinStyle joinStyleU;
    joinStyleU = (Qt::PenJoinStyle)(join - 1);

    QPen* u;
    u = new QPen(*brushUu, sizeU, styleU, capStyleU, joinStyleU);
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
CppField(Slash, Size)
CppField(Slash, Cape)
CppField(Slash, Join)

Int Slash_Intern(Int o)
{
    Slash* m;
    m = CP(o);
    Int a;
    a = CastInt(m->Intern);
    return a;
}