namespace Saber.Test;

public class Test : TextAdd
{
    public override bool Init()
    {
        base.Init();
        this.ListInfra = ListInfra.This;
        this.StorageInfra = StorageInfra.This;
        this.ClassInfra = ClassInfra.This;
        this.SystemConsole = ConsoleConsole.This;
        this.StorageComp = StorageComp.This;
        this.TaskKindList = TaskKindList.This;

        this.DataFold = this.ClassInfra.TextDot;

        this.ResultSpace = this.StringComp.CreateChar(' ', 4);

        this.SClass = this.S("Class");
        this.SExpect = this.S("Expect");
        this.SActual = this.S("Actual");
        this.SPath = this.S("Path");
        this.SSource = this.S("Source");
        this.SCode = this.S("Code");
        this.SPass = this.S("Pass");
        this.SFail = this.S("Fail");
        this.SAll = this.S("All");
        this.SSpace = this.S(" ");

        this.LangName = this.CreateLangName();

        this.Console = this.CreateConsole();

        this.SeerTable = this.ClassInfra.TableCreateStringLess();

        this.AddSeerList();
        return true;
    }

    protected virtual ListInfra ListInfra { get; set; }
    protected virtual StorageInfra StorageInfra { get; set; }
    protected virtual ClassInfra ClassInfra { get; set; }
    protected virtual ConsoleConsole SystemConsole { get; set; }
    protected virtual StorageComp StorageComp { get; set; }
    protected virtual TaskKindList TaskKindList { get; set; }
    protected virtual String LangName { get; set; }

    private String DataFold { get; set; }
    private List CaseList { get; set; }
    private Table SeerTable { get; set; }
    private Seer Seer { get; set; }
    private Case Case { get; set; }
    private long PassCount { get; set; }
    private ClassConsole Console { get; set; }
    private String CaseFold { get; set; }
    private StringOut Out { get; set; }
    private StringOut Err { get; set; }
    private String InitThisFold { get; set; }
    private String ResultSpace { get; set; }
    private long CaseIndex { get; set; }
    private bool CasePass { get; set; }
    private String SClass { get; set; }
    private String SExpect { get; set; }
    private String SActual { get; set; }
    private String SPath { get; set; }
    private String SSource { get; set; }
    private String SCode { get; set; }
    private String SPass { get; set; }
    private String SFail { get; set; }
    private String SAll { get; set; }

    protected virtual String DataRootDirectory()
    {
        return this.S("../../Saber/SaberTest/Test");
    }

    protected virtual bool AddSeerList()
    {
        this.AddSeer("Token", this.TaskKindList.Token, false, false, false);

        this.AddSeer("Node", this.TaskKindList.Node, true, false, false);
        return true;
    }

    protected virtual bool AddSeer(string name, TaskKind taskKind, bool addKindAfterTaskArg, bool addPathAfterTaskArg, bool sourceFold)
    {
        Seer seer;
        seer = new Seer();
        seer.Init();
        seer.Name = this.S(name);
        seer.TaskKind = taskKind;
        seer.AddKindAfterTaskArg = addKindAfterTaskArg;
        seer.AddPathAfterTaskArg = addPathAfterTaskArg;
        seer.SourceFold = sourceFold;

        this.ListInfra.TableAdd(this.SeerTable, seer.Name, seer);
        return true;
    }

    protected virtual bool SetWorkFold()
    {
        String k;
        k = this.DataRootDirectory();
        
        this.StorageComp.ThisFoldSet(k);
        
        this.InitThisFold = this.StorageComp.ThisFoldGet();
        return true;
    }

    public virtual long Execute()
    {
        bool b;
        b = this.Console.Load();
        if (!b)
        {
            return this.Console.Status;
        }

        this.SetWorkFold();
        
        this.ExecuteSeerList();
        return 0;
    }

