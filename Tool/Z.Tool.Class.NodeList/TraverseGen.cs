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

            sj.Append(nodeString);
        }

        string a;
        a = sj.Result();
        return a;
    }

    protected virtual string Node(Class varClass)
    {
        string className;
        className = varClass.Name;

        string varName;
        varName = this.VarName(varClass.Name);

        string state;
        state = this.State(varClass, varName);

        string k;
        k = this.TextNode;
        k = k.Replace("#Virtual#", this.TextVirtual);
        k = k.Replace("#ClassName#", className);
        k = k.Replace("#VarName#", varName);
        k = k.Replace("#State#", state);
        return k;
    }

    protected virtual string State(Class varClass, string varName)
    {
        if (0 < varClass.Derive.Count)
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

        sj.Append(newLine);

        Table table;
        table = varClass.Derive; 

        Iter iter;
        iter = table.IterCreate();
        table.IterSet(iter);

        while (iter.Next())
        {
            Class aa;
            aa = (Class)iter.Value;

            string kk;
            kk = aa.Name;

            string k;
            k = this.TextDerive;
            k = k.Replace("#VarName#", varName);
            k = k.Replace("#DeriveClassName#", kk);

            sj.Append(k);
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

        string ka;
        ka = this.ExecuteNode(varName);

        string k;
        k = this.TextArray;
        k = k.Replace("#VarName#", varName);
        k = k.Replace("#ItemClassName#", itemClassName);

        sj.Append(ka);
        sj.Append(newLine);
        sj.Append(k);

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

        sj.Append(ka);

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

            string k;
            k = this.Field(aa, varName);

            if (!(k.Length == 0))
            {
                if (!ba)
                {
                    sj.Append(newLine);
                    ba = true;
                }

                sj.Append(k);
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

        if (fieldClassName == "Bool" | fieldClassName == "Int" | fieldClassName == "String")
        {
            return "";
        }

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

    private string GetPath(string name)
    {
        return "ToolData/Traverse" + name + ".txt";
    }
}