#include "Class.h"

Int Intern_Any_FieldGet[0] = { };
Int Intern_Any_FieldSet[0] = { };
Int Intern_Any_MaideCall[1] = { CastInt(Intern_Any_Init) };

Int Intern_Any_State[3] = 
{
    CastInt(Intern_Any_FieldGet), CastInt(Intern_Any_FieldSet), CastInt(Intern_Any_MaideCall)
};


Int Intern_Intern_FieldGet[0] = { };
Int Intern_Intern_FieldSet[0] = { };

Int Intern_Intern_State[3] = 
{
    CastInt(Intern_Intern_FieldGet), CastInt(Intern_Intern_FieldSet), CastInt(Intern_Intern_MaideCall)
};

Int Intern_Intern_Base[2] =
{ 
    CastInt(Intern_Any_State),
    CastInt(Intern_Intern_State)
};

Int Intern_Intern_Class[3] =
{
    CastInt(Intern_Intern_Base), 0x1000000, 0
};