    protected virtual bool ExecuteSeerList()
    {
        Iter iter;
        iter = this.SeerTable.IterCreate();
        this.SeerTable.IterSet(iter);
        while (iter.Next())
        {
            this.Seer = iter.Value as Seer;

            this.AddSeerCaseList();

            this.ExecuteSeer();

            this.Seer = null;
        }
        return true;
    }

    private bool AddSeerCaseList()
    {
        this.CaseList = new List();
        this.CaseList.Init();

        String combine;
        combine = this.TextInfra.PathCombine;

        String set;
        set = this.Seer.Name;

        String seerFoldPath;
        seerFoldPath = this.AddClear().Add(this.DataFold).Add(combine).Add(set).AddResult();

        Array kindList;
        kindList = this.FoldList(seerFoldPath);

        Iter kindIter;
        kindIter = kindList.IterCreate();
        kindList.IterSet(kindIter);
        while (kindIter.Next())
        {
            StorageEntry kindFold;
            kindFold = kindIter.Value as StorageEntry;

            String kind;
            kind = kindFold.Name;

            String kindFoldPath;
            kindFoldPath = this.AddClear().Add(seerFoldPath).Add(combine).Add(kind).AddResult();

            Array unitList;
            unitList = this.FoldList(kindFoldPath);

            Iter unitIter;
            unitIter = unitList.IterCreate();
            unitList.IterSet(unitIter);
            while (unitIter.Next())
            {
                StorageEntry unitFold;
                unitFold = unitIter.Value as StorageEntry;

                String unit;
                unit = unitFold.Name;

                String unitFoldPath;
                unitFoldPath = this.AddClear().Add(kindFoldPath).Add(combine).Add(unit).AddResult();

                String expectFile;                
                expectFile = this.AddClear().Add(unitFoldPath).Add(combine).Add(this.SExpect).AddResult();

                String expect;                
                expect = this.StorageInfra.TextRead(expectFile);

                String path;
                path = null;
                if (this.Seer.AddPathAfterTaskArg)
                {
                    String pathFile;
                    pathFile = this.AddClear().Add(unitFoldPath).Add(combine).Add(this.SPath).AddResult();

                    path = this.StorageInfra.TextRead(pathFile);
                }
                
                Case a;
                a = new Case();
                a.Init();
                a.Seer = this.Seer;
                a.Kind = kind;
                a.Name = unit;
                a.Expect = expect;
                a.Path = path;
                this.CaseList.Add(a);
            }
        }
        return true;
    }

    private bool ExecuteSeer()
    {
        this.WriteHead(this.Seer.Name);

        this.PassCount = 0;
        this.CaseIndex = 0;

        Iter iter;
        iter = this.CaseList.IterCreate();
        this.CaseList.IterSet(iter);
        while (iter.Next())
        {
            this.Case = iter.Value as Case;

            this.ExecuteCase();

            this.WriteCaseResult();

            this.Case = null;

            this.CaseIndex = this.CaseIndex + 1;

            if (this.CasePass)
            {
                this.PassCount = this.PassCount + 1;
            }
        }

        this.WriteTotalResult();
        return true;
    }

    private bool ExecuteCase()
    {
        String c;
        c = this.TextInfra.PathCombine;

        this.CaseFold = this.AddClear().Add(this.DataFold).Add(c).Add(this.Case.Seer.Name).Add(c).Add(this.Case.Kind).Add(c).Add(this.Case.Name).AddResult();

        this.Out = new StringOut();
        this.Out.Init();
        this.Err = new StringOut();
        this.Err.Init();

        this.StorageComp.ThisFoldSet(this.CaseFold);

        Task task;
        task = this.CreateTask();
        this.Console.Task = task;
    
        this.Console.Execute();

        this.StorageComp.ThisFoldSet(this.InitThisFold);

        String actual;
        String actualOut;
        String actualErr;

        actualOut = this.Out.Result();
        actualErr = this.Err.Result();

        actual = this.AddClear().Add(actualErr).Add(actualOut).AddResult();

        String actualFile;
        actualFile = this.AddClear().Add(this.CaseFold).Add(c).Add(this.SActual).AddResult();

        this.StorageInfra.TextWrite(actualFile, actual);

        this.Case.Actual = actual;

        bool pass;
        pass = this.TextSame(this.TA(this.Case.Actual), this.TB(this.Case.Expect));

        this.CasePass = pass;
        return true;
    }

