class Extern : Any
{
    maide prusate Int New(var Int count) { }
    maide prusate Int Delete(var Int any) { }
    maide prusate Int Copy(var Int dest, var Int source, var Int count) { }
    maide prusate Int Exit(var Int code) { }

    maide prusate Int String_New() { }
    maide prusate Int String_Delete(var Int o) { }
    maide prusate Int String_Init(var Int o) { }
    maide prusate Int String_Final(var Int o) { }
    maide prusate Int String_ValueGet(var Int o) { }
    maide prusate Int String_ValueSet(var Int o, var Int value) { }
    maide prusate Int String_CountGet(var Int o) { }
    maide prusate Int String_CountSet(var Int o, var Int value) { }

    maide prusate Int String_Char(var Int o, var Int index) { }
    maide prusate Int String_Equal(var Int o, var Int other) { }

    maide prusate Int String_ConstantCreate(var Int o) { }
    maide prusate Int String_ConstantDelete(var Int o) { }

    maide prusate Int Console_New() { }
    maide prusate Int Console_Delete(var Int o) { }
    maide prusate Int Console_Init(var Int o) { }
    maide prusate Int Console_Final(var Int o) { }
    maide prusate Int Console_OutWrite(var Int o, var Int text) { }
    maide prusate Int Console_ErrWrite(var Int o, var Int text) { }
    maide prusate Int Console_InnRead(var Int o) { }

    maide prusate Int Array_New() { }
    maide prusate Int Array_Delete(var Int o) { }
    maide prusate Int Array_Init(var Int o) { }
    maide prusate Int Array_Final(var Int o) { }
    maide prusate Int Array_CountGet(var Int o) { }
    maide prusate Int Array_CountSet(var Int o, var Int value) { }

    maide prusate Int Array_ItemGet(var Int o, var Int index) { }
    maide prusate Int Array_ItemSet(var Int o, var Int index, var Int value) { }

    maide prusate Int TextCode_New() { }
    maide prusate Int TextCode_Delete(var Int o) { }
    maide prusate Int TextCode_Init(var Int o) { }
    maide prusate Int TextCode_Final(var Int o) { }
    maide prusate Int TextCode_ExecuteCount(var Int o, var Int innKind, var Int outKind, var Int dataValue, var Int dataCount) { }
    maide prusate Int TextCode_ExecuteResult(var Int o, var Int result, var Int innKind, var Int outKind, var Int dataValue, var Int dataCount) { }

    maide prusate Int Format_New() { }
    maide prusate Int Format_Delete(var Int o) { }
    maide prusate Int Format_Init(var Int o) { }
    maide prusate Int Format_Final(var Int o) { }
    maide prusate Int Format_ExecuteCount(var Int o, var Int varBase, var Int argList) { }
    maide prusate Int Format_ExecuteResult(var Int o, var Int varBase, var Int argList, var Int result) { }
    maide prusate Int Format_ExecuteArgCount(var Int o, var Int arg) { }
    maide prusate Int Format_ExecuteArgResult(var Int o, var Int arg, var Int result) { }

    maide prusate Int FormatArg_New() { }
    maide prusate Int FormatArg_Delete(var Int o) { }
    maide prusate Int FormatArg_Init(var Int o) { }
    maide prusate Int FormatArg_Final(var Int o) { }
    maide prusate Int FormatArg_PosGet(var Int o) { }
    maide prusate Int FormatArg_PosSet(var Int o, var Int value) { }
    maide prusate Int FormatArg_KindGet(var Int o) { }
    maide prusate Int FormatArg_KindSet(var Int o, var Int value) { }
    maide prusate Int FormatArg_ValueGet(var Int o) { }
    maide prusate Int FormatArg_ValueSet(var Int o, var Int value) { }
    maide prusate Int FormatArg_AlignLeftGet(var Int o) { }
    maide prusate Int FormatArg_AlignLeftSet(var Int o, var Int value) { }
    maide prusate Int FormatArg_FieldWidthGet(var Int o) { }
    maide prusate Int FormatArg_FieldWidthSet(var Int o, var Int value) { }
    maide prusate Int FormatArg_MaxWidthGet(var Int o) { }
    maide prusate Int FormatArg_MaxWidthSet(var Int o, var Int value) { }
    maide prusate Int FormatArg_CaseGet(var Int o) { }
    maide prusate Int FormatArg_CaseSet(var Int o, var Int value) { }
    maide prusate Int FormatArg_BaseGet(var Int o) { }
    maide prusate Int FormatArg_BaseSet(var Int o, var Int value) { }
    maide prusate Int FormatArg_SignGet(var Int o) { }
    maide prusate Int FormatArg_SignSet(var Int o, var Int value) { }
    maide prusate Int FormatArg_FillCharGet(var Int o) { }
    maide prusate Int FormatArg_FillCharSet(var Int o, var Int value) { }
    maide prusate Int FormatArg_HasCountGet(var Int o) { }
    maide prusate Int FormatArg_HasCountSet(var Int o, var Int value) { }
    maide prusate Int FormatArg_ValueCountGet(var Int o) { }
    maide prusate Int FormatArg_ValueCountSet(var Int o, var Int value) { }
    maide prusate Int FormatArg_CountGet(var Int o) { }
    maide prusate Int FormatArg_CountSet(var Int o, var Int value) { }

