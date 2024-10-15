#include "Extern.h"

Int IntNull = ((Int)((SInt)-1));

Int Intern_Extern_New(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = New(a0);

    Return;
}

Int Intern_Extern_Delete(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Delete(a0);

    Return;
}

Int Intern_Extern_Copy(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 3;

    Param(0);
    Param(1);
    Param(2);

    Int a;
    a = Copy(a0, a1, a2);

    Return;
}

Int Intern_Extern_Exit(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Exit(a0);

    Return;
}


Int Intern_Extern_String_New(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 0;

    Int a;
    a = String_New();

    Return;
}
Int Intern_Extern_String_Delete(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = String_Delete(a0);

    Return;
}

Int Intern_Extern_String_Init(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = String_Init(a0);

    Return;
}

Int Intern_Extern_String_Final(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = String_Final(a0);

    Return;
}

Int Intern_Extern_String_CountGet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = String_CountGet(a0);

    Return;
}

Int Intern_Extern_String_CountSet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = String_CountSet(a0, a1);

    Return;
}

Int Intern_Extern_String_DataGet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = String_DataGet(a0);

    Return;
}

Int Intern_Extern_String_DataSet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = String_DataSet(a0, a1);

    Return;
}

Int Intern_Extern_String_Char(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = String_Char(a0, a1);

    Return;
}

Int Intern_Extern_String_Equal(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = String_Equal(a0, a1);

    Return;
}

Int Intern_Extern_String_ConstantCreate(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = String_ConstantCreate(a0);

    Return;
}

Int Intern_Extern_String_ConstantDelete(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = String_ConstantDelete(a0);

    Return;
}

Int Intern_Extern_Console_New(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 0;

    Int a;
    a = Console_New();

    Return;
}

Int Intern_Extern_Console_Delete(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Console_Delete(a0);

    Return;
}

Int Intern_Extern_Console_Init(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Console_Init(a0);

    Return;
}

Int Intern_Extern_Console_Final(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Console_Final(a0);

    Return;
}

Int Intern_Extern_Console_OutWrite(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = Console_OutWrite(a0, a1);

    Return;
}

Int Intern_Extern_Console_ErrWrite(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = Console_ErrWrite(a0, a1);

    Return;
}

Int Intern_Extern_Console_InnRead(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Console_InnRead(a0);

    Return;
}

Int Intern_Extern_Array_New(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 0;

    Int a;
    a = Array_New();

    Return;
}

Int Intern_Extern_Array_Delete(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Array_Delete(a0);

    Return;
}

Int Intern_Extern_Array_Init(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Array_Init(a0);

    Return;
}

Int Intern_Extern_Array_Final(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Array_Final(a0);

    Return;
}

Int Intern_Extern_Array_CountGet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Array_CountGet(a0);

    Return;
}

Int Intern_Extern_Array_CountSet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = Array_CountSet(a0, a1);

    Return;
}

Int Intern_Extern_Array_ItemGet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = Array_ItemGet(a0, a1);

    Return;
}

Int Intern_Extern_Array_ItemSet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 3;

    Param(0);
    Param(1);
    Param(2);

    Int a;
    a = Array_ItemSet(a0, a1, a2);

    Return;
}

Int Intern_Extern_TextCode_New(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 0;

    Int a;
    a = TextCode_New();

    Return;
}

Int Intern_Extern_TextCode_Delete(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = TextCode_Delete(a0);

    Return;
}

Int Intern_Extern_TextCode_Init(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = TextCode_Init(a0);

    Return;
}

Int Intern_Extern_TextCode_Final(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = TextCode_Final(a0);

    Return;
}

Int Intern_Extern_TextCode_ExecuteCount(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 5;

    Param(0);
    Param(1);
    Param(2);
    Param(3);
    Param(4);

    Int a;
    a = TextCode_ExecuteCount(a0, a1, a2, a3, a4);

    Return;
}

Int Intern_Extern_TextCode_ExecuteResult(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 6;

    Param(0);
    Param(1);
    Param(2);
    Param(3);
    Param(4);
    Param(5);

    Int a;
    a = TextCode_ExecuteResult(a0, a1, a2, a3, a4, a5);

    Return;
}

Int Intern_Extern_Format_New(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 0;

    Int a;
    a = Format_New();

    Return;
}

Int Intern_Extern_Format_Delete(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Format_Delete(a0);

    Return;
}

Int Intern_Extern_Format_Init(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Format_Init(a0);

    Return;
}

Int Intern_Extern_Format_Final(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Format_Final(a0);

    Return;
}

Int Intern_Extern_Format_ExecuteCount(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 3;

    Param(0);
    Param(1);
    Param(2);

    Int a;
    a = Format_ExecuteCount(a0, a1, a2);

    Return;
}

Int Intern_Extern_Format_ExecuteResult(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 4;

    Param(0);
    Param(1);
    Param(2);
    Param(3);

    Int a;
    a = Format_ExecuteResult(a0, a1, a2, a3);

    Return;
}

Int Intern_Extern_Format_ExecuteArgCount(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = Format_ExecuteArgCount(a0, a1);

    Return;
}

Int Intern_Extern_Format_ExecuteArgResult(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 3;

    Param(0);
    Param(1);
    Param(2);

    Int a;
    a = Format_ExecuteArgResult(a0, a1, a2);

    Return;
}

Int Intern_Extern_FormatArg_New(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 0;

    Int a;
    a = FormatArg_New();

    Return;
}

Int Intern_Extern_FormatArg_Delete(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = FormatArg_Delete(a0);

    Return;
}

Int Intern_Extern_FormatArg_Init(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = FormatArg_Init(a0);

    Return;
}

Int Intern_Extern_FormatArg_Final(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = FormatArg_Final(a0);

    Return;
}

Int Intern_Extern_FormatArg_PosGet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = FormatArg_PosGet(a0);

    Return;
}

Int Intern_Extern_FormatArg_PosSet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = FormatArg_PosSet(a0, a1);

    Return;
}

Int Intern_Extern_FormatArg_KindGet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = FormatArg_KindGet(a0);

    Return;
}

Int Intern_Extern_FormatArg_KindSet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = FormatArg_KindSet(a0, a1);

    Return;
}

Int Intern_Extern_FormatArg_ValueGet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = FormatArg_ValueGet(a0);

    Return;
}

Int Intern_Extern_FormatArg_ValueSet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = FormatArg_ValueSet(a0, a1);

    Return;
}

Int Intern_Extern_FormatArg_AlignLeftGet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = FormatArg_AlignLeftGet(a0);

    Return;
}

Int Intern_Extern_FormatArg_AlignLeftSet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = FormatArg_AlignLeftSet(a0, a1);

    Return;
}

Int Intern_Extern_FormatArg_FieldWidthGet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = FormatArg_FieldWidthGet(a0);

    Return;
}

Int Intern_Extern_FormatArg_FieldWidthSet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = FormatArg_FieldWidthSet(a0, a1);

    Return;
}

Int Intern_Extern_FormatArg_MaxWidthGet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = FormatArg_MaxWidthGet(a0);

    Return;
}

Int Intern_Extern_FormatArg_MaxWidthSet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = FormatArg_MaxWidthSet(a0, a1);

    Return;
}

Int Intern_Extern_FormatArg_CaseGet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = FormatArg_CaseGet(a0);

    Return;
}

Int Intern_Extern_FormatArg_CaseSet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = FormatArg_CaseSet(a0, a1);

    Return;
}

Int Intern_Extern_FormatArg_BaseGet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = FormatArg_BaseGet(a0);

    Return;
}

Int Intern_Extern_FormatArg_BaseSet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = FormatArg_BaseSet(a0, a1);

    Return;
}

Int Intern_Extern_FormatArg_SignGet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = FormatArg_SignGet(a0);

    Return;
}

Int Intern_Extern_FormatArg_SignSet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = FormatArg_SignSet(a0, a1);

    Return;
}

Int Intern_Extern_FormatArg_FillCharGet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = FormatArg_FillCharGet(a0);

    Return;
}

Int Intern_Extern_FormatArg_FillCharSet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = FormatArg_FillCharSet(a0, a1);

    Return;
}

Int Intern_Extern_FormatArg_HasCountGet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = FormatArg_HasCountGet(a0);

    Return;
}

Int Intern_Extern_FormatArg_HasCountSet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = FormatArg_HasCountSet(a0, a1);

    Return;
}

Int Intern_Extern_FormatArg_ValueCountGet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = FormatArg_ValueCountGet(a0);

    Return;
}

Int Intern_Extern_FormatArg_ValueCountSet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = FormatArg_ValueCountSet(a0, a1);

    Return;
}

Int Intern_Extern_FormatArg_CountGet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = FormatArg_CountGet(a0);

    Return;
}

Int Intern_Extern_FormatArg_CountSet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = FormatArg_CountSet(a0, a1);

    Return;
}

Int Intern_Extern_Math_New(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 0;

    Int a;
    a = Math_New();

    Return;
}

Int Intern_Extern_Math_Delete(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Math_Delete(a0);

    Return;
}

Int Intern_Extern_Math_Init(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Math_Init(a0);

    Return;
}

Int Intern_Extern_Math_Final(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Math_Final(a0);

    Return;
}

Int Intern_Extern_Math_Value(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 3;

    Param(0);
    Param(1);
    Param(2);

    Int a;
    a = Math_Value(a0, a1, a2);

    Return;
}

Int Intern_Extern_Math_ValueTen(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 3;

    Param(0);
    Param(1);
    Param(2);

    Int a;
    a = Math_ValueTen(a0, a1, a2);

    Return;
}

Int Intern_Extern_Math_Less(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 3;

    Param(0);
    Param(1);
    Param(2);

    Int a;
    a = Math_Less(a0, a1, a2);

    Return;
}

Int Intern_Extern_Math_Add(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 3;

    Param(0);
    Param(1);
    Param(2);

    Int a;
    a = Math_Add(a0, a1, a2);

    Return;
}

Int Intern_Extern_Math_Sub(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 3;

    Param(0);
    Param(1);
    Param(2);

    Int a;
    a = Math_Sub(a0, a1, a2);

    Return;
}

Int Intern_Extern_Math_Mul(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 3;

    Param(0);
    Param(1);
    Param(2);

    Int a;
    a = Math_Mul(a0, a1, a2);

    Return;
}

Int Intern_Extern_Math_Div(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 3;

    Param(0);
    Param(1);
    Param(2);

    Int a;
    a = Math_Div(a0, a1, a2);

    Return;
}

Int Intern_Extern_Math_Abs(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = Math_Abs(a0, a1);

    Return;
}

