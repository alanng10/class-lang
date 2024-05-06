namespace Z.Infra.ListSourceGen;

public class Gen : Any
{
    public override bool Init()
    {
        base.Init();
        this.ToolInfra = ToolInfra.This;

        this.ClassFileName = "ToolData/Class.txt";
        this.InitMethodFileName = "ToolData/InitMethod.txt";
        this.AddMethodFileName = "ToolData/AddMethod.txt";
        this.ArrayCompListFileName = "ToolData/ArrayCompList.txt";
        this.ItemListFileName = "ToolData/ItemList.txt";
        return true;
    }

    public virtual string Namespace { get; set; }
    public virtual string ClassName { get; set; }
    public virtual string BaseClassName { get; set; }
    public virtual string AnyClassName { get; set; }
    public virtual bool Export { get; set; }
    public virtual string ItemClassName { get; set; }
    public virtual string ArrayClassName { get; set; }
    public virtual string ClassFileName { get; set; }
    public virtual string InitMethodFileName { get; set; }
    public virtual string AddMethodFileName { get; set; }
    public virtual string ArrayCompListFileName { get; set; }
    public virtual string ItemListFileName { get; set; }
    public virtual string OutputFilePath { get; set; }
    protected virtual ToolInfra ToolInfra { get; set; }
    protected virtual Array LineArray { get; set; }
    protected virtual Table ItemTable { get; set; }

    public virtual int Execute()
    {
        this.ExecuteItemList();

        string a;
        a = this.ToolInfra.StorageTextRead(this.ClassFileName);

        StringBuilder sb;        
        sb = new StringBuilder(a);
        sb.Replace("#Namespace#", this.Namespace);
        sb.Replace("#ClassName#", this.ClassName);
        sb.Replace("#AnyClassName#", this.AnyClassName);
        sb.Replace("#BaseClassName#", this.BaseClassName);

        string aa;
        aa = "";
        if (this.Export)
        {
            aa = "public ";
        }

        sb.Replace("#Export#", aa);

        string initMethodText;
        initMethodText = this.GetInitMethod();
        sb.Replace("#InitMethod#", initMethodText);

        string fieldListText;
        fieldListText = this.GetFieldList();
        sb.Replace("#FieldList#", fieldListText);

        string addMethodText;
        addMethodText = this.GetAddMethod();
        sb.Replace("#AddMethod#", addMethodText);

        string arrayCompListText;
        arrayCompListText = this.GetArrayCompList();
        sb.Replace("#ArrayCompList#", arrayCompListText);

        string ka;
        ka = sb.ToString();

        this.ToolInfra.StorageTextWrite(this.OutputFilePath, ka);
        return 0;
    }

    protected virtual bool ExecuteItemList()
    {
        string a;
        a = this.ToolInfra.StorageTextRead(this.ItemListFileName);

        this.LineArray = this.ToolInfra.SplitLineList(a);

        StringCompare compare;
        compare = new StringCompare();
        compare.Init();

        this.ItemTable = new Table();
        this.ItemTable.Compare = compare;
        this.ItemTable.Init();

        Iter iter;
        iter = this.LineArray.IterCreate();
        this.LineArray.IterSet(iter);
        while (iter.Next())
        {
            string line;
            line = (string)iter.Value;

            TableEntry entry;
            entry = this.GetItemEntry(line);

            this.ItemTable.Add(entry);
        }
        return true;
    }

    protected virtual TableEntry GetItemEntry(string line)
    {
        TableEntry a;
        a = new TableEntry();
        a.Init();
        a.Index = line;
        a.Value = line;
        return a;
    }

    protected virtual string GetInitMethod()
    {
        string e;
        e = this.ToolInfra.StorageTextRead(this.InitMethodFileName);

        StringBuilder sb;
        sb = new StringBuilder(e);

        string aa;
        aa = this.GetInitFieldList();

        sb.Replace("#InitFieldList#", aa);

        string a;
        a = sb.ToString();
        return a;
    }

