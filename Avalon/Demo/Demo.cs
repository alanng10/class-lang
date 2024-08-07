namespace Demo;

class Demo : Any
{
    public Frame Frame { get; set; }
    public View View { get; set; }
    public ViewA ViewA { get; set; }
    public ViewC ViewC { get; set; }
    public DrawRect UpdateRect { get; set; }
    public DrawImage ThreadDrawImage { get; set; }
    public AudioEffect AudioEffect { get; set; }
    public Play Play { get; set; }
    public DrawImage PlayImage { get; set; }
    public Console Console { get; set; }
    public Network Peer { get; set; }
    public NetworkHost Host { get; set; }

    public virtual InfraInfra InfraInfra { get; set; }
    public virtual ListInfra ListInfra { get; set; }
    public virtual MathInfra MathInfra { get; set; }
    public virtual TextInfra TextInfra { get; set; }
    public virtual DrawInfra DrawInfra { get; set; }
    private StorageStatusList StorageStatusList { get; set; }
    public NetworkPortKindList NetworkPortKindList { get; set; }
    public NetworkCaseList NetworkCaseList { get; set; }
    public NetworkStatusList NetworkStatusList { get; set; }
    private DrawBrushKindList BrushKindList { get; set; }
    private DrawBrushLineList BrushLineList { get; set; }
    private DrawBrushCapList BrushCapList { get; set; }
    private DrawBrushJoinList BrushJoinList { get; set; }

    public virtual MathMath Math { get; set; }
    protected virtual MathComp MathComp { get; set; }

