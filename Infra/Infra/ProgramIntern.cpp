#include "ProgramIntern.hpp"

Bool ProgramIntern::Init()
{
    connect(this, &QProcess::started, this, &ProgramIntern::StartHandle);
    connect(this, &QProcess::finished, this, &ProgramIntern::FinishHandle);
    return true;
}

void ProgramIntern::StartHandle()
{
    Int m;
    m = this->Program;
    Program_Start(m);
}

void ProgramIntern::FinishHandle(int exitCode, QProcess::ExitStatus exitStatus)
{
    Int m;
    m = this->Program;
    Program_Finish(m);
}