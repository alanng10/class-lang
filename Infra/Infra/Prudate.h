#pragma once

#ifdef __WIN64__
#define OS_Windows
#endif

#ifdef OS_Windows
#define ExportApi __declspec(dllexport)
#define ImportApi __declspec(dllimport)
#else
#define ExportApi __attribute__((visibility("default")))
#define ImportApi __attribute__((visibility("default")))
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
Infra_Api Int String_GetCount(Int o);
Infra_Api Int String_SetCount(Int o, Int value);
Infra_Api Int String_GetData(Int o);
Infra_Api Int String_SetData(Int o, Int value);

Infra_Api Int String_Char(Int o, Int index);
Infra_Api Int String_Equal(Int o, Int other);

Infra_Api Int String_ConstantCreate(Int o);
Infra_Api Int String_ConstantDelete(Int o);

InfraApiNew(Return)
Infra_Api Int Return_GetString(Int o);
Infra_Api Int Return_SetString(Int o, Int value);
Infra_Api Int Return_GetStringList(Int o);
Infra_Api Int Return_SetStringList(Int o, Int value);

Infra_Api Int Return_StringStart(Int o);
Infra_Api Int Return_StringEnd(Int o);
Infra_Api Int Return_StringCount(Int o);
Infra_Api Int Return_StringResult(Int o, Int result);
Infra_Api Int Return_StringListStart(Int o);
Infra_Api Int Return_StringListEnd(Int o);
Infra_Api Int Return_StringListCount(Int o);
Infra_Api Int Return_StringListItem(Int o, Int index);

InfraApiNew(Console)
Infra_Api Int Console_Write(Int o, Int text);
Infra_Api Int Console_ErrWrite(Int o, Int text);
Infra_Api Int Console_Read(Int o);

InfraApiNew(Array)
Infra_Api Int Array_GetCount(Int o);
Infra_Api Int Array_SetCount(Int o, Int value);

Infra_Api Int Array_GetItem(Int o, Int index);
Infra_Api Int Array_SetItem(Int o, Int index, Int value);

InfraApiNew(TextEncode)
Infra_Api Int TextEncode_GetKind(Int o);
Infra_Api Int TextEncode_SetKind(Int o, Int value);
Infra_Api Int TextEncode_GetWriteBom(Int o);
Infra_Api Int TextEncode_SetWriteBom(Int o, Int value);

Infra_Api Int TextEncode_GetStringCountMax(Int o, Int count);
Infra_Api Int TextEncode_GetString(Int o, Int result, Int data);
Infra_Api Int TextEncode_GetDataCountMax(Int o, Int count);
Infra_Api Int TextEncode_GetData(Int o, Int result, Int fromString);

InfraApiNew(Format)
Infra_Api Int Format_ExecuteCount(Int o, Int varBase, Int argList);
Infra_Api Int Format_ExecuteResult(Int o, Int varBase, Int argList, Int result);
Infra_Api Int Format_ExecuteArgCount(Int o, Int arg);
Infra_Api Int Format_ExecuteArgResult(Int o, Int arg, Int result);

InfraApiNew(FormatArg)
Infra_Api Int FormatArg_GetPos(Int o);
Infra_Api Int FormatArg_SetPos(Int o, Int value);
Infra_Api Int FormatArg_GetKind(Int o);
Infra_Api Int FormatArg_SetKind(Int o, Int value);
Infra_Api Int FormatArg_GetValue(Int o);
Infra_Api Int FormatArg_SetValue(Int o, Int value);
Infra_Api Int FormatArg_GetAlignLeft(Int o);
Infra_Api Int FormatArg_SetAlignLeft(Int o, Int value);
Infra_Api Int FormatArg_GetFieldWidth(Int o);
Infra_Api Int FormatArg_SetFieldWidth(Int o, Int value);
Infra_Api Int FormatArg_GetMaxWidth(Int o);
Infra_Api Int FormatArg_SetMaxWidth(Int o, Int value);
Infra_Api Int FormatArg_GetCase(Int o);
Infra_Api Int FormatArg_SetCase(Int o, Int value);
Infra_Api Int FormatArg_GetBase(Int o);
Infra_Api Int FormatArg_SetBase(Int o, Int value);
Infra_Api Int FormatArg_GetSign(Int o);
Infra_Api Int FormatArg_SetSign(Int o, Int value);
Infra_Api Int FormatArg_GetPrecision(Int o);
Infra_Api Int FormatArg_SetPrecision(Int o, Int value);
Infra_Api Int FormatArg_GetFillChar(Int o);
Infra_Api Int FormatArg_SetFillChar(Int o, Int value);
Infra_Api Int FormatArg_GetHasCount(Int o);
Infra_Api Int FormatArg_SetHasCount(Int o, Int value);
Infra_Api Int FormatArg_GetValueCount(Int o);
Infra_Api Int FormatArg_SetValueCount(Int o, Int value);
Infra_Api Int FormatArg_GetCount(Int o);
Infra_Api Int FormatArg_SetCount(Int o, Int value);

