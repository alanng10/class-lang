namespace Class.Console;

public class Console : Any
{
    public override bool Init()
    {
        base.Init();

        this.InfraInfra = InfraInfra.This;
        this.ListInfra = ListInfra.This;
        this.TextInfra = TextInfra.This;
        this.StorageInfra = StorageInfra.This;
        this.ClassInfra = ClassInfra.This;
        this.TaskKind = TaskKindList.This;

        this.ErrorWrite = true;

        this.BinaryRead = this.CreateBinaryRead();
        this.ModuleCreateBinary = this.CreateModuleCreateBinary();

        this.ErrorString = new ErrorString();
        this.ErrorString.Class = this;
        this.ErrorString.Init();

        this.Create = this.CreateCreate();

        this.ModuleTable = this.ClassInfra.TableCreateModuleRefCompare();
        this.BinaryTable = this.ClassInfra.TableCreateModuleRefCompare();

        this.ModuleCreateBinary.ModuleTable = this.ModuleTable;
        this.ModuleCreateBinary.BinaryTable = this.BinaryTable;

        this.InitSystem();

        return true;
    }


    public virtual Array Source { get; set; }

    public virtual string ModuleName { get; set; }


    public virtual bool ErrorWrite { get; set; }

    public virtual Array Arg { get; set; }

    public virtual Task Task { get; set; }


    public virtual Result Result { get; set; }


    public virtual TaskKindList TaskKind { get; set; }



    protected virtual Out Out { get; set; }
    protected virtual Out Err { get; set; }



    public virtual Create Create { get; set; }




    private ErrorString ErrorString { get; set; }

    public virtual string SourceFold { get; set; }


    protected virtual InfraInfra InfraInfra { get; set; }
    protected virtual ListInfra ListInfra { get; set; }
    protected virtual TextInfra TextInfra { get; set; }
    protected virtual StorageInfra StorageInfra { get; set; }
    protected virtual ClassInfra ClassInfra { get; set; }
    protected virtual Table ModuleTable { get; set; }
    protected virtual Table BinaryTable { get; set; }
    protected virtual BinaryRead BinaryRead { get; set; }
    protected virtual ModuleCreateBinary ModuleCreateBinary { get; set; }

    protected virtual bool InitSystem()
    {
        this.InitBinary("System.Infra");
        this.InitBinary("System.List");
        this.InitBinary("System.Math");
        this.InitBinary("System.Text");
        this.InitBinary("System.Event");
        this.InitBinary("System.Comp");
        this.InitBinary("System.Thread");
        this.InitBinary("System.Stream");
        this.InitBinary("System.Type");
        this.InitBinary("System.Time");
        this.InitBinary("System.Video");
        this.InitBinary("System.Audio");
        this.InitBinary("System.Storage");
        this.InitBinary("System.Network");
        this.InitBinary("System.Console");
        this.InitBinary("System.Media");
        this.InitBinary("System.Draw");
        this.InitBinary("System.View");
        this.InitBinary("System.Main");
        this.InitBinary("System.Entry");
        this.InitBinary("Class.Infra");
        this.InitBinary("Class.Binary");
        this.InitBinary("Class.Port");
        this.InitBinary("Class.Token");
        this.InitBinary("Class.Node");
        this.InitBinary("Class.Module");
        this.InitBinary("Class.Console");

        this.InitModuleList();

        return true;
    }

    protected virtual bool InitBinary(string moduleName)
    {
        string filePath;
        filePath = moduleName + ".ref";

        Data data;
        data = this.StorageInfra.DataRead(filePath);

        if (data == null)
        {
            global::System.Console.Error.Write("Class.Console:Class.InitBinary data is null, module name: " + moduleName + "\n");
            global::System.Environment.Exit(1001);
        }

        BinaryRead read;
        read = this.BinaryRead;

        read.Data = data;
        read.SystemInfo = true;

        read.Execute();

        BinaryBinary binary;
        binary = read.Binary;

        if (binary == null)
        {
            global::System.Console.Error.Write("Class.Console:Class.InitBinary binary is null, module name: " + moduleName + "\n");
            global::System.Environment.Exit(1000);
        }

        read.Binary = null;

        this.ListInfra.TableAdd(this.BinaryTable, binary.Ref, binary);
        return true;
    }