Int Intern_Extern_Math_Exp(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = Math_Exp(a0, a1);

    Return;
}

Int Intern_Extern_Math_Exp2(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = Math_Exp2(a0, a1);

    Return;
}

Int Intern_Extern_Math_Log(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = Math_Log(a0, a1);

    Return;
}

Int Intern_Extern_Math_Log10(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = Math_Log10(a0, a1);

    Return;
}

Int Intern_Extern_Math_Log2(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = Math_Log2(a0, a1);

    Return;
}

Int Intern_Extern_Math_Pow(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 3;

    Param(0);
    Param(1);
    Param(2);

    Int a;
    a = Math_Pow(a0, a1, a2);

    Return;
}

Int Intern_Extern_Math_Ceil(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = Math_Ceil(a0, a1);

    Return;
}

Int Intern_Extern_Math_Floor(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = Math_Floor(a0, a1);

    Return;
}

Int Intern_Extern_Math_Trunc(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = Math_Trunc(a0, a1);

    Return;
}

Int Intern_Extern_Math_Round(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = Math_Round(a0, a1);

    Return;
}

Int Intern_Extern_Math_Sin(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = Math_Sin(a0, a1);

    Return;
}

Int Intern_Extern_Math_Cos(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = Math_Cos(a0, a1);

    Return;
}

Int Intern_Extern_Math_Tan(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = Math_Tan(a0, a1);

    Return;
}

Int Intern_Extern_Math_ASin(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = Math_ASin(a0, a1);

    Return;
}

Int Intern_Extern_Math_ACos(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = Math_ACos(a0, a1);

    Return;
}

Int Intern_Extern_Math_ATan(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = Math_ATan(a0, a1);

    Return;
}

Int Intern_Extern_Math_SinH(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = Math_SinH(a0, a1);

    Return;
}

Int Intern_Extern_Math_CosH(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = Math_CosH(a0, a1);

    Return;
}

Int Intern_Extern_Math_TanH(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = Math_TanH(a0, a1);

    Return;
}

Int Intern_Extern_Math_ASinH(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = Math_ASinH(a0, a1);

    Return;
}

Int Intern_Extern_Math_ACosH(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = Math_ACosH(a0, a1);

    Return;
}

Int Intern_Extern_Math_ATanH(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = Math_ATanH(a0, a1);

    Return;
}

Int Intern_Extern_Rand_New(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 0;

    Int a;
    a = Rand_New();

    Return;
}

Int Intern_Extern_Rand_Delete(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Rand_Delete(a0);

    Return;
}

Int Intern_Extern_Rand_Init(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Rand_Init(a0);

    Return;
}

Int Intern_Extern_Rand_Final(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Rand_Final(a0);

    Return;
}

Int Intern_Extern_Rand_SeedGet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Rand_SeedGet(a0);

    Return;
}

Int Intern_Extern_Rand_SeedSet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = Rand_SeedSet(a0, a1);

    Return;
}

Int Intern_Extern_Rand_Execute(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Rand_Execute(a0);

    Return;
}

Int Intern_Extern_Range_New(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 0;

    Int a;
    a = Range_New();

    Return;
}

Int Intern_Extern_Range_Delete(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Range_Delete(a0);

    Return;
}

Int Intern_Extern_Range_Init(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Range_Init(a0);

    Return;
}

Int Intern_Extern_Range_Final(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Range_Final(a0);

    Return;
}

Int Intern_Extern_Range_IndexGet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Range_IndexGet(a0);

    Return;
}

Int Intern_Extern_Range_IndexSet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = Range_IndexSet(a0, a1);

    Return;
}

Int Intern_Extern_Range_CountGet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Range_CountGet(a0);

    Return;
}

Int Intern_Extern_Range_CountSet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = Range_CountSet(a0, a1);

    Return;
}

Int Intern_Extern_Rect_New(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 0;

    Int a;
    a = Rect_New();

    Return;
}

Int Intern_Extern_Rect_Delete(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Rect_Delete(a0);

    Return;
}

Int Intern_Extern_Rect_Init(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Rect_Init(a0);

    Return;
}

Int Intern_Extern_Rect_Final(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Rect_Final(a0);

    Return;
}

Int Intern_Extern_Rect_PosGet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Rect_PosGet(a0);

    Return;
}

Int Intern_Extern_Rect_PosSet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = Rect_PosSet(a0, a1);

    Return;
}

Int Intern_Extern_Rect_SizeGet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Rect_SizeGet(a0);

    Return;
}

Int Intern_Extern_Rect_SizeSet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = Rect_SizeSet(a0, a1);

    Return;
}

Int Intern_Extern_Pos_New(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 0;

    Int a;
    a = Pos_New();

    Return;
}

Int Intern_Extern_Pos_Delete(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Pos_Delete(a0);

    Return;
}

Int Intern_Extern_Pos_Init(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Pos_Init(a0);

    Return;
}

Int Intern_Extern_Pos_Final(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Pos_Final(a0);

    Return;
}

Int Intern_Extern_Pos_ColGet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Pos_ColGet(a0);

    Return;
}

Int Intern_Extern_Pos_ColSet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = Pos_ColSet(a0, a1);

    Return;
}

Int Intern_Extern_Pos_RowGet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Pos_RowGet(a0);

    Return;
}

Int Intern_Extern_Pos_RowSet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = Pos_RowSet(a0, a1);

    Return;
}

Int Intern_Extern_Size_New(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 0;

    Int a;
    a = Size_New();

    Return;
}

Int Intern_Extern_Size_Delete(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Size_Delete(a0);

    Return;
}

Int Intern_Extern_Size_Init(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Size_Init(a0);

    Return;
}

Int Intern_Extern_Size_Final(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Size_Final(a0);

    Return;
}

Int Intern_Extern_Size_WedGet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Size_WedGet(a0);

    Return;
}

Int Intern_Extern_Size_WedSet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = Size_WedSet(a0, a1);

    Return;
}

Int Intern_Extern_Size_HetGet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Size_HetGet(a0);

    Return;
}

Int Intern_Extern_Size_HetSet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = Size_HetSet(a0, a1);

    Return;
}

Int Intern_Extern_Data_New(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 0;

    Int a;
    a = Data_New();

    Return;
}

Int Intern_Extern_Data_Delete(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Data_Delete(a0);

    Return;
}

Int Intern_Extern_Data_Init(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Data_Init(a0);

    Return;
}

Int Intern_Extern_Data_Final(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Data_Final(a0);

    Return;
}

Int Intern_Extern_Data_CountGet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Data_CountGet(a0);

    Return;
}

Int Intern_Extern_Data_CountSet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = Data_CountSet(a0, a1);

    Return;
}

Int Intern_Extern_Data_ValueGet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Data_ValueGet(a0);

    Return;
}

Int Intern_Extern_Data_ValueSet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = Data_ValueSet(a0, a1);

    Return;
}

Int Intern_Extern_Entry_New(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 0;

    Int a;
    a = Entry_New();

    Return;
}

Int Intern_Extern_Entry_Delete(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Entry_Delete(a0);

    Return;
}

Int Intern_Extern_Entry_Init(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Entry_Init(a0);

    Return;
}

Int Intern_Extern_Entry_Final(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Entry_Final(a0);

    Return;
}

Int Intern_Extern_Entry_IndexGet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Entry_IndexGet(a0);

    Return;
}

Int Intern_Extern_Entry_IndexSet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = Entry_IndexSet(a0, a1);

    Return;
}

Int Intern_Extern_Entry_ValueGet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Entry_ValueGet(a0);

    Return;
}

Int Intern_Extern_Entry_ValueSet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = Entry_ValueSet(a0, a1);

    Return;
}

Int Intern_Extern_State_New(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 0;

    Int a;
    a = State_New();

    Return;
}

Int Intern_Extern_State_Delete(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = State_Delete(a0);

    Return;
}

Int Intern_Extern_State_Init(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = State_Init(a0);

    Return;
}

Int Intern_Extern_State_Final(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = State_Final(a0);

    Return;
}

Int Intern_Extern_State_MaideGet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = State_MaideGet(a0);

    Return;
}

Int Intern_Extern_State_MaideSet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = State_MaideSet(a0, a1);

    Return;
}

Int Intern_Extern_State_ArgGet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = State_ArgGet(a0);

    Return;
}

Int Intern_Extern_State_ArgSet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = State_ArgSet(a0, a1);

    Return;
}

Int Intern_Extern_Main_TerminateStateGet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 0;

    Int a;
    a = Main_TerminateStateGet();

    Return;
}

Int Intern_Extern_Main_TerminateStateSet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Main_TerminateStateSet(a0);

    Return;
}

Int Intern_Extern_Main_Init(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 0;

    Int a;
    a = Main_Init();

    Return;
}

Int Intern_Extern_Main_Final(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 0;

    Int a;
    a = Main_Final();

    Return;
}

Int Intern_Extern_Main_IsCSharpSet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Main_IsCSharpSet(a0);

    Return;
}

Int Intern_Extern_Main_Arg(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 0;

    Int a;
    a = Main_Arg();

    Return;
}

Int Intern_Extern_Main_ExecuteEventLoop(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 0;

    Int a;
    a = Main_ExecuteEventLoop();

    Return;
}

Int Intern_Extern_Main_ExitEventLoop(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Main_ExitEventLoop(a0);

    Return;
}

Int Intern_Extern_Frame_New(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 0;

    Int a;
    a = Frame_New();

    Return;
}

Int Intern_Extern_Frame_Delete(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Frame_Delete(a0);

    Return;
}

Int Intern_Extern_Frame_Init(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Frame_Init(a0);

    Return;
}

Int Intern_Extern_Frame_Final(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Frame_Final(a0);

    Return;
}

Int Intern_Extern_Frame_TitleGet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Frame_TitleGet(a0);

    Return;
}

Int Intern_Extern_Frame_TitleSet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = Frame_TitleSet(a0, a1);

    Return;
}

Int Intern_Extern_Frame_VisibleGet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Frame_VisibleGet(a0);

    Return;
}

Int Intern_Extern_Frame_VisibleSet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = Frame_VisibleSet(a0, a1);

    Return;
}

Int Intern_Extern_Frame_SizeGet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Frame_SizeGet(a0);

    Return;
}

Int Intern_Extern_Frame_SizeSet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = Frame_SizeSet(a0, a1);

    Return;
}

Int Intern_Extern_Frame_TypeStateGet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Frame_TypeStateGet(a0);

    Return;
}

Int Intern_Extern_Frame_TypeStateSet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = Frame_TypeStateSet(a0, a1);

    Return;
}

