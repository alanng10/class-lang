#include "Stat.hpp"

Int Stat_Var_BrushJoinMiter = Qt::MiterJoin + 1;
Int Stat_Var_BrushJoinBevel = Qt::BevelJoin + 1;
Int Stat_Var_BrushJoinRound = Qt::RoundJoin + 1;

Int Stat_BrushJoinMiter(Int o)
{
    return Stat_Var_BrushJoinMiter;
}
Int Stat_BrushJoinBevel(Int o)
{
    return Stat_Var_BrushJoinBevel;
}
Int Stat_BrushJoinRound(Int o)
{
    return Stat_Var_BrushJoinRound;
}