    protected virtual bool InitModuleList()
    {
        Iter iter;
        iter = this.BinaryTable.IterCreate();
        this.BinaryTable.IterSet(iter);

        while (iter.Next())
        {
            ModuleRef moduleRef;
            moduleRef = (ModuleRef)iter.Index;

            this.ModuleCreateBinary.ModuleRef = moduleRef;
            this.ModuleCreateBinary.Execute();

            ClassModule a;
            a = this.ModuleCreateBinary.Module;

            this.ModuleCreateBinary.Module = null;

            this.ListInfra.TableAdd(this.ModuleTable, a.Ref, a);
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

    protected virtual ModuleCreateBinary CreateModuleCreateBinary()
    {
        ModuleCreateBinary a;
        a = new ModuleCreateBinary();
        a.Init();
        return a;
    }

    public virtual int Execute()
    {
        this.Out = this.Task.Out;
        this.Err = this.Task.Err;

        TaskKindList kindList;
        kindList = this.TaskKind;
        TaskKind kind;
        kind = this.Task.Kind;

        bool b;
        b = (kind == kindList.Console | kind == kindList.Module);

        bool hasFileExtension;
        hasFileExtension = false;
        Array sourceNameList;
        sourceNameList = null;
        if (!b)
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
            sourceNameList.Set(0, fileName);
        }

        if (b)
        {
            this.SourceFold = this.Task.Source;

            if (this.SourceFold == null)
            {
                this.Error("Source Fold Invalid");
                return 100;
            }

            bool ba;
            ba = this.ReadPort();
            if (!ba)
            {
                this.Error("Port Invalid");
                return 101;
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
        return 0;
    }




    protected virtual bool ReadPort()
    {
        return true;
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
        a.Class = this;
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
            a = (Error)errorList.Get(i);
            this.WriteError(a);
            i = i + 1;
        }
        return true;
    }

    protected virtual bool WriteError(Error error)
    {
        string a;
        a = this.ErrorString.String(error);
        this.Err.Write(a);
        return true;
    }

    protected virtual bool PrintModuleResult()
    {
        ModuleString a;
        a = this.CreateModuleString();
        a.Path = this.Task.Path;
        a.CheckResult = this.Result.Module;
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

    protected virtual ModuleString CreateModuleString()
    {
        ModuleString a;
        a = new ModuleString();
        a.Init();
        return a;
    }

    private bool GetPort(string filePath)
    {
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
            array.Set(i, k);
            i = i + 1;
        }

        InfraRange range;
        range = new InfraRange();
        range.Init();
        range.Count = count;

        StringCompare compare;
        compare = new StringCompare();
        compare.Init();

        array.Sort(range, compare);
        return array;
    }

    protected virtual Array GetSourceNameList(string foldPath)
    {
        Array fileArray;
        fileArray = this.GetFileList(foldPath);

        List list;
        list = new List();
        list.Init();

        string o;
        o = ".cla";

        int count;
        count = fileArray.Count;
        int i;
        i = 0;
        while (i < count)
        {
            string fileName;
            fileName = (string)fileArray.Get(i);

            if (fileName.EndsWith(o))
            {
                string name;
                name = fileName.Substring(0, fileName.Length - o.Length);

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
            name = (string)array.Get(i);

            Source a;
            a = new Source();
            a.Init();
            a.Index = i;
            a.Name = name;

            array.Set(i, a);
            i = i + 1;
        }

        this.Source = array;
        return true;
    }

    protected virtual bool ReadSourceText(bool hasFileExtension)
    {
        int count;
        count = this.Source.Count;
        int i;
        i = 0;
        while (i < count)
        {
            Source a;
            a = (Source)this.Source.Get(i);

            string k;
            k = "";
            if (hasFileExtension)
            {
                k = ".cla";
            }

            string filePath;
            filePath = this.SourceFold + "/" + a.Name + k;

            string h;
            h = this.StorageInfra.TextRead(filePath);

            Array text;
            text = this.ClassInfra.TextCreate(h);
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

    private bool CheckPortFile(string portFile)
    {
        string name;


        name = Path.GetFileName(portFile);



        bool b;


        b = (name == "Port");



        if (!b)
        {
            return false;
        }



        if (!File.Exists(portFile))
        {
            return false;
        }



        return true;
    }
}