InfraApiNew(Math)
Infra_Api Int Math_GetValue(Int o, Int significand, Int exponent);
Infra_Api Int Math_GetValueTen(Int o, Int significand, Int exponentTen);
Infra_Api Int Math_GetCompose(Int o, Int value, Int significand, Int exponent);
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
Infra_Api Int Random_GetSeed(Int o);
Infra_Api Int Random_SetSeed(Int o, Int value);

Infra_Api Int Random_Execute(Int o);

InfraApiNew(Range)
Infra_Api Int Range_GetStart(Int o);
Infra_Api Int Range_SetStart(Int o, Int value);
Infra_Api Int Range_GetEnd(Int o);
Infra_Api Int Range_SetEnd(Int o, Int value);

InfraApiNew(Rect)
Infra_Api Int Rect_GetPos(Int o);
Infra_Api Int Rect_SetPos(Int o, Int value);
Infra_Api Int Rect_GetSize(Int o);
Infra_Api Int Rect_SetSize(Int o, Int value);

InfraApiNew(Pos)
Infra_Api Int Pos_GetLeft(Int o);
Infra_Api Int Pos_SetLeft(Int o, Int value);
Infra_Api Int Pos_GetUp(Int o);
Infra_Api Int Pos_SetUp(Int o, Int value);

InfraApiNew(Size)
Infra_Api Int Size_GetWidth(Int o);
Infra_Api Int Size_SetWidth(Int o, Int value);
Infra_Api Int Size_GetHeight(Int o);
Infra_Api Int Size_SetHeight(Int o, Int value);

InfraApiNew(Data)
Infra_Api Int Data_GetCount(Int o);
Infra_Api Int Data_SetCount(Int o, Int value);
Infra_Api Int Data_GetValue(Int o);
Infra_Api Int Data_SetValue(Int o, Int value);

InfraApiNew(Entry)
Infra_Api Int Entry_GetIndex(Int o);
Infra_Api Int Entry_SetIndex(Int o, Int value);
Infra_Api Int Entry_GetValue(Int o);
Infra_Api Int Entry_SetValue(Int o, Int value);

InfraApiNew(State)
Infra_Api Int State_GetMaide(Int o);
Infra_Api Int State_SetMaide(Int o, Int value);
Infra_Api Int State_GetArg(Int o);
Infra_Api Int State_SetArg(Int o, Int value);

Infra_Api Int Main_GetTerminateState();
Infra_Api Int Main_SetTerminateState(Int value);

Infra_Api Int Main_Init();
Infra_Api Int Main_Final();
Infra_Api Int Main_SetIsCSharp(Int value);
Infra_Api Int Main_ExecuteEventLoop();
Infra_Api Int Main_ExitEventLoop(Int code);

typedef Int (*Main_Terminate_Maide)(Int arg);

InfraApiNew(Frame)
Infra_Api Int Frame_GetTitle(Int o);
Infra_Api Int Frame_SetTitle(Int o, Int value);
Infra_Api Int Frame_GetVisible(Int o);
Infra_Api Int Frame_SetVisible(Int o, Int value);
Infra_Api Int Frame_GetResizeState(Int o);
Infra_Api Int Frame_SetResizeState(Int o, Int value);
Infra_Api Int Frame_GetTypeState(Int o);
Infra_Api Int Frame_SetTypeState(Int o, Int value);
Infra_Api Int Frame_GetMouseState(Int o);
Infra_Api Int Frame_SetMouseState(Int o, Int value);
Infra_Api Int Frame_GetDrawState(Int o);
Infra_Api Int Frame_SetDrawState(Int o, Int value);
Infra_Api Int Frame_GetWindowStat(Int o);
Infra_Api Int Frame_SetWindowStat(Int o, Int value);

Infra_Api Int Frame_GetVideoOut(Int o);
Infra_Api Int Frame_GetSize(Int o);
Infra_Api Int Frame_SetFrameTitle(Int o);
Infra_Api Int Frame_Update(Int o, Int rect);
Infra_Api Int Frame_Close(Int o);

typedef Int (*Frame_Resize_Maide)(Int frame, Int arg);
typedef Int (*Frame_Type_Maide)(Int frame, Int index, Int field, Int arg);
typedef Int (*Frame_Mouse_Maide)(Int frame, Int eventInfo, Int arg);
typedef Int (*Frame_Draw_Maide)(Int frame, Int arg);

InfraApiNew(Draw)
Infra_Api Int Draw_GetSize(Int o);
Infra_Api Int Draw_SetSize(Int o, Int value);
Infra_Api Int Draw_GetOut(Int o);
Infra_Api Int Draw_SetOut(Int o, Int value);
Infra_Api Int Draw_GetArea(Int o);
Infra_Api Int Draw_SetArea(Int o, Int value);
Infra_Api Int Draw_GetFillPos(Int o);
Infra_Api Int Draw_SetFillPos(Int o, Int value);
Infra_Api Int Draw_GetBrush(Int o);
Infra_Api Int Draw_SetBrush(Int o, Int value);
Infra_Api Int Draw_GetPen(Int o);
Infra_Api Int Draw_SetPen(Int o, Int value);
Infra_Api Int Draw_GetFont(Int o);
Infra_Api Int Draw_SetFont(Int o, Int value);
Infra_Api Int Draw_GetTransform(Int o);
Infra_Api Int Draw_SetTransform(Int o, Int value);
Infra_Api Int Draw_GetComposite(Int o);
Infra_Api Int Draw_SetComposite(Int o, Int value);

