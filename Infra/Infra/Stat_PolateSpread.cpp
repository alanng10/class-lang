#include "Stat.hpp"

Int Stat_Var_PolateSpreadClose = QGradient::PadSpread + 1;
Int Stat_Var_PolateSpreadFlect = QGradient::ReflectSpread + 1;
Int Stat_Var_PolateSpreadPeatt = QGradient::RepeatSpread + 1;

Int Stat_PolateSpreadClose(Int o)
{
    return Stat_Var_PolateSpreadClose;
}
Int Stat_PolateSpreadFlect(Int o)
{
    return Stat_Var_PolateSpreadFlect;
}
Int Stat_PolateSpreadPeatt(Int o)
{
    return Stat_Var_PolateSpreadPeatt;
}
