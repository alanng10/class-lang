#pragma once

#ifdef __WIN64__
#define OS_Windows
#endif

#ifdef OS_Windows
#define ExportApi __declspec(dllexport)
#define ImportApi __declspec(dllimport)
#else
#define ExportApi __attribute__((__visibility__("default")))
#define ImportApi
#endif

#ifdef Infra_Module
#define Infra_Api ExportApi
#else
#define Infra_Api ImportApi
#endif

typedef unsigned char Byte;
typedef unsigned long long Bool;
typedef unsigned long long Int;
typedef long long SInt;
typedef unsigned int Int32;
typedef int SInt32;
typedef unsigned short Int16;
typedef short SInt16;
typedef Int32 Char;

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

#define CastInt(o) ((Int)(o))
#define CastPointer(o) ((void*)(o))

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
    o = Environ_New(count);\
    return o;\
}\
Int c##_Delete(Int o)\
{\
    Environ_Delete(o);\
    return true;\
}\


#define ClassNew(m, c) \
Int m##_##c##_New()\
{\
    Int count;\
    count = sizeof(c);\
    Int o;\
    o = Environ_New(count);\
    return o;\
}\
Int m##_##c##_Delete(Int o)\
{\
    Environ_Delete(o);\
    return true;\
}\


Infra_Api Int Environ_New(Int count);
Infra_Api Int Environ_Delete(Int any);
Infra_Api Int Environ_Copy(Int dest, Int source, Int count);
Infra_Api Int Environ_Exit(Int status);
Infra_Api Int Environ_System();

InfraApiNew(String)
Infra_Api Int String_ValueGet(Int o);
Infra_Api Int String_ValueSet(Int o, Int value);
Infra_Api Int String_CountGet(Int o);
Infra_Api Int String_CountSet(Int o, Int value);

Infra_Api Int String_Char(Int o, Int index);
Infra_Api Int String_Equal(Int o, Int other);

Infra_Api Int String_ConstantCreate(Int o);
Infra_Api Int String_ConstantDelete(Int o);

InfraApiNew(Console)
Infra_Api Int Console_OutWrite(Int o, Int text);
Infra_Api Int Console_ErrWrite(Int o, Int text);
Infra_Api Int Console_InnRead(Int o);

InfraApiNew(Array)
Infra_Api Int Array_CountGet(Int o);
Infra_Api Int Array_CountSet(Int o, Int value);

Infra_Api Int Array_ItemGet(Int o, Int index);
Infra_Api Int Array_ItemSet(Int o, Int index, Int value);

InfraApiNew(TextCode)
Infra_Api Int TextCode_ExecuteCount(Int o, Int innKind, Int outKind, Int dataValue, Int dataCount);
Infra_Api Int TextCode_ExecuteResult(Int o, Int result, Int innKind, Int outKind, Int dataValue, Int dataCount);

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
Infra_Api Int FormatArg_BaseGet(Int o);
Infra_Api Int FormatArg_BaseSet(Int o, Int value);
Infra_Api Int FormatArg_FillCharGet(Int o);
Infra_Api Int FormatArg_FillCharSet(Int o, Int value);
Infra_Api Int FormatArg_ValueCountGet(Int o);
Infra_Api Int FormatArg_ValueCountSet(Int o, Int value);
Infra_Api Int FormatArg_CountGet(Int o);
Infra_Api Int FormatArg_CountSet(Int o, Int value);
Infra_Api Int FormatArg_FormGet(Int o);
Infra_Api Int FormatArg_FormSet(Int o, Int value);