Infra_Api Int Draw_Start(Int o);
Infra_Api Int Draw_End(Int o);
Infra_Api Int Draw_SetDrawFillPos(Int o);
Infra_Api Int Draw_SetDrawArea(Int o);
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
Infra_Api Int Brush_GetKind(Int o);
Infra_Api Int Brush_SetKind(Int o, Int value);
Infra_Api Int Brush_GetColor(Int o);
Infra_Api Int Brush_SetColor(Int o, Int value);
Infra_Api Int Brush_GetImage(Int o);
Infra_Api Int Brush_SetImage(Int o, Int value);
Infra_Api Int Brush_GetGradient(Int o);
Infra_Api Int Brush_SetGradient(Int o, Int value);

InfraApiNew(Pen)
Infra_Api Int Pen_GetKind(Int o);
Infra_Api Int Pen_SetKind(Int o, Int value);
Infra_Api Int Pen_GetWidth(Int o);
Infra_Api Int Pen_SetWidth(Int o, Int value);
Infra_Api Int Pen_GetBrush(Int o);
Infra_Api Int Pen_SetBrush(Int o, Int value);
Infra_Api Int Pen_GetCap(Int o);
Infra_Api Int Pen_SetCap(Int o, Int value);
Infra_Api Int Pen_GetJoin(Int o);
Infra_Api Int Pen_SetJoin(Int o, Int value);

Infra_Api Int PointData_GetPoint(Int address, Int result);
Infra_Api Int PointData_SetPoint(Int address, Int pos);

InfraApiNew(Image)
Infra_Api Int Image_GetSize(Int o);
Infra_Api Int Image_SetSize(Int o, Int value);
Infra_Api Int Image_GetData(Int o);
Infra_Api Int Image_SetData(Int o, Int value);

Infra_Api Int Image_GetRowByteCount(Int o);
Infra_Api Int Image_GetVideoOut(Int o);
Infra_Api Int Image_CreateData(Int o);

InfraApiNew(Font)
Infra_Api Int Font_GetFamily(Int o);
Infra_Api Int Font_SetFamily(Int o, Int value);
Infra_Api Int Font_GetSize(Int o);
Infra_Api Int Font_SetSize(Int o, Int value);
Infra_Api Int Font_GetWeight(Int o);
Infra_Api Int Font_SetWeight(Int o, Int value);
Infra_Api Int Font_GetItalic(Int o);
Infra_Api Int Font_SetItalic(Int o, Int value);
Infra_Api Int Font_GetUnderline(Int o);
Infra_Api Int Font_SetUnderline(Int o, Int value);
Infra_Api Int Font_GetOverline(Int o);
Infra_Api Int Font_SetOverline(Int o, Int value);
Infra_Api Int Font_GetStrikeout(Int o);
Infra_Api Int Font_SetStrikeout(Int o, Int value);

InfraApiNew(Transform)
Infra_Api Int Transform_Reset(Int o);
Infra_Api Int Transform_Offset(Int o, Int offsetLeft, Int offsetUp);
Infra_Api Int Transform_Scale(Int o, Int horizScale, Int vertScale);
Infra_Api Int Transform_Rotate(Int o, Int angle);
Infra_Api Int Transform_GetValue(Int o, Int row, Int col);
Infra_Api Int Transform_SetValue(Int o, Int row, Int col, Int value);
Infra_Api Int Transform_Multiply(Int o, Int other);
Infra_Api Int Transform_IsIdentity(Int o);
Infra_Api Int Transform_IsInvertible(Int o);
Infra_Api Int Transform_Invert(Int o, Int result);
Infra_Api Int Transform_Transpose(Int o, Int result);
Infra_Api Int Transform_Determinant(Int o);

InfraApiNew(Gradient)
Infra_Api Int Gradient_GetKind(Int o);
Infra_Api Int Gradient_SetKind(Int o, Int value);
Infra_Api Int Gradient_GetValue(Int o);
Infra_Api Int Gradient_SetValue(Int o, Int value);
Infra_Api Int Gradient_GetStop(Int o);
Infra_Api Int Gradient_SetStop(Int o, Int value);
Infra_Api Int Gradient_GetSpread(Int o);
Infra_Api Int Gradient_SetSpread(Int o, Int value);

InfraApiNew(GradientLinear)
Infra_Api Int GradientLinear_GetStartPos(Int o);
Infra_Api Int GradientLinear_SetStartPos(Int o, Int value);
Infra_Api Int GradientLinear_GetEndPos(Int o);
Infra_Api Int GradientLinear_SetEndPos(Int o, Int value);

