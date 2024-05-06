namespace Class.Console;

public class ModuleInfoGen : Any
{
    public override bool Init()
    {
        base.Init();
        this.InfraInfra = InfraInfra.This;
        this.TextInfra = TextInfra.This;
        this.StorageInfra = StorageInfra.This;

        this.InitSourceTemplate();

        this.Format = new Format();
        this.Format.Init();
        this.FormatArg = new FormatArg();
        this.FormatArg.Init();
        return true;
    }

    public virtual ModuleRef ModuleRef { get; set; }
    public virtual string Source { get; set; }
    protected virtual InfraInfra InfraInfra { get; set; }
    protected virtual TextInfra TextInfra { get; set; }
    protected virtual StorageInfra StorageInfra { get; set; }
    protected virtual string SourceTemplate { get; set; }
    protected virtual Format Format { get; set; }
    protected virtual FormatArg FormatArg { get; set; }

    protected virtual bool InitSourceTemplate()
    {
        string k;
        k = this.InfraInfra.PathCombine;

        this.SourceTemplate = this.StorageInfra.TextRead("Class.Console.data" + k + "ModuleInfo.txt");
        return true;
    }

    public virtual bool Execute()
    {

        string o;
        o = this.SourceTemplate;
        
        o = o.Replace("#Name#", this.ModuleRef.Name);
        

        this.Source = o;
        return true;
    }

    protected virtual string Version()
    {
        FormatArg e;
        e = this.FormatArg;

        e.Kind = 1;
        e.Base = 16;
        e.Case = 0;
        e.AlignLeft = false;
        e.FieldWidth = 15;
        e.MaxWidth = 15;
        e.ValueInt = this.ModuleRef.Version;
        e.FillChar = '0';
        
        this.Format.ExecuteArgCount(e);

        Text text;
        text = this.TextInfra.TextCreate(e.Count);

        this.Format.ExecuteArgResult(e, text);

        string a;
        a = this.TextInfra.StringCreate(text);
        return a;
    }
}