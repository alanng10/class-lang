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




protected:

    void paintEvent(QPaintEvent* ev) override;


    void keyPressEvent(QKeyEvent* ev) override;


    void keyReleaseEvent(QKeyEvent* ev) override;


    void mousePressEvent(QMouseEvent* ev) override;


    void mouseReleaseEvent(QMouseEvent* ev) override;


    void mouseDoubleClickEvent(QMouseEvent* ev) override;


    void mouseMoveEvent(QMouseEvent* ev) override;


private:

    Bool TypeState(Bool press, QKeyEvent* ev);


    Bool MouseHandle(Int kind, QMouseEvent* ev);
};

