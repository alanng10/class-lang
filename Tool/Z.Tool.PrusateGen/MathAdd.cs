namespace Z.Tool.PrusateGen;

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
    protected virtual Table MaideTable { get; set; }
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

        this.MaideTable = toolInfra.TableCreateStringCompare();

        bool b;

        b = this.AddMaideList();
        if (!b)
        {
            return false;
        }

        b = this.AddTrigoMaideList("", "");
        if (!b)
        {
            return false;
        }

        b = this.AddTrigoMaideList("A", "");
        if (!b)
        {
            return false;
        }

        b = this.AddTrigoMaideList("", "H");
        if (!b)
        {
            return false;
        }
        
        b = this.AddTrigoMaideList("A", "H");
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
        ka = mathClass.Maide.Count;

        int kb;
        kb = this.MaideTable.Count;

        int k;
        k = ka;
        k = k + kb;

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
            method = (Maide)mathClass.Maide.GetAt(i);

            array.SetAt(i, method);

            i = i + 1;
        }

        Iter iter;
        iter = this.MaideTable.IterCreate();
        this.MaideTable.IterSet(iter);

        int start;
        start = ka;

        count = kb;
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

        mathClass.Maide = array;
        return true;
    }

    protected virtual bool AddMaideList()
    {
        ToolInfra toolInfra;
        toolInfra = this.ToolInfra;

        Array array;
        array = this.LineList;

        Table table;
        table = this.MaideTable;

        bool b;
        b = false;

        int count;
        count = array.Count;
        int i;
        i = 0;
        while (i < count)
        {
            string a;
            a = (string)array.GetAt(i);

            string[] uu;
            uu = a.Split(' ');

            if (!(uu.Length == 4))
            {
                return false;
            }

            string name;
            name = uu[0];

            string ka;
            ka = uu[1];

            bool ba;
            ba = toolInfra.GetBool(ka);

            b = this.TableAddMaide(table, name, ba);
            if (!b)
            {
                return false;
            }

            i = i + 1;
        }

        return true;
    }

    protected virtual bool TableAddMaide(Table table, string name, bool operandTwo)
    {
        ListInfra listInfra;
        listInfra = this.ListInfra;

        if (table.Valid(name))
        {
            return false;
        }

        Maide maide;
        maide = this.CreateMaide(name, operandTwo);

        listInfra.TableAdd(table, name, maide);
        return true;
    }

    protected virtual bool AddTrigoMaideList(string pre, string post)
    {
        Array array;
        array = this.TrigoList;

        Table table;
        table = this.MaideTable;

        bool b;
        b = false;
        
        int count;
        count = array.Count;
        int i;
        i = 0;
        while (i < count)
        {
            string k;
            k = (string)array.GetAt(i);

            string name;
            name = pre + k + post;

            b = this.TableAddMaide(table, name, false);
            if (!b)
            {
                return false;
            }

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

        Maide a;
        a = new Maide();
        a.Init();
        a.Name = name;
        a.Param = param;
        return a;
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