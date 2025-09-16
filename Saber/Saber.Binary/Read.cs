namespace Saber.Binary;

public class Read : Any
{
    public override bool Init()
    {
        base.Init();
        this.InfraInfra = InfraInfra.This;
        this.ListInfra = ListInfra.This;
        this.TextInfra = TextInfra.This;
        this.ClassInfra = ClassInfra.This;

        this.CountOperate = this.CreateCountOperate();
        this.StringOperate = this.CreateStringOperate();
        this.SetOperate = this.CreateSetOperate();
        return true;
    }

    protected virtual ReadCountOperate CreateCountOperate()
    {
        ReadCountOperate a;
        a = new ReadCountOperate();
        a.Read = this;
        a.Init();
        return a;
    }

    protected virtual ReadStringOperate CreateStringOperate()
    {
        ReadStringOperate a;
        a = new ReadStringOperate();
        a.Read = this;
        a.Init();
        return a;
    }

    protected virtual ReadSetOperate CreateSetOperate()
    {
        ReadSetOperate a;
        a = new ReadSetOperate();
        a.Read = this;
        a.Init();
        return a;
    }

    public virtual Data Data { get; set; }
    public virtual Binary Result { get; set; }
    public virtual ReadArg Arg { get; set; }
    public virtual ReadOperate Operate { get; set; }
    public virtual ReadCountOperate CountOperate { get; set; }
    public virtual ReadStringOperate StringOperate { get; set; }
    public virtual ReadSetOperate SetOperate { get; set; }
    protected virtual InfraInfra InfraInfra { get; set; }
    protected virtual ListInfra ListInfra { get; set; }
    protected virtual TextInfra TextInfra { get; set; }
    protected virtual ClassInfra ClassInfra { get; set; }

    public virtual bool Execute()
    {
        this.Arg = new ReadArg();
        this.Arg.Init();

        ReadArg arg;
        arg = this.Arg;

        this.Operate = this.CountOperate;

        this.ResetStage();
        this.ExecuteStage();

        arg.StringCountData = new Data();
        arg.StringCountData.Count = arg.StringIndex * sizeof(long);
        arg.StringCountData.Init();

        arg.StringTextData = new Data();
        arg.StringTextData.Count = arg.StringTextIndex * sizeof(int);
        arg.StringTextData.Init();

        arg.ArrayCountData = new Data();
        arg.ArrayCountData.Count = arg.ArrayIndex * sizeof(long);
        arg.ArrayCountData.Init();

        arg.DataCountData = new Data();
        arg.DataCountData.Count = arg.DataIndex * sizeof(long);
        arg.DataCountData.Init();

        this.Operate = this.StringOperate;

        this.ResetStage();
        this.ExecuteStage();

        arg.BinaryArray = this.ListInfra.ArrayCreate(arg.BinaryIndex);
        arg.ClassArray = this.ListInfra.ArrayCreate(arg.ClassIndex);
        arg.ImportArray = this.ListInfra.ArrayCreate(arg.ImportIndex);
        arg.PartArray = this.ListInfra.ArrayCreate(arg.PartIndex);
        arg.FieldArray = this.ListInfra.ArrayCreate(arg.FieldIndex);
        arg.MaideArray = this.ListInfra.ArrayCreate(arg.MaideIndex);
        arg.VarArray = this.ListInfra.ArrayCreate(arg.VarIndex);
        arg.EntryArray = this.ListInfra.ArrayCreate(arg.EntryIndex);
        arg.ClassIndexArray = this.ListInfra.ArrayCreate(arg.ClassIndexIndex);
        arg.ModuleRefArray = this.ListInfra.ArrayCreate(arg.ModuleRefIndex);
        arg.StringArray = this.ListInfra.ArrayCreate(arg.StringIndex);
        arg.ArrayArray = this.ListInfra.ArrayCreate(arg.ArrayIndex);
        arg.DataArray = this.ListInfra.ArrayCreate(arg.DataIndex);

        this.ExecuteCreateBinary();
        this.ExecuteCreateClass();
        this.ExecuteCreateImport();
        this.ExecuteCreatePart();
        this.ExecuteCreateField();
        this.ExecuteCreateMaide();
        this.ExecuteCreateVar();
        this.ExecuteCreateEntry();
        this.ExecuteCreateClassIndex();
        this.ExecuteCreateModuleRef();
        this.ExecuteCreateString();
        this.ExecuteCreateArray();
        this.ExecuteCreateData();

        this.Operate = this.SetOperate;

        this.ResetStage();
        this.ExecuteStage();

        this.Operate = null;
        this.Arg = null;
        return true;
    }

