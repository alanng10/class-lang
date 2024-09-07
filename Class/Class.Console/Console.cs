namespace Class.Console;

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
        this.SFlagD = this.S("-d");
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
    public virtual Table ClassTable { get; set; }
    public virtual Table ImportTable { get; set; }
    public virtual Table ExportTable { get; set; }
    public virtual bool ErrorWrite { get; set; }
    protected virtual StorageInfra StorageInfra { get; set; }
    protected virtual BinaryRead BinaryRead { get; set; }
    protected virtual ModuleLoad ModuleLoad { get; set; }
    protected virtual PortRead PortRead { get; set; }
    protected virtual PortLoad PortLoad { get; set; }
    protected virtual NameCheck NameCheck { get; set; }
    protected virtual Out Out { get; set; }
    protected virtual Out Err { get; set; }
    protected virtual Table InitModuleTable { get; set; }
    protected virtual Table InitBinaryTable { get; set; }
    protected virtual PortPort Port { get; set; }
    protected virtual ModuleRef ModuleRef { get; set; }
    protected virtual ModuleRefLess ModuleRefLess { get; set; }
    protected virtual String SInfo { get; set; }
    protected virtual String SFlagD { get; set; }
    protected virtual String SClassDotPort { get; set; }
    protected virtual String SDotCla { get; set; }
    private StorageComp StorageComp { get; set; }
    
    protected virtual NameCheck CreateNameCheck()
    {
        NameCheck a;
        a = new NameCheck();
        a.Init();
        a.TextLess = this.TextLess;
        a.CharLess = this.CharLess;
        a.CharForm = this.TextForm;
        return a;
    }

    public virtual bool Load()
    {
        // List list;
        // list = new List();
        // list.Init();

        // list.Add("System.Infra");
        // list.Add("System.List");
        // list.Add("System.Math");
        // list.Add("System.Text");
        // list.Add("System.Event");
        // list.Add("System.Comp");
        // list.Add("System.Thread");
        // list.Add("System.Stream");
        // list.Add("System.Type");
        // list.Add("System.Time");
        // list.Add("System.Storage");
        // list.Add("System.Network");
        // list.Add("System.Console");
        // list.Add("System.Draw");
        // list.Add("System.View");
        // list.Add("System.Media");
        // list.Add("System.Entry");
        // list.Add("Class.Infra");
        // list.Add("Class.Binary");
        // list.Add("Class.Info");
        // list.Add("Class.Port");
        // list.Add("Class.Token");
        // list.Add("Class.Node");
        // list.Add("Class.Module");
        // list.Add("Class.Console");

        // Iter iter;
        // iter = list.IterCreate();
        // list.IterSet(iter);
        // while (iter.Next())
        // {
        //     string a;
        //     a = (string)iter.Value;
            
        //     bool ba;
        //     ba = this.InitBinary(a);
        //     if (!ba)
        //     {
        //         return false;
        //     }
        // }

        bool b;
        // b = this.InitModuleList();
        // if (!b)
        // {
        //     return false;
        // }

        b = this.InfoGen.Load();
        if (!b)
        {
            return false;
        }

        return true;
    }

    protected virtual bool InitBinary(String moduleName)
    {
        String filePath;
        filePath = this.AddClear().Add(moduleName).AddS(".ref").AddResult();

        Data data;
        data = this.StorageInfra.DataReadAny(filePath, true);

        if (data == null)
        {
            this.Status = 100;
            return false;
        }

        int kk;
        kk = (int)data.Count;

        InfraRange range;
        range = new InfraRange();
        range.Init();
        range.Count = kk;

        BinaryRead read;
        read = this.BinaryRead;

        read.Data = data;
        read.Range = range;

        read.Execute();

        BinaryBinary binary;
        binary = read.Binary;

        read.Binary = null;
        read.Range = null;
        read.Data = null;

        if (binary == null)
        {
            this.Status = 101;
            return false;
        }

        ModuleRef ka;
        ka = this.ModuleRef;
        ka.Name = moduleName;

        if (!(this.ModuleRefLess.Execute(ka, binary.Ref) == 0))
        {
            this.Status = 102;
            return false;
        }

        this.ListInfra.TableAdd(this.InitBinaryTable, binary.Ref, binary);
        return true;
    }

    protected virtual bool InitModuleList()
    {
        this.ModuleLoad.ModuleTable = this.InitModuleTable;
        this.ModuleLoad.BinaryTable = this.InitBinaryTable;

        Iter iter;
        iter = this.InitBinaryTable.IterCreate();
        this.InitBinaryTable.IterSet(iter);

        while (iter.Next())
        {
            ModuleRef moduleRef;
            moduleRef = (ModuleRef)iter.Index;

            this.ModuleLoad.ModuleRef = moduleRef;
            
            bool b;
            b = this.ModuleLoad.Execute();
            if (!b)
            {
                long o;
                o = this.ModuleLoad.Status;
                if (!(o == 0))
                {
                    this.Status = 200 + o;
                    return false;
                }
            }

            ClassModule a;
            a = this.ModuleLoad.Module;

            this.ModuleLoad.Module = null;

            this.ListInfra.TableAdd(this.InitModuleTable, a.Ref, a);
        }

        this.ModuleLoad.ModuleTable = null;
        this.ModuleLoad.BinaryTable = null;
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
        a.NameCheck = this.NameCheck;
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

            String executeFoldPath;
            executeFoldPath = this.StorageComp.ExecuteFoldPath;

            String combine;
            combine = this.TextInfra.PathCombine;

            StorageInfra storageInfra;
            storageInfra = this.StorageInfra;

            TextLess less;
            less = this.TextLess;

            String sourceFold;
            sourceFold = aaa;

            if (storageInfra.IsRelativePath(this.TA(sourceFold), less))
            {
                sourceFold = this.AddClear().Add(executeFoldPath).Add(combine).Add(sourceFold).AddResult();
            }

            String destFold;
            destFold = aab;

            if (storageInfra.IsRelativePath(this.TA(destFold), less))
            {
                destFold = this.AddClear().Add(executeFoldPath).Add(combine).Add(destFold).AddResult();
            }

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
            combineIndex = this.StorageInfra.EntryPathNameCombine(this.TA(file), this.TextLess);

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
        source = this.StorageInfra.TextReadAny(filePath, true);

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
        this.ClassTable = this.ClassInfra.TableCreateStringLess();
        this.ImportTable = this.ClassInfra.TableCreateModuleRefLess();
        this.ExportTable = this.ClassInfra.TableCreateStringLess();

        PortLoad portLoad;
        portLoad = this.PortLoad;

        portLoad.Port = this.Port;
        portLoad.BinaryRead = this.BinaryRead;
        portLoad.ModuleLoad = this.ModuleLoad;
        portLoad.BinaryTable = this.BinaryTable;
        portLoad.ModuleTable = this.ModuleTable;
        portLoad.ClassTable = this.ClassTable;
        portLoad.ImportTable = this.ImportTable;
        portLoad.ExportTable = this.ExportTable;

        bool b;
        b = portLoad.Execute();

        if (!b)
        {
            this.Status = 1800 + portLoad.Status;
            return false;
        }

        this.PortModule = portLoad.Module;

        portLoad.Module = null;
        portLoad.ExportTable = null;
        portLoad.ImportTable = null;
        portLoad.ClassTable = null;
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

    protected virtual Create CreateCreate()
    {
        Create a;
        a = new Create();
        a.Console = this;
        a.Init();
        return a;
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
        StorageInfra storageInfra;
        storageInfra = this.StorageInfra;

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
            h = storageInfra.TextReadAny(filePath, true);

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