namespace Class.Console;

public class ImportGen : Any
{
    public override bool Init()
    {
        base.Init();
        this.InfraInfra = InfraInfra.This;
        this.TextInfra = TextInfra.This;
        this.StorageInfra = StorageInfra.This;

        this.InitSourceTemplate();
        return true;
    }

    public virtual Table ClassImportName { get; set; }
    public virtual string Source { get; set; }
    protected virtual InfraInfra InfraInfra { get; set; }
    protected virtual TextInfra TextInfra { get; set; }
    protected virtual StorageInfra StorageInfra { get; set; }
    protected virtual string SourceTemplate { get; set; }

    protected virtual bool InitSourceTemplate()
    {
        string k;
        k = this.InfraInfra.PathCombine;

        this.SourceTemplate = this.StorageInfra.TextRead("Class.Console.data" + k + "Import.txt");
        return true;
    }

    public virtual bool Execute()
    {
        StringJoin k;
        k = new StringJoin();
        k.Init();

        Iter iter;
        iter = this.ClassImportName.IterCreate();
        this.ClassImportName.IterSet(iter);
        while (iter.Next())
        {
            ClassClass c;
            c = (ClassClass)iter.Index;

            string name;
            name = (string)iter.Value;

            string moduleName;
            moduleName = c.Module.Ref.Name;

            string ka;
            ka = this.Namespace(moduleName);

            k.Append("global using ");
            k.Append("_");
            k.Append(name);
            k.Append(" = ");
            k.Append(ka);
            k.Append(".");
            k.Append(c.Name);
            k.Append(";");
            k.Append("\n");
        }

        string kk;
        kk = k.Result();

        string o;
        o = this.SourceTemplate;
        
        o = o.Replace("#Import#", kk);

        this.Source = o;
        return true;
    }

    protected virtual string Namespace(string moduleName)
    {
        string ka;
        ka = "System.";
        if (moduleName.StartsWith(ka))
        {
            string kaa;
            kaa = moduleName.Substring(ka.Length);

            string kab;
            kab = "Avalon." + kaa;
            return kab;   
        }

        if (moduleName.StartsWith("Class."))
        {
            return moduleName;
        }

        string kb;
        kb = "C.";

        string a;
        a = kb + moduleName;
        return a;
    }
}