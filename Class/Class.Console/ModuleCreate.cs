namespace Class.Console;

public class ModuleCreate : Any
{
    public override bool Init()
    {
        base.Init();
        this.ListInfra = ListInfra.This;
        return true;
    }

    public virtual Table ModuleTable { get; set; }
    public virtual ReferRefer Refer { get; set; }
    public virtual ClassModule Module { get; set; }
    protected virtual ListInfra ListInfra { get; set; }

    public virtual bool Execute()
    {
        ModuleRef o;
        o = this.Refer.Ref;
        if (this.ModuleTable.Contain(o))
        {
            return false;
        }

        ClassModule a;
        a = new ClassModule();
        a.Init();
        a.Ref = this.ModuleRefCreate(o.Name, o.Ver);
        this.Module = a;


        return true;
    }

    protected virtual bool AddClassList()
    {
        return true;
    }

    protected virtual ModuleRef ModuleRefCreate(string name, long ver)
    {
        ModuleRef a;
        a = new ModuleRef();
        a.Init();
        a.Name = name;
        a.Ver = ver;
        return a;
    }
}