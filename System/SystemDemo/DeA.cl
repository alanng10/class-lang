class DeA : Dem
{
    maide prusate Bool Init()
    {
        base.Init();
        this.ListInfra : share ListInfra;
        this.TextInfra : share TextInfra;
        this.Math : share Math;
        this.StorageInfra : share StorageInfra;
        this.StringComp : share StringComp;
        this.StorageComp : share StorageComp;
        this.Console : share Console;

        this.MathComp : new MathComp;
        this.MathComp.Init();

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

    field precate ListInfra ListInfra { get { return data; } set { data : value; } }
    field precate TextInfra TextInfra { get { return data; } set { data : value; } }
    field prusate Math Math { get { return data; } set { data : value; } }
    field precate StorageInfra StorageInfra { get { return data; } set { data : value; } }
    field precate StringComp StringComp { get { return data; } set { data : value; } }
    field precate StorageComp StorageComp { get { return data; } set { data : value; } }
    field prusate Console Console { get { return data; } set { data : value; } }
    field precate MathComp MathComp { get { return data; } set { data : value; } }
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
    field precate Int ArrayIndex { get { return data; } set { data : value; } }
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

        var Demo demo;
        demo : new Demo;
        demo.Init();
        demo.ExecuteA();

        this.Aa;
        this.Aa : null;

        var Bool baaa;
        baaa : (this.Aaa = null);
        this.Console.Out.Write(this.AddClear().Add("Demo Field Data Default ").Add(this.StatusString(baaa)).AddLine().AddResult());

        var String kaaa;
        kaaa : "Ke ad";

        this.Ake : kaaa;

        var String kkk;
        kkk : this.Ake;

        var Bool baab;
        baab : kkk = kaaa;

        this.Console.Out.Write(this.AddClear().Add("Demo Base Field Data ").Add(this.StatusString(baab)).AddLine().AddResult());

        var Bool ba;
        ba : true;

        var Int count;
        count : 3;
        var Int i;
        i : 0;
        while (i < count)
        {
            var Int nak;
            
            ba : ba & (nak = null);

            nak : 2;

            i : i + 1;
        }

        this.Console.Out.Write(this.AddClear().Add("Demo While Loop Local Var ").Add(this.StatusString(ba)).AddLine().AddResult());


        var String k;
        #k : console.Inn.Read();
        k : "k l o";

        var String a;
        
        a : this.AddClear().Add("k: ").AddLine()
            .Add(k)
            .AddLine().AddResult();

        this.Console.Out.Write(a);

        this.ExecuteValueCast();

        this.ExecuteCast();

        this.ExecuteIntOperate();

        this.ExecuteList();
        
        var Text text;
        text : this.TextCreate("h j\n");

        k : this.StringCreate(text);

        this.Console.Out.Write(k);

        this.ExecuteTextIntParse();

        this.ExecuteFormat();

        this.ExecuteMath();

        this.ExecuteRand();

        this.ExecuteThread();

        this.ExecuteMemoryStream();

        this.ExecuteTime();

        this.ExecuteStorage();

        this.ExecuteStorageStream();

        this.ExecuteNetwork();

        this.ExecuteNetworkProgram();

        this.Console.Inn.Read();

        var Data ka;
        ka : new Data;
        ka.Count : 10 * 1024 * 1024;
        ka.Init();

        this.Console.Inn.Read();

        this.Console.Out.Write("Demo HHHH\n");

        this.Console.Out.Write("Demo Execute End\n");

        return true;
    }

    maide private Bool ExecuteValueCast()
    {
        var Bool b;
        b : true;

        var Any k;
        k : true;

        var Bool ba;
        ba : cast Bool(k);

        b : b & ba;

        k : 1;

        ba : cast Bool(k);

        b : b & (ba = null);

        k : 7392641;

        var Int na;
        na : cast Int(k);

        b : b & (na = 7392641);

        k : true;

        na : cast Int(k);

        b : b & (na = null);

        k : "LKs s9 &";

        var String ka;
        ka : cast String(k);

        b : b & this.TextSame(this.TA(ka), this.TB("LKs s9 &"));

        k : 3492;

        ka : cast String(k);

        b : b & (ka = null);
        
        this.Console.Out.Write(this.AddClear().Add("Demo Value Cast ").Add(this.StatusString(b)).AddLine().AddResult());

        return true;
    }

    maide private Bool ExecuteCast()
    {
        var DeA ka;
        ka : new DeA;
        
        var Any kk;
        kk : ka;

        var Bool b;
        b : true;

        var Text kaa;
        kaa : cast Text(kk);

        b : b & (kaa = null);

        var DeA kab;
        kab : cast DeA(kk);

        b : b & (kab = ka);

        var Dem kac;
        kac : cast Dem(kk);

        b : b & (kac = ka);

        this.Console.Out.Write(this.AddClear().Add("Demo Cast ").Add(this.StatusString(b)).AddLine().AddResult());

        return true;
    }

    maide private Bool ExecuteIntOperate()
    {
        var Bool b;
        b : true;

        var Int ka;
        ka : 1 / 0;

        b : b & (ka = 0);

        ka : 0 / 0;

        b : b & (ka = 0);

        var Bool ba;
        ba : sign <(0sn11, 0sn10); 

        b : b & ba;

        ka : sign *(0sn4, 0sn6);

        b : b & (ka = 24);

        ka : sign *(0sn9, 3);

        b : b & (ka = 0sn27);

        ka : sign /(0sn1, 0);

        b : b & (ka = 0);

        ka : sign /(0, 0);

        b : b & (ka = 0);

        ka : bit ~(0haf);

        b : b & (ka = 0hfffffffffffff50);

        ka : bit &(0ha0, 0h7f);

        b : b & (ka = 0h20);

        ka : bit |(0ha0, 0h40f);

        b : b & (ka = 0h4af);

        ka : bit <(3, 2);

        b : b & (ka = 12);

        ka : bit >(8, 2);

        b : b & (ka = 2);

        ka : bit >>(0h800000000000070, 4);

        b : b & (ka = 0hf80000000000007);

        ka : bit >>(0h700000000000070, 4);

        b : b & (ka = 0h070000000000007);

        this.Console.Out.Write(this.AddClear().Add("Demo Int Operate ").Add(this.StatusString(b)).AddLine().AddResult());

        return true;
    }

    maide private Bool ExecuteList()
    {
        this.ExecuteListList();
        this.ExecuteListTable();
        this.ExecuteListSort();
        this.ExecuteListFind();
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

        this.Console.Out.Write(this.AddClear().Add("List Add ").Add(this.StatusString(b)).AddLine().AddResult());

        list.Rem(indexA);

        array : this.ListInfra.ArrayCreateList(list);

        b : (array.Count = 2);
        b : b & this.ArrayIntSame(array, 0, 983501);
        b : b & this.ArrayIntSame(array, 1, 8197);

        this.Console.Out.Write(this.AddClear().Add("List Rem ").Add(this.StatusString(b)).AddLine().AddResult());

        var Int ka;
        ka : 792461;

        list.Ins(indexB, ka);

        array : this.ListInfra.ArrayCreateList(list);

        b : (array.Count = 3);
        b : b & this.ArrayIntSame(array, 0, 983501);
        b : b & this.ArrayIntSame(array, 1, 792461);
        b : b & this.ArrayIntSame(array, 2, 8197);

        this.Console.Out.Write(this.AddClear().Add("List Ins ").Add(this.StatusString(b)).AddLine().AddResult());

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

        this.Console.Out.Write(this.AddClear().Add("Table Add ").Add(this.StatusString(b)).AddLine().AddResult());

        var Any kk;
        kk : array.Get(1);

        table.Rem(kk);

        array : this.ListInfra.ArrayCreateList(table);

        b : (array.Count = 2);
        b : b & this.ArrayIntSame(array, 0, 983501);
        b : b & this.ArrayIntSame(array, 1, 8197);

        this.Console.Out.Write(this.AddClear().Add("Table Rem ").Add(this.StatusString(b)).AddLine().AddResult());

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

        this.Console.Out.Write(this.AddClear().Add("Table Ins ").Add(this.StatusString(b)).AddLine().AddResult());

        return true;
    }

    maide private Bool ExecuteListSort()
    {
        var Array array;
        array : this.ListInfra.ArrayCreate(5);

        this.ArrayIndex : 0;

        this.ArrayAddInt(array, 91);
        this.ArrayAddInt(array, 2632);
        this.ArrayAddInt(array, 8);
        this.ArrayAddInt(array, 2633);
        this.ArrayAddInt(array, 2631);

        var IntLess less;
        less : new IntLess;
        less.Init();

        var Range range;
        range : new Range;
        range.Init();
        range.Index : 0;
        range.Count : array.Count;

        var Array copyArray;
        copyArray : this.ListInfra.ArrayCreate(array.Count);

        this.ListInfra.Sort(array, less, range, copyArray);

        var Bool b;
        b : true;
        b : b & this.ArrayIntSame(array, 0, 8);
        b : b & this.ArrayIntSame(array, 1, 91);
        b : b & this.ArrayIntSame(array, 2, 2631);
        b : b & this.ArrayIntSame(array, 3, 2632);
        b : b & this.ArrayIntSame(array, 4, 2633);

        this.Console.Out.Write(this.AddClear().Add("List Sort ").Add(this.StatusString(b)).AddLine().AddResult());
        return true;
    }

    maide private Bool ExecuteListFind()
    {
        var Array array;
        array : this.ListInfra.ArrayCreate(5);

        this.ArrayIndex : 0;

        this.ArrayAddInt(array, 8);
        this.ArrayAddInt(array, 91);
        this.ArrayAddInt(array, 2631);
        this.ArrayAddInt(array, 2632);
        this.ArrayAddInt(array, 2633);

        var IntLess less;
        less : new IntLess;
        less.Init();

        var Range range;
        range : new Range;
        range.Init();
        range.Index : 0;
        range.Count : array.Count;

        var Int ka;
        ka : 2632;

        var Int n;
        n : this.ListInfra.Find(array, ka, less, range);

        var Bool ba;
        ba : (n = 3);

        ka : 8;

        n : this.ListInfra.Find(array, ka, less, range);

        var Bool bb;
        bb : (n = 0);

        ka : 2633;

        n : this.ListInfra.Find(array, ka, less, range);

        var Bool bc;
        bc : (n = 4);

        var Bool b;
        b : ba & bb & bc;

        this.Console.Out.Write(this.AddClear().Add("List Find ").Add(this.StatusString(b)).AddLine().AddResult());
        return true;
    }

    maide private Any ListAddInt(var List list, var Int n)
    {
        return list.Add(n);
    }

    maide private Bool TableAddInt(var Table table, var Int n)
    {
        this.ListInfra.TableAdd(table, n, n);
        return true;
    }

    maide private Bool ArrayAddInt(var Array array, var Int n)
    {
        array.Set(this.ArrayIndex, n);

        this.ArrayIndex : this.ArrayIndex + 1;

        return true;
    }

    maide private Bool ArrayIntSame(var Array array, var Int index, var Int value)
    {
        var Int k;
        k : cast Int(array.Get(index));

        return k = value;
    }

    maide private Bool ExecuteMath()
    {
        var MathComp ka;
        ka : new MathComp;
        ka.Init();

        ka.Cand : 3;
        ka.Expo : 2;

        var Int aa;
        aa : this.Math.ValueTen(ka);
        this.ConsoleWriteMathValue("Demo Math ValueTen: ", aa);

        ka.Cand : 5;
        ka.Expo : 0sn1;

        aa : this.Math.ValueTen(ka);
        this.ConsoleWriteMathValue("Demo Math ValueTen 2: ", aa);

        ka.Cand : 0sn1;
        ka.Expo : 0sn2;

        aa : this.Math.Value(ka);
        this.ConsoleWriteMathValue("Demo Math Value: ", aa);

        aa : this.Math.Sin(0);
        this.ConsoleWriteMathValue("Demo Math Sin(0): ", aa);

        aa : this.Math.Cos(0);
        this.ConsoleWriteMathValue("Demo Math Cos(0): ", aa);
        return true;
    }

    maide private Bool ConsoleWriteMathValue(var String prefix, var Int value)
    {
        this.Math.Comp(this.MathComp, value);
        
        var String ka;
        ka : this.StringSInt(this.MathComp.Expo);

        var String k;

        k : this.AddClear()
            .Add(prefix)
            .Add("Cand: ")
            .Add(this.StringIntFormat(this.MathComp.Cand, 16, false, 15, 15, this.Char("0")))
            .Add(", ")
            .Add("Expo: ")
            .Add(ka)
            .AddLine()
            .AddResult()
            ;

        this.Console.Out.Write(k);

        return true;
    }

    maide private String StringSInt(var Int n)
    {
        this.AddClear();

        var Int k;
        k : n;
        inf (sign <(n, 0))
        {
            k : 0 - n;
        
            this.Add("-");
        }

        this.Add(this.StringInt(k));

        return this.AddResult();
    }

    maide private Bool ExecuteRand()
    {
        var Rand rand;
        rand : new Rand;
        rand.Init();

        rand.Seed : 36719;

        var Int oa;
        oa : rand.Execute();

        var Bool ba;
        ba : oa = 0hb86ed3ea0326c2a;

        oa : rand.Execute();

        var Bool bb;
        bb : oa = 0h0af07c3df31044c;

        var Bool b;
        b : ba & bb;

        this.Console.Out.Write(this.AddClear().Add("Demo Rand ").Add(this.StatusString(b)).AddLine().AddResult());

        rand.Final();
        return true;
    }

    maide private Bool ExecuteTextIntParse()
    {
        var Bool b;
        b : true;

        var Text text;
        text : this.TextInfra.TextCreateStringData("fffffffffffffff", null);

        var Int nn;
        nn : this.TextInfra.Char("9");

        var Int kkk;
        kkk : this.TextInfra.DigitValue(nn, 10);

        b : b & (kkk = 9);

        var Int na;
        na : this.IntParse.Execute(text, 16, null);

        b : b & (na = 0hfffffffffffffff);

        text : this.TextCreate("ffffffffffffffff");

        na : this.IntParse.Execute(text, 16, null);

        b : b & (na = null);

        text : this.TextCreate("0000000000000000");

        na : this.IntParse.Execute(text, 16, null);

        b : b & (na = null);

        text : this.TextCreate("1000000000000000");

        na : this.IntParse.Execute(text, 16, null);

        b : b & (na = null);

        text : this.TextCreate("000000000000000");

        na : this.IntParse.Execute(text, 16, null);

        b : b & (na = 0);

        text : this.TextCreate("800000000000000");

        na : this.IntParse.Execute(text, 16, null);

        b : b & (na = 0h800000000000000);

        this.Console.Out.Write(this.AddClear().Add("Demo Int Parse ").Add(this.StatusString(b)).AddLine().AddResult());

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

    maide private Bool ExecuteThread()
    {
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

        var Bool b;
        b : thread.Status = 93824;

        thread.Final();

        phore.Final();

        this.Console.Out.Write(this.AddClear().Add("Thread ").Add(this.StatusString(b)).AddLine().AddResult());
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

        memory.Close();

        memory.Final();

        this.Console.Out.Write(this.AddClear().Add("Memory Stream read write ").Add(this.StatusString(b)).AddLine().AddResult());
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
        k : this.StorageInfra.TextRead("SystemDemo-96207.08.47.data/A.txt");

        this.Console.Out.Write(this.AddClear().Add("Storage Read: ").Add(k).AddLine().AddResult());

        this.StorageComp.ThisFoldSet("SystemDemo-96207.08.47.data");

        var String ka;
        ka : this.StorageInfra.TextRead("A.txt");

        var Bool b;
        b : this.TextSame(this.TA(ka), this.TB(k));

        this.Console.Out.Write(this.AddClear().Add("StorageComp ThisFold Set Read ").Add(this.StatusString(b)).AddLine().AddResult());

        this.StorageComp.ThisFoldSet("..");
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

        storage.Path : "SystemDemo-96207.08.47.data/StorageStream.txt";
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
        program.Name : "../class.exe";
        program.Argue : list;
        program.WorkFold : "..";
        program.Environ : null;

        program.Execute();

        program.Wait();

        hostThread.Wait();

        program.Final();

        hostThread.Final();

        this.Console.Out.Write("Network Program End\n");

        return true;
    }

    maide prusate String StatusString(var Bool b)
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

    maide prusate String StringIntHex(var Int int)
    {
        return this.StringIntFormat(int, 16, false, 15, 15, this.Char("0"));
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