    maide prusate Int Math_New() { }
    maide prusate Int Math_Delete(var Int o) { }
    maide prusate Int Math_Init(var Int o) { }
    maide prusate Int Math_Final(var Int o) { }
    maide prusate Int Math_Value(var Int o, var Int cand, var Int expo) { }
    maide prusate Int Math_ValueTen(var Int o, var Int cand, var Int expoTen) { }
    maide prusate Int Math_Less(var Int o, var Int valueA, var Int valueB) { }
    maide prusate Int Math_Add(var Int o, var Int valueA, var Int valueB) { }
    maide prusate Int Math_Sub(var Int o, var Int valueA, var Int valueB) { }
    maide prusate Int Math_Mul(var Int o, var Int valueA, var Int valueB) { }
    maide prusate Int Math_Div(var Int o, var Int valueA, var Int valueB) { }
    maide prusate Int Math_Abs(var Int o, var Int value) { }
    maide prusate Int Math_Exp(var Int o, var Int value) { }
    maide prusate Int Math_Exp2(var Int o, var Int value) { }
    maide prusate Int Math_Log(var Int o, var Int value) { }
    maide prusate Int Math_Log10(var Int o, var Int value) { }
    maide prusate Int Math_Log2(var Int o, var Int value) { }
    maide prusate Int Math_Pow(var Int o, var Int valueA, var Int valueB) { }
    maide prusate Int Math_Ceil(var Int o, var Int value) { }
    maide prusate Int Math_Floor(var Int o, var Int value) { }
    maide prusate Int Math_Trunc(var Int o, var Int value) { }
    maide prusate Int Math_Round(var Int o, var Int value) { }
    maide prusate Int Math_Sin(var Int o, var Int value) { }
    maide prusate Int Math_Cos(var Int o, var Int value) { }
    maide prusate Int Math_Tan(var Int o, var Int value) { }
    maide prusate Int Math_ASin(var Int o, var Int value) { }
    maide prusate Int Math_ACos(var Int o, var Int value) { }
    maide prusate Int Math_ATan(var Int o, var Int value) { }
    maide prusate Int Math_SinH(var Int o, var Int value) { }
    maide prusate Int Math_CosH(var Int o, var Int value) { }
    maide prusate Int Math_TanH(var Int o, var Int value) { }
    maide prusate Int Math_ASinH(var Int o, var Int value) { }
    maide prusate Int Math_ACosH(var Int o, var Int value) { }
    maide prusate Int Math_ATanH(var Int o, var Int value) { }

    maide prusate Int Rand_New() { }
    maide prusate Int Rand_Delete(var Int o) { }
    maide prusate Int Rand_Init(var Int o) { }
    maide prusate Int Rand_Final(var Int o) { }
    maide prusate Int Rand_SeedGet(var Int o) { }
    maide prusate Int Rand_SeedSet(var Int o, var Int value) { }

    maide prusate Int Rand_Execute(var Int o) { }

    maide prusate Int Range_New() { }
    maide prusate Int Range_Delete(var Int o) { }
    maide prusate Int Range_Init(var Int o) { }
    maide prusate Int Range_Final(var Int o) { }
    maide prusate Int Range_IndexGet(var Int o) { }
    maide prusate Int Range_IndexSet(var Int o, var Int value) { }
    maide prusate Int Range_CountGet(var Int o) { }
    maide prusate Int Range_CountSet(var Int o, var Int value) { }

    maide prusate Int Rect_New() { }
    maide prusate Int Rect_Delete(var Int o) { }
    maide prusate Int Rect_Init(var Int o) { }
    maide prusate Int Rect_Final(var Int o) { }
    maide prusate Int Rect_PosGet(var Int o) { }
    maide prusate Int Rect_PosSet(var Int o, var Int value) { }
    maide prusate Int Rect_SizeGet(var Int o) { }
    maide prusate Int Rect_SizeSet(var Int o, var Int value) { }

    maide prusate Int Pos_New() { }
    maide prusate Int Pos_Delete(var Int o) { }
    maide prusate Int Pos_Init(var Int o) { }
    maide prusate Int Pos_Final(var Int o) { }
    maide prusate Int Pos_ColGet(var Int o) { }
    maide prusate Int Pos_ColSet(var Int o, var Int value) { }
    maide prusate Int Pos_RowGet(var Int o) { }
    maide prusate Int Pos_RowSet(var Int o, var Int value) { }

    maide prusate Int Size_New() { }
    maide prusate Int Size_Delete(var Int o) { }
    maide prusate Int Size_Init(var Int o) { }
    maide prusate Int Size_Final(var Int o) { }
    maide prusate Int Size_WedGet(var Int o) { }
    maide prusate Int Size_WedSet(var Int o, var Int value) { }
    maide prusate Int Size_HetGet(var Int o) { }
    maide prusate Int Size_HetSet(var Int o, var Int value) { }

    maide prusate Int Data_New() { }
    maide prusate Int Data_Delete(var Int o) { }
    maide prusate Int Data_Init(var Int o) { }
    maide prusate Int Data_Final(var Int o) { }
    maide prusate Int Data_CountGet(var Int o) { }
    maide prusate Int Data_CountSet(var Int o, var Int value) { }
    maide prusate Int Data_ValueGet(var Int o) { }
    maide prusate Int Data_ValueSet(var Int o, var Int value) { }

    maide prusate Int Entry_New() { }
    maide prusate Int Entry_Delete(var Int o) { }
    maide prusate Int Entry_Init(var Int o) { }
    maide prusate Int Entry_Final(var Int o) { }
    maide prusate Int Entry_IndexGet(var Int o) { }
    maide prusate Int Entry_IndexSet(var Int o, var Int value) { }
    maide prusate Int Entry_ValueGet(var Int o) { }
    maide prusate Int Entry_ValueSet(var Int o, var Int value) { }

    maide prusate Int State_New() { }
    maide prusate Int State_Delete(var Int o) { }
    maide prusate Int State_Init(var Int o) { }
    maide prusate Int State_Final(var Int o) { }
    maide prusate Int State_MaideGet(var Int o) { }
    maide prusate Int State_MaideSet(var Int o, var Int value) { }
    maide prusate Int State_ArgGet(var Int o) { }
    maide prusate Int State_ArgSet(var Int o, var Int value) { }

    maide prusate Int Main_TerminateStateGet() { }
    maide prusate Int Main_TerminateStateSet(var Int value) { }

    maide prusate Int Main_Init() { }
    maide prusate Int Main_Final() { }
    maide prusate Int Main_IsCSharpSet(var Int value) { }
    maide prusate Int Main_Arg() { }
    maide prusate Int Main_ArgSet(var Int argc, var Int argv) { }

    maide prusate Int Frame_New() { }
    maide prusate Int Frame_Delete(var Int o) { }
    maide prusate Int Frame_Init(var Int o) { }
    maide prusate Int Frame_Final(var Int o) { }
    maide prusate Int Frame_TitleGet(var Int o) { }
    maide prusate Int Frame_TitleSet(var Int o, var Int value) { }
    maide prusate Int Frame_ShownGet(var Int o) { }
    maide prusate Int Frame_ShownSet(var Int o, var Int value) { }
    maide prusate Int Frame_SizeGet(var Int o) { }
    maide prusate Int Frame_SizeSet(var Int o, var Int value) { }
    maide prusate Int Frame_TypeStateGet(var Int o) { }
    maide prusate Int Frame_TypeStateSet(var Int o, var Int value) { }
    maide prusate Int Frame_DrawStateGet(var Int o) { }
    maide prusate Int Frame_DrawStateSet(var Int o, var Int value) { }

