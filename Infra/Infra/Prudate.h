#pragma once

#ifdef __WIN64__
#define OS_Windows
#endif

#ifdef OS_Windows
#define ExportApi __declspec(dllexport)
#define ImportApi __declspec(dllimport)
#else
#endif

#ifdef Infra_Module
#define Infra_Api ExportApi
#else
#define Infra_Api ImportApi
#endif

typedef unsigned char Byte;
typedef unsigned long long Bool;
typedef unsigned long long Int;
typedef unsigned short Char;
typedef long long SInt;
typedef unsigned int Int32;
typedef int SInt32;
typedef unsigned short Int16;
typedef short SInt16;

#define true (1)
#define false (0)

#ifndef null
#define null (0)
#else
#error null is defined by another include
#endif

#define Constant_IntByteCount() (sizeof(Int))
#define Constant_Int32ByteCount() (sizeof(Int32))
#define Constant_CharByteCount() (sizeof(Char))
#define Constant_ByteHexDigitCount() (2)
#define Constant_HexDigitBitCount() (4)

#define CastInt(o) ((Int)o)
#define CastPointer(o) ((void*)o)

#define InfraApiNew(c) \
Infra_Api Int c##_New();\
Infra_Api Int c##_Delete(Int o);\
Infra_Api Int c##_Init(Int o);\
Infra_Api Int c##_Final(Int o);\


#define ApiNew(m, c) \
m##_Api Int m##_##c##_New();\
m##_Api Int m##_##c##_Delete(Int o);\
m##_Api Int m##_##c##_Init(Int o);\
m##_Api Int m##_##c##_Final(Int o);\


#define InfraClassNew(c) \
Int c##_New()\
{\
    Int count;\
    count = sizeof(c);\
    Int o;\
    o = New(count);\
    return o;\
}\
Int c##_Delete(Int o)\
{\
    Delete(o);\
    return true;\
}\


#define ClassNew(m, c) \
Int m##_##c##_New()\
{\
    Int count;\
    count = sizeof(c);\
    Int o;\
    o = New(count);\
    return o;\
}\
Int m##_##c##_Delete(Int o)\
{\
    Delete(o);\
    return true;\
}\


Infra_Api Int New(Int count);
Infra_Api Int Delete(Int any);
Infra_Api Int Copy(Int dest, Int source, Int count);
Infra_Api Int Exit(Int code);

InfraApiNew(String)
Infra_Api Int String_CountGet(Int o);
Infra_Api Int String_CountSet(Int o, Int value);
Infra_Api Int String_DataGet(Int o);
Infra_Api Int String_DataSet(Int o, Int value);

Infra_Api Int String_Char(Int o, Int index);
Infra_Api Int String_Equal(Int o, Int other);

Infra_Api Int String_ConstantCreate(Int o);
Infra_Api Int String_ConstantDelete(Int o);

InfraApiNew(Return)
Infra_Api Int Return_StringGet(Int o);
Infra_Api Int Return_StringSet(Int o, Int value);
Infra_Api Int Return_StringListGet(Int o);
Infra_Api Int Return_StringListSet(Int o, Int value);

Infra_Api Int Return_StringStart(Int o);
Infra_Api Int Return_StringEnd(Int o);
Infra_Api Int Return_StringCount(Int o);
Infra_Api Int Return_StringResult(Int o, Int result);
Infra_Api Int Return_StringListStart(Int o);
Infra_Api Int Return_StringListEnd(Int o);
Infra_Api Int Return_StringListCount(Int o);
Infra_Api Int Return_StringListItem(Int o, Int index);

InfraApiNew(Console)
Infra_Api Int Console_OutWrite(Int o, Int text);
Infra_Api Int Console_ErrWrite(Int o, Int text);
Infra_Api Int Console_InnRead(Int o);

InfraApiNew(Array)
Infra_Api Int Array_CountGet(Int o);
Infra_Api Int Array_CountSet(Int o, Int value);

Infra_Api Int Array_ItemGet(Int o, Int index);
Infra_Api Int Array_ItemSet(Int o, Int index, Int value);

InfraApiNew(TextEncode)
Infra_Api Int TextEncode_KindGet(Int o);
Infra_Api Int TextEncode_KindSet(Int o, Int value);
Infra_Api Int TextEncode_WriteBomGet(Int o);
Infra_Api Int TextEncode_WriteBomSet(Int o, Int value);

Infra_Api Int TextEncode_StringCountMax(Int o, Int count);
Infra_Api Int TextEncode_String(Int o, Int result, Int data);
Infra_Api Int TextEncode_DataCountMax(Int o, Int count);
Infra_Api Int TextEncode_Data(Int o, Int result, Int fromString);

InfraApiNew(Format)
Infra_Api Int Format_ExecuteCount(Int o, Int varBase, Int argList);
Infra_Api Int Format_ExecuteResult(Int o, Int varBase, Int argList, Int result);
Infra_Api Int Format_ExecuteArgCount(Int o, Int arg);
Infra_Api Int Format_ExecuteArgResult(Int o, Int arg, Int result);

InfraApiNew(FormatArg)
Infra_Api Int FormatArg_PosGet(Int o);
Infra_Api Int FormatArg_PosSet(Int o, Int value);
Infra_Api Int FormatArg_KindGet(Int o);
Infra_Api Int FormatArg_KindSet(Int o, Int value);
Infra_Api Int FormatArg_ValueGet(Int o);
Infra_Api Int FormatArg_ValueSet(Int o, Int value);
Infra_Api Int FormatArg_AlignLeftGet(Int o);
Infra_Api Int FormatArg_AlignLeftSet(Int o, Int value);
Infra_Api Int FormatArg_FieldWidthGet(Int o);
Infra_Api Int FormatArg_FieldWidthSet(Int o, Int value);
Infra_Api Int FormatArg_MaxWidthGet(Int o);
Infra_Api Int FormatArg_MaxWidthSet(Int o, Int value);
Infra_Api Int FormatArg_CaseGet(Int o);
Infra_Api Int FormatArg_CaseSet(Int o, Int value);
Infra_Api Int FormatArg_BaseGet(Int o);
Infra_Api Int FormatArg_BaseSet(Int o, Int value);
Infra_Api Int FormatArg_SignGet(Int o);
Infra_Api Int FormatArg_SignSet(Int o, Int value);
Infra_Api Int FormatArg_FillCharGet(Int o);
Infra_Api Int FormatArg_FillCharSet(Int o, Int value);
Infra_Api Int FormatArg_HasCountGet(Int o);
Infra_Api Int FormatArg_HasCountSet(Int o, Int value);
Infra_Api Int FormatArg_ValueCountGet(Int o);
Infra_Api Int FormatArg_ValueCountSet(Int o, Int value);
Infra_Api Int FormatArg_CountGet(Int o);
Infra_Api Int FormatArg_CountSet(Int o, Int value);

