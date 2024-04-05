#pragma once

#include <QWidget>
#include <QPaintEvent>
#include <QPainter>

#include "Probate.hpp"

class FrameIntern : public QWidget
{
    Q_OBJECT

public:
    Int Frame;
    Bool Init();

protected:
    void paintEvent(QPaintEvent* ev) override;
    void keyPressEvent(QKeyEvent* ev) override;
    void keyReleaseEvent(QKeyEvent* ev) override;

private:
    Bool TypeState(Bool press, QKeyEvent* ev);
};