    public virtual bool ResetStage()
    {
        ReadArg a;
        a = this.Arg;
        a.Index = 0;
        a.BinaryIndex = 0;
        a.ClassIndex = 0;
        a.ImportIndex = 0;
        a.PartIndex = 0;
        a.FieldIndex = 0;
        a.MaideIndex = 0;
        a.VarIndex = 0;
        a.EntryIndex = 0;
        a.ClassIndexIndex = 0;
        a.ModuleRefIndex = 0;
        a.StringIndex = 0;
        a.StringTextIndex = 0;
        a.ArrayIndex = 0;
        a.DataIndex = 0;
        return true;
    }

    protected virtual bool ExecuteCreateBinary()
    {
        Array array;
        array = this.Arg.BinaryArray;

        long count;
        count = array.Count;

        long i;
        i = 0;
        while (i < count)
        {
            Binary k;
            k = new Binary();
            k.Init();

            array.SetAt(i, k);

            i = i + 1;
        }
        return true;
    }

    protected virtual bool ExecuteCreateClass()
    {
        Array array;
        array = this.Arg.ClassArray;

        long count;
        count = array.Count;

        long i;
        i = 0;
        while (i < count)
        {
            Class k;
            k = new Class();
            k.Init();

            array.SetAt(i, k);

            i = i + 1;
        }
        return true;
    }

    protected virtual bool ExecuteCreateImport()
    {
        Array array;
        array = this.Arg.ImportArray;

        long count;
        count = array.Count;

        long i;
        i = 0;
        while (i < count)
        {
            Import k;
            k = new Import();
            k.Init();

            array.SetAt(i, k);

            i = i + 1;
        }
        return true;
    }

    protected virtual bool ExecuteCreatePart()
    {
        Array array;
        array = this.Arg.PartArray;

        long count;
        count = array.Count;

        long i;
        i = 0;
        while (i < count)
        {
            Part k;
            k = new Part();
            k.Init();

            array.SetAt(i, k);

            i = i + 1;
        }
        return true;
    }

    protected virtual bool ExecuteCreateField()
    {
        Array array;
        array = this.Arg.FieldArray;

        long count;
        count = array.Count;

        long i;
        i = 0;
        while (i < count)
        {
            Field k;
            k = new Field();
            k.Init();

            array.SetAt(i, k);

            i = i + 1;
        }
        return true;
    }

    protected virtual bool ExecuteCreateMaide()
    {
        Array array;
        array = this.Arg.MaideArray;

        long count;
        count = array.Count;

        long i;
        i = 0;
        while (i < count)
        {
            Maide k;
            k = new Maide();
            k.Init();

            array.SetAt(i, k);

            i = i + 1;
        }
        return true;
    }

    protected virtual bool ExecuteCreateVar()
    {
        Array array;
        array = this.Arg.VarArray;

        long count;
        count = array.Count;

        long i;
        i = 0;
        while (i < count)
        {
            Var k;
            k = new Var();
            k.Init();

            array.SetAt(i, k);

            i = i + 1;
        }
        return true;
    }

    protected virtual bool ExecuteCreateEntry()
    {
        Array array;
        array = this.Arg.EntryArray;

        long count;
        count = array.Count;

        long i;
        i = 0;
        while (i < count)
        {
            Entry k;
            k = new Entry();
            k.Init();

            array.SetAt(i, k);

            i = i + 1;
        }
        return true;
    }

    protected virtual bool ExecuteCreateClassIndex()
    {
        Array array;
        array = this.Arg.ClassIndexArray;

        long count;
        count = array.Count;

        long i;
        i = 0;
        while (i < count)
        {
            Value k;
            k = new Value();
            k.Init();

            array.SetAt(i, k);

            i = i + 1;
        }
        return true;
    }