InfraApiNew(Math)
Infra_Api Int Math_Value(Int o, Int cand, Int expo);
Infra_Api Int Math_ValueTen(Int o, Int cand, Int expoTen);
Infra_Api Int Math_Less(Int o, Int valueA, Int valueB);
Infra_Api Int Math_Add(Int o, Int valueA, Int valueB);
Infra_Api Int Math_Sub(Int o, Int valueA, Int valueB);
Infra_Api Int Math_Mul(Int o, Int valueA, Int valueB);
Infra_Api Int Math_Div(Int o, Int valueA, Int valueB);
Infra_Api Int Math_Abs(Int o, Int value);
Infra_Api Int Math_Exp(Int o, Int value);
Infra_Api Int Math_Exp2(Int o, Int value);
Infra_Api Int Math_Log(Int o, Int value);
Infra_Api Int Math_Log10(Int o, Int value);
Infra_Api Int Math_Log2(Int o, Int value);
Infra_Api Int Math_Pow(Int o, Int valueA, Int valueB);
Infra_Api Int Math_Ceil(Int o, Int value);
Infra_Api Int Math_Floor(Int o, Int value);
Infra_Api Int Math_Trunc(Int o, Int value);
Infra_Api Int Math_Round(Int o, Int value);
Infra_Api Int Math_Sin(Int o, Int value);
Infra_Api Int Math_Cos(Int o, Int value);
Infra_Api Int Math_Tan(Int o, Int value);
Infra_Api Int Math_ASin(Int o, Int value);
Infra_Api Int Math_ACos(Int o, Int value);
Infra_Api Int Math_ATan(Int o, Int value);
Infra_Api Int Math_SinH(Int o, Int value);
Infra_Api Int Math_CosH(Int o, Int value);
Infra_Api Int Math_TanH(Int o, Int value);
Infra_Api Int Math_ASinH(Int o, Int value);
Infra_Api Int Math_ACosH(Int o, Int value);
Infra_Api Int Math_ATanH(Int o, Int value);

InfraApiNew(Rand)
Infra_Api Int Rand_SeedGet(Int o);
Infra_Api Int Rand_SeedSet(Int o, Int value);

Infra_Api Int Rand_Execute(Int o);

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
Infra_Api Int Pos_ColGet(Int o);
Infra_Api Int Pos_ColSet(Int o, Int value);
Infra_Api Int Pos_RowGet(Int o);
Infra_Api Int Pos_RowSet(Int o, Int value);

InfraApiNew(Size)
Infra_Api Int Size_WidthGet(Int o);
Infra_Api Int Size_WidthSet(Int o, Int value);
Infra_Api Int Size_HegthGet(Int o);
Infra_Api Int Size_HegthSet(Int o, Int value);

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

Infra_Api Int Main_Init(Int argc, Int argv);
Infra_Api Int Main_Final();
Infra_Api Int Main_IsCSharpSet(Int value);
Infra_Api Int Main_Arg();

typedef Int (*Main_Terminate_Maide)(Int arg);

InfraApiNew(Screen)
Infra_Api Int Screen_SizeGet(Int o);
Infra_Api Int Screen_SizeSet(Int o, Int value);
Infra_Api Int Screen_DimendGet(Int o);
Infra_Api Int Screen_DimendSet(Int o, Int value);

InfraApiNew(Frame)
Infra_Api Int Frame_TitleGet(Int o);
Infra_Api Int Frame_TitleSet(Int o, Int value);
Infra_Api Int Frame_ShownGet(Int o);
Infra_Api Int Frame_ShownSet(Int o, Int value);
Infra_Api Int Frame_TypeStateGet(Int o);
Infra_Api Int Frame_TypeStateSet(Int o, Int value);
Infra_Api Int Frame_DrawStateGet(Int o);
Infra_Api Int Frame_DrawStateSet(Int o, Int value);

Infra_Api Int Frame_TitleThisSet(Int o);
Infra_Api Int Frame_Out(Int o);
Infra_Api Int Frame_Update(Int o, Int rect);
Infra_Api Int Frame_Close(Int o);

typedef Int (*Frame_Type_Maide)(Int frame, Int arg, Int index, Int value);
typedef Int (*Frame_Draw_Maide)(Int frame, Int arg);

InfraApiNew(Draw)
Infra_Api Int Draw_SizeGet(Int o);
Infra_Api Int Draw_SizeSet(Int o, Int value);
Infra_Api Int Draw_OutGet(Int o);
Infra_Api Int Draw_OutSet(Int o, Int value);
Infra_Api Int Draw_AreaGet(Int o);
Infra_Api Int Draw_AreaSet(Int o, Int value);
Infra_Api Int Draw_FillGet(Int o);
Infra_Api Int Draw_FillSet(Int o, Int value);
Infra_Api Int Draw_FillPosGet(Int o);
Infra_Api Int Draw_FillPosSet(Int o, Int value);
Infra_Api Int Draw_LineGet(Int o);
Infra_Api Int Draw_LineSet(Int o, Int value);
Infra_Api Int Draw_FontGet(Int o);
Infra_Api Int Draw_FontSet(Int o, Int value);
Infra_Api Int Draw_FormGet(Int o);
Infra_Api Int Draw_FormSet(Int o, Int value);
Infra_Api Int Draw_CompGet(Int o);
Infra_Api Int Draw_CompSet(Int o, Int value);

