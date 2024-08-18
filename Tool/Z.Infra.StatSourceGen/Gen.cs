namespace Z.Infra.StatSourceGen;

public class Gen : ToolGen
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

    public virtual int Execute()
    {
        this.ExecuteItemList();

        String sourceText;
        sourceText = this.ToolInfra.StorageTextRead(this.SourceFileName);

        Text k;
        k = this.TextCreate(sourceText);

        String methodList;
        methodList = this.GetMethodList();

        String shareVarList;
        shareVarList = this.GetShareVarList();

        k = this.Replace(k, "#ShareVarList#", shareVarList);
        k = this.Replace(k, "#MethodList#", methodList);

        String a;
        a = this.StringCreate(k);

        this.OutputFilePath = this.GetOutputFilePath();

        this.ToolInfra.StorageTextWrite(this.OutputFilePath, a);
        return 0;
    }

    protected virtual bool ExecuteItemList()
    {
        String a;
        a = this.ToolInfra.StorageTextRead(this.ItemListFileName);

        this.LineArray = this.ToolInfra.TextSplitLineString(a);

        this.ItemTable = this.ToolInfra.TableCreateStringCompare();

        Iter iter;
        iter = this.LineArray.IterCreate();
        this.LineArray.IterSet(iter);
        while (iter.Next())
        {
            String line;
            line = (String)iter.Value;

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
        string methodText;
        methodText = this.ToolInfra.StorageTextRead(this.MethodFileName);

        StringBuilder sa;
        sa = new StringBuilder(methodText);
        sa.Replace("#ClassName#", this.ClassName);
        sa.Replace("#NamePrefix#", this.NamePrefix);
        sa.Replace("#NamePostfix#", this.NamePostfix);
        sa.Replace("#ScopeName#", this.ScopeName);
        sa.Replace("#ScopeSeparator#", this.ScopeSeparator);
        sa.Replace("#ValuePrefix#", this.ValuePrefix);
        sa.Replace("#ValuePostfix#", this.ValuePostfix);
        sa.Replace("#ValueOffset#", this.ValueOffset);

        string oo;
        oo = sa.ToString();

        StringBuilder sb;
        sb = new StringBuilder();

        Iter iter;
        iter = this.ItemTable.IterCreate();
        this.ItemTable.IterSet(iter);

        int i;
        i = 0;
        while (iter.Next())
        {
            string k;
            k = this.GetItemMethod(oo, iter, i);
            
            sb.Append(k);

            i = i + 1;
        }

        string ka;
        ka = sb.ToString();
        return ka;
    }

    protected virtual string GetShareVarList()
    {
        string shareVarText;
        shareVarText = this.ToolInfra.StorageTextRead(this.ShareVarFileName);

        StringBuilder sa;
        sa = new StringBuilder(shareVarText);
        sa.Replace("#ClassName#", this.ClassName);
        sa.Replace("#NamePrefix#", this.NamePrefix);
        sa.Replace("#NamePostfix#", this.NamePostfix);
        sa.Replace("#ScopeName#", this.ScopeName);
        sa.Replace("#ScopeSeparator#", this.ScopeSeparator);
        sa.Replace("#ValuePrefix#", this.ValuePrefix);
        sa.Replace("#ValuePostfix#", this.ValuePostfix);
        sa.Replace("#ValueOffset#", this.ValueOffset);

        string oo;
        oo = sa.ToString();

        StringBuilder sb;
        sb = new StringBuilder();

        Iter iter;
        iter = this.ItemTable.IterCreate();
        this.ItemTable.IterSet(iter);
        int i;
        i = 0;
        while (iter.Next())
        {
            string k;
            k = this.GetItemShareVar(oo, iter, i);

            sb.Append(k);

            i = i + 1;
        }

        string ka;
        ka = sb.ToString();
        return ka;
    }

    protected virtual string GetItemShareVar(string shareVar, Iter iter, int index)
    {
        string a;
        a = (string)iter.Index;

        string ka;
        ka = (string)iter.Value;

        string kb;
        kb = index.ToString();

        string k;
        k = shareVar;
        k = k.Replace("#ItemName#", a);
        k = k.Replace("#ItemValue#", ka);
        k = k.Replace("#ItemIndex#", kb);
        return k;
    }

    protected virtual string GetItemMethod(string method, Iter iter, int index)
    {
        string a;
        a = (string)iter.Index;

        string ka;
        ka = (string)iter.Value;

        string kb;
        kb = index.ToString();

        string k;
        k = method;
        k = k.Replace("#ItemName#", a);
        k = k.Replace("#ItemValue#", ka);
        k = k.Replace("#ItemIndex#", kb);
        return k;
    }

    protected virtual string GetOutputFilePath()
    {
        return "../../Infra/Infra/Stat_" + this.ClassName + ".cpp";
    }
}