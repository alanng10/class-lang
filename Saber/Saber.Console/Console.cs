namespace Saber.Console;

public class Console : ClassBase
{
    public override bool Init()
    {
        base.Init();

        this.StorageInfra = StorageInfra.This;
        this.StorageComp = StorageComp.This;
        this.TaskKind = TaskKindList.This;

        this.ErrorWrite = true;
        this.NameCheck = this.CreateNameCheck();

        this.BinaryRead = this.CreateBinaryRead();
        this.ModuleLoad = this.CreateModuleLoad();

        this.PortLoad = this.CreatePortLoad();

        this.ClassGen = this.CreateClassGen();

        this.ErrorString = new ErrorString();
        this.ErrorString.Init();

        this.Create = this.CreateCreate();

        this.InfoGen = new InfoGen();
        this.InfoGen.Init();

        this.InitModuleTable = this.ClassInfra.TableCreateModuleRefLess();
        this.InitBinaryTable = this.ClassInfra.TableCreateModuleRefLess();

        this.PortRead = new PortRead();
        this.PortRead.Init();

        this.ModuleRef = this.ClassInfra.ModuleRefCreate(null, 0);

        this.ModuleRefLess = new ModuleRefLess();
        this.ModuleRefLess.Init();

        this.SInfo = this.S("info");
        this.SMake = this.S("make");
        this.SFlagD = this.S("-d");
        this.SFlagM = this.S("-m");
        this.SClassDotPort = this.S("Class.Port");
        this.SDotCla = this.S(".cla");
        return true;
    }

    public virtual long Status { get; set; }
    public virtual Array Arg { get; set; }
    public virtual Task Task { get; set; }
    public virtual Array Source { get; set; }
    public virtual String SourceFold { get; set; }
    public virtual Create Create { get; set; }
    public virtual Result Result { get; set; }
    public virtual InfoGen InfoGen { get; set; }
    public virtual ClassModule PortModule { get; set; }
    public virtual ErrorString ErrorString { get; set; }
    public virtual TaskKindList TaskKind { get; set; }
    public virtual Table ModuleTable { get; set; }
    public virtual Table BinaryTable { get; set; }
    public virtual Table ImportClass { get; set; }
    public virtual bool ErrorWrite { get; set; }
    protected virtual StorageInfra StorageInfra { get; set; }
    protected virtual StorageComp StorageComp { get; set; }
    protected virtual BinaryRead BinaryRead { get; set; }
    protected virtual ModuleLoad ModuleLoad { get; set; }
    protected virtual PortRead PortRead { get; set; }
    protected virtual PortLoad PortLoad { get; set; }
    protected virtual ClassGen ClassGen { get; set; }
    protected virtual NameCheck NameCheck { get; set; }
    protected virtual Out Out { get; set; }
    protected virtual Out Err { get; set; }
    protected virtual Table InitModuleTable { get; set; }
    protected virtual Table InitBinaryTable { get; set; }
    protected virtual PortPort Port { get; set; }
    protected virtual ModuleRef ModuleRef { get; set; }
    protected virtual ModuleRefLess ModuleRefLess { get; set; }
    protected virtual String SInfo { get; set; }
    protected virtual String SMake { get; set; }
    protected virtual String SFlagD { get; set; }
    protected virtual String SFlagM { get; set; }
    protected virtual String SClassDotPort { get; set; }
    protected virtual String SDotCla { get; set; }
    
    protected virtual NameCheck CreateNameCheck()
    {
        NameCheck a;
        a = new NameCheck();
        a.Init();
        a.TextLess = this.TLess;
        a.CharLess = this.CharLess;
        a.CharForm = this.TForm;
        return a;
    }

    public virtual bool Load()
    {
        bool b;

        b = this.InfoGen.Load();
        if (!b)
        {
            return false;
        }

        return true;
    }

    protected virtual BinaryRead CreateBinaryRead()
    {
        BinaryRead a;
        a = new BinaryRead();
        a.Init();
        return a;
    }

    protected virtual ModuleLoad CreateModuleLoad()
    {
        ModuleLoad a;
        a = new ModuleLoad();
        a.Init();
        return a;
    }

    protected virtual PortLoad CreatePortLoad()
    {
        PortLoad a;
        a = new PortLoad();
        a.Init();
        a.NameCheck = this.NameCheck;
        return a;
    }

    protected virtual ClassGen CreateClassGen()
    {
        ClassGen a;
        a = new ClassGen();
        a.Init();
        return a;
    }