InfraApiNew(Math)
Infra_Api Int Math_Value(Int o, Int significand, Int exponent);
Infra_Api Int Math_ValueTen(Int o, Int significand, Int exponentTen);
Infra_Api Int Math_Compose(Int o, Int value, Int significand, Int exponent);
Infra_Api Int Math_Add(Int o, Int a, Int b);
Infra_Api Int Math_Sub(Int o, Int a, Int b);
Infra_Api Int Math_Mul(Int o, Int a, Int b);
Infra_Api Int Math_Div(Int o, Int a, Int b);
Infra_Api Int Math_Less(Int o, Int a, Int b);
Infra_Api Int Math_Abs(Int o, Int a);
Infra_Api Int Math_Sin(Int o, Int a);
Infra_Api Int Math_Cos(Int o, Int a);
Infra_Api Int Math_Tan(Int o, Int a);
Infra_Api Int Math_ASin(Int o, Int a);
Infra_Api Int Math_ACos(Int o, Int a);
Infra_Api Int Math_ATan(Int o, Int a);
Infra_Api Int Math_ATan2(Int o, Int a, Int b);
Infra_Api Int Math_SinH(Int o, Int a);
Infra_Api Int Math_CosH(Int o, Int a);
Infra_Api Int Math_TanH(Int o, Int a);
Infra_Api Int Math_ASinH(Int o, Int a);
Infra_Api Int Math_ACosH(Int o, Int a);
Infra_Api Int Math_ATanH(Int o, Int a);
Infra_Api Int Math_Exp(Int o, Int a);
Infra_Api Int Math_ExpE(Int o, Int a);
Infra_Api Int Math_Log(Int o, Int a);
Infra_Api Int Math_LogE(Int o, Int a);
Infra_Api Int Math_LogN(Int o, Int a);
Infra_Api Int Math_Pow(Int o, Int a, Int exp);
Infra_Api Int Math_Sqrt(Int o, Int a);
Infra_Api Int Math_TGamma(Int o, Int a);
Infra_Api Int Math_Ceil(Int o, Int a);
Infra_Api Int Math_Floor(Int o, Int a);
Infra_Api Int Math_Trunc(Int o, Int a);
Infra_Api Int Math_Round(Int o, Int a);

InfraApiNew(Random)
Infra_Api Int Random_SeedGet(Int o);
Infra_Api Int Random_SeedSet(Int o, Int value);

Infra_Api Int Random_Execute(Int o);

InfraApiNew(Range)
Infra_Api Int Range_IndexGet(Int o);
Infra_Api Int Range_IndexSet(Int o, Int value);
Infra_Api Int Range_CountGet(Int o);
Infra_Api Int Range_CountSet(Int o, Int value);

InfraApiNew(Rect)
Infra_Api Int Rect_PosGet(Int o);
Infra_Api Int Rect_PosSet(Int o, Int value);
Infra_Api Int Rect_SizeGet(Int o);
Infra_Api Int Rect_SizeSet(Int o, Int value);

InfraApiNew(Pos)
Infra_Api Int Pos_LeftGet(Int o);
Infra_Api Int Pos_LeftSet(Int o, Int value);
Infra_Api Int Pos_UpGet(Int o);
Infra_Api Int Pos_UpSet(Int o, Int value);

InfraApiNew(Size)
Infra_Api Int Size_WidthGet(Int o);
Infra_Api Int Size_WidthSet(Int o, Int value);
Infra_Api Int Size_HeightGet(Int o);
Infra_Api Int Size_HeightSet(Int o, Int value);

InfraApiNew(Data)
Infra_Api Int Data_CountGet(Int o);
Infra_Api Int Data_CountSet(Int o, Int value);
Infra_Api Int Data_ValueGet(Int o);
Infra_Api Int Data_ValueSet(Int o, Int value);

InfraApiNew(Entry)
Infra_Api Int Entry_IndexGet(Int o);
Infra_Api Int Entry_IndexSet(Int o, Int value);
Infra_Api Int Entry_ValueGet(Int o);
Infra_Api Int Entry_ValueSet(Int o, Int value);

InfraApiNew(State)
Infra_Api Int State_MaideGet(Int o);
Infra_Api Int State_MaideSet(Int o, Int value);
Infra_Api Int State_ArgGet(Int o);
Infra_Api Int State_ArgSet(Int o, Int value);

Infra_Api Int Main_TerminateStateGet();
Infra_Api Int Main_TerminateStateSet(Int value);

Infra_Api Int Main_Init();
Infra_Api Int Main_Final();
Infra_Api Int Main_IsCSharpSet(Int value);
Infra_Api Int Main_ExecuteEventLoop();
Infra_Api Int Main_ExitEventLoop(Int code);

typedef Int (*Main_Terminate_Maide)(Int arg);

InfraApiNew(Frame)
Infra_Api Int Frame_TitleGet(Int o);
Infra_Api Int Frame_TitleSet(Int o, Int value);
Infra_Api Int Frame_VisibleGet(Int o);
Infra_Api Int Frame_VisibleSet(Int o, Int value);
Infra_Api Int Frame_SizeGet(Int o);
Infra_Api Int Frame_SizeSet(Int o, Int value);
Infra_Api Int Frame_TypeStateGet(Int o);
Infra_Api Int Frame_TypeStateSet(Int o, Int value);
Infra_Api Int Frame_DrawStateGet(Int o);
Infra_Api Int Frame_DrawStateSet(Int o, Int value);

Infra_Api Int Frame_TitleThisSet(Int o);
Infra_Api Int Frame_VideoOut(Int o);
Infra_Api Int Frame_Update(Int o, Int rect);
Infra_Api Int Frame_Close(Int o);

