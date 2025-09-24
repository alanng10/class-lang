namespace Z.Infra.ListSourceGen;

public class Gen : ToolBase
{
    public override bool Init()
    {
        base.Init();
        this.ClassFileName = this.S("ToolData/System/Class.txt");
        this.InitMethodFileName = this.S("ToolData/System/InitMaide.txt");
        this.AddMethodFileName = this.S("ToolData/System/AddMaide.txt");
        this.ArrayCompListFileName = this.S("ToolData/System/ArrayCompList.txt");
        this.ItemListFileName = this.S("ToolData/System/ItemList.txt");
        return true;
    }

    public virtual String Module { get; set; }
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
    protected virtual Array LineArray { get; set; }
    protected virtual Table ItemTable { get; set; }

    public virtual long Execute()
    {
        this.ExecuteItemList();

        String a;
        a = this.StorageTextRead(this.ClassFileName);

        Text k;        
        k = this.TextCreate(a);
        k = this.Place(k, "#Namespace#", this.Module);
        k = this.Place(k, "#ClassName#", this.ClassName);
        k = this.Place(k, "#AnyClassName#", this.AnyClassName);
        k = this.Place(k, "#BaseClassName#", this.BaseClassName);

        String aa;
        aa = null;
        bool ba;
        ba = this.Export;
        if (!ba)
        {
            aa = this.S("");
        }
        if (ba)
        {
            aa = this.S("public ");
        }

        k = this.Place(k, "#Export#", aa);

        String initMethodText;
        initMethodText = this.GetInitMethod();
        k = this.Place(k, "#InitMaide#", initMethodText);

        String fieldListText;
        fieldListText = this.GetFieldList();
        k = this.Place(k, "#FieldList#", fieldListText);

        String addMethodText;
        addMethodText = this.GetAddMethod();
        k = this.Place(k, "#AddMaide#", addMethodText);

        String arrayCompListText;
        arrayCompListText = this.GetArrayCompList();
        k = this.Place(k, "#ArrayCompList#", arrayCompListText);

        String ka;
        ka = this.StringCreate(k);

        this.StorageTextWrite(this.OutputFilePath, ka);
        return 0;
    }

    protected virtual bool ExecuteItemList()
    {
        String a;
        a = this.StorageTextRead(this.ItemListFileName);

        this.LineArray = this.StringLine(this.TextCreate(a));

        this.ItemTable = this.TableCreateStringLess();

        Iter iter;
        iter = this.LineArray.IterCreate();
        this.LineArray.IterSet(iter);
        while (iter.Next())
        {
            String line;
            line = iter.Value as String;

            TableEntry entry;
            entry = this.GetItemEntry(line);

            this.ItemTable.Add(entry);
        }
        return true;
    }

    protected virtual TableEntry GetItemEntry(String line)
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
        e = this.StorageTextRead(this.InitMethodFileName);

        String kaa;
        kaa = this.GetInitFieldList();

        Text k;
        k = this.TextCreate(e);
        k = this.Place(k, "#InitFieldList#", kaa);

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

        this.AddS("this").AddS(".").Add(index).AddS(" ").AddS(":").AddS(" ").AddS("this").AddS(".");

        this.AddInitFieldAddItem(index, value);

        this.AddS(";").AddLine();
        return true;
    }

    protected virtual bool AddInitFieldAddItem(String index, object value)
    {
        this.AddS("AddItem").AddS("(").AddS(")");
        return true;
    }

    protected virtual String GetFieldList()
    {
        this.AddClear();

        Iter iter;
        iter = this.ItemTable.IterCreate();
        this.ItemTable.IterSet(iter);
        while (iter.Next())
        {
            String index;
            index = iter.Index as String;

            object value;
            value = iter.Value;

            this.AddField(index, value);
        }

        String a;
        a = this.AddResult();
        return a;
    }

    protected virtual bool AddField(String index, object value)
    {
        this.AddIndent(1)
            .AddS("field").AddS(" ").AddS("prusate").AddS(" ")
            .Add(this.ItemClassName).AddS(" ").Add(index).AddS(" ")
            .AddS("{").AddS(" ")
            .AddS("get").AddS(" ").AddS("{").AddS(" ").AddS("return").AddS(" ").AddS("data").AddS(";").AddS(" ").AddS("}")
            .AddS(" ")
            .AddS("set").AddS(" ").AddS("{").AddS(" ").AddS("data").AddS(" ").AddS(":").AddS(" ").AddS("value").AddS(";").AddS(" ").AddS("}")
            .AddS(" ")
            .AddS("}")
            .AddLine();
        return true;
    }

    protected virtual String GetAddMethod()
    {
        String e;
        e = this.StorageTextRead(this.AddMethodFileName);

        Text k;
        k = this.TextCreate(e);
        k = this.Place(k, "#ItemClassName#", this.ItemClassName);
        k = this.Place(k, "#ArrayClassName#", this.ArrayClassName);
        k = this.Place(k, "#ClassName#", this.ClassName);
        k = this.Place(k, "#BaseClassName#", this.BaseClassName);

        String a;
        a = this.StringCreate(k);
        return a;
    }

    protected virtual String GetArrayCompList()
    {
        String e;
        e = this.StorageTextRead(this.ArrayCompListFileName);
        
        Text k;
        k = this.TextCreate(e);
        k = this.Place(k, "#ItemClassName#", this.ItemClassName);
        k = this.Place(k, "#ArrayClassName#", this.ArrayClassName);
        k = this.Place(k, "#ClassName#", this.ClassName);
        k = this.Place(k, "#BaseClassName#", this.BaseClassName);

        long count;
        count = this.ItemTable.Count;

        String aaa;
        aaa = this.S(count.ToString());

        k = this.Place(k, "#ArrayCount#", aaa);

        String a;
        a = this.StringCreate(k);
        return a;
    }
}