Int Intern_Extern_Frame_DrawStateGet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Frame_DrawStateGet(a0);

    Return;
}

Int Intern_Extern_Frame_DrawStateSet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = Frame_DrawStateSet(a0, a1);

    Return;
}

Int Intern_Extern_Frame_TitleThisSet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Frame_TitleThisSet(a0);

    Return;
}

Int Intern_Extern_Frame_VideoOut(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Frame_VideoOut(a0);

    Return;
}

Int Intern_Extern_Frame_Update(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = Frame_Update(a0, a1);

    Return;
}

Int Intern_Extern_Frame_Close(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Frame_Close(a0);

    Return;
}

Int Intern_Extern_Draw_New(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 0;

    Int a;
    a = Draw_New();

    Return;
}

Int Intern_Extern_Draw_Delete(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Draw_Delete(a0);

    Return;
}

Int Intern_Extern_Draw_Init(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Draw_Init(a0);

    Return;
}

Int Intern_Extern_Draw_Final(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Draw_Final(a0);

    Return;
}

Int Intern_Extern_Draw_SizeGet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Draw_SizeGet(a0);

    Return;
}

Int Intern_Extern_Draw_SizeSet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = Draw_SizeSet(a0, a1);

    Return;
}

Int Intern_Extern_Draw_OutGet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Draw_OutGet(a0);

    Return;
}

Int Intern_Extern_Draw_OutSet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = Draw_OutSet(a0, a1);

    Return;
}

Int Intern_Extern_Draw_AreaGet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Draw_AreaGet(a0);

    Return;
}

Int Intern_Extern_Draw_AreaSet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = Draw_AreaSet(a0, a1);

    Return;
}

Int Intern_Extern_Draw_FillGet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Draw_FillGet(a0);

    Return;
}

Int Intern_Extern_Draw_FillSet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = Draw_FillSet(a0, a1);

    Return;
}

Int Intern_Extern_Draw_FillPosGet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Draw_FillPosGet(a0);

    Return;
}

Int Intern_Extern_Draw_FillPosSet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = Draw_FillPosSet(a0, a1);

    Return;
}

Int Intern_Extern_Draw_StrokeGet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Draw_StrokeGet(a0);

    Return;
}

Int Intern_Extern_Draw_StrokeSet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = Draw_StrokeSet(a0, a1);

    Return;
}

Int Intern_Extern_Draw_FaceGet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Draw_FaceGet(a0);

    Return;
}

Int Intern_Extern_Draw_FaceSet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = Draw_FaceSet(a0, a1);

    Return;
}

Int Intern_Extern_Draw_FormGet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Draw_FormGet(a0);

    Return;
}

Int Intern_Extern_Draw_FormSet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = Draw_FormSet(a0, a1);

    Return;
}

Int Intern_Extern_Draw_CompGet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Draw_CompGet(a0);

    Return;
}

Int Intern_Extern_Draw_CompSet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = Draw_CompSet(a0, a1);

    Return;
}

Int Intern_Extern_Draw_Start(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Draw_Start(a0);

    Return;
}

Int Intern_Extern_Draw_End(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Draw_End(a0);

    Return;
}

Int Intern_Extern_Draw_FillPosThisSet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Draw_FillPosThisSet(a0);

    Return;
}

Int Intern_Extern_Draw_AreaThisSet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Draw_AreaThisSet(a0);

    Return;
}

Int Intern_Extern_Draw_Clear(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = Draw_Clear(a0, a1);

    Return;
}

Int Intern_Extern_Draw_ExecuteLine(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 3;

    Param(0);
    Param(1);
    Param(2);

    Int a;
    a = Draw_ExecuteLine(a0, a1, a2);

    Return;
}

Int Intern_Extern_Draw_ExecuteRect(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = Draw_ExecuteRect(a0, a1);

    Return;
}

Int Intern_Extern_Draw_ExecuteRectRound(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 4;

    Param(0);
    Param(1);
    Param(2);
    Param(3);

    Int a;
    a = Draw_ExecuteRectRound(a0, a1, a2, a3);

    Return;
}

Int Intern_Extern_Draw_ExecuteRound(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = Draw_ExecuteRound(a0, a1);

    Return;
}

Int Intern_Extern_Draw_ExecuteRoundLine(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 3;

    Param(0);
    Param(1);
    Param(2);

    Int a;
    a = Draw_ExecuteRoundLine(a0, a1, a2);

    Return;
}

Int Intern_Extern_Draw_ExecuteRoundPart(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 3;

    Param(0);
    Param(1);
    Param(2);

    Int a;
    a = Draw_ExecuteRoundPart(a0, a1, a2);

    Return;
}

Int Intern_Extern_Draw_ExecuteRoundShape(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 3;

    Param(0);
    Param(1);
    Param(2);

    Int a;
    a = Draw_ExecuteRoundShape(a0, a1, a2);

    Return;
}

Int Intern_Extern_Draw_ExecuteShape(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 3;

    Param(0);
    Param(1);
    Param(2);

    Int a;
    a = Draw_ExecuteShape(a0, a1, a2);

    Return;
}

Int Intern_Extern_Draw_ExecuteShapeLine(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 3;

    Param(0);
    Param(1);
    Param(2);

    Int a;
    a = Draw_ExecuteShapeLine(a0, a1, a2);

    Return;
}

Int Intern_Extern_Draw_ExecuteImage(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 4;

    Param(0);
    Param(1);
    Param(2);
    Param(3);

    Int a;
    a = Draw_ExecuteImage(a0, a1, a2, a3);

    Return;
}

Int Intern_Extern_Draw_ExecuteText(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 7;

    Param(0);
    Param(1);
    Param(2);
    Param(3);
    Param(4);
    Param(5);
    Param(6);

    Int a;
    a = Draw_ExecuteText(a0, a1, a2, a3, a4, a5, a6);

    Return;
}

Int Intern_Extern_Brush_New(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 0;

    Int a;
    a = Brush_New();

    Return;
}

Int Intern_Extern_Brush_Delete(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Brush_Delete(a0);

    Return;
}

Int Intern_Extern_Brush_Init(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Brush_Init(a0);

    Return;
}

Int Intern_Extern_Brush_Final(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Brush_Final(a0);

    Return;
}

Int Intern_Extern_Brush_KindGet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Brush_KindGet(a0);

    Return;
}

Int Intern_Extern_Brush_KindSet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = Brush_KindSet(a0, a1);

    Return;
}

Int Intern_Extern_Brush_ColorGet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Brush_ColorGet(a0);

    Return;
}

Int Intern_Extern_Brush_ColorSet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = Brush_ColorSet(a0, a1);

    Return;
}

Int Intern_Extern_Brush_PolateGet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Brush_PolateGet(a0);

    Return;
}

Int Intern_Extern_Brush_PolateSet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = Brush_PolateSet(a0, a1);

    Return;
}

Int Intern_Extern_Brush_ImageGet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Brush_ImageGet(a0);

    Return;
}

Int Intern_Extern_Brush_ImageSet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = Brush_ImageSet(a0, a1);

    Return;
}

Int Intern_Extern_Brush_LineGet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Brush_LineGet(a0);

    Return;
}

Int Intern_Extern_Brush_LineSet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = Brush_LineSet(a0, a1);

    Return;
}

Int Intern_Extern_Brush_WidthGet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Brush_WidthGet(a0);

    Return;
}

Int Intern_Extern_Brush_WidthSet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = Brush_WidthSet(a0, a1);

    Return;
}

Int Intern_Extern_Brush_CapGet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Brush_CapGet(a0);

    Return;
}

Int Intern_Extern_Brush_CapSet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = Brush_CapSet(a0, a1);

    Return;
}

Int Intern_Extern_Brush_JoinGet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Brush_JoinGet(a0);

    Return;
}

Int Intern_Extern_Brush_JoinSet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = Brush_JoinSet(a0, a1);

    Return;
}

Int Intern_Extern_PointData_PointGet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = PointData_PointGet(a0, a1);

    Return;
}

Int Intern_Extern_PointData_PointSet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = PointData_PointSet(a0, a1);

    Return;
}

Int Intern_Extern_Image_New(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 0;

    Int a;
    a = Image_New();

    Return;
}

Int Intern_Extern_Image_Delete(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Image_Delete(a0);

    Return;
}

Int Intern_Extern_Image_Init(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Image_Init(a0);

    Return;
}

Int Intern_Extern_Image_Final(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Image_Final(a0);

    Return;
}

Int Intern_Extern_Image_SizeGet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Image_SizeGet(a0);

    Return;
}

Int Intern_Extern_Image_SizeSet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = Image_SizeSet(a0, a1);

    Return;
}

Int Intern_Extern_Image_DataGet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Image_DataGet(a0);

    Return;
}

Int Intern_Extern_Image_DataSet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = Image_DataSet(a0, a1);

    Return;
}

Int Intern_Extern_Image_VideoOut(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Image_VideoOut(a0);

    Return;
}

Int Intern_Extern_Image_DataCreate(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Image_DataCreate(a0);

    Return;
}

Int Intern_Extern_Face_New(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 0;

    Int a;
    a = Face_New();

    Return;
}

Int Intern_Extern_Face_Delete(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Face_Delete(a0);

    Return;
}

Int Intern_Extern_Face_Init(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Face_Init(a0);

    Return;
}

Int Intern_Extern_Face_Final(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Face_Final(a0);

    Return;
}

Int Intern_Extern_Face_FamilyGet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Face_FamilyGet(a0);

    Return;
}

Int Intern_Extern_Face_FamilySet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = Face_FamilySet(a0, a1);

    Return;
}

Int Intern_Extern_Face_SizeGet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Face_SizeGet(a0);

    Return;
}

Int Intern_Extern_Face_SizeSet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = Face_SizeSet(a0, a1);

    Return;
}

Int Intern_Extern_Face_WeightGet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Face_WeightGet(a0);

    Return;
}

Int Intern_Extern_Face_WeightSet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = Face_WeightSet(a0, a1);

    Return;
}

Int Intern_Extern_Face_ItalicGet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Face_ItalicGet(a0);

    Return;
}

Int Intern_Extern_Face_ItalicSet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = Face_ItalicSet(a0, a1);

    Return;
}

Int Intern_Extern_Face_UnderlineGet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Face_UnderlineGet(a0);

    Return;
}

Int Intern_Extern_Face_UnderlineSet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = Face_UnderlineSet(a0, a1);

    Return;
}

Int Intern_Extern_Face_OverlineGet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Face_OverlineGet(a0);

    Return;
}

Int Intern_Extern_Face_OverlineSet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = Face_OverlineSet(a0, a1);

    Return;
}