typedef Int (*Frame_Type_Maide)(Int frame, Int index, Int field, Int arg);
typedef Int (*Frame_Draw_Maide)(Int frame, Int arg);

InfraApiNew(Draw)
Infra_Api Int Draw_SizeGet(Int o);
Infra_Api Int Draw_SizeSet(Int o, Int value);
Infra_Api Int Draw_OutGet(Int o);
Infra_Api Int Draw_OutSet(Int o, Int value);
Infra_Api Int Draw_AreaGet(Int o);
Infra_Api Int Draw_AreaSet(Int o, Int value);
Infra_Api Int Draw_FillPosGet(Int o);
Infra_Api Int Draw_FillPosSet(Int o, Int value);
Infra_Api Int Draw_BrushGet(Int o);
Infra_Api Int Draw_BrushSet(Int o, Int value);
Infra_Api Int Draw_PenGet(Int o);
Infra_Api Int Draw_PenSet(Int o, Int value);
Infra_Api Int Draw_FontGet(Int o);
Infra_Api Int Draw_FontSet(Int o, Int value);
Infra_Api Int Draw_TransformGet(Int o);
Infra_Api Int Draw_TransformSet(Int o, Int value);
Infra_Api Int Draw_CompositeGet(Int o);
Infra_Api Int Draw_CompositeSet(Int o, Int value);

Infra_Api Int Draw_Start(Int o);
Infra_Api Int Draw_End(Int o);
Infra_Api Int Draw_FillPosThisSet(Int o);
Infra_Api Int Draw_AreaThisSet(Int o);
Infra_Api Int Draw_Clear(Int o, Int color);
Infra_Api Int Draw_ExecuteLine(Int o, Int startPos, Int endPos);
Infra_Api Int Draw_ExecuteArc(Int o, Int rect, Int angleRange);
Infra_Api Int Draw_ExecuteChord(Int o, Int rect, Int angleRange);
Infra_Api Int Draw_ExecutePie(Int o, Int rect, Int angleRange);
Infra_Api Int Draw_ExecuteEllipse(Int o, Int rect);
Infra_Api Int Draw_ExecuteRect(Int o, Int rect);
Infra_Api Int Draw_ExecuteRoundRect(Int o, Int rect, Int horizRadius, Int vertRadius);
Infra_Api Int Draw_ExecutePolygon(Int o, Int pointListCount, Int pointListData);
Infra_Api Int Draw_ExecutePolyline(Int o, Int pointListCount, Int pointListData);
Infra_Api Int Draw_ExecuteImage(Int o, Int image, Int destRect, Int sourceRect);
Infra_Api Int Draw_ExecuteText(Int o, Int destRect, Int flag, Int text, Int boundRect);

InfraApiNew(Brush)
Infra_Api Int Brush_KindGet(Int o);
Infra_Api Int Brush_KindSet(Int o, Int value);
Infra_Api Int Brush_ColorGet(Int o);
Infra_Api Int Brush_ColorSet(Int o, Int value);
Infra_Api Int Brush_ImageGet(Int o);
Infra_Api Int Brush_ImageSet(Int o, Int value);
Infra_Api Int Brush_GradientGet(Int o);
Infra_Api Int Brush_GradientSet(Int o, Int value);

InfraApiNew(Pen)
Infra_Api Int Pen_KindGet(Int o);
Infra_Api Int Pen_KindSet(Int o, Int value);
Infra_Api Int Pen_WidthGet(Int o);
Infra_Api Int Pen_WidthSet(Int o, Int value);
Infra_Api Int Pen_BrushGet(Int o);
Infra_Api Int Pen_BrushSet(Int o, Int value);
Infra_Api Int Pen_CapGet(Int o);
Infra_Api Int Pen_CapSet(Int o, Int value);
Infra_Api Int Pen_JoinGet(Int o);
Infra_Api Int Pen_JoinSet(Int o, Int value);

Infra_Api Int PointData_PointGet(Int address, Int result);
Infra_Api Int PointData_PointSet(Int address, Int pos);

InfraApiNew(Image)
Infra_Api Int Image_SizeGet(Int o);
Infra_Api Int Image_SizeSet(Int o, Int value);
Infra_Api Int Image_DataGet(Int o);
Infra_Api Int Image_DataSet(Int o, Int value);
Infra_Api Int Image_RowByteCountGet(Int o);
Infra_Api Int Image_RowByteCountSet(Int o, Int value);

Infra_Api Int Image_VideoOut(Int o);
Infra_Api Int Image_DataCreate(Int o);

InfraApiNew(Font)
Infra_Api Int Font_FamilyGet(Int o);
Infra_Api Int Font_FamilySet(Int o, Int value);
Infra_Api Int Font_SizeGet(Int o);
Infra_Api Int Font_SizeSet(Int o, Int value);
Infra_Api Int Font_WeightGet(Int o);
Infra_Api Int Font_WeightSet(Int o, Int value);
Infra_Api Int Font_ItalicGet(Int o);
Infra_Api Int Font_ItalicSet(Int o, Int value);
Infra_Api Int Font_UnderlineGet(Int o);
Infra_Api Int Font_UnderlineSet(Int o, Int value);
Infra_Api Int Font_OverlineGet(Int o);
Infra_Api Int Font_OverlineSet(Int o, Int value);
Infra_Api Int Font_StrikeoutGet(Int o);
Infra_Api Int Font_StrikeoutSet(Int o, Int value);

InfraApiNew(Transform)
Infra_Api Int Transform_Reset(Int o);
Infra_Api Int Transform_Offset(Int o, Int offsetLeft, Int offsetUp);
Infra_Api Int Transform_Scale(Int o, Int horizScale, Int vertScale);
Infra_Api Int Transform_Rotate(Int o, Int angle);
Infra_Api Int Transform_ValueGet(Int o, Int row, Int col);
Infra_Api Int Transform_ValueSet(Int o, Int row, Int col, Int value);
Infra_Api Int Transform_Multiply(Int o, Int other);
Infra_Api Int Transform_IsIdentity(Int o);
Infra_Api Int Transform_IsInvertible(Int o);
Infra_Api Int Transform_Invert(Int o, Int result);
Infra_Api Int Transform_Transpose(Int o, Int result);
Infra_Api Int Transform_Determinant(Int o);