Infra_Api Int Draw_Start(Int o);
Infra_Api Int Draw_End(Int o);
Infra_Api Int Draw_FillPosThisSet(Int o);
Infra_Api Int Draw_AreaThisSet(Int o);
Infra_Api Int Draw_Clear(Int o);
Infra_Api Int Draw_ExecuteRect(Int o, Int rect);
Infra_Api Int Draw_ExecuteRectRound(Int o, Int rect, Int colRadius, Int rowRadius);
Infra_Api Int Draw_ExecuteRound(Int o, Int rect);
Infra_Api Int Draw_ExecuteRoundLine(Int o, Int rect, Int range);
Infra_Api Int Draw_ExecuteRoundPart(Int o, Int rect, Int range);
Infra_Api Int Draw_ExecuteRoundShape(Int o, Int rect, Int range);
Infra_Api Int Draw_ExecuteLine(Int o, Int startPos, Int endPos);
Infra_Api Int Draw_ExecuteShape(Int o, Int pointListCount, Int pointListData);
Infra_Api Int Draw_ExecuteImage(Int o, Int image, Int destRect, Int sourceRect);
Infra_Api Int Draw_ExecuteText(Int o, Int text, Int colAlign, Int rowAlign, Int wordWrap, Int destRect, Int boundRect);

InfraApiNew(Brush)
Infra_Api Int Brush_KindGet(Int o);
Infra_Api Int Brush_KindSet(Int o, Int value);
Infra_Api Int Brush_ColorGet(Int o);
Infra_Api Int Brush_ColorSet(Int o, Int value);
Infra_Api Int Brush_PolateGet(Int o);
Infra_Api Int Brush_PolateSet(Int o, Int value);
Infra_Api Int Brush_ImageGet(Int o);
Infra_Api Int Brush_ImageSet(Int o, Int value);

InfraApiNew(Slash)
Infra_Api Int Slash_BrushGet(Int o);
Infra_Api Int Slash_BrushSet(Int o, Int value);
Infra_Api Int Slash_LineGet(Int o);
Infra_Api Int Slash_LineSet(Int o, Int value);
Infra_Api Int Slash_SizeGet(Int o);
Infra_Api Int Slash_SizeSet(Int o, Int value);
Infra_Api Int Slash_CapeGet(Int o);
Infra_Api Int Slash_CapeSet(Int o, Int value);
Infra_Api Int Slash_JoinGet(Int o);
Infra_Api Int Slash_JoinSet(Int o, Int value);

Infra_Api Int PointData_PointGet(Int memory, Int result);
Infra_Api Int PointData_PointSet(Int memory, Int pos);

InfraApiNew(Image)
Infra_Api Int Image_SizeGet(Int o);
Infra_Api Int Image_SizeSet(Int o, Int value);
Infra_Api Int Image_DataGet(Int o);
Infra_Api Int Image_DataSet(Int o, Int value);

Infra_Api Int Image_Out(Int o);
Infra_Api Int Image_DataCreate(Int o);

InfraApiNew(Font)
Infra_Api Int Font_NameGet(Int o);
Infra_Api Int Font_NameSet(Int o, Int value);
Infra_Api Int Font_SizeGet(Int o);
Infra_Api Int Font_SizeSet(Int o, Int value);
Infra_Api Int Font_StrongGet(Int o);
Infra_Api Int Font_StrongSet(Int o, Int value);
Infra_Api Int Font_TendenGet(Int o);
Infra_Api Int Font_TendenSet(Int o, Int value);
Infra_Api Int Font_StalineGet(Int o);
Infra_Api Int Font_StalineSet(Int o, Int value);
Infra_Api Int Font_MidlineGet(Int o);
Infra_Api Int Font_MidlineSet(Int o, Int value);
Infra_Api Int Font_EndlineGet(Int o);
Infra_Api Int Font_EndlineSet(Int o, Int value);