    maide prusate Int Frame_TitleThisSet(var Int o) { }
    maide prusate Int Frame_Out(var Int o) { }
    maide prusate Int Frame_Update(var Int o, var Int rect) { }
    maide prusate Int Frame_Close(var Int o) { }

    maide prusate Int Draw_New() { }
    maide prusate Int Draw_Delete(var Int o) { }
    maide prusate Int Draw_Init(var Int o) { }
    maide prusate Int Draw_Final(var Int o) { }
    maide prusate Int Draw_SizeGet(var Int o) { }
    maide prusate Int Draw_SizeSet(var Int o, var Int value) { }
    maide prusate Int Draw_OutGet(var Int o) { }
    maide prusate Int Draw_OutSet(var Int o, var Int value) { }
    maide prusate Int Draw_AreaGet(var Int o) { }
    maide prusate Int Draw_AreaSet(var Int o, var Int value) { }
    maide prusate Int Draw_FillGet(var Int o) { }
    maide prusate Int Draw_FillSet(var Int o, var Int value) { }
    maide prusate Int Draw_FillPosGet(var Int o) { }
    maide prusate Int Draw_FillPosSet(var Int o, var Int value) { }
    maide prusate Int Draw_LineGet(var Int o) { }
    maide prusate Int Draw_LineSet(var Int o, var Int value) { }
    maide prusate Int Draw_FontGet(var Int o) { }
    maide prusate Int Draw_FontSet(var Int o, var Int value) { }
    maide prusate Int Draw_FormGet(var Int o) { }
    maide prusate Int Draw_FormSet(var Int o, var Int value) { }
    maide prusate Int Draw_CompGet(var Int o) { }
    maide prusate Int Draw_CompSet(var Int o, var Int value) { }

    maide prusate Int Draw_Start(var Int o) { }
    maide prusate Int Draw_End(var Int o) { }
    maide prusate Int Draw_FillPosThisSet(var Int o) { }
    maide prusate Int Draw_AreaThisSet(var Int o) { }
    maide prusate Int Draw_Clear(var Int o, var Int color) { }
    maide prusate Int Draw_ExecuteRect(var Int o, var Int rect) { }
    maide prusate Int Draw_ExecuteRectRound(var Int o, var Int rect, var Int colRadius, var Int rowRadius) { }
    maide prusate Int Draw_ExecuteRound(var Int o, var Int rect) { }
    maide prusate Int Draw_ExecuteRoundLine(var Int o, var Int rect, var Int range) { }
    maide prusate Int Draw_ExecuteRoundPart(var Int o, var Int rect, var Int range) { }
    maide prusate Int Draw_ExecuteRoundShape(var Int o, var Int rect, var Int range) { }
    maide prusate Int Draw_ExecuteLine(var Int o, var Int startPos, var Int endPos) { }
    maide prusate Int Draw_ExecuteShape(var Int o, var Int pointListCount, var Int pointListData) { }
    maide prusate Int Draw_ExecuteShapeLine(var Int o, var Int pointListCount, var Int pointListData) { }
    maide prusate Int Draw_ExecuteImage(var Int o, var Int image, var Int destRect, var Int sourceRect) { }
    maide prusate Int Draw_ExecuteText(var Int o, var Int text, var Int colAlign, var Int rowAlign, var Int wordWrap, var Int destRect, var Int boundRect) { }

    maide prusate Int Brush_New() { }
    maide prusate Int Brush_Delete(var Int o) { }
    maide prusate Int Brush_Init(var Int o) { }
    maide prusate Int Brush_Final(var Int o) { }
    maide prusate Int Brush_KindGet(var Int o) { }
    maide prusate Int Brush_KindSet(var Int o, var Int value) { }
    maide prusate Int Brush_ColorGet(var Int o) { }
    maide prusate Int Brush_ColorSet(var Int o, var Int value) { }
    maide prusate Int Brush_PolateGet(var Int o) { }
    maide prusate Int Brush_PolateSet(var Int o, var Int value) { }
    maide prusate Int Brush_ImageGet(var Int o) { }
    maide prusate Int Brush_ImageSet(var Int o, var Int value) { }

    maide prusate Int Slash_New() { }
    maide prusate Int Slash_Delete(var Int o) { }
    maide prusate Int Slash_Init(var Int o) { }
    maide prusate Int Slash_Final(var Int o) { }
    maide prusate Int Slash_BrushGet(var Int o) { }
    maide prusate Int Slash_BrushSet(var Int o, var Int value) { }
    maide prusate Int Slash_LineGet(var Int o) { }
    maide prusate Int Slash_LineSet(var Int o, var Int value) { }
    maide prusate Int Slash_SizeGet(var Int o) { }
    maide prusate Int Slash_SizeSet(var Int o, var Int value) { }
    maide prusate Int Slash_CapeGet(var Int o) { }
    maide prusate Int Slash_CapeSet(var Int o, var Int value) { }
    maide prusate Int Slash_JoinGet(var Int o) { }
    maide prusate Int Slash_JoinSet(var Int o, var Int value) { }

    maide prusate Int PointData_PointGet(var Int memory, var Int result) { }
    maide prusate Int PointData_PointSet(var Int memory, var Int pos) { }

    maide prusate Int Image_New() { }
    maide prusate Int Image_Delete(var Int o) { }
    maide prusate Int Image_Init(var Int o) { }
    maide prusate Int Image_Final(var Int o) { }
    maide prusate Int Image_SizeGet(var Int o) { }
    maide prusate Int Image_SizeSet(var Int o, var Int value) { }
    maide prusate Int Image_DataGet(var Int o) { }
    maide prusate Int Image_DataSet(var Int o, var Int value) { }

    maide prusate Int Image_Out(var Int o) { }
    maide prusate Int Image_DataCreate(var Int o) { }

