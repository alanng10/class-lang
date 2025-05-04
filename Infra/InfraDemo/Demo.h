#pragma once

#include <Infra/Prusate.h>

Int TypeHandle(Int frame, Int index, Int field, Int arg);

Int DrawHandle(Int frame, Int arg);

Int VideoOutFrameHandle(Int videoOut, Int arg);

Int ConsoleWriteConstant(const char* o);

Int SetRect(Int rect, Int left, Int up, Int width, Int height);

Int SetPos(Int pos, Int left, Int up);

Int SetSize(Int size, Int width, Int height);

Int SetRange(Int range, Int index, Int count);

Int MathInt(Int n);

int main(int argc, char* argv[]);
