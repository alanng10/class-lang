namespace Z.Tool.Class.NodeList;

public class TraverseGen : Any
{
    public override bool Init()
    {
        base.Init();
        this.ToolInfra = ToolInfra.This;

        this.PathOutput = "../../Class/Class.Node/Traverse.cs";

        this.PathSource = this.GetPath("Source");
        this.PathNode = this.GetPath("Node");
        this.PathDerive = this.GetPath("Derive");
        this.PathExecuteNode = this.GetPath("ExecuteNode");
        this.PathArray = this.GetPath("Array");
        this.PathField = this.GetPath("Field");
        return true;
    }

    public virtual Table ClassTable { get; set; }
    protected virtual ToolInfra ToolInfra { get; set; }
    protected virtual string PathOutput { get; set; }
    protected virtual string PathSource { get; set; }
    protected virtual string PathNode { get; set; }
    protected virtual string PathDerive { get; set; }
    protected virtual string PathExecuteNode { get; set; }
    protected virtual string PathArray { get; set; }
    protected virtual string PathField { get; set; }
    protected virtual string TextSource { get; set; }
    protected virtual string TextNode { get; set; }
    protected virtual string TextDerive { get; set; }
    protected virtual string TextExecuteNode { get; set; }
    protected virtual string TextArray { get; set; }
    protected virtual string TextField { get; set; }
    protected virtual string TextVirtual { get; set; }

    public virtual bool Execute()
    {
        this.TextSource = this.ToolInfra.StorageTextRead(this.PathSource);
        this.TextNode = this.ToolInfra.StorageTextRead(this.PathNode);
        this.TextDerive = this.ToolInfra.StorageTextRead(this.PathDerive);
        this.TextExecuteNode = this.ToolInfra.StorageTextRead(this.PathExecuteNode);
        this.TextArray = this.ToolInfra.StorageTextRead(this.PathArray);
        this.TextField = this.ToolInfra.StorageTextRead(this.PathField);

        this.TextVirtual = this.Virtual();

        string nodeList;
        nodeList = this.NodeList();

        string k;
        k = this.TextSource;
        k = k.Replace("#NodeList#", nodeList);
    
        this.ToolInfra.StorageTextWrite(this.PathOutput, k);
        return true;
    }

    protected virtual string NodeList()
    {
        StringJoin sj;
        sj = new StringJoin();
        sj.Init();

        Table table;
        table = this.ClassTable;

        Iter iter;
        iter = table.IterCreate();
        table.IterSet(iter);

        while (iter.Next())
        {
            Class varClass;
            varClass = (Class)iter.Value;

            string nodeString;
            nodeString = this.Node(varClass);

            this.Append(sj, nodeString);
        }

        string a;
        a = sj.Result();
        return a;
    }

    protected virtual string Node(Class varClass)
    {
        string className;
        className = varClass.Name;

        string declareClassName;
        declareClassName = this.DeclareClassName(className);

        string varName;
        varName = this.VarName(varClass.Name);

        string state;
        state = this.State(varClass, varName);

        string k;
        k = this.TextNode;
        k = k.Replace("#Virtual#", this.TextVirtual);
        k = k.Replace("#ClassName#", className);
        k = k.Replace("#DeclareClassName#", declareClassName);
        k = k.Replace("#VarName#", varName);
        k = k.Replace("#State#", state);
        return k;
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
        a = sj.Result();
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
        a = sj.Result();        
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
        a = sj.Result();
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

    protected virtual string Virtual()
    {
        return "virtual";
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

    protected virtual string GetPath(string name)
    {
        return "ToolData/Traverse" + name + ".txt";
    }

    protected virtual bool Append(StringJoin h, string k)
    {
        return this.ToolInfra.Append(h, k);
    }
}