    maide prusate Int Font_New() { }
    maide prusate Int Font_Delete(var Int o) { }
    maide prusate Int Font_Init(var Int o) { }
    maide prusate Int Font_Final(var Int o) { }
    maide prusate Int Font_NameGet(var Int o) { }
    maide prusate Int Font_NameSet(var Int o, var Int value) { }
    maide prusate Int Font_SizeGet(var Int o) { }
    maide prusate Int Font_SizeSet(var Int o, var Int value) { }
    maide prusate Int Font_StrongGet(var Int o) { }
    maide prusate Int Font_StrongSet(var Int o, var Int value) { }
    maide prusate Int Font_TendenGet(var Int o) { }
    maide prusate Int Font_TendenSet(var Int o, var Int value) { }
    maide prusate Int Font_StalineGet(var Int o) { }
    maide prusate Int Font_StalineSet(var Int o, var Int value) { }
    maide prusate Int Font_MidlineGet(var Int o) { }
    maide prusate Int Font_MidlineSet(var Int o, var Int value) { }
    maide prusate Int Font_EndlineGet(var Int o) { }
    maide prusate Int Font_EndlineSet(var Int o, var Int value) { }

    maide prusate Int Form_New() { }
    maide prusate Int Form_Delete(var Int o) { }
    maide prusate Int Form_Init(var Int o) { }
    maide prusate Int Form_Final(var Int o) { }
    maide prusate Int Form_Reset(var Int o) { }
    maide prusate Int Form_Pos(var Int o, var Int col, var Int row) { }
    maide prusate Int Form_Angle(var Int o, var Int angle) { }
    maide prusate Int Form_Scale(var Int o, var Int colScale, var Int rowScale) { }
    maide prusate Int Form_ValueGet(var Int o, var Int col, var Int row) { }
    maide prusate Int Form_ValueSet(var Int o, var Int col, var Int row, var Int value) { }
    maide prusate Int Form_Mul(var Int o, var Int other) { }
    maide prusate Int Form_Ident(var Int o) { }
    maide prusate Int Form_IsInvertible(var Int o) { }
    maide prusate Int Form_Invert(var Int o, var Int result) { }
    maide prusate Int Form_Transpose(var Int o, var Int result) { }

    maide prusate Int Polate_New() { }
    maide prusate Int Polate_Delete(var Int o) { }
    maide prusate Int Polate_Init(var Int o) { }
    maide prusate Int Polate_Final(var Int o) { }
    maide prusate Int Polate_KindGet(var Int o) { }
    maide prusate Int Polate_KindSet(var Int o, var Int value) { }
    maide prusate Int Polate_ValueGet(var Int o) { }
    maide prusate Int Polate_ValueSet(var Int o, var Int value) { }
    maide prusate Int Polate_StopGet(var Int o) { }
    maide prusate Int Polate_StopSet(var Int o, var Int value) { }
    maide prusate Int Polate_SpreadGet(var Int o) { }
    maide prusate Int Polate_SpreadSet(var Int o, var Int value) { }

    maide prusate Int PolateLinear_New() { }
    maide prusate Int PolateLinear_Delete(var Int o) { }
    maide prusate Int PolateLinear_Init(var Int o) { }
    maide prusate Int PolateLinear_Final(var Int o) { }
    maide prusate Int PolateLinear_StartPosGet(var Int o) { }
    maide prusate Int PolateLinear_StartPosSet(var Int o, var Int value) { }
    maide prusate Int PolateLinear_EndPosGet(var Int o) { }
    maide prusate Int PolateLinear_EndPosSet(var Int o, var Int value) { }

    maide prusate Int PolateRadial_New() { }
    maide prusate Int PolateRadial_Delete(var Int o) { }
    maide prusate Int PolateRadial_Init(var Int o) { }
    maide prusate Int PolateRadial_Final(var Int o) { }
    maide prusate Int PolateRadial_CenterPosGet(var Int o) { }
    maide prusate Int PolateRadial_CenterPosSet(var Int o, var Int value) { }
    maide prusate Int PolateRadial_CenterRadiusGet(var Int o) { }
    maide prusate Int PolateRadial_CenterRadiusSet(var Int o, var Int value) { }
    maide prusate Int PolateRadial_FocusPosGet(var Int o) { }
    maide prusate Int PolateRadial_FocusPosSet(var Int o, var Int value) { }
    maide prusate Int PolateRadial_FocusRadiusGet(var Int o) { }
    maide prusate Int PolateRadial_FocusRadiusSet(var Int o, var Int value) { }

    maide prusate Int PolateStop_New() { }
    maide prusate Int PolateStop_Delete(var Int o) { }
    maide prusate Int PolateStop_Init(var Int o) { }
    maide prusate Int PolateStop_Final(var Int o) { }
    maide prusate Int PolateStop_CountGet(var Int o) { }
    maide prusate Int PolateStop_CountSet(var Int o, var Int value) { }

    maide prusate Int PolateStop_PointGetPos(var Int o, var Int index) { }
    maide prusate Int PolateStop_PointGetColor(var Int o, var Int index) { }
    maide prusate Int PolateStop_PointSet(var Int o, var Int index, var Int pos, var Int color) { }

    maide prusate Int ImageRead_New() { }
    maide prusate Int ImageRead_Delete(var Int o) { }
    maide prusate Int ImageRead_Init(var Int o) { }
    maide prusate Int ImageRead_Final(var Int o) { }
    maide prusate Int ImageRead_StreamGet(var Int o) { }
    maide prusate Int ImageRead_StreamSet(var Int o, var Int value) { }
    maide prusate Int ImageRead_ImageGet(var Int o) { }
    maide prusate Int ImageRead_ImageSet(var Int o, var Int value) { }

    maide prusate Int ImageRead_Execute(var Int o) { }

    maide prusate Int ImageWrite_New() { }
    maide prusate Int ImageWrite_Delete(var Int o) { }
    maide prusate Int ImageWrite_Init(var Int o) { }
    maide prusate Int ImageWrite_Final(var Int o) { }
    maide prusate Int ImageWrite_StreamGet(var Int o) { }
    maide prusate Int ImageWrite_StreamSet(var Int o, var Int value) { }
    maide prusate Int ImageWrite_ImageGet(var Int o) { }
    maide prusate Int ImageWrite_ImageSet(var Int o, var Int value) { }
    maide prusate Int ImageWrite_FormatGet(var Int o) { }
    maide prusate Int ImageWrite_FormatSet(var Int o, var Int value) { }

    maide prusate Int ImageWrite_Execute(var Int o) { }

    maide prusate Int FontStore_New() { }
    maide prusate Int FontStore_Delete(var Int o) { }
    maide prusate Int FontStore_Init(var Int o) { }
    maide prusate Int FontStore_Final(var Int o) { }
    maide prusate Int FontStore_Add(var Int o, var Int data) { }
    maide prusate Int FontStore_Rem(var Int o, var Int ident) { }
    maide prusate Int FontStore_NameList(var Int o) { }
    maide prusate Int FontStore_NameListIdent(var Int o, var Int ident) { }

