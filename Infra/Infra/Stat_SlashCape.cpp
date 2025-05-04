#include "Stat.hpp"

Int Stat_Var_SlashCapePlane = Qt::FlatCap + 1;
Int Stat_Var_SlashCapeRight = Qt::SquareCap + 1;
Int Stat_Var_SlashCapeRound = Qt::RoundCap + 1;

Int Stat_SlashCapePlane(Int o)
{
    return Stat_Var_SlashCapePlane;
}
Int Stat_SlashCapeRight(Int o)
{
    return Stat_Var_SlashCapeRight;
}
Int Stat_SlashCapeRound(Int o)
{
    return Stat_Var_SlashCapeRound;
}
