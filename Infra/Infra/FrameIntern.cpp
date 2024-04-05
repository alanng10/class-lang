#include "FrameIntern.hpp"

Bool FrameIntern::Init()
{
    return true;
}

void FrameIntern::paintEvent(QPaintEvent *ev)
{
    Int frame;
    frame = this->Frame;

    Int state;
    state = Frame_DrawStateGet(frame);
    Int aa;
    aa = State_MaideGet(state);
    Int arg;
    arg = State_ArgGet(state);

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

Bool FrameIntern::TypeState(Bool press, QKeyEvent* ev)
{
    if (ev->isAutoRepeat())
    {
        return true;
    }

    Int frame;
    frame = this->Frame;
    Int state;
    state = Frame_TypeStateGet(frame);
    Int aa;
    aa = State_MaideGet(state);
    Int arg;
    arg = State_ArgGet(state);

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