InfraApiNew(GradientRadial)
Infra_Api Int GradientRadial_GetCenterPos(Int o);
Infra_Api Int GradientRadial_SetCenterPos(Int o, Int value);
Infra_Api Int GradientRadial_GetCenterRadius(Int o);
Infra_Api Int GradientRadial_SetCenterRadius(Int o, Int value);
Infra_Api Int GradientRadial_GetFocusPos(Int o);
Infra_Api Int GradientRadial_SetFocusPos(Int o, Int value);
Infra_Api Int GradientRadial_GetFocusRadius(Int o);
Infra_Api Int GradientRadial_SetFocusRadius(Int o, Int value);

InfraApiNew(GradientStop)
Infra_Api Int GradientStop_GetCount(Int o);
Infra_Api Int GradientStop_SetCount(Int o, Int value);

Infra_Api Int GradientStop_GetPoint(Int o, Int index, Int pos, Int color);
Infra_Api Int GradientStop_SetPoint(Int o, Int index, Int pos, Int color);

InfraApiNew(ImageRead)
Infra_Api Int ImageRead_GetStream(Int o);
Infra_Api Int ImageRead_SetStream(Int o, Int value);
Infra_Api Int ImageRead_GetImage(Int o);
Infra_Api Int ImageRead_SetImage(Int o, Int value);

Infra_Api Int ImageRead_Execute(Int o);

InfraApiNew(ImageWrite)
Infra_Api Int ImageWrite_GetStream(Int o);
Infra_Api Int ImageWrite_SetStream(Int o, Int value);
Infra_Api Int ImageWrite_GetImage(Int o);
Infra_Api Int ImageWrite_SetImage(Int o, Int value);
Infra_Api Int ImageWrite_GetFormat(Int o);
Infra_Api Int ImageWrite_SetFormat(Int o, Int value);
Infra_Api Int ImageWrite_GetQuality(Int o);
Infra_Api Int ImageWrite_SetQuality(Int o, Int value);

Infra_Api Int ImageWrite_Execute(Int o);

InfraApiNew(Dialog)
Infra_Api Int Dialog_GetKind(Int o);
Infra_Api Int Dialog_SetKind(Int o, Int value);
Infra_Api Int Dialog_GetValue(Int o);
Infra_Api Int Dialog_SetValue(Int o, Int value);
Infra_Api Int Dialog_GetModal(Int o);
Infra_Api Int Dialog_SetModal(Int o, Int value);
Infra_Api Int Dialog_GetVisible(Int o);
Infra_Api Int Dialog_SetVisible(Int o, Int value);
Infra_Api Int Dialog_GetFinishedState(Int o);
Infra_Api Int Dialog_SetFinishedState(Int o, Int value);

Infra_Api Int Dialog_Done(Int o, Int result);

typedef Int (*Dialog_Finished_Maide)(Int dialog, Int result, Int arg);

InfraApiNew(DialogFile)
Infra_Api Int DialogFile_GetSave(Int o);
Infra_Api Int DialogFile_SetSave(Int o, Int value);
Infra_Api Int DialogFile_GetFileMode(Int o);
Infra_Api Int DialogFile_SetFileMode(Int o, Int value);
Infra_Api Int DialogFile_GetFold(Int o);
Infra_Api Int DialogFile_SetFold(Int o, Int value);

Infra_Api Int DialogFile_SelectedFileList(Int o);
Infra_Api Int DialogFile_SelectFile(Int o, Int fileName);

InfraApiNew(VideoOut)
Infra_Api Int VideoOut_GetSize(Int o);
Infra_Api Int VideoOut_SetSize(Int o, Int value);
Infra_Api Int VideoOut_GetFrame(Int o);
Infra_Api Int VideoOut_SetFrame(Int o, Int value);
Infra_Api Int VideoOut_GetSubtitle(Int o);
Infra_Api Int VideoOut_SetSubtitle(Int o, Int value);
Infra_Api Int VideoOut_GetFrameState(Int o);
Infra_Api Int VideoOut_SetFrameState(Int o, Int value);
Infra_Api Int VideoOut_GetSizeState(Int o);
Infra_Api Int VideoOut_SetSizeState(Int o, Int value);

Infra_Api Int VideoOut_SetVideoSubtitle(Int o);

typedef Int (*VideoOut_Frame_Maide)(Int videoOut, Int frame, Int arg);
typedef Int (*VideoOut_Size_Maide)(Int videoOut, Int size, Int arg);

InfraApiNew(VideoFrame)
Infra_Api Int VideoFrame_GetSize(Int o);
Infra_Api Int VideoFrame_SetSize(Int o, Int value);

Infra_Api Int VideoFrame_GetImage(Int o, Int image);

InfraApiNew(AudioOut)
Infra_Api Int AudioOut_GetMuted(Int o);
Infra_Api Int AudioOut_SetMuted(Int o, Int value);
Infra_Api Int AudioOut_GetVolume(Int o);
Infra_Api Int AudioOut_SetVolume(Int o, Int value);

