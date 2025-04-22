namespace Demo;

class Demo : TextAdd
{
    public override bool Init()
    {
        base.Init();
        this.InfraInfra = InfraInfra.This;
        this.ListInfra = ListInfra.This;
        this.MathInfra = MathInfra.This;
        this.StorageInfra = StorageInfra.This;
        this.Math = MathMath.This;
        this.TextCode = TextCode.This;
        this.TextCodeKindList = TextCodeKindList.This;
        this.StorageStatusList = StorageStatusList.This;
        this.StorageComp = StorageComp.This;
        this.NetworkPortKindList = NetworkPortKindList.This;
        this.NetworkCaseList = NetworkCaseList.This;
        this.NetworkStatusList = NetworkStatusList.This;
        this.Console = Console.This;

        this.MathComp = new MathComp();
        this.MathComp.Init();

        this.SSuccess = this.S("Success");
        this.SError = this.S("Error");
        return true;
    }

    public virtual NetworkNetwork Peer { get; set; }
    public virtual NetworkHostA Host { get; set; }
    public virtual InfraInfra InfraInfra { get; set; }
    public virtual ListInfra ListInfra { get; set; }
    public virtual MathInfra MathInfra { get; set; }
    public virtual StorageInfra StorageInfra { get; set; }
    public virtual MathMath Math { get; set; }
    public virtual TextCode TextCode { get; set; }
    public virtual TextCodeKindList TextCodeKindList { get; set; }
    public virtual StorageStatusList StorageStatusList { get; set; }
    public virtual StorageComp StorageComp { get; set; }
    public virtual NetworkPortKindList NetworkPortKindList { get; set; }
    public virtual NetworkCaseList NetworkCaseList { get; set; }
    public virtual NetworkStatusList NetworkStatusList { get; set; }
    public virtual Console Console { get; set; }
    protected virtual MathComp MathComp { get; set; }
    private long ArrayIndex { get; set; }
    private String SSuccess { get; set; }
    private String SError { get; set; }

    public bool Execute()
    {
        this.ExecuteConsole();
        this.ExecuteList();
        this.ExecuteMath();
        this.ExecuteRand();
        this.ExecuteFormat();
        this.ExecuteIntParse();
        this.ExecuteMemoryStream();
        this.ExecuteTime();
        this.ExecuteStorage();
        this.ExecuteStoragePath();
        this.ExecuteStorageStream();
        this.ExecuteStorageComp();

        this.ExecuteDemoThread();
        this.ExecuteTimeEvent();

        this.ExecuteNetwork();
        this.ExecuteNetworkProgram();
        return true;
    }

    private bool ExecuteConsole()
    {
        this.Console.Out.Write(this.S("Console 水中\n"));

        this.Console.Out.Write(this.S("Input a: "));

        String a;
        a = this.Console.Inn.Read();

        String ka;
        ka = this.AddClear().AddS("a: ").Add(a).AddLine().AddResult();

        this.Console.Out.Write(ka);

        this.Console.Out.Write(this.S("Input aa: "));

        String aa;
        aa = this.Console.Inn.Read();

        ka = this.AddClear().AddS("aa: ").Add(aa).AddLine().AddResult();
        
        this.Console.Out.Write(ka);
        return true;
    }

    private bool ExecuteList()
    {
        this.ExecuteListList();
        this.ExecuteListTable();
        this.ExecuteListSort();
        this.ExecuteListFind();
        return true;
    }