    protected virtual bool ExecuteCreateModuleRef()
    {
        Array array;
        array = this.Arg.ModuleRefArray;

        long count;
        count = array.Count;

        long i;
        i = 0;
        while (i < count)
        {
            ModuleRef k;
            k = this.ClassInfra.ModuleRefCreate(null, -1);

            array.SetAt(i, k);

            i = i + 1;
        }
        return true;
    }

    protected virtual bool ExecuteCreateString()
    {
        ReadArg arg;
        arg = this.Arg;

        Array array;
        array = arg.StringArray;

        Text text;
        text = new Text();
        text.Init();
        text.Range = new Range();
        text.Range.Init();
        text.Data = arg.StringTextData;

        long total;
        total = 0;

        long count;
        count = array.Count;

        long i;
        i = 0;
        while (i < count)
        {
            long kaa;
            kaa = i * sizeof(long);

            long ka;
            ka = this.InfraInfra.DataIntGet(arg.StringCountData, kaa);

            text.Range.Index = total;
            text.Range.Count = ka;

            String k;
            k = this.TextInfra.StringCreate(text);

            array.SetAt(i, k);

            total = total + ka;

            i = i + 1;
        }
        return true;
    }

    protected virtual bool ExecuteCreateArray()
    {
        ReadArg arg;
        arg = this.Arg;

        Array array;
        array = arg.ArrayArray;

        long count;
        count = array.Count;

        long i;
        i = 0;
        while (i < count)
        {
            long index;
            index = i * sizeof(long);

            long ka;
            ka = this.InfraInfra.DataIntGet(arg.ArrayCountData, index);

            Array k;
            k = this.ListInfra.ArrayCreate(ka);

            array.SetAt(i, k);

            i = i + 1;
        }
        return true;
    }

    protected virtual bool ExecuteCreateData()
    {
        ReadArg arg;
        arg = this.Arg;

        Array array;
        array = arg.DataArray;

        long count;
        count = array.Count;

        long i;
        i = 0;
        while (i < count)
        {
            long index;
            index = i * sizeof(long);

            long ka;
            ka = this.InfraInfra.DataIntGet(arg.DataCountData, index);

            Data k;
            k = new Data();
            k.Count = ka;
            k.Init();

            array.SetAt(i, k);

            i = i + 1;
        }
        return true;
    }

    public virtual bool ExecuteStage()
    {
        this.Result = this.ExecuteBinary();
        return true;
    }

    protected virtual Binary ExecuteBinary()
    {
        ModuleRef varRef;
        varRef = this.ExecuteModuleRef();
        if (varRef == null)
        {
            return null;
        }

        Array varClass;
        varClass = this.ExecuteClassArray();
        if (varClass == null)
        {
            return null;
        }

        Array import;
        import = this.ExecuteImportArray();
        if (import == null)
        {
            return null;
        }

        Array export;
        export = this.ExecuteExportArray();
        if (export == null)
        {
            return null;
        }

        Array varBase;
        varBase = this.ExecuteBaseArray();
        if (varBase == null)
        {
            return null;
        }

        Array part;
        part = this.ExecutePartArray();
        if (part == null)
        {
            return null;
        }

        Entry entry;
        entry = this.ExecuteEntry();
        if (entry == null)
        {
            return null;
        }

        Data state;
        state = this.ExecuteState();
        if (state == null)
        {
            return null;
        }

        Binary a;
        a = this.Operate.ExecuteBinary();
        a.Ref = varRef;
        a.Class = varClass;
        a.Import = import;
        a.Export = export;
        a.Base = varBase;
        a.Part = part;
        a.Entry = entry;
        a.State = state;
        return a;
    }

    protected virtual Array ExecuteClassArray()
    {
        long count;
        count = this.ExecuteCount();
        if (count == -1)
        {
            return null;
        }

        Array array;
        array = this.ExecuteArray(count);
        if (array == null)
        {
            return null;
        }

        long i;
        i = 0;
        while (i < count)
        {
            Class a;
            a = this.ExecuteClass();
            if (a == null)
            {
                return null;
            }

            this.Operate.ExecuteArrayItemSet(array, i, a);

            i = i + 1;
        }
        return array;
    }

    protected virtual Class ExecuteClass()
    {
        String name;
        name = this.ExecuteString();
        if (name == null)
        {
            return null;
        }

        Class a;
        a = this.Operate.ExecuteClass();
        a.Name = name;
        return a;
    }