InfraApiNew(AudioEffect)
Infra_Api Int AudioEffect_GetSource(Int o);
Infra_Api Int AudioEffect_SetSource(Int o, Int value);
Infra_Api Int AudioEffect_GetVolume(Int o);
Infra_Api Int AudioEffect_SetVolume(Int o, Int value);

Infra_Api Int AudioEffect_SetAudioSource(Int o);
Infra_Api Int AudioEffect_Play(Int o);
Infra_Api Int AudioEffect_Stop(Int o);

InfraApiNew(Play)
Infra_Api Int Play_GetSource(Int o);
Infra_Api Int Play_SetSource(Int o, Int value);
Infra_Api Int Play_GetVideoOut(Int o);
Infra_Api Int Play_SetVideoOut(Int o, Int value);
Infra_Api Int Play_GetAudioOut(Int o);
Infra_Api Int Play_SetAudioOut(Int o, Int value);
Infra_Api Int Play_GetTime(Int o);
Infra_Api Int Play_SetTime(Int o, Int value);
Infra_Api Int Play_GetPos(Int o);
Infra_Api Int Play_SetPos(Int o, Int value);

Infra_Api Int Play_SetPlaySource(Int o);
Infra_Api Int Play_HasVideo(Int o);
Infra_Api Int Play_HasAudio(Int o);
Infra_Api Int Play_Execute(Int o);
Infra_Api Int Play_Pause(Int o);
Infra_Api Int Play_Stop(Int o);

InfraApiNew(Stream)
Infra_Api Int Stream_GetKind(Int o);
Infra_Api Int Stream_SetKind(Int o, Int value);

Infra_Api Int Stream_GetCount(Int o);
Infra_Api Int Stream_SetCount(Int o, Int value);
Infra_Api Int Stream_GetPos(Int o);
Infra_Api Int Stream_SetPos(Int o, Int value);
Infra_Api Int Stream_HasCount(Int o);
Infra_Api Int Stream_HasPos(Int o);
Infra_Api Int Stream_CanRead(Int o);
Infra_Api Int Stream_CanWrite(Int o);
Infra_Api Int Stream_GetStatus(Int o);
Infra_Api Int Stream_Read(Int o, Int data, Int range);
Infra_Api Int Stream_Write(Int o, Int data, Int range);

InfraApiNew(Memory)
Infra_Api Int Memory_GetStream(Int o);
Infra_Api Int Memory_SetStream(Int o, Int value);

Infra_Api Int Memory_Open(Int o);
Infra_Api Int Memory_Close(Int o);

InfraApiNew(Storage)
Infra_Api Int Storage_GetPath(Int o);
Infra_Api Int Storage_SetPath(Int o, Int value);
Infra_Api Int Storage_GetMode(Int o);
Infra_Api Int Storage_SetMode(Int o, Int value);
Infra_Api Int Storage_GetStream(Int o);
Infra_Api Int Storage_SetStream(Int o, Int value);
Infra_Api Int Storage_GetStatus(Int o);
Infra_Api Int Storage_SetStatus(Int o, Int value);

Infra_Api Int Storage_Open(Int o);
Infra_Api Int Storage_Close(Int o);

InfraApiNew(StorageArrange)
Infra_Api Int StorageArrange_Copy(Int o, Int path, Int destPath);
Infra_Api Int StorageArrange_Rename(Int o, Int path, Int destPath);
Infra_Api Int StorageArrange_Remove(Int o, Int path);
Infra_Api Int StorageArrange_Exist(Int o, Int path);
Infra_Api Int StorageArrange_Link(Int o, Int path, Int linkPath);
Infra_Api Int StorageArrange_LinkTarget(Int o, Int path);
Infra_Api Int StorageArrange_GetPermit(Int o, Int path);
Infra_Api Int StorageArrange_SetPermit(Int o, Int path, Int value);
Infra_Api Int StorageArrange_MoveToTrash(Int o, Int path, Int trashPath);
Infra_Api Int StorageArrange_CreateFold(Int o, Int path, Int permit);
Infra_Api Int StorageArrange_CreateFoldToPath(Int o, Int path);
Infra_Api Int StorageArrange_RemoveFold(Int o, Int path);
Infra_Api Int StorageArrange_RemoveFoldRecursive(Int o, Int path);
Infra_Api Int StorageArrange_RenameFold(Int o, Int path, Int destPath);
Infra_Api Int StorageArrange_EntryCount(Int o, Int foldPath);
Infra_Api Int StorageArrange_EntryName(Int o, Int path);
Infra_Api Int StorageArrange_BaseName(Int o, Int name);
Infra_Api Int StorageArrange_Extension(Int o, Int name);
Infra_Api Int StorageArrange_AbsolutePath(Int o, Int path);
Infra_Api Int StorageArrange_RelativePath(Int o, Int path, Int destPath);
Infra_Api Int StorageArrange_CanonicalPath(Int o, Int path);
Infra_Api Int StorageArrange_CleanPath(Int o, Int path);

