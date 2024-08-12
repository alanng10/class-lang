#include "Intern.h"

Int Intern_Intern_RefCompare(Eval* eval, Int frame)
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
        
        RefKindClear(kca);
        RefKindInt(kca);

        Return(kca, 2);
    }
    
    Int kda;
    Int kdb;
    kda = ka;
    kdb = kb;
    RefKindClear(kda);
    RefKindClear(kdb);

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

    RefKindClear(ke);
    RefKindInt(ke);

    Return(ke, 2);
}

Int Intern_Intern_StringChar(Eval* eval, Int frame)
{
    Int s;
    Int index;
    s = eval->Stack[frame - 2];
    index = eval->Stack[frame - 1];

    Int k;
    k = s;
    RefMemoryAddress(k);

    k = k + 2 * sizeof(Int);

    Int32* p;
    p = CastPointer(k);

    Int ka;
    ka = index;
    RefKindClear(ka);

    Int32 ko;
    ko = p[ka];

    Int ke;
    ke = ko;
    RefKindInt(ke);

    Return(ke, 2);
}

Int Intern_Intern_StringCount(Eval* eval, Int frame)
{
    Int s;
    s = eval->Stack[frame - 1];

    Int k;
    k = s;
    RefMemoryAddress(k);

    k = k + sizeof(Int);

    Int* p;
    p = CastPointer(k);

    Int ke;
    ke = *p;

    Return(ke, 1);
}

Int Intern_Any_Init(Eval* eval, Int frame)
{
    Int k;
    k = BoolTrue;

    Return(k, 0);
}