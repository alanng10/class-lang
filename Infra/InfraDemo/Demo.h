#pragma once



#include <Infra/Prudate.h>




Bool TypeHandle(Int frame, Int index, Int field, Int arg);


Bool DrawHandle(Int frame, Int arg);


Int ThreadExecute(Int thread, Int arg);


Int ThreadAAExecute(Int thread, Int arg);



Bool TerminateHandle();



Bool MainThreadExecute();



Bool ThreadAExecute(Int thread, Int arg);



Int ThreadIntervalExecute(Int thread, Int arg);




Int ThreadIntervalElapseHandle(Int interval, Int arg);




Int ConsoleWriteConstant(const char* o);




Bool SetRect(Int rect, Int left, Int up, Int width, Int height);

Bool SetPos(Int pos, Int left, Int up);

Bool SetSize(Int size, Int width, Int height);

Bool SetRange(Int range, Int start, Int end);




int main(int argc, char* argv[]);