    public virtual bool ArgSet(Array arg)
    {
        this.Arg = arg;

        String aa;
        aa = null;
        bool b;
        b = (0 < arg.Count);
        if (!b)
        {
            return false;
        }
        if (b)
        {
            aa = (String)arg.GetAt(0);
        }

        bool ba;
        ba = this.TextSame(this.TA(aa), this.TB(this.SInfo));
        if (ba)
        {
            bool baa;
            baa = (2 < arg.Count);
            if (!baa)
            {
                return false;
            }
            String aaa;
            aaa = (String)arg.GetAt(1);
            String aab;
            aab = (String)arg.GetAt(2);

            String aac;
            aac = null;
            if (3 < arg.Count)
            {
                aac = (String)arg.GetAt(3);
            }

            String sourceFold;
            sourceFold = aaa;

            String destFold;
            destFold = aab;

            bool linkFileName;
            linkFileName = true;
            if (!(aac == null))
            {
                if (this.TextSame(this.TA(aac), this.TB(this.SFlagD)))
                {
                    linkFileName = false;
                }
            }

            ConsoleConsole oo;
            oo = ConsoleConsole.This;

            Task task;
            task = new Task();
            task.Init();
            task.Kind = this.TaskKind.Info;
            task.Source = sourceFold;
            task.Dest = destFold;
            task.ArgBool = linkFileName;
            task.Out = oo.Out;
            task.Err = oo.Err;

            this.Task = task;
        }

        bool bb;
        bb = this.TextSame(this.TA(aa), this.TB(this.SMake));
        if (bb)
        {
            bool bba;
            bba = (1 < arg.Count);
            if (!bba)
            {
                return false;
            }
            String aba;
            aba = (String)arg.GetAt(1);

            String abb;
            abb = null;
            if (2 < arg.Count)
            {
                abb = (String)arg.GetAt(2);
            }

            String sourceFold;
            sourceFold = aba;

            bool systemModule;
            systemModule = false;
            if (!(abb == null))
            {
                if (this.TextSame(this.TA(abb), this.TB(this.SFlagM)))
                {
                    systemModule = true;
                }
            }

            ConsoleConsole oo;
            oo = ConsoleConsole.This;

            Task task;
            task = new Task();
            task.Init();
            task.Kind = this.TaskKind.Console;
            task.Source = sourceFold;
            task.ArgBool = systemModule;
            task.Out = oo.Out;
            task.Err = oo.Err;

            this.Task = task;
        }
        return true;
    }

    public virtual bool Execute()
    {
        this.Status = 0;

        if (this.Task == null)
        {
            this.Status = 1000;
            return false;
        }

        this.Out = this.Task.Out;
        this.Err = this.Task.Err;

        TaskKindList kindList;
        kindList = this.TaskKind;
        TaskKind kind;
        kind = this.Task.Kind;

        bool b;
        b = (kind == kindList.Console | kind == kindList.Module);
        bool ba;
        ba = (kind == kindList.Token | kind == kindList.Node);
        bool bb;
        bb = (kind == kindList.Info);

        if (bb)
        {
            String sourceFoldPath;
            String destFoldPath;
            sourceFoldPath = this.Task.Source;
            destFoldPath = this.Task.Dest;
            bool linkFileName;
            linkFileName = this.Task.ArgBool;

            this.InfoGen.SourceFoldPath = sourceFoldPath;
            this.InfoGen.DestFoldPath = destFoldPath;
            this.InfoGen.LinkFileName = linkFileName;

            bool bba;
            bba = this.InfoGen.Execute();
            if (!bba)
            {
                this.Status = 30000;
                return false;
            }
            return true;
        }

        bool hasFileExtension;
        hasFileExtension = false;
        Array sourceNameList;
        sourceNameList = null;
        if (ba)
        {
            String file;
            file = this.Task.Source;

            long combineIndex;
            combineIndex = this.StorageInfra.EntryPathNameCombine(this.TA(file), this.TLess);

            String fileName;
            fileName = null;

            bool baaa;
            baaa = (combineIndex < 0);

            if (baaa)
            {
                fileName = file;

                this.SourceFold = this.StorageInfra.SDot;
            }

            if (!baaa)
            {
                fileName = this.StringCreateIndex(file, combineIndex + 1);

                this.SourceFold = this.StringCreateRange(file, 0, combineIndex);
            }

            sourceNameList = new Array();
            sourceNameList.Count = 1;
            sourceNameList.Init();
            sourceNameList.SetAt(0, fileName);
        }

        if (b)
        {
            this.SourceFold = this.Task.Source;

            if (this.SourceFold == null)
            {
                this.Status = 1001;
                return false;;
            }

            bool baa;
            baa = this.ReadPort();
            if (!baa)
            {
                this.Status = 1002;
                return false;
            }

            baa = this.PortModuleLoad();
            if (!baa)
            {
                return false;
            }

            hasFileExtension = true;
            sourceNameList = this.GetSourceNameList(this.SourceFold);
        }

        this.SetSource(sourceNameList);

        this.ReadSourceText(hasFileExtension);

        this.ExecuteCreate();

        this.WriteAllError();

        if (kind == kindList.Console)
        {
            if (this.CanGen())
            {
                this.ExecuteGen();
            }
        }

        if (this.Task.Print)
        {
            if (kind == kindList.Token)
            {
                this.PrintTokenResult();
            }
            if (kind == kindList.Node)
            {
                this.PrintNodeResult();
            }
            if (kind == kindList.Module)
            {
                this.PrintModuleResult();
            }
        }
        return true;
    }

