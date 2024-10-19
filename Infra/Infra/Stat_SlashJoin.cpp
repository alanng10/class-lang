#include "Stat.hpp"

Int Stat_Var_SlashJoinMiter = Qt::MiterJoin + 1;
Int Stat_Var_SlashJoinBevel = Qt::BevelJoin + 1;
Int Stat_Var_SlashJoinRound = Qt::RoundJoin + 1;

Int Stat_SlashJoinMiter(Int o)
{
    return Stat_Var_SlashJoinMiter;
}
Int Stat_SlashJoinBevel(Int o)
{
    return Stat_Var_SlashJoinBevel;
}
Int Stat_SlashJoinRound(Int o)
{
    return Stat_Var_SlashJoinRound;
}
