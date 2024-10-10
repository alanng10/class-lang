namespace Demo;

class Demo : Any
{
    public NetworkNetwork Peer { get; set; }
    public NetworkHostA Host { get; set; }

    public virtual InfraInfra InfraInfra { get; set; }
    public virtual ListInfra ListInfra { get; set; }
    public virtual MathInfra MathInfra { get; set; }
    public virtual TextInfra TextInfra { get; set; }
    public virtual StorageInfra StorageInfra { get; set; }
    public virtual StringComp StringComp { get; set; }
    public virtual TextCode TextCode { get; set; }
    public virtual TextCodeKindList TextCodeKindList { get; set; }
    public virtual StorageStatusList StorageStatusList { get; set; }
    public virtual StorageComp StorageComp { get; set; }
    public virtual NetworkPortKindList NetworkPortKindList { get; set; }
    public virtual NetworkCaseList NetworkCaseList { get; set; }
    public virtual NetworkStatusList NetworkStatusList { get; set; }
    public virtual Console Console { get; set; }

    public virtual MathMath Math { get; set; }
    protected virtual MathComp MathComp { get; set; }
    private StringAdd StringAdd { get; set; }
    private TextWrite TextWrite { get; set; }
    private TextWriteArg TextWriteArg { get; set; }

    public bool Execute()
    {
        this.InfraInfra = InfraInfra.This;
        this.ListInfra = ListInfra.This;
        this.TextInfra = TextInfra.This;
        this.MathInfra = MathInfra.This;
        this.StorageInfra = StorageInfra.This;
        this.StringComp = StringComp.This;
        this.TextCode = TextCode.This;
        this.TextCodeKindList = TextCodeKindList.This;
        this.StorageStatusList = StorageStatusList.This;
        this.StorageComp = StorageComp.This;
        this.NetworkPortKindList = NetworkPortKindList.This;
        this.NetworkCaseList = NetworkCaseList.This;
        this.NetworkStatusList = NetworkStatusList.This;
        this.Console = Console.This;

        this.StringAdd = new StringAdd();
        this.StringAdd.Init();

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
        this.ExecuteStorageComp();

        this.ExecuteDemoThread();
        this.ExecuteTimeEvent();
        this.ExecutePost();

        this.ExecuteNetwork();
        this.ExecuteNetworkProcess();
        return true;
    }

    private bool ExecuteConsole()
    {
        this.Console.Out.Write(this.S("Console 水中\n"));

        this.Console.Out.Write(this.S("Input a: "));

        String ka;

        String a;
        a = this.Console.Inn.Read();

        ka = this.AddClear().AddS("a: ").Add(a).AddS("\n").AddResult();

        this.Console.Out.Write(ka);

        this.Console.Out.Write(this.S("Input aa: "));
        
        String aa;
        aa = this.Console.Inn.Read();

        ka = this.AddClear().AddS("aa: ").Add(aa).AddS("\n").AddResult();
        
        this.Console.Out.Write(ka);
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
        
        String ka;

        ka = this.AddClear()
            .AddS(prefix)
            .AddS("Cand: ")
            .AddS(this.MathComp.Cand.ToString("x"))
            .AddS(", ")
            .AddS("Expo: ")
            .AddS(this.MathComp.Expo.ToString())
            .AddS("\n")
            .AddResult()
            ;

        this.Console.Out.Write(ka);

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

        String ka;

        ka = this.AddClear()
            .AddS("Demo.ExecuteRand oa: 0h")
            .AddS(oa.ToString("x15"))
            .AddS("\n")
            .AddResult();
            ;

        this.Console.Out.Write(ka);

        rand.Final();
        return true;
    }

