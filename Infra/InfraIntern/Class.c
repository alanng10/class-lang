#include "Class.h"

Int Intern_Intern_StateFieldGet[0] = { };
Int Intern_Intern_StateFieldSet[0] = { };

Int Intern_Intern_BaseClass[4] = 
{
    CastInt(&Intern_Intern_Class), CastInt(Intern_Intern_StateFieldGet), CastInt(Intern_Intern_StateFieldSet), CastInt(Intern_Intern_MaideCall)
};

Int Intern_Intern_Base[2] =
{ 
    0,
    CastInt(Intern_Intern_BaseClass)
};

Int Intern_Intern_ClassAny[4] =
{
    CastInt(Intern_Intern_Base), 0x10000000000000, 0, 0
};

Int Intern_Intern_Class = CastInt(Intern_Intern_ClassAny);

Int Intern_Extern_StateFieldGet[0] = { };
Int Intern_Extern_StateFieldSet[0] = { };
Int Intern_Extern_StateMaideCall[0] = { };

Int Intern_Extern_State[3] = 
{
    CastInt(Intern_Extern_StateFieldGet), CastInt(Intern_Extern_StateFieldSet), CastInt(Intern_Extern_StateMaideCall)
};

Int Intern_Extern_Base[2] =
{ 
    0,
    CastInt(Intern_Extern_State)
};

Int Intern_Extern_ClassAny[4] =
{
    CastInt(Intern_Extern_Base), 0x10000000000000, 0, 0
};

Int Intern_Extern_Class = CastInt(Intern_Extern_ClassAny);