    private bool ExecuteListList()
    {
        List list;
        list = new List();
        list.Init();

        object indexA;
        object indexB;
        this.ListAddInt(list, 983501);
        indexA = this.ListAddInt(list, 6728);
        indexB = this.ListAddInt(list, 8197);

        Array array;
        array = this.ListInfra.ArrayCreateList(list);

        bool b;
        b = (array.Count == 3);
        b = b & this.ArrayIntSame(array, 0, 983501);
        b = b & this.ArrayIntSame(array, 1, 6728);
        b = b & this.ArrayIntSame(array, 2, 8197);

        this.Console.Out.Write(this.AddClear().AddS("List Add ").Add(this.StatusString(b)).AddLine().AddResult());

        list.Rem(indexA);

        array = this.ListInfra.ArrayCreateList(list);

        b = (array.Count == 2);
        b = b & this.ArrayIntSame(array, 0, 983501);
        b = b & this.ArrayIntSame(array, 1, 8197);

        this.Console.Out.Write(this.AddClear().AddS("List Rem ").Add(this.StatusString(b)).AddLine().AddResult());

        Value ka;
        ka = new Value();
        ka.Init();
        ka.Int = 792461;

        list.Ins(indexB, ka);

        array = this.ListInfra.ArrayCreateList(list);

        b = (array.Count == 3);
        b = b & this.ArrayIntSame(array, 0, 983501);
        b = b & this.ArrayIntSame(array, 1, 792461);
        b = b & this.ArrayIntSame(array, 2, 8197);

        this.Console.Out.Write(this.AddClear().AddS("List Ins ").Add(this.StatusString(b)).AddLine().AddResult());

        return true;
    }

    private bool ExecuteListTable()
    {
        RefLess less;
        less = new RefLess();
        less.Init();

        Table table;
        table = new Table();
        table.Less = less;
        table.Init();

        this.TableAddInt(table, 983501);
        this.TableAddInt(table, 6728);
        this.TableAddInt(table, 8197);

        Array array;
        array = this.ListInfra.ArrayCreateList(table);

        bool b;
        b = (array.Count == 3);
        b = b & this.ArrayIntSame(array, 0, 983501);
        b = b & this.ArrayIntSame(array, 1, 6728);
        b = b & this.ArrayIntSame(array, 2, 8197);

        this.Console.Out.Write(this.AddClear().AddS("Table Add ").Add(this.StatusString(b)).AddLine().AddResult());

        object kk;
        kk = array.GetAt(1);

        table.Rem(kk);

        array = this.ListInfra.ArrayCreateList(table);

        b = (array.Count == 2);
        b = b & this.ArrayIntSame(array, 0, 983501);
        b = b & this.ArrayIntSame(array, 1, 8197);

        this.Console.Out.Write(this.AddClear().AddS("Table Rem ").Add(this.StatusString(b)).AddLine().AddResult());

        kk = array.GetAt(1);

        Value ka;
        ka = new Value();
        ka.Init();
        ka.Int = 792461;

        ListEntry kaa;
        kaa = new ListEntry();
        kaa.Init();
        kaa.Index = ka;
        kaa.Value = ka;

        table.Ins(kk, kaa);

        array = this.ListInfra.ArrayCreateList(table);

        b = (array.Count == 3);
        b = b & this.ArrayIntSame(array, 0, 983501);
        b = b & this.ArrayIntSame(array, 1, 792461);
        b = b & this.ArrayIntSame(array, 2, 8197);

        this.Console.Out.Write(this.AddClear().AddS("Table Ins ").Add(this.StatusString(b)).AddLine().AddResult());

        return true;
    }

    private bool ExecuteListSort()
    {
        Array array;
        array = this.ListInfra.ArrayCreate(5);

        this.ArrayIndex = 0;

        this.ArrayAddInt(array, 91);
        this.ArrayAddInt(array, 2632);
        this.ArrayAddInt(array, 8);
        this.ArrayAddInt(array, 2633);
        this.ArrayAddInt(array, 2631);

        LessA less;
        less = new LessA();
        less.Init();

        Range range;
        range = new Range();
        range.Init();
        range.Count = array.Count;

        Array copyArray;
        copyArray = this.ListInfra.ArrayCreate(array.Count);

        this.ListInfra.Sort(array, less, range, copyArray);

        bool b;
        b = true;
        b = b & this.ArrayIntSame(array, 0, 8);
        b = b & this.ArrayIntSame(array, 1, 91);
        b = b & this.ArrayIntSame(array, 2, 2631);
        b = b & this.ArrayIntSame(array, 3, 2632);
        b = b & this.ArrayIntSame(array, 4, 2633);

        this.Console.Out.Write(this.AddClear().AddS("List Sort ").Add(this.StatusString(b)).AddLine().AddResult());
        return true;
    }

