namespace Class.Binary;

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
    public virtual bool SystemClass { get; set; }
    
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
        this.ExecuteBaseArray(refer.Base);
        this.ExecutePartArray(refer.Part);
        this.ExecuteEntry(refer.Entry);
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
        this.ExecuteClassIndexArray(import.Class);
        return true;
    }

    protected virtual bool ExecuteClassIndexArray(Array array)
    {
        int count;
        count = array.Count;
        this.ExecuteCount(count);
        int i;
        i = 0;
        while (i < count)
        {
            ClassIndex classIndex;
            classIndex = (ClassIndex)array.Get(i);
            this.ExecuteClassIndex(classIndex);
            i = i + 1;
        }
        return true;
    }

    protected virtual bool ExecuteClassIndex(ClassIndex classIndex)
    {
        this.ExecuteIndex(classIndex.Value);
        return true;
    }

    protected virtual bool ExecuteBaseArray(Array array)
    {
        return this.ExecuteClassIndexArray(array);
    }

    protected virtual bool ExecutePartArray(Array array)
    {
        int count;
        count = array.Count;
        this.ExecuteCount(count);
        int i;
        i = 0;
        while (i < count)
        {
            Part part;
            part = (Part)array.Get(i);
            this.ExecutePart(part);
            i = i + 1;
        }
        return true;
    }

    protected virtual bool ExecutePart(Part part)
    {
        this.ExecuteFieldArray(part.Field);
        this.ExecuteMaideArray(part.Maide);
        return true;
    }

    protected virtual bool ExecuteFieldArray(Array array)
    {
        int count;
        count = array.Count;
        this.ExecuteCount(count);
        int i;
        i = 0;
        while (i < count)
        {
            Field field;
            field = (Field)array.Get(i);
            this.ExecuteField(field);
            i = i + 1;
        }
        return true;
    }

    protected virtual bool ExecuteField(Field field)
    {
        this.ExecuteIndex(field.Class);
        this.ExecuteSystemClass(field.SystemClass);
        this.ExecuteByte(field.Count);
        this.ExecuteName(field.Name);
        return true;
    }

    protected virtual bool ExecuteMaideArray(Array array)
    {
        int count;
        count = array.Count;
        this.ExecuteCount(count);
        int i;
        i = 0;
        while (i < count)
        {
            Maide maide;
            maide = (Maide)array.Get(i);
            this.ExecuteMaide(maide);
            i = i + 1;
        }
        return true;
    }

    protected virtual bool ExecuteMaide(Maide maide)
    {
        this.ExecuteIndex(maide.Class);
        this.ExecuteSystemClass(maide.SystemClass);
        this.ExecuteByte(maide.Count);
        this.ExecuteName(maide.Name);
        this.ExecuteVarArray(maide.Param);
        return true;
    }

    protected virtual bool ExecuteVarArray(Array array)
    {
        int count;
        count = array.Count;
        this.ExecuteCount(count);
        int i;
        i = 0;
        while (i < count)
        {
            Var varVar;
            varVar = (Var)array.Get(i);
            this.ExecuteVar(varVar);
            i = i + 1;
        }
        return true;
    }

    protected virtual bool ExecuteVar(Var varVar)
    {
        this.ExecuteIndex(varVar.Class);
        this.ExecuteSystemClass(varVar.SystemClass);
        this.ExecuteName(varVar.Name);
        return true;
    }

    protected virtual bool ExecuteEntry(int entry)
    {
        this.ExecuteIndex(entry);
        return true;
    }

    protected virtual bool ExecuteModuleRef(ModuleRef varRef)
    {
        this.ExecuteName(varRef.Name);
        this.ExecuteInt(varRef.Ver);
        return true;
    }

    protected virtual bool ExecuteSystemClass(int value)
    {
        if (this.SystemClass)
        {
            this.ExecuteByte(value);
        }
        return true;
    }

    protected virtual bool ExecuteName(string name)
    {
        return this.ExecuteString(name);
    }

    protected virtual bool ExecuteString(string value)
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