    private bool ExecuteFormat()
    {
        TextWriteArg argA;
        argA = new TextWriteArg();
        argA.Init();
        argA.Pos = 3;
        argA.Kind = 0;
        argA.Value.Bool = true;
        argA.FieldWidth = 6;
        argA.MaxWidth = -1;
        argA.FillChar = ' ';
        argA.Form = this.TextInfra.AlphaNiteForm;

        TextWriteArg argB;
        argB = new TextWriteArg();
        argB.Init();
        argB.Pos = 3;
        argB.Kind = 1;
        argB.Value.Int = 56712;
        argB.AlignLeft = true;
        argB.FieldWidth = 8;
        argB.MaxWidth = 6;
        argB.Base = 10;
        argB.FillChar = ' ';

        TextWriteArg argC;
        argC = new TextWriteArg();
        argC.Init();
        argC.Pos = 6;
        argC.Kind = 1;
        argC.Value.Int = 46842;
        argC.AlignLeft = false;
        argC.FieldWidth = 8;
        argC.MaxWidth = 6;
        argC.Base = 10;
        argC.FillChar = ' ';

        TextWriteArg argD;
        argD = new TextWriteArg();
        argD.Init();
        argD.Pos = 7;
        argD.Kind = 1;
        argD.Value.Int = 0x5bd9ea;
        argD.AlignLeft = false;
        argD.FieldWidth = 8;
        argD.MaxWidth = 6;
        argD.Base = 16;
        argD.FillChar = ' ';
        argD.Form = this.TextInfra.AlphaNiteForm;

        TextWriteArg argDA;
        argDA = new TextWriteArg();
        argDA.Init();
        argDA.Pos = 7;
        argDA.Kind = 1;
        argDA.Value.Int = 100;
        argDA.AlignLeft = false;
        argDA.FieldWidth = 4;
        argDA.MaxWidth = -1;
        argDA.Base = 10;

        TextWriteArg argDB;
        argDB = new TextWriteArg();
        argDB.Init();
        argDB.Pos = 8;
        argDB.Kind = 1;
        argDB.Value.Int = 0;
        argDB.AlignLeft = false;
        argDB.FieldWidth = 3;
        argDB.MaxWidth = -1;
        argDB.Base = 10;
        argDB.FillChar = ':';

        TextWriteArg argE;
        argE = new TextWriteArg();
        argE.Init();
        argE.Pos = 10;
        argE.Kind = 2;
        argE.Value.Any = this.TextInfra.TextCreateStringData(this.S("F Hre a"), null);
        argE.AlignLeft = true;
        argE.FieldWidth = 11;
        argE.MaxWidth = 10;
        argE.FillChar = '=';
        argE.Form = this.TextInfra.AlphaNiteForm;

        TextWriteArg argF;
        argF = new TextWriteArg();
        argF.Init();
        argF.Pos = 10;
        argF.Kind = 2;
        argF.Value.Any = this.TextInfra.TextCreateStringData(this.StringComp.CreateChar('H', 1), null);
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
        varBase = this.TextInfra.TextCreateStringData(this.S("G H , j h\n\n"), null);

        TextWrite write;
        write = new TextWrite();
        write.Init();

        long count;
        count = write.ExecuteCount(varBase, argList);

        Text text;
        text = this.TextInfra.TextCreate(count);

        write.ExecuteResult(varBase, argList, text);

        String a;
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
        long ooa;

        ooo = this.TextInfra.TextCreateStringData(this.S("43695"), null);        
        ooa = a.Execute(ooo, 10, false, null);
        this.ConsoleWriteIntParse(ooa);

        ooo = this.TextInfra.TextCreateStringData(this.S("9E532F"), null);
        ooa = a.Execute(ooo, 16, true, null);
        this.ConsoleWriteIntParse(ooa);

        ooo = this.TextInfra.TextCreateStringData(this.S("0000000000009294ef0d"), null);
        ooa = a.Execute(ooo, 16, false, null);
        this.ConsoleWriteIntParse(ooa);

        ooo = this.TextInfra.TextCreateStringData(this.S("1000000000000000"), null);
        ooa = a.Execute(ooo, 16, true, null);
        this.ConsoleWriteIntParse(ooa);
        return true;
    }

    private bool ConsoleWriteIntParse(long a)
    {
        String ka;

        ka = this.AddClear()
            .AddS("Demo.ExecuteIntParse ooa: ")
            .AddS(a.ToString("x16"))
            .AddS("\n")
            .AddResult()
            ;

        this.Console.Out.Write(ka);

        return true;
    }

    private bool ExecuteTime()
    {
        TextWrite write;
        write = new TextWrite();
        write.Init();

        this.TextWrite = write;

        TextWriteArg arg;
        arg = new TextWriteArg();
        arg.Init();
        arg.Kind = 1;
        arg.Base = 10;
        arg.MaxWidth = -1;
        arg.FieldWidth = 1;
        this.TextWriteArg = arg;

        Time time;
        time = new Time();
        time.Init();
        
        this.ConsoleWriteTime("Demo.ExecuteTime time init : ", time);
        
        time.This();
        this.ConsoleWriteTime("Demo.ExecuteTime time current : ", time);

        time.ToPos(2 * 60 * 60);
        this.ConsoleWriteTime("Demo.ExecuteTime time ToPos : ", time);

        time.AddTick(200 * 1000);
        this.ConsoleWriteTime("Demo.ExecuteTime time AddMillisec : ", time);

        time.Final();
        return true;
    }

