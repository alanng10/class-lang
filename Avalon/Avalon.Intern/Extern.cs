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


    [DllImport(InfraLib)] public extern static ulong String_GetCount(ulong o);
    [DllImport(InfraLib)] public extern static ulong String_SetCount(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong String_GetData(ulong o);
    [DllImport(InfraLib)] public extern static ulong String_SetData(ulong o, ulong value);


    [DllImport(InfraLib)] public extern static ulong String_Char(ulong o, ulong index);

    [DllImport(InfraLib)] public extern static ulong String_Equal(ulong o, ulong other);


    [DllImport(InfraLib)] public extern static ulong String_ConstantCreate(ulong o);

    [DllImport(InfraLib)] public extern static ulong String_ConstantDelete(ulong o);



    [DllImport(InfraLib)] public extern static ulong Return_New();

    [DllImport(InfraLib)] public extern static ulong Return_Delete(ulong o);

    [DllImport(InfraLib)] public extern static ulong Return_Init(ulong o);

    [DllImport(InfraLib)] public extern static ulong Return_Final(ulong o);


    [DllImport(InfraLib)] public extern static ulong Return_GetString(ulong o);
    [DllImport(InfraLib)] public extern static ulong Return_SetString(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong Return_GetStringList(ulong o);
    [DllImport(InfraLib)] public extern static ulong Return_SetStringList(ulong o, ulong value);


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


    [DllImport(InfraLib)] public extern static ulong Array_GetCount(ulong o);
    [DllImport(InfraLib)] public extern static ulong Array_SetCount(ulong o, ulong value);


    [DllImport(InfraLib)] public extern static ulong Array_GetItem(ulong o, ulong index);

    [DllImport(InfraLib)] public extern static ulong Array_SetItem(ulong o, ulong index, ulong value);



    [DllImport(InfraLib)] public extern static ulong TextEncode_New();

    [DllImport(InfraLib)] public extern static ulong TextEncode_Delete(ulong o);

    [DllImport(InfraLib)] public extern static ulong TextEncode_Init(ulong o);

    [DllImport(InfraLib)] public extern static ulong TextEncode_Final(ulong o);


    [DllImport(InfraLib)] public extern static ulong TextEncode_GetKind(ulong o);
    [DllImport(InfraLib)] public extern static ulong TextEncode_SetKind(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong TextEncode_GetWriteBom(ulong o);
    [DllImport(InfraLib)] public extern static ulong TextEncode_SetWriteBom(ulong o, ulong value);


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


    [DllImport(InfraLib)] public extern static ulong FormatArg_GetPos(ulong o);
    [DllImport(InfraLib)] public extern static ulong FormatArg_SetPos(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong FormatArg_GetKind(ulong o);
    [DllImport(InfraLib)] public extern static ulong FormatArg_SetKind(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong FormatArg_GetValue(ulong o);
    [DllImport(InfraLib)] public extern static ulong FormatArg_SetValue(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong FormatArg_GetAlignLeft(ulong o);
    [DllImport(InfraLib)] public extern static ulong FormatArg_SetAlignLeft(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong FormatArg_GetFieldWidth(ulong o);
    [DllImport(InfraLib)] public extern static ulong FormatArg_SetFieldWidth(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong FormatArg_GetMaxWidth(ulong o);
    [DllImport(InfraLib)] public extern static ulong FormatArg_SetMaxWidth(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong FormatArg_GetCase(ulong o);
    [DllImport(InfraLib)] public extern static ulong FormatArg_SetCase(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong FormatArg_GetBase(ulong o);
    [DllImport(InfraLib)] public extern static ulong FormatArg_SetBase(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong FormatArg_GetSign(ulong o);
    [DllImport(InfraLib)] public extern static ulong FormatArg_SetSign(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong FormatArg_GetPrecision(ulong o);
    [DllImport(InfraLib)] public extern static ulong FormatArg_SetPrecision(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong FormatArg_GetFillChar(ulong o);
    [DllImport(InfraLib)] public extern static ulong FormatArg_SetFillChar(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong FormatArg_GetHasCount(ulong o);
    [DllImport(InfraLib)] public extern static ulong FormatArg_SetHasCount(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong FormatArg_GetValueCount(ulong o);
    [DllImport(InfraLib)] public extern static ulong FormatArg_SetValueCount(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong FormatArg_GetCount(ulong o);
    [DllImport(InfraLib)] public extern static ulong FormatArg_SetCount(ulong o, ulong value);



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


    [DllImport(InfraLib)] public extern static ulong Random_GetSeed(ulong o);
    [DllImport(InfraLib)] public extern static ulong Random_SetSeed(ulong o, ulong value);


    [DllImport(InfraLib)] public extern static ulong Random_Execute(ulong o);



    [DllImport(InfraLib)] public extern static ulong Range_New();

    [DllImport(InfraLib)] public extern static ulong Range_Delete(ulong o);

    [DllImport(InfraLib)] public extern static ulong Range_Init(ulong o);

    [DllImport(InfraLib)] public extern static ulong Range_Final(ulong o);


    [DllImport(InfraLib)] public extern static ulong Range_GetStart(ulong o);
    [DllImport(InfraLib)] public extern static ulong Range_SetStart(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong Range_GetEnd(ulong o);
    [DllImport(InfraLib)] public extern static ulong Range_SetEnd(ulong o, ulong value);



    [DllImport(InfraLib)] public extern static ulong Rect_New();

    [DllImport(InfraLib)] public extern static ulong Rect_Delete(ulong o);

    [DllImport(InfraLib)] public extern static ulong Rect_Init(ulong o);

    [DllImport(InfraLib)] public extern static ulong Rect_Final(ulong o);


    [DllImport(InfraLib)] public extern static ulong Rect_GetPos(ulong o);
    [DllImport(InfraLib)] public extern static ulong Rect_SetPos(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong Rect_GetSize(ulong o);
    [DllImport(InfraLib)] public extern static ulong Rect_SetSize(ulong o, ulong value);



    [DllImport(InfraLib)] public extern static ulong Pos_New();

    [DllImport(InfraLib)] public extern static ulong Pos_Delete(ulong o);

    [DllImport(InfraLib)] public extern static ulong Pos_Init(ulong o);

    [DllImport(InfraLib)] public extern static ulong Pos_Final(ulong o);


    [DllImport(InfraLib)] public extern static ulong Pos_GetLeft(ulong o);
    [DllImport(InfraLib)] public extern static ulong Pos_SetLeft(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong Pos_GetUp(ulong o);
    [DllImport(InfraLib)] public extern static ulong Pos_SetUp(ulong o, ulong value);



    [DllImport(InfraLib)] public extern static ulong Size_New();

    [DllImport(InfraLib)] public extern static ulong Size_Delete(ulong o);

    [DllImport(InfraLib)] public extern static ulong Size_Init(ulong o);

    [DllImport(InfraLib)] public extern static ulong Size_Final(ulong o);


    [DllImport(InfraLib)] public extern static ulong Size_GetWidth(ulong o);
    [DllImport(InfraLib)] public extern static ulong Size_SetWidth(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong Size_GetHeight(ulong o);
    [DllImport(InfraLib)] public extern static ulong Size_SetHeight(ulong o, ulong value);



    [DllImport(InfraLib)] public extern static ulong Data_New();

    [DllImport(InfraLib)] public extern static ulong Data_Delete(ulong o);

    [DllImport(InfraLib)] public extern static ulong Data_Init(ulong o);

    [DllImport(InfraLib)] public extern static ulong Data_Final(ulong o);


    [DllImport(InfraLib)] public extern static ulong Data_GetCount(ulong o);
    [DllImport(InfraLib)] public extern static ulong Data_SetCount(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong Data_GetValue(ulong o);
    [DllImport(InfraLib)] public extern static ulong Data_SetValue(ulong o, ulong value);



    [DllImport(InfraLib)] public extern static ulong Entry_New();

    [DllImport(InfraLib)] public extern static ulong Entry_Delete(ulong o);

    [DllImport(InfraLib)] public extern static ulong Entry_Init(ulong o);

    [DllImport(InfraLib)] public extern static ulong Entry_Final(ulong o);


    [DllImport(InfraLib)] public extern static ulong Entry_GetIndex(ulong o);
    [DllImport(InfraLib)] public extern static ulong Entry_SetIndex(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong Entry_GetValue(ulong o);
    [DllImport(InfraLib)] public extern static ulong Entry_SetValue(ulong o, ulong value);



    [DllImport(InfraLib)] public extern static ulong State_New();

    [DllImport(InfraLib)] public extern static ulong State_Delete(ulong o);

    [DllImport(InfraLib)] public extern static ulong State_Init(ulong o);

    [DllImport(InfraLib)] public extern static ulong State_Final(ulong o);


    [DllImport(InfraLib)] public extern static ulong State_GetMaide(ulong o);
    [DllImport(InfraLib)] public extern static ulong State_SetMaide(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong State_GetArg(ulong o);
    [DllImport(InfraLib)] public extern static ulong State_SetArg(ulong o, ulong value);



    [DllImport(InfraLib)] public extern static ulong Main_GetTerminateState();
    [DllImport(InfraLib)] public extern static ulong Main_SetTerminateState(ulong value);


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


    [DllImport(InfraLib)] public extern static ulong Frame_GetTitle(ulong o);
    [DllImport(InfraLib)] public extern static ulong Frame_SetTitle(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong Frame_GetVisible(ulong o);
    [DllImport(InfraLib)] public extern static ulong Frame_SetVisible(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong Frame_GetResizeState(ulong o);
    [DllImport(InfraLib)] public extern static ulong Frame_SetResizeState(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong Frame_GetTypeState(ulong o);
    [DllImport(InfraLib)] public extern static ulong Frame_SetTypeState(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong Frame_GetMouseState(ulong o);
    [DllImport(InfraLib)] public extern static ulong Frame_SetMouseState(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong Frame_GetDrawState(ulong o);
    [DllImport(InfraLib)] public extern static ulong Frame_SetDrawState(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong Frame_GetWindowStat(ulong o);
    [DllImport(InfraLib)] public extern static ulong Frame_SetWindowStat(ulong o, ulong value);


    [DllImport(InfraLib)] public extern static ulong Frame_GetVideoOut(ulong o);

    [DllImport(InfraLib)] public extern static ulong Frame_GetSize(ulong o);

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


    [DllImport(InfraLib)] public extern static ulong Draw_GetSize(ulong o);
    [DllImport(InfraLib)] public extern static ulong Draw_SetSize(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong Draw_GetOut(ulong o);
    [DllImport(InfraLib)] public extern static ulong Draw_SetOut(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong Draw_GetArea(ulong o);
    [DllImport(InfraLib)] public extern static ulong Draw_SetArea(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong Draw_GetFillPos(ulong o);
    [DllImport(InfraLib)] public extern static ulong Draw_SetFillPos(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong Draw_GetBrush(ulong o);
    [DllImport(InfraLib)] public extern static ulong Draw_SetBrush(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong Draw_GetPen(ulong o);
    [DllImport(InfraLib)] public extern static ulong Draw_SetPen(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong Draw_GetFont(ulong o);
    [DllImport(InfraLib)] public extern static ulong Draw_SetFont(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong Draw_GetTransform(ulong o);
    [DllImport(InfraLib)] public extern static ulong Draw_SetTransform(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong Draw_GetComposite(ulong o);
    [DllImport(InfraLib)] public extern static ulong Draw_SetComposite(ulong o, ulong value);


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


    [DllImport(InfraLib)] public extern static ulong Brush_GetKind(ulong o);
    [DllImport(InfraLib)] public extern static ulong Brush_SetKind(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong Brush_GetColor(ulong o);
    [DllImport(InfraLib)] public extern static ulong Brush_SetColor(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong Brush_GetImage(ulong o);
    [DllImport(InfraLib)] public extern static ulong Brush_SetImage(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong Brush_GetGradient(ulong o);
    [DllImport(InfraLib)] public extern static ulong Brush_SetGradient(ulong o, ulong value);



    [DllImport(InfraLib)] public extern static ulong Pen_New();

    [DllImport(InfraLib)] public extern static ulong Pen_Delete(ulong o);

    [DllImport(InfraLib)] public extern static ulong Pen_Init(ulong o);

    [DllImport(InfraLib)] public extern static ulong Pen_Final(ulong o);


    [DllImport(InfraLib)] public extern static ulong Pen_GetKind(ulong o);
    [DllImport(InfraLib)] public extern static ulong Pen_SetKind(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong Pen_GetWidth(ulong o);
    [DllImport(InfraLib)] public extern static ulong Pen_SetWidth(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong Pen_GetBrush(ulong o);
    [DllImport(InfraLib)] public extern static ulong Pen_SetBrush(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong Pen_GetCap(ulong o);
    [DllImport(InfraLib)] public extern static ulong Pen_SetCap(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong Pen_GetJoin(ulong o);
    [DllImport(InfraLib)] public extern static ulong Pen_SetJoin(ulong o, ulong value);



    [DllImport(InfraLib)] public extern static ulong PointData_GetPoint(ulong address, ulong result);

    [DllImport(InfraLib)] public extern static ulong PointData_SetPoint(ulong address, ulong pos);



    [DllImport(InfraLib)] public extern static ulong Image_New();

    [DllImport(InfraLib)] public extern static ulong Image_Delete(ulong o);

    [DllImport(InfraLib)] public extern static ulong Image_Init(ulong o);

    [DllImport(InfraLib)] public extern static ulong Image_Final(ulong o);


    [DllImport(InfraLib)] public extern static ulong Image_GetSize(ulong o);
    [DllImport(InfraLib)] public extern static ulong Image_SetSize(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong Image_GetData(ulong o);
    [DllImport(InfraLib)] public extern static ulong Image_SetData(ulong o, ulong value);


    [DllImport(InfraLib)] public extern static ulong Image_GetRowByteCount(ulong o);

    [DllImport(InfraLib)] public extern static ulong Image_GetVideoOut(ulong o);

    [DllImport(InfraLib)] public extern static ulong Image_CreateData(ulong o);



    [DllImport(InfraLib)] public extern static ulong Font_New();

    [DllImport(InfraLib)] public extern static ulong Font_Delete(ulong o);

    [DllImport(InfraLib)] public extern static ulong Font_Init(ulong o);

    [DllImport(InfraLib)] public extern static ulong Font_Final(ulong o);


    [DllImport(InfraLib)] public extern static ulong Font_GetFamily(ulong o);
    [DllImport(InfraLib)] public extern static ulong Font_SetFamily(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong Font_GetSize(ulong o);
    [DllImport(InfraLib)] public extern static ulong Font_SetSize(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong Font_GetWeight(ulong o);
    [DllImport(InfraLib)] public extern static ulong Font_SetWeight(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong Font_GetItalic(ulong o);
    [DllImport(InfraLib)] public extern static ulong Font_SetItalic(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong Font_GetUnderline(ulong o);
    [DllImport(InfraLib)] public extern static ulong Font_SetUnderline(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong Font_GetOverline(ulong o);
    [DllImport(InfraLib)] public extern static ulong Font_SetOverline(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong Font_GetStrikeout(ulong o);
    [DllImport(InfraLib)] public extern static ulong Font_SetStrikeout(ulong o, ulong value);



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


    [DllImport(InfraLib)] public extern static ulong Gradient_GetKind(ulong o);
    [DllImport(InfraLib)] public extern static ulong Gradient_SetKind(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong Gradient_GetValue(ulong o);
    [DllImport(InfraLib)] public extern static ulong Gradient_SetValue(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong Gradient_GetStop(ulong o);
    [DllImport(InfraLib)] public extern static ulong Gradient_SetStop(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong Gradient_GetSpread(ulong o);
    [DllImport(InfraLib)] public extern static ulong Gradient_SetSpread(ulong o, ulong value);



    [DllImport(InfraLib)] public extern static ulong GradientLinear_New();

    [DllImport(InfraLib)] public extern static ulong GradientLinear_Delete(ulong o);

    [DllImport(InfraLib)] public extern static ulong GradientLinear_Init(ulong o);

    [DllImport(InfraLib)] public extern static ulong GradientLinear_Final(ulong o);


    [DllImport(InfraLib)] public extern static ulong GradientLinear_GetStartPos(ulong o);
    [DllImport(InfraLib)] public extern static ulong GradientLinear_SetStartPos(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong GradientLinear_GetEndPos(ulong o);
    [DllImport(InfraLib)] public extern static ulong GradientLinear_SetEndPos(ulong o, ulong value);



    [DllImport(InfraLib)] public extern static ulong GradientRadial_New();

    [DllImport(InfraLib)] public extern static ulong GradientRadial_Delete(ulong o);

    [DllImport(InfraLib)] public extern static ulong GradientRadial_Init(ulong o);

    [DllImport(InfraLib)] public extern static ulong GradientRadial_Final(ulong o);


    [DllImport(InfraLib)] public extern static ulong GradientRadial_GetCenterPos(ulong o);
    [DllImport(InfraLib)] public extern static ulong GradientRadial_SetCenterPos(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong GradientRadial_GetCenterRadius(ulong o);
    [DllImport(InfraLib)] public extern static ulong GradientRadial_SetCenterRadius(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong GradientRadial_GetFocusPos(ulong o);
    [DllImport(InfraLib)] public extern static ulong GradientRadial_SetFocusPos(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong GradientRadial_GetFocusRadius(ulong o);
    [DllImport(InfraLib)] public extern static ulong GradientRadial_SetFocusRadius(ulong o, ulong value);



    [DllImport(InfraLib)] public extern static ulong GradientStop_New();

    [DllImport(InfraLib)] public extern static ulong GradientStop_Delete(ulong o);

    [DllImport(InfraLib)] public extern static ulong GradientStop_Init(ulong o);

    [DllImport(InfraLib)] public extern static ulong GradientStop_Final(ulong o);


    [DllImport(InfraLib)] public extern static ulong GradientStop_GetCount(ulong o);
    [DllImport(InfraLib)] public extern static ulong GradientStop_SetCount(ulong o, ulong value);


    [DllImport(InfraLib)] public extern static ulong GradientStop_GetPoint(ulong o, ulong index, ulong pos, ulong color);

    [DllImport(InfraLib)] public extern static ulong GradientStop_SetPoint(ulong o, ulong index, ulong pos, ulong color);



    [DllImport(InfraLib)] public extern static ulong ImageRead_New();

    [DllImport(InfraLib)] public extern static ulong ImageRead_Delete(ulong o);

    [DllImport(InfraLib)] public extern static ulong ImageRead_Init(ulong o);

    [DllImport(InfraLib)] public extern static ulong ImageRead_Final(ulong o);


    [DllImport(InfraLib)] public extern static ulong ImageRead_GetStream(ulong o);
    [DllImport(InfraLib)] public extern static ulong ImageRead_SetStream(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong ImageRead_GetImage(ulong o);
    [DllImport(InfraLib)] public extern static ulong ImageRead_SetImage(ulong o, ulong value);


    [DllImport(InfraLib)] public extern static ulong ImageRead_Execute(ulong o);



    [DllImport(InfraLib)] public extern static ulong ImageWrite_New();

    [DllImport(InfraLib)] public extern static ulong ImageWrite_Delete(ulong o);

    [DllImport(InfraLib)] public extern static ulong ImageWrite_Init(ulong o);

    [DllImport(InfraLib)] public extern static ulong ImageWrite_Final(ulong o);


    [DllImport(InfraLib)] public extern static ulong ImageWrite_GetStream(ulong o);
    [DllImport(InfraLib)] public extern static ulong ImageWrite_SetStream(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong ImageWrite_GetImage(ulong o);
    [DllImport(InfraLib)] public extern static ulong ImageWrite_SetImage(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong ImageWrite_GetFormat(ulong o);
    [DllImport(InfraLib)] public extern static ulong ImageWrite_SetFormat(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong ImageWrite_GetQuality(ulong o);
    [DllImport(InfraLib)] public extern static ulong ImageWrite_SetQuality(ulong o, ulong value);


    [DllImport(InfraLib)] public extern static ulong ImageWrite_Execute(ulong o);



    [DllImport(InfraLib)] public extern static ulong Dialog_New();

    [DllImport(InfraLib)] public extern static ulong Dialog_Delete(ulong o);

    [DllImport(InfraLib)] public extern static ulong Dialog_Init(ulong o);

    [DllImport(InfraLib)] public extern static ulong Dialog_Final(ulong o);


    [DllImport(InfraLib)] public extern static ulong Dialog_GetKind(ulong o);
    [DllImport(InfraLib)] public extern static ulong Dialog_SetKind(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong Dialog_GetValue(ulong o);
    [DllImport(InfraLib)] public extern static ulong Dialog_SetValue(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong Dialog_GetModal(ulong o);
    [DllImport(InfraLib)] public extern static ulong Dialog_SetModal(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong Dialog_GetVisible(ulong o);
    [DllImport(InfraLib)] public extern static ulong Dialog_SetVisible(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong Dialog_GetFinishedState(ulong o);
    [DllImport(InfraLib)] public extern static ulong Dialog_SetFinishedState(ulong o, ulong value);


    [DllImport(InfraLib)] public extern static ulong Dialog_Done(ulong o, ulong result);


    public delegate ulong Dialog_Finished_Maide(ulong dialog, ulong result, ulong arg);



    [DllImport(InfraLib)] public extern static ulong DialogFile_New();

    [DllImport(InfraLib)] public extern static ulong DialogFile_Delete(ulong o);

    [DllImport(InfraLib)] public extern static ulong DialogFile_Init(ulong o);

    [DllImport(InfraLib)] public extern static ulong DialogFile_Final(ulong o);


    [DllImport(InfraLib)] public extern static ulong DialogFile_GetSave(ulong o);
    [DllImport(InfraLib)] public extern static ulong DialogFile_SetSave(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong DialogFile_GetFileMode(ulong o);
    [DllImport(InfraLib)] public extern static ulong DialogFile_SetFileMode(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong DialogFile_GetFold(ulong o);
    [DllImport(InfraLib)] public extern static ulong DialogFile_SetFold(ulong o, ulong value);


    [DllImport(InfraLib)] public extern static ulong DialogFile_SelectedFileList(ulong o);

    [DllImport(InfraLib)] public extern static ulong DialogFile_SelectFile(ulong o, ulong fileName);



    [DllImport(InfraLib)] public extern static ulong VideoOut_New();

    [DllImport(InfraLib)] public extern static ulong VideoOut_Delete(ulong o);

    [DllImport(InfraLib)] public extern static ulong VideoOut_Init(ulong o);

    [DllImport(InfraLib)] public extern static ulong VideoOut_Final(ulong o);


    [DllImport(InfraLib)] public extern static ulong VideoOut_GetSize(ulong o);
    [DllImport(InfraLib)] public extern static ulong VideoOut_SetSize(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong VideoOut_GetFrame(ulong o);
    [DllImport(InfraLib)] public extern static ulong VideoOut_SetFrame(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong VideoOut_GetSubtitle(ulong o);
    [DllImport(InfraLib)] public extern static ulong VideoOut_SetSubtitle(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong VideoOut_GetFrameState(ulong o);
    [DllImport(InfraLib)] public extern static ulong VideoOut_SetFrameState(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong VideoOut_GetSizeState(ulong o);
    [DllImport(InfraLib)] public extern static ulong VideoOut_SetSizeState(ulong o, ulong value);


    [DllImport(InfraLib)] public extern static ulong VideoOut_SetVideoSubtitle(ulong o);


    public delegate ulong VideoOut_Frame_Maide(ulong videoOut, ulong frame, ulong arg);

    public delegate ulong VideoOut_Size_Maide(ulong videoOut, ulong size, ulong arg);



    [DllImport(InfraLib)] public extern static ulong VideoFrame_New();

    [DllImport(InfraLib)] public extern static ulong VideoFrame_Delete(ulong o);

    [DllImport(InfraLib)] public extern static ulong VideoFrame_Init(ulong o);

    [DllImport(InfraLib)] public extern static ulong VideoFrame_Final(ulong o);


    [DllImport(InfraLib)] public extern static ulong VideoFrame_GetSize(ulong o);
    [DllImport(InfraLib)] public extern static ulong VideoFrame_SetSize(ulong o, ulong value);


    [DllImport(InfraLib)] public extern static ulong VideoFrame_GetImage(ulong o, ulong image);



    [DllImport(InfraLib)] public extern static ulong AudioOut_New();

    [DllImport(InfraLib)] public extern static ulong AudioOut_Delete(ulong o);

    [DllImport(InfraLib)] public extern static ulong AudioOut_Init(ulong o);

    [DllImport(InfraLib)] public extern static ulong AudioOut_Final(ulong o);


    [DllImport(InfraLib)] public extern static ulong AudioOut_GetMuted(ulong o);
    [DllImport(InfraLib)] public extern static ulong AudioOut_SetMuted(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong AudioOut_GetVolume(ulong o);
    [DllImport(InfraLib)] public extern static ulong AudioOut_SetVolume(ulong o, ulong value);



    [DllImport(InfraLib)] public extern static ulong AudioEffect_New();

    [DllImport(InfraLib)] public extern static ulong AudioEffect_Delete(ulong o);

    [DllImport(InfraLib)] public extern static ulong AudioEffect_Init(ulong o);

    [DllImport(InfraLib)] public extern static ulong AudioEffect_Final(ulong o);


    [DllImport(InfraLib)] public extern static ulong AudioEffect_GetSource(ulong o);
    [DllImport(InfraLib)] public extern static ulong AudioEffect_SetSource(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong AudioEffect_GetVolume(ulong o);
    [DllImport(InfraLib)] public extern static ulong AudioEffect_SetVolume(ulong o, ulong value);


    [DllImport(InfraLib)] public extern static ulong AudioEffect_SetAudioSource(ulong o);

    [DllImport(InfraLib)] public extern static ulong AudioEffect_Play(ulong o);

    [DllImport(InfraLib)] public extern static ulong AudioEffect_Stop(ulong o);



    [DllImport(InfraLib)] public extern static ulong Play_New();

    [DllImport(InfraLib)] public extern static ulong Play_Delete(ulong o);

    [DllImport(InfraLib)] public extern static ulong Play_Init(ulong o);

    [DllImport(InfraLib)] public extern static ulong Play_Final(ulong o);


    [DllImport(InfraLib)] public extern static ulong Play_GetSource(ulong o);
    [DllImport(InfraLib)] public extern static ulong Play_SetSource(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong Play_GetVideoOut(ulong o);
    [DllImport(InfraLib)] public extern static ulong Play_SetVideoOut(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong Play_GetAudioOut(ulong o);
    [DllImport(InfraLib)] public extern static ulong Play_SetAudioOut(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong Play_GetTime(ulong o);
    [DllImport(InfraLib)] public extern static ulong Play_SetTime(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong Play_GetPos(ulong o);
    [DllImport(InfraLib)] public extern static ulong Play_SetPos(ulong o, ulong value);


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


    [DllImport(InfraLib)] public extern static ulong Stream_GetKind(ulong o);
    [DllImport(InfraLib)] public extern static ulong Stream_SetKind(ulong o, ulong value);


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


    [DllImport(InfraLib)] public extern static ulong Memory_GetStream(ulong o);
    [DllImport(InfraLib)] public extern static ulong Memory_SetStream(ulong o, ulong value);


    [DllImport(InfraLib)] public extern static ulong Memory_Open(ulong o);

    [DllImport(InfraLib)] public extern static ulong Memory_Close(ulong o);



    [DllImport(InfraLib)] public extern static ulong Storage_New();

    [DllImport(InfraLib)] public extern static ulong Storage_Delete(ulong o);

    [DllImport(InfraLib)] public extern static ulong Storage_Init(ulong o);

    [DllImport(InfraLib)] public extern static ulong Storage_Final(ulong o);


    [DllImport(InfraLib)] public extern static ulong Storage_GetPath(ulong o);
    [DllImport(InfraLib)] public extern static ulong Storage_SetPath(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong Storage_GetMode(ulong o);
    [DllImport(InfraLib)] public extern static ulong Storage_SetMode(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong Storage_GetStream(ulong o);
    [DllImport(InfraLib)] public extern static ulong Storage_SetStream(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong Storage_GetStatus(ulong o);
    [DllImport(InfraLib)] public extern static ulong Storage_SetStatus(ulong o, ulong value);


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


    [DllImport(InfraLib)] public extern static ulong StorageWatch_GetFileChangedState(ulong o);
    [DllImport(InfraLib)] public extern static ulong StorageWatch_SetFileChangedState(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong StorageWatch_GetFoldChangedState(ulong o);
    [DllImport(InfraLib)] public extern static ulong StorageWatch_SetFoldChangedState(ulong o, ulong value);


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


    [DllImport(InfraLib)] public extern static ulong StorageEntry_GetPath(ulong o);
    [DllImport(InfraLib)] public extern static ulong StorageEntry_SetPath(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong StorageEntry_GetKind(ulong o);
    [DllImport(InfraLib)] public extern static ulong StorageEntry_SetKind(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong StorageEntry_GetCount(ulong o);
    [DllImport(InfraLib)] public extern static ulong StorageEntry_SetCount(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong StorageEntry_GetIsReadable(ulong o);
    [DllImport(InfraLib)] public extern static ulong StorageEntry_SetIsReadable(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong StorageEntry_GetIsHidden(ulong o);
    [DllImport(InfraLib)] public extern static ulong StorageEntry_SetIsHidden(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong StorageEntry_GetIsExecutable(ulong o);
    [DllImport(InfraLib)] public extern static ulong StorageEntry_SetIsExecutable(ulong o, ulong value);


    [DllImport(InfraLib)] public extern static ulong StorageEntry_CreateTime(ulong o, ulong result);

    [DllImport(InfraLib)] public extern static ulong StorageEntry_LastModifyTime(ulong o, ulong result);

    [DllImport(InfraLib)] public extern static ulong StorageEntry_LastReadTime(ulong o, ulong result);

    [DllImport(InfraLib)] public extern static ulong StorageEntry_InfoChangeTime(ulong o, ulong result);

    [DllImport(InfraLib)] public extern static ulong StorageEntry_Update(ulong o);



    [DllImport(InfraLib)] public extern static ulong Network_New();

    [DllImport(InfraLib)] public extern static ulong Network_Delete(ulong o);

    [DllImport(InfraLib)] public extern static ulong Network_Init(ulong o);

    [DllImport(InfraLib)] public extern static ulong Network_Final(ulong o);


    [DllImport(InfraLib)] public extern static ulong Network_GetHostName(ulong o);
    [DllImport(InfraLib)] public extern static ulong Network_SetHostName(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong Network_GetPort(ulong o);
    [DllImport(InfraLib)] public extern static ulong Network_SetPort(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong Network_GetStream(ulong o);
    [DllImport(InfraLib)] public extern static ulong Network_SetStream(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong Network_GetReadyCount(ulong o);
    [DllImport(InfraLib)] public extern static ulong Network_SetReadyCount(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong Network_GetStatus(ulong o);
    [DllImport(InfraLib)] public extern static ulong Network_SetStatus(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong Network_GetCase(ulong o);
    [DllImport(InfraLib)] public extern static ulong Network_SetCase(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong Network_GetCaseChangedState(ulong o);
    [DllImport(InfraLib)] public extern static ulong Network_SetCaseChangedState(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong Network_GetErrorState(ulong o);
    [DllImport(InfraLib)] public extern static ulong Network_SetErrorState(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong Network_GetReadyReadState(ulong o);
    [DllImport(InfraLib)] public extern static ulong Network_SetReadyReadState(ulong o, ulong value);


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


    [DllImport(InfraLib)] public extern static ulong NetworkServer_GetAddress(ulong o);
    [DllImport(InfraLib)] public extern static ulong NetworkServer_SetAddress(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong NetworkServer_GetPort(ulong o);
    [DllImport(InfraLib)] public extern static ulong NetworkServer_SetPort(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong NetworkServer_GetError(ulong o);
    [DllImport(InfraLib)] public extern static ulong NetworkServer_SetError(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong NetworkServer_GetNewPeerState(ulong o);
    [DllImport(InfraLib)] public extern static ulong NetworkServer_SetNewPeerState(ulong o, ulong value);


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


    [DllImport(InfraLib)] public extern static ulong NetworkAddress_GetKind(ulong o);
    [DllImport(InfraLib)] public extern static ulong NetworkAddress_SetKind(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong NetworkAddress_GetValueA(ulong o);
    [DllImport(InfraLib)] public extern static ulong NetworkAddress_SetValueA(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong NetworkAddress_GetValueB(ulong o);
    [DllImport(InfraLib)] public extern static ulong NetworkAddress_SetValueB(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong NetworkAddress_GetValueC(ulong o);
    [DllImport(InfraLib)] public extern static ulong NetworkAddress_SetValueC(ulong o, ulong value);


    [DllImport(InfraLib)] public extern static ulong NetworkAddress_Set(ulong o);



    [DllImport(InfraLib)] public extern static ulong Thread_New();

    [DllImport(InfraLib)] public extern static ulong Thread_Delete(ulong o);

    [DllImport(InfraLib)] public extern static ulong Thread_Init(ulong o);

    [DllImport(InfraLib)] public extern static ulong Thread_Final(ulong o);


    [DllImport(InfraLib)] public extern static ulong Thread_GetIdent(ulong o);
    [DllImport(InfraLib)] public extern static ulong Thread_SetIdent(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong Thread_GetExecuteState(ulong o);
    [DllImport(InfraLib)] public extern static ulong Thread_SetExecuteState(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong Thread_GetStatus(ulong o);
    [DllImport(InfraLib)] public extern static ulong Thread_SetStatus(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong Thread_GetCase(ulong o);
    [DllImport(InfraLib)] public extern static ulong Thread_SetCase(ulong o, ulong value);


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


    [DllImport(InfraLib)] public extern static ulong Semaphore_GetCount(ulong o);
    [DllImport(InfraLib)] public extern static ulong Semaphore_SetCount(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong Semaphore_GetInitCount(ulong o);
    [DllImport(InfraLib)] public extern static ulong Semaphore_SetInitCount(ulong o, ulong value);


    [DllImport(InfraLib)] public extern static ulong Semaphore_Acquire(ulong o);

    [DllImport(InfraLib)] public extern static ulong Semaphore_Release(ulong o);



    [DllImport(InfraLib)] public extern static ulong Time_New();

    [DllImport(InfraLib)] public extern static ulong Time_Delete(ulong o);

    [DllImport(InfraLib)] public extern static ulong Time_Init(ulong o);

    [DllImport(InfraLib)] public extern static ulong Time_Final(ulong o);


    [DllImport(InfraLib)] public extern static ulong Time_GetYear(ulong o);
    [DllImport(InfraLib)] public extern static ulong Time_SetYear(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong Time_GetMonth(ulong o);
    [DllImport(InfraLib)] public extern static ulong Time_SetMonth(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong Time_GetDay(ulong o);
    [DllImport(InfraLib)] public extern static ulong Time_SetDay(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong Time_GetHour(ulong o);
    [DllImport(InfraLib)] public extern static ulong Time_SetHour(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong Time_GetMinute(ulong o);
    [DllImport(InfraLib)] public extern static ulong Time_SetMinute(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong Time_GetSecond(ulong o);
    [DllImport(InfraLib)] public extern static ulong Time_SetSecond(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong Time_GetMillisecond(ulong o);
    [DllImport(InfraLib)] public extern static ulong Time_SetMillisecond(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong Time_GetOffsetUtc(ulong o);
    [DllImport(InfraLib)] public extern static ulong Time_SetOffsetUtc(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong Time_GetLocalTime(ulong o);
    [DllImport(InfraLib)] public extern static ulong Time_SetLocalTime(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong Time_GetYearDay(ulong o);
    [DllImport(InfraLib)] public extern static ulong Time_SetYearDay(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong Time_GetWeekDay(ulong o);
    [DllImport(InfraLib)] public extern static ulong Time_SetWeekDay(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong Time_GetYearDayCount(ulong o);
    [DllImport(InfraLib)] public extern static ulong Time_SetYearDayCount(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong Time_GetMonthDayCount(ulong o);
    [DllImport(InfraLib)] public extern static ulong Time_SetMonthDayCount(ulong o, ulong value);


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


    [DllImport(InfraLib)] public extern static ulong Interval_GetTime(ulong o);
    [DllImport(InfraLib)] public extern static ulong Interval_SetTime(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong Interval_GetSingleShot(ulong o);
    [DllImport(InfraLib)] public extern static ulong Interval_SetSingleShot(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong Interval_GetActive(ulong o);
    [DllImport(InfraLib)] public extern static ulong Interval_SetActive(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong Interval_GetElapseState(ulong o);
    [DllImport(InfraLib)] public extern static ulong Interval_SetElapseState(ulong o, ulong value);


    [DllImport(InfraLib)] public extern static ulong Interval_Start(ulong o);

    [DllImport(InfraLib)] public extern static ulong Interval_Stop(ulong o);


    public delegate ulong Interval_Elapse_Maide(ulong interval, ulong arg);



    [DllImport(InfraLib)] public extern static ulong Post_New();

    [DllImport(InfraLib)] public extern static ulong Post_Delete(ulong o);

    [DllImport(InfraLib)] public extern static ulong Post_Init(ulong o);

    [DllImport(InfraLib)] public extern static ulong Post_Final(ulong o);


    [DllImport(InfraLib)] public extern static ulong Post_GetExecuteState(ulong o);
    [DllImport(InfraLib)] public extern static ulong Post_SetExecuteState(ulong o, ulong value);


    [DllImport(InfraLib)] public extern static ulong Post_Execute(ulong o);


    public delegate ulong Post_Execute_Maide(ulong post, ulong arg);



    [DllImport(InfraLib)] public extern static ulong Libray_New();

    [DllImport(InfraLib)] public extern static ulong Libray_Delete(ulong o);

    [DllImport(InfraLib)] public extern static ulong Libray_Init(ulong o);

    [DllImport(InfraLib)] public extern static ulong Libray_Final(ulong o);


    [DllImport(InfraLib)] public extern static ulong Libray_GetFile(ulong o);
    [DllImport(InfraLib)] public extern static ulong Libray_SetFile(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong Libray_GetLoaded(ulong o);
    [DllImport(InfraLib)] public extern static ulong Libray_SetLoaded(ulong o, ulong value);


    [DllImport(InfraLib)] public extern static ulong Libray_SetLibraryFile(ulong o);

    [DllImport(InfraLib)] public extern static ulong Libray_Load(ulong o);

    [DllImport(InfraLib)] public extern static ulong Libray_Unload(ulong o);

    [DllImport(InfraLib)] public extern static ulong Libray_GetAddress(ulong o, ulong name);



    [DllImport(InfraLib)] public extern static ulong Process_New();

    [DllImport(InfraLib)] public extern static ulong Process_Delete(ulong o);

    [DllImport(InfraLib)] public extern static ulong Process_Init(ulong o);

    [DllImport(InfraLib)] public extern static ulong Process_Final(ulong o);


    [DllImport(InfraLib)] public extern static ulong Process_GetProgram(ulong o);
    [DllImport(InfraLib)] public extern static ulong Process_SetProgram(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong Process_GetArgue(ulong o);
    [DllImport(InfraLib)] public extern static ulong Process_SetArgue(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong Process_GetWorkFold(ulong o);
    [DllImport(InfraLib)] public extern static ulong Process_SetWorkFold(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong Process_GetEnvironment(ulong o);
    [DllImport(InfraLib)] public extern static ulong Process_SetEnvironment(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong Process_GetStartedState(ulong o);
    [DllImport(InfraLib)] public extern static ulong Process_SetStartedState(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong Process_GetFinishedState(ulong o);
    [DllImport(InfraLib)] public extern static ulong Process_SetFinishedState(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong Process_GetReadOutState(ulong o);
    [DllImport(InfraLib)] public extern static ulong Process_SetReadOutState(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong Process_GetReadErrState(ulong o);
    [DllImport(InfraLib)] public extern static ulong Process_SetReadErrState(ulong o, ulong value);


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


    [DllImport(InfraLib)] public extern static ulong ProcessSemaphore_GetName(ulong o);
    [DllImport(InfraLib)] public extern static ulong ProcessSemaphore_SetName(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong ProcessSemaphore_GetInitCount(ulong o);
    [DllImport(InfraLib)] public extern static ulong ProcessSemaphore_SetInitCount(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong ProcessSemaphore_GetCreate(ulong o);
    [DllImport(InfraLib)] public extern static ulong ProcessSemaphore_SetCreate(ulong o, ulong value);

    [DllImport(InfraLib)] public extern static ulong ProcessSemaphore_GetStatus(ulong o);
    [DllImport(InfraLib)] public extern static ulong ProcessSemaphore_SetStatus(ulong o, ulong value);


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