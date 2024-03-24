namespace Class.Refer;

public class Write : Any
{
    public override bool Init()
    {
        base.Init();
        this.CountOperate = new CountWriteOperate();
        this.CountOperate.Write = this;
        this.CountOperate.Init();
        this.SetOperate = new SetWriteOperate();
        this.SetOperate.Write = this;
        this.SetOperate.Init();
        return true;
    }

    public virtual Refer Refer { get; set; }
    public virtual Data Data { get; set; }
    public virtual int Index { get; set; }

    protected virtual CountWriteOperate CountOperate { get; set; }
    protected virtual SetWriteOperate SetOperate { get; set; }
    protected virtual WriteOperate Operate { get; set; }

    public virtual bool Execute()
    {
        this.Operate = this.CountOperate;
        this.Index = 0;

        this.ExecuteStage();

        int count;
        count = this.Index;
        this.Data = new Data();
        this.Data.Count = count;
        this.Data.Init();

        this.Operate = this.SetOperate;
        this.Index = 0;

        this.ExecuteStage();

        this.Operate = null;
        this.Index = 0;

        return true;
    }

    protected virtual bool ExecuteStage()
    {
        this.ExecuteRefer(this.Refer);
        return true;
    }

    protected virtual bool ExecuteRefer(Refer refer)
    {
        this.ExecuteModuleRef(refer.Ref);
        this.ExecuteClassArray(refer.Class);
        this.ExecuteImportArray(refer.Import);
        this.ExecuteExportArray(refer.Export);
        return true;
    }

    protected virtual bool ExecuteClassArray(Array array)
    {
        int count;
        count = array.Count;
        this.ExecuteCount(count);
        int i;
        i = 0;
        while (i < count)
        {
            Class varClass;
            varClass = (Class)array.Get(i);
            this.ExecuteClass(varClass);
            i = i + 1;
        }
        return true;
    }

    protected virtual bool ExecuteClass(Class varClass)
    {
        this.ExecuteName(varClass.Name);
        return true;
    }

    protected virtual bool ExecuteImportArray(Array array)
    {
        int count;
        count = array.Count;
        this.ExecuteCount(count);
        int i;
        i = 0;
        while (i < count)
        {
            Import import;
            import = (Import)array.Get(i);
            this.ExecuteImport(import);
            i = i + 1;
        }
        return true;
    }

    protected virtual bool ExecuteImport(Import import)
    {
        this.ExecuteModuleRef(import.Module);
        this.ExecuteImportClassArray(import.Class);
        return true;
    }

    protected virtual bool ExecuteImportClassArray(Array array)
    {
        int count;
        count = array.Count;
        this.ExecuteCount(count);
        int i;
        i = 0;
        while (i < count)
        {
            ImportClass importClass;
            importClass = (ImportClass)array.Get(i);
            this.ExecuteImportClass(importClass);
            i = i + 1;
        }
        return true;
    }

    protected virtual bool ExecuteImportClass(ImportClass importClass)
    {
        this.ExecuteIndex(importClass.Class);
        return true;
    }

    protected virtual bool ExecuteExportArray(Array array)
    {
        int count;
        count = array.Count;
        this.ExecuteCount(count);
        int i;
        i = 0;
        while (i < count)
        {
            Export export;
            export = (Export)array.Get(i);
            this.ExecuteExport(export);
            i = i + 1;
        }
        return true;
    }

    protected virtual bool ExecuteExport(Export export)
    {
        this.ExecuteIndex(export.Class);
        return true;
    }

    protected virtual bool ExecuteModuleRef(ModuleRef varRef)
    {
        this.ExecuteName(varRef.Name);
        this.ExecuteInt(varRef.Ver);
        return true;
    }

    protected virtual bool ExecuteName(string value)
    {
        int count;
        count = value.Length;
        this.ExecuteCount(count);
        int i;
        i = 0;
        while (i < count)
        {
            char oc;
            oc = value[i];
            byte ob;
            ob = (byte)oc;
            this.ExecuteByte(ob);
            i = i + 1;
        }
        return true;
    }

    protected virtual bool ExecuteCount(int value)
    {
        return this.ExecuteInt(value);
    }

    protected virtual bool ExecuteIndex(int value)
    {
        return this.ExecuteInt(value);
    }

    protected virtual bool ExecuteInt(long value)
    {
        this.Operate.ExecuteInt(value);
        return true;
    }

    protected virtual bool ExecuteByte(int value)
    {
        this.Operate.ExecuteByte(value);
        return true;
    }
}