InfraApiNew(StorageWatch)
Infra_Api Int StorageWatch_GetFileChangedState(Int o);
Infra_Api Int StorageWatch_SetFileChangedState(Int o, Int value);
Infra_Api Int StorageWatch_GetFoldChangedState(Int o);
Infra_Api Int StorageWatch_SetFoldChangedState(Int o, Int value);

Infra_Api Int StorageWatch_AddPath(Int o, Int path);
Infra_Api Int StorageWatch_AddPathList(Int o, Int pathList);
Infra_Api Int StorageWatch_RemovePath(Int o, Int path);
Infra_Api Int StorageWatch_RemovePathList(Int o, Int pathList);
Infra_Api Int StorageWatch_FileList(Int o);
Infra_Api Int StorageWatch_FoldList(Int o);

typedef Int (*StorageWatch_FileChanged_Maide)(Int storageWatch, Int path, Int arg);
typedef Int (*StorageWatch_FoldChanged_Maide)(Int storageWatch, Int path, Int arg);

InfraApiNew(StorageEntry)
Infra_Api Int StorageEntry_GetPath(Int o);
Infra_Api Int StorageEntry_SetPath(Int o, Int value);
Infra_Api Int StorageEntry_GetKind(Int o);
Infra_Api Int StorageEntry_SetKind(Int o, Int value);
Infra_Api Int StorageEntry_GetCount(Int o);
Infra_Api Int StorageEntry_SetCount(Int o, Int value);
Infra_Api Int StorageEntry_GetIsReadable(Int o);
Infra_Api Int StorageEntry_SetIsReadable(Int o, Int value);
Infra_Api Int StorageEntry_GetIsHidden(Int o);
Infra_Api Int StorageEntry_SetIsHidden(Int o, Int value);
Infra_Api Int StorageEntry_GetIsExecutable(Int o);
Infra_Api Int StorageEntry_SetIsExecutable(Int o, Int value);

Infra_Api Int StorageEntry_CreateTime(Int o, Int result);
Infra_Api Int StorageEntry_LastModifyTime(Int o, Int result);
Infra_Api Int StorageEntry_LastReadTime(Int o, Int result);
Infra_Api Int StorageEntry_InfoChangeTime(Int o, Int result);
Infra_Api Int StorageEntry_Update(Int o);

InfraApiNew(Network)
Infra_Api Int Network_GetHostName(Int o);
Infra_Api Int Network_SetHostName(Int o, Int value);
Infra_Api Int Network_GetPort(Int o);
Infra_Api Int Network_SetPort(Int o, Int value);
Infra_Api Int Network_GetStream(Int o);
Infra_Api Int Network_SetStream(Int o, Int value);
Infra_Api Int Network_GetReadyCount(Int o);
Infra_Api Int Network_SetReadyCount(Int o, Int value);
Infra_Api Int Network_GetStatus(Int o);
Infra_Api Int Network_SetStatus(Int o, Int value);
Infra_Api Int Network_GetCase(Int o);
Infra_Api Int Network_SetCase(Int o, Int value);
Infra_Api Int Network_GetCaseChangedState(Int o);
Infra_Api Int Network_SetCaseChangedState(Int o, Int value);
Infra_Api Int Network_GetErrorState(Int o);
Infra_Api Int Network_SetErrorState(Int o, Int value);
Infra_Api Int Network_GetReadyReadState(Int o);
Infra_Api Int Network_SetReadyReadState(Int o, Int value);

Infra_Api Int Network_Open(Int o);
Infra_Api Int Network_Close(Int o);
Infra_Api Int Network_Abort(Int o);

typedef Int (*Network_CaseChanged_Maide)(Int network, Int arg);
typedef Int (*Network_Error_Maide)(Int network, Int arg);
typedef Int (*Network_ReadyRead_Maide)(Int network, Int arg);

InfraApiNew(NetworkServer)
Infra_Api Int NetworkServer_GetAddress(Int o);
Infra_Api Int NetworkServer_SetAddress(Int o, Int value);
Infra_Api Int NetworkServer_GetPort(Int o);
Infra_Api Int NetworkServer_SetPort(Int o, Int value);
Infra_Api Int NetworkServer_GetError(Int o);
Infra_Api Int NetworkServer_SetError(Int o, Int value);
Infra_Api Int NetworkServer_GetNewPeerState(Int o);
Infra_Api Int NetworkServer_SetNewPeerState(Int o, Int value);

Infra_Api Int NetworkServer_Listen(Int o);
Infra_Api Int NetworkServer_Close(Int o);
Infra_Api Int NetworkServer_IsListen(Int o);
Infra_Api Int NetworkServer_NextPendingPeer(Int o);
Infra_Api Int NetworkServer_ClosePeer(Int o, Int network);
Infra_Api Int NetworkServer_HasPendingPeer(Int o);
Infra_Api Int NetworkServer_PauseAccept(Int o);
Infra_Api Int NetworkServer_ResumeAccept(Int o);

