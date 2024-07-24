#include "Stat.hpp"

Int Stat_Var_BrushLineSolid = Qt::SolidLine;
Int Stat_Var_BrushLineDash = Qt::DashLine;
Int Stat_Var_BrushLineDot = Qt::DotLine;
Int Stat_Var_BrushLineDashDot = Qt::DashDotLine;
Int Stat_Var_BrushLineDashDotDot = Qt::DashDotDotLine;

Int Stat_BrushLineSolid(Int o)
{
    return Stat_Var_BrushLineSolid;
}
Int Stat_BrushLineDash(Int o)
{
    return Stat_Var_BrushLineDash;
}
Int Stat_BrushLineDot(Int o)
{
    return Stat_Var_BrushLineDot;
}
Int Stat_BrushLineDashDot(Int o)
{
    return Stat_Var_BrushLineDashDot;
}
Int Stat_BrushLineDashDotDot(Int o)
{
    return Stat_Var_BrushLineDashDotDot;
}
