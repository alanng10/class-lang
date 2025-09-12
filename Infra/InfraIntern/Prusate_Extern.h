#pragma once

#include "Prusate.h"

Intern_Api Int Intern_Extern_Environ_New(Eval* e, Int f);
Intern_Api Int Intern_Extern_Environ_Delete(Eval* e, Int f);
Intern_Api Int Intern_Extern_Environ_Copy(Eval* e, Int f);
Intern_Api Int Intern_Extern_Environ_Exit(Eval* e, Int f);
Intern_Api Int Intern_Extern_Environ_System(Eval* e, Int f);

Intern_Api Int Intern_Extern_String_New(Eval* e, Int f);
Intern_Api Int Intern_Extern_String_Delete(Eval* e, Int f);
Intern_Api Int Intern_Extern_String_Init(Eval* e, Int f);
Intern_Api Int Intern_Extern_String_Final(Eval* e, Int f);
Intern_Api Int Intern_Extern_String_ValueGet(Eval* e, Int f);
Intern_Api Int Intern_Extern_String_ValueSet(Eval* e, Int f);
Intern_Api Int Intern_Extern_String_CountGet(Eval* e, Int f);
Intern_Api Int Intern_Extern_String_CountSet(Eval* e, Int f);

Intern_Api Int Intern_Extern_String_Char(Eval* e, Int f);
Intern_Api Int Intern_Extern_String_Equal(Eval* e, Int f);

Intern_Api Int Intern_Extern_String_ConstantCreate(Eval* e, Int f);
Intern_Api Int Intern_Extern_String_ConstantDelete(Eval* e, Int f);

Intern_Api Int Intern_Extern_Console_New(Eval* e, Int f);
Intern_Api Int Intern_Extern_Console_Delete(Eval* e, Int f);
Intern_Api Int Intern_Extern_Console_Init(Eval* e, Int f);
Intern_Api Int Intern_Extern_Console_Final(Eval* e, Int f);
Intern_Api Int Intern_Extern_Console_OutWrite(Eval* e, Int f);
Intern_Api Int Intern_Extern_Console_ErrWrite(Eval* e, Int f);
Intern_Api Int Intern_Extern_Console_InnRead(Eval* e, Int f);

Intern_Api Int Intern_Extern_Array_New(Eval* e, Int f);
Intern_Api Int Intern_Extern_Array_Delete(Eval* e, Int f);
Intern_Api Int Intern_Extern_Array_Init(Eval* e, Int f);
Intern_Api Int Intern_Extern_Array_Final(Eval* e, Int f);
Intern_Api Int Intern_Extern_Array_CountGet(Eval* e, Int f);
Intern_Api Int Intern_Extern_Array_CountSet(Eval* e, Int f);

Intern_Api Int Intern_Extern_Array_ItemGet(Eval* e, Int f);
Intern_Api Int Intern_Extern_Array_ItemSet(Eval* e, Int f);

Intern_Api Int Intern_Extern_TextCode_New(Eval* e, Int f);
Intern_Api Int Intern_Extern_TextCode_Delete(Eval* e, Int f);
Intern_Api Int Intern_Extern_TextCode_Init(Eval* e, Int f);
Intern_Api Int Intern_Extern_TextCode_Final(Eval* e, Int f);
Intern_Api Int Intern_Extern_TextCode_ExecuteCount(Eval* e, Int f);
Intern_Api Int Intern_Extern_TextCode_ExecuteResult(Eval* e, Int f);

Intern_Api Int Intern_Extern_Format_New(Eval* e, Int f);
Intern_Api Int Intern_Extern_Format_Delete(Eval* e, Int f);
Intern_Api Int Intern_Extern_Format_Init(Eval* e, Int f);
Intern_Api Int Intern_Extern_Format_Final(Eval* e, Int f);
Intern_Api Int Intern_Extern_Format_ExecuteCount(Eval* e, Int f);
Intern_Api Int Intern_Extern_Format_ExecuteResult(Eval* e, Int f);
Intern_Api Int Intern_Extern_Format_ExecuteArgCount(Eval* e, Int f);
Intern_Api Int Intern_Extern_Format_ExecuteArgResult(Eval* e, Int f);

Intern_Api Int Intern_Extern_FormatArg_New(Eval* e, Int f);
Intern_Api Int Intern_Extern_FormatArg_Delete(Eval* e, Int f);
Intern_Api Int Intern_Extern_FormatArg_Init(Eval* e, Int f);
Intern_Api Int Intern_Extern_FormatArg_Final(Eval* e, Int f);
Intern_Api Int Intern_Extern_FormatArg_PosGet(Eval* e, Int f);
Intern_Api Int Intern_Extern_FormatArg_PosSet(Eval* e, Int f);
Intern_Api Int Intern_Extern_FormatArg_KindGet(Eval* e, Int f);
Intern_Api Int Intern_Extern_FormatArg_KindSet(Eval* e, Int f);
Intern_Api Int Intern_Extern_FormatArg_ValueGet(Eval* e, Int f);
Intern_Api Int Intern_Extern_FormatArg_ValueSet(Eval* e, Int f);
Intern_Api Int Intern_Extern_FormatArg_AlignLeftGet(Eval* e, Int f);
Intern_Api Int Intern_Extern_FormatArg_AlignLeftSet(Eval* e, Int f);
Intern_Api Int Intern_Extern_FormatArg_FieldWidthGet(Eval* e, Int f);
Intern_Api Int Intern_Extern_FormatArg_FieldWidthSet(Eval* e, Int f);
Intern_Api Int Intern_Extern_FormatArg_MaxWidthGet(Eval* e, Int f);
Intern_Api Int Intern_Extern_FormatArg_MaxWidthSet(Eval* e, Int f);
Intern_Api Int Intern_Extern_FormatArg_BaseGet(Eval* e, Int f);
Intern_Api Int Intern_Extern_FormatArg_BaseSet(Eval* e, Int f);
Intern_Api Int Intern_Extern_FormatArg_FillCharGet(Eval* e, Int f);
Intern_Api Int Intern_Extern_FormatArg_FillCharSet(Eval* e, Int f);
Intern_Api Int Intern_Extern_FormatArg_ValueCountGet(Eval* e, Int f);
Intern_Api Int Intern_Extern_FormatArg_ValueCountSet(Eval* e, Int f);
Intern_Api Int Intern_Extern_FormatArg_CountGet(Eval* e, Int f);
Intern_Api Int Intern_Extern_FormatArg_CountSet(Eval* e, Int f);
Intern_Api Int Intern_Extern_FormatArg_FormGet(Eval* e, Int f);
Intern_Api Int Intern_Extern_FormatArg_FormSet(Eval* e, Int f);

Intern_Api Int Intern_Extern_Math_New(Eval* e, Int f);
Intern_Api Int Intern_Extern_Math_Delete(Eval* e, Int f);
Intern_Api Int Intern_Extern_Math_Init(Eval* e, Int f);
Intern_Api Int Intern_Extern_Math_Final(Eval* e, Int f);
Intern_Api Int Intern_Extern_Math_Value(Eval* e, Int f);
Intern_Api Int Intern_Extern_Math_ValueTen(Eval* e, Int f);
Intern_Api Int Intern_Extern_Math_Less(Eval* e, Int f);
Intern_Api Int Intern_Extern_Math_Add(Eval* e, Int f);
Intern_Api Int Intern_Extern_Math_Sub(Eval* e, Int f);
Intern_Api Int Intern_Extern_Math_Mul(Eval* e, Int f);
Intern_Api Int Intern_Extern_Math_Div(Eval* e, Int f);
Intern_Api Int Intern_Extern_Math_Abs(Eval* e, Int f);
Intern_Api Int Intern_Extern_Math_Exp(Eval* e, Int f);
Intern_Api Int Intern_Extern_Math_Exp2(Eval* e, Int f);
Intern_Api Int Intern_Extern_Math_Log(Eval* e, Int f);
Intern_Api Int Intern_Extern_Math_Log10(Eval* e, Int f);
Intern_Api Int Intern_Extern_Math_Log2(Eval* e, Int f);
Intern_Api Int Intern_Extern_Math_Pow(Eval* e, Int f);
Intern_Api Int Intern_Extern_Math_Ceil(Eval* e, Int f);
Intern_Api Int Intern_Extern_Math_Floor(Eval* e, Int f);
Intern_Api Int Intern_Extern_Math_Trunc(Eval* e, Int f);
Intern_Api Int Intern_Extern_Math_Round(Eval* e, Int f);
Intern_Api Int Intern_Extern_Math_Sin(Eval* e, Int f);
Intern_Api Int Intern_Extern_Math_Cos(Eval* e, Int f);
Intern_Api Int Intern_Extern_Math_Tan(Eval* e, Int f);
Intern_Api Int Intern_Extern_Math_ASin(Eval* e, Int f);
Intern_Api Int Intern_Extern_Math_ACos(Eval* e, Int f);
Intern_Api Int Intern_Extern_Math_ATan(Eval* e, Int f);
Intern_Api Int Intern_Extern_Math_SinH(Eval* e, Int f);
Intern_Api Int Intern_Extern_Math_CosH(Eval* e, Int f);
Intern_Api Int Intern_Extern_Math_TanH(Eval* e, Int f);
Intern_Api Int Intern_Extern_Math_ASinH(Eval* e, Int f);
Intern_Api Int Intern_Extern_Math_ACosH(Eval* e, Int f);
Intern_Api Int Intern_Extern_Math_ATanH(Eval* e, Int f);