    private bool ConsoleWriteTime(string prefix, Time time)
    {
        this.AddClear().AddS(prefix);

        this.AddS("yea: ").Add(this.IntString(time.Yea))
            .AddS(", mon: ").Add(this.IntString(time.Mon))
            .AddS(", day: ").Add(this.IntString(time.Day))
            .AddS(", our: ").Add(this.IntString(time.Our))
            .AddS(", min: ").Add(this.IntString(time.Min))
            .AddS(", sec: ").Add(this.IntString(time.Sec))
            .AddS(", millisec: ").Add(this.IntString(time.Tick))
            .AddS(", pos: ").Add(this.IntString(time.Pos))
            .AddS("\n");

        String k;
        k = this.AddResult();

        this.Console.Out.Write(k);

        return true;
    }

    private String IntString(long o)
    {
        this.TextWriteArg.Value.Int = o;

        this.TextWrite.ExecuteArgCount(this.TextWriteArg);

        Text text;
        text = this.TextInfra.TextCreate(this.TextWriteArg.Count);

        this.TextWrite.ExecuteArgResult(this.TextWriteArg, text);

        String a;
        a = this.TextInfra.StringCreate(text);

        return a;
    }

    private bool ExecuteStorage()
    {
        StorageInfra infra;
        infra = StorageInfra.This;

        String ka;
        
        String k;
        k = infra.TextRead(this.S("DemoData/Demo.txt"));
        this.Console.Out.Write(this.S("Demo.txt text: \n"));
        this.Console.Out.Write(k);
        this.Console.Out.Write(this.S("\n"));

        string ou;
        ou = "DemoData/Demo2.txt";
        File.Delete(ou);

        String kou;
        kou = this.S(ou);

        bool b;
        b = false;
        bool ba;
        ba = infra.TextWrite(kou, this.S("DEMO STORAGE WRITE AAA BBB"));
        if (!ba)
        {
            ka = this.AddClear().AddS("Write ").Add(kou).AddS(" 1 Error\n").AddResult();

            this.Console.Out.Write(ka);
            b = true;
        }

        if (ba)
        {
            bool bb;
            bb = infra.TextWrite(kou, this.S("DEMO STORAGE WRITE 2 AAA"));
            if (!bb)
            {
                ka = this.AddClear().AddS("Write ").Add(kou).AddS(" 3 Error\n").AddResult();

                this.Console.Out.Write(ka);
                b = true;
            }
        }

        if (!b)
        {
            k = infra.TextRead(kou);

            ka = this.AddClear().Add(kou).AddS(" text: \n").Add(k).AddS("\n").AddResult();

            this.Console.Out.Write(ka);
        }

        string oua;
        oua = "DemoData/Demo3.txt";
        File.Delete(oua);

        String koua;
        koua = this.S(oua);

        bool bo;
        bo = false;
        bool baa;
        baa = infra.TextWrite(koua, this.S("DEMO STORAGE WRITE DEMO ABCD"));
        if (!baa)
        {
            ka = this.AddClear().AddS("Write ").Add(koua).AddS(" 1 Error\n").AddResult();

            this.Console.Out.Write(ka);
            bo = true;
        }
        if (baa)
        {
            String koa;
            koa = this.S("OUHU");

            bool bab;
            bab = this.WriteStringPos(koua, koa, 19);
            if (!bab)
            {
                ka = this.AddClear().AddS("Write ").Add(koua).AddS(" 2 Error\n").AddResult();

                this.Console.Out.Write(ka);
                bo = true;
            }
        }
        if (!bo)
        {
            k = infra.TextRead(koua);

            ka = this.AddClear().Add(koua).AddS(" text: \n").Add(k).AddS("\n").AddResult();

            this.Console.Out.Write(ka);
        }

        string oub;
        oub = "DemoData/Demo4.txt";
        File.Delete(oub);

        String koub;
        koub = this.S(oub);

        bo = false;
        bool bac;
        bac = infra.TextWrite(koub, this.S("Demo Storage Set Count aaaadda"));
        if (!bac)
        {
            ka = this.AddClear().AddS("Write ").Add(koub).AddS(" Error\n").AddResult();

            this.Console.Out.Write(ka);
            bo = true;
        }
        if (bac)
        {
            bool bd;
            bd = infra.CountSet(koub, 22);
            if (!bd)
            {
                ka = this.AddClear().AddS("Set Count ").Add(koub).AddS(" Error\n").AddResult();

                this.Console.Out.Write(ka);
                bo = true;
            }
        }
        if (!bo)
        {
            k = infra.TextRead(koub);

            ka = this.AddClear().Add(koub).AddS(" text: \n").Add(k).AddS("\n").AddResult();

            this.Console.Out.Write(ka);
        }
        return true;
    }

