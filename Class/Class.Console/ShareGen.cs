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
    public virtual bool Export { get; set; }
    public virtual string Source { get; set; }
    protected virtual InfraInfra InfraInfra { get; set; }
    protected virtual StorageInfra StorageInfra { get; set; }
    protected virtual string SourceTemplate { get; set; }

    protected virtual bool InitSourceTemplate()
    {
        string k;
        k = this.InfraInfra.PathCombine;

        this.SourceTemplate = this.StorageInfra.TextReadAny("Class.Console.data" + k + "ClassShare.txt", true);
        return true;
    }

    public virtual bool Execute()
    {
        string ka;
        ka = "";
        if (this.Export)
        {
            ka = "public ";
        }

        string o;
        o = this.SourceTemplate;
        
        o = o.Replace("#ModuleName#", this.Class.Module.Ref.Name);
        o = o.Replace("#ClassName#", this.Class.Name);
        o = o.Replace("#Export#", ka);

        this.Source = o;
        return true;
    }
}