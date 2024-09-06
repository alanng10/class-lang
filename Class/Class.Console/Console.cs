namespace Class.Console;

public class Console : ClassInfraGen
{
    public override bool Init()
    {
        base.Init();

        this.InfraInfra = InfraInfra.This;
        this.ListInfra = ListInfra.This;
        this.TextInfra = TextInfra.This;
        this.StorageInfra = StorageInfra.This;
        this.ClassInfra = ClassInfra.This;
        this.StorageArrange = StorageArrange.This;
        this.TaskKind = TaskKindList.This;

        this.ErrorWrite = true;

        this.CharLess = this.CreateCharLess();
        this.CharForm = this.CreateCharForm();
        this.TextLess = this.CreateTextLess();

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

        this.TextNewLine = this.TextInfra.TextCreateStringData(this.ClassInfra.NewLine, null);

        this.SInfo = this.S("info");
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
    public virtual bool ErrorWrite { get; set; }
    protected virtual ListInfra ListInfra { get; set; }
    protected virtual StorageInfra StorageInfra { get; set; }
    protected virtual ClassInfra ClassInfra { get; set; }
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
    protected virtual Text TextNewLine { get; set; }
    protected virtual String SInfo { get; set; }
    private StorageArrange StorageArrange { get; set; }

    protected virtual LessInt CreateCharLess()
    {
        LessInt a;
        a = new LessInt();
        a.Init();
        return a;
    }

    protected virtual CharForm CreateCharForm()
    {
        CharForm a;
        a = new CharForm();
        a.Init();
        return a;
    }

    protected virtual TextLess CreateTextLess()
    {
        TextLess a;
        a = new TextLess();
        a.CharLess = this.CharLess;
        a.LiteCharForm = this.CharForm;
        a.RiteCharForm = this.CharForm;
        a.Init();
        return a;
    }
    
    protected virtual NameCheck CreateNameCheck()
    {
        NameCheck a;
        a = new NameCheck();
        a.Init();
        a.TextLess = this.TextLess;
        a.CharLess = this.CharLess;
        a.CharForm = this.CharForm;
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
                int o;
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

        this.TextString(this.TextA, this.StringDataA, aa);
        this.TextString(this.TextB, this.StringDataB, this.SInfo);

        bool ba;
        ba = (aa == "info");
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

            string aac;
            aac = null;
            if (3 < arg.Count)
            {
                aac = (string)arg.GetAt(3);
            }

            string executeFoldPath;
            executeFoldPath = this.StorageArrange.ExecuteFoldPath;

            string combine;
            combine = this.InfraInfra.PathCombine;

            StorageInfra storageInfra;
            storageInfra = this.StorageInfra;

            TextLess less;
            less = this.TextLess;

            Text text;
            text = this.TextA;
            StringData data;
            data = this.StringDataA;

            aaa = aaa.Replace('\\', '/');
            aab = aab.Replace('\\', '/');

            string sourceFold;
            sourceFold = aaa;

            this.TextStringGet(text, data, sourceFold);
            if (storageInfra.IsRelativePath(text, less))
            {
                sourceFold = executeFoldPath + combine + sourceFold;
            }

            string destFold;
            destFold = aab;

            this.TextStringGet(text, data, destFold);
            if (storageInfra.IsRelativePath(text, less))
            {
                destFold = executeFoldPath + combine + destFold;
            }

            bool linkFileName;
            linkFileName = true;
            if (!(aac == null))
            {
                if (aac == "-d")
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
            string sourceFoldPath;
            string destFoldPath;
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
            string file;
            file = this.Task.Source;

            string fileName;
            fileName = Path.GetFileName(file);

            this.SourceFold = Path.GetDirectoryName(file);

            if (this.SourceFold.Length == 0)
            {
                this.SourceFold = ".";
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
                this.Error("Source Fold Invalid");
                this.Status = 1001;
                return false;;
            }

            bool baa;
            baa = this.ReadPort();
            if (!baa)
            {
                this.Error("Port Invalid");
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
        string combine;
        combine = this.InfraInfra.PathCombine;

        string fileName;
        fileName = "Class.Port";

        string filePath;
        filePath = this.SourceFold + combine + fileName;

        string source;
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
        Table binaryTable;
        binaryTable = this.CopyModuleRefTable(this.InitBinaryTable);
        Table moduleTable;
        moduleTable = this.CopyModuleRefTable(this.InitModuleTable);
        Table classTable;
        classTable = this.ClassInfra.TableCreateStringLess();
        
        this.BinaryTable = binaryTable;
        this.ModuleTable = moduleTable;
        this.ClassTable = classTable;

        PortLoad portLoad;
        portLoad = this.PortLoad;

        portLoad.Port = this.Port;
        portLoad.BinaryRead = this.BinaryRead;
        portLoad.ModuleLoad = this.ModuleLoad;
        portLoad.BinaryTable = binaryTable;
        portLoad.ModuleTable = moduleTable;
        portLoad.ClassTable = classTable;

        bool b;
        b = portLoad.Execute();

        if (!b)
        {
            this.Error("Port Module Load Fail");
            this.Status = 1800 + portLoad.Status;
            return false;
        }

        this.PortModule = portLoad.Module;

        portLoad.Module = null;
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
        int count;
        count = errorList.Count;
        int i;
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
        string a;
        a = this.ErrorString.Execute(error);
        this.Err.Write(a);
        return true;
    }

    protected virtual bool PrintModuleResult()
    {
        ModuleString a;
        a = this.CreateModuleString();
        a.Path = this.Task.Path;
        a.ModuleResult = this.Result.Module;
        a.NodeResult = this.Result.Node;
        a.Execute();

        string e;
        e = a.Result();

        this.Out.Write(e);
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

            string a;
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
            
            string a;
            a = objectString.Result();

            this.Out.Write(a);
        }
        return true;
    }

    protected virtual Array GetFileList(string foldPath)
    {
        string[] u;
        u = Directory.GetFiles(foldPath);

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
        array = new Array();
        array.Count = u.Length;
        array.Init();

        count = array.Count;
        i = 0;
        while (i < count)
        {
            string k;
            k = u[i];
            array.SetAt(i, k);
            i = i + 1;
        }

        InfraRange range;
        range = new InfraRange();
        range.Init();
        range.Count = count;

        StringLess less;
        less = this.InfraInfra.StringLessCreate();

        array.Sort(range, less);
        return array;
    }

    protected virtual Array GetSourceNameList(string foldPath)
    {
        Array fileArray;
        fileArray = this.GetFileList(foldPath);

        List list;
        list = new List();
        list.Init();

        string ka;
        ka = ".cla";

        int count;
        count = fileArray.Count;
        int i;
        i = 0;
        while (i < count)
        {
            string fileName;
            fileName = (string)fileArray.GetAt(i);

            string k;
            k = fileName.ToLower();

            if (k.EndsWith(ka))
            {
                string name;
                name = fileName.Substring(0, k.Length - ka.Length);

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
        int count;
        count = array.Count;
        int i;
        i = 0;
        while (i < count)
        {
            string name;
            name = (string)array.GetAt(i);

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

        StorageInfra storageInfra;
        storageInfra = this.StorageInfra;
        TextInfra textInfra;
        textInfra = this.TextInfra;

        Array array;
        array = this.Source;
        string sourceFold;
        sourceFold = this.SourceFold;

        string combine;
        combine = infraInfra.PathCombine;

        Text newLine;
        newLine = this.TextNewLine;
        Less less;
        less = this.TextLess;
        
        int count;
        count = array.Count;
        int i;
        i = 0;
        while (i < count)
        {
            Source a;
            a = (Source)array.GetAt(i);

            string k;
            k = "";
            if (hasFileExtension)
            {
                k = ".cla";
            }

            string filePath;
            filePath = sourceFold + combine + a.Name + k;

            string h;
            h = storageInfra.TextReadAny(filePath, true);

            Text aa;
            aa = textInfra.TextCreateStringData(h, null);

            Array text;
            text = textInfra.Limit(aa, newLine, less);
            a.Text = text;

            i = i + 1;
        }
        return true;
    }

    protected virtual bool Error(string message)
    {
        this.Err.Write(message + "\n");
        return true;
    }
}