Int Intern_Extern_Face_StrikeoutGet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Face_StrikeoutGet(a0);

    Return;
}

Int Intern_Extern_Face_StrikeoutSet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = Face_StrikeoutSet(a0, a1);

    Return;
}

Int Intern_Extern_Form_New(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 0;

    Int a;
    a = Form_New();

    Return;
}

Int Intern_Extern_Form_Delete(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Form_Delete(a0);

    Return;
}

Int Intern_Extern_Form_Init(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Form_Init(a0);

    Return;
}

Int Intern_Extern_Form_Final(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Form_Final(a0);

    Return;
}

Int Intern_Extern_Form_Reset(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Form_Reset(a0);

    Return;
}

Int Intern_Extern_Form_Offset(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 3;

    Param(0);
    Param(1);
    Param(2);

    Int a;
    a = Form_Offset(a0, a1, a2);

    Return;
}

Int Intern_Extern_Form_Scale(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 3;

    Param(0);
    Param(1);
    Param(2);

    Int a;
    a = Form_Scale(a0, a1, a2);

    Return;
}

Int Intern_Extern_Form_Rotate(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = Form_Rotate(a0, a1);

    Return;
}

Int Intern_Extern_Form_ValueGet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 3;

    Param(0);
    Param(1);
    Param(2);

    Int a;
    a = Form_ValueGet(a0, a1, a2);

    Return;
}

Int Intern_Extern_Form_ValueSet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 4;

    Param(0);
    Param(1);
    Param(2);
    Param(3);

    Int a;
    a = Form_ValueSet(a0, a1, a2, a3);

    Return;
}

Int Intern_Extern_Form_Multiply(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = Form_Multiply(a0, a1);

    Return;
}

Int Intern_Extern_Form_IsIdentity(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Form_IsIdentity(a0);

    Return;
}

Int Intern_Extern_Form_IsInvertible(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Form_IsInvertible(a0);

    Return;
}

Int Intern_Extern_Form_Invert(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = Form_Invert(a0, a1);

    Return;
}

Int Intern_Extern_Form_Transpose(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = Form_Transpose(a0, a1);

    Return;
}

Int Intern_Extern_Polate_New(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 0;

    Int a;
    a = Polate_New();

    Return;
}

Int Intern_Extern_Polate_Delete(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Polate_Delete(a0);

    Return;
}

Int Intern_Extern_Polate_Init(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Polate_Init(a0);

    Return;
}

Int Intern_Extern_Polate_Final(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Polate_Final(a0);

    Return;
}

Int Intern_Extern_Polate_KindGet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Polate_KindGet(a0);

    Return;
}

Int Intern_Extern_Polate_KindSet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = Polate_KindSet(a0, a1);

    Return;
}

Int Intern_Extern_Polate_ValueGet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Polate_ValueGet(a0);

    Return;
}

Int Intern_Extern_Polate_ValueSet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = Polate_ValueSet(a0, a1);

    Return;
}

Int Intern_Extern_Polate_StopGet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Polate_StopGet(a0);

    Return;
}

Int Intern_Extern_Polate_StopSet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = Polate_StopSet(a0, a1);

    Return;
}

Int Intern_Extern_Polate_SpreadGet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Polate_SpreadGet(a0);

    Return;
}

Int Intern_Extern_Polate_SpreadSet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = Polate_SpreadSet(a0, a1);

    Return;
}

Int Intern_Extern_PolateLinear_New(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 0;

    Int a;
    a = PolateLinear_New();

    Return;
}

Int Intern_Extern_PolateLinear_Delete(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = PolateLinear_Delete(a0);

    Return;
}

Int Intern_Extern_PolateLinear_Init(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = PolateLinear_Init(a0);

    Return;
}

Int Intern_Extern_PolateLinear_Final(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = PolateLinear_Final(a0);

    Return;
}

Int Intern_Extern_PolateLinear_StartPosGet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = PolateLinear_StartPosGet(a0);

    Return;
}

Int Intern_Extern_PolateLinear_StartPosSet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = PolateLinear_StartPosSet(a0, a1);

    Return;
}

Int Intern_Extern_PolateLinear_EndPosGet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = PolateLinear_EndPosGet(a0);

    Return;
}

Int Intern_Extern_PolateLinear_EndPosSet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = PolateLinear_EndPosSet(a0, a1);

    Return;
}

Int Intern_Extern_PolateRadial_New(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 0;

    Int a;
    a = PolateRadial_New();

    Return;
}

Int Intern_Extern_PolateRadial_Delete(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = PolateRadial_Delete(a0);

    Return;
}

Int Intern_Extern_PolateRadial_Init(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = PolateRadial_Init(a0);

    Return;
}

Int Intern_Extern_PolateRadial_Final(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = PolateRadial_Final(a0);

    Return;
}

Int Intern_Extern_PolateRadial_CenterPosGet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = PolateRadial_CenterPosGet(a0);

    Return;
}

Int Intern_Extern_PolateRadial_CenterPosSet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = PolateRadial_CenterPosSet(a0, a1);

    Return;
}

Int Intern_Extern_PolateRadial_CenterRadiusGet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = PolateRadial_CenterRadiusGet(a0);

    Return;
}

Int Intern_Extern_PolateRadial_CenterRadiusSet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = PolateRadial_CenterRadiusSet(a0, a1);

    Return;
}

Int Intern_Extern_PolateRadial_FocusPosGet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = PolateRadial_FocusPosGet(a0);

    Return;
}

Int Intern_Extern_PolateRadial_FocusPosSet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = PolateRadial_FocusPosSet(a0, a1);

    Return;
}

Int Intern_Extern_PolateRadial_FocusRadiusGet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = PolateRadial_FocusRadiusGet(a0);

    Return;
}

Int Intern_Extern_PolateRadial_FocusRadiusSet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = PolateRadial_FocusRadiusSet(a0, a1);

    Return;
}

Int Intern_Extern_PolateStop_New(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 0;

    Int a;
    a = PolateStop_New();

    Return;
}

Int Intern_Extern_PolateStop_Delete(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = PolateStop_Delete(a0);

    Return;
}

Int Intern_Extern_PolateStop_Init(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = PolateStop_Init(a0);

    Return;
}

Int Intern_Extern_PolateStop_Final(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = PolateStop_Final(a0);

    Return;
}

Int Intern_Extern_PolateStop_CountGet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = PolateStop_CountGet(a0);

    Return;
}

Int Intern_Extern_PolateStop_CountSet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = PolateStop_CountSet(a0, a1);

    Return;
}

Int Intern_Extern_PolateStop_PointGetPos(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = PolateStop_PointGetPos(a0, a1);

    Return;
}

Int Intern_Extern_PolateStop_PointGetColor(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = PolateStop_PointGetColor(a0, a1);

    Return;
}

Int Intern_Extern_PolateStop_PointSet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 4;

    Param(0);
    Param(1);
    Param(2);
    Param(3);

    Int a;
    a = PolateStop_PointSet(a0, a1, a2, a3);

    Return;
}

Int Intern_Extern_ImageRead_New(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 0;

    Int a;
    a = ImageRead_New();

    Return;
}

Int Intern_Extern_ImageRead_Delete(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = ImageRead_Delete(a0);

    Return;
}

Int Intern_Extern_ImageRead_Init(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = ImageRead_Init(a0);

    Return;
}

Int Intern_Extern_ImageRead_Final(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = ImageRead_Final(a0);

    Return;
}

Int Intern_Extern_ImageRead_StreamGet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = ImageRead_StreamGet(a0);

    Return;
}

Int Intern_Extern_ImageRead_StreamSet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = ImageRead_StreamSet(a0, a1);

    Return;
}

Int Intern_Extern_ImageRead_ImageGet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = ImageRead_ImageGet(a0);

    Return;
}

Int Intern_Extern_ImageRead_ImageSet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = ImageRead_ImageSet(a0, a1);

    Return;
}

Int Intern_Extern_ImageRead_Execute(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = ImageRead_Execute(a0);

    Return;
}

Int Intern_Extern_ImageWrite_New(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 0;

    Int a;
    a = ImageWrite_New();

    Return;
}

Int Intern_Extern_ImageWrite_Delete(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = ImageWrite_Delete(a0);

    Return;
}

Int Intern_Extern_ImageWrite_Init(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = ImageWrite_Init(a0);

    Return;
}

Int Intern_Extern_ImageWrite_Final(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = ImageWrite_Final(a0);

    Return;
}

Int Intern_Extern_ImageWrite_StreamGet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = ImageWrite_StreamGet(a0);

    Return;
}

Int Intern_Extern_ImageWrite_StreamSet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = ImageWrite_StreamSet(a0, a1);

    Return;
}

Int Intern_Extern_ImageWrite_ImageGet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = ImageWrite_ImageGet(a0);

    Return;
}

Int Intern_Extern_ImageWrite_ImageSet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = ImageWrite_ImageSet(a0, a1);

    Return;
}

Int Intern_Extern_ImageWrite_BinaryGet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = ImageWrite_BinaryGet(a0);

    Return;
}

Int Intern_Extern_ImageWrite_BinarySet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = ImageWrite_BinarySet(a0, a1);

    Return;
}

Int Intern_Extern_ImageWrite_QualityGet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = ImageWrite_QualityGet(a0);

    Return;
}

Int Intern_Extern_ImageWrite_QualitySet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = ImageWrite_QualitySet(a0, a1);

    Return;
}

Int Intern_Extern_ImageWrite_Execute(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = ImageWrite_Execute(a0);

    Return;
}

Int Intern_Extern_VideoOut_New(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 0;

    Int a;
    a = VideoOut_New();

    Return;
}

Int Intern_Extern_VideoOut_Delete(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = VideoOut_Delete(a0);

    Return;
}

Int Intern_Extern_VideoOut_Init(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = VideoOut_Init(a0);

    Return;
}

Int Intern_Extern_VideoOut_Final(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = VideoOut_Final(a0);

    Return;
}

Int Intern_Extern_VideoOut_FrameGet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = VideoOut_FrameGet(a0);

    Return;
}

Int Intern_Extern_VideoOut_FrameSet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = VideoOut_FrameSet(a0, a1);

    Return;
}

Int Intern_Extern_VideoOut_FrameStateGet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = VideoOut_FrameStateGet(a0);

    Return;
}

Int Intern_Extern_VideoOut_FrameStateSet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = VideoOut_FrameStateSet(a0, a1);

    Return;
}

Int Intern_Extern_VideoFrame_New(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 0;

    Int a;
    a = VideoFrame_New();

    Return;
}