Intern_Api Int Intern_Extern_Rand_New(Eval* e, Int f);
Intern_Api Int Intern_Extern_Rand_Delete(Eval* e, Int f);
Intern_Api Int Intern_Extern_Rand_Init(Eval* e, Int f);
Intern_Api Int Intern_Extern_Rand_Final(Eval* e, Int f);
Intern_Api Int Intern_Extern_Rand_SeedGet(Eval* e, Int f);
Intern_Api Int Intern_Extern_Rand_SeedSet(Eval* e, Int f);

Intern_Api Int Intern_Extern_Rand_Execute(Eval* e, Int f);

Intern_Api Int Intern_Extern_Range_New(Eval* e, Int f);
Intern_Api Int Intern_Extern_Range_Delete(Eval* e, Int f);
Intern_Api Int Intern_Extern_Range_Init(Eval* e, Int f);
Intern_Api Int Intern_Extern_Range_Final(Eval* e, Int f);
Intern_Api Int Intern_Extern_Range_IndexGet(Eval* e, Int f);
Intern_Api Int Intern_Extern_Range_IndexSet(Eval* e, Int f);
Intern_Api Int Intern_Extern_Range_CountGet(Eval* e, Int f);
Intern_Api Int Intern_Extern_Range_CountSet(Eval* e, Int f);

Intern_Api Int Intern_Extern_Rect_New(Eval* e, Int f);
Intern_Api Int Intern_Extern_Rect_Delete(Eval* e, Int f);
Intern_Api Int Intern_Extern_Rect_Init(Eval* e, Int f);
Intern_Api Int Intern_Extern_Rect_Final(Eval* e, Int f);
Intern_Api Int Intern_Extern_Rect_PosGet(Eval* e, Int f);
Intern_Api Int Intern_Extern_Rect_PosSet(Eval* e, Int f);
Intern_Api Int Intern_Extern_Rect_SizeGet(Eval* e, Int f);
Intern_Api Int Intern_Extern_Rect_SizeSet(Eval* e, Int f);

Intern_Api Int Intern_Extern_Pos_New(Eval* e, Int f);
Intern_Api Int Intern_Extern_Pos_Delete(Eval* e, Int f);
Intern_Api Int Intern_Extern_Pos_Init(Eval* e, Int f);
Intern_Api Int Intern_Extern_Pos_Final(Eval* e, Int f);
Intern_Api Int Intern_Extern_Pos_ColGet(Eval* e, Int f);
Intern_Api Int Intern_Extern_Pos_ColSet(Eval* e, Int f);
Intern_Api Int Intern_Extern_Pos_RowGet(Eval* e, Int f);
Intern_Api Int Intern_Extern_Pos_RowSet(Eval* e, Int f);

Intern_Api Int Intern_Extern_Size_New(Eval* e, Int f);
Intern_Api Int Intern_Extern_Size_Delete(Eval* e, Int f);
Intern_Api Int Intern_Extern_Size_Init(Eval* e, Int f);
Intern_Api Int Intern_Extern_Size_Final(Eval* e, Int f);
Intern_Api Int Intern_Extern_Size_WidthGet(Eval* e, Int f);
Intern_Api Int Intern_Extern_Size_WidthSet(Eval* e, Int f);
Intern_Api Int Intern_Extern_Size_HegthGet(Eval* e, Int f);
Intern_Api Int Intern_Extern_Size_HegthSet(Eval* e, Int f);

Intern_Api Int Intern_Extern_Data_New(Eval* e, Int f);
Intern_Api Int Intern_Extern_Data_Delete(Eval* e, Int f);
Intern_Api Int Intern_Extern_Data_Init(Eval* e, Int f);
Intern_Api Int Intern_Extern_Data_Final(Eval* e, Int f);
Intern_Api Int Intern_Extern_Data_CountGet(Eval* e, Int f);
Intern_Api Int Intern_Extern_Data_CountSet(Eval* e, Int f);
Intern_Api Int Intern_Extern_Data_ValueGet(Eval* e, Int f);
Intern_Api Int Intern_Extern_Data_ValueSet(Eval* e, Int f);

Intern_Api Int Intern_Extern_Entry_New(Eval* e, Int f);
Intern_Api Int Intern_Extern_Entry_Delete(Eval* e, Int f);
Intern_Api Int Intern_Extern_Entry_Init(Eval* e, Int f);
Intern_Api Int Intern_Extern_Entry_Final(Eval* e, Int f);
Intern_Api Int Intern_Extern_Entry_IndexGet(Eval* e, Int f);
Intern_Api Int Intern_Extern_Entry_IndexSet(Eval* e, Int f);
Intern_Api Int Intern_Extern_Entry_ValueGet(Eval* e, Int f);
Intern_Api Int Intern_Extern_Entry_ValueSet(Eval* e, Int f);

Intern_Api Int Intern_Extern_State_New(Eval* e, Int f);
Intern_Api Int Intern_Extern_State_Delete(Eval* e, Int f);
Intern_Api Int Intern_Extern_State_Init(Eval* e, Int f);
Intern_Api Int Intern_Extern_State_Final(Eval* e, Int f);
Intern_Api Int Intern_Extern_State_MaideGet(Eval* e, Int f);
Intern_Api Int Intern_Extern_State_MaideSet(Eval* e, Int f);
Intern_Api Int Intern_Extern_State_ArgGet(Eval* e, Int f);
Intern_Api Int Intern_Extern_State_ArgSet(Eval* e, Int f);

Intern_Api Int Intern_Extern_Main_TerminateStateGet(Eval* e, Int f);
Intern_Api Int Intern_Extern_Main_TerminateStateSet(Eval* e, Int f);

Intern_Api Int Intern_Extern_Main_Init(Eval* e, Int f);
Intern_Api Int Intern_Extern_Main_Final(Eval* e, Int f);
Intern_Api Int Intern_Extern_Main_IsCSharpSet(Eval* e, Int f);
Intern_Api Int Intern_Extern_Main_Arg(Eval* e, Int f);

Intern_Api Int Intern_Extern_Screen_New(Eval* e, Int f);
Intern_Api Int Intern_Extern_Screen_Delete(Eval* e, Int f);
Intern_Api Int Intern_Extern_Screen_Init(Eval* e, Int f);
Intern_Api Int Intern_Extern_Screen_Final(Eval* e, Int f);
Intern_Api Int Intern_Extern_Screen_SizeGet(Eval* e, Int f);
Intern_Api Int Intern_Extern_Screen_SizeSet(Eval* e, Int f);
Intern_Api Int Intern_Extern_Screen_DimendGet(Eval* e, Int f);
Intern_Api Int Intern_Extern_Screen_DimendSet(Eval* e, Int f);

Intern_Api Int Intern_Extern_Frame_New(Eval* e, Int f);
Intern_Api Int Intern_Extern_Frame_Delete(Eval* e, Int f);
Intern_Api Int Intern_Extern_Frame_Init(Eval* e, Int f);
Intern_Api Int Intern_Extern_Frame_Final(Eval* e, Int f);
Intern_Api Int Intern_Extern_Frame_TitleGet(Eval* e, Int f);
Intern_Api Int Intern_Extern_Frame_TitleSet(Eval* e, Int f);
Intern_Api Int Intern_Extern_Frame_ShownGet(Eval* e, Int f);
Intern_Api Int Intern_Extern_Frame_ShownSet(Eval* e, Int f);
Intern_Api Int Intern_Extern_Frame_TypeStateGet(Eval* e, Int f);
Intern_Api Int Intern_Extern_Frame_TypeStateSet(Eval* e, Int f);
Intern_Api Int Intern_Extern_Frame_DrawStateGet(Eval* e, Int f);
Intern_Api Int Intern_Extern_Frame_DrawStateSet(Eval* e, Int f);

Intern_Api Int Intern_Extern_Frame_TitleThisSet(Eval* e, Int f);
Intern_Api Int Intern_Extern_Frame_Out(Eval* e, Int f);
Intern_Api Int Intern_Extern_Frame_Update(Eval* e, Int f);
Intern_Api Int Intern_Extern_Frame_Close(Eval* e, Int f);

