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

    public virtual bool Execute()
    {
        string textSource;
        textSource = this.ToolInfra.StorageTextRead(this.PathSource);

        string nodeList;
        nodeList = this.NodeList();

        string k;
        k = textSource.Replace("#NodeList#", nodeList);
    
        this.ToolInfra.StorageTextWrite(this.PathOutput, k);
        return true;
    }

    protected virtual string NodeList()
    {
        StringJoin kk;
        kk = new StringJoin();
        kk.Init();

        string textNode;
        textNode = this.ToolInfra.StorageTextRead(this.PathNode);

        string varVirtual;
        varVirtual = this.Virtual();

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
            nodeString = this.Node(textNode, varVirtual, varClass);

            kk.Append(nodeString);
        }

        string a;
        a = kk.Result();
        return a;
    }

    protected virtual string Node(string textNode, string varVirtual, Class varClass)
    {
        string className;
        className = varClass.Name;

        string varName;
        varName = this.VarName(varClass.Name);

        string state;
        state = this.State(varName, varClass);

        string k;
        k = textNode;
        k = k.Replace("#Virtual#", varVirtual);
        k = k.Replace("#ClassName#", className);
        k = k.Replace("#VarName#", varName);
        k = k.Replace("#State#", state);
        return k;
    }

    protected virtual string State(string varName, Class varClass)
    {
        return null;
    }

    protected virtual string Field(string textField, string varName, Field field)
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
        k = textField;
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