InfraApiNew(Form)
Infra_Api Int Form_Reset(Int o);
Infra_Api Int Form_Pos(Int o, Int col, Int row);
Infra_Api Int Form_Angle(Int o, Int angle);
Infra_Api Int Form_Scale(Int o, Int colScale, Int rowScale);
Infra_Api Int Form_ValueGet(Int o, Int col, Int row);
Infra_Api Int Form_ValueSet(Int o, Int col, Int row, Int value);
Infra_Api Int Form_Mul(Int o, Int other);
Infra_Api Int Form_Ident(Int o);
Infra_Api Int Form_IsInvertible(Int o);
Infra_Api Int Form_Invert(Int o, Int result);
Infra_Api Int Form_Transpose(Int o, Int result);

InfraApiNew(Polate)
Infra_Api Int Polate_KindGet(Int o);
Infra_Api Int Polate_KindSet(Int o, Int value);
Infra_Api Int Polate_ValueGet(Int o);
Infra_Api Int Polate_ValueSet(Int o, Int value);
Infra_Api Int Polate_StopGet(Int o);
Infra_Api Int Polate_StopSet(Int o, Int value);
Infra_Api Int Polate_SpreadGet(Int o);
Infra_Api Int Polate_SpreadSet(Int o, Int value);

InfraApiNew(PolateLinear)
Infra_Api Int PolateLinear_StartPosGet(Int o);
Infra_Api Int PolateLinear_StartPosSet(Int o, Int value);
Infra_Api Int PolateLinear_EndPosGet(Int o);
Infra_Api Int PolateLinear_EndPosSet(Int o, Int value);

InfraApiNew(PolateRadial)
Infra_Api Int PolateRadial_CenterPosGet(Int o);
Infra_Api Int PolateRadial_CenterPosSet(Int o, Int value);
Infra_Api Int PolateRadial_CenterRadiusGet(Int o);
Infra_Api Int PolateRadial_CenterRadiusSet(Int o, Int value);
Infra_Api Int PolateRadial_FocusPosGet(Int o);
Infra_Api Int PolateRadial_FocusPosSet(Int o, Int value);
Infra_Api Int PolateRadial_FocusRadiusGet(Int o);
Infra_Api Int PolateRadial_FocusRadiusSet(Int o, Int value);

InfraApiNew(PolateStop)
Infra_Api Int PolateStop_CountGet(Int o);
Infra_Api Int PolateStop_CountSet(Int o, Int value);

Infra_Api Int PolateStop_PointGetPos(Int o, Int index);
Infra_Api Int PolateStop_PointGetColor(Int o, Int index);
Infra_Api Int PolateStop_PointSet(Int o, Int index, Int pos, Int color);

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

Infra_Api Int ImageWrite_Execute(Int o);

InfraApiNew(FontStore)
Infra_Api Int FontStore_Add(Int o, Int data);
Infra_Api Int FontStore_Rem(Int o, Int ident);
Infra_Api Int FontStore_NameList(Int o);
Infra_Api Int FontStore_NameListIdent(Int o, Int ident);

InfraApiNew(VideoOut)
Infra_Api Int VideoOut_FrameGet(Int o);
Infra_Api Int VideoOut_FrameSet(Int o, Int value);
Infra_Api Int VideoOut_FrameEventStateGet(Int o);
Infra_Api Int VideoOut_FrameEventStateSet(Int o, Int value);

typedef Int (*VideoOut_FrameEvent_Maide)(Int videoOut, Int arg);
typedef Int (*VideoOut_Size_Maide)(Int videoOut, Int size, Int arg);

InfraApiNew(VideoFrame)
Infra_Api Int VideoFrame_SizeGet(Int o);
Infra_Api Int VideoFrame_SizeSet(Int o, Int value);

Infra_Api Int VideoFrame_Image(Int o, Int image);

InfraApiNew(AudioOut)
Infra_Api Int AudioOut_MuteGet(Int o);
Infra_Api Int AudioOut_MuteSet(Int o, Int value);
Infra_Api Int AudioOut_VolumeGet(Int o);
Infra_Api Int AudioOut_VolumeSet(Int o, Int value);

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