    public bool Execute()
    {
        this.InfraInfra = InfraInfra.This;
        this.ListInfra = ListInfra.This;
        this.TextInfra = TextInfra.This;
        this.MathInfra = MathInfra.This;
        this.DrawInfra = DrawInfra.This;
        this.StorageStatusList = StorageStatusList.This;
        this.NetworkPortKindList = NetworkPortKindList.This;
        this.NetworkCaseList = NetworkCaseList.This;
        this.NetworkStatusList = NetworkStatusList.This;
        this.BrushKindList = DrawBrushKindList.This;
        this.BrushLineList = DrawBrushLineList.This;
        this.BrushCapList = DrawBrushCapList.This;
        this.BrushJoinList = DrawBrushJoinList.This;
        this.Console = Console.This;

        ThreadThis varThis;
        varThis = new ThreadThis();
        varThis.Init();
        
        this.Math = new MathMath();
        this.Math.Init();
        this.MathComp = new MathComp();
        this.MathComp.Init();

        this.ExecuteConsole();
        this.ExecuteMath();
        this.ExecuteRand();
        this.ExecuteFormat();
        this.ExecuteIntParse();
        this.ExecuteTime();
        this.ExecuteStorage();
        this.ExecuteStorageArrange();

        this.ThreadDrawImage = this.ThreadDrawImageCreate();

        this.ExecuteDemoThread();
        this.ExecuteTimeEvent();
        this.ExecutePost();

        // this.ExecuteNetwork();
        // this.ExecuteNetworkProcess();

        this.Frame = new Frame();
        this.Frame.Init();
        this.Frame.Title = "Avalon Demo";
        this.Frame.TitleSet();

        this.UpdateRect = new DrawRect();
        this.UpdateRect.Init();
        this.UpdateRect.Pos = new DrawPos();
        this.UpdateRect.Pos.Init();
        this.UpdateRect.Size = new DrawSize();
        this.UpdateRect.Size.Init();
        this.UpdateRect.Size.Width = this.Frame.Size.Width;
        this.UpdateRect.Size.Height = this.Frame.Size.Height;

        Type type;
        type = Type.This;
        TypeState state;
        state = new TypeState();
        state.Init();
        state.Demo = this;
        type.Change.State.AddState(state);
        this.Frame.Type = type;

        DrawBrush brush;
        brush = new DrawBrush();
        brush.Kind = this.BrushKindList.Color;
        brush.Color = this.DrawInfra.ColorCreate(0xff, 0, 0xff, 0);
        brush.Init();

        View view;
        view = new View();
        view.Init();
        view.Pos.Col = 100;
        view.Pos.Row = 100;
        view.Size.Width = 1600;
        view.Size.Height = 900;
        view.Back = brush;

        DrawBrush brushA;
        brushA = new DrawBrush();
        brushA.Kind = this.BrushKindList.Color;
        brushA.Color = this.DrawInfra.ColorCreate(0xff, 0, 0, 0xff);
        brushA.Init();

        DrawBrush penBrush;
        penBrush = new DrawBrush();
        penBrush.Kind = this.BrushKindList.Color;
        penBrush.Color = this.DrawInfra.ColorCreate(0xff, 0xff, 0, 0xff);
        penBrush.Line = this.BrushLineList.DashDotDot;
        penBrush.Width = this.MathInt(11);
        penBrush.Cap = this.BrushCapList.Round;
        penBrush.Join = this.BrushJoinList.Bevel;
        penBrush.Init();

        ViewC viewC;
        viewC = this.ViewCCreate();

        DrawForm viewAForm;
        viewAForm = new DrawForm();
        viewAForm.Init();

        ViewA viewA;
        viewA = new ViewA();
        viewA.Init();
        viewA.Pos.Col = 0;
        viewA.Pos.Row = 0;
        viewA.Size.Width = 600;
        viewA.Size.Height = 400;
        viewA.Back = brushA;
        viewA.DrawPen = penBrush;
        viewA.Form = viewAForm;
        viewA.Demo = this;

        DrawBrush gridBrush;
        gridBrush = new DrawBrush();
        gridBrush.Kind = this.BrushKindList.Color;
        gridBrush.Color = this.DrawInfra.ColorCreate(0x80, 0, 0, 0);
        gridBrush.Init();

        Grid grid;
        grid = new Grid();
        grid.Init();

        grid.Back = gridBrush;

        ViewCount colA;
        colA = new ViewCount();
        colA.Init();
        colA.Value = 600;
        ViewCount colB;
        colB = new ViewCount();
        colB.Init();
        colB.Value = 600;
        ViewCount rowA;
        rowA = new ViewCount();
        rowA.Init();
        rowA.Value = 600;
        GridChild childA;
        childA = new GridChild();
        childA.Init();
        childA.View = viewA;
        childA.Rect.Size.Width = 1;
        childA.Rect.Size.Height = 1;
        GridChild childB;
        childB = new GridChild();
        childB.Init();
        childB.View = viewC;
        childB.Rect.Pos.Col = 1;
        childB.Rect.Size.Width = 1;
        childB.Rect.Size.Height = 1;

        grid.Pos.Col = 50;
        grid.Pos.Row = 50;
        grid.Size.Width = 1500;
        grid.Size.Height = 800;
        grid.Dest.Pos.Col = 0;
        grid.Dest.Pos.Row = 0;
        grid.Dest.Size.Width = 1500;
        grid.Dest.Size.Height = 800;
        grid.Row.Add(rowA);
        grid.Col.Add(colA);
        grid.Col.Add(colB);
        grid.ChildList.Add(childA);
        grid.ChildList.Add(childB);

        view.Child = grid;

        DrawImage image;
        image = this.ImageCreate();

        int widthA;
        int heightA;
        widthA = 400;
        heightA = 200;
        DrawRectInt sourceRect;
        sourceRect = this.DrawInfra.RectIntCreate(this.MathInt(1880), this.MathInt(910), this.MathInt(widthA), this.MathInt(heightA));

        DrawForm formA;
        formA = new DrawForm();
        formA.Init();

        DrawRectInt destRectA;
        destRectA = this.DrawInfra.RectIntCreate(0, 0, this.MathInt(200), this.MathInt(200));

        DrawRectInt sourceRectA;
        sourceRectA = this.DrawInfra.RectIntCreate(0, 0, this.MathInt(200), this.MathInt(200));

        ViewB viewB;
        viewB = new ViewB();
        viewB.Init();
        viewB.Pos.Col = 60;
        viewB.Pos.Row = 40;
        viewB.Size.Width = widthA;
        viewB.Size.Height = heightA;
        viewB.DrawImage = image;
        viewB.SourceRect = sourceRect;
        viewB.Form = formA;
        viewB.ThreadDrawImage = this.ThreadDrawImage;
        viewB.DestRectA = destRectA;
        viewB.SourceRectA = sourceRectA;

        viewA.Child = viewB;

        this.PlayImage = this.PlayImageCreate();

        this.Play = this.PlayCreate();

        this.AudioEffect = this.AudioEffectCreate();

        this.ViewA = viewA;
        this.View = view;
        this.ViewC = viewC;

        this.Frame.View = this.View;
        this.Frame.Visible = true;

        ThreadThread thread;
        thread = varThis.Thread;
        
        thread.ExecuteEventLoop();

        this.AudioEffectFinal(this.AudioEffect);

        this.PlayFinal(this.Play);

        this.PlayImageFinal(this.PlayImage);

        formA.Final();

        this.ImageFinal(image);

        gridBrush.Final();

        viewAForm.Final();

        this.ViewCFinal(viewC);

        penBrush.Final();

        brushA.Final();

        brush.Final();

        this.Frame.Final();

        this.ThreadDrawImageFinal(this.ThreadDrawImage);
        return true;
    }

    private DrawImage ImageCreate()
    {
        DrawImage image;
        image = this.DrawInfra.ImageCreatePath("DemoData/image.jpg");
        return image;
    }

    private bool ImageFinal(DrawImage image)
    {
        image.Final();
        return true;
    }

    private bool ExecuteConsole()
    {
        this.Console.Out.Write("Console 水中\n");
        this.Console.Out.Write("Input a: ");
        string a;
        a = this.Console.Inn.Read();
        this.Console.Out.Write("a: " + a + "\n");
        this.Console.Out.Write("Input aa: ");
        string aa;
        aa = this.Console.Inn.Read();
        this.Console.Out.Write("aa: " + aa + "\n");
        return true;
    }

