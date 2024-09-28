#include "Stat.hpp"

Int Stat_Var_CompSourceOver = QPainter::CompositionMode_SourceOver + 1;
Int Stat_Var_CompDestinationOver = QPainter::CompositionMode_DestinationOver + 1;
Int Stat_Var_CompClear = QPainter::CompositionMode_Clear + 1;
Int Stat_Var_CompSource = QPainter::CompositionMode_Source + 1;
Int Stat_Var_CompDestination = QPainter::CompositionMode_Destination + 1;
Int Stat_Var_CompSourceIn = QPainter::CompositionMode_SourceIn + 1;
Int Stat_Var_CompDestinationIn = QPainter::CompositionMode_DestinationIn + 1;
Int Stat_Var_CompSourceOut = QPainter::CompositionMode_SourceOut + 1;
Int Stat_Var_CompDestinationOut = QPainter::CompositionMode_DestinationOut + 1;

Int Stat_CompSourceOver(Int o)
{
    return Stat_Var_CompSourceOver;
}
Int Stat_CompDestinationOver(Int o)
{
    return Stat_Var_CompDestinationOver;
}
Int Stat_CompClear(Int o)
{
    return Stat_Var_CompClear;
}
Int Stat_CompSource(Int o)
{
    return Stat_Var_CompSource;
}
Int Stat_CompDestination(Int o)
{
    return Stat_Var_CompDestination;
}
Int Stat_CompSourceIn(Int o)
{
    return Stat_Var_CompSourceIn;
}
Int Stat_CompDestinationIn(Int o)
{
    return Stat_Var_CompDestinationIn;
}
Int Stat_CompSourceOut(Int o)
{
    return Stat_Var_CompSourceOut;
}
Int Stat_CompDestinationOut(Int o)
{
    return Stat_Var_CompDestinationOut;
}
