#include "Random.hpp"

CppClassNew(Random)

Int Random_Init(Int o)
{
    return true;
}

Int Random_Final(Int o)
{
    return true;
}

CppField(Random, Seed)