Intern_Api Int Intern_Extern_Draw_New(Eval* e, Int f);
Intern_Api Int Intern_Extern_Draw_Delete(Eval* e, Int f);
Intern_Api Int Intern_Extern_Draw_Init(Eval* e, Int f);
Intern_Api Int Intern_Extern_Draw_Final(Eval* e, Int f);
Intern_Api Int Intern_Extern_Draw_SizeGet(Eval* e, Int f);
Intern_Api Int Intern_Extern_Draw_SizeSet(Eval* e, Int f);
Intern_Api Int Intern_Extern_Draw_OutGet(Eval* e, Int f);
Intern_Api Int Intern_Extern_Draw_OutSet(Eval* e, Int f);
Intern_Api Int Intern_Extern_Draw_AreaGet(Eval* e, Int f);
Intern_Api Int Intern_Extern_Draw_AreaSet(Eval* e, Int f);
Intern_Api Int Intern_Extern_Draw_FillGet(Eval* e, Int f);
Intern_Api Int Intern_Extern_Draw_FillSet(Eval* e, Int f);
Intern_Api Int Intern_Extern_Draw_FillPosGet(Eval* e, Int f);
Intern_Api Int Intern_Extern_Draw_FillPosSet(Eval* e, Int f);
Intern_Api Int Intern_Extern_Draw_LineGet(Eval* e, Int f);
Intern_Api Int Intern_Extern_Draw_LineSet(Eval* e, Int f);
Intern_Api Int Intern_Extern_Draw_FontGet(Eval* e, Int f);
Intern_Api Int Intern_Extern_Draw_FontSet(Eval* e, Int f);
Intern_Api Int Intern_Extern_Draw_FormGet(Eval* e, Int f);
Intern_Api Int Intern_Extern_Draw_FormSet(Eval* e, Int f);
Intern_Api Int Intern_Extern_Draw_CompGet(Eval* e, Int f);
Intern_Api Int Intern_Extern_Draw_CompSet(Eval* e, Int f);

Intern_Api Int Intern_Extern_Draw_Start(Eval* e, Int f);
Intern_Api Int Intern_Extern_Draw_End(Eval* e, Int f);
Intern_Api Int Intern_Extern_Draw_FillPosThisSet(Eval* e, Int f);
Intern_Api Int Intern_Extern_Draw_AreaThisSet(Eval* e, Int f);
Intern_Api Int Intern_Extern_Draw_Clear(Eval* e, Int f);
Intern_Api Int Intern_Extern_Draw_ExecuteRect(Eval* e, Int f);
Intern_Api Int Intern_Extern_Draw_ExecuteRectRound(Eval* e, Int f);
Intern_Api Int Intern_Extern_Draw_ExecuteRound(Eval* e, Int f);
Intern_Api Int Intern_Extern_Draw_ExecuteRoundLine(Eval* e, Int f);
Intern_Api Int Intern_Extern_Draw_ExecuteRoundPart(Eval* e, Int f);
Intern_Api Int Intern_Extern_Draw_ExecuteRoundShape(Eval* e, Int f);
Intern_Api Int Intern_Extern_Draw_ExecuteLine(Eval* e, Int f);
Intern_Api Int Intern_Extern_Draw_ExecuteShape(Eval* e, Int f);
Intern_Api Int Intern_Extern_Draw_ExecuteImage(Eval* e, Int f);
Intern_Api Int Intern_Extern_Draw_ExecuteText(Eval* e, Int f);

Intern_Api Int Intern_Extern_Brush_New(Eval* e, Int f);
Intern_Api Int Intern_Extern_Brush_Delete(Eval* e, Int f);
Intern_Api Int Intern_Extern_Brush_Init(Eval* e, Int f);
Intern_Api Int Intern_Extern_Brush_Final(Eval* e, Int f);
Intern_Api Int Intern_Extern_Brush_KindGet(Eval* e, Int f);
Intern_Api Int Intern_Extern_Brush_KindSet(Eval* e, Int f);
Intern_Api Int Intern_Extern_Brush_ColorGet(Eval* e, Int f);
Intern_Api Int Intern_Extern_Brush_ColorSet(Eval* e, Int f);
Intern_Api Int Intern_Extern_Brush_PolateGet(Eval* e, Int f);
Intern_Api Int Intern_Extern_Brush_PolateSet(Eval* e, Int f);
Intern_Api Int Intern_Extern_Brush_ImageGet(Eval* e, Int f);
Intern_Api Int Intern_Extern_Brush_ImageSet(Eval* e, Int f);

Intern_Api Int Intern_Extern_Slash_New(Eval* e, Int f);
Intern_Api Int Intern_Extern_Slash_Delete(Eval* e, Int f);
Intern_Api Int Intern_Extern_Slash_Init(Eval* e, Int f);
Intern_Api Int Intern_Extern_Slash_Final(Eval* e, Int f);
Intern_Api Int Intern_Extern_Slash_BrushGet(Eval* e, Int f);
Intern_Api Int Intern_Extern_Slash_BrushSet(Eval* e, Int f);
Intern_Api Int Intern_Extern_Slash_LineGet(Eval* e, Int f);
Intern_Api Int Intern_Extern_Slash_LineSet(Eval* e, Int f);
Intern_Api Int Intern_Extern_Slash_SizeGet(Eval* e, Int f);
Intern_Api Int Intern_Extern_Slash_SizeSet(Eval* e, Int f);
Intern_Api Int Intern_Extern_Slash_CapeGet(Eval* e, Int f);
Intern_Api Int Intern_Extern_Slash_CapeSet(Eval* e, Int f);
Intern_Api Int Intern_Extern_Slash_JoinGet(Eval* e, Int f);
Intern_Api Int Intern_Extern_Slash_JoinSet(Eval* e, Int f);

Intern_Api Int Intern_Extern_PointData_PointGet(Eval* e, Int f);
Intern_Api Int Intern_Extern_PointData_PointSet(Eval* e, Int f);

Intern_Api Int Intern_Extern_Image_New(Eval* e, Int f);
Intern_Api Int Intern_Extern_Image_Delete(Eval* e, Int f);
Intern_Api Int Intern_Extern_Image_Init(Eval* e, Int f);
Intern_Api Int Intern_Extern_Image_Final(Eval* e, Int f);
Intern_Api Int Intern_Extern_Image_SizeGet(Eval* e, Int f);
Intern_Api Int Intern_Extern_Image_SizeSet(Eval* e, Int f);
Intern_Api Int Intern_Extern_Image_DataGet(Eval* e, Int f);
Intern_Api Int Intern_Extern_Image_DataSet(Eval* e, Int f);

Intern_Api Int Intern_Extern_Image_Out(Eval* e, Int f);
Intern_Api Int Intern_Extern_Image_DataCreate(Eval* e, Int f);

Intern_Api Int Intern_Extern_Font_New(Eval* e, Int f);
Intern_Api Int Intern_Extern_Font_Delete(Eval* e, Int f);
Intern_Api Int Intern_Extern_Font_Init(Eval* e, Int f);
Intern_Api Int Intern_Extern_Font_Final(Eval* e, Int f);
Intern_Api Int Intern_Extern_Font_NameGet(Eval* e, Int f);
Intern_Api Int Intern_Extern_Font_NameSet(Eval* e, Int f);
Intern_Api Int Intern_Extern_Font_SizeGet(Eval* e, Int f);
Intern_Api Int Intern_Extern_Font_SizeSet(Eval* e, Int f);
Intern_Api Int Intern_Extern_Font_StrongGet(Eval* e, Int f);
Intern_Api Int Intern_Extern_Font_StrongSet(Eval* e, Int f);
Intern_Api Int Intern_Extern_Font_TendenGet(Eval* e, Int f);
Intern_Api Int Intern_Extern_Font_TendenSet(Eval* e, Int f);
Intern_Api Int Intern_Extern_Font_StalineGet(Eval* e, Int f);
Intern_Api Int Intern_Extern_Font_StalineSet(Eval* e, Int f);
Intern_Api Int Intern_Extern_Font_MidlineGet(Eval* e, Int f);
Intern_Api Int Intern_Extern_Font_MidlineSet(Eval* e, Int f);
Intern_Api Int Intern_Extern_Font_EndlineGet(Eval* e, Int f);
Intern_Api Int Intern_Extern_Font_EndlineSet(Eval* e, Int f);

