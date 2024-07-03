namespace Z.Tool.Class.NodeList;

class Read : Any
{
    public override bool Init()
    {
        base.Init();
        this.ListInfra = ListInfra.This;
        this.ClassInfra = ClassInfra.This;
        this.ToolInfra = ToolInfra.This;
        this.NameCheck = new NameCheck();
        this.NameCheck.Init();

        this.TextA = this.CreateText();
        this.StringDataA = new StringData();
        this.StringDataA.Init();
        return true;
    }

    private Text CreateText()
    {
        Text a;
        a = new Text();
        a.Init();
        a.Range = new Range();
        a.Range.Init();
        return a;
    }

    public virtual int Execute()
    {
        bool b;

        b = this.SetClassTable();
        if (!b)
        {
            return 10;
        }
        
        b = this.SetDerive();
        if (!b)
        {
            return 20;
        }

        b = this.CheckArrayField();
        if (!b)
        {
            return 30;
        }
        return 0;
    }

    public virtual Table ClassTable { get; set; }
    protected virtual ListInfra ListInfra { get; set; }
    protected virtual ClassInfra ClassInfra { get; set; }
    protected virtual ToolInfra ToolInfra { get; set; }
    protected virtual NameCheck NameCheck { get; set; }
    protected virtual Text TextA { get; set; }
    protected virtual StringData StringDataA { get; set; }
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

        this.ClassTable = this.ClassInfra.TableCreateStringCompare();

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
        }
        if (b)
        {
            if (this.Class == null)
            {
                return false;
            }

            string compLine;
            compLine = line.Substring(oo.Length);

            Field ob;
            ob = this.GetField(compLine);
            if (ob == null)
            {
                return false;
            }

            if (this.Class.Field.Contain(ob.Name))
            {
                return false;
            }

            this.ListInfra.TableAdd(this.Class.Field, ob.Name, ob);
        }
        return true;
    }

    protected virtual bool EndCurrentClass()
    {
        this.Class = null;
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

        if (!this.CheckIsName(className))
        {
            return null;
        }

        if (!this.CheckIsName(baseClassName))
        {
            return null;
        }

        Class varClass;
        varClass = new Class();
        varClass.Init();
        varClass.Name = className;
        varClass.Base = baseClassName;
        varClass.Field = this.ClassInfra.TableCreateStringCompare();
        varClass.Derive = this.ClassInfra.TableCreateStringCompare();
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
        string itemClassName;
        itemClassName = null;
        string fieldName;
        fieldName = null;

        className = a.Substring(0, uu);

        int ka;
        ka = uu + 1;

        bool b;
        b = (className == "Array");
        if (b)
        {            
            int ua;
            ua = a.IndexOf(' ', ka);

            if (ua < 0)
            {
                return null;
            }

            int kk;
            kk = ua - ka;

            itemClassName = a.Substring(ka, kk);

            fieldName = a.Substring(ua + 1);
        }

        if (!b)
        {
            fieldName = a.Substring(uu + 1);
        }

        if (!this.CheckIsName(className))
        {
            return null;
        }

        if (!(itemClassName == null))
        {
            if (!this.CheckIsName(itemClassName))
            {
                return null;
            }
        }

        if (!this.CheckIsName(fieldName))
        {
            return null;
        }

        Field o;
        o = new Field();
        o.Init();
        o.Class = className;
        o.ItemClass = itemClassName;
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

            if (!(ka == "Node"))
            {
                Class k;
                k = (Class)table.Get(ka);

                if (k == null)
                {
                    return false;
                }

                listInfra.TableAdd(k.Derive, a.Name, a);
            }
        }

        table.IterSet(iter);
        
        while (iter.Next())
        {
            Class a;
            a = (Class)iter.Value;

            if (0 < a.Derive.Count)
            {
                if (0 < a.Field.Count)
                {
                    return false;
                }
            }
        }

        return true;
    }

    protected virtual bool CheckArrayField()
    {
        Table table;
        table = this.ClassTable;

        Iter iter;
        iter = table.IterCreate();
        table.IterSet(iter);

        while (iter.Next())
        {
            Class a;
            a = (Class)iter.Value;

            int n;
            n = 0;

            Table tableA;
            tableA = a.Field;

            Iter iterA;
            iterA = tableA.IterCreate();
            tableA.IterSet(iterA);
            
            while (iterA.Next())
            {
                Field aa;
                aa = (Field)iterA.Value;

                if (!(aa.ItemClass == null))
                {
                    n = n + 1;
                }
            }

            if (1 < n)
            {
                return false;
            }

            if (n == 1)
            {
                if (1 < tableA.Count)
                {
                    return false;
                }
            }
        }
        return true;
    }

    protected virtual bool CheckIsName(string value)
    {
        NameCheck nameCheck;
        nameCheck = this.NameCheck;

        Text textA;
        textA = this.TextA;
        StringData stringDataA;
        stringDataA = this.StringDataA;

        this.TextStringGet(textA, stringDataA, value);

        return nameCheck.IsName(textA);
    }

    protected virtual bool TextStringGet(Text text, StringData data, string o)
    {
        data.Value = o;

        text.Data = data;
        text.Range.Index = 0;
        text.Range.Count = o.Length;
        return true;
    }
}