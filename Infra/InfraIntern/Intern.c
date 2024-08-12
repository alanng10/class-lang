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
        kca = kc;
        
        RefClear(kca);
        RefKindInt(kca);

        Return(kca, 2);
    }
    
    Int kda;
    Int kdb;
    kda = ka;
    kdb = kb;
    RefClear(kda);
    RefClear(kdb);

    SInt kdo;
    kdo = kda - kdb;
    
    SInt kea;
    kea = 0;

    if (kdo < 0)
    {
        kea = -1;
    }
    if (0 < kdo)
    {
        kea = 1;
    }

    Int ke;
    ke = kea;

    RefClear(ke);
    RefKindInt(ke);

    Return(ke, 2);
}