Intern_Api Int Intern_Extern_Form_New(Eval* e, Int f);
Intern_Api Int Intern_Extern_Form_Delete(Eval* e, Int f);
Intern_Api Int Intern_Extern_Form_Init(Eval* e, Int f);
Intern_Api Int Intern_Extern_Form_Final(Eval* e, Int f);
Intern_Api Int Intern_Extern_Form_Reset(Eval* e, Int f);
Intern_Api Int Intern_Extern_Form_Pos(Eval* e, Int f);
Intern_Api Int Intern_Extern_Form_Angle(Eval* e, Int f);
Intern_Api Int Intern_Extern_Form_Scale(Eval* e, Int f);
Intern_Api Int Intern_Extern_Form_ValueGet(Eval* e, Int f);
Intern_Api Int Intern_Extern_Form_ValueSet(Eval* e, Int f);
Intern_Api Int Intern_Extern_Form_Mul(Eval* e, Int f);
Intern_Api Int Intern_Extern_Form_Ident(Eval* e, Int f);
Intern_Api Int Intern_Extern_Form_IsInvertible(Eval* e, Int f);
Intern_Api Int Intern_Extern_Form_Invert(Eval* e, Int f);
Intern_Api Int Intern_Extern_Form_Transpose(Eval* e, Int f);

Intern_Api Int Intern_Extern_Polate_New(Eval* e, Int f);
Intern_Api Int Intern_Extern_Polate_Delete(Eval* e, Int f);
Intern_Api Int Intern_Extern_Polate_Init(Eval* e, Int f);
Intern_Api Int Intern_Extern_Polate_Final(Eval* e, Int f);
Intern_Api Int Intern_Extern_Polate_KindGet(Eval* e, Int f);
Intern_Api Int Intern_Extern_Polate_KindSet(Eval* e, Int f);
Intern_Api Int Intern_Extern_Polate_ValueGet(Eval* e, Int f);
Intern_Api Int Intern_Extern_Polate_ValueSet(Eval* e, Int f);
Intern_Api Int Intern_Extern_Polate_StopGet(Eval* e, Int f);
Intern_Api Int Intern_Extern_Polate_StopSet(Eval* e, Int f);
Intern_Api Int Intern_Extern_Polate_SpreadGet(Eval* e, Int f);
Intern_Api Int Intern_Extern_Polate_SpreadSet(Eval* e, Int f);

Intern_Api Int Intern_Extern_PolateLinear_New(Eval* e, Int f);
Intern_Api Int Intern_Extern_PolateLinear_Delete(Eval* e, Int f);
Intern_Api Int Intern_Extern_PolateLinear_Init(Eval* e, Int f);
Intern_Api Int Intern_Extern_PolateLinear_Final(Eval* e, Int f);
Intern_Api Int Intern_Extern_PolateLinear_StartPosGet(Eval* e, Int f);
Intern_Api Int Intern_Extern_PolateLinear_StartPosSet(Eval* e, Int f);
Intern_Api Int Intern_Extern_PolateLinear_EndPosGet(Eval* e, Int f);
Intern_Api Int Intern_Extern_PolateLinear_EndPosSet(Eval* e, Int f);

Intern_Api Int Intern_Extern_PolateRadial_New(Eval* e, Int f);
Intern_Api Int Intern_Extern_PolateRadial_Delete(Eval* e, Int f);
Intern_Api Int Intern_Extern_PolateRadial_Init(Eval* e, Int f);
Intern_Api Int Intern_Extern_PolateRadial_Final(Eval* e, Int f);
Intern_Api Int Intern_Extern_PolateRadial_CenterPosGet(Eval* e, Int f);
Intern_Api Int Intern_Extern_PolateRadial_CenterPosSet(Eval* e, Int f);
Intern_Api Int Intern_Extern_PolateRadial_CenterRadiusGet(Eval* e, Int f);
Intern_Api Int Intern_Extern_PolateRadial_CenterRadiusSet(Eval* e, Int f);
Intern_Api Int Intern_Extern_PolateRadial_FocusPosGet(Eval* e, Int f);
Intern_Api Int Intern_Extern_PolateRadial_FocusPosSet(Eval* e, Int f);
Intern_Api Int Intern_Extern_PolateRadial_FocusRadiusGet(Eval* e, Int f);
Intern_Api Int Intern_Extern_PolateRadial_FocusRadiusSet(Eval* e, Int f);

Intern_Api Int Intern_Extern_PolateStop_New(Eval* e, Int f);
Intern_Api Int Intern_Extern_PolateStop_Delete(Eval* e, Int f);
Intern_Api Int Intern_Extern_PolateStop_Init(Eval* e, Int f);
Intern_Api Int Intern_Extern_PolateStop_Final(Eval* e, Int f);
Intern_Api Int Intern_Extern_PolateStop_CountGet(Eval* e, Int f);
Intern_Api Int Intern_Extern_PolateStop_CountSet(Eval* e, Int f);

Intern_Api Int Intern_Extern_PolateStop_PointGetPos(Eval* e, Int f);
Intern_Api Int Intern_Extern_PolateStop_PointGetColor(Eval* e, Int f);
Intern_Api Int Intern_Extern_PolateStop_PointSet(Eval* e, Int f);

Intern_Api Int Intern_Extern_ImageRead_New(Eval* e, Int f);
Intern_Api Int Intern_Extern_ImageRead_Delete(Eval* e, Int f);
Intern_Api Int Intern_Extern_ImageRead_Init(Eval* e, Int f);
Intern_Api Int Intern_Extern_ImageRead_Final(Eval* e, Int f);
Intern_Api Int Intern_Extern_ImageRead_StreamGet(Eval* e, Int f);
Intern_Api Int Intern_Extern_ImageRead_StreamSet(Eval* e, Int f);
Intern_Api Int Intern_Extern_ImageRead_ImageGet(Eval* e, Int f);
Intern_Api Int Intern_Extern_ImageRead_ImageSet(Eval* e, Int f);

Intern_Api Int Intern_Extern_ImageRead_Execute(Eval* e, Int f);

Intern_Api Int Intern_Extern_ImageWrite_New(Eval* e, Int f);
Intern_Api Int Intern_Extern_ImageWrite_Delete(Eval* e, Int f);
Intern_Api Int Intern_Extern_ImageWrite_Init(Eval* e, Int f);
Intern_Api Int Intern_Extern_ImageWrite_Final(Eval* e, Int f);
Intern_Api Int Intern_Extern_ImageWrite_StreamGet(Eval* e, Int f);
Intern_Api Int Intern_Extern_ImageWrite_StreamSet(Eval* e, Int f);
Intern_Api Int Intern_Extern_ImageWrite_ImageGet(Eval* e, Int f);
Intern_Api Int Intern_Extern_ImageWrite_ImageSet(Eval* e, Int f);
Intern_Api Int Intern_Extern_ImageWrite_FormatGet(Eval* e, Int f);
Intern_Api Int Intern_Extern_ImageWrite_FormatSet(Eval* e, Int f);

Intern_Api Int Intern_Extern_ImageWrite_Execute(Eval* e, Int f);

Intern_Api Int Intern_Extern_FontStore_New(Eval* e, Int f);
Intern_Api Int Intern_Extern_FontStore_Delete(Eval* e, Int f);
Intern_Api Int Intern_Extern_FontStore_Init(Eval* e, Int f);
Intern_Api Int Intern_Extern_FontStore_Final(Eval* e, Int f);
Intern_Api Int Intern_Extern_FontStore_Add(Eval* e, Int f);
Intern_Api Int Intern_Extern_FontStore_Rem(Eval* e, Int f);
Intern_Api Int Intern_Extern_FontStore_NameList(Eval* e, Int f);
Intern_Api Int Intern_Extern_FontStore_NameListIdent(Eval* e, Int f);

Intern_Api Int Intern_Extern_VideoOut_New(Eval* e, Int f);
Intern_Api Int Intern_Extern_VideoOut_Delete(Eval* e, Int f);
Intern_Api Int Intern_Extern_VideoOut_Init(Eval* e, Int f);
Intern_Api Int Intern_Extern_VideoOut_Final(Eval* e, Int f);
Intern_Api Int Intern_Extern_VideoOut_FrameGet(Eval* e, Int f);
Intern_Api Int Intern_Extern_VideoOut_FrameSet(Eval* e, Int f);
Intern_Api Int Intern_Extern_VideoOut_FrameEventStateGet(Eval* e, Int f);
Intern_Api Int Intern_Extern_VideoOut_FrameEventStateSet(Eval* e, Int f);

Intern_Api Int Intern_Extern_VideoFrame_New(Eval* e, Int f);
Intern_Api Int Intern_Extern_VideoFrame_Delete(Eval* e, Int f);
Intern_Api Int Intern_Extern_VideoFrame_Init(Eval* e, Int f);
Intern_Api Int Intern_Extern_VideoFrame_Final(Eval* e, Int f);
Intern_Api Int Intern_Extern_VideoFrame_SizeGet(Eval* e, Int f);
Intern_Api Int Intern_Extern_VideoFrame_SizeSet(Eval* e, Int f);

