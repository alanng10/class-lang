namespace Class.Console;

public class ShareGen : Any
{
    public override bool Init()
    {
        base.Init();
        this.InfraInfra = InfraInfra.This;
        this.StorageInfra = StorageInfra.This;

        this.InitSourceTemplate();
        return true;
    }

    public virtual ClassClass Class { get; set; }
    public virtual string Source { get; set; }
    protected virtual InfraInfra InfraInfra { get; set; }
    protected virtual StorageInfra StorageInfra { get; set; }
    protected virtual string SourceTemplate { get; set; }

    protected virtual bool InitSourceTemplate()
    {
        string k;
        k = this.InfraInfra.PathCombine;

        this.SourceTemplate = this.StorageInfra.TextRead("Class.Console.data" + k + "ClassShare.txt");
        return true;
    }

    public virtual bool Execute()
    {
        string o;
        o = this.SourceTemplate;
        o = o.Replace("#ClassName#", this.Class.Name);
        
        this.Source = o;
        return true;
    }
}