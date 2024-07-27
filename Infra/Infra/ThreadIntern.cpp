#include "ThreadIntern.hpp"

Bool ThreadIntern::Init()
{
    return true;
}

void ThreadIntern::run()
{
    Int thread;
    thread = this->Thread;

    Thread_ExecuteHandle(thread);
}

Int ThreadIntern::ExecuteEventLoop()
{
    int u;
    u = this->exec();
    Int a;
    a = u;
    return a;
}