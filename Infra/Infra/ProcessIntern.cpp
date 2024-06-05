#include "ProcessIntern.hpp"

Bool ProcessIntern::Init()
{
    connect(this, &QProcess::started, this, &ProcessIntern::StartHandle);
    connect(this, &QProcess::finished, this, &ProcessIntern::FinishHandle);
    return true;
}

void ProcessIntern::StartHandle()
{
    Int process;
    process = this->Process;
    Process_Start(process);
}

void ProcessIntern::FinishHandle(int exitCode, QProcess::ExitStatus exitStatus)
{
    Int process;
    process = this->Process;
    Process_Finish(process);
}