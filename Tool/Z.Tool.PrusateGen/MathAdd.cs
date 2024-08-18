namespace Z.Tool.PrusateGen;

class MathAdd : ToolGen
{
    public override bool Init()
    {
        base.Init();
        this.ListInfra = ListInfra.This;
        return true;
    }

    public virtual ReadResult ReadResult { get; set; }
    protected virtual ListInfra ListInfra { get; set; }
    protected virtual Table MaideTable { get; set; }
    protected virtual Array TrigoList { get; set; }
    protected virtual Array LineList { get; set; }

    public virtual bool Execute()
    {
        ToolInfra toolInfra;
        toolInfra = this.ToolInfra;

        String ka;
        ka = toolInfra.StorageTextRead(this.S("ToolData/Math/TrigoList.txt"));

        String kb;
        kb = toolInfra.StorageTextRead(this.S("ToolData/Math/List.txt"));

        this.TrigoList = toolInfra.TextSplitLineString(ka);

        this.LineList = toolInfra.TextSplitLineString(kb);

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

        long ka;
        ka = mathClass.Maide.Count;

        long kb;
        kb = this.MaideTable.Count;

        long k;
        k = ka;
        k = k + kb;

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
            Maide method;
            method = (Maide)mathClass.Maide.GetAt(i);

            array.SetAt(i, method);

            i = i + 1;
        }

        Iter iter;
        iter = this.MaideTable.IterCreate();
        this.MaideTable.IterSet(iter);

        long start;
        start = ka;

        count = kb;
        i = 0;
        while (i < count)
        {
            iter.Next();

            Maide method;
            method = (Maide)iter.Value;

            long index;
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

            Text k;
            k = this.TextCreate(a);

            Array uu;
            uu = this.TextSplit(k, space);

            if (!(uu.Count == 4))
            {
                return false;
            }

            Text textName;
            textName = (Text)uu.GetAt(0);

            Text textOperandTwo;
            textOperandTwo = (Text)uu.GetAt(1);

            String name;
            name = this.StringCreate(textName);

            String operandTwo;
            operandTwo = this.StringCreate(textOperandTwo);

            bool ba;
            ba = toolInfra.GetBool(operandTwo);

            b = this.TableAddMaide(table, name, ba);
            if (!b)
            {
                return false;
            }

            i = i + 1;
        }

        return true;
    }

    protected virtual bool TableAddMaide(Table table, String name, bool operandTwo)
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

        String preK;
        String postK;
        preK = this.S(pre);
        postK = this.S(post);

        bool b;
        b = false;
        
        long count;
        count = array.Count;
        long i;
        i = 0;
        while (i < count)
        {
            String k;
            k = (String)array.GetAt(i);

            String name;
            name = this.AddClear().Add(preK).Add(k).Add(postK).AddResult();

            b = this.TableAddMaide(table, name, false);
            if (!b)
            {
                return false;
            }

            i = i + 1;
        }
        return true;
    }

    protected virtual Maide CreateMaide(String name, bool operandTwo)
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
            param.SetAt(0, this.S("value"));
        }

        if (b)
        {
            param.SetAt(0, this.S("valueA"));
            param.SetAt(1, this.S("valueB"));
        }

        return param;
    }
}