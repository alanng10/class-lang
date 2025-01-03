#pragma once



#include <Infra/Prusate.h>




Bool TypeHandle(Int frame, Int index, Int field, Int arg);


Bool DrawHandle(Int frame, Int arg);



Int ConsoleWriteConstant(const char* o);




Bool SetRect(Int rect, Int left, Int up, Int width, Int height);

Bool SetPos(Int pos, Int left, Int up);

Bool SetSize(Int size, Int width, Int height);

Bool SetRange(Int range, Int index, Int count);

Int MathInt(Int n);



int main(int argc, char* argv[]);