Intern_Api Int Intern_Extern_VideoFrame_Image(Eval* e, Int f);

Intern_Api Int Intern_Extern_AudioOut_New(Eval* e, Int f);
Intern_Api Int Intern_Extern_AudioOut_Delete(Eval* e, Int f);
Intern_Api Int Intern_Extern_AudioOut_Init(Eval* e, Int f);
Intern_Api Int Intern_Extern_AudioOut_Final(Eval* e, Int f);
Intern_Api Int Intern_Extern_AudioOut_MuteGet(Eval* e, Int f);
Intern_Api Int Intern_Extern_AudioOut_MuteSet(Eval* e, Int f);
Intern_Api Int Intern_Extern_AudioOut_VolumeGet(Eval* e, Int f);
Intern_Api Int Intern_Extern_AudioOut_VolumeSet(Eval* e, Int f);

Intern_Api Int Intern_Extern_Play_New(Eval* e, Int f);
Intern_Api Int Intern_Extern_Play_Delete(Eval* e, Int f);
Intern_Api Int Intern_Extern_Play_Init(Eval* e, Int f);
Intern_Api Int Intern_Extern_Play_Final(Eval* e, Int f);
Intern_Api Int Intern_Extern_Play_SourceGet(Eval* e, Int f);
Intern_Api Int Intern_Extern_Play_SourceSet(Eval* e, Int f);
Intern_Api Int Intern_Extern_Play_VideoOutGet(Eval* e, Int f);
Intern_Api Int Intern_Extern_Play_VideoOutSet(Eval* e, Int f);
Intern_Api Int Intern_Extern_Play_AudioOutGet(Eval* e, Int f);
Intern_Api Int Intern_Extern_Play_AudioOutSet(Eval* e, Int f);
Intern_Api Int Intern_Extern_Play_TimeGet(Eval* e, Int f);
Intern_Api Int Intern_Extern_Play_TimeSet(Eval* e, Int f);
Intern_Api Int Intern_Extern_Play_PosGet(Eval* e, Int f);
Intern_Api Int Intern_Extern_Play_PosSet(Eval* e, Int f);

Intern_Api Int Intern_Extern_Play_SourceThisSet(Eval* e, Int f);
Intern_Api Int Intern_Extern_Play_HasVideo(Eval* e, Int f);
Intern_Api Int Intern_Extern_Play_HasAudio(Eval* e, Int f);
Intern_Api Int Intern_Extern_Play_Execute(Eval* e, Int f);
Intern_Api Int Intern_Extern_Play_Pause(Eval* e, Int f);
Intern_Api Int Intern_Extern_Play_Stop(Eval* e, Int f);

Intern_Api Int Intern_Extern_Stream_New(Eval* e, Int f);
Intern_Api Int Intern_Extern_Stream_Delete(Eval* e, Int f);
Intern_Api Int Intern_Extern_Stream_Init(Eval* e, Int f);
Intern_Api Int Intern_Extern_Stream_Final(Eval* e, Int f);
Intern_Api Int Intern_Extern_Stream_KindGet(Eval* e, Int f);
Intern_Api Int Intern_Extern_Stream_KindSet(Eval* e, Int f);
Intern_Api Int Intern_Extern_Stream_StatusGet(Eval* e, Int f);
Intern_Api Int Intern_Extern_Stream_StatusSet(Eval* e, Int f);

Intern_Api Int Intern_Extern_Stream_CountGet(Eval* e, Int f);
Intern_Api Int Intern_Extern_Stream_PosGet(Eval* e, Int f);
Intern_Api Int Intern_Extern_Stream_PosSet(Eval* e, Int f);
Intern_Api Int Intern_Extern_Stream_HasCount(Eval* e, Int f);
Intern_Api Int Intern_Extern_Stream_HasPos(Eval* e, Int f);
Intern_Api Int Intern_Extern_Stream_CanRead(Eval* e, Int f);
Intern_Api Int Intern_Extern_Stream_CanWrite(Eval* e, Int f);
Intern_Api Int Intern_Extern_Stream_Read(Eval* e, Int f);
Intern_Api Int Intern_Extern_Stream_Write(Eval* e, Int f);

Intern_Api Int Intern_Extern_Memory_New(Eval* e, Int f);
Intern_Api Int Intern_Extern_Memory_Delete(Eval* e, Int f);
Intern_Api Int Intern_Extern_Memory_Init(Eval* e, Int f);
Intern_Api Int Intern_Extern_Memory_Final(Eval* e, Int f);
Intern_Api Int Intern_Extern_Memory_StreamGet(Eval* e, Int f);
Intern_Api Int Intern_Extern_Memory_StreamSet(Eval* e, Int f);

Intern_Api Int Intern_Extern_Memory_Open(Eval* e, Int f);
Intern_Api Int Intern_Extern_Memory_Close(Eval* e, Int f);

Intern_Api Int Intern_Extern_Storage_New(Eval* e, Int f);
Intern_Api Int Intern_Extern_Storage_Delete(Eval* e, Int f);
Intern_Api Int Intern_Extern_Storage_Init(Eval* e, Int f);
Intern_Api Int Intern_Extern_Storage_Final(Eval* e, Int f);
Intern_Api Int Intern_Extern_Storage_PathGet(Eval* e, Int f);
Intern_Api Int Intern_Extern_Storage_PathSet(Eval* e, Int f);
Intern_Api Int Intern_Extern_Storage_ModeGet(Eval* e, Int f);
Intern_Api Int Intern_Extern_Storage_ModeSet(Eval* e, Int f);
Intern_Api Int Intern_Extern_Storage_StreamGet(Eval* e, Int f);
Intern_Api Int Intern_Extern_Storage_StreamSet(Eval* e, Int f);
Intern_Api Int Intern_Extern_Storage_StatusGet(Eval* e, Int f);
Intern_Api Int Intern_Extern_Storage_StatusSet(Eval* e, Int f);

Intern_Api Int Intern_Extern_Storage_CountSet(Eval* e, Int f);
Intern_Api Int Intern_Extern_Storage_Open(Eval* e, Int f);
Intern_Api Int Intern_Extern_Storage_Close(Eval* e, Int f);

Intern_Api Int Intern_Extern_StorageComp_New(Eval* e, Int f);
Intern_Api Int Intern_Extern_StorageComp_Delete(Eval* e, Int f);
Intern_Api Int Intern_Extern_StorageComp_Init(Eval* e, Int f);
Intern_Api Int Intern_Extern_StorageComp_Final(Eval* e, Int f);
Intern_Api Int Intern_Extern_StorageComp_Rename(Eval* e, Int f);
Intern_Api Int Intern_Extern_StorageComp_FileCopy(Eval* e, Int f);
Intern_Api Int Intern_Extern_StorageComp_FileDelete(Eval* e, Int f);
Intern_Api Int Intern_Extern_StorageComp_FoldCreate(Eval* e, Int f);
Intern_Api Int Intern_Extern_StorageComp_FoldCopy(Eval* e, Int f);
Intern_Api Int Intern_Extern_StorageComp_FoldDelete(Eval* e, Int f);
Intern_Api Int Intern_Extern_StorageComp_Entry(Eval* e, Int f);
Intern_Api Int Intern_Extern_StorageComp_EntryList(Eval* e, Int f);
Intern_Api Int Intern_Extern_StorageComp_ThisFoldGet(Eval* e, Int f);
Intern_Api Int Intern_Extern_StorageComp_ThisFoldSet(Eval* e, Int f);

Intern_Api Int Intern_Extern_StorageEntry_New(Eval* e, Int f);
Intern_Api Int Intern_Extern_StorageEntry_Delete(Eval* e, Int f);
Intern_Api Int Intern_Extern_StorageEntry_Init(Eval* e, Int f);
Intern_Api Int Intern_Extern_StorageEntry_Final(Eval* e, Int f);
Intern_Api Int Intern_Extern_StorageEntry_NameGet(Eval* e, Int f);
Intern_Api Int Intern_Extern_StorageEntry_NameSet(Eval* e, Int f);
Intern_Api Int Intern_Extern_StorageEntry_ExistGet(Eval* e, Int f);
Intern_Api Int Intern_Extern_StorageEntry_ExistSet(Eval* e, Int f);
Intern_Api Int Intern_Extern_StorageEntry_FoldGet(Eval* e, Int f);
Intern_Api Int Intern_Extern_StorageEntry_FoldSet(Eval* e, Int f);
Intern_Api Int Intern_Extern_StorageEntry_SizeGet(Eval* e, Int f);
Intern_Api Int Intern_Extern_StorageEntry_SizeSet(Eval* e, Int f);
Intern_Api Int Intern_Extern_StorageEntry_CreateTimeGet(Eval* e, Int f);
Intern_Api Int Intern_Extern_StorageEntry_CreateTimeSet(Eval* e, Int f);
Intern_Api Int Intern_Extern_StorageEntry_ModifyTimeGet(Eval* e, Int f);
Intern_Api Int Intern_Extern_StorageEntry_ModifyTimeSet(Eval* e, Int f);
Intern_Api Int Intern_Extern_StorageEntry_OwnerGet(Eval* e, Int f);
Intern_Api Int Intern_Extern_StorageEntry_OwnerSet(Eval* e, Int f);
Intern_Api Int Intern_Extern_StorageEntry_GroupGet(Eval* e, Int f);
Intern_Api Int Intern_Extern_StorageEntry_GroupSet(Eval* e, Int f);
Intern_Api Int Intern_Extern_StorageEntry_PermitGet(Eval* e, Int f);
Intern_Api Int Intern_Extern_StorageEntry_PermitSet(Eval* e, Int f);

