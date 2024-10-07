#include "Class.h"

Int Intern_Intern_FieldGet[0] = { };
Int Intern_Intern_FieldSet[0] = { };

Int Intern_Intern_State[3] = 
{
    CastInt(Intern_Intern_FieldGet), CastInt(Intern_Intern_FieldSet), CastInt(Intern_Intern_MaideCall)
};

Int Intern_Intern_Base[2] =
{ 
    0,
    CastInt(Intern_Intern_State)
};

Int Intern_Intern_Class[3] =
{
    CastInt(Intern_Intern_Base), 0x10000000000000, 0
};
