#include "Stat.hpp"

Int Stat_Var_SlashCapFlat = Qt::FlatCap + 1;
Int Stat_Var_SlashCapSquare = Qt::SquareCap + 1;
Int Stat_Var_SlashCapRound = Qt::RoundCap + 1;

Int Stat_SlashCapFlat(Int o)
{
    return Stat_Var_SlashCapFlat;
}
Int Stat_SlashCapSquare(Int o)
{
    return Stat_Var_SlashCapSquare;
}
Int Stat_SlashCapRound(Int o)
{
    return Stat_Var_SlashCapRound;
}
