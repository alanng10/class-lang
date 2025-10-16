#include "Cast.h"

Int Intern_Cast(Int classVar, Eval* eval)
{
    Int ka;
    ka = eval->S[eval->N - 1];

    


    eval->S[eval->N - 1] = ka;

    return 0;
}