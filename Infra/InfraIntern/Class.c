#include "Class.h"

Int Intern_Any_FieldGet[0] = { };
Int Intern_Any_FieldSet[0] = { };



Int Intern_FieldGet[0] = { };
Int Intern_FieldSet[0] = { };

Int Intern_CompState[3] = 
{
    CastInt(Intern_FieldGet), CastInt(Intern_FieldSet), 0
};

Int Intern_Base[2] =
{ 
    0,
    CastInt(Intern_CompState)
};

Int Intern_Class[2] =
{
    CastInt(Intern_Base), 0x1000000
};