    maide prusate Int VideoOut_New() { }
    maide prusate Int VideoOut_Delete(var Int o) { }
    maide prusate Int VideoOut_Init(var Int o) { }
    maide prusate Int VideoOut_Final(var Int o) { }
    maide prusate Int VideoOut_FrameGet(var Int o) { }
    maide prusate Int VideoOut_FrameSet(var Int o, var Int value) { }
    maide prusate Int VideoOut_FrameEventStateGet(var Int o) { }
    maide prusate Int VideoOut_FrameEventStateSet(var Int o, var Int value) { }

    maide prusate Int VideoFrame_New() { }
    maide prusate Int VideoFrame_Delete(var Int o) { }
    maide prusate Int VideoFrame_Init(var Int o) { }
    maide prusate Int VideoFrame_Final(var Int o) { }
    maide prusate Int VideoFrame_SizeGet(var Int o) { }
    maide prusate Int VideoFrame_SizeSet(var Int o, var Int value) { }

    maide prusate Int VideoFrame_Image(var Int o, var Int image) { }

    maide prusate Int AudioOut_New() { }
    maide prusate Int AudioOut_Delete(var Int o) { }
    maide prusate Int AudioOut_Init(var Int o) { }
    maide prusate Int AudioOut_Final(var Int o) { }
    maide prusate Int AudioOut_MuteGet(var Int o) { }
    maide prusate Int AudioOut_MuteSet(var Int o, var Int value) { }
    maide prusate Int AudioOut_VolumeGet(var Int o) { }
    maide prusate Int AudioOut_VolumeSet(var Int o, var Int value) { }

    maide prusate Int Play_New() { }
    maide prusate Int Play_Delete(var Int o) { }
    maide prusate Int Play_Init(var Int o) { }
    maide prusate Int Play_Final(var Int o) { }
    maide prusate Int Play_SourceGet(var Int o) { }
    maide prusate Int Play_SourceSet(var Int o, var Int value) { }
    maide prusate Int Play_VideoOutGet(var Int o) { }
    maide prusate Int Play_VideoOutSet(var Int o, var Int value) { }
    maide prusate Int Play_AudioOutGet(var Int o) { }
    maide prusate Int Play_AudioOutSet(var Int o, var Int value) { }
    maide prusate Int Play_TimeGet(var Int o) { }
    maide prusate Int Play_TimeSet(var Int o, var Int value) { }
    maide prusate Int Play_PosGet(var Int o) { }
    maide prusate Int Play_PosSet(var Int o, var Int value) { }

    maide prusate Int Play_SourceThisSet(var Int o) { }
    maide prusate Int Play_HasVideo(var Int o) { }
    maide prusate Int Play_HasAudio(var Int o) { }
    maide prusate Int Play_Execute(var Int o) { }
    maide prusate Int Play_Pause(var Int o) { }
    maide prusate Int Play_Stop(var Int o) { }

    maide prusate Int Stream_New() { }
    maide prusate Int Stream_Delete(var Int o) { }
    maide prusate Int Stream_Init(var Int o) { }
    maide prusate Int Stream_Final(var Int o) { }
    maide prusate Int Stream_KindGet(var Int o) { }
    maide prusate Int Stream_KindSet(var Int o, var Int value) { }
    maide prusate Int Stream_StatusGet(var Int o) { }
    maide prusate Int Stream_StatusSet(var Int o, var Int value) { }

    maide prusate Int Stream_CountGet(var Int o) { }
    maide prusate Int Stream_PosGet(var Int o) { }
    maide prusate Int Stream_PosSet(var Int o, var Int value) { }
    maide prusate Int Stream_HasCount(var Int o) { }
    maide prusate Int Stream_HasPos(var Int o) { }
    maide prusate Int Stream_CanRead(var Int o) { }
    maide prusate Int Stream_CanWrite(var Int o) { }
    maide prusate Int Stream_Read(var Int o, var Int data, var Int range) { }
    maide prusate Int Stream_Write(var Int o, var Int data, var Int range) { }

    maide prusate Int Memory_New() { }
    maide prusate Int Memory_Delete(var Int o) { }
    maide prusate Int Memory_Init(var Int o) { }
    maide prusate Int Memory_Final(var Int o) { }
    maide prusate Int Memory_StreamGet(var Int o) { }
    maide prusate Int Memory_StreamSet(var Int o, var Int value) { }

    maide prusate Int Memory_Open(var Int o) { }
    maide prusate Int Memory_Close(var Int o) { }

    maide prusate Int Storage_New() { }
    maide prusate Int Storage_Delete(var Int o) { }
    maide prusate Int Storage_Init(var Int o) { }
    maide prusate Int Storage_Final(var Int o) { }
    maide prusate Int Storage_PathGet(var Int o) { }
    maide prusate Int Storage_PathSet(var Int o, var Int value) { }
    maide prusate Int Storage_ModeGet(var Int o) { }
    maide prusate Int Storage_ModeSet(var Int o, var Int value) { }
    maide prusate Int Storage_StreamGet(var Int o) { }
    maide prusate Int Storage_StreamSet(var Int o, var Int value) { }
    maide prusate Int Storage_StatusGet(var Int o) { }
    maide prusate Int Storage_StatusSet(var Int o, var Int value) { }

    maide prusate Int Storage_CountSet(var Int o, var Int value) { }
    maide prusate Int Storage_Open(var Int o) { }
    maide prusate Int Storage_Close(var Int o) { }

    maide prusate Int StorageComp_New() { }
    maide prusate Int StorageComp_Delete(var Int o) { }
    maide prusate Int StorageComp_Init(var Int o) { }
    maide prusate Int StorageComp_Final(var Int o) { }
    maide prusate Int StorageComp_Rename(var Int o, var Int path, var Int destPath) { }
    maide prusate Int StorageComp_FileCopy(var Int o, var Int path, var Int destPath) { }
    maide prusate Int StorageComp_FileDelete(var Int o, var Int path) { }
    maide prusate Int StorageComp_FoldCreate(var Int o, var Int path) { }
    maide prusate Int StorageComp_FoldCopy(var Int o, var Int path, var Int destPath) { }
    maide prusate Int StorageComp_FoldDelete(var Int o, var Int path) { }
    maide prusate Int StorageComp_Exist(var Int o, var Int path) { }
    maide prusate Int StorageComp_Fold(var Int o, var Int path) { }
    maide prusate Int StorageComp_EntryList(var Int o, var Int path, var Int fold) { }
    maide prusate Int StorageComp_ThisFoldGet(var Int o) { }
    maide prusate Int StorageComp_ThisFoldSet(var Int o, var Int path) { }

