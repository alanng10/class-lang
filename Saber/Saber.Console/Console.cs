namespace Saber.Console;

public class Console : TextAdd
{
    public override bool Init()
    {
        base.Init();
        this.ListInfra = ListInfra.This;
        this.StorageInfra = StorageInfra.This;
        this.ClassInfra = ClassInfra.This;
        this.StorageComp = StorageComp.This;
        this.TaskKind = TaskKindList.This;

        this.ErrorWrite = true;
        this.Create = this.CreateCreate();
        this.PortRead = this.CreatePortRead();
        this.BinaryRead = this.CreateBinaryRead();
        this.BinaryWrite = this.CreateBinaryWrite();
        this.ModulePort = this.CreateModulePort();
        this.PortLoad = this.CreatePortLoad();
        this.BinaryGen = this.CreateBinaryGen();
        this.StorageGen = this.CreateStorageGen();
        this.LibraryGen = this.CreateLibraryGen();
        this.ErrorString = this.CreateErrorString();
        this.InfoToken = this.CreateInfoToken();
        this.InfoTravel = this.CreateInfoTravel();
        this.NameValid = this.CreateNameValid();
        this.ModuleRefLess = this.CreateModuleRefLess();
        this.StorageNameLess = this.CreateStorageNameLess();

        this.SClass = this.S("Class");
        this.SDocue = this.S("docue");
        this.SMake = this.S("make");
        this.SLibrary = this.S("library");
        this.SFlagM = this.S("-m");
        this.SClassDotPort = this.S("Class.Port");
        this.SDotCl = this.S(".cl");
        this.SModule = this.S("Module");
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

    protected virtual PortRead CreatePortRead()
    {
        PortRead a;
        a = new PortRead();
        a.Init();
        return a;
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

    protected virtual ModulePort CreateModulePort()
    {
        ModulePort a;
        a = new ModulePort();
        a.Init();
        return a;
    }

    protected virtual PortLoad CreatePortLoad()
    {
        PortLoad a;
        a = new PortLoad();
        a.Init();
        return a;
    }

    protected virtual BinaryGen CreateBinaryGen()
    {
        BinaryGen a;
        a = new BinaryGen();
        a.Init();
        return a;
    }

    protected virtual StorageGen CreateStorageGen()
    {
        StorageGen a;
        a = new StorageGen();
        a.Init();
        return a;
    }

    protected virtual LibraryGen CreateLibraryGen()
    {
        LibraryGen a;
        a = new LibraryGen();
        a.Init();
        return a;
    }

    protected virtual ErrorString CreateErrorString()
    {
        ErrorString a;
        a = new ErrorString();
        a.Init();
        return a;
    }

    protected virtual InfoToken CreateInfoToken()
    {
        InfoToken a;
        a = new InfoToken();
        a.Init();
        return a;
    }

    protected virtual InfoTravel CreateInfoTravel()
    {
        InfoTravel a;
        a = new InfoTravel();
        a.Init();
        return a;
    }

    protected virtual NameValid CreateNameValid()
    {
        NameValid a;
        a = new NameValid();
        a.Init();
        return a;
    }

    protected virtual ModuleRefLess CreateModuleRefLess()
    {
        ModuleRefLess a;
        a = new ModuleRefLess();
        a.Init();
        return a;
    }

    protected virtual TextLess CreateStorageNameLess()
    {
        TextLess a;
        a = new TextLess();
        a.LiteForm = this.StorageInfra.NameForm;
        a.RiteForm = this.StorageInfra.NameForm;
        a.CharLess = this.ILess;
        a.Init();
        return a;
    }

    public virtual long Status { get; set; }
    public virtual Array Arg { get; set; }
    public virtual Task Task { get; set; }
    public virtual Array Source { get; set; }
    public virtual String SourceFold { get; set; }
    public virtual Create Create { get; set; }
    public virtual Result Result { get; set; }
    public virtual ClassModule PortModule { get; set; }
    public virtual TaskKindList TaskKind { get; set; }
    public virtual Table ModuleTable { get; set; }
    public virtual Table ImportClass { get; set; }
    public virtual bool ErrorWrite { get; set; }
    protected virtual ListInfra ListInfra { get; set; }
    protected virtual StorageInfra StorageInfra { get; set; }
    protected virtual ClassInfra ClassInfra { get; set; }
    protected virtual StorageComp StorageComp { get; set; }
    protected virtual BinaryRead BinaryRead { get; set; }
    protected virtual BinaryWrite BinaryWrite { get; set; }
    protected virtual ModulePort ModulePort { get; set; }
    protected virtual PortRead PortRead { get; set; }
    protected virtual PortLoad PortLoad { get; set; }
    protected virtual BinaryGen BinaryGen { get; set; }
    protected virtual LibraryGen LibraryGen { get; set; }
    protected virtual StorageGen StorageGen { get; set; }
    protected virtual ErrorString ErrorString { get; set; }
    protected virtual NameValid NameValid { get; set; }
    protected virtual InfoToken InfoToken { get; set; }
    protected virtual InfoTravel InfoTravel { get; set; }
    protected virtual Out Out { get; set; }
    protected virtual Out Err { get; set; }
    protected virtual String ClassPath { get; set; }
    protected virtual PortPort Port { get; set; }
    protected virtual Array PortError { get; set; }
    protected virtual bool MakeSystem { get; set; }
    protected virtual ModuleRefLess ModuleRefLess { get; set; }
    protected virtual TextLess StorageNameLess { get; set; }
    protected virtual String SClass { get; set; }
    protected virtual String SDocue { get; set; }
    protected virtual String SMake { get; set; }
    protected virtual String SLibrary { get; set; }
    protected virtual String SFlagM { get; set; }
    protected virtual String SClassDotPort { get; set; }
    protected virtual String SDotCl { get; set; }
    protected virtual String SModule { get; set; }

    public virtual bool Load()
    {
        this.ClassPath = this.StorageInfra.TextRead(this.S("Saber.Console.data/ClassPath.txt"));

        if (this.ClassPath == null)
        {
            return false;
        }

        bool b;

        b = this.LibraryGen.Load();
        if (!b)
        {
            return false;
        }

        return true;
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
            aa = arg.GetAt(0) as String;
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
            aba = arg.GetAt(1) as String;

            String abb;
            abb = null;
            if (2 < arg.Count)
            {
                abb = arg.GetAt(2) as String;
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
            oo = new ConsoleConsole();
            oo.Init();

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

        bool bc;
        bc = this.TextSame(this.TA(aa), this.TB(this.SLibrary));
        if (bc)
        {
            bool bca;
            bca = (1 < arg.Count);
            if (!bca)
            {
                return false;
            }
            String aca;
            aca = arg.GetAt(1) as String;

            String moduleRefString;
            moduleRefString = aca;

            ConsoleConsole oo;
            oo = new ConsoleConsole();
            oo.Init();

            Task task;
            task = new Task();
            task.Init();
            task.Kind = this.TaskKind.Library;
            task.Source = moduleRefString;
            task.ArgBool = false;
            task.Node = null;
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
        bb = (kind == kindList.Library);

        if (bb)
        {
            ModuleRef moduleRef;
            moduleRef = this.ModuleRefFromString(this.Task.Source);

            if (moduleRef == null)
            {
                this.Status = 1200;
                return false;
            }

            bool bba;
            bba = this.ExecuteGenLibrary(moduleRef);

            if (!bba)
            {
                return false;
            }

            return true;
        }

        bool fileExtend;
        fileExtend = false;
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
            baaa = (combineIndex == -1);

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

            sourceNameList = this.ListInfra.ArrayCreate(1);
            sourceNameList.SetAt(0, fileName);
        }

        if (b)
        {
            this.SourceFold = this.Task.Source;

            this.MakeSystem = this.Task.ArgBool;

            if (this.SourceFold == null)
            {
                this.Status = 1010;
                return false;
            }

            bool baa;
            baa = this.ReadPort();
            if (!baa)
            {
                this.Status = 1100;
                return false;
            }

            baa = this.PortModuleLoad();
            if (!baa)
            {
                this.WriteErrorList(this.PortError);
                return false;
            }

            fileExtend = true;
            sourceNameList = this.SourceNameList(this.SourceFold);
        }

        this.SetSource(sourceNameList);

        this.ReadSourceText(fileExtend);

        this.ExecuteCreate();

        this.ErrorString.SourceArray = this.Source;

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

        Array lineArray;
        lineArray = this.TextLine(this.TextCreate(source));

        PortRead read;
        read = this.PortRead;

        read.Source = lineArray;

        read.Execute();

        PortPort port;
        port = read.Result;

        read.Result = null;
        read.Source = null;

        if (port == null)
        {
            return false;
        }

        this.Port = port;
        return true;
    }

    protected virtual bool PortModuleLoad()
    {
        this.ModuleTable = this.ClassInfra.TableCreateModuleRefLess();
        this.ImportClass = this.ClassInfra.TableCreateStringLess();

        PortLoad portLoad;
        portLoad = this.PortLoad;

        portLoad.Port = this.Port;
        portLoad.BinaryRead = this.BinaryRead;
        portLoad.ModulePort = this.ModulePort;
        portLoad.ModuleTable = this.ModuleTable;
        portLoad.ImportClass = this.ImportClass;
        portLoad.NameValid = this.NameValid;
        portLoad.SystemModule = this.MakeSystem;
        portLoad.ClassPath = this.ClassPath;
        portLoad.SourceFold = this.SourceFold;

        bool b;
        b = portLoad.Execute();

        if (!b)
        {
            this.Status = 3000 + portLoad.Status;
            this.PortError = portLoad.Error;
            return false;
        }

        this.PortModule = portLoad.Module;

        portLoad.Error = null;
        portLoad.Module = null;
        portLoad.SourceFold = null;
        portLoad.ClassPath = null;
        portLoad.SystemModule = false;
        portLoad.NameValid = null;
        portLoad.ImportClass = null;
        portLoad.ModuleTable = null;
        portLoad.ModulePort = null;
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

        String moduleRefString;
        moduleRefString = this.ClassInfra.ModuleRefString(module.Ref);

        bool ba;
        ba = this.ExecuteGenBinary(moduleRefString);

        if (!ba)
        {
            return false;
        }

        this.StorageGen.Module = module;
        this.StorageGen.ClassPath = this.ClassPath;

        bool bc;
        bc = this.StorageGen.Execute();

        this.StorageGen.ClassPath = null;
        this.StorageGen.Module = null;

        if (!bc)
        {
            this.Status = 5200;
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
        data = this.BinaryWrite.Result;

        this.BinaryWrite.Result = null;
        this.BinaryWrite.Binary = null;

        String foldPath;
        foldPath = this.AddClear().Add(this.ClassInfra.ClassModulePath(this.ClassPath))
            .Add(this.TextInfra.PathCombine)
            .Add(moduleRefString).AddResult();

        this.StorageComp.FoldDelete(foldPath);

        this.StorageComp.FoldCreate(foldPath);

        StorageEntry entry;
        entry = this.StorageComp.Entry(foldPath);

        if (!entry.Exist)
        {
            this.Status = 5000 + 10;
            return false;
        }

        if (!entry.Fold)
        {
            this.Status = 5000 + 20;
            return false;
        }

        String filePath;
        filePath = this.AddClear().Add(foldPath).Add(this.TextInfra.PathCombine)
            .Add(this.SModule).AddResult();

        bool b;
        b = this.StorageInfra.DataWrite(filePath, data);

        if (!b)
        {
            this.Status = 5000 + 30;
            return false;
        }

        return true;
    }

    protected virtual bool ExecuteGenLibrary(ModuleRef moduleRef)
    {
        this.LibraryGen.ModuleRef = moduleRef;
        this.LibraryGen.ModulePort = this.ModulePort;
        this.LibraryGen.BinaryRead = this.BinaryRead;
        this.LibraryGen.ClassPath = this.ClassPath;

        bool b;
        b = this.LibraryGen.Execute();

        this.LibraryGen.ClassPath = null;
        this.LibraryGen.BinaryRead = null;
        this.LibraryGen.ModulePort = null;
        this.LibraryGen.ModuleRef = null;

        if (!b)
        {
            this.Status = 6000 + this.LibraryGen.Status;
            return false;
        }
        return true;
    }

    protected virtual ModuleRef ModuleRefFromString(String value)
    {
        long ka;
        ka = this.TextIndex(this.TA(value), this.TB(this.ClassInfra.TextHyphen));

        if (ka == -1)
        {
            return null;
        }

        String name;
        name = this.StringCreateRange(value, 0, ka);

        long verIndex;
        long verCount;
        verIndex = ka + 1;
        verCount = this.StringCount(value) - verIndex;

        String verString;
        verString = this.StringCreateRange(value, verIndex, verCount);

        String verMajorString;
        String verMinorString;
        String verMelorString;

        long majorDot;
        majorDot = this.TextIndex(this.TA(verString), this.TB(this.ClassInfra.TextDot));

        if (majorDot == -1)
        {
            return null;
        }

        long kae;
        kae = majorDot + 1;

        String kaa;
        kaa = this.StringCreateRange(verString, kae, verCount - kae);

        long minorDot;
        minorDot = this.TextIndex(this.TA(kaa), this.TB(this.ClassInfra.TextDot));

        if (minorDot == -1)
        {
            return null;
        }

        long verMajorIndex;
        long verMajorCount;
        verMajorIndex = 0;
        verMajorCount = majorDot;

        verMajorString = this.StringCreateRange(verString, verMajorIndex, verMajorCount);

        long verMinorIndex;
        long verMinorCount;
        verMinorIndex = kae;
        verMinorCount = minorDot;

        if (!(verMinorCount == 2))
        {
            return null;
        }

        verMinorString = this.StringCreateRange(verString, verMinorIndex, verMinorCount);

        long verMelorIndex;
        long verMelorCount;
        verMelorIndex = verMinorIndex + verMinorCount + 1;
        verMelorCount = verCount - verMelorIndex;

        if (!(verMelorCount == 2))
        {
            return null;
        }

        verMelorString = this.StringCreateRange(verString, verMelorIndex, verMelorCount);

        long verMajor;
        long verMinor;
        long verMelor;

        verMajor = this.IntText(this.TA(verMajorString), 10);
        if (verMajor == -1)
        {
            return null;
        }

        verMinor = this.IntText(this.TA(verMinorString), 10);
        if (verMinor == -1)
        {
            return null;
        }

        verMelor = this.IntText(this.TA(verMelorString), 10);
        if (verMelor == -1)
        {
            return null;
        }

        Ver ver;
        ver = new Ver();
        ver.Init();
        ver.Major = verMajor;
        ver.Minor = verMinor;
        ver.Melor = verMelor;

        long moduleVer;
        moduleVer = this.ClassInfra.VerValue(ver);

        ModuleRef a;
        a = this.ClassInfra.ModuleRefCreate(name, moduleVer);
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
        Iter iter;
        iter = this.Result.Node.Root.IterCreate();
        this.Result.Node.Root.IterSet(iter);

        while (iter.Next())
        {
            NodeNode root;
            root = iter.Value as NodeNode;

            String a;
            a = this.InfoTravel.Execute(root);

            this.Out.Write(a);
        }
        return true;
    }

    protected virtual bool PrintTokenResult()
    {
        Iter iter;
        iter = this.Result.Token.Code.IterCreate();
        this.Result.Token.Code.IterSet(iter);

        while (iter.Next())
        {
            Code code;
            code = iter.Value as Code;

            String a;
            a = this.InfoToken.Execute(code);

            this.Out.Write(a);
        }
        return true;
    }

    protected virtual Array FileList(String foldPath)
    {
        Array a;
        a = this.StorageComp.EntryList(foldPath, false, true);

        return a;
    }

    protected virtual Array SourceNameList(String foldPath)
    {
        Array fileArray;
        fileArray = this.FileList(foldPath);

        List list;
        list = new List();
        list.Init();

        String ka;
        ka = this.SDotCl;

        long count;
        count = fileArray.Count;
        long i;
        i = 0;
        while (i < count)
        {
            StorageEntry file;
            file = fileArray.GetAt(i) as StorageEntry;

            String fileName;
            fileName = file.Name;

            if (this.TextInfra.End(this.TA(fileName), this.TB(ka), this.StorageNameLess))
            {
                long ke;
                ke = this.StringCount(fileName) - this.StringCount(ka);

                String name;
                name = this.StringCreateRange(fileName, 0, ke);

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

    protected virtual bool ReadSourceText(bool hasFileExtend)
    {
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
            a = array.GetAt(i) as Source;

            String k;
            k = textInfra.Zero;
            if (hasFileExtend)
            {
                k = this.SDotCl;
            }

            String filePath;
            filePath = this.AddClear().Add(sourceFold).Add(combine).Add(a.Name).Add(k).AddResult();

            String h;
            h = this.StorageInfra.TextRead(filePath);

            Array text;
            text = this.TextLine(this.TextCreate(h));
   
            a.Text = text;

            i = i + 1;
        }
        return true;
    }

    protected virtual bool Error(String message)
    {
        this.Err.Write(this.AddClear().Add(message).Add(this.TextInfra.NewLine).AddResult());
        return true;
    }
}