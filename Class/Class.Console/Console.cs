namespace Class.Console;

public class Console : Any
{
    public override bool Init()
    {
        base.Init();

        this.InfraInfra = InfraInfra.This;
        this.ListInfra = ListInfra.This;
        this.StorageInfra = StorageInfra.This;
        this.ClassInfra = ClassInfra.This;
        this.TaskKind = TaskKindList.This;

        this.ErrorWrite = true;

        this.BinaryRead = this.CreateBinaryRead();
        this.ModuleCreate = this.CreateModuleCreate();

        this.ErrorString = new ErrorString();
        this.ErrorString.Class = this;
        this.ErrorString.Init();

        this.Create = this.CreateCreate();

        this.ModuleTable = this.ClassInfra.TableCreateModuleRefCompare();
        this.BinaryTable = this.ClassInfra.TableCreateModuleRefCompare();

        this.ModuleCreate.ModuleTable = this.ModuleTable;
        this.ModuleCreate.BinaryTable = this.BinaryTable;

        this.InitSystem();

        return true;
    }


    public virtual Source Source { get; set; }

    public virtual string ModuleName { get; set; }


    public virtual bool ErrorWrite { get; set; }

    public virtual Array Arg { get; set; }

    public virtual Task Task { get; set; }


    public virtual Result Result { get; set; }


    public virtual TaskKindList TaskKind { get; set; }



    protected virtual Out Out { get; set; }



    public virtual Create Create { get; set; }




    private ErrorString ErrorString { get; set; }

    public virtual string SourceFold { get; set; }


    protected virtual InfraInfra InfraInfra { get; set; }
    protected virtual ListInfra ListInfra { get; set; }
    protected virtual StorageInfra StorageInfra { get; set; }
    protected virtual ClassInfra ClassInfra { get; set; }
    protected virtual Table ModuleTable { get; set; }
    protected virtual Table BinaryTable { get; set; }
    protected virtual BinaryRead BinaryRead { get; set; }
    protected virtual ModuleCreate ModuleCreate { get; set; }

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
        this.InitBinary("Class.Refer");
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

            this.ModuleCreate.ModuleRef = moduleRef;
            this.ModuleCreate.Execute();

            ClassModule a;
            a = this.ModuleCreate.Module;

            this.ModuleCreate.Module = null;

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

    protected virtual ModuleCreate CreateModuleCreate()
    {
        ModuleCreate a;
        a = new ModuleCreate();
        a.Init();
        return a;
    }

