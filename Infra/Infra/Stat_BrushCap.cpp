#include "Stat.hpp"

Int Stat_Var_BrushCapFlat = Qt::FlatCap + 1;
Int Stat_Var_BrushCapSquare = Qt::SquareCap + 1;
Int Stat_Var_BrushCapRound = Qt::RoundCap + 1;

Int Stat_BrushCapFlat(Int o)
{
    return Stat_Var_BrushCapFlat;
}
Int Stat_BrushCapSquare(Int o)
{
    return Stat_Var_BrushCapSquare;
}
Int Stat_BrushCapRound(Int o)
{
    return Stat_Var_BrushCapRound;
}
