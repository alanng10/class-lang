#include "Stat.hpp"




Int Stat_Var_PenCapFlat = Qt::FlatCap + 1;

Int Stat_Var_PenCapSquare = Qt::SquareCap + 1;

Int Stat_Var_PenCapRound = Qt::RoundCap + 1;






Int Stat_PenCapFlat(Int o)
{
    return Stat_Var_PenCapFlat;
}


Int Stat_PenCapSquare(Int o)
{
    return Stat_Var_PenCapSquare;
}


Int Stat_PenCapRound(Int o)
{
    return Stat_Var_PenCapRound;
}


