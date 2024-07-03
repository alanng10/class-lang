namespace Z.Tool.Class.NodeList;

class Read : Any
{
    public override bool Init()
    {
        base.Init();
        this.ListInfra = ListInfra.This;
        this.ToolInfra = ToolInfra.This;
        return true;
    }

    public virtual int Execute()
    {
        bool b;
        b = this.SetClassTable();
        if (!b)
        {
            return 1;
        }
        return 0;
    }

    public virtual Table ClassTable { get; set; }
    protected virtual ListInfra ListInfra { get; set; }
    protected virtual ToolInfra ToolInfra { get; set; }
    protected virtual Class Class { get; set; }
    protected virtual List FieldList { get; set; }

    protected virtual bool SetClassTable()
    {
        ToolInfra infra;
        infra = this.ToolInfra;

        string ka;
        ka = infra.StorageTextRead("ToolData/NodeList.txt");

        Array lineArray;        
        lineArray = infra.SplitLineList(ka);

        this.ClassTable = this.CreateTableStringCompare();

        int count;
        count = lineArray.Count;
        int i;
        i = 0;
        while (i < count)
        {
            string line;
            line = (string)lineArray.Get(i);

            bool b;
            b = this.SetClassTableOneLine(line);
            if (!b)
            {
                return false;
            }

            i = i + 1;
        }

        this.EndCurrentClass();
        return true;
    }

    protected virtual bool SetClassTableOneLine(string line)
    {
        if (line.Length == 0)
        {
            return true;
        }

        string oo;
        oo = "    ";

        bool b;
        b = line.StartsWith(oo);
        if (!b)
        {
            this.EndCurrentClass();

            Class varClass;
            varClass = this.GetClass(line);
            if (varClass == null)
            {
                return false;
            }

            if (this.ClassTable.Contain(varClass.Name))
            {
                return false;
            }

            this.Class = varClass;

            this.ListInfra.TableAdd(this.ClassTable, varClass.Name, varClass);

            this.FieldList = new List();
            this.FieldList.Init();
        }
        if (b)
        {
            string compLine;
            compLine = line.Substring(oo.Length);

            Field ob;
            ob = this.GetField(compLine);
            if (ob == null)
            {
                return false;
            }

            List list;
            list = this.FieldList;
            list.Add(ob);
        }
        return true;
    }

    protected virtual bool EndCurrentClass()
    {
        if (this.Class == null)
        {
            return true;
        }

        this.Class.Field = this.ListInfra.ArrayCreateList(this.FieldList);

        this.Class = null;
        this.FieldList = null;
        return true;
    }

    protected virtual Class GetClass(string a)
    {
        string uo;
        uo = " : ";

        int uu;
        uu = a.IndexOf(uo);
        if (uu < 0)
        {
            return null;
        }

        string className;
        className = a.Substring(0, uu);

        string baseClassName;
        baseClassName = a.Substring(uu + uo.Length);

        Class varClass;
        varClass = new Class();
        varClass.Init();
        varClass.Name = className;
        varClass.Base = baseClassName;
        varClass.Derive = this.CreateTableStringCompare();
        return varClass;
    }

    protected virtual Field GetField(string a)
    {
        int uu;
        uu = a.IndexOf(' ');

        if (uu < 0)
        {
            return null;
        }

        string className;
        className = a.Substring(0, uu);

        string fieldName;
        fieldName = a.Substring(uu + 1);

        Field o;
        o = new Field();
        o.Init();
        o.Class = className;
        o.Name = fieldName;
        return o;
    }

    protected virtual bool SetDerive()
    {
        ListInfra listInfra;
        listInfra = this.ListInfra;

        Table table;
        table = this.ClassTable;

        Iter iter;
        iter = table.IterCreate();
        table.IterSet(iter);

        while (iter.Next())
        {
            Class a;
            a = (Class)iter.Value;

            string ka;
            ka = a.Base;

            Class k;
            k = (Class)table.Get(ka);

            if (k == null)
            {
                return false;
            }

            listInfra.TableAdd(k.Derive, a.Name, a);
        }
        return true;
    }

    protected virtual Table CreateTableStringCompare()
    {
        IntCompare charCompare;
        charCompare = new IntCompare();
        charCompare.Init();

        StringCompare compare;
        compare = new StringCompare();
        compare.CharCompare = charCompare;
        compare.Init();

        Table table;
        table = new Table();
        table.Compare = compare;
        table.Init();
        return table;
    }
}