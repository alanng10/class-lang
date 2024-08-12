#include "Intern.h"

Int Intern_RefCompare(Eval* eval, Int frame)
{
    Int ka;
    Int kb;
    ka = eval->Stack[frame - 2];
    kb = eval->Stack[frame - 1];

    Int kka;
    Int kkb;
    kka = ka >> 60;
    kkb = kb >> 60;

    SInt kc;
    kc = kka - kkb;
    kc = kc << 4;
    kc = kc >> 4;

    if (!(kc == 0))
    {
        Int kca;
        kca = kc;

        RefClear(kca);
        RefKindInt(kca);

        Return(kca, 3);
    }


    return 0;
}