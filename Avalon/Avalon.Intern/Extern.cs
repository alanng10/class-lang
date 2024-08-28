namespace Avalon.Intern;

public static class Extern
{
    const string InfraLib = ExternConstant.NameBefore + "Infra" + ExternConstant.NameAfter;

    [DllImport(InfraLib)] public extern static ulong New(ulong count);
    [DllImport(InfraLib)] public extern static ulong Delete(ulong any);
    [DllImport(InfraLib)] public extern static ulong Copy(ulong dest, ulong source, ulong count);
    [DllImport(InfraLib)] public extern static ulong Exit(ulong code);

    [DllImport(InfraLib)] public extern static ulong String_New();
    [DllImport(InfraLib)] public extern static ulong String_Delete(ulong o);
    [DllImport(InfraLib)] public extern static ulong String_Init(ulong o);
    [DllImport(InfraLib)] public extern static ulong String_Final(ulong o);
    [DllImport(InfraLib)] public extern static ulong String_CountGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong String_CountSet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong String_DataGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong String_DataSet(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong String_Char(ulong o, ulong index);
    [DllImport(InfraLib)] public extern static ulong String_Equal(ulong o, ulong other);

    [DllImport(InfraLib)] public extern static ulong String_ConstantCreate(ulong o);
    [DllImport(InfraLib)] public extern static ulong String_ConstantDelete(ulong o);

    [DllImport(InfraLib)] public extern static ulong Console_New();
    [DllImport(InfraLib)] public extern static ulong Console_Delete(ulong o);
    [DllImport(InfraLib)] public extern static ulong Console_Init(ulong o);
    [DllImport(InfraLib)] public extern static ulong Console_Final(ulong o);
    [DllImport(InfraLib)] public extern static ulong Console_OutWrite(ulong o, ulong text);
    [DllImport(InfraLib)] public extern static ulong Console_ErrWrite(ulong o, ulong text);
    [DllImport(InfraLib)] public extern static ulong Console_InnRead(ulong o);

    [DllImport(InfraLib)] public extern static ulong Array_New();
    [DllImport(InfraLib)] public extern static ulong Array_Delete(ulong o);
    [DllImport(InfraLib)] public extern static ulong Array_Init(ulong o);
    [DllImport(InfraLib)] public extern static ulong Array_Final(ulong o);
    [DllImport(InfraLib)] public extern static ulong Array_CountGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong Array_CountSet(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong Array_ItemGet(ulong o, ulong index);
    [DllImport(InfraLib)] public extern static ulong Array_ItemSet(ulong o, ulong index, ulong value);

    [DllImport(InfraLib)] public extern static ulong TextCode_New();
    [DllImport(InfraLib)] public extern static ulong TextCode_Delete(ulong o);
    [DllImport(InfraLib)] public extern static ulong TextCode_Init(ulong o);
    [DllImport(InfraLib)] public extern static ulong TextCode_Final(ulong o);
    [DllImport(InfraLib)] public extern static ulong TextCode_ExecuteCount(ulong o, ulong innKind, ulong outKind, ulong dataValue, ulong dataCount);
    [DllImport(InfraLib)] public extern static ulong TextCode_ExecuteResult(ulong o, ulong result, ulong innKind, ulong outKind, ulong dataValue, ulong dataCount);

    [DllImport(InfraLib)] public extern static ulong Format_New();
    [DllImport(InfraLib)] public extern static ulong Format_Delete(ulong o);
    [DllImport(InfraLib)] public extern static ulong Format_Init(ulong o);
    [DllImport(InfraLib)] public extern static ulong Format_Final(ulong o);
    [DllImport(InfraLib)] public extern static ulong Format_ExecuteCount(ulong o, ulong varBase, ulong argList);
    [DllImport(InfraLib)] public extern static ulong Format_ExecuteResult(ulong o, ulong varBase, ulong argList, ulong result);
    [DllImport(InfraLib)] public extern static ulong Format_ExecuteArgCount(ulong o, ulong arg);
    [DllImport(InfraLib)] public extern static ulong Format_ExecuteArgResult(ulong o, ulong arg, ulong result);

    [DllImport(InfraLib)] public extern static ulong FormatArg_New();
    [DllImport(InfraLib)] public extern static ulong FormatArg_Delete(ulong o);
    [DllImport(InfraLib)] public extern static ulong FormatArg_Init(ulong o);
    [DllImport(InfraLib)] public extern static ulong FormatArg_Final(ulong o);
    [DllImport(InfraLib)] public extern static ulong FormatArg_PosGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong FormatArg_PosSet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong FormatArg_KindGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong FormatArg_KindSet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong FormatArg_ValueGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong FormatArg_ValueSet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong FormatArg_AlignLeftGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong FormatArg_AlignLeftSet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong FormatArg_FieldWidthGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong FormatArg_FieldWidthSet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong FormatArg_MaxWidthGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong FormatArg_MaxWidthSet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong FormatArg_CaseGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong FormatArg_CaseSet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong FormatArg_BaseGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong FormatArg_BaseSet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong FormatArg_SignGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong FormatArg_SignSet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong FormatArg_FillCharGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong FormatArg_FillCharSet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong FormatArg_HasCountGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong FormatArg_HasCountSet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong FormatArg_ValueCountGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong FormatArg_ValueCountSet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong FormatArg_CountGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong FormatArg_CountSet(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong Math_New();
    [DllImport(InfraLib)] public extern static ulong Math_Delete(ulong o);
    [DllImport(InfraLib)] public extern static ulong Math_Init(ulong o);
    [DllImport(InfraLib)] public extern static ulong Math_Final(ulong o);
    [DllImport(InfraLib)] public extern static ulong Math_Value(ulong o, ulong cand, ulong expo);
    [DllImport(InfraLib)] public extern static ulong Math_ValueTen(ulong o, ulong cand, ulong expoTen);
    [DllImport(InfraLib)] public extern static ulong Math_Comp(ulong o, ulong value, ulong cand, ulong expo);
    [DllImport(InfraLib)] public extern static ulong Math_Less(ulong o, ulong valueA, ulong valueB);
    [DllImport(InfraLib)] public extern static ulong Math_Add(ulong o, ulong valueA, ulong valueB);
    [DllImport(InfraLib)] public extern static ulong Math_Sub(ulong o, ulong valueA, ulong valueB);
    [DllImport(InfraLib)] public extern static ulong Math_Mul(ulong o, ulong valueA, ulong valueB);
    [DllImport(InfraLib)] public extern static ulong Math_Div(ulong o, ulong valueA, ulong valueB);
    [DllImport(InfraLib)] public extern static ulong Math_Abs(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong Math_Exp(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong Math_Exp2(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong Math_Log(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong Math_Log10(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong Math_Log2(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong Math_Pow(ulong o, ulong valueA, ulong valueB);
    [DllImport(InfraLib)] public extern static ulong Math_Sqrt(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong Math_Ceil(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong Math_Floor(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong Math_Trunc(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong Math_Round(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong Math_ATan2(ulong o, ulong valueA, ulong valueB);
    [DllImport(InfraLib)] public extern static ulong Math_Sin(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong Math_Cos(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong Math_Tan(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong Math_ASin(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong Math_ACos(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong Math_ATan(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong Math_SinH(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong Math_CosH(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong Math_TanH(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong Math_ASinH(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong Math_ACosH(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong Math_ATanH(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong Rand_New();
    [DllImport(InfraLib)] public extern static ulong Rand_Delete(ulong o);
    [DllImport(InfraLib)] public extern static ulong Rand_Init(ulong o);
    [DllImport(InfraLib)] public extern static ulong Rand_Final(ulong o);
    [DllImport(InfraLib)] public extern static ulong Rand_SeedGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong Rand_SeedSet(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong Rand_Execute(ulong o);

    [DllImport(InfraLib)] public extern static ulong Range_New();
    [DllImport(InfraLib)] public extern static ulong Range_Delete(ulong o);
    [DllImport(InfraLib)] public extern static ulong Range_Init(ulong o);
    [DllImport(InfraLib)] public extern static ulong Range_Final(ulong o);
    [DllImport(InfraLib)] public extern static ulong Range_IndexGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong Range_IndexSet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong Range_CountGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong Range_CountSet(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong Rect_New();
    [DllImport(InfraLib)] public extern static ulong Rect_Delete(ulong o);
    [DllImport(InfraLib)] public extern static ulong Rect_Init(ulong o);
    [DllImport(InfraLib)] public extern static ulong Rect_Final(ulong o);
    [DllImport(InfraLib)] public extern static ulong Rect_PosGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong Rect_PosSet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong Rect_SizeGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong Rect_SizeSet(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong Pos_New();
    [DllImport(InfraLib)] public extern static ulong Pos_Delete(ulong o);
    [DllImport(InfraLib)] public extern static ulong Pos_Init(ulong o);
    [DllImport(InfraLib)] public extern static ulong Pos_Final(ulong o);
    [DllImport(InfraLib)] public extern static ulong Pos_ColGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong Pos_ColSet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong Pos_RowGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong Pos_RowSet(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong Size_New();
    [DllImport(InfraLib)] public extern static ulong Size_Delete(ulong o);
    [DllImport(InfraLib)] public extern static ulong Size_Init(ulong o);
    [DllImport(InfraLib)] public extern static ulong Size_Final(ulong o);
    [DllImport(InfraLib)] public extern static ulong Size_WedGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong Size_WedSet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong Size_HetGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong Size_HetSet(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong Data_New();
    [DllImport(InfraLib)] public extern static ulong Data_Delete(ulong o);
    [DllImport(InfraLib)] public extern static ulong Data_Init(ulong o);
    [DllImport(InfraLib)] public extern static ulong Data_Final(ulong o);
    [DllImport(InfraLib)] public extern static ulong Data_CountGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong Data_CountSet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong Data_ValueGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong Data_ValueSet(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong Entry_New();
    [DllImport(InfraLib)] public extern static ulong Entry_Delete(ulong o);
    [DllImport(InfraLib)] public extern static ulong Entry_Init(ulong o);
    [DllImport(InfraLib)] public extern static ulong Entry_Final(ulong o);
    [DllImport(InfraLib)] public extern static ulong Entry_IndexGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong Entry_IndexSet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong Entry_ValueGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong Entry_ValueSet(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong State_New();
    [DllImport(InfraLib)] public extern static ulong State_Delete(ulong o);
    [DllImport(InfraLib)] public extern static ulong State_Init(ulong o);
    [DllImport(InfraLib)] public extern static ulong State_Final(ulong o);
    [DllImport(InfraLib)] public extern static ulong State_MaideGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong State_MaideSet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong State_ArgGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong State_ArgSet(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong Main_TerminateStateGet();
    [DllImport(InfraLib)] public extern static ulong Main_TerminateStateSet(ulong value);

    [DllImport(InfraLib)] public extern static ulong Main_Init();
    [DllImport(InfraLib)] public extern static ulong Main_Final();
    [DllImport(InfraLib)] public extern static ulong Main_IsCSharpSet(ulong value);
    [DllImport(InfraLib)] public extern static ulong Main_ExecuteEventLoop();
    [DllImport(InfraLib)] public extern static ulong Main_ExitEventLoop(ulong code);

    public delegate ulong Main_Terminate_Maide(ulong arg);

    [DllImport(InfraLib)] public extern static ulong Frame_New();
    [DllImport(InfraLib)] public extern static ulong Frame_Delete(ulong o);
    [DllImport(InfraLib)] public extern static ulong Frame_Init(ulong o);
    [DllImport(InfraLib)] public extern static ulong Frame_Final(ulong o);
    [DllImport(InfraLib)] public extern static ulong Frame_TitleGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong Frame_TitleSet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong Frame_VisibleGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong Frame_VisibleSet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong Frame_SizeGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong Frame_SizeSet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong Frame_TypeStateGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong Frame_TypeStateSet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong Frame_DrawStateGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong Frame_DrawStateSet(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong Frame_TitleThisSet(ulong o);
    [DllImport(InfraLib)] public extern static ulong Frame_VideoOut(ulong o);
    [DllImport(InfraLib)] public extern static ulong Frame_Update(ulong o, ulong rect);
    [DllImport(InfraLib)] public extern static ulong Frame_Close(ulong o);

    public delegate ulong Frame_Type_Maide(ulong frame, ulong index, ulong field, ulong arg);
    public delegate ulong Frame_Draw_Maide(ulong frame, ulong arg);

    [DllImport(InfraLib)] public extern static ulong Draw_New();
    [DllImport(InfraLib)] public extern static ulong Draw_Delete(ulong o);
    [DllImport(InfraLib)] public extern static ulong Draw_Init(ulong o);
    [DllImport(InfraLib)] public extern static ulong Draw_Final(ulong o);
    [DllImport(InfraLib)] public extern static ulong Draw_SizeGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong Draw_SizeSet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong Draw_OutGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong Draw_OutSet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong Draw_AreaGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong Draw_AreaSet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong Draw_FillGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong Draw_FillSet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong Draw_FillPosGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong Draw_FillPosSet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong Draw_StrokeGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong Draw_StrokeSet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong Draw_FaceGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong Draw_FaceSet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong Draw_FormGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong Draw_FormSet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong Draw_CompGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong Draw_CompSet(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong Draw_Start(ulong o);
    [DllImport(InfraLib)] public extern static ulong Draw_End(ulong o);
    [DllImport(InfraLib)] public extern static ulong Draw_FillPosThisSet(ulong o);
    [DllImport(InfraLib)] public extern static ulong Draw_AreaThisSet(ulong o);
    [DllImport(InfraLib)] public extern static ulong Draw_Clear(ulong o, ulong color);
    [DllImport(InfraLib)] public extern static ulong Draw_ExecuteLine(ulong o, ulong startPos, ulong endPos);
    [DllImport(InfraLib)] public extern static ulong Draw_ExecuteRect(ulong o, ulong rect);
    [DllImport(InfraLib)] public extern static ulong Draw_ExecuteRectRound(ulong o, ulong rect, ulong horizRadius, ulong vertRadius);
    [DllImport(InfraLib)] public extern static ulong Draw_ExecuteRound(ulong o, ulong rect);
    [DllImport(InfraLib)] public extern static ulong Draw_ExecuteRoundLine(ulong o, ulong rect, ulong angleRange);
    [DllImport(InfraLib)] public extern static ulong Draw_ExecuteRoundPart(ulong o, ulong rect, ulong angleRange);
    [DllImport(InfraLib)] public extern static ulong Draw_ExecuteRoundShape(ulong o, ulong rect, ulong angleRange);
    [DllImport(InfraLib)] public extern static ulong Draw_ExecuteShape(ulong o, ulong pointListCount, ulong pointListData);
    [DllImport(InfraLib)] public extern static ulong Draw_ExecuteShapeLine(ulong o, ulong pointListCount, ulong pointListData);
    [DllImport(InfraLib)] public extern static ulong Draw_ExecuteImage(ulong o, ulong image, ulong destRect, ulong sourceRect);
    [DllImport(InfraLib)] public extern static ulong Draw_ExecuteText(ulong o, ulong text, ulong horizAlign, ulong vertAlign, ulong wordWrap, ulong destRect, ulong boundRect);

    [DllImport(InfraLib)] public extern static ulong Brush_New();
    [DllImport(InfraLib)] public extern static ulong Brush_Delete(ulong o);
    [DllImport(InfraLib)] public extern static ulong Brush_Init(ulong o);
    [DllImport(InfraLib)] public extern static ulong Brush_Final(ulong o);
    [DllImport(InfraLib)] public extern static ulong Brush_KindGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong Brush_KindSet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong Brush_ColorGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong Brush_ColorSet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong Brush_GradientGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong Brush_GradientSet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong Brush_ImageGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong Brush_ImageSet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong Brush_LineGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong Brush_LineSet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong Brush_WidthGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong Brush_WidthSet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong Brush_CapGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong Brush_CapSet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong Brush_JoinGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong Brush_JoinSet(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong PointData_PointGet(ulong address, ulong result);
    [DllImport(InfraLib)] public extern static ulong PointData_PointSet(ulong address, ulong pos);

    [DllImport(InfraLib)] public extern static ulong Image_New();
    [DllImport(InfraLib)] public extern static ulong Image_Delete(ulong o);
    [DllImport(InfraLib)] public extern static ulong Image_Init(ulong o);
    [DllImport(InfraLib)] public extern static ulong Image_Final(ulong o);
    [DllImport(InfraLib)] public extern static ulong Image_SizeGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong Image_SizeSet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong Image_DataGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong Image_DataSet(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong Image_VideoOut(ulong o);
    [DllImport(InfraLib)] public extern static ulong Image_DataCreate(ulong o);

    [DllImport(InfraLib)] public extern static ulong Face_New();
    [DllImport(InfraLib)] public extern static ulong Face_Delete(ulong o);
    [DllImport(InfraLib)] public extern static ulong Face_Init(ulong o);
    [DllImport(InfraLib)] public extern static ulong Face_Final(ulong o);
    [DllImport(InfraLib)] public extern static ulong Face_FamilyGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong Face_FamilySet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong Face_SizeGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong Face_SizeSet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong Face_WeightGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong Face_WeightSet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong Face_ItalicGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong Face_ItalicSet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong Face_UnderlineGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong Face_UnderlineSet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong Face_OverlineGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong Face_OverlineSet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong Face_StrikeoutGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong Face_StrikeoutSet(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong Form_New();
    [DllImport(InfraLib)] public extern static ulong Form_Delete(ulong o);
    [DllImport(InfraLib)] public extern static ulong Form_Init(ulong o);
    [DllImport(InfraLib)] public extern static ulong Form_Final(ulong o);
    [DllImport(InfraLib)] public extern static ulong Form_Reset(ulong o);
    [DllImport(InfraLib)] public extern static ulong Form_Offset(ulong o, ulong offsetLeft, ulong offsetUp);
    [DllImport(InfraLib)] public extern static ulong Form_Scale(ulong o, ulong horizScale, ulong vertScale);
    [DllImport(InfraLib)] public extern static ulong Form_Rotate(ulong o, ulong angle);
    [DllImport(InfraLib)] public extern static ulong Form_ValueGet(ulong o, ulong row, ulong col);
    [DllImport(InfraLib)] public extern static ulong Form_ValueSet(ulong o, ulong row, ulong col, ulong value);
    [DllImport(InfraLib)] public extern static ulong Form_Multiply(ulong o, ulong other);
    [DllImport(InfraLib)] public extern static ulong Form_IsIdentity(ulong o);
    [DllImport(InfraLib)] public extern static ulong Form_IsInvertible(ulong o);
    [DllImport(InfraLib)] public extern static ulong Form_Invert(ulong o, ulong result);
    [DllImport(InfraLib)] public extern static ulong Form_Transpose(ulong o, ulong result);

    [DllImport(InfraLib)] public extern static ulong Gradient_New();
    [DllImport(InfraLib)] public extern static ulong Gradient_Delete(ulong o);
    [DllImport(InfraLib)] public extern static ulong Gradient_Init(ulong o);
    [DllImport(InfraLib)] public extern static ulong Gradient_Final(ulong o);
    [DllImport(InfraLib)] public extern static ulong Gradient_KindGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong Gradient_KindSet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong Gradient_ValueGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong Gradient_ValueSet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong Gradient_StopGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong Gradient_StopSet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong Gradient_SpreadGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong Gradient_SpreadSet(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong GradientLinear_New();
    [DllImport(InfraLib)] public extern static ulong GradientLinear_Delete(ulong o);
    [DllImport(InfraLib)] public extern static ulong GradientLinear_Init(ulong o);
    [DllImport(InfraLib)] public extern static ulong GradientLinear_Final(ulong o);
    [DllImport(InfraLib)] public extern static ulong GradientLinear_StartPosGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong GradientLinear_StartPosSet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong GradientLinear_EndPosGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong GradientLinear_EndPosSet(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong GradientRadial_New();
    [DllImport(InfraLib)] public extern static ulong GradientRadial_Delete(ulong o);
    [DllImport(InfraLib)] public extern static ulong GradientRadial_Init(ulong o);
    [DllImport(InfraLib)] public extern static ulong GradientRadial_Final(ulong o);
    [DllImport(InfraLib)] public extern static ulong GradientRadial_CenterPosGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong GradientRadial_CenterPosSet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong GradientRadial_CenterRadiusGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong GradientRadial_CenterRadiusSet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong GradientRadial_FocusPosGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong GradientRadial_FocusPosSet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong GradientRadial_FocusRadiusGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong GradientRadial_FocusRadiusSet(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong GradientStop_New();
    [DllImport(InfraLib)] public extern static ulong GradientStop_Delete(ulong o);
    [DllImport(InfraLib)] public extern static ulong GradientStop_Init(ulong o);
    [DllImport(InfraLib)] public extern static ulong GradientStop_Final(ulong o);
    [DllImport(InfraLib)] public extern static ulong GradientStop_CountGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong GradientStop_CountSet(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong GradientStop_PointGet(ulong o, ulong index, ulong pos, ulong color);
    [DllImport(InfraLib)] public extern static ulong GradientStop_PointSet(ulong o, ulong index, ulong pos, ulong color);

    [DllImport(InfraLib)] public extern static ulong ImageRead_New();
    [DllImport(InfraLib)] public extern static ulong ImageRead_Delete(ulong o);
    [DllImport(InfraLib)] public extern static ulong ImageRead_Init(ulong o);
    [DllImport(InfraLib)] public extern static ulong ImageRead_Final(ulong o);
    [DllImport(InfraLib)] public extern static ulong ImageRead_StreamGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong ImageRead_StreamSet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong ImageRead_ImageGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong ImageRead_ImageSet(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong ImageRead_Execute(ulong o);

    [DllImport(InfraLib)] public extern static ulong ImageWrite_New();
    [DllImport(InfraLib)] public extern static ulong ImageWrite_Delete(ulong o);
    [DllImport(InfraLib)] public extern static ulong ImageWrite_Init(ulong o);
    [DllImport(InfraLib)] public extern static ulong ImageWrite_Final(ulong o);
    [DllImport(InfraLib)] public extern static ulong ImageWrite_StreamGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong ImageWrite_StreamSet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong ImageWrite_ImageGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong ImageWrite_ImageSet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong ImageWrite_BinaryGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong ImageWrite_BinarySet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong ImageWrite_QualityGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong ImageWrite_QualitySet(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong ImageWrite_Execute(ulong o);

    [DllImport(InfraLib)] public extern static ulong VideoOut_New();
    [DllImport(InfraLib)] public extern static ulong VideoOut_Delete(ulong o);
    [DllImport(InfraLib)] public extern static ulong VideoOut_Init(ulong o);
    [DllImport(InfraLib)] public extern static ulong VideoOut_Final(ulong o);
    [DllImport(InfraLib)] public extern static ulong VideoOut_SizeGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong VideoOut_SizeSet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong VideoOut_FrameGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong VideoOut_FrameSet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong VideoOut_SubtitleGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong VideoOut_SubtitleSet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong VideoOut_FrameStateGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong VideoOut_FrameStateSet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong VideoOut_SizeStateGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong VideoOut_SizeStateSet(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong VideoOut_SubtitleThisSet(ulong o);

    public delegate ulong VideoOut_Frame_Maide(ulong videoOut, ulong frame, ulong arg);
    public delegate ulong VideoOut_Size_Maide(ulong videoOut, ulong size, ulong arg);

    [DllImport(InfraLib)] public extern static ulong VideoFrame_New();
    [DllImport(InfraLib)] public extern static ulong VideoFrame_Delete(ulong o);
    [DllImport(InfraLib)] public extern static ulong VideoFrame_Init(ulong o);
    [DllImport(InfraLib)] public extern static ulong VideoFrame_Final(ulong o);
    [DllImport(InfraLib)] public extern static ulong VideoFrame_SizeGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong VideoFrame_SizeSet(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong VideoFrame_Image(ulong o, ulong image);

    [DllImport(InfraLib)] public extern static ulong AudioOut_New();
    [DllImport(InfraLib)] public extern static ulong AudioOut_Delete(ulong o);
    [DllImport(InfraLib)] public extern static ulong AudioOut_Init(ulong o);
    [DllImport(InfraLib)] public extern static ulong AudioOut_Final(ulong o);
    [DllImport(InfraLib)] public extern static ulong AudioOut_MutedGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong AudioOut_MutedSet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong AudioOut_VolumeGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong AudioOut_VolumeSet(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong Play_New();
    [DllImport(InfraLib)] public extern static ulong Play_Delete(ulong o);
    [DllImport(InfraLib)] public extern static ulong Play_Init(ulong o);
    [DllImport(InfraLib)] public extern static ulong Play_Final(ulong o);
    [DllImport(InfraLib)] public extern static ulong Play_SourceGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong Play_SourceSet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong Play_VideoOutGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong Play_VideoOutSet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong Play_AudioOutGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong Play_AudioOutSet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong Play_TimeGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong Play_TimeSet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong Play_PosGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong Play_PosSet(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong Play_SourceThisSet(ulong o);
    [DllImport(InfraLib)] public extern static ulong Play_HasVideo(ulong o);
    [DllImport(InfraLib)] public extern static ulong Play_HasAudio(ulong o);
    [DllImport(InfraLib)] public extern static ulong Play_Execute(ulong o);
    [DllImport(InfraLib)] public extern static ulong Play_Pause(ulong o);
    [DllImport(InfraLib)] public extern static ulong Play_Stop(ulong o);

    [DllImport(InfraLib)] public extern static ulong Stream_New();
    [DllImport(InfraLib)] public extern static ulong Stream_Delete(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stream_Init(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stream_Final(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stream_KindGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stream_KindSet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong Stream_StatusGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stream_StatusSet(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong Stream_CountGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stream_PosGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stream_PosSet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong Stream_HasCount(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stream_HasPos(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stream_CanRead(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stream_CanWrite(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stream_Read(ulong o, ulong data, ulong range);
    [DllImport(InfraLib)] public extern static ulong Stream_Write(ulong o, ulong data, ulong range);

    [DllImport(InfraLib)] public extern static ulong Memory_New();
    [DllImport(InfraLib)] public extern static ulong Memory_Delete(ulong o);
    [DllImport(InfraLib)] public extern static ulong Memory_Init(ulong o);
    [DllImport(InfraLib)] public extern static ulong Memory_Final(ulong o);
    [DllImport(InfraLib)] public extern static ulong Memory_StreamGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong Memory_StreamSet(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong Memory_Open(ulong o);
    [DllImport(InfraLib)] public extern static ulong Memory_Close(ulong o);

    [DllImport(InfraLib)] public extern static ulong Storage_New();
    [DllImport(InfraLib)] public extern static ulong Storage_Delete(ulong o);
    [DllImport(InfraLib)] public extern static ulong Storage_Init(ulong o);
    [DllImport(InfraLib)] public extern static ulong Storage_Final(ulong o);
    [DllImport(InfraLib)] public extern static ulong Storage_PathGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong Storage_PathSet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong Storage_ModeGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong Storage_ModeSet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong Storage_StreamGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong Storage_StreamSet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong Storage_StatusGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong Storage_StatusSet(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong Storage_CountSet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong Storage_Open(ulong o);
    [DllImport(InfraLib)] public extern static ulong Storage_Close(ulong o);

    [DllImport(InfraLib)] public extern static ulong StorageArrange_New();
    [DllImport(InfraLib)] public extern static ulong StorageArrange_Delete(ulong o);
    [DllImport(InfraLib)] public extern static ulong StorageArrange_Init(ulong o);
    [DllImport(InfraLib)] public extern static ulong StorageArrange_Final(ulong o);
    [DllImport(InfraLib)] public extern static ulong StorageArrange_Rename(ulong o, ulong path, ulong destPath);
    [DllImport(InfraLib)] public extern static ulong StorageArrange_FileCopy(ulong o, ulong path, ulong destPath);
    [DllImport(InfraLib)] public extern static ulong StorageArrange_FileRemove(ulong o, ulong path);
    [DllImport(InfraLib)] public extern static ulong StorageArrange_FoldCreate(ulong o, ulong path);
    [DllImport(InfraLib)] public extern static ulong StorageArrange_FoldCopy(ulong o, ulong path, ulong destPath);
    [DllImport(InfraLib)] public extern static ulong StorageArrange_FoldRemove(ulong o, ulong path);
    [DllImport(InfraLib)] public extern static ulong StorageArrange_Exist(ulong o, ulong path);

    [DllImport(InfraLib)] public extern static ulong Network_New();
    [DllImport(InfraLib)] public extern static ulong Network_Delete(ulong o);
    [DllImport(InfraLib)] public extern static ulong Network_Init(ulong o);
    [DllImport(InfraLib)] public extern static ulong Network_Final(ulong o);
    [DllImport(InfraLib)] public extern static ulong Network_HostNameGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong Network_HostNameSet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong Network_HostPortGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong Network_HostPortSet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong Network_StreamGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong Network_StreamSet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong Network_ReadyCountGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong Network_ReadyCountSet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong Network_StatusGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong Network_StatusSet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong Network_CaseGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong Network_CaseSet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong Network_CaseChangeStateGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong Network_CaseChangeStateSet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong Network_StatusChangeStateGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong Network_StatusChangeStateSet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong Network_ReadyReadStateGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong Network_ReadyReadStateSet(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong Network_Open(ulong o);
    [DllImport(InfraLib)] public extern static ulong Network_Close(ulong o);
    [DllImport(InfraLib)] public extern static ulong Network_Abort(ulong o);

    public delegate ulong Network_CaseChange_Maide(ulong network, ulong arg);
    public delegate ulong Network_StatusChange_Maide(ulong network, ulong arg);
    public delegate ulong Network_ReadyRead_Maide(ulong network, ulong arg);

    [DllImport(InfraLib)] public extern static ulong NetworkHost_New();
    [DllImport(InfraLib)] public extern static ulong NetworkHost_Delete(ulong o);
    [DllImport(InfraLib)] public extern static ulong NetworkHost_Init(ulong o);
    [DllImport(InfraLib)] public extern static ulong NetworkHost_Final(ulong o);
    [DllImport(InfraLib)] public extern static ulong NetworkHost_PortGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong NetworkHost_PortSet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong NetworkHost_NewPeerStateGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong NetworkHost_NewPeerStateSet(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong NetworkHost_Open(ulong o);
    [DllImport(InfraLib)] public extern static ulong NetworkHost_Close(ulong o);
    [DllImport(InfraLib)] public extern static ulong NetworkHost_OpenPeer(ulong o);
    [DllImport(InfraLib)] public extern static ulong NetworkHost_ClosePeer(ulong o, ulong network);

    public delegate ulong NetworkHost_NewPeer_Maide(ulong networkHost, ulong arg);

    [DllImport(InfraLib)] public extern static ulong NetworkPort_New();
    [DllImport(InfraLib)] public extern static ulong NetworkPort_Delete(ulong o);
    [DllImport(InfraLib)] public extern static ulong NetworkPort_Init(ulong o);
    [DllImport(InfraLib)] public extern static ulong NetworkPort_Final(ulong o);
    [DllImport(InfraLib)] public extern static ulong NetworkPort_KindGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong NetworkPort_KindSet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong NetworkPort_ValueAGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong NetworkPort_ValueASet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong NetworkPort_ValueBGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong NetworkPort_ValueBSet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong NetworkPort_ValueCGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong NetworkPort_ValueCSet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong NetworkPort_HostGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong NetworkPort_HostSet(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong NetworkPort_Set(ulong o);

    [DllImport(InfraLib)] public extern static ulong Thread_New();
    [DllImport(InfraLib)] public extern static ulong Thread_Delete(ulong o);
    [DllImport(InfraLib)] public extern static ulong Thread_Init(ulong o);
    [DllImport(InfraLib)] public extern static ulong Thread_Final(ulong o);
    [DllImport(InfraLib)] public extern static ulong Thread_IdentGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong Thread_IdentSet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong Thread_ExecuteStateGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong Thread_ExecuteStateSet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong Thread_StatusGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong Thread_StatusSet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong Thread_CaseGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong Thread_CaseSet(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong Thread_Execute(ulong o);
    [DllImport(InfraLib)] public extern static ulong Thread_Terminate(ulong o);
    [DllImport(InfraLib)] public extern static ulong Thread_Pause(ulong o);
    [DllImport(InfraLib)] public extern static ulong Thread_Resume(ulong o);
    [DllImport(InfraLib)] public extern static ulong Thread_Wait(ulong o);
    [DllImport(InfraLib)] public extern static ulong Thread_ExecuteEventLoop(ulong o);
    [DllImport(InfraLib)] public extern static ulong Thread_ExitEventLoop(ulong o, ulong code);
    [DllImport(InfraLib)] public extern static ulong Thread_IsMain(ulong o);

    [DllImport(InfraLib)] public extern static ulong Thread_Sleep(ulong time);
    [DllImport(InfraLib)] public extern static ulong Thread_This();

    public delegate ulong Thread_Execute_Maide(ulong thread, ulong arg);

    [DllImport(InfraLib)] public extern static ulong Phore_New();
    [DllImport(InfraLib)] public extern static ulong Phore_Delete(ulong o);
    [DllImport(InfraLib)] public extern static ulong Phore_Init(ulong o);
    [DllImport(InfraLib)] public extern static ulong Phore_Final(ulong o);
    [DllImport(InfraLib)] public extern static ulong Phore_CountGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong Phore_CountSet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong Phore_InitCountGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong Phore_InitCountSet(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong Phore_Acquire(ulong o);
    [DllImport(InfraLib)] public extern static ulong Phore_Release(ulong o);

    [DllImport(InfraLib)] public extern static ulong Time_New();
    [DllImport(InfraLib)] public extern static ulong Time_Delete(ulong o);
    [DllImport(InfraLib)] public extern static ulong Time_Init(ulong o);
    [DllImport(InfraLib)] public extern static ulong Time_Final(ulong o);
    [DllImport(InfraLib)] public extern static ulong Time_YeaGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong Time_YeaSet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong Time_MonGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong Time_MonSet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong Time_DayGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong Time_DaySet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong Time_OurGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong Time_OurSet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong Time_MinGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong Time_MinSet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong Time_SecGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong Time_SecSet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong Time_MillisecGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong Time_MillisecSet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong Time_PosGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong Time_PosSet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong Time_YeaDayGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong Time_YeaDaySet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong Time_WeekDayGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong Time_WeekDaySet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong Time_YeaDayCountGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong Time_YeaDayCountSet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong Time_MonDayCountGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong Time_MonDayCountSet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong Time_TotalMillisecGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong Time_TotalMillisecSet(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong Time_AddYea(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong Time_AddMon(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong Time_AddDay(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong Time_AddMillisec(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong Time_This(ulong o);
    [DllImport(InfraLib)] public extern static ulong Time_ToPos(ulong o, ulong pos);
    [DllImport(InfraLib)] public extern static ulong Time_Set(ulong o, ulong yea, ulong mon, ulong day, ulong our, ulong min, ulong sec, ulong millisec, ulong pos);

    [DllImport(InfraLib)] public extern static ulong Time_LeapYea(ulong yea);
    [DllImport(InfraLib)] public extern static ulong Time_ValidDate(ulong yea, ulong mon, ulong day);
    [DllImport(InfraLib)] public extern static ulong Time_ValidTime(ulong our, ulong min, ulong sec, ulong millisec);

    [DllImport(InfraLib)] public extern static ulong TimeEvent_New();
    [DllImport(InfraLib)] public extern static ulong TimeEvent_Delete(ulong o);
    [DllImport(InfraLib)] public extern static ulong TimeEvent_Init(ulong o);
    [DllImport(InfraLib)] public extern static ulong TimeEvent_Final(ulong o);
    [DllImport(InfraLib)] public extern static ulong TimeEvent_TimeGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong TimeEvent_TimeSet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong TimeEvent_SingleGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong TimeEvent_SingleSet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong TimeEvent_ActiveGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong TimeEvent_ActiveSet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong TimeEvent_ElapseStateGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong TimeEvent_ElapseStateSet(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong TimeEvent_Start(ulong o);
    [DllImport(InfraLib)] public extern static ulong TimeEvent_Stop(ulong o);

    public delegate ulong TimeEvent_Elapse_Maide(ulong timeEvent, ulong arg);

    [DllImport(InfraLib)] public extern static ulong Post_New();
    [DllImport(InfraLib)] public extern static ulong Post_Delete(ulong o);
    [DllImport(InfraLib)] public extern static ulong Post_Init(ulong o);
    [DllImport(InfraLib)] public extern static ulong Post_Final(ulong o);
    [DllImport(InfraLib)] public extern static ulong Post_ExecuteStateGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong Post_ExecuteStateSet(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong Post_Execute(ulong o);

    public delegate ulong Post_Execute_Maide(ulong post, ulong arg);

    [DllImport(InfraLib)] public extern static ulong Program_New();
    [DllImport(InfraLib)] public extern static ulong Program_Delete(ulong o);
    [DllImport(InfraLib)] public extern static ulong Program_Init(ulong o);
    [DllImport(InfraLib)] public extern static ulong Program_Final(ulong o);
    [DllImport(InfraLib)] public extern static ulong Program_NameGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong Program_NameSet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong Program_ArgueGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong Program_ArgueSet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong Program_WorkFoldGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong Program_WorkFoldSet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong Program_EnvironmentGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong Program_EnvironmentSet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong Program_IdentGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong Program_IdentSet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong Program_StatusGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong Program_StatusSet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong Program_ExitKindGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong Program_ExitKindSet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong Program_StartStateGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong Program_StartStateSet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong Program_FinishStateGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong Program_FinishStateSet(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong Program_Execute(ulong o);
    [DllImport(InfraLib)] public extern static ulong Program_Wait(ulong o);
    [DllImport(InfraLib)] public extern static ulong Program_Terminate(ulong o);

    public delegate ulong Program_Start_Maide(ulong program, ulong arg);
    public delegate ulong Program_Finish_Maide(ulong program, ulong arg);

    [DllImport(InfraLib)] public extern static ulong Infra_Share();

    [DllImport(InfraLib)] public extern static ulong Share_Stat(ulong o);

    [DllImport(InfraLib)] public extern static ulong Stat_PointDataCount(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_TextAlignStart(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_TextAlignMid(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_TextAlignEnd(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_TextCodeKindUtf8(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_TextCodeKindUtf16(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_TextCodeKindUtf32(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_ThreadCaseReady(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_ThreadCaseExecute(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_ThreadCasePause(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_ThreadCaseFinish(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_ThreadCaseTerminate(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_StreamKindMemory(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_StreamKindStorage(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_StreamKindNetwork(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_StorageModeRead(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_StorageModeWrite(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_StorageModeNew(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_StorageModeExisting(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_StorageStatusNoError(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_StorageStatusReadError(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_StorageStatusWriteError(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_StorageStatusFatalError(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_StorageStatusResourceError(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_StorageStatusOpenError(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_StorageStatusAbortError(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_StorageStatusTimeOutError(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_StorageStatusUnspecifiedError(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_StorageStatusRemoveError(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_StorageStatusRenameError(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_StorageStatusPositionError(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_StorageStatusResizeError(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_StorageStatusPermissionsError(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_StorageStatusCopyError(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_NetworkCaseUnconnected(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_NetworkCaseHostLookup(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_NetworkCaseConnecting(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_NetworkCaseConnected(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_NetworkCaseBound(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_NetworkCaseListening(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_NetworkCaseClosing(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_NetworkPortKindIPv6(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_NetworkPortKindIPv4(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_NetworkPortKindBroadcast(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_NetworkPortKindLocalHost(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_NetworkPortKindLocalHostIPv6(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_NetworkPortKindAny(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_NetworkPortKindAnyIPv6(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_NetworkPortKindAnyIPv4(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_NetworkStatusNoError(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_NetworkStatusConnectionRefusedError(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_NetworkStatusRemoteHostClosedError(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_NetworkStatusHostNotFoundError(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_NetworkStatusSocketAccessError(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_NetworkStatusSocketResourceError(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_NetworkStatusSocketTimeoutError(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_NetworkStatusDatagramTooLargeError(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_NetworkStatusNetworkError(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_NetworkStatusAddressInUseError(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_NetworkStatusSocketAddressNotAvailableError(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_NetworkStatusUnsupportedSocketOperationError(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_NetworkStatusUnfinishedSocketOperationError(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_NetworkStatusProxyAuthenticationRequiredError(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_NetworkStatusSslHandshakeFailedError(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_NetworkStatusProxyConnectionRefusedError(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_NetworkStatusProxyConnectionClosedError(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_NetworkStatusProxyConnectionTimeoutError(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_NetworkStatusProxyNotFoundError(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_NetworkStatusProxyProtocolError(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_NetworkStatusOperationError(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_NetworkStatusSslInternalError(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_NetworkStatusSslInvalidUserDataError(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_NetworkStatusTemporaryError(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_BrushKindColor(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_BrushKindGradient(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_BrushKindImage(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_BrushLineSolid(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_BrushLineDash(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_BrushLineDot(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_BrushLineDashDot(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_BrushLineDashDotDot(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_BrushCapFlat(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_BrushCapSquare(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_BrushCapRound(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_BrushJoinMiter(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_BrushJoinBevel(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_BrushJoinRound(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_GradientKindLinear(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_GradientKindRadial(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_GradientSpreadPad(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_GradientSpreadReflect(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_GradientSpreadRepeat(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_CompSourceOver(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_CompDestinationOver(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_CompClear(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_CompSource(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_CompDestination(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_CompSourceIn(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_CompDestinationIn(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_CompSourceOut(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_CompDestinationOut(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_CompSourceAtop(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_CompDestinationAtop(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_ImageBinaryBmp(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_ImageBinaryJpg(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_ImageBinaryPng(ulong o);

}