    public virtual int Execute()
    {
        this.Out = this.Task.Out;




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



            if (t == k.Check)
            {
                this.PrintCheckResult();
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
        Create create;




        create = new Create();




        create.Class = this;




        create.Init();






        Create ret;



        ret = create;



        return ret;
    }






    private bool WriteAllError()
    {
        if (!this.ErrorWrite)
        {
            return true;
        }




        bool kindModule;


        kindModule = this.Kind(this.TaskKind.Module);



        if (kindModule | this.Kind(this.TaskKind.Token))
        {
            if (!(this.Result.Token == null))
            {
                this.WriteErrorList(this.Result.Token.Error);
            }
        }



        if (kindModule | this.Kind(this.TaskKind.Node))
        {
            if (!(this.Result.Node == null))
            {
                this.WriteErrorList(this.Result.Node.Error);
            }
        }



        if (kindModule | this.Kind(this.TaskKind.Check))
        {
            if (!(this.Result.Check == null))
            {
                this.WriteErrorList(this.Result.Check.Error);
            }
        }



        return true;
    }




    private bool Kind(TaskKind kind)
    {
        return this.Task.Kind == kind;
    }





    private bool WriteErrorList(Array errorList)
    {
        int count;

        count = errorList.Count;


        int i;

        i = 0;

        while (i < count)
        {
            Error error;


            error = (Error)errorList.Get(i);




            this.WriteError(error);



            i = i + 1;
        }



        return true;
    }




    private bool WriteError(Error error)
    {
        string t;

        t = this.ErrorString.String(error);


        this.Out.Write(t);




        return true;
    }





    private bool PrintModuleResult()
    {
        ModuleString moduleString;



        moduleString = new ModuleString();




        moduleString.Init();




        moduleString.Execute(this.Result.Module);




        string s;
        
        
        s = moduleString.Result();




        this.Out.Write(s);




        return true;
    }







    private bool PrintCheckResult()
    {
        CheckString checkString;




        checkString = this.CreateCheckString();





        checkString.Path = this.Task.Check;





        checkString.CheckResult = this.Result.Check;





        checkString.NodeResult = this.Result.Node;





        checkString.Execute();





        string s;


        s = checkString.Result();




        this.Out.Write(s);




        return true;
    }






    private bool PrintNodeResult()
    {
        ObjectString objectString;



        objectString = new ObjectString();



        objectString.Init();





        Iter sourceItemIter;

        sourceItemIter = this.Source.Item.IterCreate();



        this.Source.Item.IterSet(sourceItemIter);





        Iter rootIter;

        rootIter = this.Result.Node.Root.IterCreate();


        this.Result.Node.Root.IterSet(rootIter);




        while (sourceItemIter.Next() & rootIter.Next())
        {
            SourceItem sourceItem;


            sourceItem = (SourceItem)sourceItemIter.Value;





            NodeNode root;


            root = (NodeNode)rootIter.Value;



            

            Text sourceText;


            sourceText = sourceItem.Text;





            objectString.Source = sourceText;



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

        sourceItemIter = this.Source.Item.IterCreate();


        this.Source.Item.IterSet(sourceItemIter);




        Iter codeIter;

        codeIter = this.Result.Token.Code.IterCreate();


        this.Result.Token.Code.IterSet(codeIter);



        
        while (sourceItemIter.Next() & codeIter.Next())
        {
            SourceItem sourceItem;


            sourceItem = (SourceItem)sourceItemIter.Value;



            Code code;



            code = (Code)codeIter.Value;





            Text sourceText;


            sourceText = sourceItem.Text;



            

            objectString.Source = sourceText;



            objectString.Execute(code);
            



            string s;
            

            s = objectString.Result();




            this.Out.Write(s);
        }




        return true;
    }




    protected virtual CheckString CreateCheckString()
    {
        CheckString checkString;
        
        
        
        
        checkString = new CheckString();




        checkString.Init();




        return checkString;
    }





    private bool GetPort(string filePath)
    {
        return true;
    }



    private Array GetFileList(string foldPath)
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




            SourceItem item;


            item = new SourceItem();


            item.Init();


            item.Index = i;


            item.Name = fileName;




            t.Set(item.Index, item);




            i = i + 1;
        }




        this.Source = new Source();


        this.Source.Init();


        this.Source.Item = t;



        return true;
    }




    protected virtual bool ReadSourceText()
    {
        int count;

        count = this.Source.Item.Count;


        int i;

        i = 0;

        
        while (i < count)
        {
            SourceItem item;


            item = (SourceItem)this.Source.Item.Get(i);




            string filePath;

            filePath = this.SourceFold + "/" + item.Name;




            string[] array;


            array = File.ReadAllLines(filePath);


            

            Text text;


            text = this.CreateText(array);
            



            item.Text = text;




            i = i + 1;
        }


        return true;
    }






    private Text CreateText(string[] array)
    {
        Text text;

        text = new Text();

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



            TextLine line;

            line = this.CreateTextLine(s);



            text.Set(i, line);



            i = i + 1;
        }




        Text ret;

        ret = text;


        return ret;
    }






    private TextLine CreateTextLine(string s)
    {
        TextLine line;


        line = new TextLine();


        line.Init();


        line.Count = s.Length;


        line.Data = this.InfraInfra.DataCreateString(s);



        TextLine ret;


        ret = line;


        return ret;
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