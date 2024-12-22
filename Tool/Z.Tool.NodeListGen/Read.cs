namespace Z.Tool.NodeListGen;

class Read : ToolBase
{
    public override bool Init()
    {
        base.Init();
        this.ClassInfra = ClassInfra.This;

        this.NameCheck = new NameCheck();
        this.NameCheck.Init();
        this.NameCheck.TextLess = this.ToolInfra.TextLess;
        this.NameCheck.CharLess = this.ToolInfra.CharLess;
        this.NameCheck.TextForm = this.ToolInfra.TextForm;

        this.BoolClass = this.TextCreate(this.S("Bool"));
        this.IntClass = this.TextCreate(this.S("Int"));
        this.StringClass = this.TextCreate(this.S("String"));

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
    protected virtual Text BoolClass { get; set; }
    protected virtual Text IntClass { get; set; }
    protected virtual Text StringClass { get; set; }
    protected virtual Text TextA { get; set; }
    protected virtual StringData StringDataA { get; set; }

    protected virtual bool SetClassTable()
    {
        ToolInfra infra;
        infra = this.ToolInfra;

        String ka;
        ka = infra.StorageTextRead(this.S("ToolData/Saber/NodeList.txt"));

        Array lineArray;        
        lineArray = this.TextLimitLineString(this.TA(ka));

        this.ClassTable = this.ClassInfra.TableCreateStringLess();

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
        varClass.Field = this.ClassInfra.TableCreateStringLess();
        varClass.Derive = this.ClassInfra.TableCreateStringLess();
        return varClass;
    }

    protected virtual Field GetField(String a)
    {
        Text k;
        k = this.TextCreate(a);

        Text oo;
        oo = this.TextCreate(this.S(" "));

        long uu;
        uu = this.TextIndex(k, oo);

        if (uu < 0)
        {
            return null;
        }

        String className;
        String itemClassName;
        itemClassName = null;
        String fieldName;
        fieldName = null;

        className = this.StringCreateRange(a, 0, uu);

        long kka;
        kka = oo.Range.Count;

        long ka;
        ka = uu + kka;

        Text kk;
        kk = this.TextCreate(className);

        Text ooa;
        ooa = this.TextCreate(this.S("Array"));

        bool b;
        b = this.TextSame(kk, ooa);
        if (b)
        {
            Range kRange;
            kRange = k.Range;

            kRange.Index = kRange.Index + ka;
            kRange.Count = kRange.Count - ka;

            long ua;
            ua = this.TextIndex(k, oo);

            if (ua < 0)
            {
                return null;
            }

            long kc;
            kc = ka + ua + kka;

            itemClassName = this.StringCreateRange(a, ka, ua);

            fieldName = this.StringCreateIndex(a, kc);
        }

        if (!b)
        {
            fieldName = this.StringCreateIndex(a, ka);
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

        Text oo;
        oo = this.TextCreate(this.S("Node"));

        Iter iter;
        iter = table.IterCreate();
        table.IterSet(iter);

        while (iter.Next())
        {
            Class a;
            a = (Class)iter.Value;

            String varBase;
            varBase = a.Base;

            Text ka;
            ka = this.TextCreate(varBase);

            if (!this.TextSame(ka, oo))
            {
                Class k;
                k = (Class)table.Get(varBase);

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

            long n;
            n = -1;

            if (n == -1)
            {
                if (0 < a.Derive.Count)
                {
                    n = 1;
                }
            }

            Table tableA;
            tableA = a.Field;

            Iter iterA;
            iterA = tableA.IterCreate();
            tableA.IterSet(iterA);

            while (iterA.Next())
            {
                Field field;
                field = (Field)iterA.Value;

                String fieldClassName;
                fieldClassName = field.Class;

                this.TextStringGet(fieldClassName);

                Text k;
                k = this.TextA;

                bool b;
                b = false;
                if (!b)
                {
                    if (this.TextSame(k, this.BoolClass))
                    {
                        b = true;
                    }
                }
                if (!b)
                {
                    if (this.TextSame(k, this.IntClass))
                    {
                        b = true;
                    }
                }
                if (!b)
                {
                    if (this.TextSame(k, this.StringClass))
                    {
                        b = true;
                    }
                }

                if (b)
                {
                    field.AnyBool = true;
                }

                if (n == -1)
                {
                    if (!(field.ItemClass == null))
                    {
                        n = 2;
                    }
                }
            }

            if (n == -1)
            {
                n = 0;
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

        return nameCheck.Name(a);
    }

    protected virtual bool TextStringGet(String o)
    {
        Text text;
        text = this.TextA;
        StringData data;
        data = this.StringDataA;
        
        data.ValueString = o;

        text.Data = data;
        text.Range.Index = 0;
        text.Range.Count = this.StringCount(o);
        return true;
    }
}