    private bool ExecuteMath()
    {
        MathComp ca;
        ca = new MathComp();
        ca.Init();

        long aaaa;
        aaaa = this.Math.ValueTen(3, 2);
        this.ConsoleWriteMathValue("Demo.ExecuteMath ValueTen: ", aaaa);

        long aaab;
        aaab = this.Math.ValueTen(5, -1);
        this.ConsoleWriteMathValue("Demo.ExecuteMath ValueTen 2: ", aaab);

        long aa;
        aa = this.Math.Sin(0);
        this.ConsoleWriteMathValue("Demo.ExecuteMath Sin(0): ", aa);

        long aaa;
        aaa = this.Math.Cos(0);
        this.ConsoleWriteMathValue("Demo.ExecuteMath Cos(0): ", aaa);

        ca.Cand = 0x3243F6A8885;
        ca.Expo = -40;

        long pi;
        pi = this.Math.Value(ca);
        this.ConsoleWriteMathValue("Demo.ExecuteMath pi: ", pi);

        long ab;
        ab = this.Math.Sin(pi);
        this.ConsoleWriteMathValue("Demo.ExecuteMath Sin(pi): ", ab);

        ca.Expo = -41;

        long piHalf;
        piHalf = this.Math.Value(ca);
        this.ConsoleWriteMathValue("Demo.ExecuteMath piHalf: ", piHalf);

        long ac;
        ac = this.Math.Sin(piHalf);
        this.ConsoleWriteMathValue("Demo.ExecuteMath Sin(piHalf): ", ac);

        long ad;
        ad = this.Math.Tan(0);
        this.ConsoleWriteMathValue("Demo.ExecuteMath Tan(0): ", ad);

        ca.Expo = -42;

        long piQuarter;
        piQuarter = this.Math.Value(ca);
        this.ConsoleWriteMathValue("Demo.ExecuteMath piQuarter: ", piQuarter);

        long ae;
        ae = this.Math.Tan(piQuarter);
        this.ConsoleWriteMathValue("Demo.ExecuteMath Tan(piQuarter): ", ae);

        long af;
        af = this.Math.ASin(0);
        this.ConsoleWriteMathValue("Demo.ExecuteMath ASin(0): ", af);

        long one;
        one = 1;
        long ag;
        ag = this.Math.ASin(one);
        this.ConsoleWriteMathValue("Demo.ExecuteMath ASin(one): ", ag);
        return true;
    }

    private bool ConsoleWriteMathValue(string prefix, long value)
    {
        this.Math.Comp(this.MathComp, value);
        
        this.Console.Out.Write(prefix +
        "Significand: " + this.MathComp.Cand.ToString("x") + ", " +
        "Exponent: " + this.MathComp.Expo +
        "\n");
        return true;
    }

    private bool ExecuteRand()
    {
        Rand rand;
        rand = new Rand();
        rand.Init();

        rand.Seed = 36719;

        long oa;
        oa = rand.Execute();

        this.Console.Out.Write("Demo.ExecuteRand oa: 0h" + oa.ToString("x15") + "\n");

        rand.Final();
        return true;
    }

