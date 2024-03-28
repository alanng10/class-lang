#include "Demo.h"



Int Text;



Int Brush;



Int ImageBrush;



Int GradientBrush;




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


Int TextFlag;



Int Image;



Int Transform;



Int Draw;



Int AreaOffset;



Int UpdateRect;




Int Stat;



SInt TextLeft;

SInt TextUp;




Int AudioEffect;




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
            AudioEffect_Play(AudioEffect);
        }



        if (index == 'U')
        {
            AudioEffect_Stop(AudioEffect);
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
    Pos_LeftSet(pos, left);


    Pos_UpSet(pos, up);



    return true;
}




Bool SetSize(Int size, Int width, Int height)
{
    Size_WidthSet(size, width);


    Size_HeightSet(size, height);



    return true;
}




Bool SetRange(Int range, Int index, Int count)
{
    Range_IndexSet(range, index);


    Range_CountSet(range, count);



    return true;
}





Int ConsoleWriteConstant(const char* o)
{
    Int u;

    u = CastInt(o);





    Int a;

    a = String_ConstantCreate(u);




    Console_Write(Console, a);




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


    areaLeft = Pos_LeftGet(areaPos);

    areaUp = Pos_UpGet(areaPos);

    areaWidth = Size_WidthGet(areaSize);

    areaHeight = Size_HeightGet(areaSize);



    Int aSize;

    aSize = Draw_SizeGet(Draw);


    Int aWidth;

    Int aHeight;

    aWidth = Size_WidthGet(aSize);

    aHeight = Size_HeightGet(aSize);



    areaLeft = AreaOffset;

    areaUp = AreaOffset;

    areaWidth = aWidth - 2 * AreaOffset;

    areaHeight = aHeight - 2 * AreaOffset;



    SetPos(areaPos, areaLeft, areaUp);

    SetSize(areaSize, areaWidth, areaHeight);




    Draw_AreaThisSet(Draw);





    Draw_BrushSet(Draw, Brush);




    Draw_PenSet(Draw, PenRect);




    SetRect(RectA, 100, 100, 200, 200);



    Draw_ExecuteRect(Draw, RectA);




    SetPos(PosA, 120, 470);


    SetPos(PosB, 230, 370);


    Draw_ExecuteLine(Draw, PosA, PosB);





    Draw_PenSet(Draw, PenRect);



    SetRect(RectA, 500, 350, 100, 100);


    SetRange(RangeA, 100 * 16, 120 * 16);



    Draw_ExecuteArc(Draw, RectA, RangeA);




    SetRect(RectA, 500, 550, 100, 100);


    SetRange(RangeA, 120 * 16, 160 * 16);


    Draw_ExecuteChord(Draw, RectA, RangeA);







    Draw_PenSet(Draw, null);


    SetRect(RectA, 500, 200, 100, 100);


    SetRange(RangeA, 10 * 16, 80 * 16);


    Draw_ExecutePie(Draw, RectA, RangeA);





    Draw_PenSet(Draw, PenRect);


    SetRect(RectA, 130, 550, 150, 100);


    Draw_ExecuteEllipse(Draw, RectA);




    Int scaleFactor;

    scaleFactor = (1 << 20);



    Draw_BrushSet(Draw, GradientBrush);


    SetRect(RectA, 1400, 200, 250, 110);


    Draw_ExecuteRoundRect(Draw, RectA, 30 * scaleFactor, 23 * scaleFactor);







    Draw_BrushSet(Draw, ImageBrush);




    Int fillPos;


    fillPos = Draw_FillPosGet(Draw);


    SetPos(fillPos, FillLeft, FillUp);


    Draw_FillPosThisSet(Draw);




    Draw_PenSet(Draw, PenRect);





    Transform_Reset(Transform);


    Transform_Offset(Transform, -780 * scaleFactor, -450 * scaleFactor);


    Transform_Scale(Transform, scaleFactor, 1 * scaleFactor + (1 << 18));


    Transform_Rotate(Transform, (RotateAngle + 30) * scaleFactor);


    Transform_Offset(Transform, 1080 * scaleFactor, -600 * scaleFactor);




    Draw_TransformSet(Draw, Transform);



    Draw_ExecutePolygon(Draw, PointListCount, PointListData);



    Draw_TransformSet(Draw, null);


    SetPos(fillPos, 0, 0);


    Draw_FillPosThisSet(Draw);





    Transform_Reset(Transform);


    Transform_Offset(Transform, 500 * scaleFactor, 100 * scaleFactor);


    Draw_TransformSet(Draw, Transform);


    Draw_ExecutePolyline(Draw, PointListCount, PointListData);


    Draw_TransformSet(Draw, null);






    SetRect(RectA, 850, 150, 150, 150);

    SetRect(RectB, 50, 10, 150, 150);


    Draw_ExecuteImage(Draw, Image, RectA, RectB);







    Draw_BrushSet(Draw, null);



    Draw_PenSet(Draw, PenRect);



    SetRect(RectA, 400 + TextLeft, 400 + TextUp, 300, 100);


    Draw_ExecuteRect(Draw, RectA);






    Draw_FontSet(Draw, Font);




    Draw_PenSet(Draw, PenText);




    SetRect(RectA, 400 + TextLeft, 400 + TextUp, 300, 100);


    Draw_ExecuteText(Draw, RectA, TextFlag, Text, RectB);




    Draw_FontSet(Draw, null);





    Draw_End(Draw);





    return true;
}





