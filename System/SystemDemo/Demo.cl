class Demo : Add
{
    maide prusate Bool Init()
    {
        base.Init();
        this.Extern : share Extern;
        this.ListInfra : share ListInfra;
        this.MathInfra : share MathInfra;
        this.StorageInfra : share StorageInfra;
        this.Math : share Math;
        this.StorageComp : share StorageComp;
        this.Console : share Console;

        this.MathComp : new MathComp;
        this.MathComp.Init();
        return true;
    }

    field private Extern Extern { get { return data; } set { data : value; } }
    field precate ListInfra ListInfra { get { return data; } set { data : value; } }
    field precate MathInfra MathInfra { get { return data; } set { data : value; } }
    field precate StorageInfra StorageInfra { get { return data; } set { data : value; } }
    field prusate Math Math { get { return data; } set { data : value; } }
    field precate StorageComp StorageComp { get { return data; } set { data : value; } }
    field prusate Console Console { get { return data; } set { data : value; } }
    field precate MathComp MathComp { get { return data; } set { data : value; } }
    field precate Int ArrayIndex { get { return data; } set { data : value; } }

    maide prusate Bool Execute()
    {
        this.Console.Out.Write("Demo ABCD AAAA BBBB\n");

        var DemoC demoC;
        demoC : new DemoC;
        demoC.Init();
        demoC.Execute();

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


        # var String k;
        #k : console.Inn.Read();

        # var String a;
        
        # a : this.AddClear().Add("k: ").AddLine()
            # .Add(k)
            # .AddLine().AddResult();

        # this.Console.Out.Write(a);

        this.ExecuteBoolOperate();

        this.ExecuteIntOperate();

        this.ExecuteSameOperate();

        this.ExecuteValueCast();

        this.ExecuteCast();

        this.ExecuteEnviron();

        this.ExecuteList();

        this.ExecuteIntParse();

        this.ExecuteFormat();

        this.ExecuteMath();

        this.ExecuteRand();

        this.ExecuteThread();

        this.ExecuteMemoryStream();

        this.ExecuteTime();

        this.ExecuteTimeEventWait();

        this.ExecuteStorage();

        this.ExecuteStorageStream();

        this.ExecuteNetwork();

        this.ExecuteNetworkProgram();

        # this.Console.Inn.Read();

        # var Data ka;
        # ka : new Data;
        # ka.Count : 10 * 1024 * 1024;
        # ka.Init();

        # this.Console.Inn.Read();

        # this.Console.Out.Write("Demo HHHH\n");

        this.Console.Out.Write("Demo Execute End\n");

        return true;
    }

    maide private Bool ExecuteBoolOperate()
    {
        var Bool b;
        b : true;

        var Bool ba;
        ba : true;

        b : b & ba;

        var Bool bb;
        bb : false;

        b : b & ~bb;

        ba : true & true;

        b : b & ba;

        ba : true & false;

        b : b & ~ba;

        ba : false & true;

        b : b & ~ba;

        ba : false & false;

        b : b & ~ba;

        ba : true | true;

        b : b & ba;

        ba : true | false;

        b : b & ba;

        ba : false | true;

        b : b & ba;

        ba : false | false;

        b : b & ~ba;

        this.Console.Out.Write(this.AddClear().Add("Bool Operate ").Add(this.StatusString(b)).AddLine().AddResult());

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

        this.Console.Out.Write(this.AddClear().Add("Int Operate ").Add(this.StatusString(b)).AddLine().AddResult());

        return true;
    }

    maide private Bool ExecuteSameOperate()
    {
        var Bool b;
        b : true;

        b : b & (~(this = null));

        b : b & (~(base = null));

        var Any ka;
        ka : this;

        b : b & (~(ka = null));

        var Text kb;
        kb : new Text;

        b : b & (~(kb = null));

        b : b & (null = null);

        this.Console.Out.Write(this.AddClear().Add("Same Operate ").Add(this.StatusString(b)).AddLine().AddResult());

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

        this.Console.Out.Write(this.AddClear().Add("Cast Value ").Add(this.StatusString(b)).AddLine().AddResult());

        return true;
    }

    maide private Bool ExecuteCast()
    {
        var DemoC ka;
        ka : new DemoC;
        
        var Any kk;
        kk : ka;

        var Bool b;
        b : true;

        var Text kaa;
        kaa : cast Text(kk);

        b : b & (kaa = null);

        var DemoC kab;
        kab : cast DemoC(kk);

        b : b & (kab = ka);

        var DemoB kac;
        kac : cast DemoB(kk);

        b : b & (kac = ka);

        this.Console.Out.Write(this.AddClear().Add("Cast ").Add(this.StatusString(b)).AddLine().AddResult());

        return true;
    }

    maide private Bool ExecuteEnviron()
    {
        var Int k;
        k : this.Extern.Environ_System();

        this.Console.Out.Write(this.AddClear().Add("System: ").AddInt(k).AddLine().AddResult());
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

        var Bool b;
        b : true;

        ka.Cand : 3;
        ka.Expo : 2;

        var Int value;

        value : this.Math.ValueTen(ka);
        b : b & this.MathValid(value, 0h12c0000000000, 0sn40);

        ka.Cand : 5;
        ka.Expo : 0sn1;

        value : this.Math.ValueTen(ka);
        b : b & this.MathValid(value, 0h1000000000000, 0sn49);

        value : this.Math.Sin(0);
        b : b & this.MathValid(value, 0, 0sn49);

        value : this.Math.Cos(0);
        b : b & this.MathValid(value, 0h1000000000000, 0sn48);

        ka.Cand : 0h3243f6a8885;
        ka.Expo : 0sn40;

        value : this.Math.Value(ka);
        b : b & this.MathValid(value, 0h1921fb5444280, 0sn47);

        value : this.Math.Sin(value);
        b : b & this.MathValid(value, 0h14611a6263314, 0sn89);

        ka.Expo : 0sn41;

        value : this.Math.Value(ka);
        b : b & this.MathValid(value, 0h1921fb5444280, 0sn48);

        value : this.Math.Sin(value);
        b : b & this.MathValid(value, 0h1000000000000, 0sn48);

        value : this.Math.Tan(0);
        b : b & this.MathValid(value, 0, 0sn49);

        ka.Expo : 0sn42;

        value : this.Math.Value(ka);
        b : b & this.MathValid(value, 0h1921fb5444280, 0sn49);

        value : this.Math.Tan(value);
        b : b & this.MathValid(value, 0h1ffffffffff5c, 0sn49);

        value : this.Math.ASin(0);
        b : b & this.MathValid(value, 0, 0sn49);

        var Int one;
        one : this.MathInt(1);

        value : this.Math.ASin(one);
        b : b & this.MathValid(value, 0h1921fb54442d1, 0sn48);

        this.Console.Out.Write(this.AddClear().Add("Math ").Add(this.StatusString(b)).AddLine().AddResult());

        # ka.Cand : 0sn1;
        # ka.Expo : 0sn2;

        # aa : this.Math.Value(ka);
        # this.ConsoleWriteMathValue("Demo Math Value: ", aa);
        return true;
    }

    maide private Bool MathValid(var Int value, var Int cand, var Int expo)
    {
        this.Math.Comp(this.MathComp, value);

        var Bool ba;
        ba : this.MathComp.Cand = cand;

        var Bool bb;
        bb : this.MathComp.Expo = expo;

        var Bool a;
        a : ba & bb;
        return a;
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

        this.Console.Out.Write(this.AddClear().Add("Rand ").Add(this.StatusString(b)).AddLine().AddResult());

        rand.Final();
        return true;
    }

    maide private Bool ExecuteIntParse()
    {
        var Bool b;
        b : true;

        var Text text;
        text : this.TA("fffffffffffffff");

        var Int na;
        na : this.IntText(text, 16);

        b : b & (na = 0hfffffffffffffff);

        text : this.TA("ffffffffffffffff");

        na : this.IntText(text, 16);

        b : b & (na = 0hfffffffffffffff);

        text : this.TA("0000000000000000");

        na : this.IntText(text, 16);

        b : b & (na = 0);

        text : this.TA("1000000000000000");

        na : this.IntText(text, 16);

        b : b & (na = 0);

        text : this.TA("000000000000000");

        na : this.IntText(text, 16);

        b : b & (na = 0);

        text : this.TA("800000000000000");

        na : this.IntText(text, 16);

        b : b & (na = 0h800000000000000);

        text : this.TA("900760a0803d002");

        na : this.IntText(text, 16);

        b : b & (na = 0h900760a0803d002);

        text : this.TA("900760A0803D002");

        na : this.IntParse.Execute(text, 16, this.TextInfra.AlphaSiteForm);

        b : b & (na = 0h900760a0803d002);

        this.Console.Out.Write(this.AddClear().Add("IntParse ").Add(this.StatusString(b)).AddLine().AddResult());

        return true;
    }
    
    maide private Bool ExecuteFormat()
    {
        var FormatArg argA;
        argA : new FormatArg;
        argA.Init();
        argA.Pos : 3;
        argA.Kind : 0;
        argA.Value : true;
        argA.FieldWidth : 6;
        argA.MaxWidth : null;
        argA.FillChar : this.Char(this.SSpace);
        argA.Form : this.TextInfra.AlphaNiteForm;

        var FormatArg argB;
        argB : new FormatArg;
        argB.Init();
        argB.Pos : 3;
        argB.Kind : 1;
        argB.Value : 56712;
        argB.AlignLeft : true;
        argB.FieldWidth : 8;
        argB.MaxWidth : 6;
        argB.Base : 10;
        argB.FillChar : this.Char(this.SSpace);

        var FormatArg argC;
        argC : new FormatArg;
        argC.Init();
        argC.Pos : 6;
        argC.Kind : 1;
        argC.Value : 46842;
        argC.AlignLeft : false;
        argC.FieldWidth : 8;
        argC.MaxWidth : 6;
        argC.Base : 10;
        argC.FillChar : this.Char(this.SSpace);

        var FormatArg argD;
        argD : new FormatArg;
        argD.Init();
        argD.Pos : 7;
        argD.Kind : 1;
        argD.Value : 0h5bd9ea;
        argD.AlignLeft : false;
        argD.FieldWidth : 8;
        argD.MaxWidth : 6;
        argD.Base : 16;
        argD.FillChar : this.Char(this.SSpace);
        argD.Form : this.TextInfra.AlphaNiteForm;

        var FormatArg argE;
        argE : new FormatArg;
        argE.Init();
        argE.Pos : 7;
        argE.Kind : 1;
        argE.Value : 100;
        argE.AlignLeft : false;
        argE.FieldWidth : 4;
        argE.MaxWidth : null;
        argE.Base : 10;
        argE.FillChar : this.Char("-");

        var FormatArg argF;
        argF : new FormatArg;
        argF.Init();
        argF.Pos : 8;
        argF.Kind : 1;
        argF.Value : 0;
        argF.AlignLeft : false;
        argF.FieldWidth : 3;
        argF.MaxWidth : null;
        argF.Base : 10;
        argF.FillChar : this.Char(":");

        var FormatArg argG;
        argG : new FormatArg;
        argG.Init();
        argG.Pos : 10;
        argG.Kind : 2;
        argG.Value : this.TextCreate("F Hre a");
        argG.AlignLeft : true;
        argG.FieldWidth : 11;
        argG.MaxWidth : 10;
        argG.FillChar : this.Char("=");
        argG.Form : this.TextInfra.AlphaNiteForm;

        var FormatArg argH;
        argH : new FormatArg;
        argH.Init();
        argH.Pos : 10;
        argH.Kind : 2;
        argH.Value : this.TextCreate(this.StringComp.CreateChar(this.Char("H"), 1));
        argH.AlignLeft : false;
        argH.FieldWidth : 10;
        argH.MaxWidth : null;
        argH.FillChar : this.Char("O");

        var Array argList;
        argList : this.ListInfra.ArrayCreate(8);
        argList.Set(0, argA);
        argList.Set(1, argB);
        argList.Set(2, argC);
        argList.Set(3, argD);
        argList.Set(4, argE);
        argList.Set(5, argF);
        argList.Set(6, argG);
        argList.Set(7, argH);

        var Text varBase;
        varBase : this.TextCreate("G H , j h\n\n");

        var Int count;
        count : this.Format.ExecuteCount(varBase, argList);

        var Text text;
        text : this.TextInfra.TextCreate(count);

        this.Format.ExecuteResult(varBase, argList, text);

        var String a;
        a : this.StringCreate(text);

        var Bool b;
        b : this.TextSame(this.TA(a), this.TB("G H  TRUE56712  ,  46842j5BD9EA-100 ::0h\nF HRE A===OOOOOOOOOH\n"));

        this.Console.Out.Write(this.AddClear().Add("Format ").Add(this.StatusString(b)).AddLine().AddResult());
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

        this.Console.Out.Write("Phore Open\n");

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

        this.Console.Out.Write(this.AddClear().Add("Memory Stream ").Add(this.StatusString(b)).AddLine().AddResult());
        return true;
    }

    maide private Bool ExecuteTime()
    {
        var Time time;
        time : new Time;
        time.Init();

        var Bool b;
        b : true;

        b : b & (time.TotalTick = 0);

        b : b & this.ValidTime(time, 1, 1, 1, 0, 0, 0, 0, 0);

        time.AddTick(2042000);

        b : b & (time.TotalTick = 2042000);

        this.Console.Out.Write(this.AddClear().Add("Time ").Add(this.StatusString(b)).AddLine().AddResult());

        time.This();

        this.ConsoleWriteTime("Time This : ", time);

        time.Final();
        return true;
    }

    maide private Bool ValidTime(var Time time, var Int yea, var Int mon, var Int day, var Int our, var Int min, var Int sec, var Int tick, var Int pos)
    {
        var Bool b;

        b : (time.Yea = yea & time.Mon = mon & time.Day = day &
            time.Our = our & time.Min = min & time.Sec = sec &
            time.Tick = tick & time.Pos = pos
        );

        return b;
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

    maide private Bool ExecuteTimeEventWait()
    {
        var TimeEvent k;
        k : new TimeEvent;
        k.Init();

        k.Wait(1000);

        k.Final();

        this.Console.Out.Write("TimeEvent Wait\n");

        return true;
    }

    maide private Bool ExecuteStorage()
    {
        var String combine;
        combine : this.TextInfra.PathCombine;

        var String dataPath;
        dataPath : "SystemDemo-96207.08.47/Data";

        var String pathA;
        pathA : this.AddClear().Add(dataPath).Add(combine).Add("A.txt").AddResult();

        var String k;
        k : this.StorageInfra.TextRead(pathA);

        var Bool b;
        b : this.TextSame(this.TA(k), this.TB("HH jj o i 可 的水 。，\n的d E 0 - +\n"));

        this.Console.Out.Write(this.AddClear().Add("Storage Infra Read ").Add(this.StatusString(b)).AddLine().AddResult());

        var String pathB;
        pathB : this.AddClear().Add(dataPath).Add(combine).Add("B.txt").AddResult();

        var String kad;
        kad : "Lo E 水 可 的 - +";

        this.StorageComp.FileDelete(pathB);

        b : true;

        b : b & this.StorageInfra.TextWrite(pathB, kad);

        var String kada;
        kada : this.StorageInfra.TextRead(pathB);

        b : b & this.TextSame(this.TA(kada), this.TB(kad));

        this.Console.Out.Write(this.AddClear().Add("Storage Infra Write ").Add(this.StatusString(b)).AddLine().AddResult());

        this.StorageComp.ThisFoldSet(dataPath);

        var String ka;
        ka : this.StorageInfra.TextRead("A.txt");

        b : this.TextSame(this.TA(ka), this.TB(k));

        this.Console.Out.Write(this.AddClear().Add("Storage ThisFold ").Add(this.StatusString(b)).AddLine().AddResult());

        this.StorageComp.ThisFoldSet("../..");

        var String foldPath;
        foldPath : this.AddClear().Add(dataPath).Add(combine).Add("Fold").AddResult();

        var String pathCA;
        pathCA : this.AddClear().Add(foldPath).Add(combine).Add("EntryFold").AddResult();

        var String pathCAA;
        pathCAA : this.AddClear().Add(pathCA).Add(combine).Add("EntryFoldA").AddResult();

        var String pathCB;
        pathCB : this.AddClear().Add(foldPath).Add(combine).Add("EntryFile").AddResult();

        b : true;
        b : b & this.StorageComp.Exist(pathCA);
        b : b & this.StorageComp.Fold(pathCA);
        b : b & this.StorageComp.Exist(pathCAA);
        b : b & this.StorageComp.Fold(pathCAA);
        b : b & this.StorageComp.Exist(pathCB);
        b : b & ~this.StorageComp.Fold(pathCB);

        this.Console.Out.Write(this.AddClear().Add("Storage Entry ").Add(this.StatusString(b)).AddLine().AddResult());

        var String pathD;
        pathD : this.AddClear().Add(foldPath).Add(combine).Add("FoldK").AddResult();

        var String pathDA;
        pathDA : this.AddClear().Add(pathD).Add(combine).Add("FoldKA").AddResult();

        this.StorageComp.FoldDelete(pathD);

        b : true;
        b : b & this.StorageComp.FoldCreate(pathDA);
        b : b & this.StorageComp.Exist(pathD);
        b : b & this.StorageComp.Fold(pathD);
        b : b & this.StorageComp.Exist(pathDA);
        b : b & this.StorageComp.Fold(pathDA);

        this.Console.Out.Write(this.AddClear().Add("Storage Fold Create ").Add(this.StatusString(b)).AddLine().AddResult());

        b : true;
        b : b & this.StorageComp.FoldDelete(pathD);
        b : b & ~this.StorageComp.Exist(pathD);
        b : b & ~this.StorageComp.Fold(pathD);
        b : b & ~this.StorageComp.Exist(pathDA);
        b : b & ~this.StorageComp.Fold(pathDA);

        this.Console.Out.Write(this.AddClear().Add("Storage Fold Delete ").Add(this.StatusString(b)).AddLine().AddResult());

        var String pathDB;
        pathDB : this.AddClear().Add(pathD).Add(combine).Add("FoldKB").AddResult();

        var String pathDC;
        pathDC : this.AddClear().Add(pathDA).Add(combine).Add("FoldKAA").AddResult();

        var String pathDD;
        pathDD : this.AddClear().Add(pathDA).Add(combine).Add("FileA").AddResult();

        var String pathDE;
        pathDE : this.AddClear().Add(pathDB).Add(combine).Add("FoldKAA").AddResult();

        var String pathDF;
        pathDF : this.AddClear().Add(pathDB).Add(combine).Add("FileA").AddResult();

        this.StorageComp.FoldCreate(pathDC);

        this.StorageInfra.TextWrite(pathDD, "");

        b : true;
        b : b & this.StorageInfra.FoldCopy(pathDA, pathDB);
        b : b & this.StorageComp.Exist(pathDB);
        b : b & this.StorageComp.Fold(pathDB);
        b : b & this.StorageComp.Exist(pathDE);
        b : b & this.StorageComp.Fold(pathDE);
        b : b & this.StorageComp.Exist(pathDF);
        b : b & ~this.StorageComp.Fold(pathDF);

        this.Console.Out.Write(this.AddClear().Add("Storage Fold Copy ").Add(this.StatusString(b)).AddLine().AddResult());

        var String pathE;
        pathE : this.AddClear().Add(foldPath).Add(combine).Add("FileCreate").AddResult();

        this.StorageComp.FileDelete(pathE);

        this.StorageInfra.TextWrite(pathE, "");

        b : true;
        b : b & this.StorageComp.FileDelete(pathE);
        b : b & ~this.StorageComp.Exist(pathE);
        b : b & ~this.StorageComp.Fold(pathE);

        this.Console.Out.Write(this.AddClear().Add("Storage File Delete ").Add(this.StatusString(b)).AddLine().AddResult());

        var String pathH;
        pathH : this.AddClear().Add(foldPath).Add(combine).Add("List").AddResult();

        var Array foldListArray;
        foldListArray : this.StorageComp.EntryList(pathH, true);

        b : true;

        b : b & foldListArray.Count = 2;
        b : b & this.TextSame(this.TA(cast String(foldListArray.Get(0))), this.TB("FoldA"));
        b : b & this.TextSame(this.TA(cast String(foldListArray.Get(1))), this.TB("FoldB"));

        this.Console.Out.Write(this.AddClear().Add("Storage EntryList Fold ").Add(this.StatusString(b)).AddLine().AddResult());

        var Array fileListArray;
        fileListArray : this.StorageComp.EntryList(pathH, false);

        b : true;

        b : b & fileListArray.Count = 2;
        b : b & this.TextSame(this.TA(cast String(fileListArray.Get(0))), this.TB("A.txt"));
        b : b & this.TextSame(this.TA(cast String(fileListArray.Get(1))), this.TB("B.txt"));

        this.Console.Out.Write(this.AddClear().Add("Storage EntryList File ").Add(this.StatusString(b)).AddLine().AddResult());
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

        storage.Path : "SystemDemo-96207.08.47/Data/StorageStream.txt";
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

        this.Console.Out.Write(this.AddClear().Add("Storage Stream ").Add(this.StatusString(b)).AddLine().AddResult());

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

        var Program program;
        program : new Program;
        program.Init();
        program.Name : "./SystemDemoNetwork-0.00.00.exe";
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

    maide precate Int MathInt(var Int n)
    {
        var Int a;
        a : this.MathInfra.Int(this.MathComp, n);
        return a;
    }
}