    protected virtual bool ReadPort()
    {
        String combine;
        combine = this.TextInfra.PathCombine;

        String fileName;
        fileName = this.SClassDotPort;

        String filePath;
        filePath = this.AddClear().Add(this.SourceFold).Add(combine).Add(fileName).AddResult();

        String source;
        source = this.StorageInfra.TextRead(filePath);

        if (source == null)
        {
            return false;
        }

        PortRead read;
        read = this.PortRead;

        read.Source = source;
        read.Execute();

        PortPort port;
        port = read.Port;

        read.Source = null;
        read.Port = null;

        if (port == null)
        {
            return false;
        }

        this.Port = port;
        return true;
    }

    protected virtual bool PortModuleLoad()
    {
        this.BinaryTable = this.CopyModuleRefTable(this.InitBinaryTable);
        this.ModuleTable = this.CopyModuleRefTable(this.InitModuleTable);
        this.ImportClass = this.ClassInfra.TableCreateStringLess();
        PortLoad portLoad;
        portLoad = this.PortLoad;

        portLoad.Port = this.Port;
        portLoad.BinaryRead = this.BinaryRead;
        portLoad.ModuleLoad = this.ModuleLoad;
        portLoad.BinaryTable = this.BinaryTable;
        portLoad.ModuleTable = this.ModuleTable;
        portLoad.ImportClass = this.ImportClass;

        bool b;
        b = portLoad.Execute();

        if (!b)
        {
            this.Status = 3000 + portLoad.Status;
            return false;
        }

        this.PortModule = portLoad.Module;

        portLoad.Module = null;
        portLoad.ImportClass = null;
        portLoad.ModuleTable = null;
        portLoad.BinaryTable = null;
        portLoad.ModuleLoad = null;
        portLoad.BinaryRead = null;
        portLoad.Port = null;
        return true;
    }

    protected virtual Table CopyModuleRefTable(Table table)
    {
        ListInfra listInfra;
        listInfra = this.ListInfra;
        
        Table a;
        a = this.ClassInfra.TableCreateModuleRefLess();

        Iter iter;
        iter = table.IterCreate();
        table.IterSet(iter);

        while (iter.Next())
        {
            object aa;
            aa = iter.Index;
            object ab;
            ab = iter.Value;

            listInfra.TableAdd(a, aa, ab);
        }

        return a;
    }

    public virtual bool ExecuteCreate()
    {
        this.Create.Execute();

        this.Result = this.Create.Result;

        this.Create.Result = null;
        return true;
    }

    protected virtual bool ExecuteGen()
    {
        return true;
    }

    protected virtual Create CreateCreate()
    {
        Create a;
        a = new Create();
        a.Console = this;
        a.Init();
        return a;
    }

    protected virtual bool CanGen()
    {
        if (!(this.Result.Token == null))
        {
            if (0 < this.Result.Token.Error.Count)
            {
                return false;
            }
        }

        if (!(this.Result.Node == null))
        {
            if (0 < this.Result.Node.Error.Count)
            {
                return false;
            }
        }

        if (!(this.Result.Module == null))
        {
            if (0 < this.Result.Module.Error.Count)
            {
                return false;
            }
        }

        return true;
    }

    protected virtual bool WriteAllError()
    {
        if (!this.ErrorWrite)
        {
            return true;
        }

        TaskKindList kindList;
        kindList = this.TaskKind;

        TaskKind kind;
        kind = this.Task.Kind;

        bool kindConsole;
        kindConsole = (kind == kindList.Console);

        if (kindConsole | (kind == kindList.Token))
        {
            if (!(this.Result.Token == null))
            {
                this.WriteErrorList(this.Result.Token.Error);
            }
        }

        if (kindConsole | (kind == kindList.Node))
        {
            if (!(this.Result.Node == null))
            {
                this.WriteErrorList(this.Result.Node.Error);
            }
        }

        if (kindConsole | (kind == kindList.Module))
        {
            if (!(this.Result.Module == null))
            {
                this.WriteErrorList(this.Result.Module.Error);
            }
        }
        return true;
    }

