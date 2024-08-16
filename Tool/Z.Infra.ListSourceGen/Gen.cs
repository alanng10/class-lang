namespace Z.Infra.ListSourceGen;

public class Gen : Any
{
    public override bool Init()
    {
        base.Init();
        this.TextInfra = TextInfra.This;
        this.ToolInfra = ToolInfra.This;

        this.ClassFileName = this.S("ToolData/System/Class.txt");
        this.InitMethodFileName = this.S("ToolData/System/InitMaide.txt");
        this.AddMethodFileName = this.S("ToolData/System/AddMaide.txt");
        this.ArrayCompListFileName = this.S("ToolData/System/ArrayCompList.txt");
        this.ItemListFileName = this.S("ToolData/System/ItemList.txt");
        return true;
    }

    public virtual String Namespace { get; set; }
    public virtual String ClassName { get; set; }
    public virtual String BaseClassName { get; set; }
    public virtual String AnyClassName { get; set; }
    public virtual bool Export { get; set; }
    public virtual String ItemClassName { get; set; }
    public virtual String ArrayClassName { get; set; }
    public virtual String ClassFileName { get; set; }
    public virtual String InitMethodFileName { get; set; }
    public virtual String AddMethodFileName { get; set; }
    public virtual String ArrayCompListFileName { get; set; }
    public virtual String ItemListFileName { get; set; }
    public virtual String OutputFilePath { get; set; }
    protected virtual TextInfra TextInfra { get; set; }
    protected virtual ToolInfra ToolInfra { get; set; }
    protected virtual Array LineArray { get; set; }
    protected virtual Table ItemTable { get; set; }

    public virtual int Execute()
    {
        this.ExecuteItemList();

        String a;
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
        sb.Replace("#InitMaide#", initMethodText);

        string fieldListText;
        fieldListText = this.GetFieldList();
        sb.Replace("#FieldList#", fieldListText);

        string addMethodText;
        addMethodText = this.GetAddMethod();
        sb.Replace("#AddMaide#", addMethodText);

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

        this.ItemTable = this.ToolInfra.TableCreateStringCompare();

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

    protected virtual String GetInitMethod()
    {
        String e;
        e = this.ToolInfra.StorageTextRead(this.InitMethodFileName);

        Text ka;
        ka = this.TextCreateString(e);

        Text kaa;
        kaa = this.TextCreateString(this.GetInitFieldList());

        Text kka;
        kka = this.TextCreateString(this.S("#InitFieldList#"));
        
        Text k;
        k = this.TextReplace(ka, kka, kaa);

        String a;
        a = this.StringCreate(k);
        return a;
    }

    protected virtual String GetInitFieldList()
    {
        this.AddClear();

        Iter iter;
        iter = this.ItemTable.IterCreate();
        this.ItemTable.IterSet(iter);
        while (iter.Next())
        {
            String index;
            index = (String)iter.Index;
            object value;
            value = iter.Value;
            this.AddInitField(index, value);
        }

        String a;
        a = this.AddResult();
        return a;
    }

    protected virtual bool AddInitField(String index, object value)
    {
        this.AddIndent(2);

        this.AddValue("this").AddChar('.').Add(index).AddChar(' ').AddChar(':').AddChar(' ').AddValue("this").AddChar('.');

        this.AddInitFieldAddItem(index, value);

        this.AddChar(';').Add(this.ToolInfra.NewLine);
        return true;
    }

    protected virtual bool AddInitFieldAddItem(String index, object value)
    {
        this.AddValue("AddItem").AddChar('(').AddChar(')');
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
        this.ToolInfra.AppendIndent(sb, 1);
        sb
            .Append("field").Append(" ").Append("prusate").Append(" ")
            .Append(this.ItemClassName).Append(" ").Append(item).Append(" ")
            .Append("{").Append(" ")
            .Append("get").Append(" ").Append("{").Append(" ").Append("return").Append(" ").Append("data").Append(";").Append(" ").Append("}")
            .Append(" ")
            .Append("set").Append(" ").Append("{").Append(" ").Append("data").Append(" ").Append(":").Append(" ").Append("value").Append(";").Append(" ").Append("}")
            .Append(" ")
            .Append("}")
            .Append(this.ToolInfra.NewLine);
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

    protected virtual Text TextCreateString(String o)
    {
        return this.TextInfra.TextCreateStringData(o, null);
    }

    protected virtual String StringCreate(Text text)
    {
        return this.TextInfra.StringCreate(text);
    }

    protected virtual Array TextSplit(Text text, Text delimit)
    {
        return this.ToolInfra.TextSplit(text, delimit);
    }

    protected virtual Text TextReplace(Text text, Text delimit, Text join)
    {
        return this.ToolInfra.TextReplace(text, delimit, join);
    }

    protected virtual Gen Add(String a)
    {
        this.ToolInfra.Add(a);
        return this;
    }

    protected virtual Gen AddChar(uint a)
    {
        this.ToolInfra.AddChar(a);
        return this;
    }

    protected virtual Gen AddValue(string o)
    {
        this.ToolInfra.AddValue(o);
        return this;
    }

    protected virtual Gen AddClear()
    {
        this.ToolInfra.AddClear();
        return this;
    }

    protected virtual String AddResult()
    {
        return this.ToolInfra.AddResult();
    }

    protected virtual Gen AddIndent(long indent)
    {
        this.ToolInfra.AddIndent(indent);
        return this;
    }
    
    protected virtual String S(string o)
    {
        return this.ToolInfra.S(o);
    }
}