typedef Int (*NetworkServer_NewPeer_Maide)(Int networkServer, Int arg);

InfraApiNew(NetworkAddress)
Infra_Api Int NetworkAddress_GetKind(Int o);
Infra_Api Int NetworkAddress_SetKind(Int o, Int value);
Infra_Api Int NetworkAddress_GetValueA(Int o);
Infra_Api Int NetworkAddress_SetValueA(Int o, Int value);
Infra_Api Int NetworkAddress_GetValueB(Int o);
Infra_Api Int NetworkAddress_SetValueB(Int o, Int value);
Infra_Api Int NetworkAddress_GetValueC(Int o);
Infra_Api Int NetworkAddress_SetValueC(Int o, Int value);

Infra_Api Int NetworkAddress_Set(Int o);

InfraApiNew(Thread)
Infra_Api Int Thread_GetIdent(Int o);
Infra_Api Int Thread_SetIdent(Int o, Int value);
Infra_Api Int Thread_GetExecuteState(Int o);
Infra_Api Int Thread_SetExecuteState(Int o, Int value);
Infra_Api Int Thread_GetStatus(Int o);
Infra_Api Int Thread_SetStatus(Int o, Int value);
Infra_Api Int Thread_GetCase(Int o);
Infra_Api Int Thread_SetCase(Int o, Int value);

Infra_Api Int Thread_Execute(Int o);
Infra_Api Int Thread_Terminate(Int o);
Infra_Api Int Thread_Pause(Int o);
Infra_Api Int Thread_Resume(Int o);
Infra_Api Int Thread_Wait(Int o);
Infra_Api Int Thread_ExecuteEventLoop(Int o);
Infra_Api Int Thread_ExitEventLoop(Int o, Int code);
Infra_Api Int Thread_IsMainThread(Int o);

Infra_Api Int Thread_Sleep(Int time);
Infra_Api Int Thread_GetCurrentThread();

typedef Int (*Thread_Execute_Maide)(Int thread, Int arg);

InfraApiNew(Mutex)
Infra_Api Int Mutex_Acquire(Int o);
Infra_Api Int Mutex_Release(Int o);

InfraApiNew(Semaphore)
Infra_Api Int Semaphore_GetCount(Int o);
Infra_Api Int Semaphore_SetCount(Int o, Int value);
Infra_Api Int Semaphore_GetInitCount(Int o);
Infra_Api Int Semaphore_SetInitCount(Int o, Int value);

Infra_Api Int Semaphore_Acquire(Int o);
Infra_Api Int Semaphore_Release(Int o);

InfraApiNew(Time)
Infra_Api Int Time_GetYear(Int o);
Infra_Api Int Time_SetYear(Int o, Int value);
Infra_Api Int Time_GetMonth(Int o);
Infra_Api Int Time_SetMonth(Int o, Int value);
Infra_Api Int Time_GetDay(Int o);
Infra_Api Int Time_SetDay(Int o, Int value);
Infra_Api Int Time_GetHour(Int o);
Infra_Api Int Time_SetHour(Int o, Int value);
Infra_Api Int Time_GetMinute(Int o);
Infra_Api Int Time_SetMinute(Int o, Int value);
Infra_Api Int Time_GetSecond(Int o);
Infra_Api Int Time_SetSecond(Int o, Int value);
Infra_Api Int Time_GetMillisecond(Int o);
Infra_Api Int Time_SetMillisecond(Int o, Int value);
Infra_Api Int Time_GetOffsetUtc(Int o);
Infra_Api Int Time_SetOffsetUtc(Int o, Int value);
Infra_Api Int Time_GetLocalTime(Int o);
Infra_Api Int Time_SetLocalTime(Int o, Int value);
Infra_Api Int Time_GetYearDay(Int o);
Infra_Api Int Time_SetYearDay(Int o, Int value);
Infra_Api Int Time_GetWeekDay(Int o);
Infra_Api Int Time_SetWeekDay(Int o, Int value);
Infra_Api Int Time_GetYearDayCount(Int o);
Infra_Api Int Time_SetYearDayCount(Int o, Int value);
Infra_Api Int Time_GetMonthDayCount(Int o);
Infra_Api Int Time_SetMonthDayCount(Int o, Int value);

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
Infra_Api Int Time_Set(Int o, Int year, Int month, Int day, Int hour, Int minute, Int second, Int millisecond, Int hasOffset, Int offsetUtc);

Infra_Api Int Time_LeapYear(Int year);
Infra_Api Int Time_ValidDate(Int year, Int month, Int day);
Infra_Api Int Time_ValidTime(Int hour, Int minute, Int second, Int millisecond);

InfraApiNew(Interval)
Infra_Api Int Interval_GetTime(Int o);
Infra_Api Int Interval_SetTime(Int o, Int value);
Infra_Api Int Interval_GetSingleShot(Int o);
Infra_Api Int Interval_SetSingleShot(Int o, Int value);
Infra_Api Int Interval_GetActive(Int o);
Infra_Api Int Interval_SetActive(Int o, Int value);
Infra_Api Int Interval_GetElapseState(Int o);
Infra_Api Int Interval_SetElapseState(Int o, Int value);