Intern_Api Int Intern_Extern_Network_New(Eval* e, Int f);
Intern_Api Int Intern_Extern_Network_Delete(Eval* e, Int f);
Intern_Api Int Intern_Extern_Network_Init(Eval* e, Int f);
Intern_Api Int Intern_Extern_Network_Final(Eval* e, Int f);
Intern_Api Int Intern_Extern_Network_HostNameGet(Eval* e, Int f);
Intern_Api Int Intern_Extern_Network_HostNameSet(Eval* e, Int f);
Intern_Api Int Intern_Extern_Network_HostPortGet(Eval* e, Int f);
Intern_Api Int Intern_Extern_Network_HostPortSet(Eval* e, Int f);
Intern_Api Int Intern_Extern_Network_StreamGet(Eval* e, Int f);
Intern_Api Int Intern_Extern_Network_StreamSet(Eval* e, Int f);
Intern_Api Int Intern_Extern_Network_ReadyCountGet(Eval* e, Int f);
Intern_Api Int Intern_Extern_Network_ReadyCountSet(Eval* e, Int f);
Intern_Api Int Intern_Extern_Network_StatusGet(Eval* e, Int f);
Intern_Api Int Intern_Extern_Network_StatusSet(Eval* e, Int f);
Intern_Api Int Intern_Extern_Network_CaseGet(Eval* e, Int f);
Intern_Api Int Intern_Extern_Network_CaseSet(Eval* e, Int f);
Intern_Api Int Intern_Extern_Network_StatusEventStateGet(Eval* e, Int f);
Intern_Api Int Intern_Extern_Network_StatusEventStateSet(Eval* e, Int f);
Intern_Api Int Intern_Extern_Network_CaseEventStateGet(Eval* e, Int f);
Intern_Api Int Intern_Extern_Network_CaseEventStateSet(Eval* e, Int f);
Intern_Api Int Intern_Extern_Network_DataEventStateGet(Eval* e, Int f);
Intern_Api Int Intern_Extern_Network_DataEventStateSet(Eval* e, Int f);

Intern_Api Int Intern_Extern_Network_Open(Eval* e, Int f);
Intern_Api Int Intern_Extern_Network_Close(Eval* e, Int f);

Intern_Api Int Intern_Extern_NetworkHost_New(Eval* e, Int f);
Intern_Api Int Intern_Extern_NetworkHost_Delete(Eval* e, Int f);
Intern_Api Int Intern_Extern_NetworkHost_Init(Eval* e, Int f);
Intern_Api Int Intern_Extern_NetworkHost_Final(Eval* e, Int f);
Intern_Api Int Intern_Extern_NetworkHost_PortGet(Eval* e, Int f);
Intern_Api Int Intern_Extern_NetworkHost_PortSet(Eval* e, Int f);
Intern_Api Int Intern_Extern_NetworkHost_NewPeerStateGet(Eval* e, Int f);
Intern_Api Int Intern_Extern_NetworkHost_NewPeerStateSet(Eval* e, Int f);

Intern_Api Int Intern_Extern_NetworkHost_Open(Eval* e, Int f);
Intern_Api Int Intern_Extern_NetworkHost_Close(Eval* e, Int f);
Intern_Api Int Intern_Extern_NetworkHost_OpenPeer(Eval* e, Int f);
Intern_Api Int Intern_Extern_NetworkHost_ClosePeer(Eval* e, Int f);

Intern_Api Int Intern_Extern_NetworkPort_New(Eval* e, Int f);
Intern_Api Int Intern_Extern_NetworkPort_Delete(Eval* e, Int f);
Intern_Api Int Intern_Extern_NetworkPort_Init(Eval* e, Int f);
Intern_Api Int Intern_Extern_NetworkPort_Final(Eval* e, Int f);
Intern_Api Int Intern_Extern_NetworkPort_KindGet(Eval* e, Int f);
Intern_Api Int Intern_Extern_NetworkPort_KindSet(Eval* e, Int f);
Intern_Api Int Intern_Extern_NetworkPort_ValueAGet(Eval* e, Int f);
Intern_Api Int Intern_Extern_NetworkPort_ValueASet(Eval* e, Int f);
Intern_Api Int Intern_Extern_NetworkPort_ValueBGet(Eval* e, Int f);
Intern_Api Int Intern_Extern_NetworkPort_ValueBSet(Eval* e, Int f);
Intern_Api Int Intern_Extern_NetworkPort_ValueCGet(Eval* e, Int f);
Intern_Api Int Intern_Extern_NetworkPort_ValueCSet(Eval* e, Int f);
Intern_Api Int Intern_Extern_NetworkPort_HostGet(Eval* e, Int f);
Intern_Api Int Intern_Extern_NetworkPort_HostSet(Eval* e, Int f);

Intern_Api Int Intern_Extern_NetworkPort_Set(Eval* e, Int f);

Intern_Api Int Intern_Extern_Thread_New(Eval* e, Int f);
Intern_Api Int Intern_Extern_Thread_Delete(Eval* e, Int f);
Intern_Api Int Intern_Extern_Thread_Init(Eval* e, Int f);
Intern_Api Int Intern_Extern_Thread_Final(Eval* e, Int f);
Intern_Api Int Intern_Extern_Thread_IdentGet(Eval* e, Int f);
Intern_Api Int Intern_Extern_Thread_IdentSet(Eval* e, Int f);
Intern_Api Int Intern_Extern_Thread_ExecuteStateGet(Eval* e, Int f);
Intern_Api Int Intern_Extern_Thread_ExecuteStateSet(Eval* e, Int f);
Intern_Api Int Intern_Extern_Thread_StatusGet(Eval* e, Int f);
Intern_Api Int Intern_Extern_Thread_StatusSet(Eval* e, Int f);
Intern_Api Int Intern_Extern_Thread_CaseGet(Eval* e, Int f);
Intern_Api Int Intern_Extern_Thread_CaseSet(Eval* e, Int f);

Intern_Api Int Intern_Extern_Thread_Execute(Eval* e, Int f);
Intern_Api Int Intern_Extern_Thread_Pause(Eval* e, Int f);
Intern_Api Int Intern_Extern_Thread_Resume(Eval* e, Int f);
Intern_Api Int Intern_Extern_Thread_Wait(Eval* e, Int f);
Intern_Api Int Intern_Extern_Thread_ExecuteMain(Eval* e, Int f);
Intern_Api Int Intern_Extern_Thread_Exit(Eval* e, Int f);

Intern_Api Int Intern_Extern_Thread_This(Eval* e, Int f);

Intern_Api Int Intern_Extern_Phore_New(Eval* e, Int f);
Intern_Api Int Intern_Extern_Phore_Delete(Eval* e, Int f);
Intern_Api Int Intern_Extern_Phore_Init(Eval* e, Int f);
Intern_Api Int Intern_Extern_Phore_Final(Eval* e, Int f);
Intern_Api Int Intern_Extern_Phore_CountGet(Eval* e, Int f);
Intern_Api Int Intern_Extern_Phore_CountSet(Eval* e, Int f);
Intern_Api Int Intern_Extern_Phore_InitCountGet(Eval* e, Int f);
Intern_Api Int Intern_Extern_Phore_InitCountSet(Eval* e, Int f);

Intern_Api Int Intern_Extern_Phore_Open(Eval* e, Int f);
Intern_Api Int Intern_Extern_Phore_Close(Eval* e, Int f);

