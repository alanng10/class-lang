namespace Class;





public class Class : Any
{
    public override bool Init()
    {
        base.Init();

        this.TextInfra = TextInfra.This;
        this.TaskKind = TaskKindList.This;





        this.ErrorWrite = true;




        this.ErrorString = new ErrorString();



        this.ErrorString.Class = this;



        this.ErrorString.Init();





        this.Create = this.CreateCreate();





        this.InitSystem();






        return true;
    }


    public Source Source { get; set; }

    public string ModuleName { get; set; }


    public bool ErrorWrite { get; set; }


    public Task Task { get; set; }


    public Result Result { get; set; }


    internal Result SystemResult { get; set; }


    public TaskKindList TaskKind { get; set; }



    private TextWriter Out { get; set; }



    public Create Create { get; set; }




    private ErrorString ErrorString { get; set; }




    public string SourceFold { get; set; }


    protected virtual TextInfra TextInfra { get; set; }








    public bool Execute()
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



                return false;
            }






            bool ba;
                
            ba = this.ReadPort();
                

            if (!ba)
            {
                this.Error("Port Invalid");


                return false;
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





        return true;
    }




    protected virtual bool ReadPort()
    {
        return true;
    }








    private bool InitSystem()
    {
        return true;
    }









    public bool ExecuteCreate()
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





    private string[] GetFiles(string folderPath)
    {
        string[] u;
        
        
        u = Directory.GetFiles(folderPath);




        int count;

        count = u.Length;


        int i;

        i = 0;


        while (i < count)
        {
            string k;


            k = u[i];


            k = Path.GetFileName(k);


            u[i] = k;



            i = i + 1;
        }




        StringComparer comparer;


        comparer = new StringComparer();


        comparer.Init();




        SystemArray.Sort<string>(u, comparer);




        string[] ret;


        ret = u;



        return ret;
    }




    private Array GetClassFiles(string foldPath)
    {
        string[] u;



        u = this.GetFiles(foldPath);



        if (u.Length < 1)
        {
            return null;
        }




        Array t;


        t = new Array();


        t.Count = u.Length - 1;


        t.Init();




        int count;

        count = t.Count;



        int i;

        i = 0;


        while (i < count)
        {
            string a;

            a = u[i + 1];


            t.Set(i, a);



            i = i + 1;
        }


        



        Array ret;


        ret = t;


        return ret;
    }





    private bool Error(string message)
    {
        this.Out.WriteLine(message);



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


        line.Data = this.TextInfra.DataCreateString(s);



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