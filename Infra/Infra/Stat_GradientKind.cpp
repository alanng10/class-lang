#include "Stat.hpp"

Int Stat_Var_GradientKindLinear = QGradient::LinearGradient + 1;
Int Stat_Var_GradientKindRadial = QGradient::RadialGradient + 1;

Int Stat_GradientKindLinear(Int o)
{
    return Stat_Var_GradientKindLinear;
}
Int Stat_GradientKindRadial(Int o)
{
    return Stat_Var_GradientKindRadial;
}