    private bool ExecuteFormat()
    {
        TextFormatArg argA;
        argA = new TextFormatArg();
        argA.Init();
        argA.Pos = 3;
        argA.Kind = 0;
        argA.ValueBool = true;
        argA.FieldWidth = 6;
        argA.MaxWidth = -1;
        argA.Case = 1;
        argA.FillChar = ' ';

        TextFormatArg argB;
        argB = new TextFormatArg();
        argB.Init();
        argB.Pos = 3;
        argB.Kind = 1;
        argB.ValueInt = 56712;
        argB.AlignLeft = true;
        argB.FieldWidth = 8;
        argB.MaxWidth = 6;
        argB.Base = 10;
        argB.FillChar = ' ';

        TextFormatArg argC;
        argC = new TextFormatArg();
        argC.Init();
        argC.Pos = 6;
        argC.Kind = 2;
        argC.ValueInt = -46842;
        argC.AlignLeft = false;
        argC.FieldWidth = 8;
        argC.MaxWidth = 6;
        argC.Base = 10;
        argC.FillChar = ' ';

        TextFormatArg argD;
        argD = new TextFormatArg();
        argD.Init();
        argD.Pos = 7;
        argD.Kind = 2;
        argD.ValueInt = -0x5bd9ea;
        argD.AlignLeft = false;
        argD.FieldWidth = 8;
        argD.MaxWidth = 6;
        argD.Base = 16;
        argD.Case = 1;
        argD.FillChar = ' ';

        TextFormatArg argDA;
        argDA = new TextFormatArg();
        argDA.Init();
        argDA.Pos = 7;
        argDA.Kind = 2;
        argDA.ValueInt = 100;
        argDA.AlignLeft = false;
        argDA.FieldWidth = 4;
        argDA.MaxWidth = -1;
        argDA.Base = 10;
        argDA.Sign = 1;

        TextFormatArg argDB;
        argDB = new TextFormatArg();
        argDB.Init();
        argDB.Pos = 8;
        argDB.Kind = 2;
        argDB.ValueInt = 0;
        argDB.AlignLeft = false;
        argDB.FieldWidth = 3;
        argDB.MaxWidth = -1;
        argDB.Base = 10;
        argDB.Sign = 2;
        argDB.FillChar = ':';

        TextFormatArg argE;
        argE = new TextFormatArg();
        argE.Init();
        argE.Pos = 10;
        argE.Kind = 3;
        argE.ValueText = this.TextInfra.TextCreateString("F Hre a", null);
        argE.AlignLeft = true;
        argE.FieldWidth = 11;
        argE.MaxWidth = 10;
        argE.Case = 2;
        argE.FillChar = '=';

        TextFormatArg argF;
        argF = new TextFormatArg();
        argF.Init();
        argF.Pos = 10;
        argF.Kind = 4;
        argF.ValueInt = 'H';
        argF.AlignLeft = false;
        argF.FieldWidth = 10;
        argF.MaxWidth = -1;
        argF.FillChar = 'O';

        Array argList;
        argList = this.ListInfra.ArrayCreate(8);
        argList.SetAt(0, argA);
        argList.SetAt(1, argB);
        argList.SetAt(2, argC);
        argList.SetAt(3, argD);
        argList.SetAt(4, argDA);
        argList.SetAt(5, argDB);
        argList.SetAt(6, argE);
        argList.SetAt(7, argF);

        Text varBase;
        varBase = this.TextInfra.TextCreateString("G H , j h\n\n", null);

        CharForm charForm;
        charForm = new CharForm();
        charForm.Init();

        TextFormat format;
        format = new TextFormat();
        format.Init();
        format.CharForm = charForm;

        int count;
        count = format.ExecuteCount(varBase, argList);

        Text text;
        text = this.TextInfra.TextCreate(count);

        format.ExecuteResult(varBase, argList, text);

        string a;
        a = this.TextInfra.StringCreate(text);

        this.Console.Out.Write(a);
        return true;
    }

    private bool ExecuteIntParse()
    {
        TextIntParse a;
        a = new TextIntParse();
        a.Init();

        Text ooo;
        ooo = this.TextInfra.TextCreateString("43695", null);
        long ooa;
        ooa = a.Execute(ooo, 10, false);
        this.Console.Out.Write("Demo.ExecuteIntParse ooa: " + ooa.ToString() + "\n");

        ooo = this.TextInfra.TextCreateStringData("9E532F", null);
        ooa = a.Execute(ooo, 16, true);
        this.Console.Out.Write("Demo.ExecuteIntParse ooa: 0h" + ooa.ToString("x15") + "\n");

        ooo = this.TextInfra.TextCreateString("0000000000009294ef0d", null);
        ooa = a.Execute(ooo, 16, false);
        this.Console.Out.Write("Demo.ExecuteIntParse ooa: 0h" + ooa.ToString("x16") + "\n");

        ooo = this.TextInfra.TextCreateStringData("1000000000000000", null);
        ooa = a.Execute(ooo, 16, true);
        this.Console.Out.Write("Demo.ExecuteIntParse ooa: 0h" + ooa.ToString("x16") + "\n");
        return true;
    }

    private bool ExecuteTime()
    {
        Time time;
        time = new Time();
        time.Init();
        
        this.ConsoleWriteTime("Demo.ExecuteTime time init ", time);
        
        time.This();
        this.ConsoleWriteTime("Demo.ExecuteTime time current ", time);

        time.ToPos(2 * 60 * 60);
        this.ConsoleWriteTime("Demo.ExecuteTime time ToPos ", time);

        time.AddMillisec(200 * 1000);
        this.ConsoleWriteTime("Demo.ExecuteTime time AddMillisec ", time);

        time.Final();
        return true;
    }

    private bool ConsoleWriteTime(string prefix, Time time)
    {
        this.Console.Out.Write(prefix +
        "year: " + time.Year + ", " +
        "month: " + time.Month + ", " +
        "day: " + time.Day + ", " +
        "hour: " + time.Hour + ", " +
        "min: " + time.Min + ", " +
        "sec: " + time.Sec + ", " +
        "millisec: " + time.Millisec + ", " +
        "pos: " + time.Pos + 
        "\n");
        return true;
    }

