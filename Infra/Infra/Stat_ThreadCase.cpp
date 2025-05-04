#include "Stat.hpp"


Int Stat_ThreadCaseReady(Int o)
{
    return 1;
}
Int Stat_ThreadCaseExecute(Int o)
{
    return 2;
}
Int Stat_ThreadCasePause(Int o)
{
    return 3;
}
Int Stat_ThreadCaseFinish(Int o)
{
    return 4;
}
Int Stat_ThreadCaseTerminate(Int o)
{
    return 5;
}
