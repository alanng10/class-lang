#pragma once

#include "Pronate.h"

#define VarSetDeref(dest, var, pos) (dest = *(((Int*)var) + pos))

#define MaskClear(name, mask) (name = name & mask)

#define MaskSet(name, mask) (name = name | mask)