    private bool ExecuteStorage()
    {
        StorageInfra infra;
        infra = StorageInfra.This;
        string k;
        k = infra.TextRead("DemoData/Demo.txt");
        this.Console.Out.Write("Demo.txt text: \n");
        this.Console.Out.Write(k);
        this.Console.Out.Write("\n");

        string ou;
        ou = "DemoData/Demo2.txt";
        File.Delete(ou);

        bool b;
        b = false;
        bool ba;
        ba = infra.TextWrite(ou, "DEMO STORAGE WRITE AAA BBB");
        if (!ba)
        {
            this.Console.Out.Write("Write " + ou + " 1 Error\n");
            b = true;
        }

        if (ba)
        {
            bool bb;
            bb = infra.TextWrite(ou, "DEMO STORAGE WRITE 2 AAA");
            if (!bb)
            {
                this.Console.Out.Write("Write " + ou + " 2 Error\n");
                b = true;
            }
        }

        if (!b)
        {
            k = infra.TextRead(ou);

            this.Console.Out.Write(ou + " text: \n");
            this.Console.Out.Write(k);
            this.Console.Out.Write("\n");
        }

        string oua;
        oua = "DemoData/Demo3.txt";
        File.Delete(oua);

        bool bo;
        bo = false;
        bool baa;
        baa = infra.TextWrite(oua, "DEMO STORAGE WRITE DEMO ABCD");
        if (!baa)
        {
            this.Console.Out.Write("Write " + oua + " 1 Error\n");
            bo = true;
        }
        if (baa)
        {
            string ka;
            ka = "OUHU";
            bool bab;
            bab = this.WriteStringPos(oua, ka, 19);
            if (!bab)
            {
                this.Console.Out.Write("Write " + oua + " 2 Error\n");
                bo = true;
            }
        }
        if (!bo)
        {
            k = infra.TextRead(oua);
            this.Console.Out.Write(oua + " text: \n");
            this.Console.Out.Write(k);
            this.Console.Out.Write("\n");
        }

        string oub;
        oub = "DemoData/Demo4.txt";
        File.Delete(oub);

        bo = false;
        bool bac;
        bac = infra.TextWrite(oub, "Demo Storage Set Count aaaadda");
        if (!bac)
        {
            this.Console.Out.Write("Write " + oub + " Error\n");
            bo = true;
        }
        if (bac)
        {
            bool bd;
            bd = infra.CountSet(oub, 22);
            if (!bd)
            {
                this.Console.Out.Write("Set Count " + oub + " Error\n");
                bo = true;
            }
        }
        if (!bo)
        {
            k = infra.TextRead(oub);
            this.Console.Out.Write(oub + " text: \n");
            this.Console.Out.Write(k);
            this.Console.Out.Write("\n");
        }
        return true;
    }

    private bool WriteStringPos(string filePath, string text, long pos)
    {
        byte[] d;
        d = Encoding.UTF8.GetBytes(text);

        Data data;
        data = new Data();
        data.Init();
        data.Value = d;
        DataRange range;
        range = new DataRange();
        range.Init();
        range.Index = 0;
        range.Count = data.Count;

        Storage storage;
        storage = new Storage();
        storage.Init();
        StorageMode mode;
        mode = new StorageMode();
        mode.Init();
        mode.Read = true;
        mode.Write = true;
        storage.Path = filePath;
        storage.Mode = mode;
        storage.Open();

        bool o;
        o = false;
        if (storage.Status == this.StorageStatusList.NoError)
        {
            Stream stream;
            stream = storage.Stream;
            stream.PosSet(pos);
            if (stream.Status == 0)
            {
                stream.Write(data, range);
                if (stream.Status == 0)
                {
                    o = true;
                }
            }
        }
        storage.Close();
        storage.Final();
        return o;
    }

