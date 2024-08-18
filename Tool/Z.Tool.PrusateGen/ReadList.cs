namespace Z.Tool.PrusateGen;

public class ReadList : ToolGen
{
    public virtual ReadResult ReadResult { get; set; }
    protected virtual List List { get; set; }

    public virtual bool Execute()
    {
        this.List = new List();
        this.List.Init();

        this.ExecuteList("TextCodeKind");
        this.ExecuteList("ThreadCase");
        this.ExecuteList("StreamKind");
        this.ExecuteList("StorageMode");
        this.ExecuteList("StorageStatus");
        this.ExecuteList("NetworkCase");
        this.ExecuteList("NetworkPortKind");
        this.ExecuteList("NetworkStatus");
        this.ExecuteList("BrushKind");
        this.ExecuteList("BrushLine");
        this.ExecuteList("BrushCap");
        this.ExecuteList("BrushJoin");
        this.ExecuteList("GradientKind");
        this.ExecuteList("GradientSpread");
        this.ExecuteList("Comp");
        this.ExecuteList("ImageBinary");

        bool b;
        b = this.SetStatMethod();

        this.List = null;

        if (!b)
        {
            return false;
        }

        return true;
    }

    protected virtual bool SetStatMethod()
    {
        Class statClass;
        statClass = (Class)this.ReadResult.Class.Get("Stat");

        if (statClass == null)
        {
            return false;
        }

        long ka;
        ka = statClass.Maide.Count;

        long k;
        k = ka;
        k = k + this.List.Count;

        Array array;
        array = new Array();
        array.Count = k;
        array.Init();

        long count;
        count = ka;

        long i;
        i = 0;
        while (i < count)
        {
            Maide maide;
            maide = (Maide)statClass.Maide.GetAt(i);

            array.SetAt(i, maide);

            i = i + 1;
        }

        Iter iter;
        iter = this.List.IterCreate();
        this.List.IterSet(iter);

        long start;
        start = ka;

        count = this.List.Count;

        i = 0;
        while (i < count)
        {
            iter.Next();

            Maide maide;
            maide = (Maide)iter.Value;

            long index;
            index = start + i;

            array.SetAt(index, maide);

            i = i + 1;
        }

        statClass.Maide = array;

        return true;
    }





    protected virtual bool ExecuteList(string className)
    {
        string listFilePath;


        listFilePath = this.GetListFilePath(className);



        string k;
        
        k = this.ToolInfra.StorageTextRead(listFilePath);



        Array array;

        array = this.ToolInfra.SplitLineList(k);



        int count;

        count = array.Count;



        int i;

        i = 0;


        while (i < count)
        {
            string a;


            a = (string)array.GetAt(i);



            string name;

            name = a;



            int uu;

            uu = a.IndexOf(' ');


            if (!(uu < 0))
            {
                int end;

                end = uu;


                name = a.Substring(0, end);
            }




            string methodName;

            methodName = this.GetMethodName(className, name);





            Array param;

            param = new Array();

            param.Count = 0;

            param.Init();



            Maide method;

            method = new Maide();

            method.Init();


            method.Name = methodName;

            method.Param = param;

            
            

            this.List.Add(method);





            i = i + 1;
        }




        return true;
    }





    protected virtual string GetListFilePath(string className)
    {
        return "ToolData/Infra/ItemList" + className + ".txt";
    }




    protected virtual string GetMethodName(string className, string itemName)
    {
        return className + itemName;
    }
}