    protected virtual String CreateLangName()
    {
        return this.SClass;
    }

    private bool WriteCaseResult()
    {
        this.WriteResultLine(this.CasePass, this.Case.Seer.Name, this.Case.Kind, this.Case.Name);
        return true;
    }

    private bool WriteResultLine(bool pass, String set, String kind, String unit)
    {
        String a;
        a = null;

        bool b;
        b = pass;
        if (b)
        {
            a = this.SPass;
        }
        if (!b)
        {
            a = this.SFail;
        }

        String u;
        u = this.StringTextFormat(this.TA(set), true, 8, -1, ' ');

        String k;
        k = this.StringTextFormat(this.TA(kind), true, 24, -1, ' ');

        String j;
        j = unit;

        long n;
        n = this.CaseIndex;

        String p;
        p = this.StringIntFormat(n, 10, false, 3, -1, '0');

        String t;
        t = this.ResultSpace;

        String s;
        s = this.AddClear().Add(p).Add(t).Add(a).Add(t).Add(u).Add(t).Add(k).Add(this.SSpace).Add(j).AddLine().AddResult();

        this.SystemConsole.Out.Write(s);
        return true;
    }

    private bool WriteTotalResult()
    {
        String o;
        o = null;

        long unitCount;
        unitCount = this.CaseIndex;
        
        bool b;
        b = (this.PassCount == unitCount);
        if (b)
        {
            o = this.SAll;
        }
        if (!b)
        {
            o = this.StringInt(this.PassCount);
        }

        String a;
        a = this.AddClear().Add(o).Add(this.SSpace).Add(this.SPass).AddLine().AddResult();

        this.SystemConsole.Out.Write(a);
        return true;
    }

    private bool WriteHead(String setName)
    {
        String s;
        s = this.StringCreate(this.TextAlphaNite(this.TA(this.LangName)));

        String k;
        k = this.StringCreate(this.TextAlphaNite(this.TA(setName)));

        String line;
        line = this.S("==============================");

        String a;
        a = this.AddClear()
            .Add(line)
            .Add(this.SSpace).Add(s).Add(this.SSpace).Add(k).Add(this.SSpace).AddS("TEST").Add(this.SSpace)
            .Add(line)
            .AddLine()
            .AddResult();

        this.SystemConsole.Out.Write(a);
        return true;
    }

    private Task CreateTask()
    {
        Task task;
        task = new Task();
        task.Init();
        task.Kind = this.Case.Seer.TaskKind;

        bool ba;
        ba = this.Seer.AddKindAfterTaskArg;
        if (ba)
        {
            task.Node = this.Case.Kind;
        }
        if (!ba)
        {
            task.Node = this.SClass;
        }

        if (this.Seer.AddPathAfterTaskArg)
        {
            task.Path = this.Case.Path;
        }

        task.Print = true;

        String source;
        source = null;
        bool b;
        b = this.Seer.SourceFold;
        if (b)
        {
            source = this.SSource;
        }
        if (!b)
        {
            source = this.SCode;
        }
        task.Source = source;

        task.Out = this.Out;
        task.Err = this.Err;

        Task ret;
        ret = task;
        return ret;
    }

    protected virtual ClassConsole CreateConsole()
    {
        ClassConsole a;
        a = new ClassConsole();
        a.Init();
        return a;
    }

    protected virtual Array FoldList(String foldPath)
    {
        Array a;
        a = this.StorageComp.EntryList(foldPath, true, false);
        return a;
    }
}