    private bool ExecuteListFind()
    {
        Array array;
        array = this.ListInfra.ArrayCreate(5);

        this.ArrayIndex = 0;

        this.ArrayAddInt(array, 8);
        this.ArrayAddInt(array, 91);
        this.ArrayAddInt(array, 2631);
        this.ArrayAddInt(array, 2632);
        this.ArrayAddInt(array, 2633);

        LessA less;
        less = new LessA();
        less.Init();

        Range range;
        range = new Range();
        range.Init();
        range.Count = array.Count;

        Value ka;
        ka = new Value();
        ka.Init();
        ka.Int = 2632;

        long n;
        n = this.ListInfra.Find(array, ka, less, range);

        bool ba;
        ba = (n == 3);

        ka.Int = 8;

        n = this.ListInfra.Find(array, ka, less, range);

        bool bb;
        bb = (n == 0);

        ka.Int = 2633;

        n = this.ListInfra.Find(array, ka, less, range);

        bool bc;
        bc = (n == 4);

        bool b;
        b = ba & bb & bc;

        this.Console.Out.Write(this.AddClear().AddS("List Find ").Add(this.StatusString(b)).AddLine().AddResult());
        return true;
    }

    private object ListAddInt(List list, long n)
    {
        Value k;
        k = new Value();
        k.Init();
        k.Int = n;

        return list.Add(k);
    }

    private bool TableAddInt(Table table, long n)
    {
        Value k;
        k = new Value();
        k.Init();
        k.Int = n;

        this.ListInfra.TableAdd(table, k, k);
        return true;
    }

    private bool ArrayAddInt(Array array, long n)
    {
        Value k;
        k = new Value();
        k.Init();
        k.Int = n;

        array.SetAt(this.ArrayIndex, k);

        this.ArrayIndex = this.ArrayIndex + 1;

        return true;
    }

    private bool ArrayIntSame(Array array, long index, long value)
    {
        Value k;
        k = array.GetAt(index) as Value;

        return k.Int == value;
    }

    private bool ExecuteMath()
    {
        MathComp ca;
        ca = new MathComp();
        ca.Init();

        ca.Cand = 3;
        ca.Expo = 2;

        long aaaa;
        aaaa = this.Math.ValueTen(ca);
        this.ConsoleWriteMathValue("Demo.ExecuteMath ValueTen: ", aaaa);

        ca.Cand = 5;
        ca.Expo = -1;

        long aaab;
        aaab = this.Math.ValueTen(ca);
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
            .AddLine()
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

        this.ConsoleWriteRand(oa);

        oa = rand.Execute();

        this.ConsoleWriteRand(oa);

        rand.Final();
        return true;
    }

    private bool ConsoleWriteRand(long n)
    {
        String ka;

        ka = this.AddClear()
            .AddS("Demo Rand: 0h")
            .AddS(n.ToString("x15"))
            .AddLine()
            .AddResult();
        ;

        this.Console.Out.Write(ka);

        return true;
    }

