#pragma once

#include <QProcess>

#include "Pronate.hpp"

class ProgramIntern : public QProcess
{
    Q_OBJECT

public:
    Bool Init();
    Int Program;

private slots:

    void StartHandle();
    void FinishHandle(int exitCode, QProcess::ExitStatus exitStatus);
};
