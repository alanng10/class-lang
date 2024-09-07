namespace Class.Test;

public class Test : ClassBase
{
    public override bool Init()
    {
        base.Init();
        this.StorageInfra = StorageInfra.This;
        this.SystemConsole = ConsoleConsole.This;
        this.TaskKindList = TaskKindList.This;

        this.LanguageName = this.CreateLanguageName();

        this.DataFold = this.ClassInfra.Dot;

        this.ResultSpace = this.StringComp.CreateChar(' ', 4);
        
        this.SExpect = this.S("Expect");

        this.Console = this.CreateConsole();

        this.SetMap = this.ClassInfra.TableCreateStringLess();

        this.AddSetList();
        return true;
    }

    protected virtual StorageInfra StorageInfra { get; set; }
    protected virtual ConsoleConsole SystemConsole { get; set; }
    protected virtual StorageComp StorageComp { get; set; }
    protected virtual TaskKindList TaskKindList { get; set; }


    protected virtual String LanguageName { get; set; }

    private String DataFold { get; set; }

    private List UnitList { get; set; }

    private Table SetMap { get; set; }

    private Set Set { get; set; }

    private Unit Unit { get; set; }

    private long PassCount { get; set; }

    private ClassConsole Console { get; set; }

    private String UnitFold { get; set; }
    private StringOut Out { get; set; }
    private StringOut Err { get; set; }
    private string InitialCurrentDirectory { get; set; }
    private String ResultSpace { get; set; }
    private long UnitIndex { get; set; }
    private bool UnitPass { get; set; }
    private String SExpect { get; set; }

    protected virtual string DataRootDirectory()
    {
        return "../../Class/ClassTest/Test";
    }

    protected virtual bool AddSetList()
    {
        this.AddSet("Token", this.TaskKindList.Token, false, false, false);

        this.AddSet("Node", this.TaskKindList.Node, true, false, false);
        return true;
    }

    protected virtual bool AddSet(string name, TaskKind taskKind, bool addKindAfterTaskArg, bool addPathAfterTaskArg, bool sourceFold)
    {
        Set set;
        set = new Set();
        set.Init();
        set.Name = this.S(name);
        set.TaskKind = taskKind;
        set.AddKindAfterTaskArg = addKindAfterTaskArg;
        set.AddPathAfterTaskArg = addPathAfterTaskArg;
        set.SourceFold = sourceFold;

        this.ListInfra.TableAdd(this.SetMap, set.Name, set);
        return true;
    }

    protected virtual bool SetWorkFold()
    {
        string oo = this.DataRootDirectory();
        Directory.SetCurrentDirectory(oo);
        this.InitialCurrentDirectory = Directory.GetCurrentDirectory();
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
        
        this.ExecuteSetList();
        return 0;
    }

    protected virtual bool ExecuteSetList()
    {
        Iter iter;
        iter = this.SetMap.IterCreate();
        this.SetMap.IterSet(iter);
        while (iter.Next())
        {
            this.Set = (Set)iter.Value;

            this.AddSetUnitList();

            this.ExecuteSet();

            this.Set = null;
        }
        return true;
    }

    private bool AddSetUnitList()
    {
        this.UnitList = new List();
        this.UnitList.Init();

        String combine;
        combine = this.TextInfra.PathCombine;

        String set;
        set = this.Set.Name;

        String setFold;            
        setFold = this.AddClear().Add(this.DataFold).Add(combine).Add(set).AddResult();

        Array kindList;
        kindList = this.FoldList(setFold);

        Iter kindIter;
        kindIter = kindList.IterCreate();
        kindList.IterSet(kindIter);
        while (kindIter.Next())
        {
            String kind;
            kind = (String)kindIter.Value;

            String kindFold;
            kindFold = this.AddClear().Add(setFold).Add(combine).Add(kind).AddResult();

            Array unitList;            
            unitList = this.FoldList(kindFold);

            Iter unitIter;
            unitIter = unitList.IterCreate();
            unitList.IterSet(unitIter);
            while (unitIter.Next())
            {
                String unit;
                unit = (String)unitIter.Value;

                String unitFold;
                unitFold = this.AddClear().Add(kindFold).Add(combine).Add(unit).AddResult();

                String expectFile;                
                expectFile = this.AddClear().Add(unitFold).Add(combine).Add(this.SExpect).AddResult();

                String expect;                
                expect = this.StorageInfra.TextReadAny(expectFile, true);

                String path;
                path = null;
                if (this.Set.AddPathAfterTaskArg)
                {
                    string pathFile;
                    pathFile = unitFold + this.InfraInfra.PathCombine + "Path";
                    path = this.StorageInfra.TextReadAny(pathFile, true);
                }
                
                Unit a;
                a = new Unit();
                a.Init();
                a.Set = this.Set;
                a.Kind = kind;
                a.Name = unit;
                a.Expect = expect;
                a.Path = path;
                this.UnitList.Add(a);
            }
        }
        return true;
    }