Int ThreadExecute(Int thread, Int arg)
{
    ConsoleWriteConstant("DEMO Thread\n");




    Thread_Sleep(4 * 1000);





    Int threadA;

    threadA = Thread_CurrentThread();




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

    Console_Write(Console, stringA);
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

    thread = Thread_CurrentThread();



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
        Console_Write(Console, stringA);


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
    Interval_Elapse_Maide maide;

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


    interval = Interval_New();


    Interval_Init(interval);



    Interval_SingleShotSet(interval, false);


    Interval_TimeSet(interval, 100);




    Interval_ElapseStateSet(interval, intervalElapseState);




    Interval_Start(interval);




    Thread_ExecuteEventLoop(thread);




    Interval_Final(interval);


    Interval_Delete(interval);



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
        Interval_Stop(interval);




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







    MainThread = Thread_CurrentThread();



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




    Console_Write(Console, stringAc);




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

    brushKind = Stat_BrushKindDiagCross(Stat);




    Brush = Brush_New();



    Brush_KindSet(Brush, brushKind);


    Brush_ColorSet(Brush, 0xff0000ff);




    Brush_Init(Brush);







    Int penRectBrushKind;

    penRectBrushKind = Stat_BrushKindSolid(Stat);





    Int penRectBrush;


    penRectBrush = Brush_New();



    Brush_KindSet(penRectBrush, penRectBrushKind);


    Brush_ColorSet(penRectBrush, 0xff00ff00);


    Brush_Init(penRectBrush);






    Int penRectKind;

    penRectKind = Stat_PenKindDashDot(Stat);



    Int penRectCap;

    penRectCap = Stat_PenCapRound(Stat);


    Int penRectJoin;

    penRectJoin = Stat_PenJoinBevel(Stat);



    PenRect = Pen_New();


    Pen_KindSet(PenRect, penRectKind);


    Pen_WidthSet(PenRect, 10);


    Pen_BrushSet(PenRect, penRectBrush);


    Pen_CapSet(PenRect, penRectCap);


    Pen_JoinSet(PenRect, penRectJoin);



    Pen_Init(PenRect);





    Int penTextBrushKind;

    penTextBrushKind = Stat_BrushKindSolid(Stat);





    Int penTextBrush;


    penTextBrush = Brush_New();



    Brush_KindSet(penTextBrush, penTextBrushKind);


    Brush_ColorSet(penTextBrush, 0xff0000ff);


    Brush_Init(penTextBrush);





    Int penTextKind;

    penTextKind = Stat_PenKindSolid(Stat);



    Int penTextCap;

    penTextCap = Stat_PenCapSquare(Stat);


    Int penTextJoin;

    penTextJoin = Stat_PenJoinMiter(Stat);




    PenText = Pen_New();


    Pen_KindSet(PenText, penTextKind);


    Pen_WidthSet(PenText, 4);


    Pen_BrushSet(PenText, penTextBrush);


    Pen_CapSet(PenText, penTextCap);


    Pen_JoinSet(PenText, penTextJoin);


    Pen_Init(PenText);




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



        SetPos(PosA, uuua, uuub);


        PointData_PointSet(pointListDataValue + iia * pointDataCount, PosA);



        iia = iia + 1;
    }






    Int fontFamily;


    fontFamily = String_ConstantCreate(CastInt("Source Sans 3"));




    Font = Font_New();


    Font_FamilySet(Font, fontFamily);


    Font_SizeSet(Font, 16);


    Font_WeightSet(Font, 600);


    Font_ItalicSet(Font, true);


    Font_UnderlineSet(Font, true);


    Font_OverlineSet(Font, true);


    Font_StrikeoutSet(Font, true);



    Font_Init(Font);





    TextFlag = Stat_TextAlignRight(Stat) | Stat_TextAlignVCenter(Stat);








    Int imagePath;


    imagePath = String_ConstantCreate(CastInt("../MyDocuments.png"));




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




    Console_Write(Console, stringOb);



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





    Transform = Transform_New();


    Transform_Init(Transform);





    Int imageBrushKind;

    imageBrushKind = Stat_BrushKindTexture(Stat);




    ImageBrush = Brush_New();


    Brush_KindSet(ImageBrush, imageBrushKind);


    Brush_ImageSet(ImageBrush, Image);


    Brush_Init(ImageBrush);





    Int scaleFactor;


    scaleFactor = 1 << 20;




    Int gradientRadialCenterPos;


    gradientRadialCenterPos = Pos_New();


    Pos_Init(gradientRadialCenterPos);


    Pos_LeftSet(gradientRadialCenterPos, 1450);


    Pos_UpSet(gradientRadialCenterPos, 250);




    Int gradientRadialFocusPos;


    gradientRadialFocusPos = Pos_New();


    Pos_Init(gradientRadialFocusPos);


    Pos_LeftSet(gradientRadialFocusPos, 1500);


    Pos_UpSet(gradientRadialFocusPos, 250);





    Int gradientRadial;

    gradientRadial = GradientRadial_New();


    GradientRadial_CenterPosSet(gradientRadial, gradientRadialCenterPos);


    GradientRadial_CenterRadiusSet(gradientRadial, 100);


    GradientRadial_FocusPosSet(gradientRadial, gradientRadialFocusPos);


    GradientRadial_FocusRadiusSet(gradientRadial, 20);


    GradientRadial_Init(gradientRadial);





    Int gradientStop;

    gradientStop = GradientStop_New();


    GradientStop_CountSet(gradientStop, 3);


    GradientStop_Init(gradientStop);



    GradientStop_PointSet(gradientStop, 0, 0, 0xffff0000);


    GradientStop_PointSet(gradientStop, 1, scaleFactor / 2, 0xff00ff00);


    GradientStop_PointSet(gradientStop, 2, scaleFactor, 0xff0000ff);





    Int gradientKind;

    gradientKind = Stat_GradientKindRadial(Stat);




    Int gradient;

    gradient = Gradient_New();


    Gradient_KindSet(gradient, gradientKind);


    Gradient_ValueSet(gradient, gradientRadial);


    Gradient_StopSet(gradient, gradientStop);


    Gradient_SpreadSet(gradient, Stat_GradientSpreadReflect(Stat));


    Gradient_Init(gradient);





    Int gradientBrushKind;

    gradientBrushKind = Stat_BrushKindRadialGradient(Stat);



    GradientBrush = Brush_New();


    Brush_KindSet(GradientBrush, gradientBrushKind);


    Brush_GradientSet(GradientBrush, gradient);


    Brush_Init(GradientBrush);







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




    Int soundUrlString;

    soundUrlString = String_ConstantCreate(CastInt("file:../../DemoSound.wav"));



    AudioEffect = AudioEffect_New();


    AudioEffect_Init(AudioEffect);


    AudioEffect_SourceSet(AudioEffect, soundUrlString);



    AudioEffect_SourceThisSet(AudioEffect);





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




    AudioEffect_Final(AudioEffect);


    AudioEffect_Delete(AudioEffect);



    String_ConstantDelete(soundUrlString);




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





    Brush_Final(GradientBrush);


    Brush_Delete(GradientBrush);




    Gradient_Final(gradient);


    Gradient_Delete(gradient);




    GradientStop_Final(gradientStop);


    GradientStop_Delete(gradientStop);




    GradientRadial_Final(gradientRadial);



    GradientRadial_Delete(gradientRadial);





    Pos_Final(gradientRadialFocusPos);



    Pos_Delete(gradientRadialFocusPos);




    Pos_Final(gradientRadialCenterPos);



    Pos_Delete(gradientRadialCenterPos);




    Brush_Final(ImageBrush);



    Brush_Delete(ImageBrush);





    Transform_Final(Transform);



    Transform_Delete(Transform);




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






    Font_Final(Font);


    Font_Delete(Font);




    String_ConstantDelete(fontFamily);





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




    Pen_Final(PenText);


    Pen_Delete(PenText);




    Brush_Final(penTextBrush);


    Brush_Delete(penTextBrush);




    Pen_Final(PenRect);


    Pen_Delete(PenRect);




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