InfraApiNew(StorageComp)
Infra_Api Int StorageComp_Rename(Int o, Int path, Int destPath);
Infra_Api Int StorageComp_FileCopy(Int o, Int path, Int destPath);
Infra_Api Int StorageComp_FileDelete(Int o, Int path);
Infra_Api Int StorageComp_FoldCreate(Int o, Int path);
Infra_Api Int StorageComp_FoldCopy(Int o, Int path, Int destPath);
Infra_Api Int StorageComp_FoldDelete(Int o, Int path);
Infra_Api Int StorageComp_Entry(Int o, Int result, Int path);
Infra_Api Int StorageComp_EntryList(Int o, Int path, Int fold);
Infra_Api Int StorageComp_ThisFoldGet(Int o);
Infra_Api Int StorageComp_ThisFoldSet(Int o, Int path);

InfraApiNew(StorageEntry)
Infra_Api Int StorageEntry_NameGet(Int o);
Infra_Api Int StorageEntry_NameSet(Int o, Int value);
Infra_Api Int StorageEntry_ExistGet(Int o);
Infra_Api Int StorageEntry_ExistSet(Int o, Int value);
Infra_Api Int StorageEntry_FoldGet(Int o);
Infra_Api Int StorageEntry_FoldSet(Int o, Int value);
Infra_Api Int StorageEntry_SizeGet(Int o);
Infra_Api Int StorageEntry_SizeSet(Int o, Int value);
Infra_Api Int StorageEntry_CreateTimeGet(Int o);
Infra_Api Int StorageEntry_CreateTimeSet(Int o, Int value);
Infra_Api Int StorageEntry_ModifyTimeGet(Int o);
Infra_Api Int StorageEntry_ModifyTimeSet(Int o, Int value);
Infra_Api Int StorageEntry_OwnerGet(Int o);
Infra_Api Int StorageEntry_OwnerSet(Int o, Int value);
Infra_Api Int StorageEntry_GroupGet(Int o);
Infra_Api Int StorageEntry_GroupSet(Int o, Int value);
Infra_Api Int StorageEntry_PermitGet(Int o);
Infra_Api Int StorageEntry_PermitSet(Int o, Int value);

InfraApiNew(Network)
Infra_Api Int Network_HostNameGet(Int o);
Infra_Api Int Network_HostNameSet(Int o, Int value);
Infra_Api Int Network_HostPortGet(Int o);
Infra_Api Int Network_HostPortSet(Int o, Int value);
Infra_Api Int Network_StreamGet(Int o);
Infra_Api Int Network_StreamSet(Int o, Int value);
Infra_Api Int Network_ReadyCountGet(Int o);
Infra_Api Int Network_ReadyCountSet(Int o, Int value);
Infra_Api Int Network_StatusGet(Int o);
Infra_Api Int Network_StatusSet(Int o, Int value);
Infra_Api Int Network_CaseGet(Int o);
Infra_Api Int Network_CaseSet(Int o, Int value);
Infra_Api Int Network_StatusEventStateGet(Int o);
Infra_Api Int Network_StatusEventStateSet(Int o, Int value);
Infra_Api Int Network_CaseEventStateGet(Int o);
Infra_Api Int Network_CaseEventStateSet(Int o, Int value);
Infra_Api Int Network_DataEventStateGet(Int o);
Infra_Api Int Network_DataEventStateSet(Int o, Int value);

Infra_Api Int Network_Open(Int o);
Infra_Api Int Network_Close(Int o);

typedef Int (*Network_StatusEvent_Maide)(Int network, Int arg);
typedef Int (*Network_CaseEvent_Maide)(Int network, Int arg);
typedef Int (*Network_DataEvent_Maide)(Int network, Int arg);

InfraApiNew(NetworkHost)
Infra_Api Int NetworkHost_PortGet(Int o);
Infra_Api Int NetworkHost_PortSet(Int o, Int value);
Infra_Api Int NetworkHost_NewPeerStateGet(Int o);
Infra_Api Int NetworkHost_NewPeerStateSet(Int o, Int value);

Infra_Api Int NetworkHost_Open(Int o);
Infra_Api Int NetworkHost_Close(Int o);
Infra_Api Int NetworkHost_OpenPeer(Int o);
Infra_Api Int NetworkHost_ClosePeer(Int o, Int network);

