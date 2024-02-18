#include "ProcessIntern.hpp"






Bool ProcessIntern::Init()
{
    connect(this, &QProcess::started, this, &ProcessIntern::StartedHandle);



    connect(this, &QProcess::finished, this, &ProcessIntern::FinshedHandle);




    return true;
}





void ProcessIntern::StartedHandle()
{
    Int process;

    process = this->Process;



    Process_Started(process);
}





void ProcessIntern::FinshedHandle(int exitCode, QProcess::ExitStatus exitStatus)
{
    Int process;

    process = this->Process;



    Process_Finished(process);
}