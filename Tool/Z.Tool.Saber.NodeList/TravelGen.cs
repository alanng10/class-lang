namespace Z.Tool.Saber.NodeList;

public class TravelGen : ToolBase
{
    public override bool Init()
    {
        base.Init();

        this.PathOutput = this.S("../../Saber/Saber.Node/Travel.cs");

        this.PathSource = this.GetPath(this.S("Source"));
        this.PathNode = this.GetPath(this.S("Node"));
        this.PathDerive = this.GetPath(this.S("Derive"));
        this.PathExecuteNode = this.GetPath(this.S("ExecuteNode"));
        this.PathArray = this.GetPath(this.S("Array"));
        this.PathField = this.GetPath(this.S("Field"));

        this.ValueVirtual = this.S("virtual");
        this.SClass = this.S("Class");
        this.SField = this.S("Field");
        this.SMaide = this.S("Maide");
        this.SVar = this.S("Var");
        this.SCount = this.S("Count");
        return true;
    }

    public virtual Table ClassTable { get; set; }
    protected virtual String PathOutput { get; set; }
    protected virtual String PathSource { get; set; }
    protected virtual String PathNode { get; set; }
    protected virtual String PathDerive { get; set; }
    protected virtual String PathExecuteNode { get; set; }
    protected virtual String PathArray { get; set; }
    protected virtual String PathField { get; set; }
    protected virtual String TextSource { get; set; }
    protected virtual String TextNode { get; set; }
    protected virtual String TextDerive { get; set; }
    protected virtual String TextExecuteNode { get; set; }
    protected virtual String TextArray { get; set; }
    protected virtual String TextField { get; set; }
    protected virtual String TextVirtual { get; set; }
    protected virtual String ValueVirtual { get; set; }
    protected virtual String SClass { get; set; }
    protected virtual String SField { get; set; }
    protected virtual String SMaide { get; set; }
    protected virtual String SVar { get; set; }
    protected virtual String SCount { get; set; }

    public virtual bool Execute()
    {
        this.TextSource = this.StorageTextRead(this.PathSource);
        this.TextNode = this.StorageTextRead(this.PathNode);
        this.TextDerive = this.StorageTextRead(this.PathDerive);
        this.TextExecuteNode = this.StorageTextRead(this.PathExecuteNode);
        this.TextArray = this.StorageTextRead(this.PathArray);
        this.TextField = this.StorageTextRead(this.PathField);

        this.TextVirtual = this.Virtual();

        String nodeList;
        nodeList = this.NodeList();

        Text k;
        k = this.TextCreate(this.TextSource);
        k = this.Place(k, "#NodeList#", nodeList);
    
        String a;
        a = this.StringCreate(k);

        this.StorageTextWrite(this.PathOutput, a);
        return true;
    }

    protected virtual String NodeList()
    {
        this.AddClear();

        Table table;
        table = this.ClassTable;

        Iter iter;
        iter = table.IterCreate();
        table.IterSet(iter);

        while (iter.Next())
        {
            Class varClass;
            varClass = iter.Value as Class;

            String nodeString;
            nodeString = this.Node(varClass);

            this.Add(nodeString);
        }

        String a;
        a = this.AddResult();
        return a;
    }

    protected virtual String Node(Class varClass)
    {
        String className;
        className = varClass.Name;

        String declareClassName;
        declareClassName = this.DeclareClassName(className);

        String varName;
        varName = this.VarName(varClass.Name);

        String state;
        state = this.State(varClass, varName);

        Text k;
        k = this.TextCreate(this.TextNode);
        k = this.Place(k, "#Virtual#", this.TextVirtual);
        k = this.Place(k, "#ClassName#", className);
        k = this.Place(k, "#DeclareClassName#", declareClassName);
        k = this.Place(k, "#VarName#", varName);
        k = this.Place(k, "#State#", state);

        String a;
        a = this.StringCreate(k);
        return a;
    }

    protected virtual String State(Class varClass, String varName)
    {
        long n;
        n = varClass.AnyInt;

        String a;
        a = null;

        if (n == 0)
        {
            a = this.FieldState(varClass, varName);
        }

        if (n == 1)
        {
            a = this.DeriveState(varClass, varName);
        }

        if (n == 2)
        {
            a = this.ArrayState(varClass, varName);
        }
        
        return a;
    }

    protected virtual String DeriveState(Class varClass, String varName)
    {
        StringJoin h;
        h = new StringJoin();
        h.Init();

        StringJoin hh;
        hh = this.StringAdd;

        this.StringAdd = h;

        this.AddClear();

        this.AddLine();

        Table table;
        table = varClass.Derive; 

        Iter iter;
        iter = table.IterCreate();
        table.IterSet(iter);

        while (iter.Next())
        {
            Class aa;
            aa = (Class)iter.Value;

            String className;
            className = aa.Name;

            String declareClassName;
            declareClassName = this.DeclareClassName(className);

            Text k;
            k = this.TextCreate(this.TextDerive);
            k = this.Place(k, "#VarName#", varName);
            k = this.Place(k, "#DeriveClassName#", className);
            k = this.Place(k, "#DeriveDeclareClassName#", declareClassName);

            String ka;
            ka = this.StringCreate(k);

            this.Add(ka);
        }

        String a;
        a = this.AddResult();

        this.StringAdd = hh;

        return a;
    }

