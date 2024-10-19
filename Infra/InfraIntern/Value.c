#include "Value.h"

Int Intern_Value_Init(Eval* eval, Int frame)
{
    Int ke;
    ke = BoolTrue;

    Return(ke, 1);
}


extern Int Intern_Value_ClassAny[5];

Int Intern_Value_FieldGet[0] = { };

Int Intern_Value_FieldSet[0] = { };

Int Intern_Value_MaideCall[1] =
{
    CastInt(Intern_Value_Init)
};

Int Intern_Value_BaseItem[4] =
{
    CastInt(Intern_Value_ClassAny),
    CastInt(Intern_Value_FieldGet),
    CastInt(Intern_Value_FieldSet),
    CastInt(Intern_Value_MaideCall),
};

Int Intern_Value_Base[1] =
{
    CastInt(Intern_Value_BaseItem)
};

Int Intern_Value_ClassAny[5] =
{
    CastInt(Intern_Value_Base),
    0,
    0,
    0,
    0
};

Int Intern_Value_Class = CastInt(Intern_Value_ClassAny);

Int Intern_Value_Any[1] =
{
    CastInt(Intern_Value_ClassAny)
};

Int Intern_Value_Ref = (CastInt(Intern_Value_Any)) + (RefKindValueAny << 60);