#include "Stat.hpp"

Int Stat_Var_CompositeSourceOver = QPainter::CompositionMode_SourceOver + 1;
Int Stat_Var_CompositeDestinationOver = QPainter::CompositionMode_DestinationOver + 1;
Int Stat_Var_CompositeClear = QPainter::CompositionMode_Clear + 1;
Int Stat_Var_CompositeSource = QPainter::CompositionMode_Source + 1;
Int Stat_Var_CompositeDestination = QPainter::CompositionMode_Destination + 1;
Int Stat_Var_CompositeSourceIn = QPainter::CompositionMode_SourceIn + 1;
Int Stat_Var_CompositeDestinationIn = QPainter::CompositionMode_DestinationIn + 1;
Int Stat_Var_CompositeSourceOut = QPainter::CompositionMode_SourceOut + 1;
Int Stat_Var_CompositeDestinationOut = QPainter::CompositionMode_DestinationOut + 1;
Int Stat_Var_CompositeSourceAtop = QPainter::CompositionMode_SourceAtop + 1;
Int Stat_Var_CompositeDestinationAtop = QPainter::CompositionMode_DestinationAtop + 1;

Int Stat_CompositeSourceOver(Int o)
{
    return Stat_Var_CompositeSourceOver;
}
Int Stat_CompositeDestinationOver(Int o)
{
    return Stat_Var_CompositeDestinationOver;
}
Int Stat_CompositeClear(Int o)
{
    return Stat_Var_CompositeClear;
}
Int Stat_CompositeSource(Int o)
{
    return Stat_Var_CompositeSource;
}
Int Stat_CompositeDestination(Int o)
{
    return Stat_Var_CompositeDestination;
}
Int Stat_CompositeSourceIn(Int o)
{
    return Stat_Var_CompositeSourceIn;
}
Int Stat_CompositeDestinationIn(Int o)
{
    return Stat_Var_CompositeDestinationIn;
}
Int Stat_CompositeSourceOut(Int o)
{
    return Stat_Var_CompositeSourceOut;
}
Int Stat_CompositeDestinationOut(Int o)
{
    return Stat_Var_CompositeDestinationOut;
}
Int Stat_CompositeSourceAtop(Int o)
{
    return Stat_Var_CompositeSourceAtop;
}
Int Stat_CompositeDestinationAtop(Int o)
{
    return Stat_Var_CompositeDestinationAtop;
}
