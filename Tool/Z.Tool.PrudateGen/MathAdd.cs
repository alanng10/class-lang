namespace Z.Tool.PrudateGen;

class MathAdd : Any
{
    public override bool Init()
    {
        base.Init();
        this.ListInfra = ListInfra.This;
        this.ToolInfra = ToolInfra.This;
        return true;
    }

    public virtual ReadResult ReadResult { get; set; }
    protected virtual ListInfra ListInfra { get; set; }
    protected virtual ToolInfra ToolInfra { get; set; }
    protected virtual List List { get; set; }
    protected virtual Array TrigoList { get; set; }
    protected virtual Array LineList { get; set; }

    public virtual bool Execute()
    {
        ToolInfra toolInfra;
        toolInfra = this.ToolInfra;

        string ka;
        ka = toolInfra.StorageTextRead("ToolData/Math/TrigoList.txt");

        string kb;
        kb = toolInfra.StorageTextRead("ToolData/Math/List.txt");

        this.TrigoList = toolInfra.SplitLineList(ka);

        this.LineList = toolInfra.SplitLineList(kb);

        this.List = new List();
        this.List.Init();

        this.AddTrigoMaideList("", "");
        this.AddTrigoMaideList("A", "");
        this.AddTrigoMaideList("", "H");
        this.AddTrigoMaideList("A", "H");

        bool b;

        b = this.AddMaideList();
        if (!b)
        {
            return false;
        }

        b = this.SetMathClass();
        if (!b)
        {
            return false;
        }

        return true;
    }

    protected virtual bool SetMathClass()
    {
        Class mathClass;
        mathClass = (Class)this.ReadResult.Class.Get("Math");

        if (mathClass == null)
        {
            return false;
        }

        int ka;
        ka = mathClass.Method.Count;

        int k;
        k = ka;
        k = k + this.List.Count;

        Array array;
        array = new Array();
        array.Count = k;
        array.Init();

        int count;
        count = ka;
        int i;
        i = 0;
        while (i < count)
        {
            Maide method;
            method = (Maide)mathClass.Method.GetAt(i);

            array.SetAt(i, method);

            i = i + 1;
        }

        Iter iter;
        iter = this.List.IterCreate();
        this.List.IterSet(iter);

        int start;
        start = ka;

        count = this.List.Count;
        i = 0;
        while (i < count)
        {
            iter.Next();

            Maide method;
            method = (Maide)iter.Value;

            int index;
            index = start + i;

            array.SetAt(index, method);

            i = i + 1;
        }

        mathClass.Method = array;
        return true;
    }

    protected virtual bool AddMaideList()
    {
        ToolInfra toolInfra;
        toolInfra = this.ToolInfra;

        Array array;
        array = this.LineList;

        int count;
        count = array.Count;
        int i;
        i = 0;
        while (i < count)
        {
            string a;
            a = (string)array.GetAt(i);

            int uu;
            uu = a.IndexOf(' ');

            if (uu < 0)
            {
                return false;
            }

            string name;
            name = a.Substring(0, uu);
            
            string kk;
            kk = a.Substring(uu + 1);

            bool ba;
            ba = toolInfra.GetBool(kk);

            Maide maide;
            maide = this.CreateMaide(name, ba);

            this.List.Add(maide);

            i = i + 1;
        }
        return true;
    }

    protected virtual bool AddTrigoMaideList(string pre, string post)
    {
        Array array;
        array = this.TrigoList;

        int count;
        count = array.Count;
        int i;
        i = 0;
        while (i < count)
        {
            string k;
            k = (string)array.GetAt(i);

            string ka;
            ka = pre + k + post;

            Maide a;
            a = this.CreateMaide(ka, false);

            this.List.Add(a);

            i = i + 1;
        }
        return true;
    }

    protected virtual Maide CreateMaide(string name, bool operandTwo)
    {
        ListInfra listInfra;
        listInfra = this.ListInfra;

        Array param;
        param = this.CreateParam(operandTwo);

        Maide maide;
        maide = new Maide();
        maide.Init();
        maide.Name = name;
        maide.Param = param;

        return maide;
    }

    protected virtual Array CreateParam(bool operandTwo)
    {
        int count;
        count = 1;

        bool b;
        b = operandTwo;

        if (b)
        {
            count = 2;
        }

        Array param;
        param = this.ListInfra.ArrayCreate(count);

        if (!b)
        {
            param.SetAt(0, "value");
        }

        if (b)
        {
            param.SetAt(0, "valueA");
            param.SetAt(1, "valueB");
        }

        return param;
    }
}