    private bool ExecuteSet()
    {
        this.WriteHeader(this.Set.Name);

        this.PassCount = 0;
        this.UnitIndex = 0;

        Iter iter;
        iter = this.UnitList.IterCreate();
        this.UnitList.IterSet(iter);
        while (iter.Next())
        {
            this.Unit = (Unit)iter.Value;

            this.ExecuteUnit();

            this.WriteUnitResult();

            this.Unit = null;

            this.UnitIndex = this.UnitIndex + 1;

            if (this.UnitPass)
            {
                this.PassCount = this.PassCount + 1;
            }
        }

        this.WriteTotalResult();
        return true;
    }

    private bool ExecuteUnit()
    {
        string c;
        c = this.InfraInfra.PathCombine;

        this.UnitFold = this.DataFold + c + this.Unit.Set.Name + c + this.Unit.Kind + c + this.Unit.Name;

        this.Out = new StringOut();
        this.Out.Init();
        this.Err = new StringOut();
        this.Err.Init();

        Directory.SetCurrentDirectory(this.UnitFold);

        Task task;
        task = this.CreateTask();
        this.Console.Task = task;
    
        this.Console.Execute();

        Directory.SetCurrentDirectory(this.InitialCurrentDirectory);

        string actual;
        string actualOut;
        string actualErr;

        actualOut = this.Out.Result();
        actualErr = this.Err.Result();
        actual = actualErr + actualOut;

        string actualFile;
        actualFile = this.UnitFold + c + "Actual";

        this.StorageInfra.TextWriteAny(actualFile, actual, true);

        this.Unit.Actual = actual;

        bool pass;
        pass = (this.Unit.Actual == this.Unit.Expect);
        this.UnitPass = pass;
        return true;
    }

    protected virtual string CreateLanguageName()
    {
        return "Class";
    }

    private bool WriteUnitResult()
    {
        this.WriteResultLine(this.UnitPass, this.Unit.Set.Name, this.Unit.Kind, this.Unit.Name);
        return true;
    }

    private bool WriteResultLine(bool pass, string set, string kind, string unit)
    {
        string a;
        a = null;

        bool b;
        b = pass;
        if (b)
        {
            a = "Pass";
        }
        if (!b)
        {
            a = "Fail";
        }

        string u;
        u = string.Format("{0,-8}", set);

        string k;
        k = string.Format("{0,-24}", kind);

        string j;
        j = unit;

        int number;
        number = this.UnitIndex + 1;

        string p;
        p = number.ToString("D3");

        string s;
        s = p + this.ResultSpace + a + this.ResultSpace + u + this.ResultSpace + k + " " + j + "\n";

        this.SystemConsole.Out.Write(s);
        return true;
    }

    private bool WriteTotalResult()
    {
        string o;
        o = null;

        int unitCount;
        unitCount = this.UnitIndex;
        
        bool b;
        b = (this.PassCount == unitCount);
        if (b)
        {
            o = "All";
        }
        if (!b)
        {
            o = this.PassCount.ToString();
        }

        this.SystemConsole.Out.Write(o + " " + "Pass" + "\n");
        return true;
    }

    private bool WriteHeader(string setName)
    {
        string s;
        s = this.LanguageName.ToUpper();

        string k;
        k = setName.ToUpper();

        this.SystemConsole.Out.Write("==============================" + " " + s + " " + k + " " + "TEST" + " " + "===============================" + "\n");
        return true;
    }

    private Task CreateTask()
    {
        Task task;
        task = new Task();
        task.Init();
        task.Kind = this.Unit.Set.TaskKind;

        bool ba;
        ba = this.Set.AddKindAfterTaskArg;
        if (ba)
        {
            task.Node = this.Unit.Kind;
        }
        if (!ba)
        {
            task.Node = "Class";
        }

        if (this.Set.AddPathAfterTaskArg)
        {
            task.Path = this.Unit.Path;
        }

        task.Print = true;

        string source;
        source = null;
        bool b;
        b = this.Set.SourceFold;
        if (b)
        {
            source = "Source";
        }
        if (!b)
        {
            source = "Code";
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
        a = this.StorageComp.FoldList(foldPath);
        return a;
    }
}