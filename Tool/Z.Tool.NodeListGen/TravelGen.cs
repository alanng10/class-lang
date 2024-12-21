namespace Z.Tool.NodeListGen;

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

    public virtual bool Execute()
    {
        this.TextSource = this.ToolInfra.StorageTextRead(this.PathSource);
        this.TextNode = this.ToolInfra.StorageTextRead(this.PathNode);
        this.TextDerive = this.ToolInfra.StorageTextRead(this.PathDerive);
        this.TextExecuteNode = this.ToolInfra.StorageTextRead(this.PathExecuteNode);
        this.TextArray = this.ToolInfra.StorageTextRead(this.PathArray);
        this.TextField = this.ToolInfra.StorageTextRead(this.PathField);

        this.TextVirtual = this.Virtual();

        String nodeList;
        nodeList = this.NodeList();

        Text k;
        k = this.TextCreate(this.TextSource);
        k = this.Replace(k, "#NodeList#", nodeList);
    
        String a;
        a = this.StringCreate(k);

        this.ToolInfra.StorageTextWrite(this.PathOutput, a);
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
            varClass = (Class)iter.Value;

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
        k = this.Replace(k, "#Virtual#", this.TextVirtual);
        k = this.Replace(k, "#ClassName#", className);
        k = this.Replace(k, "#DeclareClassName#", declareClassName);
        k = this.Replace(k, "#VarName#", varName);
        k = this.Replace(k, "#State#", state);

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
        hh = this.ToolInfra.StringAdd;

        this.ToolInfra.StringAdd = h;

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
            k = this.Replace(k, "#VarName#", varName);
            k = this.Replace(k, "#DeriveClassName#", className);
            k = this.Replace(k, "#DeriveDeclareClassName#", declareClassName);

            String ka;
            ka = this.StringCreate(k);

            this.Add(ka);
        }

        String a;
        a = this.AddResult();

        this.ToolInfra.StringAdd = hh;

        return a;
    }

    protected virtual String ArrayState(Class varClass, String varName)
    {
        StringJoin h;
        h = new StringJoin();
        h.Init();

        StringJoin hh;
        hh = this.ToolInfra.StringAdd;

        this.ToolInfra.StringAdd = h;

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
        k = this.Replace(k, "#VarName#", varName);
        k = this.Replace(k, "#ItemClassName#", itemClassName);
        k = this.Replace(k, "#ItemDeclareClassName#", itemDeclareClassName);

        String ke;
        ke = this.StringCreate(k);

        this.Add(ka);
        this.AddLine();
        this.Add(ke);

        String a;
        a = this.AddResult();

        this.ToolInfra.StringAdd = hh;

        return a;
    }

    protected virtual String FieldState(Class varClass, String varName)
    {
        StringJoin h;
        h = new StringJoin();
        h.Init();

        StringJoin hh;
        hh = this.ToolInfra.StringAdd;

        this.ToolInfra.StringAdd = h;

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
            aa = (Field)iter.Value;

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

        this.ToolInfra.StringAdd = hh;

        return a;
    }

    protected virtual String ExecuteNode(String varName)
    {
        Text k;
        k = this.TextCreate(this.TextExecuteNode);
        k = this.Replace(k, "#VarName#", varName);

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
        k = this.Replace(k, "#FieldClassName#", fieldClassName);
        k = this.Replace(k, "#VarName#", varName);
        k = this.Replace(k, "#FieldName#", fieldName);

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
            if (this.TextSame(ka, this.TextCreate(this.S("Class"))))
            {
                b = true;
            }
        }
        if (!b)
        {
            if (this.TextSame(ka, this.TextCreate(this.S("Field"))))
            {
                b = true;
            }
        }
        if (!b)
        {
            if (this.TextSame(ka, this.TextCreate(this.S("Maide"))))
            {
                b = true;
            }
        }
        if (!b)
        {
            if (this.TextSame(ka, this.TextCreate(this.S("Var"))))
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
        hh = this.ToolInfra.StringAdd;

        this.ToolInfra.StringAdd = h;

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

        this.ToolInfra.StringAdd = hh;

        return a;
    }

    protected virtual String GetPath(String name)
    {
        return this.AddClear().AddS("ToolData/Saber/Travel").Add(name).AddS(".txt").AddResult();
    }
}