Intern_Api Int Intern_Extern_Time_New(Eval* e, Int f);
Intern_Api Int Intern_Extern_Time_Delete(Eval* e, Int f);
Intern_Api Int Intern_Extern_Time_Init(Eval* e, Int f);
Intern_Api Int Intern_Extern_Time_Final(Eval* e, Int f);
Intern_Api Int Intern_Extern_Time_YeaGet(Eval* e, Int f);
Intern_Api Int Intern_Extern_Time_YeaSet(Eval* e, Int f);
Intern_Api Int Intern_Extern_Time_MonGet(Eval* e, Int f);
Intern_Api Int Intern_Extern_Time_MonSet(Eval* e, Int f);
Intern_Api Int Intern_Extern_Time_DayGet(Eval* e, Int f);
Intern_Api Int Intern_Extern_Time_DaySet(Eval* e, Int f);
Intern_Api Int Intern_Extern_Time_OurGet(Eval* e, Int f);
Intern_Api Int Intern_Extern_Time_OurSet(Eval* e, Int f);
Intern_Api Int Intern_Extern_Time_MinGet(Eval* e, Int f);
Intern_Api Int Intern_Extern_Time_MinSet(Eval* e, Int f);
Intern_Api Int Intern_Extern_Time_SecGet(Eval* e, Int f);
Intern_Api Int Intern_Extern_Time_SecSet(Eval* e, Int f);
Intern_Api Int Intern_Extern_Time_TickGet(Eval* e, Int f);
Intern_Api Int Intern_Extern_Time_TickSet(Eval* e, Int f);
Intern_Api Int Intern_Extern_Time_PosGet(Eval* e, Int f);
Intern_Api Int Intern_Extern_Time_PosSet(Eval* e, Int f);
Intern_Api Int Intern_Extern_Time_YeaDayGet(Eval* e, Int f);
Intern_Api Int Intern_Extern_Time_YeaDaySet(Eval* e, Int f);
Intern_Api Int Intern_Extern_Time_WeekDayGet(Eval* e, Int f);
Intern_Api Int Intern_Extern_Time_WeekDaySet(Eval* e, Int f);
Intern_Api Int Intern_Extern_Time_YeaDayCountGet(Eval* e, Int f);
Intern_Api Int Intern_Extern_Time_YeaDayCountSet(Eval* e, Int f);
Intern_Api Int Intern_Extern_Time_MonDayCountGet(Eval* e, Int f);
Intern_Api Int Intern_Extern_Time_MonDayCountSet(Eval* e, Int f);
Intern_Api Int Intern_Extern_Time_TotalTickGet(Eval* e, Int f);
Intern_Api Int Intern_Extern_Time_TotalTickSet(Eval* e, Int f);

Intern_Api Int Intern_Extern_Time_AddYea(Eval* e, Int f);
Intern_Api Int Intern_Extern_Time_AddMon(Eval* e, Int f);
Intern_Api Int Intern_Extern_Time_AddDay(Eval* e, Int f);
Intern_Api Int Intern_Extern_Time_AddTick(Eval* e, Int f);
Intern_Api Int Intern_Extern_Time_This(Eval* e, Int f);
Intern_Api Int Intern_Extern_Time_ToPos(Eval* e, Int f);
Intern_Api Int Intern_Extern_Time_Set(Eval* e, Int f);

Intern_Api Int Intern_Extern_Time_LeapYea(Eval* e, Int f);
Intern_Api Int Intern_Extern_Time_ValidDate(Eval* e, Int f);
Intern_Api Int Intern_Extern_Time_ValidTime(Eval* e, Int f);

Intern_Api Int Intern_Extern_TimeEvent_New(Eval* e, Int f);
Intern_Api Int Intern_Extern_TimeEvent_Delete(Eval* e, Int f);
Intern_Api Int Intern_Extern_TimeEvent_Init(Eval* e, Int f);
Intern_Api Int Intern_Extern_TimeEvent_Final(Eval* e, Int f);
Intern_Api Int Intern_Extern_TimeEvent_TimeGet(Eval* e, Int f);
Intern_Api Int Intern_Extern_TimeEvent_TimeSet(Eval* e, Int f);
Intern_Api Int Intern_Extern_TimeEvent_SingleGet(Eval* e, Int f);
Intern_Api Int Intern_Extern_TimeEvent_SingleSet(Eval* e, Int f);
Intern_Api Int Intern_Extern_TimeEvent_ActiveGet(Eval* e, Int f);
Intern_Api Int Intern_Extern_TimeEvent_ActiveSet(Eval* e, Int f);
Intern_Api Int Intern_Extern_TimeEvent_ElapseStateGet(Eval* e, Int f);
Intern_Api Int Intern_Extern_TimeEvent_ElapseStateSet(Eval* e, Int f);

Intern_Api Int Intern_Extern_TimeEvent_Start(Eval* e, Int f);
Intern_Api Int Intern_Extern_TimeEvent_Stop(Eval* e, Int f);

Intern_Api Int Intern_Extern_TimeEvent_Wait(Eval* e, Int f);

Intern_Api Int Intern_Extern_Program_New(Eval* e, Int f);
Intern_Api Int Intern_Extern_Program_Delete(Eval* e, Int f);
Intern_Api Int Intern_Extern_Program_Init(Eval* e, Int f);
Intern_Api Int Intern_Extern_Program_Final(Eval* e, Int f);
Intern_Api Int Intern_Extern_Program_NameGet(Eval* e, Int f);
Intern_Api Int Intern_Extern_Program_NameSet(Eval* e, Int f);
Intern_Api Int Intern_Extern_Program_ArgueGet(Eval* e, Int f);
Intern_Api Int Intern_Extern_Program_ArgueSet(Eval* e, Int f);
Intern_Api Int Intern_Extern_Program_WorkFoldGet(Eval* e, Int f);
Intern_Api Int Intern_Extern_Program_WorkFoldSet(Eval* e, Int f);
Intern_Api Int Intern_Extern_Program_EnvironGet(Eval* e, Int f);
Intern_Api Int Intern_Extern_Program_EnvironSet(Eval* e, Int f);
Intern_Api Int Intern_Extern_Program_IdentGet(Eval* e, Int f);
Intern_Api Int Intern_Extern_Program_IdentSet(Eval* e, Int f);
Intern_Api Int Intern_Extern_Program_StatusGet(Eval* e, Int f);
Intern_Api Int Intern_Extern_Program_StatusSet(Eval* e, Int f);

Intern_Api Int Intern_Extern_Program_Execute(Eval* e, Int f);
Intern_Api Int Intern_Extern_Program_Wait(Eval* e, Int f);
Intern_Api Int Intern_Extern_Program_Exit(Eval* e, Int f);

Intern_Api Int Intern_Extern_Infra_Share(Eval* e, Int f);

Intern_Api Int Intern_Extern_Share_Stat(Eval* e, Int f);

