namespace Z.Tool.Saber.NodeList;

public class TravelPathGen : TravelGen
{
    public override bool Init()
    {
        base.Init();

        this.PathOutput = this.S("../../Saber/Saber.Console/PathTravel_Part.cs");
        this.PathSource = this.GetPath(this.S("PathSource"));
        this.PathArray = this.GetPath(this.S("PathArray"));
        this.PathExecuteNode = this.GetPath(this.S("PathExecuteNode"));
        this.PathField = this.GetPath(this.S("PathField"));
        this.PathInitStringMaide = this.GetPath(this.S("PathInitStringMaide"));
        this.ValueOverride = this.S("override");
        return true;
    }

    protected virtual String PathInitStringMaide { get; set; }
    protected virtual String TextInitStringMaide { get; set; }
    protected virtual Table FieldTable { get; set; }
    protected virtual String ValueOverride { get; set; }

    public override bool Execute()
    {
        this.TextSource = this.StorageTextRead(this.PathSource);
        this.TextNode = this.StorageTextRead(this.PathNode);
        this.TextDerive = this.StorageTextRead(this.PathDerive);
        this.TextExecuteNode = this.StorageTextRead(this.PathExecuteNode);
        this.TextArray = this.StorageTextRead(this.PathArray);
        this.TextField = this.StorageTextRead(this.PathField);
        this.TextInitStringMaide = this.StorageTextRead(this.PathInitStringMaide);

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
        k = this.Place(k, "#InitStringMaide#", initStringMaide);
        k = this.Place(k, "#StringFieldList#", stringFieldList);
        k = this.Place(k, "#NodeList#", nodeList);

        String a;
        a = this.StringCreate(k);

        this.StorageTextWrite(this.PathOutput, a);
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
        table = this.TableCreateStringLess();

        Table classTable;
        classTable = this.ClassTable;

        Iter iter;
        iter = classTable.IterCreate();
        classTable.IterSet(iter);

        while (iter.Next())
        {
            Class varClass;
            varClass = iter.Value as Class;

            Iter iterA;
            iterA = varClass.Field.IterCreate();
            varClass.Field.IterSet(iterA);

            while (iterA.Next())
            {
                Field field;
                field = iterA.Value as Field;

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
        k = this.Place(k, "#StringFieldSetList#", ka);

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
            k = iter.Value as String;

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
            k = iter.Value as String;

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
        k = this.Place(k, "#VarName#", varName);
        k = this.Place(k, "#ItemClassName#", itemClassName);
        k = this.Place(k, "#ItemDeclareClassName#", itemDeclareClassName);

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
            if (this.TextSame(k, this.TA(this.SClass)))
            {
                b = true;
            }
        }
        if (!b)
        {
            if (this.TextSame(k, this.TA(this.SField)))
            {
                b = true;
            }
        }
        if (!b)
        {
            if (this.TextSame(k, this.TA(this.SMaide)))
            {
                b = true;
            }
        }
        if (!b)
        {
            if (this.TextSame(k, this.TA(this.SVar)))
            {
                b = true;
            }
        }
        if (!b)
        {
            if (this.TextSame(k, this.TA(this.SCount)))
            {
                b = true;
            }
        }

        if (b)
        {
            StringAdd h;
            h = new StringAdd();
            h.Init();

            StringAdd hh;
            hh = this.StringAdd;

            this.StringAdd = h;

            this.AddClear().AddS("Node").Add(className);

            String a;
            a = this.AddResult();

            this.StringAdd = hh;

            return a;
            
        }

        return className;
    }

    protected override String Virtual()
    {
        return this.ValueOverride;
    }
}