    private bool ExecuteFormat()
    {
        FormatArg argA;
        argA = new FormatArg();
        argA.Init();
        argA.Pos = 3;
        argA.Kind = 0;
        argA.Value.Bool = true;
        argA.FieldWidth = 6;
        argA.MaxWidth = -1;
        argA.FillChar = ' ';
        argA.Form = this.TextInfra.AlphaNiteForm;

        FormatArg argB;
        argB = new FormatArg();
        argB.Init();
        argB.Pos = 3;
        argB.Kind = 1;
        argB.Value.Int = 56712;
        argB.AlignLeft = true;
        argB.FieldWidth = 8;
        argB.MaxWidth = 6;
        argB.Base = 10;
        argB.FillChar = ' ';

        FormatArg argC;
        argC = new FormatArg();
        argC.Init();
        argC.Pos = 6;
        argC.Kind = 1;
        argC.Value.Int = 46842;
        argC.AlignLeft = false;
        argC.FieldWidth = 8;
        argC.MaxWidth = 6;
        argC.Base = 10;
        argC.FillChar = ' ';

        FormatArg argD;
        argD = new FormatArg();
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

        FormatArg argDA;
        argDA = new FormatArg();
        argDA.Init();
        argDA.Pos = 7;
        argDA.Kind = 1;
        argDA.Value.Int = 100;
        argDA.AlignLeft = false;
        argDA.FieldWidth = 4;
        argDA.MaxWidth = -1;
        argDA.Base = 10;

        FormatArg argDB;
        argDB = new FormatArg();
        argDB.Init();
        argDB.Pos = 8;
        argDB.Kind = 1;
        argDB.Value.Int = 0;
        argDB.AlignLeft = false;
        argDB.FieldWidth = 3;
        argDB.MaxWidth = -1;
        argDB.Base = 10;
        argDB.FillChar = ':';

        FormatArg argE;
        argE = new FormatArg();
        argE.Init();
        argE.Pos = 10;
        argE.Kind = 2;
        argE.Value.Any = this.TextInfra.TextCreateStringData(this.S("F Hre a"), null);
        argE.AlignLeft = true;
        argE.FieldWidth = 11;
        argE.MaxWidth = 10;
        argE.FillChar = '=';
        argE.Form = this.TextInfra.AlphaNiteForm;

        FormatArg argF;
        argF = new FormatArg();
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

        Format write;
        write = new Format();
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
        ooa = a.Execute(ooo, 10, null);
        this.ConsoleWriteIntParse(ooa);

        ooo = this.TextInfra.TextCreateStringData(this.S("9E532F"), null);
        ooa = a.Execute(ooo, 16, this.TextInfra.AlphaSiteForm);
        this.ConsoleWriteIntParse(ooa);

        ooo = this.TextInfra.TextCreateStringData(this.S("0000000000009294ef0d"), null);
        ooa = a.Execute(ooo, 16, null);
        this.ConsoleWriteIntParse(ooa);

        ooo = this.TextInfra.TextCreateStringData(this.S("1000000000000000"), null);
        ooa = a.Execute(ooo, 16, this.TextInfra.AlphaSiteForm);
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

    private bool ExecuteMemoryStream()
    {
        Memory memory;
        memory = new Memory();
        memory.Init();

        memory.Open();

        Stream stream;
        stream = memory.Stream;

        String ka;
        ka = this.S("K o e f");

        Data data;
        data = this.TextInfra.StringDataCreateString(ka);

        Range range;
        range = new Range();
        range.Init();
        range.Count = data.Count;

        stream.Write(data, range);

        ka = this.S("* [ 19");

        data = this.TextInfra.StringDataCreateString(ka);

        range.Count = data.Count;

        stream.Write(data, range);

        data = new Data();
        data.Count = 10 * sizeof(uint);
        data.Init();

        range.Count = data.Count;

        stream.PosSet(3 * sizeof(uint));

        stream.Read(data, range);

        String kaa;
        kaa = this.StringComp.CreateData(data, null);

        StringLess less;
        less = this.TextInfra.StringLessCreate();

        String kb;
        kb = this.S(" e f* [ 19");

        long na;
        na = less.Execute(kaa, kb);

        bool ba;
        ba = (na == 0);
        
        this.Console.Out.Write(this.AddClear().AddS("Memory Stream read write ").Add(this.StatusString(ba)).AddLine().AddResult());

        memory.Close();

        memory.Final();

        return true;
    }

    private bool ExecuteTime()
    {
        Format write;
        write = new Format();
        write.Init();

        this.Format = write;

        FormatArg arg;
        arg = new FormatArg();
        arg.Init();
        arg.Kind = 1;
        arg.Base = 10;
        arg.MaxWidth = -1;
        arg.FieldWidth = 1;
        this.FormatArg = arg;

        Time time;
        time = new Time();
        time.Init();
        
        this.ConsoleWriteTime("Demo.ExecuteTime time init : ", time);
        
        time.This();
        this.ConsoleWriteTime("Demo.ExecuteTime time current : ", time);

        time.ToPos(2 * 60 * 60);
        this.ConsoleWriteTime("Demo.ExecuteTime time ToPos : ", time);

        time.AddTick(200 * 1000);
        this.ConsoleWriteTime("Demo.ExecuteTime time AddTick : ", time);

        time.Final();
        return true;
    }

    private bool ConsoleWriteTime(string prefix, Time time)
    {
        this.AddClear().AddS(prefix);

        this.AddS("yea: ").Add(this.StringInt(time.Yea))
            .AddS(", mon: ").Add(this.StringInt(time.Mon))
            .AddS(", day: ").Add(this.StringInt(time.Day))
            .AddS(", our: ").Add(this.StringInt(time.Our))
            .AddS(", min: ").Add(this.StringInt(time.Min))
            .AddS(", sec: ").Add(this.StringInt(time.Sec))
            .AddS(", tick: ").Add(this.StringInt(time.Tick))
            .AddS(", pos: ").Add(this.StringInt(time.Pos))
            .AddS(", total tick: ").Add(this.StringInt(time.TotalTick))
            .AddLine();

        String k;
        k = this.AddResult();

        this.Console.Out.Write(k);

        return true;
    }

    private bool ExecuteStorage()
    {
        StorageInfra infra;
        infra = StorageInfra.This;

        String ka;
        
        String k;
        k = infra.TextRead(this.S("DemoData/Demo.txt"));
        this.Console.Out.Write(this.AddClear().AddS("Demo.txt text: ").AddLine().Add(k).AddLine().AddResult());

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

    private bool ExecuteStorageStream()
    {
        Storage storage;
        storage = new Storage();
        storage.Init();

        StorageMode mode;
        mode = new StorageMode();
        mode.Init();
        mode.Read = true;
        mode.Write = true;

        storage.Path = this.S("DemoData/StorageStream.txt");
        storage.Mode = mode;

        storage.Open();

        Stream stream;
        stream = storage.Stream;

        String ka;
        ka = this.S("K o e f");

        Data data;
        data = this.TextInfra.StringDataCreateString(ka);

        Range range;
        range = new Range();
        range.Init();
        range.Count = data.Count;

        stream.Write(data, range);

        ka = this.S("* [ 19");

        data = this.TextInfra.StringDataCreateString(ka);

        range.Count = data.Count;

        stream.Write(data, range);

        data = new Data();
        data.Count = 10 * sizeof(uint);
        data.Init();

        range.Count = data.Count;

        stream.PosSet(3 * sizeof(uint));

        stream.Read(data, range);

        String kaa;
        kaa = this.StringComp.CreateData(data, null);

        StringLess less;
        less = this.TextInfra.StringLessCreate();

        String kb;
        kb = this.S(" e f* [ 19");

        long na;
        na = less.Execute(kaa, kb);

        bool ba;
        ba = (na == 0);

        this.Console.Out.Write(this.AddClear().AddS("Storage Stream read write ").Add(this.StatusString(ba)).AddLine().AddResult());

        storage.Close();

        storage.Final();

        return true;
    }

    private bool ExecuteStoragePath()
    {
        String kaa;
        kaa = this.S("Demo/FileA.txt");

        Text ka;
        ka = this.TextCreate(kaa);

        long n;
        n = this.StorageInfra.EntryPathNameCombine(ka, this.TLess);

        String k;
        k = this.StringCreateRange(kaa, 0, n);

        StringLess less;
        less = this.TextInfra.StringLessCreate();

        long nn;
        nn = less.Execute(k, this.S("Demo"));

        bool b;
        b = (nn == 0);

        this.Console.Out.Write(this.AddClear().AddS("Storage Path ").Add(this.StatusString(b)).AddLine().AddResult());

        return true;
    }

    private bool ExecuteStorageComp()
    {
        StorageComp storageComp;
        storageComp = this.StorageComp;

        String kaaaa;
        kaaaa = this.AddClear().AddS("Module Fold Path: ").Add(storageComp.ModuleFoldPath).AddLine().AddResult();

        this.Console.Out.Write(kaaaa);

        bool exist;
        exist = storageComp.Exist(this.S("DemoData/FoldA/FileA.txt"));

        this.Console.Out.Write(this.AddClear().AddS("File Exist ").Add(this.StatusString(exist)).AddLine().AddResult());

        exist = storageComp.Exist(this.S("DemoData/FoldA"));

        this.Console.Out.Write(this.AddClear().AddS("Fold Exist ").Add(this.StatusString(exist)).AddLine().AddResult());

        exist = storageComp.Exist(this.S("DemoData/Dummy"));

        this.Console.Out.Write(this.AddClear().AddS("Dummy Exist ").Add(this.StatusString(!exist)).AddLine().AddResult());


        bool isFold;
        isFold = storageComp.Fold(this.S("DemoData/FoldA/FileA.txt"));

        this.Console.Out.Write(this.AddClear().AddS("File Is Fold ").Add(this.StatusString(!isFold)).AddLine().AddResult());

        isFold = storageComp.Fold(this.S("DemoData/FoldA"));

        this.Console.Out.Write(this.AddClear().AddS("Fold Is Fold ").Add(this.StatusString(isFold)).AddLine().AddResult());

        isFold = storageComp.Fold(this.S("DemoData/Dummy"));

        this.Console.Out.Write(this.AddClear().AddS("Dummy Is Fold ").Add(this.StatusString(!isFold)).AddLine().AddResult());

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

        this.Console.Out.Write(this.AddClear().AddS("File Rename ").Add(this.StatusString(b)).AddLine().AddResult());

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

        this.Console.Out.Write(this.AddClear().AddS("Fold Rename ").Add(this.StatusString(b)).AddLine().AddResult());

        string path;
        path = "DemoData/DemoCopy.txt";
        string destPath;
        destPath = "DemoData/DemoCopy_Copy.txt";
        File.Delete(destPath);

        b = storageComp.FileCopy(this.S(path), this.S(destPath));

        this.Console.Out.Write(this.AddClear().AddS("File Copy ").Add(this.StatusString(b)).AddLine().AddResult());

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

        this.Console.Out.Write(this.AddClear().AddS("File Delete ").Add(this.StatusString(b)).AddLine().AddResult());


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

        this.Console.Out.Write(this.AddClear().AddS("Fold Create ").Add(this.StatusString(b)).AddLine().AddResult());

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

        this.Console.Out.Write(this.AddClear().AddS("Fold Copy ").Add(this.StatusString(b)).AddLine().AddResult());

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

        this.Console.Out.Write(this.AddClear().AddS("Fold Delete ").Add(this.StatusString(b)).AddLine().AddResult());

        String foldListPath;
        foldListPath = this.S("DemoData/FoldCopy/FoldA");

        Array foldList;
        foldList = storageComp.EntryList(foldListPath, true);

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
        fileList = storageComp.EntryList(fileListPath, false);

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

    private String StatusString(bool b)
    {
        String k;
        k = this.SSuccess;
        if (!b)
        {
            k = this.SError;
        }
        return k;
    }

    private String BoolString(bool b)
    {
        String k;
        k = this.TextInfra.BoolFalseString;

        if (b)
        {
            k = this.TextInfra.BoolTrueString;
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

    private bool ExecuteNetworkProgram()
    {
        this.Console.Out.Write(this.S("Network Program Start\n"));

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

        this.Console.Out.Write(this.S("Network Program End\n"));
        return true;
    }

    private bool ExecuteDemoThread()
    {
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

        this.Console.Out.Write(this.S("Demo.ExecuteDemoThread phore Open Success\n"));

        thread.Wait();

        long aa;
        aa = thread.Status;
        this.Console.Out.Write(this.S("Demo.ExecuteDemoThread Thread Status: 0h" + aa.ToString("x8") + "\n"));

        thread.Final();

        phore.Final();
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

    public virtual long MathInt(long n)
    {
        MathInfra mathInfra;
        mathInfra = this.MathInfra;

        MathComp mathComp;
        mathComp = this.MathComp;

        long a;
        a = mathInfra.Int(mathComp, n);
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