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

    [DllImport(InfraLib)] public extern static ulong Return_New();
    [DllImport(InfraLib)] public extern static ulong Return_Delete(ulong o);
    [DllImport(InfraLib)] public extern static ulong Return_Init(ulong o);
    [DllImport(InfraLib)] public extern static ulong Return_Final(ulong o);
    [DllImport(InfraLib)] public extern static ulong Return_StringGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong Return_StringSet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong Return_StringListGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong Return_StringListSet(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong Return_StringStart(ulong o);
    [DllImport(InfraLib)] public extern static ulong Return_StringEnd(ulong o);
    [DllImport(InfraLib)] public extern static ulong Return_StringCount(ulong o);
    [DllImport(InfraLib)] public extern static ulong Return_StringResult(ulong o, ulong result);
    [DllImport(InfraLib)] public extern static ulong Return_StringListStart(ulong o);
    [DllImport(InfraLib)] public extern static ulong Return_StringListEnd(ulong o);
    [DllImport(InfraLib)] public extern static ulong Return_StringListCount(ulong o);
    [DllImport(InfraLib)] public extern static ulong Return_StringListItem(ulong o, ulong index);

    [DllImport(InfraLib)] public extern static ulong Console_New();
    [DllImport(InfraLib)] public extern static ulong Console_Delete(ulong o);
    [DllImport(InfraLib)] public extern static ulong Console_Init(ulong o);
    [DllImport(InfraLib)] public extern static ulong Console_Final(ulong o);
    [DllImport(InfraLib)] public extern static ulong Console_Write(ulong o, ulong text);
    [DllImport(InfraLib)] public extern static ulong Console_ErrWrite(ulong o, ulong text);
    [DllImport(InfraLib)] public extern static ulong Console_Read(ulong o);

    [DllImport(InfraLib)] public extern static ulong Array_New();
    [DllImport(InfraLib)] public extern static ulong Array_Delete(ulong o);
    [DllImport(InfraLib)] public extern static ulong Array_Init(ulong o);
    [DllImport(InfraLib)] public extern static ulong Array_Final(ulong o);
    [DllImport(InfraLib)] public extern static ulong Array_CountGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong Array_CountSet(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong Array_ItemGet(ulong o, ulong index);
    [DllImport(InfraLib)] public extern static ulong Array_ItemSet(ulong o, ulong index, ulong value);

    [DllImport(InfraLib)] public extern static ulong TextEncode_New();
    [DllImport(InfraLib)] public extern static ulong TextEncode_Delete(ulong o);
    [DllImport(InfraLib)] public extern static ulong TextEncode_Init(ulong o);
    [DllImport(InfraLib)] public extern static ulong TextEncode_Final(ulong o);
    [DllImport(InfraLib)] public extern static ulong TextEncode_KindGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong TextEncode_KindSet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong TextEncode_WriteBomGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong TextEncode_WriteBomSet(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong TextEncode_GetStringCountMax(ulong o, ulong count);
    [DllImport(InfraLib)] public extern static ulong TextEncode_GetString(ulong o, ulong result, ulong data);
    [DllImport(InfraLib)] public extern static ulong TextEncode_GetDataCountMax(ulong o, ulong count);
    [DllImport(InfraLib)] public extern static ulong TextEncode_GetData(ulong o, ulong result, ulong fromString);

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
    [DllImport(InfraLib)] public extern static ulong FormatArg_PrecisionGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong FormatArg_PrecisionSet(ulong o, ulong value);
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
    [DllImport(InfraLib)] public extern static ulong Math_GetValue(ulong o, ulong significand, ulong exponent);
    [DllImport(InfraLib)] public extern static ulong Math_GetValueTen(ulong o, ulong significand, ulong exponentTen);
    [DllImport(InfraLib)] public extern static ulong Math_GetCompose(ulong o, ulong value, ulong significand, ulong exponent);
    [DllImport(InfraLib)] public extern static ulong Math_Add(ulong o, ulong a, ulong b);
    [DllImport(InfraLib)] public extern static ulong Math_Sub(ulong o, ulong a, ulong b);
    [DllImport(InfraLib)] public extern static ulong Math_Mul(ulong o, ulong a, ulong b);
    [DllImport(InfraLib)] public extern static ulong Math_Div(ulong o, ulong a, ulong b);
    [DllImport(InfraLib)] public extern static ulong Math_Less(ulong o, ulong a, ulong b);
    [DllImport(InfraLib)] public extern static ulong Math_Abs(ulong o, ulong a);
    [DllImport(InfraLib)] public extern static ulong Math_Sin(ulong o, ulong a);
    [DllImport(InfraLib)] public extern static ulong Math_Cos(ulong o, ulong a);
    [DllImport(InfraLib)] public extern static ulong Math_Tan(ulong o, ulong a);
    [DllImport(InfraLib)] public extern static ulong Math_ASin(ulong o, ulong a);
    [DllImport(InfraLib)] public extern static ulong Math_ACos(ulong o, ulong a);
    [DllImport(InfraLib)] public extern static ulong Math_ATan(ulong o, ulong a);
    [DllImport(InfraLib)] public extern static ulong Math_ATan2(ulong o, ulong a, ulong b);
    [DllImport(InfraLib)] public extern static ulong Math_SinH(ulong o, ulong a);
    [DllImport(InfraLib)] public extern static ulong Math_CosH(ulong o, ulong a);
    [DllImport(InfraLib)] public extern static ulong Math_TanH(ulong o, ulong a);
    [DllImport(InfraLib)] public extern static ulong Math_ASinH(ulong o, ulong a);
    [DllImport(InfraLib)] public extern static ulong Math_ACosH(ulong o, ulong a);
    [DllImport(InfraLib)] public extern static ulong Math_ATanH(ulong o, ulong a);
    [DllImport(InfraLib)] public extern static ulong Math_Exp(ulong o, ulong a);
    [DllImport(InfraLib)] public extern static ulong Math_ExpE(ulong o, ulong a);
    [DllImport(InfraLib)] public extern static ulong Math_Log(ulong o, ulong a);
    [DllImport(InfraLib)] public extern static ulong Math_LogE(ulong o, ulong a);
    [DllImport(InfraLib)] public extern static ulong Math_LogN(ulong o, ulong a);
    [DllImport(InfraLib)] public extern static ulong Math_Pow(ulong o, ulong a, ulong exp);
    [DllImport(InfraLib)] public extern static ulong Math_Sqrt(ulong o, ulong a);
    [DllImport(InfraLib)] public extern static ulong Math_TGamma(ulong o, ulong a);
    [DllImport(InfraLib)] public extern static ulong Math_Ceil(ulong o, ulong a);
    [DllImport(InfraLib)] public extern static ulong Math_Floor(ulong o, ulong a);
    [DllImport(InfraLib)] public extern static ulong Math_Trunc(ulong o, ulong a);
    [DllImport(InfraLib)] public extern static ulong Math_Round(ulong o, ulong a);

    [DllImport(InfraLib)] public extern static ulong Random_New();
    [DllImport(InfraLib)] public extern static ulong Random_Delete(ulong o);
    [DllImport(InfraLib)] public extern static ulong Random_Init(ulong o);
    [DllImport(InfraLib)] public extern static ulong Random_Final(ulong o);
    [DllImport(InfraLib)] public extern static ulong Random_SeedGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong Random_SeedSet(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong Random_Execute(ulong o);

    [DllImport(InfraLib)] public extern static ulong Sort_New();
    [DllImport(InfraLib)] public extern static ulong Sort_Delete(ulong o);
    [DllImport(InfraLib)] public extern static ulong Sort_Init(ulong o);
    [DllImport(InfraLib)] public extern static ulong Sort_Final(ulong o);
    [DllImport(InfraLib)] public extern static ulong Sort_Execute(ulong o, ulong data, ulong count, ulong compareState);

    public delegate ulong Sort_Compare_Maide(ulong sort, ulong left, ulong right, ulong arg);

    [DllImport(InfraLib)] public extern static ulong Range_New();
    [DllImport(InfraLib)] public extern static ulong Range_Delete(ulong o);
    [DllImport(InfraLib)] public extern static ulong Range_Init(ulong o);
    [DllImport(InfraLib)] public extern static ulong Range_Final(ulong o);
    [DllImport(InfraLib)] public extern static ulong Range_StartGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong Range_StartSet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong Range_EndGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong Range_EndSet(ulong o, ulong value);

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
    [DllImport(InfraLib)] public extern static ulong Pos_LeftGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong Pos_LeftSet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong Pos_UpGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong Pos_UpSet(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong Size_New();
    [DllImport(InfraLib)] public extern static ulong Size_Delete(ulong o);
    [DllImport(InfraLib)] public extern static ulong Size_Init(ulong o);
    [DllImport(InfraLib)] public extern static ulong Size_Final(ulong o);
    [DllImport(InfraLib)] public extern static ulong Size_WidthGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong Size_WidthSet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong Size_HeightGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong Size_HeightSet(ulong o, ulong value);

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
    [DllImport(InfraLib)] public extern static ulong Main_SetIsCSharp(ulong value);
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
    [DllImport(InfraLib)] public extern static ulong Frame_ResizeStateGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong Frame_ResizeStateSet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong Frame_TypeStateGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong Frame_TypeStateSet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong Frame_MouseStateGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong Frame_MouseStateSet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong Frame_DrawStateGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong Frame_DrawStateSet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong Frame_WindowStatGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong Frame_WindowStatSet(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong Frame_VideoOut(ulong o);
    [DllImport(InfraLib)] public extern static ulong Frame_SizeGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong Frame_SetFrameTitle(ulong o);
    [DllImport(InfraLib)] public extern static ulong Frame_Update(ulong o, ulong rect);
    [DllImport(InfraLib)] public extern static ulong Frame_Close(ulong o);

    public delegate ulong Frame_Resize_Maide(ulong frame, ulong arg);
    public delegate ulong Frame_Type_Maide(ulong frame, ulong index, ulong field, ulong arg);
    public delegate ulong Frame_Mouse_Maide(ulong frame, ulong eventInfo, ulong arg);
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
    [DllImport(InfraLib)] public extern static ulong Draw_FillPosGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong Draw_FillPosSet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong Draw_BrushGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong Draw_BrushSet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong Draw_PenGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong Draw_PenSet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong Draw_FontGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong Draw_FontSet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong Draw_TransformGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong Draw_TransformSet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong Draw_CompositeGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong Draw_CompositeSet(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong Draw_Start(ulong o);
    [DllImport(InfraLib)] public extern static ulong Draw_End(ulong o);
    [DllImport(InfraLib)] public extern static ulong Draw_SetDrawFillPos(ulong o);
    [DllImport(InfraLib)] public extern static ulong Draw_SetDrawArea(ulong o);
    [DllImport(InfraLib)] public extern static ulong Draw_Clear(ulong o, ulong color);
    [DllImport(InfraLib)] public extern static ulong Draw_ExecuteLine(ulong o, ulong startPos, ulong endPos);
    [DllImport(InfraLib)] public extern static ulong Draw_ExecuteArc(ulong o, ulong rect, ulong angleRange);
    [DllImport(InfraLib)] public extern static ulong Draw_ExecuteChord(ulong o, ulong rect, ulong angleRange);
    [DllImport(InfraLib)] public extern static ulong Draw_ExecutePie(ulong o, ulong rect, ulong angleRange);
    [DllImport(InfraLib)] public extern static ulong Draw_ExecuteEllipse(ulong o, ulong rect);
    [DllImport(InfraLib)] public extern static ulong Draw_ExecuteRect(ulong o, ulong rect);
    [DllImport(InfraLib)] public extern static ulong Draw_ExecuteRoundRect(ulong o, ulong rect, ulong horizRadius, ulong vertRadius);
    [DllImport(InfraLib)] public extern static ulong Draw_ExecutePolygon(ulong o, ulong pointListCount, ulong pointListData);
    [DllImport(InfraLib)] public extern static ulong Draw_ExecutePolyline(ulong o, ulong pointListCount, ulong pointListData);
    [DllImport(InfraLib)] public extern static ulong Draw_ExecuteImage(ulong o, ulong image, ulong destRect, ulong sourceRect);
    [DllImport(InfraLib)] public extern static ulong Draw_ExecuteText(ulong o, ulong destRect, ulong flag, ulong text, ulong boundRect);

    [DllImport(InfraLib)] public extern static ulong Brush_New();
    [DllImport(InfraLib)] public extern static ulong Brush_Delete(ulong o);
    [DllImport(InfraLib)] public extern static ulong Brush_Init(ulong o);
    [DllImport(InfraLib)] public extern static ulong Brush_Final(ulong o);
    [DllImport(InfraLib)] public extern static ulong Brush_KindGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong Brush_KindSet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong Brush_ColorGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong Brush_ColorSet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong Brush_ImageGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong Brush_ImageSet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong Brush_GradientGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong Brush_GradientSet(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong Pen_New();
    [DllImport(InfraLib)] public extern static ulong Pen_Delete(ulong o);
    [DllImport(InfraLib)] public extern static ulong Pen_Init(ulong o);
    [DllImport(InfraLib)] public extern static ulong Pen_Final(ulong o);
    [DllImport(InfraLib)] public extern static ulong Pen_KindGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong Pen_KindSet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong Pen_WidthGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong Pen_WidthSet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong Pen_BrushGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong Pen_BrushSet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong Pen_CapGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong Pen_CapSet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong Pen_JoinGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong Pen_JoinSet(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong PointData_GetPoint(ulong address, ulong result);
    [DllImport(InfraLib)] public extern static ulong PointData_SetPoint(ulong address, ulong pos);

    [DllImport(InfraLib)] public extern static ulong Image_New();
    [DllImport(InfraLib)] public extern static ulong Image_Delete(ulong o);
    [DllImport(InfraLib)] public extern static ulong Image_Init(ulong o);
    [DllImport(InfraLib)] public extern static ulong Image_Final(ulong o);
    [DllImport(InfraLib)] public extern static ulong Image_SizeGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong Image_SizeSet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong Image_DataGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong Image_DataSet(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong Image_GetRowByteCount(ulong o);
    [DllImport(InfraLib)] public extern static ulong Image_GetVideoOut(ulong o);
    [DllImport(InfraLib)] public extern static ulong Image_CreateData(ulong o);

    [DllImport(InfraLib)] public extern static ulong Font_New();
    [DllImport(InfraLib)] public extern static ulong Font_Delete(ulong o);
    [DllImport(InfraLib)] public extern static ulong Font_Init(ulong o);
    [DllImport(InfraLib)] public extern static ulong Font_Final(ulong o);
    [DllImport(InfraLib)] public extern static ulong Font_FamilyGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong Font_FamilySet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong Font_SizeGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong Font_SizeSet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong Font_WeightGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong Font_WeightSet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong Font_ItalicGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong Font_ItalicSet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong Font_UnderlineGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong Font_UnderlineSet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong Font_OverlineGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong Font_OverlineSet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong Font_StrikeoutGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong Font_StrikeoutSet(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong Transform_New();
    [DllImport(InfraLib)] public extern static ulong Transform_Delete(ulong o);
    [DllImport(InfraLib)] public extern static ulong Transform_Init(ulong o);
    [DllImport(InfraLib)] public extern static ulong Transform_Final(ulong o);
    [DllImport(InfraLib)] public extern static ulong Transform_Reset(ulong o);
    [DllImport(InfraLib)] public extern static ulong Transform_Offset(ulong o, ulong offsetLeft, ulong offsetUp);
    [DllImport(InfraLib)] public extern static ulong Transform_Scale(ulong o, ulong horizScale, ulong vertScale);
    [DllImport(InfraLib)] public extern static ulong Transform_Rotate(ulong o, ulong angle);
    [DllImport(InfraLib)] public extern static ulong Transform_GetValue(ulong o, ulong row, ulong col);
    [DllImport(InfraLib)] public extern static ulong Transform_SetValue(ulong o, ulong row, ulong col, ulong value);
    [DllImport(InfraLib)] public extern static ulong Transform_Multiply(ulong o, ulong other);
    [DllImport(InfraLib)] public extern static ulong Transform_IsIdentity(ulong o);
    [DllImport(InfraLib)] public extern static ulong Transform_IsInvertible(ulong o);
    [DllImport(InfraLib)] public extern static ulong Transform_Invert(ulong o, ulong result);
    [DllImport(InfraLib)] public extern static ulong Transform_Transpose(ulong o, ulong result);
    [DllImport(InfraLib)] public extern static ulong Transform_Determinant(ulong o);

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

    [DllImport(InfraLib)] public extern static ulong GradientStop_GetPoint(ulong o, ulong index, ulong pos, ulong color);
    [DllImport(InfraLib)] public extern static ulong GradientStop_SetPoint(ulong o, ulong index, ulong pos, ulong color);

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
    [DllImport(InfraLib)] public extern static ulong ImageWrite_FormatGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong ImageWrite_FormatSet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong ImageWrite_QualityGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong ImageWrite_QualitySet(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong ImageWrite_Execute(ulong o);

    [DllImport(InfraLib)] public extern static ulong Dialog_New();
    [DllImport(InfraLib)] public extern static ulong Dialog_Delete(ulong o);
    [DllImport(InfraLib)] public extern static ulong Dialog_Init(ulong o);
    [DllImport(InfraLib)] public extern static ulong Dialog_Final(ulong o);
    [DllImport(InfraLib)] public extern static ulong Dialog_KindGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong Dialog_KindSet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong Dialog_ValueGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong Dialog_ValueSet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong Dialog_ModalGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong Dialog_ModalSet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong Dialog_VisibleGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong Dialog_VisibleSet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong Dialog_FinishedStateGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong Dialog_FinishedStateSet(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong Dialog_Done(ulong o, ulong result);

    public delegate ulong Dialog_Finished_Maide(ulong dialog, ulong result, ulong arg);

    [DllImport(InfraLib)] public extern static ulong DialogFile_New();
    [DllImport(InfraLib)] public extern static ulong DialogFile_Delete(ulong o);
    [DllImport(InfraLib)] public extern static ulong DialogFile_Init(ulong o);
    [DllImport(InfraLib)] public extern static ulong DialogFile_Final(ulong o);
    [DllImport(InfraLib)] public extern static ulong DialogFile_SaveGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong DialogFile_SaveSet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong DialogFile_FileModeGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong DialogFile_FileModeSet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong DialogFile_FoldGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong DialogFile_FoldSet(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong DialogFile_SelectedFileList(ulong o);
    [DllImport(InfraLib)] public extern static ulong DialogFile_SelectFile(ulong o, ulong fileName);

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

    [DllImport(InfraLib)] public extern static ulong VideoOut_SetVideoSubtitle(ulong o);

    public delegate ulong VideoOut_Frame_Maide(ulong videoOut, ulong frame, ulong arg);
    public delegate ulong VideoOut_Size_Maide(ulong videoOut, ulong size, ulong arg);

    [DllImport(InfraLib)] public extern static ulong VideoFrame_New();
    [DllImport(InfraLib)] public extern static ulong VideoFrame_Delete(ulong o);
    [DllImport(InfraLib)] public extern static ulong VideoFrame_Init(ulong o);
    [DllImport(InfraLib)] public extern static ulong VideoFrame_Final(ulong o);
    [DllImport(InfraLib)] public extern static ulong VideoFrame_SizeGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong VideoFrame_SizeSet(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong VideoFrame_GetImage(ulong o, ulong image);

    [DllImport(InfraLib)] public extern static ulong AudioOut_New();
    [DllImport(InfraLib)] public extern static ulong AudioOut_Delete(ulong o);
    [DllImport(InfraLib)] public extern static ulong AudioOut_Init(ulong o);
    [DllImport(InfraLib)] public extern static ulong AudioOut_Final(ulong o);
    [DllImport(InfraLib)] public extern static ulong AudioOut_MutedGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong AudioOut_MutedSet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong AudioOut_VolumeGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong AudioOut_VolumeSet(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong AudioEffect_New();
    [DllImport(InfraLib)] public extern static ulong AudioEffect_Delete(ulong o);
    [DllImport(InfraLib)] public extern static ulong AudioEffect_Init(ulong o);
    [DllImport(InfraLib)] public extern static ulong AudioEffect_Final(ulong o);
    [DllImport(InfraLib)] public extern static ulong AudioEffect_SourceGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong AudioEffect_SourceSet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong AudioEffect_VolumeGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong AudioEffect_VolumeSet(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong AudioEffect_SetAudioSource(ulong o);
    [DllImport(InfraLib)] public extern static ulong AudioEffect_Play(ulong o);
    [DllImport(InfraLib)] public extern static ulong AudioEffect_Stop(ulong o);

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

    [DllImport(InfraLib)] public extern static ulong Play_SetPlaySource(ulong o);
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

    [DllImport(InfraLib)] public extern static ulong Stream_GetCount(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stream_SetCount(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong Stream_GetPos(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stream_SetPos(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong Stream_HasCount(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stream_HasPos(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stream_CanRead(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stream_CanWrite(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stream_GetStatus(ulong o);
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

    [DllImport(InfraLib)] public extern static ulong Storage_SetCount(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong Storage_Open(ulong o);
    [DllImport(InfraLib)] public extern static ulong Storage_Close(ulong o);

    [DllImport(InfraLib)] public extern static ulong StorageArrange_New();
    [DllImport(InfraLib)] public extern static ulong StorageArrange_Delete(ulong o);
    [DllImport(InfraLib)] public extern static ulong StorageArrange_Init(ulong o);
    [DllImport(InfraLib)] public extern static ulong StorageArrange_Final(ulong o);
    [DllImport(InfraLib)] public extern static ulong StorageArrange_Copy(ulong o, ulong path, ulong destPath);
    [DllImport(InfraLib)] public extern static ulong StorageArrange_Rename(ulong o, ulong path, ulong destPath);
    [DllImport(InfraLib)] public extern static ulong StorageArrange_Remove(ulong o, ulong path);
    [DllImport(InfraLib)] public extern static ulong StorageArrange_Exist(ulong o, ulong path);
    [DllImport(InfraLib)] public extern static ulong StorageArrange_Link(ulong o, ulong path, ulong linkPath);
    [DllImport(InfraLib)] public extern static ulong StorageArrange_LinkTarget(ulong o, ulong path);
    [DllImport(InfraLib)] public extern static ulong StorageArrange_GetPermit(ulong o, ulong path);
    [DllImport(InfraLib)] public extern static ulong StorageArrange_SetPermit(ulong o, ulong path, ulong value);
    [DllImport(InfraLib)] public extern static ulong StorageArrange_MoveToTrash(ulong o, ulong path, ulong trashPath);
    [DllImport(InfraLib)] public extern static ulong StorageArrange_CreateFold(ulong o, ulong path, ulong permit);
    [DllImport(InfraLib)] public extern static ulong StorageArrange_CreateFoldToPath(ulong o, ulong path);
    [DllImport(InfraLib)] public extern static ulong StorageArrange_RemoveFold(ulong o, ulong path);
    [DllImport(InfraLib)] public extern static ulong StorageArrange_RemoveFoldRecursive(ulong o, ulong path);
    [DllImport(InfraLib)] public extern static ulong StorageArrange_RenameFold(ulong o, ulong path, ulong destPath);
    [DllImport(InfraLib)] public extern static ulong StorageArrange_EntryCount(ulong o, ulong foldPath);
    [DllImport(InfraLib)] public extern static ulong StorageArrange_EntryName(ulong o, ulong path);
    [DllImport(InfraLib)] public extern static ulong StorageArrange_BaseName(ulong o, ulong name);
    [DllImport(InfraLib)] public extern static ulong StorageArrange_Extension(ulong o, ulong name);
    [DllImport(InfraLib)] public extern static ulong StorageArrange_AbsolutePath(ulong o, ulong path);
    [DllImport(InfraLib)] public extern static ulong StorageArrange_RelativePath(ulong o, ulong path, ulong destPath);
    [DllImport(InfraLib)] public extern static ulong StorageArrange_CanonicalPath(ulong o, ulong path);
    [DllImport(InfraLib)] public extern static ulong StorageArrange_CleanPath(ulong o, ulong path);

    [DllImport(InfraLib)] public extern static ulong StorageWatch_New();
    [DllImport(InfraLib)] public extern static ulong StorageWatch_Delete(ulong o);
    [DllImport(InfraLib)] public extern static ulong StorageWatch_Init(ulong o);
    [DllImport(InfraLib)] public extern static ulong StorageWatch_Final(ulong o);
    [DllImport(InfraLib)] public extern static ulong StorageWatch_FileChangedStateGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong StorageWatch_FileChangedStateSet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong StorageWatch_FoldChangedStateGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong StorageWatch_FoldChangedStateSet(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong StorageWatch_AddPath(ulong o, ulong path);
    [DllImport(InfraLib)] public extern static ulong StorageWatch_AddPathList(ulong o, ulong pathList);
    [DllImport(InfraLib)] public extern static ulong StorageWatch_RemovePath(ulong o, ulong path);
    [DllImport(InfraLib)] public extern static ulong StorageWatch_RemovePathList(ulong o, ulong pathList);
    [DllImport(InfraLib)] public extern static ulong StorageWatch_FileList(ulong o);
    [DllImport(InfraLib)] public extern static ulong StorageWatch_FoldList(ulong o);

    public delegate ulong StorageWatch_FileChanged_Maide(ulong storageWatch, ulong path, ulong arg);
    public delegate ulong StorageWatch_FoldChanged_Maide(ulong storageWatch, ulong path, ulong arg);

    [DllImport(InfraLib)] public extern static ulong StorageEntry_New();
    [DllImport(InfraLib)] public extern static ulong StorageEntry_Delete(ulong o);
    [DllImport(InfraLib)] public extern static ulong StorageEntry_Init(ulong o);
    [DllImport(InfraLib)] public extern static ulong StorageEntry_Final(ulong o);
    [DllImport(InfraLib)] public extern static ulong StorageEntry_PathGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong StorageEntry_PathSet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong StorageEntry_KindGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong StorageEntry_KindSet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong StorageEntry_CountGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong StorageEntry_CountSet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong StorageEntry_IsReadableGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong StorageEntry_IsReadableSet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong StorageEntry_IsHiddenGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong StorageEntry_IsHiddenSet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong StorageEntry_IsExecutableGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong StorageEntry_IsExecutableSet(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong StorageEntry_CreateTime(ulong o, ulong result);
    [DllImport(InfraLib)] public extern static ulong StorageEntry_LastModifyTime(ulong o, ulong result);
    [DllImport(InfraLib)] public extern static ulong StorageEntry_LastReadTime(ulong o, ulong result);
    [DllImport(InfraLib)] public extern static ulong StorageEntry_InfoChangeTime(ulong o, ulong result);
    [DllImport(InfraLib)] public extern static ulong StorageEntry_Update(ulong o);

    [DllImport(InfraLib)] public extern static ulong Network_New();
    [DllImport(InfraLib)] public extern static ulong Network_Delete(ulong o);
    [DllImport(InfraLib)] public extern static ulong Network_Init(ulong o);
    [DllImport(InfraLib)] public extern static ulong Network_Final(ulong o);
    [DllImport(InfraLib)] public extern static ulong Network_HostNameGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong Network_HostNameSet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong Network_PortGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong Network_PortSet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong Network_StreamGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong Network_StreamSet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong Network_ReadyCountGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong Network_ReadyCountSet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong Network_StatusGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong Network_StatusSet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong Network_CaseGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong Network_CaseSet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong Network_CaseChangedStateGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong Network_CaseChangedStateSet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong Network_ErrorStateGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong Network_ErrorStateSet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong Network_ReadyReadStateGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong Network_ReadyReadStateSet(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong Network_Open(ulong o);
    [DllImport(InfraLib)] public extern static ulong Network_Close(ulong o);
    [DllImport(InfraLib)] public extern static ulong Network_Abort(ulong o);

    public delegate ulong Network_CaseChanged_Maide(ulong network, ulong arg);
    public delegate ulong Network_Error_Maide(ulong network, ulong arg);
    public delegate ulong Network_ReadyRead_Maide(ulong network, ulong arg);

    [DllImport(InfraLib)] public extern static ulong NetworkServer_New();
    [DllImport(InfraLib)] public extern static ulong NetworkServer_Delete(ulong o);
    [DllImport(InfraLib)] public extern static ulong NetworkServer_Init(ulong o);
    [DllImport(InfraLib)] public extern static ulong NetworkServer_Final(ulong o);
    [DllImport(InfraLib)] public extern static ulong NetworkServer_AddressGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong NetworkServer_AddressSet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong NetworkServer_PortGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong NetworkServer_PortSet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong NetworkServer_ErrorGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong NetworkServer_ErrorSet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong NetworkServer_NewPeerStateGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong NetworkServer_NewPeerStateSet(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong NetworkServer_Listen(ulong o);
    [DllImport(InfraLib)] public extern static ulong NetworkServer_Close(ulong o);
    [DllImport(InfraLib)] public extern static ulong NetworkServer_IsListen(ulong o);
    [DllImport(InfraLib)] public extern static ulong NetworkServer_NextPendingPeer(ulong o);
    [DllImport(InfraLib)] public extern static ulong NetworkServer_ClosePeer(ulong o, ulong network);
    [DllImport(InfraLib)] public extern static ulong NetworkServer_HasPendingPeer(ulong o);
    [DllImport(InfraLib)] public extern static ulong NetworkServer_PauseAccept(ulong o);
    [DllImport(InfraLib)] public extern static ulong NetworkServer_ResumeAccept(ulong o);

    public delegate ulong NetworkServer_NewPeer_Maide(ulong networkServer, ulong arg);

    [DllImport(InfraLib)] public extern static ulong NetworkAddress_New();
    [DllImport(InfraLib)] public extern static ulong NetworkAddress_Delete(ulong o);
    [DllImport(InfraLib)] public extern static ulong NetworkAddress_Init(ulong o);
    [DllImport(InfraLib)] public extern static ulong NetworkAddress_Final(ulong o);
    [DllImport(InfraLib)] public extern static ulong NetworkAddress_KindGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong NetworkAddress_KindSet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong NetworkAddress_ValueAGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong NetworkAddress_ValueASet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong NetworkAddress_ValueBGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong NetworkAddress_ValueBSet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong NetworkAddress_ValueCGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong NetworkAddress_ValueCSet(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong NetworkAddress_Set(ulong o);

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
    [DllImport(InfraLib)] public extern static ulong Thread_IsMainThread(ulong o);

    [DllImport(InfraLib)] public extern static ulong Thread_Sleep(ulong time);
    [DllImport(InfraLib)] public extern static ulong Thread_GetCurrentThread();

    public delegate ulong Thread_Execute_Maide(ulong thread, ulong arg);

    [DllImport(InfraLib)] public extern static ulong Mutex_New();
    [DllImport(InfraLib)] public extern static ulong Mutex_Delete(ulong o);
    [DllImport(InfraLib)] public extern static ulong Mutex_Init(ulong o);
    [DllImport(InfraLib)] public extern static ulong Mutex_Final(ulong o);
    [DllImport(InfraLib)] public extern static ulong Mutex_Acquire(ulong o);
    [DllImport(InfraLib)] public extern static ulong Mutex_Release(ulong o);

    [DllImport(InfraLib)] public extern static ulong Semaphore_New();
    [DllImport(InfraLib)] public extern static ulong Semaphore_Delete(ulong o);
    [DllImport(InfraLib)] public extern static ulong Semaphore_Init(ulong o);
    [DllImport(InfraLib)] public extern static ulong Semaphore_Final(ulong o);
    [DllImport(InfraLib)] public extern static ulong Semaphore_CountGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong Semaphore_CountSet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong Semaphore_InitCountGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong Semaphore_InitCountSet(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong Semaphore_Acquire(ulong o);
    [DllImport(InfraLib)] public extern static ulong Semaphore_Release(ulong o);

    [DllImport(InfraLib)] public extern static ulong Time_New();
    [DllImport(InfraLib)] public extern static ulong Time_Delete(ulong o);
    [DllImport(InfraLib)] public extern static ulong Time_Init(ulong o);
    [DllImport(InfraLib)] public extern static ulong Time_Final(ulong o);
    [DllImport(InfraLib)] public extern static ulong Time_YearGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong Time_YearSet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong Time_MonthGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong Time_MonthSet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong Time_DayGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong Time_DaySet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong Time_HourGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong Time_HourSet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong Time_MinuteGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong Time_MinuteSet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong Time_SecondGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong Time_SecondSet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong Time_MillisecondGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong Time_MillisecondSet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong Time_OffsetUtcGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong Time_OffsetUtcSet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong Time_LocalTimeGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong Time_LocalTimeSet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong Time_YearDayGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong Time_YearDaySet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong Time_WeekDayGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong Time_WeekDaySet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong Time_YearDayCountGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong Time_YearDayCountSet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong Time_MonthDayCountGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong Time_MonthDayCountSet(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong Time_AddYear(ulong o, ulong offset);
    [DllImport(InfraLib)] public extern static ulong Time_AddMonth(ulong o, ulong offset);
    [DllImport(InfraLib)] public extern static ulong Time_AddDay(ulong o, ulong offset);
    [DllImport(InfraLib)] public extern static ulong Time_AddHour(ulong o, ulong offset);
    [DllImport(InfraLib)] public extern static ulong Time_AddMinute(ulong o, ulong offset);
    [DllImport(InfraLib)] public extern static ulong Time_AddSecond(ulong o, ulong offset);
    [DllImport(InfraLib)] public extern static ulong Time_AddMillisecond(ulong o, ulong offset);
    [DllImport(InfraLib)] public extern static ulong Time_MillisecondTo(ulong o, ulong other);
    [DllImport(InfraLib)] public extern static ulong Time_DayTo(ulong o, ulong other);
    [DllImport(InfraLib)] public extern static ulong Time_Current(ulong o);
    [DllImport(InfraLib)] public extern static ulong Time_ToLocalTime(ulong o);
    [DllImport(InfraLib)] public extern static ulong Time_ToOffsetUtc(ulong o, ulong offset);
    [DllImport(InfraLib)] public extern static ulong Time_Set(ulong o, ulong year, ulong month, ulong day, ulong hour, ulong minute, ulong second, ulong millisecond, ulong hasOffset, ulong offsetUtc);

    [DllImport(InfraLib)] public extern static ulong Time_LeapYear(ulong year);
    [DllImport(InfraLib)] public extern static ulong Time_ValidDate(ulong year, ulong month, ulong day);
    [DllImport(InfraLib)] public extern static ulong Time_ValidTime(ulong hour, ulong minute, ulong second, ulong millisecond);

    [DllImport(InfraLib)] public extern static ulong Interval_New();
    [DllImport(InfraLib)] public extern static ulong Interval_Delete(ulong o);
    [DllImport(InfraLib)] public extern static ulong Interval_Init(ulong o);
    [DllImport(InfraLib)] public extern static ulong Interval_Final(ulong o);
    [DllImport(InfraLib)] public extern static ulong Interval_TimeGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong Interval_TimeSet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong Interval_SingleShotGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong Interval_SingleShotSet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong Interval_ActiveGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong Interval_ActiveSet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong Interval_ElapseStateGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong Interval_ElapseStateSet(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong Interval_Start(ulong o);
    [DllImport(InfraLib)] public extern static ulong Interval_Stop(ulong o);

    public delegate ulong Interval_Elapse_Maide(ulong interval, ulong arg);

    [DllImport(InfraLib)] public extern static ulong Post_New();
    [DllImport(InfraLib)] public extern static ulong Post_Delete(ulong o);
    [DllImport(InfraLib)] public extern static ulong Post_Init(ulong o);
    [DllImport(InfraLib)] public extern static ulong Post_Final(ulong o);
    [DllImport(InfraLib)] public extern static ulong Post_ExecuteStateGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong Post_ExecuteStateSet(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong Post_Execute(ulong o);

    public delegate ulong Post_Execute_Maide(ulong post, ulong arg);

    [DllImport(InfraLib)] public extern static ulong Process_New();
    [DllImport(InfraLib)] public extern static ulong Process_Delete(ulong o);
    [DllImport(InfraLib)] public extern static ulong Process_Init(ulong o);
    [DllImport(InfraLib)] public extern static ulong Process_Final(ulong o);
    [DllImport(InfraLib)] public extern static ulong Process_ProgramGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong Process_ProgramSet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong Process_ArgueGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong Process_ArgueSet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong Process_WorkFoldGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong Process_WorkFoldSet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong Process_EnvironmentGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong Process_EnvironmentSet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong Process_StartedStateGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong Process_StartedStateSet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong Process_FinishedStateGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong Process_FinishedStateSet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong Process_ReadOutStateGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong Process_ReadOutStateSet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong Process_ReadErrStateGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong Process_ReadErrStateSet(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong Process_Execute(ulong o);
    [DllImport(InfraLib)] public extern static ulong Process_GetIdent(ulong o);
    [DllImport(InfraLib)] public extern static ulong Process_Wait(ulong o);
    [DllImport(InfraLib)] public extern static ulong Process_Terminate(ulong o);
    [DllImport(InfraLib)] public extern static ulong Process_GetStatus(ulong o);
    [DllImport(InfraLib)] public extern static ulong Process_GetExitKind(ulong o);
    [DllImport(InfraLib)] public extern static ulong Process_ReadOut(ulong o);
    [DllImport(InfraLib)] public extern static ulong Process_ReadErr(ulong o);

    public delegate ulong Process_Started_Maide(ulong process, ulong arg);
    public delegate ulong Process_Finished_Maide(ulong process, ulong arg);
    public delegate ulong Process_ReadOut_Maide(ulong process, ulong arg);
    public delegate ulong Process_ReadErr_Maide(ulong process, ulong arg);

    [DllImport(InfraLib)] public extern static ulong ProcessSemaphore_New();
    [DllImport(InfraLib)] public extern static ulong ProcessSemaphore_Delete(ulong o);
    [DllImport(InfraLib)] public extern static ulong ProcessSemaphore_Init(ulong o);
    [DllImport(InfraLib)] public extern static ulong ProcessSemaphore_Final(ulong o);
    [DllImport(InfraLib)] public extern static ulong ProcessSemaphore_NameGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong ProcessSemaphore_NameSet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong ProcessSemaphore_InitCountGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong ProcessSemaphore_InitCountSet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong ProcessSemaphore_CreateGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong ProcessSemaphore_CreateSet(ulong o, ulong value);
    [DllImport(InfraLib)] public extern static ulong ProcessSemaphore_StatusGet(ulong o);
    [DllImport(InfraLib)] public extern static ulong ProcessSemaphore_StatusSet(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong ProcessSemaphore_Acquire(ulong o);
    [DllImport(InfraLib)] public extern static ulong ProcessSemaphore_Release(ulong o);

    [DllImport(InfraLib)] public extern static ulong Infra_Share();

    [DllImport(InfraLib)] public extern static ulong Share_Stat(ulong o);

    [DllImport(InfraLib)] public extern static ulong Stat_PointDataCount(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_TextEncodeKindUtf8(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_TextEncodeKindUtf16(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_TextEncodeKindUtf16LE(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_TextEncodeKindUtf16BE(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_TextEncodeKindUtf32(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_TextEncodeKindUtf32LE(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_TextEncodeKindUtf32BE(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_TextEncodeKindLatin1(ulong o);
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
    [DllImport(InfraLib)] public extern static ulong Stat_NetworkAddressKindIPv6(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_NetworkAddressKindIPv4(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_NetworkAddressKindBroadcast(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_NetworkAddressKindLocalHost(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_NetworkAddressKindLocalHostIPv6(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_NetworkAddressKindAny(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_NetworkAddressKindAnyIPv6(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_NetworkAddressKindAnyIPv4(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_NetworkCaseUnconnected(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_NetworkCaseHostLookup(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_NetworkCaseConnecting(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_NetworkCaseConnected(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_NetworkCaseBound(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_NetworkCaseListening(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_NetworkCaseClosing(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_NetworkStatusNoError(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_NetworkStatusUnknownSocketError(ulong o);
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
    [DllImport(InfraLib)] public extern static ulong Stat_BrushKindSolid(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_BrushKindDense1(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_BrushKindDense2(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_BrushKindDense3(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_BrushKindDense4(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_BrushKindDense5(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_BrushKindDense6(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_BrushKindDense7(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_BrushKindHor(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_BrushKindVer(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_BrushKindCross(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_BrushKindBDiag(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_BrushKindFDiag(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_BrushKindDiagCross(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_BrushKindLinearGradient(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_BrushKindRadialGradient(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_BrushKindConicalGradient(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_BrushKindTexture(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_PenKindSolid(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_PenKindDash(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_PenKindDot(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_PenKindDashDot(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_PenKindDashDotDot(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_PenKindCustomDash(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_PenCapFlat(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_PenCapSquare(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_PenCapRound(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_PenJoinMiter(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_PenJoinBevel(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_PenJoinRound(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_PenJoinSvgMiter(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_CompositeSourceOver(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_CompositeDestinationOver(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_CompositeClear(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_CompositeSource(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_CompositeDestination(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_CompositeSourceIn(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_CompositeDestinationIn(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_CompositeSourceOut(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_CompositeDestinationOut(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_CompositeSourceAtop(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_CompositeDestinationAtop(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_CompositeXor(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_CompositePlus(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_CompositeMultiply(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_CompositeScreen(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_CompositeOverlay(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_CompositeDarken(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_CompositeLighten(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_CompositeColorDodge(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_CompositeColorBurn(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_CompositeHardLight(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_CompositeSoftLight(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_CompositeDifference(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_CompositeExclusion(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_GradientKindLinear(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_GradientKindRadial(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_GradientKindConical(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_GradientSpreadPad(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_GradientSpreadReflect(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_GradientSpreadRepeat(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_TextAlignLeft(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_TextAlignRight(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_TextAlignHCenter(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_TextAlignJustify(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_TextAlignTop(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_TextAlignBottom(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_TextAlignVCenter(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_TextWrapWordWrap(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_ImageFormatBmp(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_ImageFormatJpg(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stat_ImageFormatPng(ulong o);

}