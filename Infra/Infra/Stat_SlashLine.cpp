#include "Stat.hpp"

Int Stat_Var_SlashLineSolid = Qt::SolidLine;
Int Stat_Var_SlashLineDash = Qt::DashLine;
Int Stat_Var_SlashLineDot = Qt::DotLine;
Int Stat_Var_SlashLineDashDot = Qt::DashDotLine;
Int Stat_Var_SlashLineDashDotDot = Qt::DashDotDotLine;

Int Stat_SlashLineSolid(Int o)
{
    return Stat_Var_SlashLineSolid;
}
Int Stat_SlashLineDash(Int o)
{
    return Stat_Var_SlashLineDash;
}
Int Stat_SlashLineDot(Int o)
{
    return Stat_Var_SlashLineDot;
}
Int Stat_SlashLineDashDot(Int o)
{
    return Stat_Var_SlashLineDashDot;
}
Int Stat_SlashLineDashDotDot(Int o)
{
    return Stat_Var_SlashLineDashDotDot;
}
