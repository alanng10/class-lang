#include "Frame.hpp"




CppClassNew(Frame)



#define CP(a) ((Frame*)(a))






Bool Frame_Init(Int o)
{
    Frame* m;

    m = CP(o);






    Int size;


    size = Size_New();


    Size_Init(size);



    m->Size = size;





    FrameIntern* a;

    a = new FrameIntern();


    a->Frame = o;




    a->setWindowState(Qt::WindowFullScreen);



    a->setCursor(Qt::BlankCursor);




    m->Intern = a;





    QScreen* screen;

    screen = m->Intern->screen();



    QSize ua;

    ua = screen->size();



    int w;

    int h;


    w = ua.width();

    h = ua.height();




    Int width;

    Int height;


    width = w;

    height = h;




    Size_SetWidth(m->Size, width);


    Size_SetHeight(m->Size, height);






    return true;
}






Bool Frame_Final(Int o)
{
    Frame* m;

    m = CP(o);




    delete m->Intern;




    Size_Final(m->Size);


    Size_Delete(m->Size);



    return true;
}







Int Frame_GetSize(Int o)
{
    Frame* m;

    m = CP(o);



    return m->Size;
}





Int Frame_GetTitle(Int o)
{
    Frame* m;

    m = CP(o);



    return m->Title;
}




Bool Frame_SetTitle(Int o, Int value)
{
    Frame* m;

    m = CP(o);



    m->Title = value;


    return true;
}






Int Frame_SetFrameTitle(Int o)
{
    Frame* m;

    m = CP(o);





    QString titleU;



    Int ua;

    ua = CastInt(&titleU);




    String_SetQString(ua, m->Title);






    m->Intern->setWindowTitle(titleU);





    return true;
}







Bool Frame_GetVisible(Int o)
{
    Frame* m;

    m = CP(o);




    bool bu;

    bu = m->Intern->isVisible();



    Bool bo;

    bo = bu;



    return bo;
}






Bool Frame_SetVisible(Int o, Bool value)
{
    Frame* m;

    m = CP(o);




    bool b;


    b = !(value == 0);



    m->Intern->setVisible(b);



    return true;
}







Int Frame_GetDrawState(Int o)
{
    Frame* m;

    m = CP(o);


    return m->DrawState;
}





Int Frame_SetDrawState(Int o, Int value)
{
    Frame* m;

    m = CP(o);


    m->DrawState = value;


    return true;
}






Int Frame_GetTypeState(Int o)
{
    Frame* m;

    m = CP(o);


    return m->TypeState;
}





Bool Frame_SetTypeState(Int o, Int value)
{
    Frame* m;

    m = CP(o);


    m->TypeState = value;


    return true;
}





Int Frame_GetMouseState(Int o)
{
    Frame* m;

    m = CP(o);


    return m->MouseState;
}





Int Frame_SetMouseState(Int o, Int value)
{
    Frame* m;

    m = CP(o);


    m->MouseState = value;


    return true;
}





Int Frame_GetMouseEvent(Int o)
{
    Frame* m;

    m = CP(o);


    return m->MouseEvent;
}





Int Frame_GetVideoOut(Int o)
{
    Frame* m;

    m = CP(o);




    QPaintDevice* u;

    u = m->Intern;




    Int uu;

    uu = CastInt(u);


    return uu;
}





Bool Frame_Update(Int o, Int rect)
{
    Frame* m;

    m = CP(o);




    Int pos;

    pos = Rect_GetPos(rect);


    Int left;

    Int up;


    left = Pos_GetLeft(pos);

    up = Pos_GetUp(pos);



    Int size;

    size = Rect_GetSize(rect);


    Int width;

    Int height;


    width = Size_GetWidth(size);

    height = Size_GetHeight(size);



    int l;

    int u;

    int w;

    int h;



    l = left;

    u = up;

    w = width;

    h = height;




    m->Intern->update(l, u, w, h);




    return true;
}





Bool Frame_Close(Int o)
{
    Frame* m;

    m = CP(o);



    m->Intern->close();



    return true;
}





