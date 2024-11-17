class DeA : Dem
{
    maide prusate Bool Init()
    {
        base.Init();
        this.TextInfra : share TextInfra;
        this.StorageInfra : share StorageInfra;
        this.StringComp : share StringComp;
        this.Console : share Console;

        this.Format : this.CreateFormat();
        this.FormatArg : this.CreateFormatArg();
        this.IntParse : this.CreateIntParse();
        this.StringAdd : this.CreateStringAdd();
        return true;
    }

    field precate TextInfra TextInfra { get { return data; } set { data : value; } }
    field precate StorageInfra StorageInfra { get { return data; } set { data : value; } }
    field precate StringComp StringComp { get { return data; } set { data : value; } }
    field precate Console Console { get { return data; } set { data : value; } }
    field private Format Format { get { return data; } set { data : value; } }
    field private FormatArg FormatArg { get { return data; } set { data : value; } }
    field private IntParse IntParse { get { return data; } set { data : value; } }
    field private StringAdd StringAdd { get { return data; } set { data : value; } }

    maide precate Format CreateFormat()
    {
        var Format a;
        a : new Format;
        a.Init();
        return a;
    }

    maide precate FormatArg CreateFormatArg()
    {
        var FormatArg a;
        a : new FormatArg;
        a.Init();
        return a;
    }

    maide precate IntParse CreateIntParse()
    {
        var IntParse a;
        a : new IntParse;
        a.Init();
        return a;
    }

    maide precate StringAdd CreateStringAdd()
    {
        var StringAdd a;
        a : new StringAdd;
        a.Init();
        return a;
    }


    maide prusate Bool Execute()
    {
        base.Execute();

        this.Console.Out.Write("Demo ABCD AAAA BBBB\n");

        var String k;
        #k : console.Inn.Read();
        k : "kkk";

        var String a;
        
        a : this.AddClear().Add("k: ").AddLine()
            .Add(k)
            .AddLine().AddResult();

        this.Console.Out.Write(a);

        #console.Inn.Read();

        #var Data ka;
        #ka : new Data;
        #ka.Count : 10 * 1024 * 1024;
        #ka.Init();

        #console.Inn.Read();

        this.Console.Out.Write("Demo HHHH\n");

        var Text text;
        text : this.TextInfra.TextCreateStringData("fffffffffffffff", null);

        var Int nn;
        nn : this.TextInfra.Char("9");

        var Int kkk;
        kkk : this.TextInfra.DigitValue(nn, 10);

        inf (kkk = 9)
        {
            this.Console.Out.Write("Demo DigitValue 1111\n");
        }

        var Int na;
        na : this.IntParse.Execute(text, 16, null);

        inf (na = 0hfffffffffffffff)
        {
            this.Console.Out.Write("Demo IntParse 1111\n");
        }

        text : this.TextCreate("ffffffffffffffff");

        na : this.IntParse.Execute(text, 16, null);

        inf (na = null)
        {
            this.Console.Out.Write("Demo IntParse 2222\n");
        }

        text : this.TextCreate("0000000000000000");

        na : this.IntParse.Execute(text, 16, null);

        inf (na = null)
        {
            this.Console.Out.Write("Demo IntParse 3333\n");
        }

        text : this.TextCreate("1000000000000000");

        na : this.IntParse.Execute(text, 16, null);

        inf (na = null)
        {
            this.Console.Out.Write("Demo IntParse 4444\n");
        }

        text : this.TextCreate("000000000000000");

        na : this.IntParse.Execute(text, 16, null);

        inf (na = 0)
        {
            this.Console.Out.Write("Demo IntParse 5555\n");
        }

        text : this.TextCreate("800000000000000");

        na : this.IntParse.Execute(text, 16, null);

        inf (na = 0h800000000000000)
        {
            this.Console.Out.Write("Demo IntParse 6666\n");
        }

        this.Console.Out.Write("Demo Text 1111\n");

        text : this.TextCreate("h j\n");

        this.Console.Out.Write("Demo Text 2222\n");

        k : this.StringCreate(text);

        this.Console.Out.Write("Demo Text 3333\n");

        this.Console.Out.Write(k);

        this.Console.Out.Write("Demo Text 4444\n");

        k : this.StringBoolFormat(true, true, 8, 8, this.Char("="));

        this.Console.Out.Write("Demo Text 5555\n");

        this.Console.Out.Write(k);

        this.Console.Out.Write("Demo Text 6666\n");

        k : this.StringTextFormat(text, false, 6, 6, this.Char("#"));

        this.Console.Out.Write("Demo Text 7777\n");

        this.Console.Out.Write(k);

        this.Console.Out.Write("Demo Text 8888\n");

        k : this.StringIntFormat(0h1e4fd8, 16, true, 10, null, this.Char("="));

        this.Console.Out.Write("Demo Text 9999\n");

        this.Console.Out.Write(this.AddClear().Add(k).AddLine().AddResult());

        this.Console.Out.Write(this.AddClear().Add(this.StringInt(89542)).AddLine().AddResult());

        this.Console.Out.Write("Demo Storage 1111\n");

        k : this.StorageInfra.TextRead("../../DemoA.txt");

        this.Console.Out.Write("Demo Storage 2222\n");

        this.Console.Out.Write(k);

        var Phore phore;
        phore : new Phore;
        phore.Init();

        var ThreadState threadState;
        threadState : new ThreadState;
        threadState.Init();

        var Thread thread;
        thread : new Thread;
        thread.Init();

        threadState.Phore : phore;

        thread.ExecuteState : threadState;

        thread.Execute();

        phore.Open();

        this.Console.Out.Write("Demo Phore Open After 1111\n");

        thread.Wait();

        this.Console.Out.Write(this.AddClear().Add("Thread Status: ").Add(this.StringInt(thread.Status)).AddLine().AddResult());

        thread.Final();

        phore.Final();

        this.ExecuteNetwork();

        this.ExecuteNetworkProgram();

        this.Console.Out.Write("Demo Execute End\n");

        return true;
    }

    maide private Bool ExecuteNetwork()
    {
        this.Console.Out.Write("Network Start\n");

        var Thread hostThread;
        hostThread : new Thread;
        hostThread.Init();

        var ThreadNetworkHostState hostState;
        hostState : new ThreadNetworkHostState;
        hostState.Init();

        hostThread.ExecuteState : hostState;

        hostThread.Execute();

        var Thread networkThread;
        networkThread : new Thread;
        networkThread.Init();

        var ThreadNetworkState networkState;
        networkState : new ThreadNetworkState;
        networkState.Init();

        networkThread.ExecuteState : networkState;

        networkThread.Execute();

        networkThread.Wait();

        hostThread.Wait();

        networkThread.Final();

        hostThread.Final();

        this.Console.Out.Write("Network End\n");

        return true;
    }

    maide private Bool ExecuteNetworkProgram()
    {
        this.Console.Out.Write("Network Program Start\n");

        var Thread hostThread;
        hostThread : new Thread;
        hostThread.Init();

        var ThreadNetworkHostState hostState;
        hostState : new ThreadNetworkHostState;
        hostState.Init();

        hostThread.ExecuteState : hostState;

        hostThread.Execute();

        var List list;
        list : new List;
        list.Init();
        list.Add("SystemDemoNetwork-0.00.00");

        var Program program;
        program : new Program;
        program.Init();
        program.Name : "class.exe";
        program.Argue : list;
        program.WorkFold : null;
        program.Environ : null;

        program.Execute();

        program.Wait();

        hostThread.Wait();

        networkThread.Final();

        hostThread.Final();

        this.Console.Out.Write("Network Program End\n");

        return true;
    }

    maide prusate String StringInt(var Int int)
    {
        return this.StringIntFormat(int, 10, false, 0, null, 0);
    }

    maide prusate String StringBoolFormat(var Bool bool, var Bool alignLeft, var Int fieldWidth, var Int maxWidth, var Int fillChar)
    {
        var FormatArg arg;
        arg : this.FormatArg;

        arg.Kind : 0;
        arg.Value : bool;
        arg.Base : 0;
        arg.AlignLeft : alignLeft;
        arg.FieldWidth : fieldWidth;
        arg.MaxWidth : maxWidth;
        arg.FillChar : fillChar;
        arg.Form : null;

        return this.StringFormat();
    }

    maide prusate String StringIntFormat(var Int int, var Int varBase, var Bool alignLeft, var Int fieldWidth, var Int maxWidth, var Int fillChar)
    {
        var FormatArg arg;
        arg : this.FormatArg;

        arg.Kind : 1;
        arg.Value : int;
        arg.Base : varBase;
        arg.AlignLeft : alignLeft;
        arg.FieldWidth : fieldWidth;
        arg.MaxWidth : maxWidth;
        arg.FillChar : fillChar;
        arg.Form : null;

        return this.StringFormat();
    }

    maide prusate String StringTextFormat(var Text text, var Bool alignLeft, var Int fieldWidth, var Int maxWidth, var Int fillChar)
    {
        var FormatArg arg;
        arg : this.FormatArg;

        arg.Kind : 2;
        arg.Value : text;
        arg.Base : 0;
        arg.AlignLeft : alignLeft;
        arg.FieldWidth : fieldWidth;
        arg.MaxWidth : maxWidth;
        arg.FillChar : fillChar;
        arg.Form : null;

        return this.StringFormat();
    }

    maide prusate String StringFormat()
    {
        var Bool b;

        b : this.Format.ExecuteArgCount(this.FormatArg);

        inf (~b)
        {
            return null;
        }

        var Text k;
        k : this.TextInfra.TextCreate(this.FormatArg.Count);

        b : this.Format.ExecuteArgResult(this.FormatArg, k);

        inf (~b)
        {
            return null;
        }

        var String a;
        a : this.StringCreate(k);

        return a;
    }

    maide prusate String StringCreate(var Text text)
    {
        return this.TextInfra.StringCreate(text);
    }

    maide prusate Int Char(var String k)
    {
        return this.TextInfra.Char(k);
    }

    maide prusate Text TextCreate(var String k)
    {
        return this.TextInfra.TextCreateStringData(k, null);
    }

    maide prusate DeA AddClear()
    {
        this.StringAdd.Clear();
        return this;
    }

    maide prusate String AddResult()
    {
        return this.StringAdd.Result();
    }

    maide prusate DeA Add(var String k)
    {
        this.TextInfra.AddString(this.StringAdd, k);
        return this;
    }

    maide prusate DeA AddLine()
    {
        return this.Add("\n");
    }
}