    protected virtual string GetInitFieldList()
    {
        StringBuilder sb;
        sb = new StringBuilder();

        Iter iter;
        iter = this.ItemTable.IterCreate();
        this.ItemTable.IterSet(iter);
        while (iter.Next())
        {
            string index;
            index = (string)iter.Index;
            object value;
            value = iter.Value;
            this.AppendInitField(sb, index, value);
        }

        string a;
        a = sb.ToString();
        return a;
    }

    protected virtual bool AppendInitField(StringBuilder sb, string index, object value)
    {
        this.ToolInfra.AppendIndent(sb, 2);

        sb.Append("this").Append(".").Append(index).Append(" ").Append("=").Append(" ").Append("this").Append(".");

        this.AppendInitFieldAddItem(sb, index, value);

        sb.Append(";").Append(this.ToolInfra.NewLine);
        return true;
    }

    protected virtual bool AppendInitFieldAddItem(StringBuilder sb, string index, object value)
    {
        sb.Append("AddItem").Append("(").Append(")");
        return true;
    }

    protected virtual string GetFieldList()
    {
        StringBuilder sb;
        sb = new StringBuilder();

        Iter iter;
        iter = this.ItemTable.IterCreate();
        this.ItemTable.IterSet(iter);
        while (iter.Next())
        {
            string item;
            item = (string)iter.Index;
            this.AppendField(sb, item);
        }

        string a;
        a = sb.ToString();
        return a;
    }

    protected virtual bool AppendField(StringBuilder sb, string item)
    {
        bool b;
        b = this.Export;
        if (b)
        {
            string dataName;
            dataName = "__D_" + item;
            
            this.ToolInfra.AppendIndent(sb, 1);
            sb
                .Append("public").Append(" ").Append("virtual").Append(" ")
                .Append(this.ItemClassName).Append(" ").Append(item).Append(" ")
                .Append("{").Append(" ")
                .Append("get").Append(" ").Append("{").Append(" ").Append("return").Append(" ").Append(dataName).Append(";").Append(" ").Append("}").Append(" ")
                .Append("set").Append(" ").Append("{").Append(" ").Append(dataName).Append(" ").Append("=").Append(" ").Append("value").Append(";").Append(" ").Append("}").Append(" ")
                .Append("}")
                .Append(this.ToolInfra.NewLine);
            
            this.ToolInfra.AppendIndent(sb, 1);
            sb
                .Append("protected").Append(" ")
                .Append(this.ItemClassName).Append(" ").Append(dataName).Append(";")
                .Append(this.ToolInfra.NewLine);
        }
        if (!b)
        {
            this.ToolInfra.AppendIndent(sb, 1);
            sb
                .Append("public").Append(" ").Append("virtual").Append(" ")
                .Append(this.ItemClassName).Append(" ").Append(item).Append(" ")
                .Append("{").Append(" ").Append("get").Append(";").Append(" ").Append("set").Append(";").Append(" ").Append("}")
                .Append(this.ToolInfra.NewLine);
        }
        return true;
    }

    protected virtual string GetAddMethod()
    {
        string e;
        e = this.ToolInfra.StorageTextRead(this.AddMethodFileName);

        StringBuilder sb;
        sb = new StringBuilder(e);
        sb.Replace("#ItemClassName#", this.ItemClassName);
        sb.Replace("#ArrayClassName#", this.ArrayClassName);
        sb.Replace("#ClassName#", this.ClassName);
        sb.Replace("#BaseClassName#", this.BaseClassName);

        string a;
        a = sb.ToString();
        return a;
    }

    protected virtual string GetArrayCompList()
    {
        string e;
        e = this.ToolInfra.StorageTextRead(this.ArrayCompListFileName);

        StringBuilder sb;
        sb = new StringBuilder(e);
        sb.Replace("#ItemClassName#", this.ItemClassName);
        sb.Replace("#ArrayClassName#", this.ArrayClassName);
        sb.Replace("#ClassName#", this.ClassName);
        sb.Replace("#BaseClassName#", this.BaseClassName);

        int count;
        count = this.ItemTable.Count;

        string aaa;
        aaa = count.ToString();

        sb.Replace("#ArrayCount#", aaa);

        string a;
        a = sb.ToString();
        return a;
    }
}