    protected virtual Array ExecuteImportArray()
    {
        long count;
        count = this.ExecuteCount();
        if (count == -1)
        {
            return null;
        }

        Array array;
        array = this.ExecuteArray(count);
        if (array == null)
        {
            return null;
        }

        long i;
        i = 0;
        while (i < count)
        {
            Import a;
            a = this.ExecuteImport();
            if (a == null)
            {
                return null;
            }

            this.Operate.ExecuteArrayItemSet(array, i, a);

            i = i + 1;
        }
        return array;
    }

    protected virtual Import ExecuteImport()
    {
        ModuleRef module;
        module = this.ExecuteModuleRef();
        if (module == null)
        {
            return null;
        }

        Array varClass;
        varClass = this.ExecuteImportClassArray();
        if (varClass == null)
        {
            return null;
        }

        Import a;
        a = this.Operate.ExecuteImport();
        a.Module = module;
        a.Class = varClass;
        return a;
    }

    protected virtual Array ExecuteImportClassArray()
    {
        return this.ExecuteClassIndexArray();
    }

    protected virtual Array ExecuteExportArray()
    {
        return this.ExecuteClassIndexArray();
    }

    protected virtual Array ExecuteBaseArray()
    {
        return this.ExecuteClassIndexArray();
    }

    protected virtual Array ExecutePartArray()
    {
        long count;
        count = this.ExecuteCount();
        if (count == -1)
        {
            return null;
        }

        Array array;
        array = this.ExecuteArray(count);
        if (array == null)
        {
            return null;
        }

        long i;
        i = 0;
        while (i < count)
        {
            Part a;
            a = this.ExecutePart();
            if (a == null)
            {
                return null;
            }

            this.Operate.ExecuteArrayItemSet(array, i, a);

            i = i + 1;
        }
        return array;
    }

    protected virtual Part ExecutePart()
    {
        long fieldStart;
        fieldStart = this.ExecuteIndex();
        if (fieldStart == -1)
        {
            return null;
        }

        long maideStart;
        maideStart = this.ExecuteIndex();
        if (maideStart == -1)
        {
            return null;
        }

        Array varField;
        varField = this.ExecuteFieldArray();
        if (varField == null)
        {
            return null;
        }

        Array varMaide;
        varMaide = this.ExecuteMaideArray();
        if (varMaide == null)
        {
            return null;
        }

        Part a;
        a = this.Operate.ExecutePart();
        a.FieldStart = fieldStart;
        a.MaideStart = maideStart;
        a.Field = varField;
        a.Maide = varMaide;
        return a;
    }

    protected virtual Array ExecuteFieldArray()
    {
        long count;
        count = this.ExecuteCount();
        if (count == -1)
        {
            return null;
        }

        Array array;
        array = this.ExecuteArray(count);
        if (array == null)
        {
            return null;
        }

        long i;
        i = 0;
        while (i < count)
        {
            Field a;
            a = this.ExecuteField();
            if (a == null)
            {
                return null;
            }

            this.Operate.ExecuteArrayItemSet(array, i, a);

            i = i + 1;
        }
        return array;
    }

    protected virtual Field ExecuteField()
    {
        long varClass;
        varClass = this.ExecuteIndex();
        if (varClass == -1)
        {
            return null;
        }

        long count;
        count = this.ExecuteByte();
        if (count == -1)
        {
            return null;
        }

        String name;
        name = this.ExecuteName();
        if (name == null)
        {
            return null;
        }

        Field a;
        a = this.Operate.ExecuteField();
        a.Class = varClass;
        a.Count = count;
        a.Name = name;
        return a;
    }

    protected virtual Array ExecuteMaideArray()
    {
        long count;
        count = this.ExecuteCount();
        if (count == -1)
        {
            return null;
        }

        Array array;
        array = this.ExecuteArray(count);
        if (array == null)
        {
            return null;
        }

        long i;
        i = 0;
        while (i < count)
        {
            Maide a;
            a = this.ExecuteMaide();
            if (a == null)
            {
                return null;
            }

            this.Operate.ExecuteArrayItemSet(array, i, a);

            i = i + 1;
        }
        return array;
    }

