#include "FrameIntern.hpp"

Bool FrameIntern::Init()
{
    return true;
}

void FrameIntern::keyPressEvent(QKeyEvent* ev)
{
    this->TypeEventHandle(true, ev);
}

void FrameIntern::keyReleaseEvent(QKeyEvent* ev)
{
    this->TypeEventHandle(false, ev);
}

void FrameIntern::paintEvent(QPaintEvent* ev)
{
    this->DrawEventHandle();
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
    Int value;
    value = press;

    Frame_TypeEvent(frame, index, value);
    return true;
}

Int FrameIntern::DrawEventHandle()
{
    Int frame;
    frame = this->Frame;

    Frame_DrawEvent(frame);
    return true;
}