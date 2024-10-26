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
        this.BinaryWrite = this.CreateBinaryWrite();

        this.ModuleLoad = this.CreateModuleLoad();

        this.PortLoad = this.CreatePortLoad();

        this.BinaryGen = this.CreateBinaryGen();

        this.ClassGen = this.CreateClassGen();

        this.ModuleGen = this.CreateModuleGen();

        this.ProjectGen = this.CreateProjectGen();

        this.ErrorString = new ErrorString();
        this.ErrorString.Init();

        this.Create = this.CreateCreate();

        this.InfoGen = new InfoGen();
        this.InfoGen.Init();

        this.PortRead = new PortRead();
        this.PortRead.Init();

        this.ModuleRef = this.ClassInfra.ModuleRefCreate(null, 0);

        this.ModuleRefLess = new ModuleRefLess();
        this.ModuleRefLess.Init();

        this.SClass = this.S("Class");
        this.SInfo = this.S("info");
        this.SMake = this.S("make");
        this.SFlagD = this.S("-d");
        this.SFlagM = this.S("-m");
        this.SClassDotPort = this.S("Class.Port");
        this.SDotCla = this.S(".cla");
        this.SSystemDotInfra = this.S("System.Infra");
        this.SIntern = this.S("Intern");
        this.SExtern = this.S("Extern");
        this.SRef = this.S("ref");
        this.SC = this.S("c");
        this.SPro = this.S("pro");
        this.SModule = this.S("Module");
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
    protected virtual BinaryWrite BinaryWrite { get; set; }
    protected virtual ModuleLoad ModuleLoad { get; set; }
    protected virtual PortRead PortRead { get; set; }
    protected virtual PortLoad PortLoad { get; set; }
    protected virtual BinaryGen BinaryGen { get; set; }
    protected virtual ClassGen ClassGen { get; set; }
    protected virtual ModuleGen ModuleGen { get; set; }
    protected virtual ProjectGen ProjectGen { get; set; }
    protected virtual NameCheck NameCheck { get; set; }
    protected virtual Out Out { get; set; }
    protected virtual Out Err { get; set; }
    protected virtual PortPort Port { get; set; }
    protected virtual bool MakeSystemModule { get; set; }
    protected virtual String ModuleProjectText { get; set; }
    protected virtual ModuleRef ModuleRef { get; set; }
    protected virtual ModuleRefLess ModuleRefLess { get; set; }
    protected virtual String SClass { get; set; }
    protected virtual String SInfo { get; set; }
    protected virtual String SMake { get; set; }
    protected virtual String SFlagD { get; set; }
    protected virtual String SFlagM { get; set; }
    protected virtual String SClassDotPort { get; set; }
    protected virtual String SDotCla { get; set; }
    protected virtual String SSystemDotInfra { get; set; }
    protected virtual String SIntern { get; set; }
    protected virtual String SExtern { get; set; }
    protected virtual String SRef { get; set; }
    protected virtual String SC { get; set; }
    protected virtual String SPro { get; set; }
    protected virtual String SModule { get; set; }

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

        this.ModuleProjectText = this.StorageInfra.TextRead(this.S("Saber.Console.data/ModuleProject.txt"));

        if (this.ModuleProjectText == null)
        {
            return false;
        }

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

    protected virtual BinaryWrite CreateBinaryWrite()
    {
        BinaryWrite a;
        a = new BinaryWrite();
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


    protected virtual BinaryGen CreateBinaryGen()
    {
        BinaryGen a;
        a = new BinaryGen();
        a.Init();
        return a;
    }

    protected virtual ClassGen CreateClassGen()
    {
        ClassGen a;
        a = new ClassGen();
        a.Init();
        return a;
    }

    protected virtual ModuleGen CreateModuleGen()
    {
        ModuleGen a;
        a = new ModuleGen();
        a.Init();
        return a;
    }

    protected virtual ProjectGen CreateProjectGen()
    {
        ProjectGen a;
        a = new ProjectGen();
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
            task.Node = this.SClass;
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

            this.MakeSystemModule = this.Task.ArgBool;

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

        if (kind == kindList.Console)
        {
            if (this.CanGen())
            {
                bool bea;
                bea = this.ExecuteGen();
                if (!bea)
                {
                    return false;
                }
            }

            this.ErrorString.RangePos = true;
            this.ErrorString.CodeArray = this.Result.Token.Code;
        }

        this.WriteAllError();

        if (this.Task.Print)
        {
            if (kind == kindList.Token)
            {
                this.PrintTokenResult();
            }
            if (kind == kindList.Node | kind == kindList.Console)
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
        this.BinaryTable = this.ClassInfra.TableCreateModuleRefLess();
        this.ModuleTable = this.ClassInfra.TableCreateModuleRefLess();
        this.ImportClass = this.ClassInfra.TableCreateStringLess();
        PortLoad portLoad;
        portLoad = this.PortLoad;

        portLoad.Port = this.Port;
        portLoad.BinaryRead = this.BinaryRead;
        portLoad.ModuleLoad = this.ModuleLoad;
        portLoad.BinaryTable = this.BinaryTable;
        portLoad.ModuleTable = this.ModuleTable;
        portLoad.ImportClass = this.ImportClass;
        portLoad.SystemModule = this.MakeSystemModule;

        bool b;
        b = portLoad.Execute();

        if (!b)
        {
            this.Status = 3000 + portLoad.Status;
            return false;
        }

        this.PortModule = portLoad.Module;

        portLoad.Module = null;
        portLoad.SystemModule = false;
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
        ClassModule module;
        module = this.Result.Module.Module;

        ClassModule systemInfraModule;
        systemInfraModule = null;

        bool b;
        b = this.TextSame(this.TA(module.Ref.Name), this.TB(this.SSystemDotInfra));

        if (b)
        {
            systemInfraModule = module;
        }

        if (!b)
        {
            this.ModuleRef.Name = this.SSystemDotInfra;
            this.ModuleRef.Ver = 0;

            systemInfraModule = (ClassModule)this.ModuleTable.Get(this.ModuleRef);
        }

        String verString;
        verString = this.ClassInfra.VerString(module.Ref.Ver);

        String moduleRefString;
        moduleRefString = this.ClassInfra.ModuleRefString(module.Ref.Name, verString);

        bool ba;
        ba = this.ExecuteGenBinary(moduleRefString);
        
        if (!ba)
        {
            return false;
        }

        ClassClass internClass;
        ClassClass externClass;
        internClass = (ClassClass)systemInfraModule.Class.Get(this.SIntern);
        externClass = (ClassClass)systemInfraModule.Class.Get(this.SExtern);

        this.ClassGen.InternClass = internClass;
        this.ClassGen.ExternClass = externClass;
        this.ClassGen.System = this.Create.Module.SystemClass;
        this.ClassGen.ImportClass = this.ImportClass;

        String genFoldPath;
        genFoldPath = this.S("Saber.Console.Data/Gen");

        String combine;
        combine = this.TextInfra.PathCombine;

        String genModuleFoldPath;
        genModuleFoldPath = this.AddClear().Add(genFoldPath).Add(combine).Add(moduleRefString).AddResult();

        this.StorageComp.FoldDelete(genModuleFoldPath);

        bool baa;
        baa = this.StorageComp.FoldCreate(genModuleFoldPath);

        if (!baa)
        {
            this.Status = 5000 + 15;
            return false;
        }

        Iter iter;
        iter = module.Class.IterCreate();
        module.Class.IterSet(iter);
        
        long count;
        count = module.Class.Count;
        long i;
        i = 0;
        while (i < count)
        {
            iter.Next();

            ClassClass varClass;
            varClass = (ClassClass)iter.Value;

            this.ClassGen.Class = varClass;

            this.ClassGen.Execute();

            String k;
            k = this.ClassGen.Result;

            this.ClassGen.Result = null;
            this.ClassGen.Class = null;

            String ka;
            ka = this.StringIntHex(i);

            String fileName;
            fileName = this.AddClear().AddChar('C').Add(ka).Add(this.ClassInfra.Dot).Add(this.SC).AddResult();

            String filePath;
            filePath = this.AddClear().Add(genModuleFoldPath).Add(combine).Add(fileName).AddResult();

            bool bab;
            bab = this.StorageInfra.TextWrite(filePath, k);

            if (!bab)
            {
                this.Status = 5000 + 20;
                return false;
            }

            i = i + 1;
        }

        bool bb;
        bb = this.GenModuleSource(genModuleFoldPath);
        if (!bb)
        {
            return false;
        }

        bool bc;
        bc = this.ExecuteGenProject(moduleRefString, genModuleFoldPath);
        if (!bc)
        {
            return false;
        }

        bool bd;
        bd = this.ExecuteGenMake(moduleRefString);
        if (!bd)
        {
            return false;
        }

        return true;
    }

    protected virtual bool ExecuteGenBinary(String moduleRefString)
    {
        ClassModule module;
        module = this.Result.Module.Module;

        this.BinaryGen.Module = module;

        this.BinaryGen.Execute();

        BinaryBinary binary;
        binary = this.BinaryGen.Result;

        this.BinaryGen.Result = null;
        this.BinaryGen.Module = null;

        this.BinaryWrite.Binary = binary;

        this.BinaryWrite.Execute();

        Data data;
        data = this.BinaryWrite.Data;

        this.BinaryWrite.Data = null;
        this.BinaryWrite.Binary = null;

        String filePath;
        filePath = this.AddClear().Add(moduleRefString).Add(this.ClassInfra.Dot).Add(this.SRef).AddResult();

        bool b;
        b = this.StorageInfra.DataWrite(filePath, data);

        if (!b)
        {
            this.Status = 5000 + 10;
            return false;
        }

        return true;
    }


    protected virtual bool GenModuleSource(String genModuleFoldPath)
    {
        this.ModuleGen.Gen = this.ClassGen;
        this.ModuleGen.Module = this.Result.Module.Module;

        this.ModuleGen.Execute();
        String k;
        k = this.ModuleGen.Result;

        this.ModuleGen.Result = null;
        this.ModuleGen.Module = null;
        this.ModuleGen.Gen = null;

        String fileName;
        fileName = this.AddClear().Add(this.SModule).Add(this.ClassInfra.Dot).Add(this.SC).AddResult();

        String filePath;
        filePath = this.AddClear().Add(genModuleFoldPath).Add(this.TextInfra.PathCombine).Add(fileName).AddResult();

        bool b;
        b = this.StorageInfra.TextWrite(filePath, k);

        if (!b)
        {
            this.Status = 5000 + 30;
            return false;
        }

        return true;
    }

    protected virtual bool ExecuteGenProject(String moduleRefString, String genModuleFoldPath)
    {
        Array moduleRefStringArray;
        moduleRefStringArray = this.ModuleRefStringArray();

        this.ProjectGen.Gen = this.ClassGen;
        this.ProjectGen.ModuleRefString = moduleRefStringArray;

        this.ProjectGen.Execute();

        String import;
        import = this.ProjectGen.Result;

        this.ProjectGen.Result = null;
        this.ProjectGen.ModuleRefString = null;
        this.ProjectGen.Gen = null;

        Text k;
        k = this.TA(this.ModuleProjectText);
        k = this.Place(k, "#Import#", import);

        String ka;
        ka = this.StringCreate(k);

        String fileName;
        fileName = this.AddClear().Add(this.SModule).Add(this.ClassInfra.Dot).Add(this.SPro).AddResult();

        String filePath;
        filePath = this.AddClear().Add(genModuleFoldPath).Add(this.TextInfra.PathCombine).Add(fileName).AddResult();

        bool b;
        b = this.StorageInfra.TextWrite(filePath, ka);

        if (!b)
        {
            this.Status = 5000 + 40;
            return false;
        }

        return true;
    }

    protected virtual Array ModuleRefStringArray()
    {
        long count;
        count = this.ModuleTable.Count;

        Array array;
        array = this.ListInfra.ArrayCreate(count);

        Iter iter;
        iter = this.ModuleTable.IterCreate();
        this.ModuleTable.IterSet(iter);

        long i;
        i = 0;
        while (i < count)
        {
            iter.Next();

            ModuleRef k;
            k = (ModuleRef)iter.Index;

            String verString;
            verString = this.ClassInfra.VerString(k.Ver);

            String a;
            a = this.ClassInfra.ModuleRefString(k.Name, verString);

            array.SetAt(i, a);

            i = i + 1;
        }

        return array;
    }

    protected virtual bool ExecuteGenMake(String moduleRefString)
    {
        List list;
        list = new List();
        list.Init();
        list.Add(this.S("/c"));
        list.Add(this.AddClear().AddS("Make.cmd ").Add(moduleRefString).AddResult());

        Program program;
        program = new Program();
        program.Init();
        program.Name = this.S("cmd.exe");
        program.Argue = list;
        program.WorkFold = this.S("Saber.Console.data");
        program.Environ = null;

        program.Execute();

        program.Wait();

        long k;
        k = program.Status;

        program.Final();

        if (!(k == 0))
        {
            this.Status = 5000 + 50;
            return false;
        }

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
                name = this.StringCreateTextRange(this.TA(fileName), 0, ke);

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