    protected virtual Maide ExecuteMaide()
    {
        long varClass;
        varClass = this.ExecuteIndex();
        if (varClass == -1)
        {
            return null;
        }

        long count;
        count = this.ExecuteByte();
        if (count == -1)
        {
            return null;
        }

        String name;
        name = this.ExecuteName();
        if (name == null)
        {
            return null;
        }

        Array param;
        param = this.ExecuteVarArray();
        if (param == null)
        {
            return null;
        }

        Maide a;
        a = this.Operate.ExecuteMaide();
        a.Class = varClass;
        a.Count = count;
        a.Name = name;
        a.Param = param;
        return a;
    }

    protected virtual Array ExecuteVarArray()
    {
        long count;
        count = this.ExecuteCount();
        if (count == -1)
        {
            return null;
        }

        Array array;
        array = this.ExecuteArray(count);
        if (array == null)
        {
            return null;
        }

        long i;
        i = 0;
        while (i < count)
        {
            Var a;
            a = this.ExecuteVar();
            if (a == null)
            {
                return null;
            }

            this.Operate.ExecuteArrayItemSet(array, i, a);

            i = i + 1;
        }
        return array;
    }

    protected virtual Var ExecuteVar()
    {
        long varClass;
        varClass = this.ExecuteIndex();
        if (varClass == -1)
        {
            return null;
        }

        String name;
        name = this.ExecuteString();
        if (name == null)
        {
            return null;
        }

        Var a;
        a = this.Operate.ExecuteVar();
        a.Class = varClass;
        a.Name = name;
        return a;
    }

    protected virtual long ExecuteEntry()
    {
        long k;
        k = this.ExecuteIndex();

        long a;
        a = k;
        return a;
    }

    protected virtual Array ExecuteClassIndexArray()
    {
        long count;
        count = this.ExecuteCount();
        if (count == -1)
        {
            return null;
        }

        Array array;
        array = this.ExecuteArray(count);
        if (array == null)
        {
            return null;
        }

        long i;
        i = 0;
        while (i < count)
        {
            Value a;
            a = this.ExecuteClassIndex();
            if (a == null)
            {
                return null;
            }

            this.Operate.ExecuteArrayItemSet(array, i, a);

            i = i + 1;
        }
        return array;
    }

    protected virtual Value ExecuteClassIndex()
    {
        long value;
        value = this.ExecuteIndex();
        if (value == -1)
        {
            return null;
        }

        Value a;
        a = this.Operate.ExecuteClassIndex();
        a.Int = value;
        return a;
    }

    protected virtual ModuleRef ExecuteModuleRef()
    {
        String name;
        name = this.ExecuteString();
        if (name == null)
        {
            return null;
        }

        long ver;
        ver = this.ExecuteInt();
        if (ver == -1)
        {
            return null;
        }

        ModuleRef a;
        a = this.Operate.ExecuteModuleRef();
        a.Name = name;
        a.Ver = ver;
        return a;
    }

    protected virtual Array ExecuteArray(long count)
    {
        return this.Operate.ExecuteArray(count);
    }

    protected virtual String ExecuteString()
    {
        long count;
        count = this.ExecuteCount();
        if (count == -1)
        {
            return null;
        }

        if (!this.ValidCount(count))
        {
            return null;
        }

        String a;
        a = this.Operate.ExecuteString(count);
        return a;
    }

    protected virtual long ExecuteIndex()
    {
        return this.ExecuteInt();
    }

    protected virtual long ExecuteCount()
    {
        return this.ExecuteInt();
    }

    protected virtual long ExecuteInt()
    {
        long count;
        count = sizeof(long);
        if (!this.ValidCount(count))
        {
            return -1;
        }

        ReadArg arg;
        arg = this.Arg;
        long index;
        index = arg.Index;

        long a;
        a = this.InfraInfra.DataIntGet(this.Data, index);

        index = index + count;
        arg.Index = index;
        return a;
    }

    protected virtual long ExecuteByte()
    {
        if (!this.ValidCount(1))
        {
            return -1;
        }

        ReadArg arg;
        arg = this.Arg;
        long index;
        index = arg.Index;
        long a;
        a = this.Data.Get(index);
        index = index + 1;
        arg.Index = index;
        return a;
    }

    protected virtual bool ValidCount(long count)
    {
        return this.InfraInfra.ValidRange(this.Data.Count, this.Arg.Index, count);
    }
}