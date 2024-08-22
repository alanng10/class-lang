namespace Z.Tool.Class.NodeList;

class Read : ToolGen
{
    public override bool Init()
    {
        base.Init();
        this.ClassInfra = ClassInfra.This;

        this.NameCheck = new NameCheck();
        this.NameCheck.Init();
        this.NameCheck.TextCompare = this.ToolInfra.TextCompare;
        this.NameCheck.CharCompare = this.ToolInfra.CharCompare;
        this.NameCheck.CharForm = this.ToolInfra.CharForm;
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

        b = this.SetAny();
        if (!b)
        {
            return 40;
        }
        return 0;
    }

    public virtual Table ClassTable { get; set; }
    protected virtual ClassInfra ClassInfra { get; set; }
    protected virtual NameCheck NameCheck { get; set; }
    protected virtual Class Class { get; set; }

    protected virtual bool SetClassTable()
    {
        ToolInfra infra;
        infra = this.ToolInfra;

        String ka;
        ka = infra.StorageTextRead(this.S("ToolData/Class/NodeList.txt"));

        Array lineArray;        
        lineArray = this.TextSplitLineString(ka);

        this.ClassTable = this.ClassInfra.TableCreateStringCompare();

        long count;
        count = lineArray.Count;
        long i;
        i = 0;
        while (i < count)
        {
            String line;
            line = (String)lineArray.GetAt(i);

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

    protected virtual bool SetClassTableOneLine(String line)
    {
        if (this.StringCount(line) == 0)
        {
            return true;
        }

        Text oo;
        oo = this.TextCreate(this.S("    "));

        Text ka;
        ka = this.TextCreate(line);

        bool b;
        b = this.TextStart(ka, oo);
        if (!b)
        {
            this.EndCurrentClass();

            Class varClass;
            varClass = this.GetClass(line);
            if (varClass == null)
            {
                return false;
            }

            if (this.ClassTable.Valid(varClass.Name))
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

            long kka;
            kka = oo.Range.Count;

            Range range;
            range = ka.Range;

            range.Index = range.Index + kka;
            range.Count = range.Count - kka;

            String compLine;
            compLine = this.StringCreate(ka);

            Field ob;
            ob = this.GetField(compLine);
            if (ob == null)
            {
                return false;
            }

            if (this.Class.Field.Valid(ob.Name))
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

    protected virtual Class GetClass(String a)
    {
        Text uo;
        uo = this.TextCreate(this.S(" : "));

        Text k;
        k = this.TextCreate(a);

        long uu;
        uu = this.TextIndex(k, uo);
        if (uu < 0)
        {
            return null;
        }

        String className;
        className = this.StringCreateRange(a, 0, uu);

        String baseClassName;
        baseClassName = this.StringCreateIndex(a, uu + uo.Range.Count);

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

    protected virtual bool SetAny()
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

                string fieldClassName;
                fieldClassName = aa.Class;

                bool b;
                b = false;
                if (!b)
                {
                    if (fieldClassName == "Bool")
                    {
                        b = true;
                    }
                }
                if (!b)
                {
                    if (fieldClassName == "Int")
                    {
                        b = true;
                    }
                }
                if (!b)
                {
                    if (fieldClassName == "String")
                    {
                        b = true;
                    }
                }

                if (b)
                {
                    aa.AnyBool = true;
                    n = n + 1;
                }
            }

            a.AnyInt = n;
        }
        return true;
    }

    protected virtual bool CheckIsName(String value)
    {
        NameCheck nameCheck;
        nameCheck = this.NameCheck;

        Text a;
        a = this.TextCreate(value);

        return nameCheck.IsName(a);
    }
}