InfraApiNew(Gradient)
Infra_Api Int Gradient_KindGet(Int o);
Infra_Api Int Gradient_KindSet(Int o, Int value);
Infra_Api Int Gradient_ValueGet(Int o);
Infra_Api Int Gradient_ValueSet(Int o, Int value);
Infra_Api Int Gradient_StopGet(Int o);
Infra_Api Int Gradient_StopSet(Int o, Int value);
Infra_Api Int Gradient_SpreadGet(Int o);
Infra_Api Int Gradient_SpreadSet(Int o, Int value);

InfraApiNew(GradientLinear)
Infra_Api Int GradientLinear_StartPosGet(Int o);
Infra_Api Int GradientLinear_StartPosSet(Int o, Int value);
Infra_Api Int GradientLinear_EndPosGet(Int o);
Infra_Api Int GradientLinear_EndPosSet(Int o, Int value);

InfraApiNew(GradientRadial)
Infra_Api Int GradientRadial_CenterPosGet(Int o);
Infra_Api Int GradientRadial_CenterPosSet(Int o, Int value);
Infra_Api Int GradientRadial_CenterRadiusGet(Int o);
Infra_Api Int GradientRadial_CenterRadiusSet(Int o, Int value);
Infra_Api Int GradientRadial_FocusPosGet(Int o);
Infra_Api Int GradientRadial_FocusPosSet(Int o, Int value);
Infra_Api Int GradientRadial_FocusRadiusGet(Int o);
Infra_Api Int GradientRadial_FocusRadiusSet(Int o, Int value);

InfraApiNew(GradientStop)
Infra_Api Int GradientStop_CountGet(Int o);
Infra_Api Int GradientStop_CountSet(Int o, Int value);

Infra_Api Int GradientStop_PointGet(Int o, Int index, Int pos, Int color);
Infra_Api Int GradientStop_PointSet(Int o, Int index, Int pos, Int color);

InfraApiNew(ImageRead)
Infra_Api Int ImageRead_StreamGet(Int o);
Infra_Api Int ImageRead_StreamSet(Int o, Int value);
Infra_Api Int ImageRead_ImageGet(Int o);
Infra_Api Int ImageRead_ImageSet(Int o, Int value);

Infra_Api Int ImageRead_Execute(Int o);

InfraApiNew(ImageWrite)
Infra_Api Int ImageWrite_StreamGet(Int o);
Infra_Api Int ImageWrite_StreamSet(Int o, Int value);
Infra_Api Int ImageWrite_ImageGet(Int o);
Infra_Api Int ImageWrite_ImageSet(Int o, Int value);
Infra_Api Int ImageWrite_FormatGet(Int o);
Infra_Api Int ImageWrite_FormatSet(Int o, Int value);
Infra_Api Int ImageWrite_QualityGet(Int o);
Infra_Api Int ImageWrite_QualitySet(Int o, Int value);

Infra_Api Int ImageWrite_Execute(Int o);

InfraApiNew(VideoOut)
Infra_Api Int VideoOut_SizeGet(Int o);
Infra_Api Int VideoOut_SizeSet(Int o, Int value);
Infra_Api Int VideoOut_FrameGet(Int o);
Infra_Api Int VideoOut_FrameSet(Int o, Int value);
Infra_Api Int VideoOut_SubtitleGet(Int o);
Infra_Api Int VideoOut_SubtitleSet(Int o, Int value);
Infra_Api Int VideoOut_FrameStateGet(Int o);
Infra_Api Int VideoOut_FrameStateSet(Int o, Int value);
Infra_Api Int VideoOut_SizeStateGet(Int o);
Infra_Api Int VideoOut_SizeStateSet(Int o, Int value);

Infra_Api Int VideoOut_SubtitleThisSet(Int o);

typedef Int (*VideoOut_Frame_Maide)(Int videoOut, Int frame, Int arg);
typedef Int (*VideoOut_Size_Maide)(Int videoOut, Int size, Int arg);

InfraApiNew(VideoFrame)
Infra_Api Int VideoFrame_SizeGet(Int o);
Infra_Api Int VideoFrame_SizeSet(Int o, Int value);

Infra_Api Int VideoFrame_Image(Int o, Int image);

InfraApiNew(AudioOut)
Infra_Api Int AudioOut_MutedGet(Int o);
Infra_Api Int AudioOut_MutedSet(Int o, Int value);
Infra_Api Int AudioOut_VolumeGet(Int o);
Infra_Api Int AudioOut_VolumeSet(Int o, Int value);

InfraApiNew(AudioEffect)
Infra_Api Int AudioEffect_SourceGet(Int o);
Infra_Api Int AudioEffect_SourceSet(Int o, Int value);
Infra_Api Int AudioEffect_VolumeGet(Int o);
Infra_Api Int AudioEffect_VolumeSet(Int o, Int value);

Infra_Api Int AudioEffect_SourceThisSet(Int o);
Infra_Api Int AudioEffect_Play(Int o);
Infra_Api Int AudioEffect_Stop(Int o);

InfraApiNew(Play)
Infra_Api Int Play_SourceGet(Int o);
Infra_Api Int Play_SourceSet(Int o, Int value);
Infra_Api Int Play_VideoOutGet(Int o);
Infra_Api Int Play_VideoOutSet(Int o, Int value);
Infra_Api Int Play_AudioOutGet(Int o);
Infra_Api Int Play_AudioOutSet(Int o, Int value);
Infra_Api Int Play_TimeGet(Int o);
Infra_Api Int Play_TimeSet(Int o, Int value);
Infra_Api Int Play_PosGet(Int o);
Infra_Api Int Play_PosSet(Int o, Int value);

Infra_Api Int Play_SourceThisSet(Int o);
Infra_Api Int Play_HasVideo(Int o);
Infra_Api Int Play_HasAudio(Int o);
Infra_Api Int Play_Execute(Int o);
Infra_Api Int Play_Pause(Int o);
Infra_Api Int Play_Stop(Int o);

InfraApiNew(Stream)
Infra_Api Int Stream_KindGet(Int o);
Infra_Api Int Stream_KindSet(Int o, Int value);
Infra_Api Int Stream_StatusGet(Int o);
Infra_Api Int Stream_StatusSet(Int o, Int value);