Int Intern_Extern_VideoFrame_Delete(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = VideoFrame_Delete(a0);

    Return;
}

Int Intern_Extern_VideoFrame_Init(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = VideoFrame_Init(a0);

    Return;
}

Int Intern_Extern_VideoFrame_Final(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = VideoFrame_Final(a0);

    Return;
}

Int Intern_Extern_VideoFrame_SizeGet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = VideoFrame_SizeGet(a0);

    Return;
}

Int Intern_Extern_VideoFrame_SizeSet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = VideoFrame_SizeSet(a0, a1);

    Return;
}

Int Intern_Extern_VideoFrame_Image(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = VideoFrame_Image(a0, a1);

    Return;
}

Int Intern_Extern_AudioOut_New(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 0;

    Int a;
    a = AudioOut_New();

    Return;
}

Int Intern_Extern_AudioOut_Delete(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = AudioOut_Delete(a0);

    Return;
}

Int Intern_Extern_AudioOut_Init(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = AudioOut_Init(a0);

    Return;
}

Int Intern_Extern_AudioOut_Final(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = AudioOut_Final(a0);

    Return;
}

Int Intern_Extern_AudioOut_MutedGet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = AudioOut_MutedGet(a0);

    Return;
}

Int Intern_Extern_AudioOut_MutedSet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = AudioOut_MutedSet(a0, a1);

    Return;
}

Int Intern_Extern_AudioOut_VolumeGet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = AudioOut_VolumeGet(a0);

    Return;
}

Int Intern_Extern_AudioOut_VolumeSet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = AudioOut_VolumeSet(a0, a1);

    Return;
}

Int Intern_Extern_Play_New(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 0;

    Int a;
    a = Play_New();

    Return;
}

Int Intern_Extern_Play_Delete(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Play_Delete(a0);

    Return;
}

Int Intern_Extern_Play_Init(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Play_Init(a0);

    Return;
}

Int Intern_Extern_Play_Final(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Play_Final(a0);

    Return;
}

Int Intern_Extern_Play_SourceGet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Play_SourceGet(a0);

    Return;
}

Int Intern_Extern_Play_SourceSet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = Play_SourceSet(a0, a1);

    Return;
}

Int Intern_Extern_Play_VideoOutGet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Play_VideoOutGet(a0);

    Return;
}

Int Intern_Extern_Play_VideoOutSet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = Play_VideoOutSet(a0, a1);

    Return;
}

Int Intern_Extern_Play_AudioOutGet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Play_AudioOutGet(a0);

    Return;
}

Int Intern_Extern_Play_AudioOutSet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = Play_AudioOutSet(a0, a1);

    Return;
}

Int Intern_Extern_Play_TimeGet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Play_TimeGet(a0);

    Return;
}

Int Intern_Extern_Play_TimeSet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = Play_TimeSet(a0, a1);

    Return;
}

Int Intern_Extern_Play_PosGet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Play_PosGet(a0);

    Return;
}

Int Intern_Extern_Play_PosSet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = Play_PosSet(a0, a1);

    Return;
}

Int Intern_Extern_Play_SourceThisSet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Play_SourceThisSet(a0);

    Return;
}

Int Intern_Extern_Play_HasVideo(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Play_HasVideo(a0);

    Return;
}

Int Intern_Extern_Play_HasAudio(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Play_HasAudio(a0);

    Return;
}

Int Intern_Extern_Play_Execute(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Play_Execute(a0);

    Return;
}

Int Intern_Extern_Play_Pause(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Play_Pause(a0);

    Return;
}

Int Intern_Extern_Play_Stop(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Play_Stop(a0);

    Return;
}

Int Intern_Extern_Stream_New(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 0;

    Int a;
    a = Stream_New();

    Return;
}

Int Intern_Extern_Stream_Delete(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Stream_Delete(a0);

    Return;
}

Int Intern_Extern_Stream_Init(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Stream_Init(a0);

    Return;
}

Int Intern_Extern_Stream_Final(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Stream_Final(a0);

    Return;
}

Int Intern_Extern_Stream_KindGet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Stream_KindGet(a0);

    Return;
}

Int Intern_Extern_Stream_KindSet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = Stream_KindSet(a0, a1);

    Return;
}

Int Intern_Extern_Stream_StatusGet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Stream_StatusGet(a0);

    Return;
}

Int Intern_Extern_Stream_StatusSet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = Stream_StatusSet(a0, a1);

    Return;
}

Int Intern_Extern_Stream_CountGet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Stream_CountGet(a0);

    Return;
}

Int Intern_Extern_Stream_PosGet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Stream_PosGet(a0);

    Return;
}

Int Intern_Extern_Stream_PosSet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = Stream_PosSet(a0, a1);

    Return;
}

Int Intern_Extern_Stream_HasCount(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Stream_HasCount(a0);

    Return;
}

Int Intern_Extern_Stream_HasPos(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Stream_HasPos(a0);

    Return;
}

Int Intern_Extern_Stream_CanRead(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Stream_CanRead(a0);

    Return;
}

Int Intern_Extern_Stream_CanWrite(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Stream_CanWrite(a0);

    Return;
}

Int Intern_Extern_Stream_Read(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 3;

    Param(0);
    Param(1);
    Param(2);

    Int a;
    a = Stream_Read(a0, a1, a2);

    Return;
}

Int Intern_Extern_Stream_Write(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 3;

    Param(0);
    Param(1);
    Param(2);

    Int a;
    a = Stream_Write(a0, a1, a2);

    Return;
}

Int Intern_Extern_Memory_New(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 0;

    Int a;
    a = Memory_New();

    Return;
}

Int Intern_Extern_Memory_Delete(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Memory_Delete(a0);

    Return;
}

Int Intern_Extern_Memory_Init(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Memory_Init(a0);

    Return;
}

Int Intern_Extern_Memory_Final(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Memory_Final(a0);

    Return;
}

Int Intern_Extern_Memory_StreamGet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Memory_StreamGet(a0);

    Return;
}

Int Intern_Extern_Memory_StreamSet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = Memory_StreamSet(a0, a1);

    Return;
}

Int Intern_Extern_Memory_Open(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Memory_Open(a0);

    Return;
}

Int Intern_Extern_Memory_Close(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Memory_Close(a0);

    Return;
}

Int Intern_Extern_Storage_New(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 0;

    Int a;
    a = Storage_New();

    Return;
}

Int Intern_Extern_Storage_Delete(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Storage_Delete(a0);

    Return;
}

Int Intern_Extern_Storage_Init(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Storage_Init(a0);

    Return;
}

Int Intern_Extern_Storage_Final(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Storage_Final(a0);

    Return;
}

Int Intern_Extern_Storage_PathGet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Storage_PathGet(a0);

    Return;
}

Int Intern_Extern_Storage_PathSet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = Storage_PathSet(a0, a1);

    Return;
}

Int Intern_Extern_Storage_ModeGet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Storage_ModeGet(a0);

    Return;
}

Int Intern_Extern_Storage_ModeSet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = Storage_ModeSet(a0, a1);

    Return;
}

Int Intern_Extern_Storage_StreamGet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Storage_StreamGet(a0);

    Return;
}

Int Intern_Extern_Storage_StreamSet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = Storage_StreamSet(a0, a1);

    Return;
}

Int Intern_Extern_Storage_StatusGet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Storage_StatusGet(a0);

    Return;
}

Int Intern_Extern_Storage_StatusSet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = Storage_StatusSet(a0, a1);

    Return;
}

Int Intern_Extern_Storage_CountSet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = Storage_CountSet(a0, a1);

    Return;
}

Int Intern_Extern_Storage_Open(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Storage_Open(a0);

    Return;
}

Int Intern_Extern_Storage_Close(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Storage_Close(a0);

    Return;
}

Int Intern_Extern_StorageComp_New(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 0;

    Int a;
    a = StorageComp_New();

    Return;
}

Int Intern_Extern_StorageComp_Delete(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = StorageComp_Delete(a0);

    Return;
}

Int Intern_Extern_StorageComp_Init(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = StorageComp_Init(a0);

    Return;
}

Int Intern_Extern_StorageComp_Final(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = StorageComp_Final(a0);

    Return;
}

Int Intern_Extern_StorageComp_Rename(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 3;

    Param(0);
    Param(1);
    Param(2);

    Int a;
    a = StorageComp_Rename(a0, a1, a2);

    Return;
}

Int Intern_Extern_StorageComp_FileCopy(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 3;

    Param(0);
    Param(1);
    Param(2);

    Int a;
    a = StorageComp_FileCopy(a0, a1, a2);

    Return;
}

Int Intern_Extern_StorageComp_FileRemove(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = StorageComp_FileRemove(a0, a1);

    Return;
}

Int Intern_Extern_StorageComp_FoldCreate(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = StorageComp_FoldCreate(a0, a1);

    Return;
}

Int Intern_Extern_StorageComp_FoldCopy(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 3;

    Param(0);
    Param(1);
    Param(2);

    Int a;
    a = StorageComp_FoldCopy(a0, a1, a2);

    Return;
}

Int Intern_Extern_StorageComp_FoldRemove(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = StorageComp_FoldRemove(a0, a1);

    Return;
}

Int Intern_Extern_StorageComp_Exist(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = StorageComp_Exist(a0, a1);

    Return;
}

Int Intern_Extern_StorageComp_FoldList(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = StorageComp_FoldList(a0, a1);

    Return;
}

Int Intern_Extern_StorageComp_FileList(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = StorageComp_FileList(a0, a1);

    Return;
}

Int Intern_Extern_StorageComp_CurrentFoldGet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = StorageComp_CurrentFoldGet(a0);

    Return;
}

Int Intern_Extern_StorageComp_CurrentFoldSet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = StorageComp_CurrentFoldSet(a0, a1);

    Return;
}

Int Intern_Extern_Network_New(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 0;

    Int a;
    a = Network_New();

    Return;
}

Int Intern_Extern_Network_Delete(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Network_Delete(a0);

    Return;
}

Int Intern_Extern_Network_Init(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Network_Init(a0);

    Return;
}

Int Intern_Extern_Network_Final(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Network_Final(a0);

    Return;
}

Int Intern_Extern_Network_HostNameGet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Network_HostNameGet(a0);

    Return;
}

Int Intern_Extern_Network_HostNameSet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = Network_HostNameSet(a0, a1);

    Return;
}

Int Intern_Extern_Network_HostPortGet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Network_HostPortGet(a0);

    Return;
}

Int Intern_Extern_Network_HostPortSet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = Network_HostPortSet(a0, a1);

    Return;
}

Int Intern_Extern_Network_StreamGet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Network_StreamGet(a0);

    Return;
}

