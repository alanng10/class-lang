#include "Stat.hpp"

Int Stat_Var_PolateSpreadPad = QGradient::PadSpread + 1;
Int Stat_Var_PolateSpreadReflect = QGradient::ReflectSpread + 1;
Int Stat_Var_PolateSpreadRepeat = QGradient::RepeatSpread + 1;

Int Stat_PolateSpreadPad(Int o)
{
    return Stat_Var_PolateSpreadPad;
}
Int Stat_PolateSpreadReflect(Int o)
{
    return Stat_Var_PolateSpreadReflect;
}
Int Stat_PolateSpreadRepeat(Int o)
{
    return Stat_Var_PolateSpreadRepeat;
}