Infra_Api Int Stream_CountGet(Int o);
Infra_Api Int Stream_PosGet(Int o);
Infra_Api Int Stream_PosSet(Int o, Int value);
Infra_Api Int Stream_HasCount(Int o);
Infra_Api Int Stream_HasPos(Int o);
Infra_Api Int Stream_CanRead(Int o);
Infra_Api Int Stream_CanWrite(Int o);
Infra_Api Int Stream_Read(Int o, Int data, Int range);
Infra_Api Int Stream_Write(Int o, Int data, Int range);

InfraApiNew(Memory)
Infra_Api Int Memory_StreamGet(Int o);
Infra_Api Int Memory_StreamSet(Int o, Int value);

Infra_Api Int Memory_Open(Int o);
Infra_Api Int Memory_Close(Int o);

InfraApiNew(Storage)
Infra_Api Int Storage_PathGet(Int o);
Infra_Api Int Storage_PathSet(Int o, Int value);
Infra_Api Int Storage_ModeGet(Int o);
Infra_Api Int Storage_ModeSet(Int o, Int value);
Infra_Api Int Storage_StreamGet(Int o);
Infra_Api Int Storage_StreamSet(Int o, Int value);
Infra_Api Int Storage_StatusGet(Int o);
Infra_Api Int Storage_StatusSet(Int o, Int value);

Infra_Api Int Storage_CountSet(Int o, Int value);
Infra_Api Int Storage_Open(Int o);
Infra_Api Int Storage_Close(Int o);

InfraApiNew(StorageArrange)
Infra_Api Int StorageArrange_Copy(Int o, Int path, Int destPath);
Infra_Api Int StorageArrange_Rename(Int o, Int path, Int destPath);
Infra_Api Int StorageArrange_Remove(Int o, Int path);
Infra_Api Int StorageArrange_Exist(Int o, Int path);
Infra_Api Int StorageArrange_LinkTarget(Int o, Int path);
Infra_Api Int StorageArrange_FoldCreate(Int o, Int path);
Infra_Api Int StorageArrange_FoldCreateToPath(Int o, Int path);
Infra_Api Int StorageArrange_FoldRemove(Int o, Int path);
Infra_Api Int StorageArrange_FoldRemoveRecursive(Int o, Int path);
Infra_Api Int StorageArrange_FoldRename(Int o, Int path, Int destPath);
Infra_Api Int StorageArrange_EntryCount(Int o, Int foldPath);
Infra_Api Int StorageArrange_EntryName(Int o, Int path);
Infra_Api Int StorageArrange_BaseName(Int o, Int name);
Infra_Api Int StorageArrange_Extension(Int o, Int name);
Infra_Api Int StorageArrange_AbsolutePath(Int o, Int path);
Infra_Api Int StorageArrange_RelativePath(Int o, Int path, Int destPath);
Infra_Api Int StorageArrange_CanonicalPath(Int o, Int path);
Infra_Api Int StorageArrange_CleanPath(Int o, Int path);

InfraApiNew(StorageEntry)
Infra_Api Int StorageEntry_PathGet(Int o);
Infra_Api Int StorageEntry_PathSet(Int o, Int value);
Infra_Api Int StorageEntry_KindGet(Int o);
Infra_Api Int StorageEntry_KindSet(Int o, Int value);
Infra_Api Int StorageEntry_CountGet(Int o);
Infra_Api Int StorageEntry_CountSet(Int o, Int value);
Infra_Api Int StorageEntry_IsReadableGet(Int o);
Infra_Api Int StorageEntry_IsReadableSet(Int o, Int value);
Infra_Api Int StorageEntry_IsHiddenGet(Int o);
Infra_Api Int StorageEntry_IsHiddenSet(Int o, Int value);
Infra_Api Int StorageEntry_IsExecutableGet(Int o);
Infra_Api Int StorageEntry_IsExecutableSet(Int o, Int value);

Infra_Api Int StorageEntry_CreateTime(Int o, Int result);
Infra_Api Int StorageEntry_LastModifyTime(Int o, Int result);
Infra_Api Int StorageEntry_LastReadTime(Int o, Int result);
Infra_Api Int StorageEntry_Update(Int o);

InfraApiNew(Network)
Infra_Api Int Network_HostNameGet(Int o);
Infra_Api Int Network_HostNameSet(Int o, Int value);
Infra_Api Int Network_ServerPortGet(Int o);
Infra_Api Int Network_ServerPortSet(Int o, Int value);
Infra_Api Int Network_StreamGet(Int o);
Infra_Api Int Network_StreamSet(Int o, Int value);
Infra_Api Int Network_ReadyCountGet(Int o);
Infra_Api Int Network_ReadyCountSet(Int o, Int value);
Infra_Api Int Network_StatusGet(Int o);
Infra_Api Int Network_StatusSet(Int o, Int value);
Infra_Api Int Network_CaseGet(Int o);
Infra_Api Int Network_CaseSet(Int o, Int value);
Infra_Api Int Network_CaseChangedStateGet(Int o);
Infra_Api Int Network_CaseChangedStateSet(Int o, Int value);
Infra_Api Int Network_ErrorStateGet(Int o);
Infra_Api Int Network_ErrorStateSet(Int o, Int value);
Infra_Api Int Network_ReadyReadStateGet(Int o);
Infra_Api Int Network_ReadyReadStateSet(Int o, Int value);

Infra_Api Int Network_Open(Int o);
Infra_Api Int Network_Close(Int o);
Infra_Api Int Network_Abort(Int o);

typedef Int (*Network_CaseChanged_Maide)(Int network, Int arg);
typedef Int (*Network_Error_Maide)(Int network, Int arg);
typedef Int (*Network_ReadyRead_Maide)(Int network, Int arg);

InfraApiNew(NetworkServer)
Infra_Api Int NetworkServer_PortGet(Int o);
Infra_Api Int NetworkServer_PortSet(Int o, Int value);
Infra_Api Int NetworkServer_ErrorGet(Int o);
Infra_Api Int NetworkServer_ErrorSet(Int o, Int value);
Infra_Api Int NetworkServer_NewPeerStateGet(Int o);
Infra_Api Int NetworkServer_NewPeerStateSet(Int o, Int value);