typedef Int (*NetworkHost_NewPeer_Maide)(Int networkHost, Int arg);

InfraApiNew(NetworkPort)
Infra_Api Int NetworkPort_KindGet(Int o);
Infra_Api Int NetworkPort_KindSet(Int o, Int value);
Infra_Api Int NetworkPort_ValueAGet(Int o);
Infra_Api Int NetworkPort_ValueASet(Int o, Int value);
Infra_Api Int NetworkPort_ValueBGet(Int o);
Infra_Api Int NetworkPort_ValueBSet(Int o, Int value);
Infra_Api Int NetworkPort_ValueCGet(Int o);
Infra_Api Int NetworkPort_ValueCSet(Int o, Int value);
Infra_Api Int NetworkPort_HostGet(Int o);
Infra_Api Int NetworkPort_HostSet(Int o, Int value);

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
Infra_Api Int Thread_Pause(Int o);
Infra_Api Int Thread_Resume(Int o);
Infra_Api Int Thread_Wait(Int o);
Infra_Api Int Thread_ExecuteMain(Int o);
Infra_Api Int Thread_Exit(Int o, Int status);

Infra_Api Int Thread_This();

typedef Int (*Thread_Execute_Maide)(Int thread, Int arg);

InfraApiNew(Phore)
Infra_Api Int Phore_CountGet(Int o);
Infra_Api Int Phore_CountSet(Int o, Int value);
Infra_Api Int Phore_InitCountGet(Int o);
Infra_Api Int Phore_InitCountSet(Int o, Int value);

Infra_Api Int Phore_Open(Int o);
Infra_Api Int Phore_Close(Int o);

InfraApiNew(Time)
Infra_Api Int Time_YeaGet(Int o);
Infra_Api Int Time_YeaSet(Int o, Int value);
Infra_Api Int Time_MonGet(Int o);
Infra_Api Int Time_MonSet(Int o, Int value);
Infra_Api Int Time_DayGet(Int o);
Infra_Api Int Time_DaySet(Int o, Int value);
Infra_Api Int Time_OurGet(Int o);
Infra_Api Int Time_OurSet(Int o, Int value);
Infra_Api Int Time_MinGet(Int o);
Infra_Api Int Time_MinSet(Int o, Int value);
Infra_Api Int Time_SecGet(Int o);
Infra_Api Int Time_SecSet(Int o, Int value);
Infra_Api Int Time_TickGet(Int o);
Infra_Api Int Time_TickSet(Int o, Int value);
Infra_Api Int Time_PosGet(Int o);
Infra_Api Int Time_PosSet(Int o, Int value);
Infra_Api Int Time_YeaDayGet(Int o);
Infra_Api Int Time_YeaDaySet(Int o, Int value);
Infra_Api Int Time_WeekDayGet(Int o);
Infra_Api Int Time_WeekDaySet(Int o, Int value);
Infra_Api Int Time_YeaDayCountGet(Int o);
Infra_Api Int Time_YeaDayCountSet(Int o, Int value);
Infra_Api Int Time_MonDayCountGet(Int o);
Infra_Api Int Time_MonDayCountSet(Int o, Int value);
Infra_Api Int Time_TotalTickGet(Int o);
Infra_Api Int Time_TotalTickSet(Int o, Int value);

Infra_Api Int Time_AddYea(Int o, Int value);
Infra_Api Int Time_AddMon(Int o, Int value);
Infra_Api Int Time_AddDay(Int o, Int value);
Infra_Api Int Time_AddTick(Int o, Int value);
Infra_Api Int Time_This(Int o);
Infra_Api Int Time_ToPos(Int o, Int pos);
Infra_Api Int Time_Set(Int o, Int yea, Int mon, Int day, Int our, Int min, Int sec, Int tick, Int pos);

Infra_Api Int Time_LeapYea(Int yea);
Infra_Api Int Time_ValidDate(Int yea, Int mon, Int day);
Infra_Api Int Time_ValidTime(Int our, Int min, Int sec, Int tick);

