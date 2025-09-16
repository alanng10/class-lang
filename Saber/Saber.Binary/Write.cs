namespace Saber.Binary;

public class Write : Any
{
    public override bool Init()
    {
        base.Init();
        this.InfraInfra = InfraInfra.This;
        this.StringComp = StringComp.This;
        this.CountOperate = this.CreateCountOperate();
        this.SetOperate = this.CreateSetOperate();
        return true;
    }

    protected virtual WriteCountOperate CreateCountOperate()
    {
        WriteCountOperate a;
        a = new WriteCountOperate();
        a.Write = this;
        a.Init();
        return a;
    }

    protected virtual WriteSetOperate CreateSetOperate()
    {
        WriteSetOperate a;
        a = new WriteSetOperate();
        a.Write = this;
        a.Init();
        return a;
    }

    public virtual Binary Binary { get; set; }
    public virtual Data Result { get; set; }
    public virtual WriteArg Arg { get; set; }
    public virtual WriteOperate Operate { get; set; }
    public virtual WriteCountOperate CountOperate { get; set; }
    public virtual WriteSetOperate SetOperate { get; set; }
    protected virtual InfraInfra InfraInfra { get; set; }
    protected virtual StringComp StringComp { get; set; }

    public virtual bool Execute()
    {
        this.Arg = new WriteArg();
        this.Arg.Init();

        this.Operate = this.CountOperate;

        this.ResetStage();
        this.ExecuteStage();

        long count;
        count = this.Arg.Index;
        this.Arg.Data = new Data();
        this.Arg.Data.Count = count;
        this.Arg.Data.Init();

        this.Operate = this.SetOperate;

        this.ResetStage();
        this.ExecuteStage();

        this.Result = this.Arg.Data;

        this.Operate = null;
        this.Arg = null;
        return true;
    }

    public virtual bool ResetStage()
    {
        this.Arg.Index = 0;
        return true;
    }

    public virtual bool ExecuteStage()
    {
        this.ExecuteBinary(this.Binary);
        return true;
    }

    protected virtual bool ExecuteBinary(Binary binary)
    {
        this.ExecuteModuleRef(binary.Ref);
        this.ExecuteClassArray(binary.Class);
        this.ExecuteImportArray(binary.Import);
        this.ExecuteExportArray(binary.Export);
        this.ExecuteBaseArray(binary.Base);
        this.ExecutePartArray(binary.Part);
        this.ExecuteEntry(binary.Entry);
        this.ExecuteState(binary.State);
        return true;
    }