Infra_Api Int NetworkServer_Listen(Int o);
Infra_Api Int NetworkServer_Close(Int o);
Infra_Api Int NetworkServer_IsListen(Int o);
Infra_Api Int NetworkServer_NextPendingPeer(Int o);
Infra_Api Int NetworkServer_ClosePeer(Int o, Int network);
Infra_Api Int NetworkServer_HasPendingPeer(Int o);
Infra_Api Int NetworkServer_PauseAccept(Int o);
Infra_Api Int NetworkServer_ResumeAccept(Int o);

typedef Int (*NetworkServer_NewPeer_Maide)(Int networkServer, Int arg);

InfraApiNew(NetworkPort)
Infra_Api Int NetworkPort_KindGet(Int o);
Infra_Api Int NetworkPort_KindSet(Int o, Int value);
Infra_Api Int NetworkPort_ValueAGet(Int o);
Infra_Api Int NetworkPort_ValueASet(Int o, Int value);
Infra_Api Int NetworkPort_ValueBGet(Int o);
Infra_Api Int NetworkPort_ValueBSet(Int o, Int value);
Infra_Api Int NetworkPort_ValueCGet(Int o);
Infra_Api Int NetworkPort_ValueCSet(Int o, Int value);
Infra_Api Int NetworkPort_ServerGet(Int o);
Infra_Api Int NetworkPort_ServerSet(Int o, Int value);

Infra_Api Int NetworkPort_Set(Int o);

InfraApiNew(Thread)
Infra_Api Int Thread_IdentGet(Int o);
Infra_Api Int Thread_IdentSet(Int o, Int value);
Infra_Api Int Thread_ExecuteStateGet(Int o);
Infra_Api Int Thread_ExecuteStateSet(Int o, Int value);
Infra_Api Int Thread_StatusGet(Int o);
Infra_Api Int Thread_StatusSet(Int o, Int value);
Infra_Api Int Thread_CaseGet(Int o);
Infra_Api Int Thread_CaseSet(Int o, Int value);

Infra_Api Int Thread_Execute(Int o);
Infra_Api Int Thread_Terminate(Int o);
Infra_Api Int Thread_Pause(Int o);
Infra_Api Int Thread_Resume(Int o);
Infra_Api Int Thread_Wait(Int o);
Infra_Api Int Thread_ExecuteEventLoop(Int o);
Infra_Api Int Thread_ExitEventLoop(Int o, Int code);
Infra_Api Int Thread_IsMainThread(Int o);

Infra_Api Int Thread_Sleep(Int time);
Infra_Api Int Thread_CurrentThread();

typedef Int (*Thread_Execute_Maide)(Int thread, Int arg);

InfraApiNew(Phore)
Infra_Api Int Phore_CountGet(Int o);
Infra_Api Int Phore_CountSet(Int o, Int value);
Infra_Api Int Phore_InitCountGet(Int o);
Infra_Api Int Phore_InitCountSet(Int o, Int value);

Infra_Api Int Phore_Acquire(Int o);
Infra_Api Int Phore_Release(Int o);

InfraApiNew(Time)
Infra_Api Int Time_YearGet(Int o);
Infra_Api Int Time_YearSet(Int o, Int value);
Infra_Api Int Time_MonthGet(Int o);
Infra_Api Int Time_MonthSet(Int o, Int value);
Infra_Api Int Time_DayGet(Int o);
Infra_Api Int Time_DaySet(Int o, Int value);
Infra_Api Int Time_HourGet(Int o);
Infra_Api Int Time_HourSet(Int o, Int value);
Infra_Api Int Time_MinuteGet(Int o);
Infra_Api Int Time_MinuteSet(Int o, Int value);
Infra_Api Int Time_SecondGet(Int o);
Infra_Api Int Time_SecondSet(Int o, Int value);
Infra_Api Int Time_MillisecondGet(Int o);
Infra_Api Int Time_MillisecondSet(Int o, Int value);
Infra_Api Int Time_OffsetUtcGet(Int o);
Infra_Api Int Time_OffsetUtcSet(Int o, Int value);
Infra_Api Int Time_LocalTimeGet(Int o);
Infra_Api Int Time_LocalTimeSet(Int o, Int value);
Infra_Api Int Time_YearDayGet(Int o);
Infra_Api Int Time_YearDaySet(Int o, Int value);
Infra_Api Int Time_WeekDayGet(Int o);
Infra_Api Int Time_WeekDaySet(Int o, Int value);
Infra_Api Int Time_YearDayCountGet(Int o);
Infra_Api Int Time_YearDayCountSet(Int o, Int value);
Infra_Api Int Time_MonthDayCountGet(Int o);
Infra_Api Int Time_MonthDayCountSet(Int o, Int value);

Infra_Api Int Time_AddYear(Int o, Int offset);
Infra_Api Int Time_AddMonth(Int o, Int offset);
Infra_Api Int Time_AddDay(Int o, Int offset);
Infra_Api Int Time_AddHour(Int o, Int offset);
Infra_Api Int Time_AddMinute(Int o, Int offset);
Infra_Api Int Time_AddSecond(Int o, Int offset);
Infra_Api Int Time_AddMillisecond(Int o, Int offset);
Infra_Api Int Time_MillisecondTo(Int o, Int other);
Infra_Api Int Time_DayTo(Int o, Int other);
Infra_Api Int Time_Current(Int o);
Infra_Api Int Time_ToLocalTime(Int o);
Infra_Api Int Time_ToOffsetUtc(Int o, Int offset);
Infra_Api Int Time_Set(Int o, Int year, Int month, Int day, Int hour, Int minute, Int second, Int millisecond, Int isLocalTime, Int offsetUtc);

Infra_Api Int Time_LeapYear(Int year);
Infra_Api Int Time_ValidDate(Int year, Int month, Int day);
Infra_Api Int Time_ValidTime(Int hour, Int minute, Int second, Int millisecond);

InfraApiNew(Interval)
Infra_Api Int Interval_TimeGet(Int o);
Infra_Api Int Interval_TimeSet(Int o, Int value);
Infra_Api Int Interval_SingleShotGet(Int o);
Infra_Api Int Interval_SingleShotSet(Int o, Int value);
Infra_Api Int Interval_ActiveGet(Int o);
Infra_Api Int Interval_ActiveSet(Int o, Int value);
Infra_Api Int Interval_ElapseStateGet(Int o);
Infra_Api Int Interval_ElapseStateSet(Int o, Int value);

