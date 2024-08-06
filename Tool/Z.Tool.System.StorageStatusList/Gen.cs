namespace Z.Tool.System.StorageStatusList;

class Gen : Any
{
    public virtual int Execute()
    {
        this.ExecuteGen(new AvalonGen());
        this.ExecuteGen(new SystemGen());   
        return 0;
    }

    protected virtual bool ExecuteGen(ListGen gen)
    {
        gen.Init();
        gen.Execute();
        return true;
    }
}