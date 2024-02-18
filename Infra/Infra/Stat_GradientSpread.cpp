#include "Stat.hpp"




Int Stat_Var_GradientSpreadPad = QGradient::PadSpread + 1;

Int Stat_Var_GradientSpreadReflect = QGradient::ReflectSpread + 1;

Int Stat_Var_GradientSpreadRepeat = QGradient::RepeatSpread + 1;






Int Stat_GradientSpreadPad(Int o)
{
    return Stat_Var_GradientSpreadPad;
}


Int Stat_GradientSpreadReflect(Int o)
{
    return Stat_Var_GradientSpreadReflect;
}


Int Stat_GradientSpreadRepeat(Int o)
{
    return Stat_Var_GradientSpreadRepeat;
}


