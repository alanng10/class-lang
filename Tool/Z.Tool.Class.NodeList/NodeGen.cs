namespace Z.Tool.Class.NodeList;

public class NodeGen : ToolGen
{
    public override bool Init()
    {
        base.Init();
        this.BoolClass = this.TextCreate(this.S("Bool"));
        this.IntClass = this.TextCreate(this.S("Int"));
        this.BoolClassWord = this.S("bool");
        this.IntClassWord = this.S("long");
        return true;
    }

    public virtual Table ClassTable { get; set; }
    protected virtual String NodeSourceText { get; set; }
    protected virtual Text BoolClass { get; set; }
    protected virtual Text IntClass { get; set; }
    protected virtual String BoolClassWord { get; set; }
    protected virtual String IntClassWord { get; set; }

    public virtual bool Execute()
    {
        this.NodeSourceText = this.ToolInfra.StorageTextRead(this.S("ToolData/Class/NodeSource.txt"));

        Table table;
        table = this.ClassTable;

        Iter iter;
        iter = table.IterCreate();
        table.IterSet(iter);
        
        while (iter.Next())
        {
            Class varClass;
            varClass = (Class)iter.Value;

            this.ExecuteClass(varClass);
        }
        return true;
    }

    protected virtual bool ExecuteClass(Class varClass)
    {
        String fieldListString;
        fieldListString = this.GetFieldListString(varClass.Field);

        Text k;
        k = this.TextCreate(this.NodeSourceText);
        k = this.Replace(k, "#ClassName#", varClass.Name);
        k = this.Replace(k, "#BaseClassName#", varClass.Base);
        k = this.Replace(k, "#FieldList#", fieldListString);

        String ka;
        ka = this.StringCreate(k);

        String outputFilePath;
        outputFilePath = this.AddClear().AddS("../../Class/Class.Node/Z_Node_").Add(varClass.Name).AddS(".cs").AddResult();

        this.ToolInfra.StorageTextWrite(outputFilePath, ka);
        return true;
    }

    protected virtual String GetFieldListString(Table fieldList)
    {
        this.AddClear();

        Iter iter;
        iter = fieldList.IterCreate();
        fieldList.IterSet(iter);
        
        while (iter.Next())
        {
            Field field;
            field = (Field)iter.Value;
            this.AddField(field);
        }
        
        String a;
        a = this.AddResult();
        return a;
    }

    protected virtual bool AddField(Field field)
    {
        this.AddIndent(1);
        
        String className;
        className = this.GetGenFieldClassName(field.Class);

        sb
            .Append("public").Append(" ").Append("virtual").Append(" ")
            .Append(className).Append(" ").Append(field.Name).Append(" ")
            .Append("{").Append(" ")
            .Append("get").Append(";").Append(" ").Append("set").Append(";")
            .Append(" ").Append("}")
            .Append(this.ToolInfra.NewLine)
            ;
        return true;
    }

    protected virtual string GetGenFieldClassName(String fieldClassName)
    {
        String ka;
        ka = fieldClassName;

        Text k;
        k = this.TextCreate(ka);

        String a;
        a = null;
        bool b;
        b = false;
        if (!b & k == "Bool")
        {
            k = "bool";
            b = true;
        }
        if (!b & k == "Int")
        {
            k = "long";
            b = true;
        }
        return k;
    }
}