Int Intern_Extern_Network_StreamSet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = Network_StreamSet(a0, a1);

    Return;
}

Int Intern_Extern_Network_ReadyCountGet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Network_ReadyCountGet(a0);

    Return;
}

Int Intern_Extern_Network_ReadyCountSet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = Network_ReadyCountSet(a0, a1);

    Return;
}

Int Intern_Extern_Network_StatusGet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Network_StatusGet(a0);

    Return;
}

Int Intern_Extern_Network_StatusSet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = Network_StatusSet(a0, a1);

    Return;
}

Int Intern_Extern_Network_CaseGet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Network_CaseGet(a0);

    Return;
}

Int Intern_Extern_Network_CaseSet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = Network_CaseSet(a0, a1);

    Return;
}

Int Intern_Extern_Network_CaseChangeStateGet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Network_CaseChangeStateGet(a0);

    Return;
}

Int Intern_Extern_Network_CaseChangeStateSet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = Network_CaseChangeStateSet(a0, a1);

    Return;
}

Int Intern_Extern_Network_StatusChangeStateGet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Network_StatusChangeStateGet(a0);

    Return;
}

Int Intern_Extern_Network_StatusChangeStateSet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = Network_StatusChangeStateSet(a0, a1);

    Return;
}

Int Intern_Extern_Network_ReadyReadStateGet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Network_ReadyReadStateGet(a0);

    Return;
}

Int Intern_Extern_Network_ReadyReadStateSet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = Network_ReadyReadStateSet(a0, a1);

    Return;
}

Int Intern_Extern_Network_Open(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Network_Open(a0);

    Return;
}

Int Intern_Extern_Network_Close(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Network_Close(a0);

    Return;
}

Int Intern_Extern_NetworkHost_New(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 0;

    Int a;
    a = NetworkHost_New();

    Return;
}

Int Intern_Extern_NetworkHost_Delete(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = NetworkHost_Delete(a0);

    Return;
}

Int Intern_Extern_NetworkHost_Init(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = NetworkHost_Init(a0);

    Return;
}

Int Intern_Extern_NetworkHost_Final(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = NetworkHost_Final(a0);

    Return;
}

Int Intern_Extern_NetworkHost_PortGet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = NetworkHost_PortGet(a0);

    Return;
}

Int Intern_Extern_NetworkHost_PortSet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = NetworkHost_PortSet(a0, a1);

    Return;
}

Int Intern_Extern_NetworkHost_NewPeerStateGet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = NetworkHost_NewPeerStateGet(a0);

    Return;
}

Int Intern_Extern_NetworkHost_NewPeerStateSet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = NetworkHost_NewPeerStateSet(a0, a1);

    Return;
}

Int Intern_Extern_NetworkHost_Open(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = NetworkHost_Open(a0);

    Return;
}

Int Intern_Extern_NetworkHost_Close(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = NetworkHost_Close(a0);

    Return;
}

Int Intern_Extern_NetworkHost_OpenPeer(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = NetworkHost_OpenPeer(a0);

    Return;
}

Int Intern_Extern_NetworkHost_ClosePeer(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = NetworkHost_ClosePeer(a0, a1);

    Return;
}

Int Intern_Extern_NetworkPort_New(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 0;

    Int a;
    a = NetworkPort_New();

    Return;
}

Int Intern_Extern_NetworkPort_Delete(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = NetworkPort_Delete(a0);

    Return;
}

Int Intern_Extern_NetworkPort_Init(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = NetworkPort_Init(a0);

    Return;
}

Int Intern_Extern_NetworkPort_Final(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = NetworkPort_Final(a0);

    Return;
}

Int Intern_Extern_NetworkPort_KindGet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = NetworkPort_KindGet(a0);

    Return;
}

Int Intern_Extern_NetworkPort_KindSet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = NetworkPort_KindSet(a0, a1);

    Return;
}

Int Intern_Extern_NetworkPort_ValueAGet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = NetworkPort_ValueAGet(a0);

    Return;
}

Int Intern_Extern_NetworkPort_ValueASet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = NetworkPort_ValueASet(a0, a1);

    Return;
}

Int Intern_Extern_NetworkPort_ValueBGet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = NetworkPort_ValueBGet(a0);

    Return;
}

Int Intern_Extern_NetworkPort_ValueBSet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = NetworkPort_ValueBSet(a0, a1);

    Return;
}

Int Intern_Extern_NetworkPort_ValueCGet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = NetworkPort_ValueCGet(a0);

    Return;
}

Int Intern_Extern_NetworkPort_ValueCSet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = NetworkPort_ValueCSet(a0, a1);

    Return;
}

Int Intern_Extern_NetworkPort_HostGet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = NetworkPort_HostGet(a0);

    Return;
}

Int Intern_Extern_NetworkPort_HostSet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = NetworkPort_HostSet(a0, a1);

    Return;
}

Int Intern_Extern_NetworkPort_Set(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = NetworkPort_Set(a0);

    Return;
}

Int Intern_Extern_Thread_New(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 0;

    Int a;
    a = Thread_New();

    Return;
}

Int Intern_Extern_Thread_Delete(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Thread_Delete(a0);

    Return;
}

Int Intern_Extern_Thread_Init(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Thread_Init(a0);

    Return;
}

Int Intern_Extern_Thread_Final(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Thread_Final(a0);

    Return;
}

Int Intern_Extern_Thread_IdentGet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Thread_IdentGet(a0);

    Return;
}

Int Intern_Extern_Thread_IdentSet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = Thread_IdentSet(a0, a1);

    Return;
}

Int Intern_Extern_Thread_ExecuteStateGet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Thread_ExecuteStateGet(a0);

    Return;
}

Int Intern_Extern_Thread_ExecuteStateSet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = Thread_ExecuteStateSet(a0, a1);

    Return;
}

Int Intern_Extern_Thread_StatusGet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Thread_StatusGet(a0);

    Return;
}

Int Intern_Extern_Thread_StatusSet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = Thread_StatusSet(a0, a1);

    Return;
}

Int Intern_Extern_Thread_CaseGet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Thread_CaseGet(a0);

    Return;
}

Int Intern_Extern_Thread_CaseSet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = Thread_CaseSet(a0, a1);

    Return;
}

Int Intern_Extern_Thread_Execute(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Thread_Execute(a0);

    Return;
}

Int Intern_Extern_Thread_Terminate(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Thread_Terminate(a0);

    Return;
}

Int Intern_Extern_Thread_Pause(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Thread_Pause(a0);

    Return;
}

Int Intern_Extern_Thread_Resume(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Thread_Resume(a0);

    Return;
}

Int Intern_Extern_Thread_Wait(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Thread_Wait(a0);

    Return;
}

Int Intern_Extern_Thread_ExecuteEventLoop(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Thread_ExecuteEventLoop(a0);

    Return;
}

Int Intern_Extern_Thread_ExitEventLoop(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = Thread_ExitEventLoop(a0, a1);

    Return;
}

Int Intern_Extern_Thread_IsMain(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Thread_IsMain(a0);

    Return;
}

Int Intern_Extern_Thread_Sleep(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Thread_Sleep(a0);

    Return;
}

Int Intern_Extern_Thread_This(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 0;

    Int a;
    a = Thread_This();

    Return;
}

Int Intern_Extern_Phore_New(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 0;

    Int a;
    a = Phore_New();

    Return;
}

Int Intern_Extern_Phore_Delete(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Phore_Delete(a0);

    Return;
}

Int Intern_Extern_Phore_Init(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Phore_Init(a0);

    Return;
}

Int Intern_Extern_Phore_Final(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Phore_Final(a0);

    Return;
}

Int Intern_Extern_Phore_CountGet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Phore_CountGet(a0);

    Return;
}

Int Intern_Extern_Phore_CountSet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = Phore_CountSet(a0, a1);

    Return;
}

Int Intern_Extern_Phore_InitCountGet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Phore_InitCountGet(a0);

    Return;
}

Int Intern_Extern_Phore_InitCountSet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = Phore_InitCountSet(a0, a1);

    Return;
}

Int Intern_Extern_Phore_Acquire(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Phore_Acquire(a0);

    Return;
}

Int Intern_Extern_Phore_Release(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Phore_Release(a0);

    Return;
}

Int Intern_Extern_Time_New(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 0;

    Int a;
    a = Time_New();

    Return;
}

Int Intern_Extern_Time_Delete(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Time_Delete(a0);

    Return;
}

Int Intern_Extern_Time_Init(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Time_Init(a0);

    Return;
}

Int Intern_Extern_Time_Final(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Time_Final(a0);

    Return;
}

Int Intern_Extern_Time_YeaGet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Time_YeaGet(a0);

    Return;
}

Int Intern_Extern_Time_YeaSet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = Time_YeaSet(a0, a1);

    Return;
}

Int Intern_Extern_Time_MonGet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Time_MonGet(a0);

    Return;
}

Int Intern_Extern_Time_MonSet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = Time_MonSet(a0, a1);

    Return;
}

Int Intern_Extern_Time_DayGet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Time_DayGet(a0);

    Return;
}

Int Intern_Extern_Time_DaySet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = Time_DaySet(a0, a1);

    Return;
}

Int Intern_Extern_Time_OurGet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Time_OurGet(a0);

    Return;
}

Int Intern_Extern_Time_OurSet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = Time_OurSet(a0, a1);

    Return;
}

Int Intern_Extern_Time_MinGet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Time_MinGet(a0);

    Return;
}

Int Intern_Extern_Time_MinSet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = Time_MinSet(a0, a1);

    Return;
}

Int Intern_Extern_Time_SecGet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Time_SecGet(a0);

    Return;
}

Int Intern_Extern_Time_SecSet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = Time_SecSet(a0, a1);

    Return;
}

Int Intern_Extern_Time_MillisecGet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Time_MillisecGet(a0);

    Return;
}

Int Intern_Extern_Time_MillisecSet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = Time_MillisecSet(a0, a1);

    Return;
}

Int Intern_Extern_Time_PosGet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Time_PosGet(a0);

    Return;
}

Int Intern_Extern_Time_PosSet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = Time_PosSet(a0, a1);

    Return;
}

Int Intern_Extern_Time_YeaDayGet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Time_YeaDayGet(a0);

    Return;
}

Int Intern_Extern_Time_YeaDaySet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = Time_YeaDaySet(a0, a1);

    Return;
}

Int Intern_Extern_Time_WeekDayGet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Time_WeekDayGet(a0);

    Return;
}

Int Intern_Extern_Time_WeekDaySet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = Time_WeekDaySet(a0, a1);

    Return;
}

