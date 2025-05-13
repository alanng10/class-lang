#include "Demo.h"

Int Frame;
Int Text;
Int Brush;
Int ImageBrush;
Int PolateBrush;
Int FillLeft;
Int FillUp;
Int RectA;
Int RectB;
Int PosA;
Int PosB;
Int RangeA;
Int RotateAngle;
Int PenRect;
Int PenText;
Int PointListCount;
Int PointListData;
Int Font;
Int TextAlignHoriz;
Int TextAlignVert;
Int Image;
Int Form;
Int Draw;
Int AreaOffset;
Int UpdateRect;
Int Stat;
SInt TextLeft;
SInt TextUp;
Int Play;
Int PlayA;
Int PlayImage;
Int VideoFrame;
Int Console;

Bool TypeHandle(Int frame, Int arg, Int index, Int value)
{
    Bool b;
    b = false;

    if (value == 0)
    {
        if (index == 'A')
        {
            TextLeft = TextLeft - 10;

            b = true;
        }
        if (index == 'D')
        {
            TextLeft = TextLeft + 10;

            b = true;
        }
        if (index == 'W')
        {
            TextUp = TextUp - 10;

            b = true;
        }
        if (index == 'S')
        {
            TextUp = TextUp + 10;

            b = true;
        }

        if (index == 'J')
        {
            FillLeft = FillLeft - 10;

            b = true;
        }
        if (index == 'L')
        {
            FillLeft = FillLeft + 10;

            b = true;
        }
        if (index == 'I')
        {
            FillUp = FillUp - 10;

            b = true;
        }
        if (index == 'K')
        {
            FillUp = FillUp + 10;

            b = true;
        }

        if (index == 'N')
        {
            AreaOffset = 0;

            b = true;
        }
        if (index == 'M')
        {
            AreaOffset = AreaOffset + 100;

            b = true;
        }

        if (index == 'O')
        {
            RotateAngle = RotateAngle + 5;

            b = true;
        }

        if (index == 'E')
        {
            Play_Execute(PlayA);
        }
        if (index == 'R')
        {
            Play_Pause(PlayA);
        }
        if (index == 'T')
        {
            Play_Stop(PlayA);
        }
        if (index == 'G')
        {
            Int kaa;
            kaa = Play_AudioOutGet(PlayA);

            Bool kab;
            kab = AudioOut_MuteGet(kaa);

            kab = !kab;

            AudioOut_MuteSet(kaa, kab);
        }

        if (index == 'Y')
        {
            Play_Execute(Play);
        }
        if (index == 'U')
        {
            Play_Stop(Play);
        }
        if (index == 'H')
        {
            Int kac;
            kac = Play_AudioOutGet(Play);

            Bool kad;
            kad = AudioOut_MuteGet(kac);

            kad = !kad;

            AudioOut_MuteSet(kac, kad);
        }

        if (index == 'B')
        {
            Frame_Close(Frame);
        }
    }

    if (b)
    {
        Frame_Update(Frame, UpdateRect);
    }

    return true;
}

Bool SetRect(Int rect, Int left, Int up, Int width, Int height)
{
    Int pos;
    Int size;
    pos = Rect_PosGet(rect);
    size = Rect_SizeGet(rect);

    SetPos(pos, left, up);

    SetSize(size, width, height);
    return true;
}

Bool SetPos(Int pos, Int left, Int up)
{
    Pos_ColSet(pos, left);
    Pos_RowSet(pos, up);
    return true;
}

Bool SetSize(Int size, Int width, Int height)
{
    Size_WedSet(size, width);
    Size_HetSet(size, height);
    return true;
}

Bool SetRange(Int range, Int index, Int count)
{
    Range_IndexSet(range, index);
    Range_CountSet(range, count);
    return true;
}

Int MathInt(Int n)
{
    return Math_Value(0, n, 0);
}

Int ConsoleWriteConstant(const char* o)
{
    Int u;
    u = CastInt(o);

    Int a;
    a = String_ConstantCreate(u);

    Console_OutWrite(Console, a);

    String_ConstantDelete(a);
    return true;
}

