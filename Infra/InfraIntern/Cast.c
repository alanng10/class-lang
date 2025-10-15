#include "Cast.h"

Int Intern_Cast(Int baseIndex, Int classVar, Eval* eval)
{
    Int k;
    k = eval->S[eval->N - 1];

    eval->S[eval->N - 1] = k;

    return 0;
}