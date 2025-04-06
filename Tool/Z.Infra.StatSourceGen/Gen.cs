namespace Z.Infra.StatSourceGen;

public class Gen : ToolBase
{
    public override bool Init()
    {
        base.Init();
        this.SourceFileName = this.S("ToolData/Infra/Source.txt");
        this.MethodFileName = this.S("ToolData/Infra/Method.txt");
        this.ShareVarFileName = this.S("ToolData/Infra/ShareVar.txt");
        this.ItemListFileName = this.S("ToolData/Infra/ItemList.txt");

        this.ClassName = this.S("");
        this.ScopeName = this.S("Qt");
        this.ScopeSeparator = this.S("::");
        this.ValuePrefix = this.S("");
        this.ValuePostfix = this.S("");
        this.ValueOffset = this.S("");
        this.NamePrefix = this.S("");
        this.NamePostfix = this.S("");
        return true;
    }

    public virtual String ClassName { get; set; }
    public virtual String ScopeName { get; set; }
    public virtual String ScopeSeparator { get; set; }
    public virtual String ValuePrefix { get; set; }
    public virtual String ValuePostfix { get; set; }
    public virtual String ValueOffset { get; set; }
    public virtual String NamePrefix { get; set; }
    public virtual String NamePostfix { get; set; }
    public virtual String SourceFileName { get; set; }
    public virtual String MethodFileName { get; set; }
    public virtual String ShareVarFileName { get; set; }
    public virtual String ItemListFileName { get; set; }
    public virtual String OutputFilePath { get; set; }
    protected virtual Array LineArray { get; set; }
    protected virtual Table ItemTable { get; set; }

    public virtual long Execute()
    {
        this.ExecuteItemList();

        String sourceText;
        sourceText = this.StorageTextRead(this.SourceFileName);

        Text k;
        k = this.TextCreate(sourceText);

        String methodList;
        methodList = this.GetMethodList();

        String shareVarList;
        shareVarList = this.GetShareVarList();

        k = this.Place(k, "#ShareVarList#", shareVarList);
        k = this.Place(k, "#MethodList#", methodList);

        String a;
        a = this.StringCreate(k);

        this.OutputFilePath = this.GetOutputFilePath();

        this.StorageTextWrite(this.OutputFilePath, a);
        return 0;
    }

    protected virtual bool ExecuteItemList()
    {
        String a;
        a = this.StorageTextRead(this.ItemListFileName);

        this.LineArray = this.TextLineString(a);

        this.ItemTable = this.TableCreateStringLess();

        Iter iter;
        iter = this.LineArray.IterCreate();
        this.LineArray.IterSet(iter);
        while (iter.Next())
        {
            String line;
            line = iter.Value as String;

            Entry entry;
            entry = this.GetItemEntry(line);

            this.ItemTable.Add(entry);
        }
        return true;
    }

    protected virtual Entry GetItemEntry(String line)
    {
        Entry a;
        a = new Entry();
        a.Init();
        a.Index = line;
        a.Value = line;
        return a;
    }

    protected virtual String GetMethodList()
    {
        String maideText;
        maideText = this.StorageTextRead(this.MethodFileName);

        Text ka;
        ka = this.TextCreate(maideText);
        ka = this.Place(ka, "#ClassName#", this.ClassName);
        ka = this.Place(ka, "#NamePrefix#", this.NamePrefix);
        ka = this.Place(ka, "#NamePostfix#", this.NamePostfix);
        ka = this.Place(ka, "#ScopeName#", this.ScopeName);
        ka = this.Place(ka, "#ScopeSeparator#", this.ScopeSeparator);
        ka = this.Place(ka, "#ValuePrefix#", this.ValuePrefix);
        ka = this.Place(ka, "#ValuePostfix#", this.ValuePostfix);
        ka = this.Place(ka, "#ValueOffset#", this.ValueOffset);

        String oo;
        oo = this.StringCreate(ka);

        this.AddClear();

        Iter iter;
        iter = this.ItemTable.IterCreate();
        this.ItemTable.IterSet(iter);

        long i;
        i = 0;
        while (iter.Next())
        {
            String k;
            k = this.GetItemMethod(oo, iter, i);
            
            this.Add(k);

            i = i + 1;
        }

        String a;
        a = this.AddResult();
        return a;
    }

    protected virtual String GetShareVarList()
    {
        String shareVarText;
        shareVarText = this.StorageTextRead(this.ShareVarFileName);

        Text k;
        k = this.TextCreate(shareVarText);
        k = this.Place(k, "#ClassName#", this.ClassName);
        k = this.Place(k, "#NamePrefix#", this.NamePrefix);
        k = this.Place(k, "#NamePostfix#", this.NamePostfix);
        k = this.Place(k, "#ScopeName#", this.ScopeName);
        k = this.Place(k, "#ScopeSeparator#", this.ScopeSeparator);
        k = this.Place(k, "#ValuePrefix#", this.ValuePrefix);
        k = this.Place(k, "#ValuePostfix#", this.ValuePostfix);
        k = this.Place(k, "#ValueOffset#", this.ValueOffset);

        String oo;
        oo = this.StringCreate(k);

        this.AddClear();

        Iter iter;
        iter = this.ItemTable.IterCreate();
        this.ItemTable.IterSet(iter);
        long i;
        i = 0;
        while (iter.Next())
        {
            String kk;
            kk = this.GetItemShareVar(oo, iter, i);

            this.Add(kk);

            i = i + 1;
        }

        String a;
        a = this.AddResult();
        return a;
    }

    protected virtual String GetItemShareVar(String shareVar, Iter iter, long index)
    {
        String aa;
        aa = (String)iter.Index;

        String ka;
        ka = (String)iter.Value;

        String kb;
        kb = this.S(index.ToString());

        Text k;
        k = this.TextCreate(shareVar);
        k = this.Place(k, "#ItemName#", aa);
        k = this.Place(k, "#ItemValue#", ka);
        k = this.Place(k, "#ItemIndex#", kb);

        String a;
        a = this.StringCreate(k);
        return a;
    }

    protected virtual String GetItemMethod(String method, Iter iter, long index)
    {
        String aa;
        aa = (String)iter.Index;

        String ka;
        ka = (String)iter.Value;

        String kb;
        kb = this.S(index.ToString());

        Text k;
        k = this.TextCreate(method);
        k = this.Place(k, "#ItemName#", aa);
        k = this.Place(k, "#ItemValue#", ka);
        k = this.Place(k, "#ItemIndex#", kb);

        String a;
        a = this.StringCreate(k);
        return a;
    }

    protected virtual String GetOutputFilePath()
    {
        return this.AddClear().AddS("../../Infra/Infra/Stat_").Add(this.ClassName).AddS(".cpp").AddResult();
    }
}