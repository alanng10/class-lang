class DeA : Dem
{
    maide prusate Bool Init()
    {
        base.Init();
        this.TextInfra : share TextInfra;
        this.StorageInfra : share StorageInfra;
        this.StringComp : share StringComp;
        this.StorageComp : share StorageComp;
        this.Console : share Console;

        this.Format : this.CreateFormat();
        this.FormatArg : this.CreateFormatArg();
        this.IntParse : this.CreateIntParse();
        this.StringAdd : this.CreateStringAdd();

        this.CharLess : this.CreateCharLess();
        this.TForm : this.CreateTextForm();
        this.TLess : this.CreateTextLess();

        this.TextA : this.CreateText();
        this.TextB : this.CreateText();
        this.StringDataA : this.CreateStringData();
        this.StringDataB : this.CreateStringData();
        return true;
    }

    field precate TextInfra TextInfra { get { return data; } set { data : value; } }
    field precate StorageInfra StorageInfra { get { return data; } set { data : value; } }
    field precate StringComp StringComp { get { return data; } set { data : value; } }
    field precate StorageComp StorageComp { get { return data; } set { data : value; } }
    field precate Console Console { get { return data; } set { data : value; } }
    field precate Format Format { get { return data; } set { data : value; } }
    field precate FormatArg FormatArg { get { return data; } set { data : value; } }
    field precate IntParse IntParse { get { return data; } set { data : value; } }
    field precate StringAdd StringAdd { get { return data; } set { data : value; } }
    field precate TextLess TLess { get { return data; } set { data : value; } }
    field precate IntLess CharLess { get { return data; } set { data : value; } }
    field precate TextForm TForm { get { return data; } set { data : value; } }
    field precate Text TextA { get { return data; } set { data : value; } }
    field precate Text TextB { get { return data; } set { data : value; } }
    field precate StringData StringDataA { get { return data; } set { data : value; } }
    field precate StringData StringDataB { get { return data; } set { data : value; } }
    field precate Int Aa { get { base.Aa; share Console.Out.Write("DeA Field Get\n"); } set { base.Aa : null; share Console.Out.Write("DeA Field Set\n"); } }
    field precate String Ake { get { return data; } set { base.Ake : value; } }
    field private Int Aaa { get { return data; } set { } }

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

    maide precate IntLess CreateCharLess()
    {
        var IntLess a;
        a : new IntLess;
        a.Init();
        return a;
    }

    maide precate TextForm CreateTextForm()
    {
        var TextForm a;
        a : new TextForm;
        a.Init();
        return a;
    }

    maide precate TextLess CreateTextLess()
    {
        var TextLess a;
        a : new TextLess;
        a.CharLess : this.CharLess;
        a.LiteForm : this.TForm;
        a.RiteForm : this.TForm;
        a.Init();
        return a;
    }

    maide precate Text CreateText()
    {
        var Text a;
        a : new Text;
        a.Init();
        a.Range : new Range;
        a.Range.Init();
        return a;
    }

    maide precate StringData CreateStringData()
    {
        var StringData a;
        a : new StringData;
        a.Init();
        return a;
    }

    maide prusate Bool Execute()
    {
        base.Execute();

        this.Console.Out.Write("Demo ABCD AAAA BBBB\n");

        this.Aa;
        this.Aa : null;

        var Bool baaa;
        baaa : (this.Aaa = null);
        this.Console.Out.Write(this.AddClear().Add("Demo Field Data Default ").Add(this.StatusString(baaa)).AddLine().AddResult());

        this.Ake : "Ke ad";

        var String kkk;
        kkk : this.Ake;

        this.Console.Out.Write(this.AddClear().Add("Demo Base Field Data: ").Add(kkk).AddLine().AddResult());

        var Int count;
        count : 3;
        var Int i;
        i : 0;
        while (i < count)
        {
            var Int nak;
            
            inf (nak = null)
            {
                this.Console.Out.Write("Demo While Local Var 1111\n");
            }
            nak : 2;

            i : i + 1;
        }


        var String k;
        #k : console.Inn.Read();
        k : "k l o";

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

        #this.Console.Out.Write("Demo HHHH\n");

        this.ExecuteValueCast();

        var Text text;
        text : this.TextCreate("h j\n");

        k : this.StringCreate(text);

        this.Console.Out.Write(k);

        this.ExecuteTextIntParse();

        this.ExecuteFormat();

        this.ExecuteMemoryStream();

        this.ExecuteTime();

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

        this.ExecuteStorage();

        this.ExecuteStorageStream();

        this.ExecuteNetwork();

        this.ExecuteNetworkProgram();

        this.Console.Out.Write("Demo Execute End\n");

        return true;
    }

    maide private Bool ExecuteValueCast()
    {
        var Any k;
        k : true;

        var Bool ba;
        ba : cast Bool(k);

        inf (ba)
        {
            this.Console.Out.Write("Demo Value Cast 1111\n");
        }

        k : 1;

        ba : cast Bool(k);

        inf (ba = null)
        {
            this.Console.Out.Write("Demo Value Cast 2222\n");
        }

        k : 7392641;

        var Int na;
        na : cast Int(k);

        inf (na = 7392641)
        {
            this.Console.Out.Write("Demo Value Cast 3333\n");
        }

        k : true;

        na : cast Int(k);

        inf (na = null)
        {
            this.Console.Out.Write("Demo Value Cast 4444\n");
        }

        k : "LKs s9 &";

        var String ka;
        ka : cast String(k);

        inf (this.TextSame(this.TA(ka), this.TB("LKs s9 &")))
        {
            this.Console.Out.Write("Demo Value Cast 5555\n");
        }

        k : 3492;

        ka : cast String(k);

        inf (ka = null)
        {
            this.Console.Out.Write("Demo Value Cast 6666\n");
        }

        return true;
    }

    maide private Bool ExecuteList()
    {
        this.ExecuteListList();
        this.ExecuteListTable();
        return true;
    }

    maide private Bool ExecuteListList()
    {
        var List list;
        list : new List;
        list.Init();

        var Any indexA;
        var Any indexB;
        this.ListAddInt(list, 983501);
        indexA : this.ListAddInt(list, 6728);
        indexB : this.ListAddInt(list, 8197);

        var Array array;
        array : this.ListInfra.ArrayCreateList(list);

        var Bool b;
        b : (array.Count = 3);
        b : b & this.ArrayIntSame(array, 0, 983501);
        b : b & this.ArrayIntSame(array, 1, 6728);
        b : b & this.ArrayIntSame(array, 2, 8197);

        this.Console.Out.Write(this.AddClear().AddS("List Add ").Add(this.StatusString(b)).AddLine().AddResult());

        list.Rem(indexA);

        array : this.ListInfra.ArrayCreateList(list);

        b : (array.Count = 2);
        b : b & this.ArrayIntSame(array, 0, 983501);
        b : b & this.ArrayIntSame(array, 1, 8197);

        this.Console.Out.Write(this.AddClear().AddS("List Rem ").Add(this.StatusString(b)).AddLine().AddResult());

        var Int ka;
        ka : 792461;

        list.Ins(indexB, ka);

        array : this.ListInfra.ArrayCreateList(list);

        b : (array.Count = 3);
        b : b & this.ArrayIntSame(array, 0, 983501);
        b : b & this.ArrayIntSame(array, 1, 792461);
        b : b & this.ArrayIntSame(array, 2, 8197);

        this.Console.Out.Write(this.AddClear().AddS("List Ins ").Add(this.StatusString(b)).AddLine().AddResult());

        return true;
    }

    maide private Bool ExecuteListTable()
    {
        var RefLess less;
        less : new RefLess;
        less.Init();

        var Table table;
        table : new Table;
        table.Less : less;
        table.Init();

        this.TableAddInt(table, 983501);
        this.TableAddInt(table, 6728);
        this.TableAddInt(table, 8197);

        var Array array;
        array : this.ListInfra.ArrayCreateList(table);

        var Bool b;
        b : (array.Count = 3);
        b : b & this.ArrayIntSame(array, 0, 983501);
        b : b & this.ArrayIntSame(array, 1, 6728);
        b : b & this.ArrayIntSame(array, 2, 8197);

        this.Console.Out.Write(this.AddClear().AddS("Table Add ").Add(this.StatusString(b)).AddLine().AddResult());

        var Any kk;
        kk : array.Get(1);

        table.Rem(kk);

        array : this.ListInfra.ArrayCreateList(table);

        b : (array.Count = 2);
        b : b & this.ArrayIntSame(array, 0, 983501);
        b : b & this.ArrayIntSame(array, 1, 8197);

        this.Console.Out.Write(this.AddClear().AddS("Table Rem ").Add(this.StatusString(b)).AddLine().AddResult());

        kk : array.Get(1);

        var Int ka;
        ka : 792461;

        var ListEntry kaa;
        kaa : new ListEntry;
        kaa.Init();
        kaa.Index : ka;
        kaa.Value : ka;

        table.Ins(kk, kaa);

        array : this.ListInfra.ArrayCreateList(table);

        b : (array.Count = 3);
        b : b & this.ArrayIntSame(array, 0, 983501);
        b : b & this.ArrayIntSame(array, 1, 792461);
        b : b & this.ArrayIntSame(array, 2, 8197);

        this.Console.Out.Write(this.AddClear().AddS("Table Ins ").Add(this.StatusString(b)).AddLine().AddResult());

        return true;
    }

    maide private Any ListAddInt(var List list, var Int n)
    {
        return list.Add(n);
    }

    maide private bool TableAddInt(var Table table, var Int n)
    {
        this.ListInfra.TableAdd(table, n, n);
        return true;
    }

    maide private Bool ArrayIntSame(var Array array, var Int index, var Int value)
    {
        var Int k;
        k : cast Int(array.Get(index));

        return k = value;
    }

    maide private Bool ExecuteTextIntParse()
    {
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

        return true;
    }
    
    maide private Bool ExecuteFormat()
    {
        var Text text;
        text : this.TextCreate("L o(");

        var String k;
        k : this.StringBoolFormat(true, true, 8, 8, this.Char("="));

        this.Console.Out.Write(this.AddClear().Add(k).AddLine().AddResult());

        k : this.StringTextFormat(text, true, 6, 6, this.Char("#"));

        this.Console.Out.Write(this.AddClear().Add(k).AddLine().AddResult());

        k : this.StringIntFormat(0h1e4fd8, 16, true, 10, null, this.Char("="));

        this.Console.Out.Write(this.AddClear().Add(k).AddLine().AddResult());

        this.Console.Out.Write(this.AddClear().Add(this.StringInt(89542)).AddLine().AddResult());

        return true;
    }

    maide private Bool ExecuteMemoryStream()
    {
        var Memory memory;
        memory : new Memory;
        memory.Init();

        memory.Open();

        var Stream stream;
        stream : memory.Stream;

        var String ka;
        ka : "K o e f";

        var Data data;
        data : this.TextInfra.StringDataCreateString(ka);

        var Range range;
        range : new Range;
        range.Init();
        range.Index : 0;
        range.Count : data.Count;

        stream.Write(data, range);

        ka : "* [ 19";

        data : this.TextInfra.StringDataCreateString(ka);

        range.Count : data.Count;

        stream.Write(data, range);

        data : new Data;
        data.Count : 10 * 4;
        data.Init();

        range.Count : data.Count;

        stream.PosSet(3 * 4);

        stream.Read(data, range);

        var String kaa;
        kaa: this.StringComp.CreateData(data, null);

        var String kb;
        kb : " e f* [ 19";

        var Bool b;
        b : this.TextSame(this.TA(kaa), this.TB(kb));

        this.Console.Out.Write(this.AddClear().Add("Memory Stream read write ").Add(this.StatusString(b)).AddLine().AddResult());

        memory.Close();

        memory.Final();

        return true;
    }

    maide private Bool ExecuteTime()
    {
        var Time time;
        time : new Time;
        time.Init();
        
        this.ConsoleWriteTime("Demo time init : ", time);
        
        time.This();
        this.ConsoleWriteTime("Demo time current : ", time);

        time.ToPos(2 * 60 * 60);
        this.ConsoleWriteTime("Demo time ToPos : ", time);

        time.AddTick(200 * 1000);
        this.ConsoleWriteTime("Demo time AddTick : ", time);

        time.Final();
        return true;
    }

    maide private Bool ConsoleWriteTime(var String prefix, var Time time)
    {
        this.AddClear().Add(prefix);

        this.Add("yea: ").Add(this.StringInt(time.Yea))
            .Add(", mon: ").Add(this.StringInt(time.Mon))
            .Add(", day: ").Add(this.StringInt(time.Day))
            .Add(", our: ").Add(this.StringInt(time.Our))
            .Add(", min: ").Add(this.StringInt(time.Min))
            .Add(", sec: ").Add(this.StringInt(time.Sec))
            .Add(", tick: ").Add(this.StringInt(time.Tick))
            .Add(", pos: ").Add(this.StringInt(time.Pos))
            .Add(", total tick: ").Add(this.StringIntFormat(time.TotalTick, 10, false, 0, null, this.Char("0")))
            .AddLine();

        var String k;
        k : this.AddResult();

        this.Console.Out.Write(k);

        return true;
    }

    maide private Bool ExecuteStorage()
    {
        var String k;
        k : this.StorageInfra.TextRead("../../DemoA.txt");

        this.Console.Out.Write(this.AddClear().Add("Storage Read: ").Add(k).AddLine().AddResult());

        this.StorageComp.ThisFoldSet("..");

        var String ka;
        ka : this.StorageInfra.TextRead("../DemoA.txt");

        var Bool b;
        b : (this.TextSame(this.TA(ka), this.TB(k)));
        
        var String kaa;
        inf (b)
        {
            kaa : "Success";
        }
        inf (~b)
        {
            kaa : "Error";
        }
        this.Console.Out.Write(this.AddClear().Add("StorageComp ThisFold Set Read ").Add(kaa).AddLine().AddResult());

        this.StorageComp.ThisFoldSet("Class");
        return true;
    }

    maide private Bool ExecuteStorageStream()
    {
        var Storage storage;
        storage : new Storage;
        storage.Init();

        var StorageMode mode;
        mode : new StorageMode;
        mode.Init();
        mode.Read : true;
        mode.Write : true;

        storage.Path : "StorageStream.txt";
        storage.Mode : mode;

        storage.Open();

        var Stream stream;
        stream : storage.Stream;

        var String ka;
        ka : "K o e f";

        var Data data;
        data : this.TextInfra.StringDataCreateString(ka);

        var Range range;
        range : new Range;
        range.Init();
        range.Index : 0;
        range.Count : data.Count;

        stream.Write(data, range);

        ka : "* [ 19";

        data : this.TextInfra.StringDataCreateString(ka);

        range.Count : data.Count;

        stream.Write(data, range);

        data : new Data;
        data.Count : 10 * 4;
        data.Init();

        range.Count : data.Count;

        stream.PosSet(3 * 4);

        stream.Read(data, range);

        var String kaa;
        kaa: this.StringComp.CreateData(data, null);

        var String kb;
        kb : " e f* [ 19";

        var Bool b;
        b : this.TextSame(this.TA(kaa), this.TB(kb));

        this.Console.Out.Write(this.AddClear().Add("Storage Stream read write ").Add(this.StatusString(b)).AddLine().AddResult());

        storage.Close();

        storage.Final();

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

        program.Final();

        hostThread.Final();

        this.Console.Out.Write("Network Program End\n");

        return true;
    }

    maide private String StatusString(var Bool b)
    {
        var String k;
        k : "Success";
        inf (~b)
        {
            k : "Error";
        }
        return k;
    }

    maide prusate Text TA(var String k)
    {
        return this.TextString(k, this.TextA, this.StringDataA);
    }

    maide prusate Text TB(var String k)
    {
        return this.TextString(k, this.TextB, this.StringDataB);
    }

    maide prusate Text TextString(var String k, var Text text, var StringData data)
    {
        data.ValueString : k;

        text.Data : data;
        text.Range.Index : 0;
        text.Range.Count : this.StringCount(k);
        return text;
    }

    maide prusate Bool TextSame(var Text text, var Text other)
    {
        return this.TextInfra.Same(text, other, this.TLess);
    }

    maide prusate Int StringCount(var String k)
    {
        return this.StringComp.Count(k);
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