Int Intern_Extern_Time_YeaDayCountGet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Time_YeaDayCountGet(a0);

    Return;
}

Int Intern_Extern_Time_YeaDayCountSet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = Time_YeaDayCountSet(a0, a1);

    Return;
}

Int Intern_Extern_Time_MonDayCountGet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Time_MonDayCountGet(a0);

    Return;
}

Int Intern_Extern_Time_MonDayCountSet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = Time_MonDayCountSet(a0, a1);

    Return;
}

Int Intern_Extern_Time_TotalMillisecGet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Time_TotalMillisecGet(a0);

    Return;
}

Int Intern_Extern_Time_TotalMillisecSet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = Time_TotalMillisecSet(a0, a1);

    Return;
}

Int Intern_Extern_Time_AddYea(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = Time_AddYea(a0, a1);

    Return;
}

Int Intern_Extern_Time_AddMon(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = Time_AddMon(a0, a1);

    Return;
}

Int Intern_Extern_Time_AddDay(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = Time_AddDay(a0, a1);

    Return;
}

Int Intern_Extern_Time_AddMillisec(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = Time_AddMillisec(a0, a1);

    Return;
}

Int Intern_Extern_Time_This(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Time_This(a0);

    Return;
}

Int Intern_Extern_Time_ToPos(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = Time_ToPos(a0, a1);

    Return;
}

Int Intern_Extern_Time_Set(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 9;

    Param(0);
    Param(1);
    Param(2);
    Param(3);
    Param(4);
    Param(5);
    Param(6);
    Param(7);
    Param(8);

    Int a;
    a = Time_Set(a0, a1, a2, a3, a4, a5, a6, a7, a8);

    Return;
}

Int Intern_Extern_Time_LeapYea(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Time_LeapYea(a0);

    Return;
}

Int Intern_Extern_Time_ValidDate(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 3;

    Param(0);
    Param(1);
    Param(2);

    Int a;
    a = Time_ValidDate(a0, a1, a2);

    Return;
}

Int Intern_Extern_Time_ValidTime(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 4;

    Param(0);
    Param(1);
    Param(2);
    Param(3);

    Int a;
    a = Time_ValidTime(a0, a1, a2, a3);

    Return;
}

Int Intern_Extern_TimeEvent_New(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 0;

    Int a;
    a = TimeEvent_New();

    Return;
}

Int Intern_Extern_TimeEvent_Delete(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = TimeEvent_Delete(a0);

    Return;
}

Int Intern_Extern_TimeEvent_Init(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = TimeEvent_Init(a0);

    Return;
}

Int Intern_Extern_TimeEvent_Final(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = TimeEvent_Final(a0);

    Return;
}

Int Intern_Extern_TimeEvent_TimeGet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = TimeEvent_TimeGet(a0);

    Return;
}

Int Intern_Extern_TimeEvent_TimeSet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = TimeEvent_TimeSet(a0, a1);

    Return;
}

Int Intern_Extern_TimeEvent_SingleGet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = TimeEvent_SingleGet(a0);

    Return;
}

Int Intern_Extern_TimeEvent_SingleSet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = TimeEvent_SingleSet(a0, a1);

    Return;
}

Int Intern_Extern_TimeEvent_ActiveGet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = TimeEvent_ActiveGet(a0);

    Return;
}

Int Intern_Extern_TimeEvent_ActiveSet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = TimeEvent_ActiveSet(a0, a1);

    Return;
}

Int Intern_Extern_TimeEvent_ElapseStateGet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = TimeEvent_ElapseStateGet(a0);

    Return;
}

Int Intern_Extern_TimeEvent_ElapseStateSet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = TimeEvent_ElapseStateSet(a0, a1);

    Return;
}

Int Intern_Extern_TimeEvent_Start(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = TimeEvent_Start(a0);

    Return;
}

Int Intern_Extern_TimeEvent_Stop(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = TimeEvent_Stop(a0);

    Return;
}

Int Intern_Extern_Post_New(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 0;

    Int a;
    a = Post_New();

    Return;
}

Int Intern_Extern_Post_Delete(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Post_Delete(a0);

    Return;
}

Int Intern_Extern_Post_Init(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Post_Init(a0);

    Return;
}

Int Intern_Extern_Post_Final(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Post_Final(a0);

    Return;
}

Int Intern_Extern_Post_ExecuteStateGet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Post_ExecuteStateGet(a0);

    Return;
}

Int Intern_Extern_Post_ExecuteStateSet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = Post_ExecuteStateSet(a0, a1);

    Return;
}

Int Intern_Extern_Post_Execute(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Post_Execute(a0);

    Return;
}

Int Intern_Extern_Program_New(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 0;

    Int a;
    a = Program_New();

    Return;
}

Int Intern_Extern_Program_Delete(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Program_Delete(a0);

    Return;
}

Int Intern_Extern_Program_Init(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Program_Init(a0);

    Return;
}

Int Intern_Extern_Program_Final(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Program_Final(a0);

    Return;
}

Int Intern_Extern_Program_NameGet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Program_NameGet(a0);

    Return;
}

Int Intern_Extern_Program_NameSet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = Program_NameSet(a0, a1);

    Return;
}

Int Intern_Extern_Program_ArgueGet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Program_ArgueGet(a0);

    Return;
}

Int Intern_Extern_Program_ArgueSet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = Program_ArgueSet(a0, a1);

    Return;
}

Int Intern_Extern_Program_WorkFoldGet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Program_WorkFoldGet(a0);

    Return;
}

Int Intern_Extern_Program_WorkFoldSet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = Program_WorkFoldSet(a0, a1);

    Return;
}

Int Intern_Extern_Program_EnvironGet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Program_EnvironGet(a0);

    Return;
}

Int Intern_Extern_Program_EnvironSet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = Program_EnvironSet(a0, a1);

    Return;
}

Int Intern_Extern_Program_IdentGet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Program_IdentGet(a0);

    Return;
}

Int Intern_Extern_Program_IdentSet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = Program_IdentSet(a0, a1);

    Return;
}

Int Intern_Extern_Program_StatusGet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Program_StatusGet(a0);

    Return;
}

Int Intern_Extern_Program_StatusSet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = Program_StatusSet(a0, a1);

    Return;
}

Int Intern_Extern_Program_ExitKindGet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Program_ExitKindGet(a0);

    Return;
}

Int Intern_Extern_Program_ExitKindSet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = Program_ExitKindSet(a0, a1);

    Return;
}

Int Intern_Extern_Program_StartStateGet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Program_StartStateGet(a0);

    Return;
}

Int Intern_Extern_Program_StartStateSet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = Program_StartStateSet(a0, a1);

    Return;
}

Int Intern_Extern_Program_FinishStateGet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Program_FinishStateGet(a0);

    Return;
}

Int Intern_Extern_Program_FinishStateSet(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 2;

    Param(0);
    Param(1);

    Int a;
    a = Program_FinishStateSet(a0, a1);

    Return;
}

Int Intern_Extern_Program_Execute(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Program_Execute(a0);

    Return;
}

Int Intern_Extern_Program_Wait(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Program_Wait(a0);

    Return;
}

Int Intern_Extern_Program_Terminate(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Program_Terminate(a0);

    Return;
}

Int Intern_Extern_Infra_Share(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 0;

    Int a;
    a = Infra_Share();

    Return;
}

Int Intern_Extern_Share_Stat(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Share_Stat(a0);

    Return;
}

Int Intern_Extern_Stat_PointDataCount(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Stat_PointDataCount(a0);

    Return;
}

Int Intern_Extern_Stat_TextAlignStart(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Stat_TextAlignStart(a0);

    Return;
}

Int Intern_Extern_Stat_TextAlignMid(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Stat_TextAlignMid(a0);

    Return;
}

Int Intern_Extern_Stat_TextAlignEnd(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Stat_TextAlignEnd(a0);

    Return;
}

Int Intern_Extern_Stat_TextCodeKindUtf8(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Stat_TextCodeKindUtf8(a0);

    Return;
}

Int Intern_Extern_Stat_TextCodeKindUtf16(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Stat_TextCodeKindUtf16(a0);

    Return;
}

Int Intern_Extern_Stat_TextCodeKindUtf32(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Stat_TextCodeKindUtf32(a0);

    Return;
}

Int Intern_Extern_Stat_ThreadCaseReady(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Stat_ThreadCaseReady(a0);

    Return;
}

Int Intern_Extern_Stat_ThreadCaseExecute(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Stat_ThreadCaseExecute(a0);

    Return;
}

Int Intern_Extern_Stat_ThreadCasePause(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Stat_ThreadCasePause(a0);

    Return;
}

Int Intern_Extern_Stat_ThreadCaseFinish(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Stat_ThreadCaseFinish(a0);

    Return;
}

Int Intern_Extern_Stat_ThreadCaseTerminate(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Stat_ThreadCaseTerminate(a0);

    Return;
}

Int Intern_Extern_Stat_StreamKindMemory(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Stat_StreamKindMemory(a0);

    Return;
}

Int Intern_Extern_Stat_StreamKindStorage(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Stat_StreamKindStorage(a0);

    Return;
}

Int Intern_Extern_Stat_StreamKindNetwork(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Stat_StreamKindNetwork(a0);

    Return;
}

Int Intern_Extern_Stat_StorageModeRead(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Stat_StorageModeRead(a0);

    Return;
}

Int Intern_Extern_Stat_StorageModeWrite(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Stat_StorageModeWrite(a0);

    Return;
}

Int Intern_Extern_Stat_StorageModeNew(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Stat_StorageModeNew(a0);

    Return;
}

Int Intern_Extern_Stat_StorageModeExisting(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Stat_StorageModeExisting(a0);

    Return;
}

Int Intern_Extern_Stat_StorageStatusNoError(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Stat_StorageStatusNoError(a0);

    Return;
}

Int Intern_Extern_Stat_StorageStatusReadError(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Stat_StorageStatusReadError(a0);

    Return;
}

Int Intern_Extern_Stat_StorageStatusWriteError(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Stat_StorageStatusWriteError(a0);

    Return;
}

Int Intern_Extern_Stat_StorageStatusFatalError(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Stat_StorageStatusFatalError(a0);

    Return;
}

Int Intern_Extern_Stat_StorageStatusResourceError(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Stat_StorageStatusResourceError(a0);

    Return;
}

Int Intern_Extern_Stat_StorageStatusOpenError(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Stat_StorageStatusOpenError(a0);

    Return;
}

Int Intern_Extern_Stat_StorageStatusAbortError(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Stat_StorageStatusAbortError(a0);

    Return;
}