    maide prusate Int Network_New() { }
    maide prusate Int Network_Delete(var Int o) { }
    maide prusate Int Network_Init(var Int o) { }
    maide prusate Int Network_Final(var Int o) { }
    maide prusate Int Network_HostNameGet(var Int o) { }
    maide prusate Int Network_HostNameSet(var Int o, var Int value) { }
    maide prusate Int Network_HostPortGet(var Int o) { }
    maide prusate Int Network_HostPortSet(var Int o, var Int value) { }
    maide prusate Int Network_StreamGet(var Int o) { }
    maide prusate Int Network_StreamSet(var Int o, var Int value) { }
    maide prusate Int Network_ReadyCountGet(var Int o) { }
    maide prusate Int Network_ReadyCountSet(var Int o, var Int value) { }
    maide prusate Int Network_StatusGet(var Int o) { }
    maide prusate Int Network_StatusSet(var Int o, var Int value) { }
    maide prusate Int Network_CaseGet(var Int o) { }
    maide prusate Int Network_CaseSet(var Int o, var Int value) { }
    maide prusate Int Network_StatusEventStateGet(var Int o) { }
    maide prusate Int Network_StatusEventStateSet(var Int o, var Int value) { }
    maide prusate Int Network_CaseEventStateGet(var Int o) { }
    maide prusate Int Network_CaseEventStateSet(var Int o, var Int value) { }
    maide prusate Int Network_DataEventStateGet(var Int o) { }
    maide prusate Int Network_DataEventStateSet(var Int o, var Int value) { }

    maide prusate Int Network_Open(var Int o) { }
    maide prusate Int Network_Close(var Int o) { }

    maide prusate Int NetworkHost_New() { }
    maide prusate Int NetworkHost_Delete(var Int o) { }
    maide prusate Int NetworkHost_Init(var Int o) { }
    maide prusate Int NetworkHost_Final(var Int o) { }
    maide prusate Int NetworkHost_PortGet(var Int o) { }
    maide prusate Int NetworkHost_PortSet(var Int o, var Int value) { }
    maide prusate Int NetworkHost_NewPeerStateGet(var Int o) { }
    maide prusate Int NetworkHost_NewPeerStateSet(var Int o, var Int value) { }

    maide prusate Int NetworkHost_Open(var Int o) { }
    maide prusate Int NetworkHost_Close(var Int o) { }
    maide prusate Int NetworkHost_OpenPeer(var Int o) { }
    maide prusate Int NetworkHost_ClosePeer(var Int o, var Int network) { }

    maide prusate Int NetworkPort_New() { }
    maide prusate Int NetworkPort_Delete(var Int o) { }
    maide prusate Int NetworkPort_Init(var Int o) { }
    maide prusate Int NetworkPort_Final(var Int o) { }
    maide prusate Int NetworkPort_KindGet(var Int o) { }
    maide prusate Int NetworkPort_KindSet(var Int o, var Int value) { }
    maide prusate Int NetworkPort_ValueAGet(var Int o) { }
    maide prusate Int NetworkPort_ValueASet(var Int o, var Int value) { }
    maide prusate Int NetworkPort_ValueBGet(var Int o) { }
    maide prusate Int NetworkPort_ValueBSet(var Int o, var Int value) { }
    maide prusate Int NetworkPort_ValueCGet(var Int o) { }
    maide prusate Int NetworkPort_ValueCSet(var Int o, var Int value) { }
    maide prusate Int NetworkPort_HostGet(var Int o) { }
    maide prusate Int NetworkPort_HostSet(var Int o, var Int value) { }

    maide prusate Int NetworkPort_Set(var Int o) { }

    maide prusate Int Thread_New() { }
    maide prusate Int Thread_Delete(var Int o) { }
    maide prusate Int Thread_Init(var Int o) { }
    maide prusate Int Thread_Final(var Int o) { }
    maide prusate Int Thread_IdentGet(var Int o) { }
    maide prusate Int Thread_IdentSet(var Int o, var Int value) { }
    maide prusate Int Thread_ExecuteStateGet(var Int o) { }
    maide prusate Int Thread_ExecuteStateSet(var Int o, var Int value) { }
    maide prusate Int Thread_StatusGet(var Int o) { }
    maide prusate Int Thread_StatusSet(var Int o, var Int value) { }
    maide prusate Int Thread_CaseGet(var Int o) { }
    maide prusate Int Thread_CaseSet(var Int o, var Int value) { }

    maide prusate Int Thread_Execute(var Int o) { }
    maide prusate Int Thread_Pause(var Int o) { }
    maide prusate Int Thread_Resume(var Int o) { }
    maide prusate Int Thread_Wait(var Int o) { }
    maide prusate Int Thread_ExecuteMain(var Int o) { }
    maide prusate Int Thread_Exit(var Int o, var Int status) { }

    maide prusate Int Thread_This() { }

    maide prusate Int Phore_New() { }
    maide prusate Int Phore_Delete(var Int o) { }
    maide prusate Int Phore_Init(var Int o) { }
    maide prusate Int Phore_Final(var Int o) { }
    maide prusate Int Phore_CountGet(var Int o) { }
    maide prusate Int Phore_CountSet(var Int o, var Int value) { }
    maide prusate Int Phore_InitCountGet(var Int o) { }
    maide prusate Int Phore_InitCountSet(var Int o, var Int value) { }

    maide prusate Int Phore_Open(var Int o) { }
    maide prusate Int Phore_Close(var Int o) { }

