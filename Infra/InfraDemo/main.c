#include "Demo.h"



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




Int Face;


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




Bool ThreadStarted;




Int Thread;



Int Console;




Int IntervalElapseCount;



Int MainThread;





Bool TypeHandle(Int frame, Int index, Int field, Int arg)
{
    Bool b;

    b = false;


    if (field == 0)
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
            if (!ThreadStarted)
            {
                Thread_Execute(Thread);



                Int threadCase;

                threadCase = Thread_CaseGet(Thread);


                Int executeCase;

                executeCase = Stat_ThreadCaseExecute(Stat);



                ThreadStarted = (threadCase == executeCase);
            }
        }


        if (index == 'R')
        {
            if (ThreadStarted)
            {
                Int threadCase;

                threadCase = Thread_CaseGet(Thread);


                Int pauseCase;

                pauseCase = Stat_ThreadCasePause(Stat);



                Bool paused;

                paused = (threadCase == pauseCase);



                if (paused)
                {
                    Thread_Resume(Thread);
                }


                if (!paused)
                {
                    Thread_Pause(Thread);
                }
            }
        }




        if (index == 'Y')
        {
            Play_Execute(Play);
        }



        if (index == 'U')
        {
            Play_Stop(Play);
        }




        if (index == 'B')
        {
            Frame_Close(frame);
        }
    }



    if (b)
    {
        Frame_Update(frame, UpdateRect);
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

Bool DrawHandle(Int frame, Int arg)
{
    Draw_Start(Draw);

    Draw_Clear(Draw, 0xffffffff);

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





    Draw_FillSet(Draw, Brush);

    Draw_StrokeSet(Draw, PenRect);

    SetRect(RectA, MathInt(100), MathInt(100), MathInt(200), MathInt(200));

    Draw_ExecuteRect(Draw, RectA);


    SetPos(PosA, MathInt(120), MathInt(470));

    SetPos(PosB, MathInt(230), MathInt(370));

    Draw_ExecuteLine(Draw, PosA, PosB);


    Draw_StrokeSet(Draw, PenRect);

    SetRect(RectA, MathInt(500), MathInt(350), MathInt(100), MathInt(100));

    SetRange(RangeA, 100 * 16, 120 * 16);

    Draw_ExecuteRoundLine(Draw, RectA, RangeA);


    SetRect(RectA, MathInt(500), MathInt(550), MathInt(100), MathInt(100));

    SetRange(RangeA, 120 * 16, 160 * 16);

    Draw_ExecuteRoundShape(Draw, RectA, RangeA);


    Draw_StrokeSet(Draw, null);

    SetRect(RectA, MathInt(500), MathInt(200), MathInt(100), MathInt(100));

    SetRange(RangeA, 10 * 16, 80 * 16);

    Draw_ExecuteRoundPart(Draw, RectA, RangeA);


    Draw_StrokeSet(Draw, PenRect);

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


    Draw_StrokeSet(Draw, PenRect);


    Form_Reset(Form);

    Form_Offset(Form, MathInt(-780), MathInt(-450));

    Form_Scale(Form, MathInt(1), Math_Value(0, 1 * scaleFactor + (1 << 18), -20));

    Form_Rotate(Form, MathInt(RotateAngle + 30));

    Form_Offset(Form, MathInt(1080), MathInt(-600));


    Draw_FormSet(Draw, Form);

    Draw_ExecuteShape(Draw, PointListCount, PointListData);

    Draw_FormSet(Draw, null);


    SetPos(fillPos, MathInt(0), MathInt(0));

    Draw_FillPosThisSet(Draw);


    Form_Reset(Form);

    Form_Offset(Form, MathInt(500), MathInt(100));

    Draw_FormSet(Draw, Form);

    Draw_ExecuteShapeLine(Draw, PointListCount, PointListData);

    Draw_FormSet(Draw, null);


    SetRect(RectA, MathInt(850), MathInt(150), MathInt(150), MathInt(150));

    SetRect(RectB, MathInt(50), MathInt(10), MathInt(150), MathInt(150));

    Draw_ExecuteImage(Draw, Image, RectA, RectB);


    Draw_FillSet(Draw, null);

    Draw_StrokeSet(Draw, PenRect);

    SetRect(RectA, MathInt(400 + TextLeft), MathInt(400 + TextUp), MathInt(300), MathInt(100));

    Draw_ExecuteRect(Draw, RectA);


    Draw_FaceSet(Draw, Face);

    Draw_StrokeSet(Draw, PenText);

    SetRect(RectA, MathInt(400 + TextLeft), MathInt(400 + TextUp), MathInt(300), MathInt(100));

    Draw_ExecuteText(Draw, Text, TextAlignHoriz, TextAlignVert, false, RectA, RectB);

    Draw_FaceSet(Draw, null);


    Draw_End(Draw);
    return true;
}





Int ThreadExecute(Int thread, Int arg)
{
    ConsoleWriteConstant("DEMO Thread\n");




    Thread_Sleep(4 * 1000);





    Int threadA;

    threadA = Thread_This();




    Int ident;

    ident = Thread_IdentGet(threadA);



    Int formatArg;

    formatArg = FormatArg_New();

    FormatArg_Init(formatArg);

    FormatArg_KindSet(formatArg, 1);
    FormatArg_ValueSet(formatArg, ident);
    FormatArg_BaseSet(formatArg, 16);

    SInt ooa;
    ooa = -1;

    Int oob;
    oob = ooa;

    FormatArg_MaxWidthSet(formatArg, oob);

    Int format;

    format = Format_New();

    Format_Init(format);

    Format_ExecuteArgCount(format, formatArg);

    Int count;
    count = FormatArg_CountGet(formatArg);

    Int byteCount;
    byteCount = count * Constant_CharByteCount();

    Int uu;
    uu = New(byteCount);

    Int stringA;
    stringA = String_New();

    String_Init(stringA);

    String_CountSet(stringA, count);

    String_DataSet(stringA, uu);

    Format_ExecuteArgResult(format, formatArg, stringA);

    Console_OutWrite(Console, stringA);
    ConsoleWriteConstant("\n");

    String_Final(stringA);
    String_Delete(stringA);

    Delete(uu);

    Format_Final(format);
    Format_Delete(format);

    FormatArg_Final(formatArg);
    FormatArg_Delete(formatArg);

    Int* paaa;

    paaa = null;

    *paaa = 1;


    ConsoleWriteConstant("DEMO Thread 2\n");

    return 0;
}





Int ThreadAAExecute(Int thread, Int arg)
{
    ConsoleWriteConstant("DEMO Thread AA\n");



    return 0;
}







Bool TerminateHandle()
{
    Int thread;

    thread = Thread_This();



    Int o;

    o = Thread_IdentGet(thread);



    Int oo;

    oo = 100000 + o;



    Exit(oo);



    return true;
}






Bool MainThreadExecute()
{
    Int stringA;


    stringA = String_ConstantCreate(CastInt("DEMO Main Thread\n"));





    Int count;

    count = 5;


    Int i;

    i = 0;


    while (i < count)
    {
        Console_OutWrite(Console, stringA);


        Thread_Sleep(2 * 1000);



        i = i + 1;
    }




    String_ConstantDelete(stringA);




    return true;
}





Bool ThreadAExecute(Int thread, Int arg)
{
    Thread_Sleep(1000);


    Thread_Pause(MainThread);


    Thread_Sleep(3000);


    Thread_Resume(MainThread);



    return true;
}






Int ThreadIntervalExecute(Int thread, Int arg)
{
    TimeEvent_Elapse_Maide maide;

    maide = &ThreadIntervalElapseHandle;



    Int ua;

    ua = CastInt(maide);


    Int ub;

    ub = thread;



    Int intervalElapseState;

    intervalElapseState = State_New();


    State_Init(intervalElapseState);


    State_MaideSet(intervalElapseState, ua);


    State_ArgSet(intervalElapseState, ub);




    Int interval;


    interval = TimeEvent_New();


    TimeEvent_Init(interval);



    TimeEvent_SingleSet(interval, false);


    TimeEvent_TimeSet(interval, 100);




    TimeEvent_ElapseStateSet(interval, intervalElapseState);




    TimeEvent_Start(interval);




    Thread_ExecuteEventLoop(thread);




    TimeEvent_Final(interval);


    TimeEvent_Delete(interval);



    State_Final(intervalElapseState);


    State_Delete(intervalElapseState);





    return 100;
}





Int ThreadIntervalElapseHandle(Int interval, Int arg)
{
    ConsoleWriteConstant("Thread Interval Elapse\n");




    IntervalElapseCount = IntervalElapseCount + 1;




    if (!(IntervalElapseCount < 3))
    {
        TimeEvent_Stop(interval);




        Int thread;

        thread = arg;


        Thread_ExitEventLoop(thread, 0);
    }






    return true;
}






int main(int argc, char* argv[])
{
    Main_Init();




    Main_Terminate_Maide terminateMaide;

    terminateMaide = &TerminateHandle;



    Int uaaa;

    uaaa = CastInt(terminateMaide);



    Int terminateState;

    terminateState = State_New();


    State_Init(terminateState);


    State_MaideSet(terminateState, uaaa);




    Main_TerminateStateSet(terminateState);







    MainThread = Thread_This();



    Thread_IdentSet(MainThread, 1024);






    Console = Console_New();

    Console_Init(Console);

    ConsoleWriteConstant("DEMO HELLO\n");

    ConsoleWriteConstant("DEMO 的 阿卡 HELLO\n");

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


    Thread_Execute_Maide maideO;

    maideO = &ThreadIntervalExecute;

    Int threadOu;
    threadOu = CastInt(maideO);

    Int threadOExecuteState;
    
    threadOExecuteState = State_New();

    State_Init(threadOExecuteState);

    State_MaideSet(threadOExecuteState, threadOu);

    Int threadO;

    threadO = Thread_New();

    Thread_Init(threadO);

    Thread_ExecuteStateSet(threadO, threadOExecuteState);

    Thread_Execute(threadO);

    Thread_Wait(threadO);

    Thread_Final(threadO);

    Thread_Delete(threadO);

    State_Final(threadOExecuteState);

    State_Delete(threadOExecuteState);








    Int share;

    share = Infra_Share();



    Stat = Share_Stat(share);



    Int brushKind;

    brushKind = Stat_BrushKindColor(Stat);




    Brush = Brush_New();



    Brush_KindSet(Brush, brushKind);


    Brush_ColorSet(Brush, 0xff0000ff);




    Brush_Init(Brush);







    Int penRectKind;
    penRectKind = Stat_BrushKindColor(Stat);

    Int penRectLine;
    penRectLine = Stat_BrushLineDashDot(Stat);

    Int penRectCap;
    penRectCap = Stat_BrushCapRound(Stat);

    Int penRectJoin;
    penRectJoin = Stat_BrushJoinBevel(Stat);

    Int penRectBrush;
    penRectBrush = Brush_New();

    Brush_KindSet(penRectBrush, penRectKind);

    Brush_ColorSet(penRectBrush, 0xff00ff00);

    Brush_LineSet(penRectBrush, penRectLine);

    Brush_WidthSet(penRectBrush, 10);

    Brush_CapSet(penRectBrush, penRectCap);

    Brush_JoinSet(penRectBrush, penRectJoin);

    Brush_Init(penRectBrush);

    PenRect = penRectBrush;


    Int penTextKind;
    penTextKind = Stat_BrushKindColor(Stat);

    Int penTextLine;
    penTextLine = Stat_BrushLineSolid(Stat);

    Int penTextCap;
    penTextCap = Stat_BrushCapSquare(Stat);

    Int penTextJoin;
    penTextJoin = Stat_BrushJoinMiter(Stat);


    Int penTextBrush;
    penTextBrush = Brush_New();

    Brush_KindSet(penTextBrush, penTextKind);

    Brush_ColorSet(penTextBrush, 0xff0000ff);

    Brush_LineSet(penTextBrush, penTextLine);

    Brush_WidthSet(penTextBrush, 4);

    Brush_CapSet(penTextBrush, penTextCap);

    Brush_JoinSet(penTextBrush, penTextJoin);

    Brush_Init(penTextBrush);

    PenText = penTextBrush;


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
    pointListDataValue = New(pointListDataCount);

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


    Int faceFamily;
    faceFamily = String_ConstantCreate(CastInt("Source Sans 3"));

    Face = Face_New();
    Face_FamilySet(Face, faceFamily);
    Face_SizeSet(Face, 16);
    Face_WeightSet(Face, 600);
    Face_ItalicSet(Face, true);
    Face_UnderlineSet(Face, true);
    Face_OverlineSet(Face, true);
    Face_StrikeoutSet(Face, true);
    Face_Init(Face);

    TextAlignHoriz = Stat_TextAlignEnd(Stat);
    TextAlignVert = Stat_TextAlignMid(Stat);


    Int imagePath;
    imagePath = String_ConstantCreate(CastInt("../../DemoImage.png"));

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
    memoryDataValue = String_DataGet(stringOa);


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
    dataValueA = New(memoryDataCount);

    Data_CountSet(dataA, memoryDataCount);

    Data_ValueSet(dataA, dataValueA);

    SetRange(RangeA, 0, memoryDataCount);

    Stream_PosSet(stream, 5 * Constant_CharByteCount());

    Stream_Read(stream, dataA, RangeA);


    Int stringOb;

    stringOb = String_New();

    String_Init(stringOb);

    String_CountSet(stringOb, stringCountA);

    String_DataSet(stringOb, dataValueA);

    Console_OutWrite(Console, stringOb);

    String_Final(stringOb);

    String_Delete(stringOb);

    Delete(dataValueA);

    Data_Final(dataA);

    Data_Delete(dataA);


    String_ConstantDelete(stringOa);


    Memory_Close(memory);

    Memory_Final(memory);

    Memory_Delete(memory);


    Thread_Execute_Maide threadAAExecute;

    threadAAExecute = &ThreadAAExecute;

    Int uoaa;
    uoaa = CastInt(threadAAExecute);

    Int threadAAExecuteState;
    threadAAExecuteState = State_New();

    State_Init(threadAAExecuteState);

    State_MaideSet(threadAAExecuteState, uoaa);


    Int threadAA;
    threadAA = Thread_New();

    Thread_Init(threadAA);

    Thread_ExecuteStateSet(threadAA, threadAAExecuteState);

    Thread_Execute(threadAA);

    Thread_Wait(threadAA);


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


    Polate_SpreadSet(polate, Stat_PolateSpreadReflect(Stat));


    Polate_Init(polate);





    Int polateBrushKind;

    polateBrushKind = Stat_BrushKindPolate(Stat);



    PolateBrush = Brush_New();


    Brush_KindSet(PolateBrush, polateBrushKind);


    Brush_PolateSet(PolateBrush, polate);


    Brush_Init(PolateBrush);







    Draw = Draw_New();




    Draw_Init(Draw);





    Thread_Execute_Maide threadMaide;

    threadMaide = &ThreadExecute;


    Int threadMaideU;

    threadMaideU = CastInt(threadMaide);




    Int threadExecuteState;

    threadExecuteState = State_New();


    State_Init(threadExecuteState);


    State_MaideSet(threadExecuteState, threadMaideU);





    Thread = Thread_New();



    Thread_Init(Thread);



    Thread_ExecuteStateSet(Thread, threadExecuteState);



    Thread_IdentSet(Thread, 0x1000);




    Text = String_ConstantCreate(CastInt("DEMO Infra ABCD abcd"));


    Int updatePos;


    updatePos = Pos_New();


    Pos_Init(updatePos);



    UpdateRect = Rect_New();


    Rect_Init(UpdateRect);



    Rect_PosSet(UpdateRect, updatePos);




    Int soundFilePath;

    soundFilePath = String_ConstantCreate(CastInt("../../DemoSound.wav"));


    Int audioOut;
    audioOut = AudioOut_New();

    AudioOut_Init(audioOut);


    Play = Play_New();

    Play_Init(Play);

    Play_SourceSet(Play, soundFilePath);

    Play_SourceThisSet(Play);

    Play_AudioOutSet(Play, audioOut);



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





    Int frame;


    frame = Frame_New();




    Frame_Init(frame);




    Frame_DrawStateSet(frame, frameDrawState);



    Frame_TypeStateSet(frame, frameTypeState);





    Int frameSize;

    frameSize = Frame_SizeGet(frame);



    Int videoOut;

    videoOut = Frame_VideoOut(frame);



    Draw_SizeSet(Draw, frameSize);



    Draw_OutSet(Draw, videoOut);



    Draw_AreaSet(Draw, area);



    Draw_FillPosSet(Draw, fillPos);




    Rect_SizeSet(UpdateRect, frameSize);





    Frame_TitleSet(frame, frameTitle);



    Frame_TitleThisSet(frame);




    Frame_VisibleSet(frame, true);




    Int o;


    o = Main_ExecuteEventLoop();






    Frame_Final(frame);



    Frame_Delete(frame);




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




    Play_Final(Play);

    Play_Delete(Play);


    AudioOut_Final(audioOut);

    AudioOut_Delete(audioOut);


    String_ConstantDelete(soundFilePath);




    Rect_Final(UpdateRect);


    Rect_Delete(UpdateRect);



    Pos_Final(updatePos);


    Pos_Delete(updatePos);


    String_ConstantDelete(Text);


    Thread_Final(Thread);



    Thread_Delete(Thread);




    State_Final(threadExecuteState);



    State_Delete(threadExecuteState);




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




    Thread_Final(threadAA);



    Thread_Delete(threadAA);




    State_Final(threadAAExecuteState);



    State_Delete(threadAAExecuteState);




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






    Face_Final(Face);


    Face_Delete(Face);




    String_ConstantDelete(faceFamily);





    Data_Final(PointListData);


    Data_Delete(PointListData);




    Delete(pointListDataValue);




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


    Brush_Final(penTextBrush);

    Brush_Delete(penTextBrush);


    Brush_Final(penRectBrush);

    Brush_Delete(penRectBrush);


    Brush_Final(Brush);


    Brush_Delete(Brush);




//    Thread_Final(threadA);


//    Thread_Delete(threadA);






    Console_Final(Console);



    Console_Delete(Console);




    State_Final(terminateState);


    State_Delete(terminateState);




    Main_Final();







    int u;

    u = o;


    return u;
}
