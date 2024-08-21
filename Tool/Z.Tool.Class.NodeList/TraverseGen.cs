namespace Z.Tool.Class.NodeList;

public class TraverseGen : ToolGen
{
    public override bool Init()
    {
        base.Init();

        this.PathOutput = this.S("../../Class/Class.Node/Traverse.cs");

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

    protected virtual string State(Class varClass, string varName)
    {
        if (this.IsDeriveState(varClass))
        {
            return this.DeriveState(varClass, varName);
        }

        if (varClass.Field.Count == 1)
        {
            Iter iter;
            iter = varClass.Field.IterCreate();
            varClass.Field.IterSet(iter);

            iter.Next();
            
            Field field;
            field = (Field)iter.Value;

            if (!(field.ItemClass == null))
            {
                return this.ArrayState(varClass, field, varName);
            }
        }

        string k;
        k = this.FieldState(varClass, varName);
        return k;
    }

    protected virtual string DeriveState(Class varClass, string varName)
    {
        StringJoin sj;
        sj = new StringJoin();
        sj.Init();

        string newLine;
        newLine = this.ToolInfra.NewLine;

        this.Append(sj, newLine);

        Table table;
        table = varClass.Derive; 

        Iter iter;
        iter = table.IterCreate();
        table.IterSet(iter);

        while (iter.Next())
        {
            Class aa;
            aa = (Class)iter.Value;

            string className;
            className = aa.Name;

            string declareClassName;
            declareClassName = this.DeclareClassName(className);

            string k;
            k = this.TextDerive;
            k = k.Replace("#VarName#", varName);
            k = k.Replace("#DeriveClassName#", className);
            k = k.Replace("#DeriveDeclareClassName#", declareClassName);

            this.Append(sj, k);
        }

        string a;
        a = sj.Rest();
        return a;
    }

    protected virtual string ArrayState(Class varClass, Field field, string varName)
    {
        StringJoin sj;
        sj = new StringJoin();
        sj.Init();

        string newLine;
        newLine = this.ToolInfra.NewLine;

        string itemClassName;
        itemClassName = field.ItemClass;

        string itemDeclareClassName;
        itemDeclareClassName = this.DeclareClassName(itemClassName);

        string ka;
        ka = this.ExecuteNode(varName);

        string k;
        k = this.TextArray;
        k = k.Replace("#VarName#", varName);
        k = k.Replace("#ItemClassName#", itemClassName);
        k = k.Replace("#ItemDeclareClassName#", itemDeclareClassName);

        this.Append(sj, ka);
        this.Append(sj, newLine);
        this.Append(sj, k);

        string a;
        a = sj.Rest();        
        return a;
    }

    protected virtual string FieldState(Class varClass, string varName)
    {
        StringJoin sj;
        sj = new StringJoin();
        sj.Init();

        string ka;
        ka = this.ExecuteNode(varName);

        this.Append(sj, ka);

        string newLine;
        newLine = this.ToolInfra.NewLine;

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
                string k;
                k = this.Field(aa, varName);

                if (!ba)
                {
                    this.Append(sj, newLine);
                    ba = true;
                }

                this.Append(sj, k);
            }
        }

        string a;
        a = sj.Rest();
        return a;
    }

    protected virtual string ExecuteNode(string varName)
    {
        string k;
        k = this.TextExecuteNode;
        k = k.Replace("#VarName#", varName);
        return k;
    }

    protected virtual string Field(Field field, string varName)
    {
        string fieldClassName;
        fieldClassName = field.Class;

        string fieldName;
        fieldName = field.Name;

        string k;
        k = this.TextField;
        k = k.Replace("#FieldClassName#", fieldClassName);
        k = k.Replace("#VarName#", varName);
        k = k.Replace("#FieldName#", fieldName);
        return k;
    }

    protected virtual String Virtual()
    {
        return this.ValueVirtual;
    }

    protected virtual bool IsDeriveState(Class varClass)
    {
        return 0 < varClass.Derive.Count;
    }

    protected virtual string DeclareClassName(string className)
    {
        return className;
    }

    protected virtual string VarName(string className)
    {
        bool b;
        b = false;
        if (!b)
        {
            if (className == "Class")
            {
                b = true;
            }
        }
        if (!b)
        {
            if (className == "Field")
            {
                b = true;
            }
        }
        if (!b)
        {
            if (className == "Maide")
            {
                b = true;
            }
        }
        if (!b)
        {
            if (className == "Var")
            {
                b = true;
            }
        }

        if (b)
        {
            return "var" + className;
        }

        char firstChar;
        firstChar = className[0];
        firstChar = char.ToLower(firstChar);

        string k;
        k = firstChar + className.Substring(1);
    
        string a;
        a = k;
        return a;
    }

    protected virtual String GetPath(String name)
    {
        return this.AddClear().AddS("ToolData/Class/Traverse").Add(name).AddS(".txt").AddResult();
    }

    protected virtual bool Append(StringJoin h, string k)
    {
        return this.ToolInfra.Append(h, k);
    }
}