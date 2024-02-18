#include "FrameIntern.hpp"




void FrameIntern::paintEvent(QPaintEvent *ev)
{
    Int frame;

    frame = this->Frame;



    Int state;

    state = Frame_GetDrawState(frame);



    Int aa;

    aa = State_GetMaide(state);


    Int arg;

    arg = State_GetArg(state);




    Frame_Draw_Maide maide;

    maide = (Frame_Draw_Maide)aa;



    if (!(maide == null))
    {
        maide(frame, arg);
    }
}





void FrameIntern::keyPressEvent(QKeyEvent* ev)
{
    this->TypeState(true, ev);
}




void FrameIntern::keyReleaseEvent(QKeyEvent* ev)
{
    this->TypeState(false, ev);
}





void FrameIntern::mousePressEvent(QMouseEvent* ev)
{
    this->MouseHandle(1, ev);
}


void FrameIntern::mouseReleaseEvent(QMouseEvent* ev)
{
    this->MouseHandle(2, ev);
}


void FrameIntern::mouseDoubleClickEvent(QMouseEvent* ev)
{
    this->MouseHandle(3, ev);
}


void FrameIntern::mouseMoveEvent(QMouseEvent* ev)
{
    this->MouseHandle(4, ev);
}





Bool FrameIntern::TypeState(Bool press, QKeyEvent* ev)
{
    if (ev->isAutoRepeat())
    {
        return true;
    }



    Int frame;

    frame = this->Frame;



    Int state;

    state = Frame_GetTypeState(frame);



    Int aa;

    aa = State_GetMaide(state);


    Int arg;

    arg = State_GetArg(state);




    Frame_Type_Maide maide;

    maide = (Frame_Type_Maide)aa;




    Int index;

    index = ev->key();



    Int field;

    field = press;




    if (!(maide == null))
    {
        maide(frame, index, field, arg);
    }




    return true;
}







Bool FrameIntern::MouseHandle(Int kind, QMouseEvent* ev)
{






    return true;
}