    protected virtual String ArrayState(Class varClass, String varName)
    {
        StringJoin h;
        h = new StringJoin();
        h.Init();

        StringJoin hh;
        hh = this.StringAdd;

        this.StringAdd = h;

        this.AddClear();

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

        String ka;
        ka = this.ExecuteNode(varName);

        Text k;
        k = this.TextCreate(this.TextArray);
        k = this.Place(k, "#VarName#", varName);
        k = this.Place(k, "#ItemClassName#", itemClassName);
        k = this.Place(k, "#ItemDeclareClassName#", itemDeclareClassName);

        String ke;
        ke = this.StringCreate(k);

        this.Add(ka);
        this.AddLine();
        this.Add(ke);

        String a;
        a = this.AddResult();

        this.StringAdd = hh;

        return a;
    }

    protected virtual String FieldState(Class varClass, String varName)
    {
        StringJoin h;
        h = new StringJoin();
        h.Init();

        StringJoin hh;
        hh = this.StringAdd;

        this.StringAdd = h;

        this.AddClear();

        String ka;
        ka = this.ExecuteNode(varName);

        this.Add(ka);

        bool ba;
        ba = false;

        Table table;
        table = varClass.Field;

        Iter iter;
        iter = table.IterCreate();
        table.IterSet(iter);

        while (iter.Next())
        {
            Field aa;
            aa = iter.Value as Field;

            if (!aa.AnyBool)
            {
                String k;
                k = this.Field(aa, varName);

                if (!ba)
                {
                    this.AddLine();
                    ba = true;
                }

                this.Add(k);
            }
        }

        String a;
        a = this.AddResult();

        this.StringAdd = hh;

        return a;
    }

    protected virtual String ExecuteNode(String varName)
    {
        Text k;
        k = this.TextCreate(this.TextExecuteNode);
        k = this.Place(k, "#VarName#", varName);

        String a;
        a = this.StringCreate(k);
        return a;
    }

    protected virtual String Field(Field field, String varName)
    {
        String fieldClassName;
        fieldClassName = field.Class;

        String fieldName;
        fieldName = field.Name;

        Text k;
        k = this.TextCreate(this.TextField);
        k = this.Place(k, "#FieldClassName#", fieldClassName);
        k = this.Place(k, "#VarName#", varName);
        k = this.Place(k, "#FieldName#", fieldName);

        String a;
        a = this.StringCreate(k);
        return a;
    }

    protected virtual String Virtual()
    {
        return this.ValueVirtual;
    }

    protected virtual String DeclareClassName(String className)
    {
        return className;
    }

    protected virtual String VarName(String className)
    {
        Text ka;
        ka = this.TextCreate(className);

        bool b;
        b = false;
        if (!b)
        {
            if (this.TextSame(ka, this.TA(this.SClass)))
            {
                b = true;
            }
        }
        if (!b)
        {
            if (this.TextSame(ka, this.TA(this.SField)))
            {
                b = true;
            }
        }
        if (!b)
        {
            if (this.TextSame(ka, this.TA(this.SMaide)))
            {
                b = true;
            }
        }
        if (!b)
        {
            if (this.TextSame(ka, this.TA(this.SVar)))
            {
                b = true;
            }
        }

        String a;
        a = null;

        StringJoin h;
        h = new StringJoin();
        h.Init();

        StringJoin hh;
        hh = this.StringAdd;

        this.StringAdd = h;

        if (b)
        {
            a = this.AddClear().AddS("var").Add(className).AddResult();   
        }

        if (!b)
        {
            Text kk;
            kk = this.TextCreate(className);
            kk.Range.Count = 1;
            kk = this.TextAlphaSite(kk);
            
            String kh;
            kh = this.StringCreate(kk);

            Range range;
            range = ka.Range;
            range.Index = range.Index + 1;
            range.Count = range.Count - 1;

            String ke;
            ke = this.StringCreate(ka);
            
            a = this.AddClear().Add(kh).Add(ke).AddResult();
        }

        this.StringAdd = hh;

        return a;
    }

    protected virtual String GetPathName(String name)
    {
        return this.AddClear().AddS("ToolData/Saber/Travel").Add(name).AddResult();
    }

    protected virtual String GetPath(String name)
    {
        String k;
        k = this.AddClear().Add(name).AddS(".txt").AddResult();

        return this.GetPathName(k);
    }
}