Int DrawHandle(Int frame, Int arg)
{
    Draw_Start(Draw);

    Draw_Clear(Draw);

    Int area;
    area = Draw_AreaGet(Draw);

    Int areaPos;
    areaPos = Rect_PosGet(area);
    Int areaSize;
    areaSize = Rect_SizeGet(area);

    Int areaLeft;
    Int areaUp;
    Int areaWidth;
    Int areaHeight;

    areaLeft = Pos_ColGet(areaPos);
    areaUp = Pos_RowGet(areaPos);
    areaWidth = Size_WedGet(areaSize);
    areaHeight = Size_HetGet(areaSize);

    Int aSize;
    aSize = Draw_SizeGet(Draw);

    Int aWidth;
    Int aHeight;
    aWidth = Size_WedGet(aSize);
    aHeight = Size_HetGet(aSize);

    areaLeft = AreaOffset;
    areaUp = AreaOffset;
    areaWidth = aWidth - 2 * AreaOffset;
    areaHeight = aHeight - 2 * AreaOffset;

    SetPos(areaPos, areaLeft, areaUp);

    SetSize(areaSize, areaWidth, areaHeight);

    Draw_AreaThisSet(Draw);

    SetRect(RectA, 100, 50, 1600, 900);
    SetRect(RectB, 0, 0, 1920, 1080);
    Draw_ExecuteImage(Draw, PlayImage, RectA, RectB);

    Draw_FillSet(Draw, Brush);
    Draw_LineSet(Draw, PenRect);

    SetRect(RectA, MathInt(100), MathInt(100), MathInt(200), MathInt(200));
    Draw_ExecuteRect(Draw, RectA);

    SetPos(PosA, MathInt(120), MathInt(470));
    SetPos(PosB, MathInt(230), MathInt(370));
    Draw_ExecuteLine(Draw, PosA, PosB);

    Draw_LineSet(Draw, PenRect);

    SetRect(RectA, MathInt(500), MathInt(350), MathInt(100), MathInt(100));
    SetRange(RangeA, 100 * 16, 120 * 16);
    Draw_ExecuteRoundLine(Draw, RectA, RangeA);

    SetRect(RectA, MathInt(500), MathInt(550), MathInt(100), MathInt(100));
    SetRange(RangeA, 120 * 16, 160 * 16);
    Draw_ExecuteRoundShape(Draw, RectA, RangeA);

    Draw_LineSet(Draw, null);

    SetRect(RectA, MathInt(500), MathInt(200), MathInt(100), MathInt(100));
    SetRange(RangeA, 10 * 16, 80 * 16);
    Draw_ExecuteRoundPart(Draw, RectA, RangeA);

    Draw_LineSet(Draw, PenRect);

    SetRect(RectA, MathInt(130), MathInt(550), MathInt(150), MathInt(100));
    Draw_ExecuteRound(Draw, RectA);

    Int scaleFactor;
    scaleFactor = (1 << 20);

    Draw_FillSet(Draw, PolateBrush);

    SetRect(RectA, MathInt(1400), MathInt(200), MathInt(250), MathInt(110));
    Draw_ExecuteRectRound(Draw, RectA, MathInt(30), MathInt(23));

    Draw_FillSet(Draw, ImageBrush);

    Int fillPos;
    fillPos = Draw_FillPosGet(Draw);

    SetPos(fillPos, MathInt(FillLeft), MathInt(FillUp));
    Draw_FillPosThisSet(Draw);

    Draw_LineSet(Draw, PenRect);

    Form_Reset(Form);
    Form_Pos(Form, MathInt(-780), MathInt(-450));
    Form_Scale(Form, MathInt(1), Math_Value(0, 1 * scaleFactor + (1 << 18), -20));
    Form_Angle(Form, MathInt(RotateAngle + 30));
    Form_Pos(Form, MathInt(1080), MathInt(-600));

    Draw_FormSet(Draw, Form);

    Draw_ExecuteShape(Draw, PointListCount, PointListData);

    Draw_FormSet(Draw, null);

    SetPos(fillPos, MathInt(0), MathInt(0));
    Draw_FillPosThisSet(Draw);

    Form_Reset(Form);
    Form_Pos(Form, MathInt(500), MathInt(100));

    Draw_FormSet(Draw, Form);

    Draw_ExecuteShapeLine(Draw, PointListCount, PointListData);

    Draw_FormSet(Draw, null);

    SetRect(RectA, MathInt(850), MathInt(150), MathInt(150), MathInt(150));
    SetRect(RectB, MathInt(50), MathInt(10), MathInt(150), MathInt(150));
    Draw_ExecuteImage(Draw, Image, RectA, RectB);

    Draw_FillSet(Draw, null);

    Draw_LineSet(Draw, PenRect);

    SetRect(RectA, MathInt(400 + TextLeft), MathInt(400 + TextUp), MathInt(300), MathInt(100));
    Draw_ExecuteRect(Draw, RectA);

    Draw_FontSet(Draw, Font);

    Draw_LineSet(Draw, PenText);

    SetRect(RectA, MathInt(400 + TextLeft), MathInt(400 + TextUp), MathInt(300), MathInt(100));
    Draw_ExecuteText(Draw, Text, TextAlignHoriz, TextAlignVert, false, RectA, RectB);

    Draw_FontSet(Draw, null);

    Draw_End(Draw);
    return true;
}

