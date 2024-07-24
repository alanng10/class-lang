#pragma once

#include <QPointF>

#include "Probate.hpp"

#define ValueFromInternValue(a) \
Int a##_u;\
a##_u = CastDoubleToInt(a);\
Int a##A;\
a##A = ValueGetFromInternValue(a##_u);\