InfraApiNew(TimeEvent)
Infra_Api Int TimeEvent_TimeGet(Int o);
Infra_Api Int TimeEvent_TimeSet(Int o, Int value);
Infra_Api Int TimeEvent_SingleGet(Int o);
Infra_Api Int TimeEvent_SingleSet(Int o, Int value);
Infra_Api Int TimeEvent_ActiveGet(Int o);
Infra_Api Int TimeEvent_ActiveSet(Int o, Int value);
Infra_Api Int TimeEvent_ElapseStateGet(Int o);
Infra_Api Int TimeEvent_ElapseStateSet(Int o, Int value);

Infra_Api Int TimeEvent_Start(Int o);
Infra_Api Int TimeEvent_Stop(Int o);

Infra_Api Int TimeEvent_Wait(Int time);

typedef Int (*TimeEvent_Elapse_Maide)(Int timeEvent, Int arg);

InfraApiNew(Program)
Infra_Api Int Program_NameGet(Int o);
Infra_Api Int Program_NameSet(Int o, Int value);
Infra_Api Int Program_ArgueGet(Int o);
Infra_Api Int Program_ArgueSet(Int o, Int value);
Infra_Api Int Program_WorkFoldGet(Int o);
Infra_Api Int Program_WorkFoldSet(Int o, Int value);
Infra_Api Int Program_EnvironGet(Int o);
Infra_Api Int Program_EnvironSet(Int o, Int value);
Infra_Api Int Program_IdentGet(Int o);
Infra_Api Int Program_IdentSet(Int o, Int value);
Infra_Api Int Program_StatusGet(Int o);
Infra_Api Int Program_StatusSet(Int o, Int value);

Infra_Api Int Program_Execute(Int o);
Infra_Api Int Program_Wait(Int o);
Infra_Api Int Program_Exit(Int o);

Infra_Api Int Infra_Share();

Infra_Api Int Share_Stat(Int o);

Infra_Api Int Stat_PointDataCount(Int o);
Infra_Api Int Stat_TextAlignStart(Int o);
Infra_Api Int Stat_TextAlignMid(Int o);
Infra_Api Int Stat_TextAlignEnd(Int o);
Infra_Api Int Stat_TextCodeKindUtf8(Int o);
Infra_Api Int Stat_TextCodeKindUtf16(Int o);
Infra_Api Int Stat_TextCodeKindUtf32(Int o);
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
Infra_Api Int Stat_StorageModeExist(Int o);
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
Infra_Api Int Stat_BrushKindColor(Int o);
Infra_Api Int Stat_BrushKindPolate(Int o);
Infra_Api Int Stat_BrushKindImage(Int o);
Infra_Api Int Stat_SlashLineSolid(Int o);
Infra_Api Int Stat_SlashLineDash(Int o);
Infra_Api Int Stat_SlashLineDot(Int o);
Infra_Api Int Stat_SlashLineDashDot(Int o);
Infra_Api Int Stat_SlashLineDashDotDot(Int o);
Infra_Api Int Stat_SlashCapePlane(Int o);
Infra_Api Int Stat_SlashCapeRight(Int o);
Infra_Api Int Stat_SlashCapeRound(Int o);
Infra_Api Int Stat_SlashJoinMiter(Int o);
Infra_Api Int Stat_SlashJoinBevel(Int o);
Infra_Api Int Stat_SlashJoinRound(Int o);
Infra_Api Int Stat_PolateKindLinear(Int o);
Infra_Api Int Stat_PolateKindRadial(Int o);
Infra_Api Int Stat_PolateSpreadClose(Int o);
Infra_Api Int Stat_PolateSpreadFlect(Int o);
Infra_Api Int Stat_PolateSpreadPeatt(Int o);
Infra_Api Int Stat_CompSource(Int o);
Infra_Api Int Stat_CompDest(Int o);
Infra_Api Int Stat_CompSourceOver(Int o);
Infra_Api Int Stat_CompDestOver(Int o);
Infra_Api Int Stat_CompSourceInn(Int o);
Infra_Api Int Stat_CompDestInn(Int o);
Infra_Api Int Stat_CompSourceOut(Int o);
Infra_Api Int Stat_CompDestOut(Int o);
Infra_Api Int Stat_ImageFormatBmp(Int o);
Infra_Api Int Stat_ImageFormatJpg(Int o);
Infra_Api Int Stat_ImageFormatPng(Int o);