    maide prusate Int Time_New() { }
    maide prusate Int Time_Delete(var Int o) { }
    maide prusate Int Time_Init(var Int o) { }
    maide prusate Int Time_Final(var Int o) { }
    maide prusate Int Time_YeaGet(var Int o) { }
    maide prusate Int Time_YeaSet(var Int o, var Int value) { }
    maide prusate Int Time_MonGet(var Int o) { }
    maide prusate Int Time_MonSet(var Int o, var Int value) { }
    maide prusate Int Time_DayGet(var Int o) { }
    maide prusate Int Time_DaySet(var Int o, var Int value) { }
    maide prusate Int Time_OurGet(var Int o) { }
    maide prusate Int Time_OurSet(var Int o, var Int value) { }
    maide prusate Int Time_MinGet(var Int o) { }
    maide prusate Int Time_MinSet(var Int o, var Int value) { }
    maide prusate Int Time_SecGet(var Int o) { }
    maide prusate Int Time_SecSet(var Int o, var Int value) { }
    maide prusate Int Time_TickGet(var Int o) { }
    maide prusate Int Time_TickSet(var Int o, var Int value) { }
    maide prusate Int Time_PosGet(var Int o) { }
    maide prusate Int Time_PosSet(var Int o, var Int value) { }
    maide prusate Int Time_YeaDayGet(var Int o) { }
    maide prusate Int Time_YeaDaySet(var Int o, var Int value) { }
    maide prusate Int Time_WeekDayGet(var Int o) { }
    maide prusate Int Time_WeekDaySet(var Int o, var Int value) { }
    maide prusate Int Time_YeaDayCountGet(var Int o) { }
    maide prusate Int Time_YeaDayCountSet(var Int o, var Int value) { }
    maide prusate Int Time_MonDayCountGet(var Int o) { }
    maide prusate Int Time_MonDayCountSet(var Int o, var Int value) { }
    maide prusate Int Time_TotalTickGet(var Int o) { }
    maide prusate Int Time_TotalTickSet(var Int o, var Int value) { }

    maide prusate Int Time_AddYea(var Int o, var Int value) { }
    maide prusate Int Time_AddMon(var Int o, var Int value) { }
    maide prusate Int Time_AddDay(var Int o, var Int value) { }
    maide prusate Int Time_AddTick(var Int o, var Int value) { }
    maide prusate Int Time_This(var Int o) { }
    maide prusate Int Time_ToPos(var Int o, var Int pos) { }
    maide prusate Int Time_Set(var Int o, var Int yea, var Int mon, var Int day, var Int our, var Int min, var Int sec, var Int tick, var Int pos) { }

    maide prusate Int Time_LeapYea(var Int yea) { }
    maide prusate Int Time_ValidDate(var Int yea, var Int mon, var Int day) { }
    maide prusate Int Time_ValidTime(var Int our, var Int min, var Int sec, var Int tick) { }

    maide prusate Int TimeEvent_New() { }
    maide prusate Int TimeEvent_Delete(var Int o) { }
    maide prusate Int TimeEvent_Init(var Int o) { }
    maide prusate Int TimeEvent_Final(var Int o) { }
    maide prusate Int TimeEvent_TimeGet(var Int o) { }
    maide prusate Int TimeEvent_TimeSet(var Int o, var Int value) { }
    maide prusate Int TimeEvent_SingleGet(var Int o) { }
    maide prusate Int TimeEvent_SingleSet(var Int o, var Int value) { }
    maide prusate Int TimeEvent_ActiveGet(var Int o) { }
    maide prusate Int TimeEvent_ActiveSet(var Int o, var Int value) { }
    maide prusate Int TimeEvent_ElapseStateGet(var Int o) { }
    maide prusate Int TimeEvent_ElapseStateSet(var Int o, var Int value) { }

    maide prusate Int TimeEvent_Start(var Int o) { }
    maide prusate Int TimeEvent_Stop(var Int o) { }

    maide prusate Int Program_New() { }
    maide prusate Int Program_Delete(var Int o) { }
    maide prusate Int Program_Init(var Int o) { }
    maide prusate Int Program_Final(var Int o) { }
    maide prusate Int Program_NameGet(var Int o) { }
    maide prusate Int Program_NameSet(var Int o, var Int value) { }
    maide prusate Int Program_ArgueGet(var Int o) { }
    maide prusate Int Program_ArgueSet(var Int o, var Int value) { }
    maide prusate Int Program_WorkFoldGet(var Int o) { }
    maide prusate Int Program_WorkFoldSet(var Int o, var Int value) { }
    maide prusate Int Program_EnvironGet(var Int o) { }
    maide prusate Int Program_EnvironSet(var Int o, var Int value) { }
    maide prusate Int Program_IdentGet(var Int o) { }
    maide prusate Int Program_IdentSet(var Int o, var Int value) { }
    maide prusate Int Program_StatusGet(var Int o) { }
    maide prusate Int Program_StatusSet(var Int o, var Int value) { }

    maide prusate Int Program_Execute(var Int o) { }
    maide prusate Int Program_Wait(var Int o) { }
    maide prusate Int Program_Exit(var Int o) { }

    maide prusate Int Infra_Share() { }

    maide prusate Int Share_Stat(var Int o) { }