    private bool ExecuteStorageArrange()
    {
        StorageArrange arrange;
        arrange = new StorageArrange();
        arrange.Init();

        bool b;

        string pathA;        
        pathA = "DemoData/DemoRename.txt";
        string destPathA;
        destPathA = "DemoData/Rename/Demo_a.txt";

        try
        {
            File.Create(pathA).Dispose();
        }
        catch
        {
        }
        try
        {
            Directory.CreateDirectory("DemoData/Rename");
            File.Delete(destPathA);
        }
        catch
        {
        }

        b = arrange.Rename(pathA, destPathA);

        this.Console.Out.Write("Rename File " + pathA + " " + this.StorageArrangeStatus(b) + "\n");

        string pathAa;
        pathAa = "DemoData/FoldRename";
        string pathAaa;
        pathAaa = pathAa + "/FoldAa";
        string pathAab;
        pathAab = pathAaa + "/FileA";
        string destPathAa;
        destPathAa = "DemoData/FoldRenameDest";

        try
        {
            Directory.Delete(destPathAa);
        }
        catch
        {
        }
        try
        {
            Directory.CreateDirectory(pathAaa);
            File.Create(pathAab).Dispose();
        }
        catch
        {
        }

        b = arrange.Rename(pathAa, destPathAa);

        this.Console.Out.Write("Rename Fold " + pathAa + " " + this.StorageArrangeStatus(b) + "\n");

        string path;
        path = "DemoData/DemoCopy.txt";
        string destPath;
        destPath = "DemoData/DemoCopy_Copy.txt";
        File.Delete(destPath);

        b = arrange.FileCopy(path, destPath);

        this.Console.Out.Write("FileCopy " + path + " to " + destPath + " " + this.StorageArrangeStatus(b) + "\n");

        string pathB;
        pathB = "DemoData/Remove.txt";
        try
        {
            File.Create(pathB).Dispose();
        }
        catch
        {
        }
        b = arrange.FileRemove(pathB);

        this.Console.Out.Write("FileRemove " + pathB + " " + this.StorageArrangeStatus(b) + "\n");


        string pathC;
        pathC = "DemoData/FoldA/FoldB";

        try
        {
            Directory.Delete(pathC);
            Directory.Delete("DemoData/FoldA");
        }
        catch
        {
        }

        b = arrange.FoldCreate(pathC);

        this.Console.Out.Write("FoldCreate " + pathC + " " + this.StorageArrangeStatus(b) + "\n");

        string pathCa;
        pathCa = "DemoData/FoldCopy";
        string destPathCa;
        destPathCa = "DemoData/FoldCopyDest";
        
        try
        {
            Directory.Delete(destPathCa, true);
        }
        catch
        {
        }

        b = arrange.FoldCopy(pathCa, destPathCa);

        this.Console.Out.Write("FoldCopy " + pathCa + " to " + destPathCa + " " + this.StorageArrangeStatus(b) + "\n");

        string pathCb;
        pathCb = "DemoData/RemoveFoldA";
        string pathCba;
        pathCba = pathCb + "/FoldB";
        string pathCbb;
        pathCbb = pathCba + "/FileA";
        try
        {
            Directory.CreateDirectory(pathCba);

            File.Create(pathCbb).Dispose();
        }
        catch
        {
        }

        b = arrange.FoldRemove(pathCb);

        this.Console.Out.Write("FoldRemove " + pathCb + " " + this.StorageArrangeStatus(b) + "\n");

        string pathE;
        pathE = "DemoData/image.jpg";

        b = arrange.Exist(pathE);

        this.Console.Out.Write("Exist " + pathE + " " + b.ToString() + "\n");

        arrange.Final();
        return true;
    }

    private string StorageArrangeStatus(bool b)
    {
        string k;
        k = "Success";
        if (!b)
        {
            k = "Error";
        }
        return k;
    }

    private bool ExecuteNetwork()
    {
        this.Console.Out.Write("Network Start\n");

        ThreadThread thread;
        thread = new ThreadThread();
        thread.Init();

        ThreadNetworkHostState state;
        state = new ThreadNetworkHostState();
        state.Demo = this;
        state.Init();

        thread.ExecuteState = state;
        
        thread.Execute();

        ThreadThread peerThread;
        peerThread = new ThreadThread();
        peerThread.Init();

        ThreadNetworkState aa;
        aa = new ThreadNetworkState();
        aa.Init();

        peerThread.ExecuteState = aa;

        peerThread.Execute();

        peerThread.Wait();

        thread.Wait();

        peerThread.Final();
        
        thread.Final();

        this.Console.Out.Write("Network End\n");
        return true;
    }

    private bool ExecuteNetworkProcess()
    {
        this.Console.Out.Write("NetworkProcess Start\n");

        ThreadThread thread;
        thread = new ThreadThread();
        thread.Init();

        ThreadNetworkHostState state;
        state = new ThreadNetworkHostState();
        state.Demo = this;
        state.Init();

        thread.ExecuteState = state;

        thread.Execute();

        List list;
        list = new List();
        list.Init();

        Program program;
        program = new Program();
        program.Init();
        program.Name = "DemoNetwork.exe";
        program.Argue = list;
        program.WorkFold = null;
        program.Environ = null;

        program.Execute();

        program.Wait();

        thread.Wait();

        program.Final();

        thread.Final();

        this.Console.Out.Write("NetworkProcess End\n");
        return true;
    }

    private DrawImage ThreadDrawImageCreate()
    {
        DrawImage a;
        a = this.DrawInfra.ImageCreateSize(this.DrawInfra.SizeCreate(250, 200));
        return a;
    }

    private bool ThreadDrawImageFinal(DrawImage a)
    {
        a.Final();
        return true;
    }

    private bool ExecuteDemoThread()
    {
        this.ExecuteDemoThisThread();

        ThreadPhore phore;
        phore = new ThreadPhore();
        phore.InitCount = 1;
        phore.Init();
        phore.Acquire();

        ThreadState state;
        state = new ThreadState();
        state.Init();
        state.Demo = this;
        state.Image = this.ThreadDrawImage;
        state.Phore = phore;

        ThreadThread thread;
        thread = new ThreadThread();
        thread.Init();
        thread.ExecuteState = state;
        thread.Execute();

        phore.Acquire();

        this.Console.Out.Write("Demo.ExecuteDemoThread phore Acquire Success\n");

        thread.Wait();

        int aa;
        aa = thread.Status;
        this.Console.Out.Write("Demo.ExecuteDemoThread Thread Status: 0h" + aa.ToString("x8") + "\n");

        thread.Final();

        phore.Final();
        return true;
    }

