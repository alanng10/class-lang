#pragma once

#include <QProcess>

#include "Pronate.hpp"

class ProgramIntern : public QProcess
{
    Q_OBJECT

public:
    Bool Init();
    Int Program;
};
