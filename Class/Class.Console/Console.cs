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
        read.SystemClass = true;

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




        bool taskModule;



        taskModule = (this.Task.Kind == this.TaskKind.Module);





        Array fileArray;



        fileArray = null;




        if (!taskModule)
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




            fileArray = new Array();


            fileArray.Count = 1;


            fileArray.Init();



            fileArray.Set(0, fileName);



            



            this.ModuleName = "Module";
        }




        if (taskModule)
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


                return 100;
            }





            fileArray = this.GetClassFiles(this.SourceFold);
        }





        this.SetSource(fileArray);
                



        this.ReadSourceText();




        this.ExecuteCreate();




        this.WriteAllError();




        if (this.Task.Print)
        {
            TaskKind t;


            t = this.Task.Kind;



            TaskKindList k;


            k = this.TaskKind;




            if (t == k.Token)
            {
                this.PrintTokenResult();
            }



            if (t == k.Node)
            {
                this.PrintNodeResult();
            }



            if (t == k.Module)
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




        return true;
    }






    private bool CreateFoldIfNotExist(string foldPath)
    {
        if (!Directory.Exists(foldPath))
        {
            Directory.CreateDirectory(foldPath);
        }


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






    private bool PrintNodeResult()
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




            string s;
                

            s = objectString.Result();




            this.Out.Write(s);
        }



        return true;
    }










    private bool PrintTokenResult()
    {
        ObjectString objectString;



        objectString = new ObjectString();



        objectString.Init();





        Iter sourceItemIter;

        sourceItemIter = this.Source.IterCreate();


        this.Source.IterSet(sourceItemIter);




        Iter codeIter;

        codeIter = this.Result.Token.Code.IterCreate();


        this.Result.Token.Code.IterSet(codeIter);



        
        while (sourceItemIter.Next() & codeIter.Next())
        {
            Code code;



            code = (Code)codeIter.Value;



            objectString.Execute(code);
            



            string s;
            

            s = objectString.Result();




            this.Out.Write(s);
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



    private Array GetClassFiles(string foldPath)
    {
        Array fileArray;
        fileArray = this.GetFileList(foldPath);


        int classFileCount;
        classFileCount = 0;

        int count;
        count = fileArray.Count;
        int i;
        i = 0;
        while (i < count)
        {
            string name;
            name = (string)fileArray.Get(i);

            if (name.EndsWith(".cla"))
            {
                classFileCount = classFileCount + 1;
            }

            i = i + 1;
        }

        int oa;
        oa = 0;

        Array a;
        a = new Array();
        a.Count = classFileCount;
        a.Init();

        i = 0;
        while (i < count)
        {
            string name;
            name = (string)fileArray.Get(i);

            if (name.EndsWith(".cla"))
            {
                a.Set(oa, name);
                oa = oa + 1;
            }

            i = i + 1;
        }
        return a;
    }





    private bool Error(string message)
    {
        this.Out.Write(message + "\n");



        return true;
    }







    private bool SetSource(Array fileArray)
    {
        Array t;


        t = new Array();



        t.Count = fileArray.Count;



        t.Init();




        int count;

        count = t.Count;



        int i;

        i = 0;



        while (i < count)
        {
            string fileName;


            fileName = (string)fileArray.Get(i);




            Source item;


            item = new Source();


            item.Init();


            item.Index = i;


            item.Name = fileName;




            t.Set(item.Index, item);




            i = i + 1;
        }

        this.Source = t;
        return true;
    }




    protected virtual bool ReadSourceText()
    {
        int count;

        count = this.Source.Count;


        int i;

        i = 0;

        
        while (i < count)
        {
            Source item;


            item = (Source)this.Source.Get(i);




            string filePath;

            filePath = this.SourceFold + "/" + item.Name;




            string[] array;


            array = File.ReadAllLines(filePath);


            

            Array text;


            text = this.CreateText(array);
            



            item.Text = text;




            i = i + 1;
        }


        return true;
    }






    private Array CreateText(string[] array)
    {
        Array text;

        text = new Array();

        text.Count = array.Length;

        text.Init();




        int count;

        count = text.Count;



        int i;

        i = 0;



        while (i < count)
        {
            string s;

            s = array[i];



            Text line;

            line = this.CreateTextLine(s);



            text.Set(i, line);



            i = i + 1;
        }




        Array ret;

        ret = text;


        return ret;
    }






    private Text CreateTextLine(string s)
    {
        Text a;
        a = this.TextInfra.TextCreateString(s);
        return a;
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