    internal bool ExecuteDemoThisThread()
    {
        ThreadThis varThis;
        varThis = new ThreadThis();
        varThis.Init();

        ThreadThread thread;
        thread = varThis.Thread;

        bool isMainThread;
        isMainThread = thread.Main;

        this.Console.Out.Write("This Thread is Main Thread: " + isMainThread.ToString() + "\n");
        return true;
    }

    private bool ExecuteTimeEvent()
    {
        this.ExecuteTimeEventOne(false, 4, 340, 0x4efd);
        this.ExecuteTimeEventOne(true, 0, 610, 0xf06e);
        return true;
    }

    private bool ExecuteTimeEventOne(bool single, int elapseCount, long time, int exitCode)
    {
        ThreadThread thread;
        thread = new ThreadThread();
        thread.Init();

        ThreadIntervalState state;
        state = new ThreadIntervalState();
        state.Init();
        state.Single = single;
        state.ElapseCount = elapseCount;
        state.Time = time;
        state.ExitCode = exitCode;

        thread.ExecuteState = state;

        thread.Execute();

        thread.Wait();

        int o;
        o = thread.Status;

        thread.Final();

        this.Console.Out.Write("Demo.ExecuteTimeEventOne Thread Status: 0h" + o.ToString("x8") + "\n");
        return true;
    }

    private bool ExecutePost()
    {
        PostState postState;
        postState = new PostState();
        postState.Init();

        ThreadPhore phore;
        phore = new ThreadPhore();
        phore.Init();

        ThreadPostState state;
        state = new ThreadPostState();
        state.Init();
        state.PostState = postState;
        state.Phore = phore;

        ThreadThread thread;
        thread = new ThreadThread();
        thread.Init();
        thread.ExecuteState = state;
        thread.Execute();

        phore.Acquire();

        state.Post.Execute();

        thread.Wait();

        int o;
        o = thread.Status;

        thread.Final();

        phore.Final();

        this.Console.Out.Write("Demo.ExecuteDemoPost Thread Status: 0h" + o.ToString("x8") + "\n");
        return true;
    }

    private DrawBrush EllipseBrushCreate()
    {
        DrawBrush a;
        a = new DrawBrush();
        a.Kind = this.BrushKindList.Color;
        a.Color = this.DrawInfra.ColorCreate(0xff, 0, 0xff, 0xff);
        a.Init();
        return a;
    }

    private bool EllipseBrushFinal(DrawBrush a)
    {
        a.Final();
        return true;
    }

    private DrawFace FaceCreate()
    {
        DrawFace a;
        a = new DrawFace();
        a.Family = "Source Code Pro";
        a.Size = 20;
        a.Weight = 400;
        a.Italic = true;
        a.Underline = true;
        a.Overline = true;
        a.Strikeout = true;
        a.Init();
        return a;
    }

    private bool FaceFinal(DrawFace a)
    {
        a.Final();
        return true;
    }

    private ViewC ViewCCreate()
    {
        DrawGradientKindList gradientKindList;
        gradientKindList = DrawGradientKindList.This;

        DrawGradientLinear gradientLinear;
        gradientLinear = new DrawGradientLinear();
        gradientLinear.StartPos = this.DrawInfra.PosIntCreate(this.MathInt(300), 0);
        gradientLinear.EndPos = this.DrawInfra.PosIntCreate(this.MathInt(300), this.MathInt(400));
        gradientLinear.Init();

        DrawGradientStop gradientStop;
        gradientStop = new DrawGradientStop();
        gradientStop.Count = 3;
        gradientStop.Init();

        DrawGradientStopPoint aa;
        aa = new DrawGradientStopPoint();
        aa.Init();

        this.GradientStopSetPoint(gradientStop, aa, 0, 0, this.DrawInfra.ColorCreate(0xff, 0xff, 0, 0));
        this.GradientStopSetPoint(gradientStop, aa, 1, this.MathValue(1, -1), this.DrawInfra.ColorCreate(0xff, 0, 0xff, 0));
        this.GradientStopSetPoint(gradientStop, aa, 2, this.MathInt(1), this.DrawInfra.ColorCreate(0xff, 0, 0, 0xff));

        DrawGradientSpreadList spreadList;
        spreadList = DrawGradientSpreadList.This;

        DrawGradient gradient;
        gradient = new DrawGradient();
        gradient.Kind = gradientKindList.Linear;
        gradient.Linear = gradientLinear;
        gradient.Stop = gradientStop;
        gradient.Spread = spreadList.Pad;
        gradient.Init();

        DrawBrush brush;
        brush = new DrawBrush();
        brush.Kind = this.BrushKindList.Gradient;
        brush.Gradient = gradient;
        brush.Init();

        DrawBrush ellipseBrush;
        ellipseBrush = this.EllipseBrushCreate();

        DrawFace face;
        face = this.FaceCreate();

        DrawBrush textPen;
        textPen = this.TextPenCreate();

        DrawTextAlignList textAlignList;
        textAlignList = DrawTextAlignList.This;

        string oa;
        oa = "G L 的哈gd@行 o #";

        Text text;
        text = this.TextInfra.TextCreateString(oa, null);

        ViewC viewC;
        viewC = new ViewC();
        viewC.Init();
        viewC.Pos.Col = -300;
        viewC.Pos.Row = 0;
        viewC.Size.Width = 500;
        viewC.Size.Height = 400;
        viewC.Back = brush;
        viewC.EllipseBrush = ellipseBrush;
        viewC.EllipseRect = this.DrawInfra.RectIntCreate(0, 0, this.MathInt(100), this.MathInt(50));
        viewC.Face = face;
        viewC.Text = text;
        viewC.TextAlign = textAlignList.CenterUp;
        viewC.TextPen = textPen;
        return viewC;
    }