    protected virtual bool WriteErrorList(Array errorList)
    {
        long count;
        count = errorList.Count;
        long i;
        i = 0;
        while (i < count)
        {
            Error a;
            a = (Error)errorList.GetAt(i);
            this.WriteError(a);
            i = i + 1;
        }
        return true;
    }

    protected virtual bool WriteError(Error error)
    {
        String a;
        a = this.ErrorString.Execute(error);
        this.Err.Write(a);
        return true;
    }

    protected virtual bool PrintModuleResult()
    {
        return true;
    }

    protected virtual bool PrintNodeResult()
    {
        ObjectString objectString;
        objectString = new ObjectString();
        objectString.Init();

        Iter rootIter;
        rootIter = this.Result.Node.Root.IterCreate();
        this.Result.Node.Root.IterSet(rootIter);

        while (rootIter.Next())
        {
            NodeNode root;
            root = (NodeNode)rootIter.Value;

            objectString.Execute(root);

            String a;
            a = objectString.Result();

            this.Out.Write(a);
        }
        return true;
    }

    protected virtual bool PrintTokenResult()
    {
        ObjectString objectString;
        objectString = new ObjectString();
        objectString.Init();

        Iter codeIter;
        codeIter = this.Result.Token.Code.IterCreate();
        this.Result.Token.Code.IterSet(codeIter);
        while (codeIter.Next())
        {
            Code code;
            code = (Code)codeIter.Value;
            
            objectString.Execute(code);
            
            String a;
            a = objectString.Result();

            this.Out.Write(a);
        }
        return true;
    }

    protected virtual Array GetFileList(String foldPath)
    {
        Array a;
        a = this.StorageComp.FileList(foldPath);

        return a;
    }

    protected virtual Array GetSourceNameList(String foldPath)
    {
        Array fileArray;
        fileArray = this.GetFileList(foldPath);

        List list;
        list = new List();
        list.Init();

        String ka;
        ka = this.SDotCla;

        long count;
        count = fileArray.Count;
        long i;
        i = 0;
        while (i < count)
        {
            String fileName;
            fileName = (String)fileArray.GetAt(i);

            Text k;
            k = this.TextAlphaSite(this.TA(fileName));

            if (this.TextEnd(k, this.TB(ka)))
            {
                long ke;
                ke = k.Range.Count - this.StringCount(ka);

                String name;
                name = this.StringCreateTextRange(k, 0, ke);

                list.Add(name);
            }

            i = i + 1;
        }

        Array a;
        a = this.ListInfra.ArrayCreateList(list);
        return a;
    }

    protected virtual bool SetSource(Array array)
    {
        long count;
        count = array.Count;
        long i;
        i = 0;
        while (i < count)
        {
            String name;
            name = (String)array.GetAt(i);

            Source a;
            a = new Source();
            a.Init();
            a.Index = i;
            a.Name = name;

            array.SetAt(i, a);
            i = i + 1;
        }

        this.Source = array;
        return true;
    }

    protected virtual bool ReadSourceText(bool hasFileExtension)
    {
        InfraInfra infraInfra;
        infraInfra = this.InfraInfra;
        TextInfra textInfra;
        textInfra = this.TextInfra;
        ClassInfra classInfra;
        classInfra = this.ClassInfra;

        Array array;
        array = this.Source;
        String sourceFold;
        sourceFold = this.SourceFold;

        String combine;
        combine = textInfra.PathCombine;
        
        long count;
        count = array.Count;
        long i;
        i = 0;
        while (i < count)
        {
            Source a;
            a = (Source)array.GetAt(i);

            String k;
            k = textInfra.Zero;
            if (hasFileExtension)
            {
                k = this.SDotCla;
            }

            String filePath;
            filePath = this.AddClear().Add(sourceFold).Add(combine).Add(a.Name).Add(k).AddResult();

            String h;
            h = this.StorageInfra.TextRead(filePath);

            Text aa;
            aa = textInfra.TextCreateStringData(h, null);

            Array text;
            text = this.TextLimit(aa, this.TA(this.ClassInfra.NewLine));
   
            a.Text = text;

            i = i + 1;
        }
        return true;
    }

    protected virtual bool Error(String message)
    {
        this.Err.Write(this.AddClear().Add(message).Add(this.ClassInfra.NewLine).AddResult());
        return true;
    }
}