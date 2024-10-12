#pragma once

#include "Pronate.h"

#define VarSetDeref(dest, var, pos) (dest = *(((Int*)var) + pos))