    private bool ViewCFinal(ViewC a)
    {
        DrawBrush textPen;
        textPen = a.TextPen;
        DrawBrush ellipseBrush;
        ellipseBrush = a.EllipseBrush;
        DrawBrush brush;
        brush = a.Back;
        DrawGradient gradient;
        gradient = brush.Gradient;
        DrawGradientStop gradientStop;
        gradientStop = gradient.Stop;
        DrawGradientLinear gradientLinear;
        gradientLinear = gradient.Linear;

        DrawFace font;
        font = a.Face;

        this.TextPenFinal(textPen);

        this.FaceFinal(font);

        this.EllipseBrushFinal(ellipseBrush);

        brush.Final();

        gradient.Final();

        gradientStop.Final();

        gradientLinear.Final();
        return true;
    }

    private bool GradientStopSetPoint(DrawGradientStop stop, DrawGradientStopPoint aa, int index, long pos, DrawColor color)
    {
        aa.Pos = pos;
        aa.Color = color;
        stop.PointSet(index, aa);
        return true;
    }

    private DrawBrush TextPenCreate()
    {
        DrawBrush a;
        a = new DrawBrush();
        a.Kind = this.BrushKindList.Color;
        a.Color = this.DrawInfra.ColorCreate(0xff, 0, 0, 0xff);
        a.Line = this.BrushLineList.DashDotDot;
        a.Width = this.MathInt(14);
        a.Cap = this.BrushCapList.Round;
        a.Join = this.BrushJoinList.Bevel;
        a.Init();
        return a;
    }

    private bool TextPenFinal(DrawBrush a)
    {
        a.Final();
        return true;
    }

    private AudioEffect AudioEffectCreate()
    {
        AudioEffect a;
        a = new AudioEffect();
        a.Source = "file:DemoData/DemoSound.wav";
        a.Init();
        return a;
    }

    private bool AudioEffectFinal(AudioEffect a)
    {
        a.Final();
        return true;
    }

    private Play PlayCreate()
    {
        VideoFrame videoFrame;
        videoFrame = new VideoFrame();
        videoFrame.Init();
        VideoFrameState frameState;
        frameState = new VideoFrameState();
        frameState.Init();
        frameState.Demo = this;

        VideoOut videoOut;
        videoOut = new VideoOut();
        videoOut.Init();
        videoOut.Frame = videoFrame;
        videoOut.FrameState = frameState;

        long scaleFactor;        
        scaleFactor = 1 << 20;

        long volume;
        volume = this.MathValue(scaleFactor / 8, -20);

        AudioOut audioOut;
        audioOut = new AudioOut();
        audioOut.Init();
        audioOut.Volume = volume;

        Play a;
        a = new Play();
        a.Init();
        a.Source = "file:DemoData/Video.mp4";
        a.SourceSet();
        a.VideoOut = videoOut;
        a.AudioOut = audioOut;
        a.VideoOutSet();
        a.AudioOutSet();
        return a;
    }

    private bool PlayFinal(Play a)
    {
        VideoOut videoOut;
        videoOut = a.VideoOut;
        VideoFrame videoFrame;
        videoFrame = videoOut.Frame;

        AudioOut audioOut;
        audioOut = a.AudioOut;

        a.Final();

        audioOut.Final();

        videoOut.Final();

        videoFrame.Final();
        return true;
    }

    private DrawImage PlayImageCreate()
    {
        DrawImage a;
        a = new DrawImage();
        a.Init();
        return a;
    }

    private bool PlayImageFinal(DrawImage a)
    {
        a.Final();
        return true;
    }

    public virtual long MathInt(long n)
    {
        MathInfra mathInfra;
        mathInfra = this.MathInfra;

        MathMath math;
        math = this.Math;

        MathComp mathComp;
        mathComp = this.MathComp;

        long a;
        a = mathInfra.Int(math, mathComp, n);
        return a;
    }

    public virtual long MathValue(long significand, long exponent)
    {
        MathComp mathComp;
        mathComp = this.MathComp;

        mathComp.Cand = significand;
        mathComp.Expo = exponent;

        long a;
        a = this.Math.Value(mathComp);
        return a;
    }
}