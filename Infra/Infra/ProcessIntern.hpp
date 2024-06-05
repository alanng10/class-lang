#pragma once

#include <QProcess>

#include "Probate.hpp"

class ProcessIntern : public QProcess
{
    Q_OBJECT

public:
    Bool Init();
    Int Process;

private slots:

    void StartHandle();
    void FinishHandle(int exitCode, QProcess::ExitStatus exitStatus);
};