Int VideoOutFrameHandle(Int videoOut, Int arg)
{
    VideoFrame_Image(VideoFrame, PlayImage);

    Frame_Update(Frame, UpdateRect);

    return 0;
}

int main(int argc, char* argv[])
{
    Int kaaa;
    Int kaab;
    kaaa = argc;
    kaab = CastInt(argv);

    Main_Init(kaaa, kaab);

    Console = Console_New();

    Console_Init(Console);
    
    Int argArray;
    argArray = Main_Arg();

    Int argCount;
    argCount = Array_CountGet(argArray);

    Int argIndex;
    argIndex = 0;
    while (argIndex < argCount)
    {
        Int argA;
        argA = Array_ItemGet(argArray, argIndex);
        
        Console_OutWrite(Console, argA);

        ConsoleWriteConstant("\n");

        argIndex = argIndex + 1;
    }

    ConsoleWriteConstant("DEMO HELLO\n");

    ConsoleWriteConstant("DEMO 的 阿卡 HELLO\n");

    Int formatBase;
    formatBase = String_ConstantCreate(CastInt("Format Int: \n"));

    Int formatArgList;
    formatArgList = Array_New();
    Array_CountSet(formatArgList, 1);
    Array_Init(formatArgList);

    Int formatArg;
    formatArg = FormatArg_New();
    FormatArg_Init(formatArg);

    FormatArg_PosSet(formatArg, 12);
    FormatArg_KindSet(formatArg, 1);
    FormatArg_ValueSet(formatArg, 0xf9e74a2);
    FormatArg_AlignLeftSet(formatArg, false);
    FormatArg_FieldWidthSet(formatArg, 0);
    FormatArg_MaxWidthSet(formatArg, -1);

    FormatArg_Final(formatArg);
    FormatArg_Delete(formatArg);

    Array_Final(formatArgList);
    Array_Delete(formatArgList);

    String_ConstantDelete(formatBase);

    Int stringAa;
    Int stringAb;
    stringAa = String_ConstantCreate(CastInt("Phore Init Count Success\n"));
    stringAb = String_ConstantCreate(CastInt("Phore Init Count Error\n"));

    Int phoreInitCount;
    phoreInitCount = 467;

    Int phore;
    phore = Phore_New();

    Phore_InitCountSet(phore, phoreInitCount);

    Phore_Init(phore);

    Int phoreCount;
    phoreCount = Phore_CountGet(phore);

    Phore_Final(phore);

    Phore_Delete(phore);

    Bool phoreB;
    phoreB = (phoreCount == phoreInitCount);

    Int stringAc;
    stringAc = stringAa;

    if (!phoreB)
    {
        stringAc = stringAb;
    }

    Console_OutWrite(Console, stringAc);

    String_ConstantDelete(stringAb);

    String_ConstantDelete(stringAa);

    Int share;

    share = Infra_Share();

    Stat = Share_Stat(share);

    Int brushKind;
    brushKind = Stat_BrushKindColor(Stat);

    Brush = Brush_New();
    Brush_KindSet(Brush, brushKind);
    Brush_ColorSet(Brush, 0xff0000ff);
    Brush_Init(Brush);

    Int penRectBrushKind;
    penRectBrushKind = Stat_BrushKindColor(Stat);

    Int penRectLine;
    penRectLine = Stat_SlashLineDashDot(Stat);

    Int penRectCape;
    penRectCape = Stat_SlashCapeRound(Stat);

    Int penRectJoin;
    penRectJoin = Stat_SlashJoinBevel(Stat);

    Int penRectBrush;
    penRectBrush = Brush_New();
    Brush_KindSet(penRectBrush, penRectBrushKind);
    Brush_ColorSet(penRectBrush, 0xff00ff00);
    Brush_Init(penRectBrush);

    PenRect = Slash_New();
    Slash_BrushSet(PenRect, penRectBrush);
    Slash_LineSet(PenRect, penRectLine);
    Slash_SizeSet(PenRect, 10);
    Slash_CapeSet(PenRect, penRectCape);
    Slash_JoinSet(PenRect, penRectJoin);
    Slash_Init(PenRect);

    Int penTextBrushKind;
    penTextBrushKind = Stat_BrushKindColor(Stat);

    Int penTextLine;
    penTextLine = Stat_SlashLineSolid(Stat);

    Int penTextCape;
    penTextCape = Stat_SlashCapePlane(Stat);

    Int penTextJoin;
    penTextJoin = Stat_SlashJoinMiter(Stat);

    Int penTextBrush;
    penTextBrush = Brush_New();
    Brush_KindSet(penTextBrush, penTextBrushKind);
    Brush_ColorSet(penTextBrush, 0xff0000ff);
    Brush_Init(penTextBrush);

    PenText = Slash_New();
    Slash_BrushSet(PenText, penTextBrush);
    Slash_LineSet(PenText, penTextLine);
    Slash_SizeSet(PenText, 4);
    Slash_CapeSet(PenText, penTextCape);
    Slash_JoinSet(PenText, penTextJoin);
    Slash_Init(PenText);

    Int rectPosA;
    Int rectSizeA;
    rectPosA = Pos_New();
    Pos_Init(rectPosA);
    rectSizeA = Size_New();
    Size_Init(rectSizeA);

    RectA = Rect_New();
    Rect_Init(RectA);
    Rect_PosSet(RectA, rectPosA);
    Rect_SizeSet(RectA, rectSizeA);

    Int rectPosB;
    Int rectSizeB;
    rectPosB = Pos_New();
    Pos_Init(rectPosB);
    rectSizeB = Size_New();
    Size_Init(rectSizeB);

    RectB = Rect_New();
    Rect_Init(RectB);
    Rect_PosSet(RectB, rectPosB);
    Rect_SizeSet(RectB, rectSizeB);

    PosA = Pos_New();
    Pos_Init(PosA);

    PosB = Pos_New();
    Pos_Init(PosB);

    RangeA = Range_New();
    Range_Init(RangeA);

    Int pointDataCount;
    pointDataCount = Stat_PointDataCount(Stat);

    PointListCount = 6;

    Int pointListDataCount;
    pointListDataCount = PointListCount * pointDataCount;

    Int pointListDataValue;
    pointListDataValue = Environ_New(pointListDataCount);

    PointListData = Data_New();
    Data_Init(PointListData);
    Data_CountSet(PointListData, pointListDataCount);
    Data_ValueSet(PointListData, pointListDataValue);

    Int pointDataArray[6][2] =
    {
        { 900, 400 },
        { 800, 430 },
        { 810, 600 },
        { 1000, 580 },
        { 1010, 440 },
        { 980, 420 },
    };

    Int iia;
    iia = 0;
    while (iia < PointListCount)
    {
        Int uuua;
        Int uuub;

        uuua = pointDataArray[iia][0];
        uuub = pointDataArray[iia][1];

        SetPos(PosA, MathInt(uuua), MathInt(uuub));

        PointData_PointSet(pointListDataValue + iia * pointDataCount, PosA);

        iia = iia + 1;
    }

    Int fontName;
    fontName = String_ConstantCreate(CastInt("Source Sans 3"));

    Font = Font_New();
    Font_NameSet(Font, fontName);
    Font_SizeSet(Font, 16);
    Font_StrongSet(Font, 600);
    Font_TendenSet(Font, true);
    Font_StalineSet(Font, true);
    Font_MidlineSet(Font, true);
    Font_EndlineSet(Font, true);
    Font_Init(Font);

    TextAlignHoriz = Stat_TextAlignEnd(Stat);
    TextAlignVert = Stat_TextAlignMid(Stat);

    Int imagePath;
    imagePath = String_ConstantCreate(CastInt("DemoImage.png"));

    Int stream;
    stream = Stream_New();
    Stream_Init(stream);

    Int storageMode;
    storageMode = Stat_StorageModeRead(Stat);

    Int storage;
    storage = Storage_New();
    Storage_Init(storage);

    Storage_PathSet(storage, imagePath);
    Storage_ModeSet(storage, storageMode);
    Storage_StreamSet(storage, stream);

    Storage_Open(storage);

    Int imageRead;
    imageRead = ImageRead_New();
    ImageRead_Init(imageRead);

    ImageRead_StreamSet(imageRead, stream);

    Int imageSize;
    imageSize = Size_New();
    Size_Init(imageSize);

    Int imageData;
    imageData = Data_New();
    Data_Init(imageData);

    Image = Image_New();
    Image_SizeSet(Image, imageSize);
    Image_DataSet(Image, imageData);
    Image_Init(Image);

    ImageRead_ImageSet(imageRead, Image);
    ImageRead_Execute(imageRead);

    Storage_Close(storage);

    Int memory;
    memory = Memory_New();
    Memory_Init(memory);

    Memory_StreamSet(memory, stream);

    Memory_Open(memory);

    Int stringOa;
    stringOa = String_ConstantCreate(CastInt("ABCD GGHH o4\n"));

    Int memoryDataValue;
    memoryDataValue = String_ValueGet(stringOa);

    Int memoryDataCount;
    memoryDataCount = String_CountGet(stringOa) * Constant_CharByteCount();

    Int dataA;
    dataA = Data_New();
    Data_Init(dataA);
    Data_CountSet(dataA, memoryDataCount);
    Data_ValueSet(dataA, memoryDataValue);

    SetRange(RangeA, 0, memoryDataCount);

    Stream_Write(stream, dataA, RangeA);

    Int stringCountA;
    stringCountA = 8;

    memoryDataCount = stringCountA * Constant_CharByteCount();

    Int dataValueA;
    dataValueA = Environ_New(memoryDataCount);

    Data_CountSet(dataA, memoryDataCount);
    Data_ValueSet(dataA, dataValueA);

    SetRange(RangeA, 0, memoryDataCount);

    Stream_PosSet(stream, 5 * Constant_CharByteCount());

    Stream_Read(stream, dataA, RangeA);

    Int stringOb;
    stringOb = String_New();
    String_Init(stringOb);
    String_CountSet(stringOb, stringCountA);
    String_ValueSet(stringOb, dataValueA);

    Console_OutWrite(Console, stringOb);

    String_Final(stringOb);
    String_Delete(stringOb);

    Environ_Delete(dataValueA);

    Data_Final(dataA);
    Data_Delete(dataA);

    String_ConstantDelete(stringOa);

    Memory_Close(memory);

    Memory_Final(memory);
    Memory_Delete(memory);

    Form = Form_New();
    Form_Init(Form);

    Int imageBrushKind;
    imageBrushKind = Stat_BrushKindImage(Stat);

    ImageBrush = Brush_New();
    Brush_KindSet(ImageBrush, imageBrushKind);
    Brush_ImageSet(ImageBrush, Image);
    Brush_Init(ImageBrush);

    Int scaleFactor;
    scaleFactor = 1 << 20;

    Int polateRadialCenterPos;
    polateRadialCenterPos = Pos_New();
    Pos_Init(polateRadialCenterPos);
    Pos_ColSet(polateRadialCenterPos, MathInt(1450));
    Pos_RowSet(polateRadialCenterPos, MathInt(250));

    Int polateRadialFocusPos;
    polateRadialFocusPos = Pos_New();
    Pos_Init(polateRadialFocusPos);
    Pos_ColSet(polateRadialFocusPos, MathInt(1500));
    Pos_RowSet(polateRadialFocusPos, MathInt(250));

    Int polateRadial;
    polateRadial = PolateRadial_New();
    PolateRadial_CenterPosSet(polateRadial, polateRadialCenterPos);
    PolateRadial_CenterRadiusSet(polateRadial, MathInt(100));
    PolateRadial_FocusPosSet(polateRadial, polateRadialFocusPos);
    PolateRadial_FocusRadiusSet(polateRadial, MathInt(20));
    PolateRadial_Init(polateRadial);

    Int polateStop;
    polateStop = PolateStop_New();
    PolateStop_CountSet(polateStop, 3);
    PolateStop_Init(polateStop);
    PolateStop_PointSet(polateStop, 0, MathInt(0), 0xffff0000);
    PolateStop_PointSet(polateStop, 1, Math_Value(0, scaleFactor / 2, -20), 0xff00ff00);
    PolateStop_PointSet(polateStop, 2, MathInt(1), 0xff0000ff);

    Int polateKind;
    polateKind = Stat_PolateKindRadial(Stat);

    Int polate;
    polate = Polate_New();
    Polate_KindSet(polate, polateKind);
    Polate_ValueSet(polate, polateRadial);
    Polate_StopSet(polate, polateStop);
    Polate_SpreadSet(polate, Stat_PolateSpreadFlect(Stat));
    Polate_Init(polate);

    Int polateBrushKind;
    polateBrushKind = Stat_BrushKindPolate(Stat);

    PolateBrush = Brush_New();
    Brush_KindSet(PolateBrush, polateBrushKind);
    Brush_PolateSet(PolateBrush, polate);
    Brush_Init(PolateBrush);

    Draw = Draw_New();
    Draw_Init(Draw);

    Text = String_ConstantCreate(CastInt("DEMO Infra ABCD abcd"));

    Int updatePos;
    updatePos = Pos_New();
    Pos_Init(updatePos);

    UpdateRect = Rect_New();
    Rect_Init(UpdateRect);
    Rect_PosSet(UpdateRect, updatePos);

    Int soundFilePath;
    soundFilePath = String_ConstantCreate(CastInt("DemoSound.wav"));

    Int audioStream;
    audioStream = Stream_New();
    Stream_Init(audioStream);

    Int audioStorageMode;
    audioStorageMode = Stat_StorageModeRead(Stat);

    Int audioStorage;
    audioStorage = Storage_New();
    Storage_Init(audioStorage);

    Storage_PathSet(audioStorage, soundFilePath);
    Storage_ModeSet(audioStorage, audioStorageMode);
    Storage_StreamSet(audioStorage, audioStream);

    Storage_Open(audioStorage);

    Int audioOut;
    audioOut = AudioOut_New();
    AudioOut_Init(audioOut);

    Play = Play_New();
    Play_Init(Play);
    Play_SourceSet(Play, audioStream);
    Play_SourceThisSet(Play);
    Play_AudioOutSet(Play, audioOut);

    Int playFilePath;
    playFilePath = String_ConstantCreate(CastInt("DemoMedia.mp4"));

    Int playStream;
    playStream = Stream_New();
    Stream_Init(playStream);

    Int playStorageMode;
    playStorageMode = Stat_StorageModeRead(Stat);

    Int playStorage;
    playStorage = Storage_New();
    Storage_Init(playStorage);

    Storage_PathSet(playStorage, playFilePath);
    Storage_ModeSet(playStorage, playStorageMode);
    Storage_StreamSet(playStorage, playStream);

    Storage_Open(playStorage);

    VideoOut_FrameEvent_Maide maideAaa;
    maideAaa = &VideoOutFrameHandle;

    Int videoOutFrameMaide;
    videoOutFrameMaide = CastInt(maideAaa);

    Int videoOutFrameState;
    videoOutFrameState = State_New();
    State_Init(videoOutFrameState);
    State_MaideSet(videoOutFrameState, videoOutFrameMaide);

    VideoFrame = VideoFrame_New();
    VideoFrame_Init(VideoFrame);

    Int playVideoOut;
    playVideoOut = VideoOut_New();
    VideoOut_Init(playVideoOut);
    VideoOut_FrameEventStateSet(playVideoOut, videoOutFrameState);
    VideoOut_FrameSet(playVideoOut, VideoFrame);

    Int playAudioOut;
    playAudioOut = AudioOut_New();
    AudioOut_Init(playAudioOut);

    PlayA = Play_New();
    Play_Init(PlayA);
    Play_SourceSet(PlayA, playStream);
    Play_SourceThisSet(PlayA);
    Play_VideoOutSet(PlayA, playVideoOut);
    Play_AudioOutSet(PlayA, playAudioOut);

    Int playImageData;
    playImageData = Data_New();
    Data_Init(playImageData);

    Int playImageSize;
    playImageSize = Size_New();
    Size_Init(playImageSize);

    PlayImage = Image_New();
    Image_DataSet(PlayImage, playImageData);
    Image_SizeSet(PlayImage, playImageSize);
    Image_Init(PlayImage);

    Int areaPos;
    areaPos = Pos_New();
    Pos_Init(areaPos);

    Int areaSize;
    areaSize = Size_New();
    Size_Init(areaSize);

    Int area;
    area = Rect_New();
    Rect_Init(area);
    Rect_PosSet(area, areaPos);
    Rect_SizeSet(area, areaSize);

    Int fillPos;
    fillPos = Pos_New();
    Pos_Init(fillPos);

    Int frameTitle;
    frameTitle = String_ConstantCreate(CastInt("Infra Demo Frame"));

    Frame_Draw_Maide ku;
    ku = &DrawHandle;

    Int drawMaide;
    drawMaide = CastInt(ku);

    Int frameDrawState;
    frameDrawState = State_New();
    State_Init(frameDrawState);
    State_MaideSet(frameDrawState, drawMaide);
    State_ArgSet(frameDrawState, Draw);

    Frame_Type_Maide kua;
    kua = &TypeHandle;

    Int typeMaide;
    typeMaide = CastInt(kua);

    Int frameTypeState;
    frameTypeState = State_New();
    State_Init(frameTypeState);
    State_MaideSet(frameTypeState, typeMaide);

    Frame = Frame_New();
    Frame_Init(Frame);

    Frame_DrawStateSet(Frame, frameDrawState);
    Frame_TypeStateSet(Frame, frameTypeState);

    Int frameSize;
    frameSize = Frame_SizeGet(Frame);

    Int videoOut;
    videoOut = Frame_Out(Frame);

    Draw_SizeSet(Draw, frameSize);
    Draw_OutSet(Draw, videoOut);
    Draw_AreaSet(Draw, area);
    Draw_FillPosSet(Draw, fillPos);

    Rect_SizeSet(UpdateRect, frameSize);

    Frame_TitleSet(Frame, frameTitle);
    Frame_TitleThisSet(Frame);
    Frame_ShownSet(Frame, true);

    Int thread;
    thread = Thread_This();

    Int o;
    o = Thread_ExecuteMain(thread);

    Frame_Final(Frame);
    Frame_Delete(Frame);

    State_Final(frameTypeState);
    State_Delete(frameTypeState);

    State_Final(frameDrawState);
    State_Delete(frameDrawState);

    String_ConstantDelete(frameTitle);

    Pos_Final(fillPos);
    Pos_Delete(fillPos);

    Rect_Final(area);
    Rect_Delete(area);

    Size_Final(areaSize);
    Size_Delete(areaSize);

    Pos_Final(areaPos);
    Pos_Delete(areaPos);

    Image_Final(PlayImage);
    Image_Delete(PlayImage);

    Size_Final(playImageSize);
    Size_Delete(playImageSize);

    Data_Final(playImageData);
    Data_Delete(playImageData);

    Play_Final(PlayA);
    Play_Delete(PlayA);

    AudioOut_Final(playAudioOut);
    AudioOut_Delete(playAudioOut);

    VideoOut_Final(playVideoOut);
    VideoOut_Delete(playVideoOut);

    VideoFrame_Final(VideoFrame);
    VideoFrame_Delete(VideoFrame);

    State_Final(videoOutFrameState);
    State_Delete(videoOutFrameState);

    Storage_Close(playStorage);

    Storage_Final(playStorage);
    Storage_Delete(playStorage);

    Stream_Final(playStream);
    Stream_Delete(playStream);

    Play_Final(Play);
    Play_Delete(Play);

    AudioOut_Final(audioOut);
    AudioOut_Delete(audioOut);

    Storage_Close(audioStorage);

    Storage_Final(audioStorage);
    Storage_Delete(audioStorage);

    Stream_Final(audioStream);
    Stream_Delete(audioStream);

    String_ConstantDelete(soundFilePath);

    Rect_Final(UpdateRect);
    Rect_Delete(UpdateRect);

    Pos_Final(updatePos);
    Pos_Delete(updatePos);

    String_ConstantDelete(Text);

    Draw_Final(Draw);
    Draw_Delete(Draw);

    Brush_Final(PolateBrush);
    Brush_Delete(PolateBrush);

    Polate_Final(polate);
    Polate_Delete(polate);

    PolateStop_Final(polateStop);
    PolateStop_Delete(polateStop);

    PolateRadial_Final(polateRadial);
    PolateRadial_Delete(polateRadial);

    Pos_Final(polateRadialFocusPos);
    Pos_Delete(polateRadialFocusPos);

    Pos_Final(polateRadialCenterPos);
    Pos_Delete(polateRadialCenterPos);

    Brush_Final(ImageBrush);
    Brush_Delete(ImageBrush);

    Form_Final(Form);
    Form_Delete(Form);

    Image_Final(Image);
    Image_Delete(Image);

    Data_Final(imageData);
    Data_Delete(imageData);

    Size_Final(imageSize);
    Size_Delete(imageSize);

    ImageRead_Final(imageRead);
    ImageRead_Delete(imageRead);

    Storage_Final(storage);
    Storage_Delete(storage);

    Stream_Final(stream);
    Stream_Delete(stream);

    String_ConstantDelete(imagePath);

    Font_Final(Font);
    Font_Delete(Font);

    String_ConstantDelete(fontName);

    Data_Final(PointListData);
    Data_Delete(PointListData);

    Environ_Delete(pointListDataValue);

    Range_Final(RangeA);
    Range_Delete(RangeA);

    Pos_Final(PosB);
    Pos_Delete(PosB);

    Pos_Final(PosA);
    Pos_Delete(PosA);

    Rect_Final(RectB);
    Rect_Delete(RectB);

    Size_Final(rectSizeB);
    Size_Delete(rectSizeB);

    Pos_Final(rectPosB);
    Pos_Delete(rectPosB);

    Rect_Final(RectA);
    Rect_Delete(RectA);

    Size_Final(rectSizeA);
    Size_Delete(rectSizeA);

    Pos_Final(rectPosA);
    Pos_Delete(rectPosA);

    Slash_Final(PenText);
    Slash_Delete(PenText);

    Brush_Final(penTextBrush);
    Brush_Delete(penTextBrush);

    Slash_Final(PenRect);
    Slash_Delete(PenRect);

    Brush_Final(penRectBrush);
    Brush_Delete(penRectBrush);

    Brush_Final(Brush);
    Brush_Delete(Brush);

    Console_Final(Console);
    Console_Delete(Console);

    Main_Final();

    int u;
    u = o;
    return u;
}
