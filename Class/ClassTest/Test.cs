namespace Class.Test;

public class Test : Any
{
    public override bool Init()
    {
        base.Init();
        this.InfraInfra = InfraInfra.This;
        this.ListInfra = ListInfra.This;
        this.StorageInfra = StorageInfra.This;
        this.SystemConsole = ConsoleConsole.This;
        this.ClassInfra = ClassInfra.This;
        this.TaskKindList = TaskKindList.This;

        this.LanguageName = this.CreateLanguageName();

        this.DataFold = ".";

        this.ResultSpace = new string(' ', 4);
        
        this.Console = this.CreateConsole();

        string oo = this.DataRootDirectory();
        Directory.SetCurrentDirectory(oo);
        this.InitialCurrentDirectory = Directory.GetCurrentDirectory();

        this.SetMap = this.ClassInfra.TableCreateStringCompare();

        this.AddSetList();
        return true;
    }

    protected virtual InfraInfra InfraInfra { get; set; }
    protected virtual ListInfra ListInfra { get; set; }
    protected virtual StorageInfra StorageInfra { get; set; }
    protected virtual ClassInfra ClassInfra { get; set; }
    protected virtual ConsoleConsole SystemConsole { get; set; }
    protected virtual TaskKindList TaskKindList { get; set; }

    protected virtual string LanguageName { get; set; }

    private string DataFold { get; set; }

    private List UnitList { get; set; }

    private Table SetMap { get; set; }

    private Set Set { get; set; }

    private Unit Unit { get; set; }

    private int PassCount { get; set; }

    private ClassConsole Console { get; set; }

    private string UnitFold { get; set; }

    private StringOut Out { get; set; }
    private StringOut Err { get; set; }

    private string InitialCurrentDirectory { get; set; }

    private string ResultSpace { get; set; }

    private int UnitIndex { get; set; }

    private bool UnitPass { get; set; }

    protected virtual string DataRootDirectory()
    {
        return "../../Class/ClassTest/Test";
    }

    protected virtual bool AddSetList()
    {
        this.AddSet("Token", this.TaskKindList.Token, false, false, false);

        this.AddSet("Node", this.TaskKindList.Node, true, false, false);

        //this.AddSet("Port", this.TaskKindList.Port, false, false, false);
        return true;
    }

    protected virtual bool AddSet(string name, TaskKind taskKind, bool addKindAfterTaskArg, bool addPathAfterTaskArg, bool sourceFold)
    {
        Set set;
        set = new Set();
        set.Init();
        set.Name = name;
        set.TaskKind = taskKind;
        set.AddKindAfterTaskArg = addKindAfterTaskArg;
        set.AddPathAfterTaskArg = addPathAfterTaskArg;
        set.SourceFold = sourceFold;

        this.ListInfra.TableAdd(this.SetMap, set.Name, set);
        return true;
    }

    public virtual int Execute()
    {
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

        string set;
        set = this.Set.Name;

        string setFold;            
        setFold = this.DataFold + this.InfraInfra.PathCombine + set;

        Array kindList;
        kindList = this.GetFoldList(setFold);

        Iter kindIter;
        kindIter = kindList.IterCreate();
        kindList.IterSet(kindIter);
        while (kindIter.Next())
        {
            string kind;
            kind = (string)kindIter.Value;

            string kindFold;
            kindFold = setFold + this.InfraInfra.PathCombine + kind;

            Array unitList;            
            unitList = this.GetFoldList(kindFold);

            Iter unitIter;
            unitIter = unitList.IterCreate();
            unitList.IterSet(unitIter);
            while (unitIter.Next())
            {
                string unit;
                unit = (string)unitIter.Value;

                string unitFold;
                unitFold = kindFold + this.InfraInfra.PathCombine + unit;

                string expectFile;                
                expectFile = unitFold + this.InfraInfra.PathCombine + "Expect";

                string expect;                
                expect = this.StorageInfra.TextRead(expectFile);

                string path;
                path = null;
                if (this.Set.AddPathAfterTaskArg)
                {
                    string pathFile;
                    pathFile = unitFold + this.InfraInfra.PathCombine + "Path";
                    path = this.StorageInfra.TextRead(pathFile);
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

        this.StorageInfra.TextWrite(actualFile, actual);

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

    private Array GetFoldList(string foldPath)
    {
        string[] u; 
        u = Directory.GetDirectories(foldPath);

        int count;
        count = u.Length;
        int i;
        i = 0;
        while (i < count)
        {
            string path;
            path = u[i];

            string name;
            name = Path.GetFileName(path);

            u[i] = name;
            i = i + 1;
        }

        Array array;
        array = this.ListInfra.ArrayCreate(count);

        i = 0;
        while (i < count)
        {
            string k;
            k = u[i];

            array.Set(i, k);
            i = i + 1;
        }

        Range range;
        range = new Range();
        range.Init();
        range.Count = count;

        StringCompare compare;
        compare = new StringCompare();
        compare.Init();

        array.Sort(range, compare);
        return array;
    }
}