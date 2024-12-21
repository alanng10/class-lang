namespace Z.Tool.NodeListGen;

public class TravelClassPathGen : TravelGen
{
    public override bool Init()
    {
        base.Init();

        this.PathOutput = this.S("../../Saber/Saber.Console/ClassPathTravel_Part.cs");

        this.PathSource = this.GetPath(this.S("ClassPathSource"));
        this.PathArray = this.GetPath(this.S("ClassPathArray"));
        this.PathExecuteNode = this.GetPath(this.S("ClassPathExecuteNode"));
        this.PathField = this.GetPath(this.S("ClassPathField"));
        return true;
    }

    protected virtual String TextInitStringMaide { get; set; }
    protected virtual Table FieldTable { get; set; }

    public override bool Execute()
    {
        this.TextSource = this.ToolInfra.StorageTextRead(this.PathSource);
        this.TextNode = this.ToolInfra.StorageTextRead(this.PathNode);
        this.TextDerive = this.ToolInfra.StorageTextRead(this.PathDerive);
        this.TextExecuteNode = this.ToolInfra.StorageTextRead(this.PathExecuteNode);
        this.TextArray = this.ToolInfra.StorageTextRead(this.PathArray);
        this.TextField = this.ToolInfra.StorageTextRead(this.PathField);
        this.TextInitStringMaide = this.ToolInfra.StorageTextRead(this.GetPath(this.S("ClassPathInitStringMaide")));

        this.TextVirtual = this.Virtual();

        this.SetFieldTable();

        String initStringMaide;
        initStringMaide = this.InitStringMaide();

        String stringFieldList;
        stringFieldList = this.StringFieldList();

        String nodeList;
        nodeList = this.NodeList();

        Text k;
        k = this.TextCreate(this.TextSource);
        k = this.Replace(k, "#InitStringMaide#", initStringMaide);
        k = this.Replace(k, "#StringFieldList#", stringFieldList);
        k = this.Replace(k, "#NodeList#", nodeList);

        String a;
        a = this.StringCreate(k);

        this.ToolInfra.StorageTextWrite(this.PathOutput, a);
        return true;
    }

    protected override String Node(Class varClass)
    {
        if (varClass.AnyInt == 1)
        {
            return this.TextInfra.Zero;
        }

        return base.Node(varClass);
    }

    protected virtual bool SetFieldTable()
    {
        Table table;
        table = this.ToolInfra.TableCreateStringLess();

        Table classTable;
        classTable = this.ClassTable;

        Iter iter;
        iter = classTable.IterCreate();
        classTable.IterSet(iter);

        while (iter.Next())
        {
            Class varClass;
            varClass = (Class)iter.Value;

            Iter iterA;
            iterA = varClass.Field.IterCreate();
            varClass.Field.IterSet(iterA);

            while (iterA.Next())
            {
                Field field;
                field = (Field)iterA.Value;

                this.ListInfra.TableAdd(table, field.Name, field.Name);
            }
        }

        this.FieldTable = table;
        return true;
    }

    protected virtual String InitStringMaide()
    {
        String ka;
        ka = this.StringFieldSetList();

        Text k;
        k = this.TextCreate(this.TextInitStringMaide);
        k = this.Replace(k, "#StringFieldSetList#", ka);

        String a;
        a = this.StringCreate(k);

        return a;
    }

    protected virtual String StringFieldSetList()
    {
        String ka;
        String kb;
        String kc;
        ka = this.S("this.SField");
        kb = this.S(" = this.S(\"");
        kc = this.S("\");\n");
        
        this.AddClear();

        Iter iter;
        iter = this.FieldTable.IterCreate();
        this.FieldTable.IterSet(iter);

        while (iter.Next())
        {
            String k;
            k = (String)iter.Value;

            this.AddIndent(2).Add(ka).Add(k).Add(kb).Add(k).Add(kc);
        }

        String a;
        a = this.AddResult();
        return a;
    }

    protected virtual String StringFieldList()
    {
        String ka;
        String kb;
        ka = this.S("protected virtual String SField");
        kb = this.S(" { get; set; }\n");

        this.AddClear();

        Iter iter;
        iter = this.FieldTable.IterCreate();
        this.FieldTable.IterSet(iter);

        while (iter.Next())
        {
            String k;
            k = (String)iter.Value;

            this.AddIndent(1).Add(ka).Add(k).Add(kb);
        }

        String a;
        a = this.AddResult();
        return a;
    }

    protected override String ArrayState(Class varClass, String varName)
    {
        Iter iter;
        iter = varClass.Field.IterCreate();
        varClass.Field.IterSet(iter);

        iter.Next();

        Field field;
        field = (Field)iter.Value;

        String itemClassName;
        itemClassName = field.ItemClass;

        String itemDeclareClassName;
        itemDeclareClassName = this.DeclareClassName(itemClassName);

        Text k;
        k = this.TextCreate(this.TextArray);
        k = this.Replace(k, "#VarName#", varName);
        k = this.Replace(k, "#ItemClassName#", itemClassName);
        k = this.Replace(k, "#ItemDeclareClassName#", itemDeclareClassName);

        String a;
        a = this.StringCreate(k);
        return a;
    }

    protected override String DeclareClassName(String className)
    {
        Text k;
        k = this.TextCreate(className);

        bool b;
        b = false;
        if (!b)
        {
            if (this.TextSame(k, this.TextCreate(this.S("Class"))))
            {
                b = true;
            }
        }
        if (!b)
        {
            if (this.TextSame(k, this.TextCreate(this.S("Field"))))
            {
                b = true;
            }
        }
        if (!b)
        {
            if (this.TextSame(k, this.TextCreate(this.S("Maide"))))
            {
                b = true;
            }
        }
        if (!b)
        {
            if (this.TextSame(k, this.TextCreate(this.S("Var"))))
            {
                b = true;
            }
        }
        if (!b)
        {
            if (this.TextSame(k, this.TextCreate(this.S("Count"))))
            {
                b = true;
            }
        }

        if (b)
        {
            StringJoin h;
            h = new StringJoin();
            h.Init();

            StringJoin hh;
            hh = this.ToolInfra.StringAdd;

            this.ToolInfra.StringAdd = h;

            this.AddClear().AddS("Node").Add(className);

            String a;
            a = this.AddResult();

            this.ToolInfra.StringAdd = hh;

            return a;
            
        }

        return className;
    }

    protected override String Virtual()
    {
        return this.S("override");
    }
}