    maide prusate Int Stat_PointDataCount(var Int o) { }
    maide prusate Int Stat_TextAlignStart(var Int o) { }
    maide prusate Int Stat_TextAlignMid(var Int o) { }
    maide prusate Int Stat_TextAlignEnd(var Int o) { }
    maide prusate Int Stat_TextCodeKindUtf8(var Int o) { }
    maide prusate Int Stat_TextCodeKindUtf16(var Int o) { }
    maide prusate Int Stat_TextCodeKindUtf32(var Int o) { }
    maide prusate Int Stat_ThreadCaseReady(var Int o) { }
    maide prusate Int Stat_ThreadCaseExecute(var Int o) { }
    maide prusate Int Stat_ThreadCasePause(var Int o) { }
    maide prusate Int Stat_ThreadCaseFinish(var Int o) { }
    maide prusate Int Stat_ThreadCaseTerminate(var Int o) { }
    maide prusate Int Stat_StreamKindMemory(var Int o) { }
    maide prusate Int Stat_StreamKindStorage(var Int o) { }
    maide prusate Int Stat_StreamKindNetwork(var Int o) { }
    maide prusate Int Stat_StorageModeRead(var Int o) { }
    maide prusate Int Stat_StorageModeWrite(var Int o) { }
    maide prusate Int Stat_StorageModeNew(var Int o) { }
    maide prusate Int Stat_StorageModeExist(var Int o) { }
    maide prusate Int Stat_StorageStatusNoError(var Int o) { }
    maide prusate Int Stat_StorageStatusReadError(var Int o) { }
    maide prusate Int Stat_StorageStatusWriteError(var Int o) { }
    maide prusate Int Stat_StorageStatusFatalError(var Int o) { }
    maide prusate Int Stat_StorageStatusResourceError(var Int o) { }
    maide prusate Int Stat_StorageStatusOpenError(var Int o) { }
    maide prusate Int Stat_StorageStatusAbortError(var Int o) { }
    maide prusate Int Stat_StorageStatusTimeOutError(var Int o) { }
    maide prusate Int Stat_StorageStatusUnspecifiedError(var Int o) { }
    maide prusate Int Stat_StorageStatusRemoveError(var Int o) { }
    maide prusate Int Stat_StorageStatusRenameError(var Int o) { }
    maide prusate Int Stat_StorageStatusPositionError(var Int o) { }
    maide prusate Int Stat_StorageStatusResizeError(var Int o) { }
    maide prusate Int Stat_StorageStatusPermissionsError(var Int o) { }
    maide prusate Int Stat_StorageStatusCopyError(var Int o) { }
    maide prusate Int Stat_NetworkCaseUnconnected(var Int o) { }
    maide prusate Int Stat_NetworkCaseHostLookup(var Int o) { }
    maide prusate Int Stat_NetworkCaseConnecting(var Int o) { }
    maide prusate Int Stat_NetworkCaseConnected(var Int o) { }
    maide prusate Int Stat_NetworkCaseBound(var Int o) { }
    maide prusate Int Stat_NetworkCaseListening(var Int o) { }
    maide prusate Int Stat_NetworkCaseClosing(var Int o) { }
    maide prusate Int Stat_NetworkPortKindIPv6(var Int o) { }
    maide prusate Int Stat_NetworkPortKindIPv4(var Int o) { }
    maide prusate Int Stat_NetworkPortKindBroadcast(var Int o) { }
    maide prusate Int Stat_NetworkPortKindLocalHost(var Int o) { }
    maide prusate Int Stat_NetworkPortKindLocalHostIPv6(var Int o) { }
    maide prusate Int Stat_NetworkPortKindAny(var Int o) { }
    maide prusate Int Stat_NetworkPortKindAnyIPv6(var Int o) { }
    maide prusate Int Stat_NetworkPortKindAnyIPv4(var Int o) { }
    maide prusate Int Stat_NetworkStatusNoError(var Int o) { }
    maide prusate Int Stat_NetworkStatusConnectionRefusedError(var Int o) { }
    maide prusate Int Stat_NetworkStatusRemoteHostClosedError(var Int o) { }
    maide prusate Int Stat_NetworkStatusHostNotFoundError(var Int o) { }
    maide prusate Int Stat_NetworkStatusSocketAccessError(var Int o) { }
    maide prusate Int Stat_NetworkStatusSocketResourceError(var Int o) { }
    maide prusate Int Stat_NetworkStatusSocketTimeoutError(var Int o) { }
    maide prusate Int Stat_NetworkStatusDatagramTooLargeError(var Int o) { }
    maide prusate Int Stat_NetworkStatusNetworkError(var Int o) { }
    maide prusate Int Stat_NetworkStatusAddressInUseError(var Int o) { }
    maide prusate Int Stat_NetworkStatusSocketAddressNotAvailableError(var Int o) { }
    maide prusate Int Stat_NetworkStatusUnsupportedSocketOperationError(var Int o) { }
    maide prusate Int Stat_NetworkStatusUnfinishedSocketOperationError(var Int o) { }
    maide prusate Int Stat_NetworkStatusProxyAuthenticationRequiredError(var Int o) { }
    maide prusate Int Stat_NetworkStatusSslHandshakeFailedError(var Int o) { }
    maide prusate Int Stat_NetworkStatusProxyConnectionRefusedError(var Int o) { }
    maide prusate Int Stat_NetworkStatusProxyConnectionClosedError(var Int o) { }
    maide prusate Int Stat_NetworkStatusProxyConnectionTimeoutError(var Int o) { }
    maide prusate Int Stat_NetworkStatusProxyNotFoundError(var Int o) { }
    maide prusate Int Stat_NetworkStatusProxyProtocolError(var Int o) { }
    maide prusate Int Stat_NetworkStatusOperationError(var Int o) { }
    maide prusate Int Stat_NetworkStatusSslInternalError(var Int o) { }
    maide prusate Int Stat_NetworkStatusSslInvalidUserDataError(var Int o) { }
    maide prusate Int Stat_NetworkStatusTemporaryError(var Int o) { }
    maide prusate Int Stat_BrushKindColor(var Int o) { }
    maide prusate Int Stat_BrushKindPolate(var Int o) { }
    maide prusate Int Stat_BrushKindImage(var Int o) { }
    maide prusate Int Stat_SlashLineSolid(var Int o) { }
    maide prusate Int Stat_SlashLineDash(var Int o) { }
    maide prusate Int Stat_SlashLineDot(var Int o) { }
    maide prusate Int Stat_SlashLineDashDot(var Int o) { }
    maide prusate Int Stat_SlashLineDashDotDot(var Int o) { }
    maide prusate Int Stat_SlashCapePlane(var Int o) { }
    maide prusate Int Stat_SlashCapeRight(var Int o) { }
    maide prusate Int Stat_SlashCapeRound(var Int o) { }
    maide prusate Int Stat_SlashJoinMiter(var Int o) { }
    maide prusate Int Stat_SlashJoinBevel(var Int o) { }
    maide prusate Int Stat_SlashJoinRound(var Int o) { }
    maide prusate Int Stat_PolateKindLinear(var Int o) { }
    maide prusate Int Stat_PolateKindRadial(var Int o) { }
    maide prusate Int Stat_PolateSpreadClose(var Int o) { }
    maide prusate Int Stat_PolateSpreadFlect(var Int o) { }
    maide prusate Int Stat_PolateSpreadPeatt(var Int o) { }
    maide prusate Int Stat_CompSource(var Int o) { }
    maide prusate Int Stat_CompDest(var Int o) { }
    maide prusate Int Stat_CompSourceOver(var Int o) { }
    maide prusate Int Stat_CompDestOver(var Int o) { }
    maide prusate Int Stat_CompSourceInn(var Int o) { }
    maide prusate Int Stat_CompDestInn(var Int o) { }
    maide prusate Int Stat_CompSourceOut(var Int o) { }
    maide prusate Int Stat_CompDestOut(var Int o) { }
    maide prusate Int Stat_ImageFormatBmp(var Int o) { }
    maide prusate Int Stat_ImageFormatJpg(var Int o) { }
    maide prusate Int Stat_ImageFormatPng(var Int o) { }

}