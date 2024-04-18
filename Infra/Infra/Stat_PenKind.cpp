#include "Stat.hpp"

Int Stat_Var_PenKindSolid = Qt::SolidLine;
Int Stat_Var_PenKindDash = Qt::DashLine;
Int Stat_Var_PenKindDot = Qt::DotLine;
Int Stat_Var_PenKindDashDot = Qt::DashDotLine;
Int Stat_Var_PenKindDashDotDot = Qt::DashDotDotLine;
Int Stat_Var_PenKindCustomDash = Qt::CustomDashLine;

Int Stat_PenKindSolid(Int o)
{
    return Stat_Var_PenKindSolid;
}
Int Stat_PenKindDash(Int o)
{
    return Stat_Var_PenKindDash;
}
Int Stat_PenKindDot(Int o)
{
    return Stat_Var_PenKindDot;
}
Int Stat_PenKindDashDot(Int o)
{
    return Stat_Var_PenKindDashDot;
}
Int Stat_PenKindDashDotDot(Int o)
{
    return Stat_Var_PenKindDashDotDot;
}
Int Stat_PenKindCustomDash(Int o)
{
    return Stat_Var_PenKindCustomDash;
}
