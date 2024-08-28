#pragma once

#include <QObject>
#include <QEvent>

#include "Pronate.hpp"

class PostIntern : public QObject
{
    Q_OBJECT

public:
    Bool Init();
    Int Post;

protected:
    void customEvent(QEvent* event) override;
};