Intern_Api Int Intern_Extern_Stat_PointDataCount(Eval* e, Int f);
Intern_Api Int Intern_Extern_Stat_TextAlignStart(Eval* e, Int f);
Intern_Api Int Intern_Extern_Stat_TextAlignMid(Eval* e, Int f);
Intern_Api Int Intern_Extern_Stat_TextAlignEnd(Eval* e, Int f);
Intern_Api Int Intern_Extern_Stat_TextCodeKindUtf8(Eval* e, Int f);
Intern_Api Int Intern_Extern_Stat_TextCodeKindUtf16(Eval* e, Int f);
Intern_Api Int Intern_Extern_Stat_TextCodeKindUtf32(Eval* e, Int f);
Intern_Api Int Intern_Extern_Stat_ThreadCaseReady(Eval* e, Int f);
Intern_Api Int Intern_Extern_Stat_ThreadCaseExecute(Eval* e, Int f);
Intern_Api Int Intern_Extern_Stat_ThreadCasePause(Eval* e, Int f);
Intern_Api Int Intern_Extern_Stat_ThreadCaseFinish(Eval* e, Int f);
Intern_Api Int Intern_Extern_Stat_ThreadCaseTerminate(Eval* e, Int f);
Intern_Api Int Intern_Extern_Stat_StreamKindMemory(Eval* e, Int f);
Intern_Api Int Intern_Extern_Stat_StreamKindStorage(Eval* e, Int f);
Intern_Api Int Intern_Extern_Stat_StreamKindNetwork(Eval* e, Int f);
Intern_Api Int Intern_Extern_Stat_StorageModeRead(Eval* e, Int f);
Intern_Api Int Intern_Extern_Stat_StorageModeWrite(Eval* e, Int f);
Intern_Api Int Intern_Extern_Stat_StorageModeNew(Eval* e, Int f);
Intern_Api Int Intern_Extern_Stat_StorageModeExist(Eval* e, Int f);
Intern_Api Int Intern_Extern_Stat_StorageStatusNoError(Eval* e, Int f);
Intern_Api Int Intern_Extern_Stat_StorageStatusReadError(Eval* e, Int f);
Intern_Api Int Intern_Extern_Stat_StorageStatusWriteError(Eval* e, Int f);
Intern_Api Int Intern_Extern_Stat_StorageStatusFatalError(Eval* e, Int f);
Intern_Api Int Intern_Extern_Stat_StorageStatusResourceError(Eval* e, Int f);
Intern_Api Int Intern_Extern_Stat_StorageStatusOpenError(Eval* e, Int f);
Intern_Api Int Intern_Extern_Stat_StorageStatusAbortError(Eval* e, Int f);
Intern_Api Int Intern_Extern_Stat_StorageStatusTimeOutError(Eval* e, Int f);
Intern_Api Int Intern_Extern_Stat_StorageStatusUnspecifiedError(Eval* e, Int f);
Intern_Api Int Intern_Extern_Stat_StorageStatusRemoveError(Eval* e, Int f);
Intern_Api Int Intern_Extern_Stat_StorageStatusRenameError(Eval* e, Int f);
Intern_Api Int Intern_Extern_Stat_StorageStatusPositionError(Eval* e, Int f);
Intern_Api Int Intern_Extern_Stat_StorageStatusResizeError(Eval* e, Int f);
Intern_Api Int Intern_Extern_Stat_StorageStatusPermissionsError(Eval* e, Int f);
Intern_Api Int Intern_Extern_Stat_StorageStatusCopyError(Eval* e, Int f);
Intern_Api Int Intern_Extern_Stat_NetworkCaseUnconnected(Eval* e, Int f);
Intern_Api Int Intern_Extern_Stat_NetworkCaseHostLookup(Eval* e, Int f);
Intern_Api Int Intern_Extern_Stat_NetworkCaseConnecting(Eval* e, Int f);
Intern_Api Int Intern_Extern_Stat_NetworkCaseConnected(Eval* e, Int f);
Intern_Api Int Intern_Extern_Stat_NetworkCaseBound(Eval* e, Int f);
Intern_Api Int Intern_Extern_Stat_NetworkCaseListening(Eval* e, Int f);
Intern_Api Int Intern_Extern_Stat_NetworkCaseClosing(Eval* e, Int f);
Intern_Api Int Intern_Extern_Stat_NetworkPortKindIPv6(Eval* e, Int f);
Intern_Api Int Intern_Extern_Stat_NetworkPortKindIPv4(Eval* e, Int f);
Intern_Api Int Intern_Extern_Stat_NetworkPortKindBroadcast(Eval* e, Int f);
Intern_Api Int Intern_Extern_Stat_NetworkPortKindLocalHost(Eval* e, Int f);
Intern_Api Int Intern_Extern_Stat_NetworkPortKindLocalHostIPv6(Eval* e, Int f);
Intern_Api Int Intern_Extern_Stat_NetworkPortKindAny(Eval* e, Int f);
Intern_Api Int Intern_Extern_Stat_NetworkPortKindAnyIPv6(Eval* e, Int f);
Intern_Api Int Intern_Extern_Stat_NetworkPortKindAnyIPv4(Eval* e, Int f);
Intern_Api Int Intern_Extern_Stat_NetworkStatusNoError(Eval* e, Int f);
Intern_Api Int Intern_Extern_Stat_NetworkStatusConnectionRefusedError(Eval* e, Int f);
Intern_Api Int Intern_Extern_Stat_NetworkStatusRemoteHostClosedError(Eval* e, Int f);
Intern_Api Int Intern_Extern_Stat_NetworkStatusHostNotFoundError(Eval* e, Int f);
Intern_Api Int Intern_Extern_Stat_NetworkStatusSocketAccessError(Eval* e, Int f);
Intern_Api Int Intern_Extern_Stat_NetworkStatusSocketResourceError(Eval* e, Int f);
Intern_Api Int Intern_Extern_Stat_NetworkStatusSocketTimeoutError(Eval* e, Int f);
Intern_Api Int Intern_Extern_Stat_NetworkStatusDatagramTooLargeError(Eval* e, Int f);
Intern_Api Int Intern_Extern_Stat_NetworkStatusNetworkError(Eval* e, Int f);
Intern_Api Int Intern_Extern_Stat_NetworkStatusAddressInUseError(Eval* e, Int f);
Intern_Api Int Intern_Extern_Stat_NetworkStatusSocketAddressNotAvailableError(Eval* e, Int f);
Intern_Api Int Intern_Extern_Stat_NetworkStatusUnsupportedSocketOperationError(Eval* e, Int f);
Intern_Api Int Intern_Extern_Stat_NetworkStatusUnfinishedSocketOperationError(Eval* e, Int f);
Intern_Api Int Intern_Extern_Stat_NetworkStatusProxyAuthenticationRequiredError(Eval* e, Int f);
Intern_Api Int Intern_Extern_Stat_NetworkStatusSslHandshakeFailedError(Eval* e, Int f);
Intern_Api Int Intern_Extern_Stat_NetworkStatusProxyConnectionRefusedError(Eval* e, Int f);
Intern_Api Int Intern_Extern_Stat_NetworkStatusProxyConnectionClosedError(Eval* e, Int f);
Intern_Api Int Intern_Extern_Stat_NetworkStatusProxyConnectionTimeoutError(Eval* e, Int f);
Intern_Api Int Intern_Extern_Stat_NetworkStatusProxyNotFoundError(Eval* e, Int f);
Intern_Api Int Intern_Extern_Stat_NetworkStatusProxyProtocolError(Eval* e, Int f);
Intern_Api Int Intern_Extern_Stat_NetworkStatusOperationError(Eval* e, Int f);
Intern_Api Int Intern_Extern_Stat_NetworkStatusSslInternalError(Eval* e, Int f);
Intern_Api Int Intern_Extern_Stat_NetworkStatusSslInvalidUserDataError(Eval* e, Int f);
Intern_Api Int Intern_Extern_Stat_NetworkStatusTemporaryError(Eval* e, Int f);
Intern_Api Int Intern_Extern_Stat_BrushKindColor(Eval* e, Int f);
Intern_Api Int Intern_Extern_Stat_BrushKindPolate(Eval* e, Int f);
Intern_Api Int Intern_Extern_Stat_BrushKindImage(Eval* e, Int f);
Intern_Api Int Intern_Extern_Stat_SlashLineSolid(Eval* e, Int f);
Intern_Api Int Intern_Extern_Stat_SlashLineDash(Eval* e, Int f);
Intern_Api Int Intern_Extern_Stat_SlashLineDot(Eval* e, Int f);
Intern_Api Int Intern_Extern_Stat_SlashLineDashDot(Eval* e, Int f);
Intern_Api Int Intern_Extern_Stat_SlashLineDashDotDot(Eval* e, Int f);
Intern_Api Int Intern_Extern_Stat_SlashCapePlane(Eval* e, Int f);
Intern_Api Int Intern_Extern_Stat_SlashCapeRight(Eval* e, Int f);
Intern_Api Int Intern_Extern_Stat_SlashCapeRound(Eval* e, Int f);
Intern_Api Int Intern_Extern_Stat_SlashJoinMiter(Eval* e, Int f);
Intern_Api Int Intern_Extern_Stat_SlashJoinBevel(Eval* e, Int f);
Intern_Api Int Intern_Extern_Stat_SlashJoinRound(Eval* e, Int f);
Intern_Api Int Intern_Extern_Stat_PolateKindLinear(Eval* e, Int f);
Intern_Api Int Intern_Extern_Stat_PolateKindRadial(Eval* e, Int f);
Intern_Api Int Intern_Extern_Stat_PolateSpreadClose(Eval* e, Int f);
Intern_Api Int Intern_Extern_Stat_PolateSpreadFlect(Eval* e, Int f);
Intern_Api Int Intern_Extern_Stat_PolateSpreadPeatt(Eval* e, Int f);
Intern_Api Int Intern_Extern_Stat_CompSource(Eval* e, Int f);
Intern_Api Int Intern_Extern_Stat_CompDest(Eval* e, Int f);
Intern_Api Int Intern_Extern_Stat_CompSourceOver(Eval* e, Int f);
Intern_Api Int Intern_Extern_Stat_CompDestOver(Eval* e, Int f);
Intern_Api Int Intern_Extern_Stat_CompSourceInn(Eval* e, Int f);
Intern_Api Int Intern_Extern_Stat_CompDestInn(Eval* e, Int f);
Intern_Api Int Intern_Extern_Stat_CompSourceOut(Eval* e, Int f);
Intern_Api Int Intern_Extern_Stat_CompDestOut(Eval* e, Int f);
Intern_Api Int Intern_Extern_Stat_ImageFormatBmp(Eval* e, Int f);
Intern_Api Int Intern_Extern_Stat_ImageFormatJpg(Eval* e, Int f);
Intern_Api Int Intern_Extern_Stat_ImageFormatPng(Eval* e, Int f);