Infra_Api Int Interval_Start(Int o);
Infra_Api Int Interval_Stop(Int o);

typedef Int (*Interval_Elapse_Maide)(Int interval, Int arg);

InfraApiNew(Post)
Infra_Api Int Post_ExecuteStateGet(Int o);
Infra_Api Int Post_ExecuteStateSet(Int o, Int value);

Infra_Api Int Post_Execute(Int o);

typedef Int (*Post_Execute_Maide)(Int post, Int arg);

InfraApiNew(Process)
Infra_Api Int Process_ProgramGet(Int o);
Infra_Api Int Process_ProgramSet(Int o, Int value);
Infra_Api Int Process_ArgueGet(Int o);
Infra_Api Int Process_ArgueSet(Int o, Int value);
Infra_Api Int Process_WorkFoldGet(Int o);
Infra_Api Int Process_WorkFoldSet(Int o, Int value);
Infra_Api Int Process_EnvironmentGet(Int o);
Infra_Api Int Process_EnvironmentSet(Int o, Int value);
Infra_Api Int Process_IdentGet(Int o);
Infra_Api Int Process_IdentSet(Int o, Int value);
Infra_Api Int Process_StatusGet(Int o);
Infra_Api Int Process_StatusSet(Int o, Int value);
Infra_Api Int Process_ExitKindGet(Int o);
Infra_Api Int Process_ExitKindSet(Int o, Int value);
Infra_Api Int Process_StartedStateGet(Int o);
Infra_Api Int Process_StartedStateSet(Int o, Int value);
Infra_Api Int Process_FinishedStateGet(Int o);
Infra_Api Int Process_FinishedStateSet(Int o, Int value);

Infra_Api Int Process_Execute(Int o);
Infra_Api Int Process_Wait(Int o);
Infra_Api Int Process_Terminate(Int o);

typedef Int (*Process_Started_Maide)(Int process, Int arg);
typedef Int (*Process_Finished_Maide)(Int process, Int arg);

Infra_Api Int Infra_Share();

Infra_Api Int Share_Stat(Int o);

