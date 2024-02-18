#pragma once



#include <QString>




#include "Probate.hpp"




struct String
{
    Int Count;
    

    Int Data;
};






#define CP(a) ((String*)(a))





Int String_ConstantCount(Int o);