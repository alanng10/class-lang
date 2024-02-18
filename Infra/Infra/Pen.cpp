#include "Pen.hpp"




CppClassNew(Pen)








Bool Pen_Init(Int o)
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

    ua = Brush_GetIntern(brush);



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






Bool Pen_Final(Int o)
{
    Pen* m;

    m = CP(o);



    delete m->Intern;




    return true;
}







Int Pen_GetKind(Int o)
{
    Pen* m;

    m = CP(o);


    return m->Kind;
}





Bool Pen_SetKind(Int o, Int value)
{
    Pen* m;

    m = CP(o);


    m->Kind = value;


    return true;
}







Int Pen_GetWidth(Int o)
{
    Pen* m;

    m = CP(o);


    return m->Width;
}





Bool Pen_SetWidth(Int o, Int value)
{
    Pen* m;

    m = CP(o);


    m->Width = value;


    return true;
}






Int Pen_GetBrush(Int o)
{
    Pen* m;

    m = CP(o);


    return m->Brush;
}





Bool Pen_SetBrush(Int o, Int value)
{
    Pen* m;

    m = CP(o);


    m->Brush = value;


    return true;
}







Int Pen_GetCap(Int o)
{
    Pen* m;

    m = CP(o);


    return m->Cap;
}





Bool Pen_SetCap(Int o, Int value)
{
    Pen* m;

    m = CP(o);


    m->Cap = value;


    return true;
}





Int Pen_GetJoin(Int o)
{
    Pen* m;

    m = CP(o);


    return m->Join;
}





Bool Pen_SetJoin(Int o, Int value)
{
    Pen* m;

    m = CP(o);


    m->Join = value;


    return true;
}






Int Pen_GetIntern(Int o)
{
    Pen* m;

    m = CP(o);



    Int u;

    u = CastInt(m->Intern);



    return u;
}