Infra_Api Int Stat_PointDataCount(Int o);
Infra_Api Int Stat_TextEncodeKindUtf8(Int o);
Infra_Api Int Stat_TextEncodeKindUtf16(Int o);
Infra_Api Int Stat_TextEncodeKindUtf16LE(Int o);
Infra_Api Int Stat_TextEncodeKindUtf16BE(Int o);
Infra_Api Int Stat_TextEncodeKindUtf32(Int o);
Infra_Api Int Stat_TextEncodeKindUtf32LE(Int o);
Infra_Api Int Stat_TextEncodeKindUtf32BE(Int o);
Infra_Api Int Stat_TextEncodeKindLatin1(Int o);
Infra_Api Int Stat_ThreadCaseReady(Int o);
Infra_Api Int Stat_ThreadCaseExecute(Int o);
Infra_Api Int Stat_ThreadCasePause(Int o);
Infra_Api Int Stat_ThreadCaseFinish(Int o);
Infra_Api Int Stat_ThreadCaseTerminate(Int o);
Infra_Api Int Stat_StreamKindMemory(Int o);
Infra_Api Int Stat_StreamKindStorage(Int o);
Infra_Api Int Stat_StreamKindNetwork(Int o);
Infra_Api Int Stat_StorageModeRead(Int o);
Infra_Api Int Stat_StorageModeWrite(Int o);
Infra_Api Int Stat_StorageModeNew(Int o);
Infra_Api Int Stat_StorageModeExisting(Int o);
Infra_Api Int Stat_StorageStatusNoError(Int o);
Infra_Api Int Stat_StorageStatusReadError(Int o);
Infra_Api Int Stat_StorageStatusWriteError(Int o);
Infra_Api Int Stat_StorageStatusFatalError(Int o);
Infra_Api Int Stat_StorageStatusResourceError(Int o);
Infra_Api Int Stat_StorageStatusOpenError(Int o);
Infra_Api Int Stat_StorageStatusAbortError(Int o);
Infra_Api Int Stat_StorageStatusTimeOutError(Int o);
Infra_Api Int Stat_StorageStatusUnspecifiedError(Int o);
Infra_Api Int Stat_StorageStatusRemoveError(Int o);
Infra_Api Int Stat_StorageStatusRenameError(Int o);
Infra_Api Int Stat_StorageStatusPositionError(Int o);
Infra_Api Int Stat_StorageStatusResizeError(Int o);
Infra_Api Int Stat_StorageStatusPermissionsError(Int o);
Infra_Api Int Stat_StorageStatusCopyError(Int o);
Infra_Api Int Stat_NetworkCaseUnconnected(Int o);
Infra_Api Int Stat_NetworkCaseHostLookup(Int o);
Infra_Api Int Stat_NetworkCaseConnecting(Int o);
Infra_Api Int Stat_NetworkCaseConnected(Int o);
Infra_Api Int Stat_NetworkCaseBound(Int o);
Infra_Api Int Stat_NetworkCaseListening(Int o);
Infra_Api Int Stat_NetworkCaseClosing(Int o);
Infra_Api Int Stat_NetworkPortKindIPv6(Int o);
Infra_Api Int Stat_NetworkPortKindIPv4(Int o);
Infra_Api Int Stat_NetworkPortKindBroadcast(Int o);
Infra_Api Int Stat_NetworkPortKindLocalHost(Int o);
Infra_Api Int Stat_NetworkPortKindLocalHostIPv6(Int o);
Infra_Api Int Stat_NetworkPortKindAny(Int o);
Infra_Api Int Stat_NetworkPortKindAnyIPv6(Int o);
Infra_Api Int Stat_NetworkPortKindAnyIPv4(Int o);
Infra_Api Int Stat_NetworkStatusNoError(Int o);
Infra_Api Int Stat_NetworkStatusUnknownSocketError(Int o);
Infra_Api Int Stat_NetworkStatusConnectionRefusedError(Int o);
Infra_Api Int Stat_NetworkStatusRemoteHostClosedError(Int o);
Infra_Api Int Stat_NetworkStatusHostNotFoundError(Int o);
Infra_Api Int Stat_NetworkStatusSocketAccessError(Int o);
Infra_Api Int Stat_NetworkStatusSocketResourceError(Int o);
Infra_Api Int Stat_NetworkStatusSocketTimeoutError(Int o);
Infra_Api Int Stat_NetworkStatusDatagramTooLargeError(Int o);
Infra_Api Int Stat_NetworkStatusNetworkError(Int o);
Infra_Api Int Stat_NetworkStatusAddressInUseError(Int o);
Infra_Api Int Stat_NetworkStatusSocketAddressNotAvailableError(Int o);
Infra_Api Int Stat_NetworkStatusUnsupportedSocketOperationError(Int o);
Infra_Api Int Stat_NetworkStatusUnfinishedSocketOperationError(Int o);
Infra_Api Int Stat_NetworkStatusProxyAuthenticationRequiredError(Int o);
Infra_Api Int Stat_NetworkStatusSslHandshakeFailedError(Int o);
Infra_Api Int Stat_NetworkStatusProxyConnectionRefusedError(Int o);
Infra_Api Int Stat_NetworkStatusProxyConnectionClosedError(Int o);
Infra_Api Int Stat_NetworkStatusProxyConnectionTimeoutError(Int o);
Infra_Api Int Stat_NetworkStatusProxyNotFoundError(Int o);
Infra_Api Int Stat_NetworkStatusProxyProtocolError(Int o);
Infra_Api Int Stat_NetworkStatusOperationError(Int o);
Infra_Api Int Stat_NetworkStatusSslInternalError(Int o);
Infra_Api Int Stat_NetworkStatusSslInvalidUserDataError(Int o);
Infra_Api Int Stat_NetworkStatusTemporaryError(Int o);
Infra_Api Int Stat_BrushKindSolid(Int o);
Infra_Api Int Stat_BrushKindDense1(Int o);
Infra_Api Int Stat_BrushKindDense2(Int o);
Infra_Api Int Stat_BrushKindDense3(Int o);
Infra_Api Int Stat_BrushKindDense4(Int o);
Infra_Api Int Stat_BrushKindDense5(Int o);
Infra_Api Int Stat_BrushKindDense6(Int o);
Infra_Api Int Stat_BrushKindDense7(Int o);
Infra_Api Int Stat_BrushKindHor(Int o);
Infra_Api Int Stat_BrushKindVer(Int o);
Infra_Api Int Stat_BrushKindCross(Int o);
Infra_Api Int Stat_BrushKindBDiag(Int o);
Infra_Api Int Stat_BrushKindFDiag(Int o);
Infra_Api Int Stat_BrushKindDiagCross(Int o);
Infra_Api Int Stat_BrushKindLinearGradient(Int o);
Infra_Api Int Stat_BrushKindRadialGradient(Int o);
Infra_Api Int Stat_BrushKindConicalGradient(Int o);
Infra_Api Int Stat_BrushKindTexture(Int o);
Infra_Api Int Stat_PenKindSolid(Int o);
Infra_Api Int Stat_PenKindDash(Int o);
Infra_Api Int Stat_PenKindDot(Int o);
Infra_Api Int Stat_PenKindDashDot(Int o);
Infra_Api Int Stat_PenKindDashDotDot(Int o);
Infra_Api Int Stat_PenKindCustomDash(Int o);
Infra_Api Int Stat_PenCapFlat(Int o);
Infra_Api Int Stat_PenCapSquare(Int o);
Infra_Api Int Stat_PenCapRound(Int o);
Infra_Api Int Stat_PenJoinMiter(Int o);
Infra_Api Int Stat_PenJoinBevel(Int o);
Infra_Api Int Stat_PenJoinRound(Int o);
Infra_Api Int Stat_PenJoinSvgMiter(Int o);
Infra_Api Int Stat_CompositeSourceOver(Int o);
Infra_Api Int Stat_CompositeDestinationOver(Int o);
Infra_Api Int Stat_CompositeClear(Int o);
Infra_Api Int Stat_CompositeSource(Int o);
Infra_Api Int Stat_CompositeDestination(Int o);
Infra_Api Int Stat_CompositeSourceIn(Int o);
Infra_Api Int Stat_CompositeDestinationIn(Int o);
Infra_Api Int Stat_CompositeSourceOut(Int o);
Infra_Api Int Stat_CompositeDestinationOut(Int o);
Infra_Api Int Stat_CompositeSourceAtop(Int o);
Infra_Api Int Stat_CompositeDestinationAtop(Int o);
Infra_Api Int Stat_CompositeXor(Int o);
Infra_Api Int Stat_CompositePlus(Int o);
Infra_Api Int Stat_CompositeMultiply(Int o);
Infra_Api Int Stat_CompositeScreen(Int o);
Infra_Api Int Stat_CompositeOverlay(Int o);
Infra_Api Int Stat_CompositeDarken(Int o);
Infra_Api Int Stat_CompositeLighten(Int o);
Infra_Api Int Stat_CompositeColorDodge(Int o);
Infra_Api Int Stat_CompositeColorBurn(Int o);
Infra_Api Int Stat_CompositeHardLight(Int o);
Infra_Api Int Stat_CompositeSoftLight(Int o);
Infra_Api Int Stat_CompositeDifference(Int o);
Infra_Api Int Stat_CompositeExclusion(Int o);
Infra_Api Int Stat_GradientKindLinear(Int o);
Infra_Api Int Stat_GradientKindRadial(Int o);
Infra_Api Int Stat_GradientKindConical(Int o);
Infra_Api Int Stat_GradientSpreadPad(Int o);
Infra_Api Int Stat_GradientSpreadReflect(Int o);
Infra_Api Int Stat_GradientSpreadRepeat(Int o);
Infra_Api Int Stat_TextAlignLeft(Int o);
Infra_Api Int Stat_TextAlignRight(Int o);
Infra_Api Int Stat_TextAlignHCenter(Int o);
Infra_Api Int Stat_TextAlignJustify(Int o);
Infra_Api Int Stat_TextAlignTop(Int o);
Infra_Api Int Stat_TextAlignBottom(Int o);
Infra_Api Int Stat_TextAlignVCenter(Int o);
Infra_Api Int Stat_TextWrapWordWrap(Int o);
Infra_Api Int Stat_ImageFormatBmp(Int o);
Infra_Api Int Stat_ImageFormatJpg(Int o);
Infra_Api Int Stat_ImageFormatPng(Int o);