    private bool WriteStringPos(String filePath, String text, long pos)
    {
        TextCodeKindList list;
        list = this.TextCodeKindList;

        Data data;
        data = this.TextInfra.StringDataCreateString(text);

        Range range;
        range = new Range();
        range.Init();
        range.Count = data.Count;

        Data resultData;
        resultData = this.TextInfra.Code(list.Utf32, list.Utf8, data, range);

        Range resultRange;
        resultRange = new Range();
        resultRange.Init();
        resultRange.Count = resultData.Count;

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
                stream.Write(resultData, resultRange);
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

    private bool ExecuteStorageComp()
    {
        StorageComp storageComp;
        storageComp = this.StorageComp;

        String kaaaa;
        kaaaa = this.AddClear().AddS("Module Fold Path: ").Add(storageComp.ModuleFoldPath).AddLine().AddResult();

        this.Console.Out.Write(kaaaa);

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

        b = storageComp.Rename(this.S(pathA), this.S(destPathA));

        this.Console.Out.Write(this.S("Rename File " + pathA + " " + this.StorageArrangeStatus(b) + "\n"));

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

        b = storageComp.Rename(this.S(pathAa), this.S(destPathAa));

        this.Console.Out.Write(this.S("Rename Fold " + pathAa + " " + this.StorageArrangeStatus(b) + "\n"));

        string path;
        path = "DemoData/DemoCopy.txt";
        string destPath;
        destPath = "DemoData/DemoCopy_Copy.txt";
        File.Delete(destPath);

        b = storageComp.FileCopy(this.S(path), this.S(destPath));

        this.Console.Out.Write(this.S("FileCopy " + path + " to " + destPath + " " + this.StorageArrangeStatus(b) + "\n"));

        string pathB;
        pathB = "DemoData/Remove.txt";
        try
        {
            File.Create(pathB).Dispose();
        }
        catch
        {
        }
        b = storageComp.FileDelete(this.S(pathB));

        this.Console.Out.Write(this.S("FileRemove " + pathB + " " + this.StorageArrangeStatus(b) + "\n"));


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

        b = storageComp.FoldCreate(this.S(pathC));

        this.Console.Out.Write(this.S("FoldCreate " + pathC + " " + this.StorageArrangeStatus(b) + "\n"));

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

        b = storageComp.FoldCopy(this.S(pathCa), this.S(destPathCa));

        this.Console.Out.Write(this.S("FoldCopy " + pathCa + " to " + destPathCa + " " + this.StorageArrangeStatus(b) + "\n"));

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

        b = storageComp.FoldDelete(this.S(pathCb));

        this.Console.Out.Write(this.S("FoldRemove " + pathCb + " " + this.StorageArrangeStatus(b) + "\n"));

        string pathE;
        pathE = "DemoData/image.jpg";

        b = storageComp.Exist(this.S(pathE));

        this.Console.Out.Write(this.S("Exist " + pathE + " " + b.ToString() + "\n"));

        String foldListPath;
        foldListPath = this.S("DemoData/FoldCopy/FoldA");

        Array foldList;
        foldList = storageComp.FoldList(foldListPath);

        this.AddClear().AddS("Fold List: \n");

        long count;
        count = foldList.Count;
        long i;
        i = 0;
        while (i < count)
        {
            String fold;
            fold = (String)foldList.GetAt(i);

            this.Add(fold).AddLine();

            i = i + 1;
        }

        String aaka;
        aaka = this.AddResult();

        this.Console.Out.Write(aaka);

        String fileListPath;
        fileListPath = this.S("DemoData/FoldCopy/FoldA/FoldB");

        Array fileList;
        fileList = storageComp.FileList(fileListPath);

        this.AddClear().AddS("File List: \n");

        count = fileList.Count;
        i = 0;
        while (i < count)
        {
            String file;
            file = (String)fileList.GetAt(i);

            this.Add(file).AddLine();

            i = i + 1;
        }

        String aakb;
        aakb = this.AddResult();

        this.Console.Out.Write(aakb);

        storageComp.Final();
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
        this.Console.Out.Write(this.S("Network Start\n"));

        ThreadThread hostThread;
        hostThread = new ThreadThread();
        hostThread.Init();

        ThreadNetworkHostState state;
        state = new ThreadNetworkHostState();
        state.Demo = this;
        state.Init();

        hostThread.ExecuteState = state;

        hostThread.Execute();

        ThreadThread networkThread;
        networkThread = new ThreadThread();
        networkThread.Init();

        ThreadNetworkState aa;
        aa = new ThreadNetworkState();
        aa.Init();

        networkThread.ExecuteState = aa;

        networkThread.Execute();

        networkThread.Wait();

        hostThread.Wait();

        networkThread.Final();

        hostThread.Final();

        this.Console.Out.Write(this.S("Network End\n"));
        return true;
    }

    private bool ExecuteNetworkProcess()
    {
        this.Console.Out.Write(this.S("NetworkProcess Start\n"));

        ThreadThread hostThread;
        hostThread = new ThreadThread();
        hostThread.Init();

        ThreadNetworkHostState state;
        state = new ThreadNetworkHostState();
        state.Demo = this;
        state.Init();

        hostThread.ExecuteState = state;

        hostThread.Execute();

        List list;
        list = new List();
        list.Init();

        Program program;
        program = new Program();
        program.Init();
        program.Name = this.S("DemoNetwork.exe");
        program.Argue = list;
        program.WorkFold = null;
        program.Environ = null;

        program.Execute();

        program.Wait();

        hostThread.Wait();

        program.Final();

        hostThread.Final();

        this.Console.Out.Write(this.S("NetworkProcess End\n"));
        return true;
    }

    private bool ExecuteDemoThread()
    {
        this.ExecuteDemoThisThread();

        ThreadPhore phore;
        phore = new ThreadPhore();
        phore.InitCount = 1;
        phore.Init();
        phore.Open();

        ThreadState state;
        state = new ThreadState();
        state.Init();
        state.Demo = this;
        state.Phore = phore;

        ThreadThread thread;
        thread = new ThreadThread();
        thread.Init();
        thread.ExecuteState = state;
        thread.Execute();

        phore.Open();

        this.Console.Out.Write(this.S("Demo.ExecuteDemoThread phore Acquire Success\n"));

        thread.Wait();

        long aa;
        aa = thread.Status;
        this.Console.Out.Write(this.S("Demo.ExecuteDemoThread Thread Status: 0h" + aa.ToString("x8") + "\n"));

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

        this.Console.Out.Write(this.S("This Thread is Main Thread: " + isMainThread.ToString() + "\n"));
        return true;
    }

    private bool ExecuteTimeEvent()
    {
        this.ExecuteTimeEventOne(false, 4, 340, 0x4efd);
        this.ExecuteTimeEventOne(true, 0, 610, 0xf06e);
        return true;
    }

    private bool ExecuteTimeEventOne(bool single, long elapseCount, long time, long exitCode)
    {
        ThreadThread thread;
        thread = new ThreadThread();
        thread.Init();

        ThreadIntervalState state;
        state = new ThreadIntervalState();
        state.Init();
        state.Demo = this;
        state.ElapseCount = elapseCount;
        state.Time = time;
        state.ExitCode = exitCode;

        thread.ExecuteState = state;

        thread.Execute();

        thread.Wait();

        long o;
        o = thread.Status;

        thread.Final();

        this.Console.Out.Write(this.S("Demo.ExecuteTimeEventOne Thread Status: 0h" + o.ToString("x8") + "\n"));
        return true;
    }

    private bool ExecutePost()
    {
        PostState postState;
        postState = new PostState();
        postState.Init();
        postState.Demo = this;

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

        phore.Open();

        state.Post.Execute();

        thread.Wait();

        long o;
        o = thread.Status;

        thread.Final();

        phore.Final();

        this.Console.Out.Write(this.S("Demo.ExecuteDemoPost Thread Status: 0h" + o.ToString("x8") + "\n"));
        return true;
    }

    public virtual Demo Add(String a)
    {
        this.InfraInfra.AddString(this.StringAdd, a);
        return this;
    }

    public virtual Demo AddLine()
    {
        return this.Add(this.TextInfra.NewLine);
    }

    public virtual Demo AddS(string o)
    {
        this.Add(this.S(o));
        return this;
    }

    public virtual Demo AddClear()
    {
        this.StringAdd.Clear();
        return this;
    }

    public virtual String AddResult()
    {
        return this.StringAdd.Result();
    }

    public virtual String S(string o)
    {
        return this.TextInfra.S(o);
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