Infra_Api Int Interval_Start(Int o);
Infra_Api Int Interval_Stop(Int o);

typedef Int (*Interval_Elapse_Maide)(Int interval, Int arg);

InfraApiNew(Post)
Infra_Api Int Post_GetExecuteState(Int o);
Infra_Api Int Post_SetExecuteState(Int o, Int value);

Infra_Api Int Post_Execute(Int o);

typedef Int (*Post_Execute_Maide)(Int post, Int arg);

InfraApiNew(Libray)
Infra_Api Int Libray_GetFile(Int o);
Infra_Api Int Libray_SetFile(Int o, Int value);
Infra_Api Int Libray_GetLoaded(Int o);
Infra_Api Int Libray_SetLoaded(Int o, Int value);

Infra_Api Int Libray_SetLibraryFile(Int o);
Infra_Api Int Libray_Load(Int o);
Infra_Api Int Libray_Unload(Int o);
Infra_Api Int Libray_GetAddress(Int o, Int name);

InfraApiNew(Process)
Infra_Api Int Process_GetProgram(Int o);
Infra_Api Int Process_SetProgram(Int o, Int value);
Infra_Api Int Process_GetArgue(Int o);
Infra_Api Int Process_SetArgue(Int o, Int value);
Infra_Api Int Process_GetWorkFold(Int o);
Infra_Api Int Process_SetWorkFold(Int o, Int value);
Infra_Api Int Process_GetEnvironment(Int o);
Infra_Api Int Process_SetEnvironment(Int o, Int value);
Infra_Api Int Process_GetStartedState(Int o);
Infra_Api Int Process_SetStartedState(Int o, Int value);
Infra_Api Int Process_GetFinishedState(Int o);
Infra_Api Int Process_SetFinishedState(Int o, Int value);
Infra_Api Int Process_GetReadOutState(Int o);
Infra_Api Int Process_SetReadOutState(Int o, Int value);
Infra_Api Int Process_GetReadErrState(Int o);
Infra_Api Int Process_SetReadErrState(Int o, Int value);

Infra_Api Int Process_Execute(Int o);
Infra_Api Int Process_GetIdent(Int o);
Infra_Api Int Process_Wait(Int o);
Infra_Api Int Process_Terminate(Int o);
Infra_Api Int Process_GetStatus(Int o);
Infra_Api Int Process_GetExitKind(Int o);
Infra_Api Int Process_ReadOut(Int o);
Infra_Api Int Process_ReadErr(Int o);

typedef Int (*Process_Started_Maide)(Int process, Int arg);
typedef Int (*Process_Finished_Maide)(Int process, Int arg);
typedef Int (*Process_ReadOut_Maide)(Int process, Int arg);
typedef Int (*Process_ReadErr_Maide)(Int process, Int arg);

InfraApiNew(ProcessSemaphore)
Infra_Api Int ProcessSemaphore_GetName(Int o);
Infra_Api Int ProcessSemaphore_SetName(Int o, Int value);
Infra_Api Int ProcessSemaphore_GetInitCount(Int o);
Infra_Api Int ProcessSemaphore_SetInitCount(Int o, Int value);
Infra_Api Int ProcessSemaphore_GetCreate(Int o);
Infra_Api Int ProcessSemaphore_SetCreate(Int o, Int value);
Infra_Api Int ProcessSemaphore_GetStatus(Int o);
Infra_Api Int ProcessSemaphore_SetStatus(Int o, Int value);

Infra_Api Int ProcessSemaphore_Acquire(Int o);
Infra_Api Int ProcessSemaphore_Release(Int o);

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
Infra_Api Int Stat_NetworkAddressKindIPv6(Int o);
Infra_Api Int Stat_NetworkAddressKindIPv4(Int o);
Infra_Api Int Stat_NetworkAddressKindBroadcast(Int o);
Infra_Api Int Stat_NetworkAddressKindLocalHost(Int o);
Infra_Api Int Stat_NetworkAddressKindLocalHostIPv6(Int o);
Infra_Api Int Stat_NetworkAddressKindAny(Int o);
Infra_Api Int Stat_NetworkAddressKindAnyIPv6(Int o);
Infra_Api Int Stat_NetworkAddressKindAnyIPv4(Int o);
Infra_Api Int Stat_NetworkCaseUnconnected(Int o);
Infra_Api Int Stat_NetworkCaseHostLookup(Int o);
Infra_Api Int Stat_NetworkCaseConnecting(Int o);
Infra_Api Int Stat_NetworkCaseConnected(Int o);
Infra_Api Int Stat_NetworkCaseBound(Int o);
Infra_Api Int Stat_NetworkCaseListening(Int o);
Infra_Api Int Stat_NetworkCaseClosing(Int o);
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

