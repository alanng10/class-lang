#include "Main.h"

Int Intern_Init(Int entryClass)
{
    Main_Init();

    Int ka;
    ka = Intern_InitMainThread();

    Eval* eval;
    eval = CastPointer(ka);

    Intern_New(RefKindAny, entryClass, eval);

    Intern_Call(eval, 1, 3, 0);

    Int a;
    a = ka;
    return a;
}