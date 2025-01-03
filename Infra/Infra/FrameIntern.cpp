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
    this->TypeEventHandle(true, ev);
}

void FrameIntern::keyReleaseEvent(QKeyEvent* ev)
{
    this->TypeEventHandle(false, ev);
}

Int FrameIntern::TypeEventHandle(Int press, QKeyEvent* ev)
{
    if (ev->isAutoRepeat())
    {
        return true;
    }

    Int frame;
    frame = this->Frame;
    Int index;
    index = ev->key();
    Int field;
    field = press;

    Frame_TypeEvent(frame, index, field);
    return true;
}