    protected virtual bool ExecuteClassArray(Array array)
    {
        long count;
        count = array.Count;

        this.ExecuteCount(count);

        long i;
        i = 0;
        while (i < count)
        {
            Class varClass;
            varClass = array.GetAt(i) as Class;

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
        long count;
        count = array.Count;

        this.ExecuteCount(count);

        long i;
        i = 0;
        while (i < count)
        {
            Import import;
            import = array.GetAt(i) as Import;

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

    protected virtual bool ExecuteExportArray(Array array)
    {
        return this.ExecuteClassIndexArray(array);
    }

    protected virtual bool ExecuteBaseArray(Array array)
    {
        return this.ExecuteClassIndexArray(array);
    }

    protected virtual bool ExecutePartArray(Array array)
    {
        long count;
        count = array.Count;

        this.ExecuteCount(count);

        long i;
        i = 0;
        while (i < count)
        {
            Part part;
            part = array.GetAt(i) as Part;

            this.ExecutePart(part);

            i = i + 1;
        }
        return true;
    }

    protected virtual bool ExecutePart(Part part)
    {
        this.ExecuteIndex(part.FieldStart);
        this.ExecuteIndex(part.MaideStart);

        this.ExecuteFieldArray(part.Field);
        this.ExecuteMaideArray(part.Maide);
        return true;
    }

    protected virtual bool ExecuteFieldArray(Array array)
    {
        long count;
        count = array.Count;

        this.ExecuteCount(count);

        long i;
        i = 0;
        while (i < count)
        {
            Field varField;
            varField = array.GetAt(i) as Field;

            this.ExecuteField(varField);

            i = i + 1;
        }
        return true;
    }

    protected virtual bool ExecuteField(Field varField)
    {
        this.ExecuteIndex(varField.Class);
        this.ExecuteByte(varField.Count);
        this.ExecuteName(varField.Name);
        return true;
    }

    protected virtual bool ExecuteMaideArray(Array array)
    {
        long count;
        count = array.Count;

        this.ExecuteCount(count);

        long i;
        i = 0;
        while (i < count)
        {
            Maide varMaide;
            varMaide = array.GetAt(i) as Maide;

            this.ExecuteMaide(varMaide);

            i = i + 1;
        }
        return true;
    }

    protected virtual bool ExecuteMaide(Maide varMaide)
    {
        this.ExecuteIndex(varMaide.Class);
        this.ExecuteByte(varMaide.Count);
        this.ExecuteName(varMaide.Name);
        this.ExecuteVarArray(varMaide.Param);
        return true;
    }

    protected virtual bool ExecuteVarArray(Array array)
    {
        long count;
        count = array.Count;

        this.ExecuteCount(count);

        long i;
        i = 0;
        while (i < count)
        {
            Var varVar;
            varVar = array.GetAt(i) as Var;

            this.ExecuteVar(varVar);

            i = i + 1;
        }
        return true;
    }

    protected virtual bool ExecuteVar(Var varVar)
    {
        this.ExecuteIndex(varVar.Class);
        this.ExecuteName(varVar.Name);
        return true;
    }

    protected virtual bool ExecuteEntry(Entry entry)
    {
        if (entry.Class == -1)
        {
            this.ExecuteByte(0);
            return true;
        }

        this.ExecuteByte(1);

        this.ExecuteIndex(entry.Class);
        return true;
    }

    protected virtual bool ExecuteModuleRef(ModuleRef varRef)
    {
        this.ExecuteName(varRef.Name);
        this.ExecuteInt(varRef.Ver);
        return true;
    }

    protected virtual bool ExecuteClassIndexArray(Array array)
    {
        long count;
        count = array.Count;

        this.ExecuteCount(count);

        long i;
        i = 0;
        while (i < count)
        {
            Value classIndex;
            classIndex = array.GetAt(i) as Value;

            this.ExecuteClassIndex(classIndex);

            i = i + 1;
        }
        return true;
    }

    protected virtual bool ExecuteClassIndex(Value classIndex)
    {
        this.ExecuteIndex(classIndex.Int);
        return true;
    }

    protected virtual bool ExecuteName(String value)
    {
        long count;
        count = this.StringComp.Count(value);

        this.ExecuteCount(count);

        long i;
        i = 0;
        while (i < count)
        {
            long ka;
            ka = this.StringComp.Char(value, i);

            this.ExecuteByte(ka);

            i = i + 1;
        }
        return true;
    }

    protected virtual bool ExecuteIndex(long value)
    {
        return this.ExecuteInt(value);
    }

    protected virtual bool ExecuteCount(long value)
    {
        return this.ExecuteInt(value);
    }

    protected virtual bool ExecuteInt(long value)
    {
        return this.ExecuteIntCount(value, sizeof(long));
    }

    protected virtual bool ExecuteIntCount(long value, long count)
    {
        long k;
        k = value;
        k = k & (this.InfraInfra.IntCapValue - 1);

        long i;
        i = 0;
        while (i < count)
        {
            int shift;
            shift = (int)(i * 8);

            long ka;
            ka = (k >> shift) & 0xff;

            this.ExecuteByte(ka);

            i = i + 1;
        }
        return true;
    }

    protected virtual bool ExecuteByte(long value)
    {
        this.Operate.ExecuteByte(value);
        return true;
    }
}