namespace Z.Tool.ToolEntryGen;

class Gen : Any
{
    public override bool Init()
    {
        base.Init();
        this.TextInfra = TextInfra.This;
        this.ToolInfra = ToolInfra.This;
        return true;
    }

    protected virtual TextInfra TextInfra { get; set; }
    protected virtual ToolInfra ToolInfra { get; set; }
    protected virtual String SourceTemplate { get; set; }

    public virtual int Execute()
    {
        this.SourceTemplate = this.ToolInfra.StorageTextRead(this.S("ToolData/Entry.txt"));

        this.ExecuteOne("Avalon.TextEncodeKindList");
        this.ExecuteOne("Avalon.StorageStatusList");
        this.ExecuteOne("Avalon.NetworkCaseList");
        this.ExecuteOne("Avalon.NetworkPortKindList");
        this.ExecuteOne("Avalon.NetworkStatusList");
        this.ExecuteOne("Avalon.BrushCapList");
        this.ExecuteOne("Avalon.BrushJoinList");
        this.ExecuteOne("Avalon.BrushKindList");
        this.ExecuteOne("Avalon.BrushLineList");
        this.ExecuteOne("Avalon.DrawCompList");
        this.ExecuteOne("Avalon.GradientKindList");
        this.ExecuteOne("Avalon.GradientSpreadList");
        this.ExecuteOne("Avalon.ImageFormatList");
        this.ExecuteOne("Avalon.TextAlignList");
        this.ExecuteOne("Class.CountList");
        this.ExecuteOne("Class.DelimitList");
        this.ExecuteOne("Class.ErrorKindList");
        this.ExecuteOne("Class.KeywordList");
        this.ExecuteOne("Class.NodeList");
        this.ExecuteOne("Class.TaskKindList");
        this.ExecuteOne("Infra.StatThreadCase");
        this.ExecuteOne("Infra.StatStreamKind");
        this.ExecuteOne("Infra.StatNetworkCase");
        this.ExecuteOne("Infra.StatNetworkPortKind");
        this.ExecuteOne("Infra.StatNetworkStatus");
        this.ExecuteOne("Infra.StatStorageMode");
        this.ExecuteOne("Infra.StatStorageStatus");
        this.ExecuteOne("Infra.StatComp");
        this.ExecuteOne("Infra.StatBrushCap");
        this.ExecuteOne("Infra.StatBrushJoin");
        this.ExecuteOne("Infra.StatBrushKind");
        this.ExecuteOne("Infra.StatBrushLine");
        this.ExecuteOne("Infra.StatGradientKind");
        this.ExecuteOne("Infra.StatGradientSpread");
        this.ExecuteOne("Infra.StatImageFormat");
        this.ExecuteOne("Infra.StatTextAlign");
        this.ExecuteOne("Infra.StatTextEncodeKind");
        this.ExecuteOne("Infra.StatTextWrap");
        this.ExecuteOne("MathGen");
        this.ExecuteOne("PrudateGen");
        this.ExecuteOne("ReferBinaryGen");

        return 0;
    }

    protected virtual bool ExecuteOne(string toolName)
    {
        String ka;
        ka = this.S(toolName);

        Text k;
        k = this.TextCreate(this.SourceTemplate);
        k = this.Replace(k, "#Name#", ka);

        String a;
        a = this.StringCreate(k);

        String path;
        path = this.AddClear().AddS("../../Tool/Z.Tool.").Add(ka).AddS("/Entry.cs").AddResult();

        this.ToolInfra.StorageTextWrite(path, a);
        return true;
    }

    protected virtual Text Replace(Text text, string delimit, String join)
    {
        return this.TextReplace(text, this.TextCreate(this.S(delimit)), this.TextCreate(join));
    }

    protected virtual Text TextCreate(String o)
    {
        return this.TextInfra.TextCreateStringData(o, null);
    }

    protected virtual String StringCreate(Text text)
    {
        return this.TextInfra.StringCreate(text);
    }

    protected virtual Text TextReplace(Text text, Text delimit, Text join)
    {
        return this.ToolInfra.TextReplace(text, delimit, join);
    }

    public virtual Gen Add(String a)
    {
        this.ToolInfra.Add(a);
        return this;
    }

    public virtual Gen AddS(string o)
    {
        this.ToolInfra.AddS(o);
        return this;
    }

    public virtual Gen AddClear()
    {
        this.ToolInfra.AddClear();
        return this;
    }

    public virtual String AddResult()
    {
        return this.ToolInfra.AddResult();
    }

    public virtual Gen AddIndent(long indent)
    {
        this.ToolInfra.AddIndent(indent);
        return this;
    }

    protected virtual String S(string o)
    {
        return this.ToolInfra.S(o);
    }
}