Int Intern_Extern_Stat_StorageStatusTimeOutError(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Stat_StorageStatusTimeOutError(a0);

    Return;
}

Int Intern_Extern_Stat_StorageStatusUnspecifiedError(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Stat_StorageStatusUnspecifiedError(a0);

    Return;
}

Int Intern_Extern_Stat_StorageStatusRemoveError(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Stat_StorageStatusRemoveError(a0);

    Return;
}

Int Intern_Extern_Stat_StorageStatusRenameError(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Stat_StorageStatusRenameError(a0);

    Return;
}

Int Intern_Extern_Stat_StorageStatusPositionError(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Stat_StorageStatusPositionError(a0);

    Return;
}

Int Intern_Extern_Stat_StorageStatusResizeError(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Stat_StorageStatusResizeError(a0);

    Return;
}

Int Intern_Extern_Stat_StorageStatusPermissionsError(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Stat_StorageStatusPermissionsError(a0);

    Return;
}

Int Intern_Extern_Stat_StorageStatusCopyError(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Stat_StorageStatusCopyError(a0);

    Return;
}

Int Intern_Extern_Stat_NetworkCaseUnconnected(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Stat_NetworkCaseUnconnected(a0);

    Return;
}

Int Intern_Extern_Stat_NetworkCaseHostLookup(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Stat_NetworkCaseHostLookup(a0);

    Return;
}

Int Intern_Extern_Stat_NetworkCaseConnecting(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Stat_NetworkCaseConnecting(a0);

    Return;
}

Int Intern_Extern_Stat_NetworkCaseConnected(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Stat_NetworkCaseConnected(a0);

    Return;
}

Int Intern_Extern_Stat_NetworkCaseBound(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Stat_NetworkCaseBound(a0);

    Return;
}

Int Intern_Extern_Stat_NetworkCaseListening(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Stat_NetworkCaseListening(a0);

    Return;
}

Int Intern_Extern_Stat_NetworkCaseClosing(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Stat_NetworkCaseClosing(a0);

    Return;
}

Int Intern_Extern_Stat_NetworkPortKindIPv6(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Stat_NetworkPortKindIPv6(a0);

    Return;
}

Int Intern_Extern_Stat_NetworkPortKindIPv4(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Stat_NetworkPortKindIPv4(a0);

    Return;
}

Int Intern_Extern_Stat_NetworkPortKindBroadcast(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Stat_NetworkPortKindBroadcast(a0);

    Return;
}

Int Intern_Extern_Stat_NetworkPortKindLocalHost(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Stat_NetworkPortKindLocalHost(a0);

    Return;
}

Int Intern_Extern_Stat_NetworkPortKindLocalHostIPv6(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Stat_NetworkPortKindLocalHostIPv6(a0);

    Return;
}

Int Intern_Extern_Stat_NetworkPortKindAny(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Stat_NetworkPortKindAny(a0);

    Return;
}

Int Intern_Extern_Stat_NetworkPortKindAnyIPv6(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Stat_NetworkPortKindAnyIPv6(a0);

    Return;
}

Int Intern_Extern_Stat_NetworkPortKindAnyIPv4(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Stat_NetworkPortKindAnyIPv4(a0);

    Return;
}

Int Intern_Extern_Stat_NetworkStatusNoError(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Stat_NetworkStatusNoError(a0);

    Return;
}

Int Intern_Extern_Stat_NetworkStatusConnectionRefusedError(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Stat_NetworkStatusConnectionRefusedError(a0);

    Return;
}

Int Intern_Extern_Stat_NetworkStatusRemoteHostClosedError(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Stat_NetworkStatusRemoteHostClosedError(a0);

    Return;
}

Int Intern_Extern_Stat_NetworkStatusHostNotFoundError(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Stat_NetworkStatusHostNotFoundError(a0);

    Return;
}

Int Intern_Extern_Stat_NetworkStatusSocketAccessError(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Stat_NetworkStatusSocketAccessError(a0);

    Return;
}

Int Intern_Extern_Stat_NetworkStatusSocketResourceError(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Stat_NetworkStatusSocketResourceError(a0);

    Return;
}

Int Intern_Extern_Stat_NetworkStatusSocketTimeoutError(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Stat_NetworkStatusSocketTimeoutError(a0);

    Return;
}

Int Intern_Extern_Stat_NetworkStatusDatagramTooLargeError(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Stat_NetworkStatusDatagramTooLargeError(a0);

    Return;
}

Int Intern_Extern_Stat_NetworkStatusNetworkError(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Stat_NetworkStatusNetworkError(a0);

    Return;
}

Int Intern_Extern_Stat_NetworkStatusAddressInUseError(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Stat_NetworkStatusAddressInUseError(a0);

    Return;
}

Int Intern_Extern_Stat_NetworkStatusSocketAddressNotAvailableError(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Stat_NetworkStatusSocketAddressNotAvailableError(a0);

    Return;
}

Int Intern_Extern_Stat_NetworkStatusUnsupportedSocketOperationError(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Stat_NetworkStatusUnsupportedSocketOperationError(a0);

    Return;
}

Int Intern_Extern_Stat_NetworkStatusUnfinishedSocketOperationError(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Stat_NetworkStatusUnfinishedSocketOperationError(a0);

    Return;
}

Int Intern_Extern_Stat_NetworkStatusProxyAuthenticationRequiredError(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Stat_NetworkStatusProxyAuthenticationRequiredError(a0);

    Return;
}

Int Intern_Extern_Stat_NetworkStatusSslHandshakeFailedError(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Stat_NetworkStatusSslHandshakeFailedError(a0);

    Return;
}

Int Intern_Extern_Stat_NetworkStatusProxyConnectionRefusedError(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Stat_NetworkStatusProxyConnectionRefusedError(a0);

    Return;
}

Int Intern_Extern_Stat_NetworkStatusProxyConnectionClosedError(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Stat_NetworkStatusProxyConnectionClosedError(a0);

    Return;
}

Int Intern_Extern_Stat_NetworkStatusProxyConnectionTimeoutError(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Stat_NetworkStatusProxyConnectionTimeoutError(a0);

    Return;
}

Int Intern_Extern_Stat_NetworkStatusProxyNotFoundError(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Stat_NetworkStatusProxyNotFoundError(a0);

    Return;
}

Int Intern_Extern_Stat_NetworkStatusProxyProtocolError(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Stat_NetworkStatusProxyProtocolError(a0);

    Return;
}

Int Intern_Extern_Stat_NetworkStatusOperationError(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Stat_NetworkStatusOperationError(a0);

    Return;
}

Int Intern_Extern_Stat_NetworkStatusSslInternalError(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Stat_NetworkStatusSslInternalError(a0);

    Return;
}

Int Intern_Extern_Stat_NetworkStatusSslInvalidUserDataError(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Stat_NetworkStatusSslInvalidUserDataError(a0);

    Return;
}

Int Intern_Extern_Stat_NetworkStatusTemporaryError(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Stat_NetworkStatusTemporaryError(a0);

    Return;
}

Int Intern_Extern_Stat_BrushKindColor(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Stat_BrushKindColor(a0);

    Return;
}

Int Intern_Extern_Stat_BrushKindPolate(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Stat_BrushKindPolate(a0);

    Return;
}

Int Intern_Extern_Stat_BrushKindImage(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Stat_BrushKindImage(a0);

    Return;
}

Int Intern_Extern_Stat_BrushLineSolid(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Stat_BrushLineSolid(a0);

    Return;
}

Int Intern_Extern_Stat_BrushLineDash(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Stat_BrushLineDash(a0);

    Return;
}

Int Intern_Extern_Stat_BrushLineDot(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Stat_BrushLineDot(a0);

    Return;
}

Int Intern_Extern_Stat_BrushLineDashDot(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Stat_BrushLineDashDot(a0);

    Return;
}

Int Intern_Extern_Stat_BrushLineDashDotDot(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Stat_BrushLineDashDotDot(a0);

    Return;
}

Int Intern_Extern_Stat_BrushCapFlat(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Stat_BrushCapFlat(a0);

    Return;
}

Int Intern_Extern_Stat_BrushCapSquare(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Stat_BrushCapSquare(a0);

    Return;
}

Int Intern_Extern_Stat_BrushCapRound(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Stat_BrushCapRound(a0);

    Return;
}

Int Intern_Extern_Stat_BrushJoinMiter(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Stat_BrushJoinMiter(a0);

    Return;
}

Int Intern_Extern_Stat_BrushJoinBevel(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Stat_BrushJoinBevel(a0);

    Return;
}

Int Intern_Extern_Stat_BrushJoinRound(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Stat_BrushJoinRound(a0);

    Return;
}

Int Intern_Extern_Stat_PolateKindLinear(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Stat_PolateKindLinear(a0);

    Return;
}

Int Intern_Extern_Stat_PolateKindRadial(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Stat_PolateKindRadial(a0);

    Return;
}

Int Intern_Extern_Stat_PolateSpreadPad(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Stat_PolateSpreadPad(a0);

    Return;
}

Int Intern_Extern_Stat_PolateSpreadReflect(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Stat_PolateSpreadReflect(a0);

    Return;
}

Int Intern_Extern_Stat_PolateSpreadRepeat(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Stat_PolateSpreadRepeat(a0);

    Return;
}

Int Intern_Extern_Stat_CompSourceOver(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Stat_CompSourceOver(a0);

    Return;
}

Int Intern_Extern_Stat_CompDestOver(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Stat_CompDestOver(a0);

    Return;
}

Int Intern_Extern_Stat_CompSource(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Stat_CompSource(a0);

    Return;
}

Int Intern_Extern_Stat_CompDest(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Stat_CompDest(a0);

    Return;
}

Int Intern_Extern_Stat_CompSourceIn(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Stat_CompSourceIn(a0);

    Return;
}

Int Intern_Extern_Stat_CompDestIn(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Stat_CompDestIn(a0);

    Return;
}

Int Intern_Extern_Stat_CompSourceOut(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Stat_CompSourceOut(a0);

    Return;
}

Int Intern_Extern_Stat_CompDestOut(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Stat_CompDestOut(a0);

    Return;
}

Int Intern_Extern_Stat_ImageBinaryBmp(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Stat_ImageBinaryBmp(a0);

    Return;
}

Int Intern_Extern_Stat_ImageBinaryJpg(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Stat_ImageBinaryJpg(a0);

    Return;
}

Int Intern_Extern_Stat_ImageBinaryPng(Eval* eval, Int frame)
{
    Int paramCount;
    paramCount = 1;

    Param(0);

    Int a;
    a = Stat_ImageBinaryPng(a0);

    Return;
}

