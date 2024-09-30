#include "Stat.hpp"

Int Stat_Var_CompSourceOver = QPainter::CompositionMode_SourceOver + 1;
Int Stat_Var_CompDestOver = QPainter::CompositionMode_DestinationOver + 1;
Int Stat_Var_CompSource = QPainter::CompositionMode_Source + 1;
Int Stat_Var_CompDest = QPainter::CompositionMode_Destination + 1;
Int Stat_Var_CompSourceIn = QPainter::CompositionMode_SourceIn + 1;
Int Stat_Var_CompDestIn = QPainter::CompositionMode_DestinationIn + 1;
Int Stat_Var_CompSourceOut = QPainter::CompositionMode_SourceOut + 1;
Int Stat_Var_CompDestOut = QPainter::CompositionMode_DestinationOut + 1;

Int Stat_CompSourceOver(Int o)
{
    return Stat_Var_CompSourceOver;
}
Int Stat_CompDestOver(Int o)
{
    return Stat_Var_CompDestOver;
}
Int Stat_CompSource(Int o)
{
    return Stat_Var_CompSource;
}
Int Stat_CompDest(Int o)
{
    return Stat_Var_CompDest;
}
Int Stat_CompSourceIn(Int o)
{
    return Stat_Var_CompSourceIn;
}
Int Stat_CompDestIn(Int o)
{
    return Stat_Var_CompDestIn;
}
Int Stat_CompSourceOut(Int o)
{
    return Stat_Var_CompSourceOut;
}
Int Stat_CompDestOut(Int o)
{
    return Stat_Var_CompDestOut;
}
