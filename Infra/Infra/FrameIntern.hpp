#pragma once

#include <QWidget>
#include <QPaintEvent>
#include <QPainter>

#include "Pronate.hpp"

class FrameIntern : public QWidget
{
    Q_OBJECT

public:
    Int Frame;
    Int Init();

protected:
    void paintEvent(QPaintEvent* ev) override;
    void keyPressEvent(QKeyEvent* ev) override;
    void keyReleaseEvent(QKeyEvent* ev) override;

private:
    Int TypeEventHandle(Int press, QKeyEvent* ev);
    Int DrawEventHandle();
};
