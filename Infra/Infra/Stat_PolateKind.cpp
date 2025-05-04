#include "Stat.hpp"

Int Stat_Var_PolateKindLinear = QGradient::LinearGradient + 1;
Int Stat_Var_PolateKindRadial = QGradient::RadialGradient + 1;

Int Stat_PolateKindLinear(Int o)
{
    return Stat_Var_PolateKindLinear;
}
Int Stat_PolateKindRadial(Int o)
{
    return Stat_Var_PolateKindRadial;
}
