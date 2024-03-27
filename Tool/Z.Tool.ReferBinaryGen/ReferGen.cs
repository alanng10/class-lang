namespace Z.Tool.ReferBinaryGen;

class ReferGen : Any
{
    public override bool Init()
    {
        base.Init();
        this.ListInfra = ListInfra.This;
        return true;
    }

    public virtual Table ModuleTable { get; set; }
    public virtual Table ReferTable { get; set; }

    protected virtual ListInfra ListInfra { get; set; }
    protected virtual Module Module { get; set; }

    public virtual bool Execute()
    {
        this.ReferTable = new Table();
        this.ReferTable.Compare = new StringCompare();
        this.ReferTable.Compare.Init();
        this.ReferTable.Init();

        Iter iter;
        iter = this.ModuleTable.IterCreate();
        this.ModuleTable.IterSet(iter);
        while (iter.Next())
        {
            Module module;
            module = (Module)iter.Value;
            Refer refer;
            refer = this.ExecuteModule(module);
            this.ListInfra.TableAdd(this.ReferTable, refer.Ref.Name, refer);
        }

        return true;
    }

    protected virtual Refer ExecuteModule(Module module)
    {
        this.Module = module;

        ModuleRef oa;
        oa = new ModuleRef();
        oa.Init();
        oa.Name = module.Ref.Name;

        Refer refer;
        refer = new Refer();
        refer.Init();
        refer.Ref = oa;

        refer.Class = this.ExecuteClassArray();

        return refer;
    }

    protected virtual Array ExecuteClassArray()
    {
        Array array;
        array = this.ListInfra.ArrayCreate(this.Module.Class.Count);

        int count;
        count = array.Count;
        int i;
        i = 0;
        Iter iter;
        iter = this.Module.Class.IterCreate();
        this.Module.Class.IterSet(iter);   

        while (i < count)
        {
            iter.Next();
            string name;
            name = (string)iter.Index;

            ReferClass a;
            a = new ReferClass();
            a.Init();
            a.Name = name;
            
            array.Set(i, a);
        }

        return array;
    }
}