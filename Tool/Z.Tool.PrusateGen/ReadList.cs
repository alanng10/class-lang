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
        statClass = (Class)this.ReadResult.Class.Get(this.S("Stat"));

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
        array = this.ListInfra.ArrayCreate(k);

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
        String classNameK;
        classNameK = this.S(className);

        String listFilePath;
        listFilePath = this.GetListFilePath(classNameK);

        String k;
        k = this.ToolInfra.StorageTextRead(listFilePath);

        Array array;
        array = this.TextSplitLineString(k);

        Text space;
        space = this.TextCreate(this.S(" "));

        long count;
        count = array.Count;

        long i;
        i = 0;
        while (i < count)
        {
            String a;
            a = (String)array.GetAt(i);

            Text ka;
            ka = this.TextCreate(a);

            Array colArray;
            colArray = this.TextSplit(ka, space);

            Text kaa;
            kaa = (Text)colArray.GetAt(0);

            String name;
            name = this.StringCreate(kaa);

            String maideName;
            maideName = this.GetMaideName(classNameK, name);

            Array param;
            param = this.ListInfra.ArrayCreate(0);

            Maide maide;
            maide = new Maide();
            maide.Init();
            maide.Name = maideName;
            maide.Param = param;

            this.List.Add(maide);

            i = i + 1;
        }

        return true;
    }

    protected virtual String GetListFilePath(String className)
    {
        return this.AddClear().AddS("ToolData/Infra/ItemList").Add(className).AddS(".txt").AddResult();
    }

    protected virtual String GetMaideName(String className, String itemName)
    {
        return this.AddClear().Add(className).Add(itemName).AddResult();
    }
}