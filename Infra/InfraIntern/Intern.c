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

    if (!(kc == 0))
    {
        Int kca;
        kca = 0;

        if (kc < 0)
        {
            kca = -1;
        }

        if (0 < kc)
        {
            kca = 1;
        }

        RefKindInt(kca);

        Return(kca, 2);
    }
    
    Int kda;
    Int kdb;
    kda = ka;
    kdb = kb;
    RefClear(kda);
    RefClear(kdb);

    SInt kd;
    kd = kda - kdb;
    
    Int ke;
    ke = 0;

    if (kd < 0)
    {
        ke = -1;
    }
    if (0 < kd)
    {
        ke = 1;
    }

    RefKindInt(ke);

    Return(ke, 2);
}