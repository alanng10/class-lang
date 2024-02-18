#include "Stat.hpp"




Int Stat_Var_PenJoinMiter = Qt::MiterJoin + 1;

Int Stat_Var_PenJoinBevel = Qt::BevelJoin + 1;

Int Stat_Var_PenJoinRound = Qt::RoundJoin + 1;

Int Stat_Var_PenJoinSvgMiter = Qt::SvgMiterJoin + 1;






Int Stat_PenJoinMiter(Int o)
{
    return Stat_Var_PenJoinMiter;
}


Int Stat_PenJoinBevel(Int o)
{
    return Stat_Var_PenJoinBevel;
}


Int Stat_PenJoinRound(Int o)
{
    return Stat_Var_PenJoinRound;
}


Int Stat_PenJoinSvgMiter(Int o)
{
    return Stat_Var_PenJoinSvgMiter;
}


