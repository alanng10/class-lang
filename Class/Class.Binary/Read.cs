namespace Class.Binary;

public class Read : Any
{
    public override bool Init()
    {
        base.Init();
        this.InfraInfra = InfraInfra.This;
        this.ListInfra = ListInfra.This;
        this.TextInfra = TextInfra.This;
        this.CountOperate = new CountReadOperate();
        this.CountOperate.Read = this;
        this.CountOperate.Init();
        this.StringOperate = new StringReadOperate();
        this.StringOperate.Read = this;
        this.StringOperate.Init();
        this.SetOperate = new SetReadOperate();
        this.SetOperate.Read = this;
        this.SetOperate.Init();

        this.Arg = new ReadArg();
        this.Arg.Init();
        return true;
    }

    public virtual Data Data { get; set; }
    public virtual Binary Binary { get; set; }
    public virtual bool SystemInfo { get; set; }
    public virtual ReadArg Arg { get; set; }
    protected virtual InfraInfra InfraInfra { get; set; }
    protected virtual ListInfra ListInfra { get; set; }
    protected virtual TextInfra TextInfra { get; set; }
    protected virtual ReadOperate Operate { get; set; }
    protected virtual CountReadOperate CountOperate { get; set; }
    protected virtual StringReadOperate StringOperate { get; set; }
    protected virtual SetReadOperate SetOperate { get; set; }

    public virtual bool Execute()
    {
        ReadArg arg;
        arg = new ReadArg();
        this.Arg = arg;

        this.Operate = this.CountOperate;

        this.ResetStageIndex();
        this.ExecuteStage();

        arg.StringCountData = new Data();
        arg.StringCountData.Count = arg.StringIndex * sizeof(uint);
        arg.StringCountData.Init();

        arg.StringTextData = new Data();
        arg.StringTextData.Count = arg.StringTextIndex * sizeof(char);
        arg.StringTextData.Init();

        arg.ArrayCountData = new Data();
        arg.ArrayCountData.Count = arg.ArrayIndex * sizeof(uint);
        arg.ArrayCountData.Init();

        this.Operate = this.StringOperate;

        this.ResetStageIndex();
        this.ExecuteStage();

        arg.BinaryArray = this.ListInfra.ArrayCreate(arg.BinaryIndex);
        arg.ClassArray = this.ListInfra.ArrayCreate(arg.ClassIndex);
        arg.ImportArray = this.ListInfra.ArrayCreate(arg.ImportIndex);
        arg.PartArray = this.ListInfra.ArrayCreate(arg.PartIndex);
        arg.FieldArray = this.ListInfra.ArrayCreate(arg.FieldIndex);
        arg.MaideArray = this.ListInfra.ArrayCreate(arg.MaideIndex);
        arg.VarArray = this.ListInfra.ArrayCreate(arg.VarIndex);
        arg.ClassIndexArray = this.ListInfra.ArrayCreate(arg.ClassIndexIndex);
        arg.ModuleRefArray = this.ListInfra.ArrayCreate(arg.ModuleRefIndex);
        arg.StringArray = this.ListInfra.ArrayCreate(arg.StringIndex);
        arg.ArrayArray = this.ListInfra.ArrayCreate(arg.ArrayIndex);

        this.ExecuteCreateBinary();
        this.ExecuteCreateClass();
        this.ExecuteCreateImport();
        this.ExecuteCreatePart();
        this.ExecuteCreateField();
        this.ExecuteCreateMaide();
        this.ExecuteCreateVar();
        this.ExecuteCreateClassIndex();
        this.ExecuteCreateModuleRef();
        this.ExecuteCreateString();
        this.ExecuteCreateArray();

        this.Operate = this.SetOperate;

        this.ResetStageIndex();
        this.ExecuteStage();

        this.Arg = null;
        return true;
    }

    protected virtual bool ResetStageIndex()
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
        a.ClassIndexIndex = 0;
        a.ModuleRefIndex = 0;
        a.StringIndex = 0;
        a.StringTextIndex = 0;
        a.ArrayIndex = 0;
        return true;
    }

    protected virtual bool ExecuteCreateString()
    {
        InfraInfra infraInfra;
        infraInfra = this.InfraInfra;
        TextInfra textInfra;
        textInfra = this.TextInfra;

        ReadArg arg;
        arg = this.Arg;
        Array array;
        array = arg.StringArray;
        Data countData;
        countData = arg.StringCountData;

        Text text;
        text = new Text();
        text.Init();
        text.Range = new Range();
        text.Range.Init();
        text.Data = arg.StringTextData;
        int total;
        total = 0;

        int count;
        count = array.Count;
        int i;
        i = 0;
        while (i < count)
        {
            long index;
            index = i * sizeof(uint);
            uint u;
            u = infraInfra.DataMidGet(countData, index);
            int oa;
            oa = (int)u;
            text.Range.Index = total;
            text.Range.Count = oa;
            string oo;
            oo = textInfra.StringCreate(text);
            array.Set(i, oo);
            total = total + oa;
            i = i + 1;
        }
        return true;
    }

    protected virtual bool ExecuteCreateArray()
    {
        InfraInfra infraInfra;
        infraInfra = this.InfraInfra;
        ListInfra listInfra;
        listInfra = this.ListInfra;

        ReadArg arg;
        arg = this.Arg;
        Array array;
        array = arg.ArrayArray;
        Data countData;
        countData = arg.ArrayCountData;

        int count;
        count = array.Count;
        int i;
        i = 0;
        while (i < count)
        {
            long index;
            index = i * sizeof(uint);
            uint u;
            u = infraInfra.DataMidGet(countData, index);
            int oa;
            oa = (int)u;
            Array o;
            o = listInfra.ArrayCreate(oa);
            array.Set(i, o);
            i = i + 1;
        }
        return true;
    }

    protected virtual bool ExecuteCreateBinary()
    {
        Array array;
        array = this.Arg.BinaryArray;

        int count;
        count = array.Count;
        int i;
        i = 0;
        while (i < count)
        {
            Binary o;
            o = new Binary();
            o.Init();
            array.Set(i, o);
            i = i + 1;
        }
        return true;
    }

    protected virtual bool ExecuteCreateClass()
    {
        Array array;
        array = this.Arg.ClassArray;

        int count;
        count = array.Count;
        int i;
        i = 0;
        while (i < count)
        {
            Class o;
            o = new Class();
            o.Init();
            array.Set(i, o);
            i = i + 1;
        }
        return true;
    }

    protected virtual bool ExecuteCreateImport()
    {
        Array array;
        array = this.Arg.ImportArray;

        int count;
        count = array.Count;
        int i;
        i = 0;
        while (i < count)
        {
            Import o;
            o = new Import();
            o.Init();
            array.Set(i, o);
            i = i + 1;
        }
        return true;
    }

    protected virtual bool ExecuteCreatePart()
    {
        Array array;
        array = this.Arg.PartArray;

        int count;
        count = array.Count;
        int i;
        i = 0;
        while (i < count)
        {
            Part o;
            o = new Part();
            o.Init();
            array.Set(i, o);
            i = i + 1;
        }
        return true;
    }

    protected virtual bool ExecuteCreateField()
    {
        Array array;
        array = this.Arg.FieldArray;

        int count;
        count = array.Count;
        int i;
        i = 0;
        while (i < count)
        {
            Field o;
            o = new Field();
            o.Init();
            array.Set(i, o);
            i = i + 1;
        }
        return true;
    }

    protected virtual bool ExecuteCreateMaide()
    {
        Array array;
        array = this.Arg.MaideArray;

        int count;
        count = array.Count;
        int i;
        i = 0;
        while (i < count)
        {
            Maide o;
            o = new Maide();
            o.Init();
            array.Set(i, o);
            i = i + 1;
        }
        return true;
    }

    protected virtual bool ExecuteCreateVar()
    {
        Array array;
        array = this.Arg.VarArray;

        int count;
        count = array.Count;
        int i;
        i = 0;
        while (i < count)
        {
            Var o;
            o = new Var();
            o.Init();
            array.Set(i, o);
            i = i + 1;
        }
        return true;
    }

    protected virtual bool ExecuteCreateClassIndex()
    {
        Array array;
        array = this.Arg.ClassIndexArray;

        int count;
        count = array.Count;
        int i;
        i = 0;
        while (i < count)
        {
            ClassIndex o;
            o = new ClassIndex();
            o.Init();
            array.Set(i, o);
            i = i + 1;
        }
        return true;
    }

    protected virtual bool ExecuteCreateModuleRef()
    {
        Array array;
        array = this.Arg.ModuleRefArray;

        int count;
        count = array.Count;
        int i;
        i = 0;
        while (i < count)
        {
            ModuleRef o;
            o = new ModuleRef();
            o.Init();
            array.Set(i, o);
            i = i + 1;
        }
        return true;
    }

    protected virtual bool ExecuteStage()
    {
        this.Binary = this.ExecuteBinary();
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

        long u;
        u = this.ExecuteInt();
        if (u == -1)
        {
            return null;
        }
        int entry;
        entry = (int)u;

        Binary a;
        a = this.Operate.ExecuteBinary();
        a.Ref = varRef;
        a.Class = varClass;
        a.Import = import;
        a.Base = varBase;
        a.Part = part;
        a.Entry = entry;
        return a;
    }

    protected virtual Array ExecuteClassArray()
    {
        int o;
        o = this.ExecuteCount();
        if (o == -1)
        {
            return null;
        }
        int count;
        count = o;

        Array array;
        array = this.ExecuteArray(count);
        if (array == null)
        {
            return null;
        }

        int i;
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
        string name;
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
        int o;
        o = this.ExecuteCount();
        if (o == -1)
        {
            return null;
        }
        int count;
        count = o;

        Array array;
        array = this.ExecuteArray(count);
        if (array == null)
        {
            return null;
        }

        int i;
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

    protected virtual Array ExecuteBaseArray()
    {
        return this.ExecuteClassIndexArray();
    }

    protected virtual Array ExecutePartArray()
    {
        int o;
        o = this.ExecuteCount();
        if (o == -1)
        {
            return null;
        }
        int count;
        count = o;

        Array array;
        array = this.ExecuteArray(count);
        if (array == null)
        {
            return null;
        }

        int i;
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
        Array field;
        field = this.ExecuteFieldArray();
        if (field == null)
        {
            return null;
        }

        Array maide;
        maide = this.ExecuteMaideArray();
        if (maide == null)
        {
            return null;
        }

        Part a;
        a = this.Operate.ExecutePart();
        a.Field = field;
        a.Maide = maide;
        return a;
    }

    protected virtual Array ExecuteFieldArray()
    {
        int o;
        o = this.ExecuteCount();
        if (o == -1)
        {
            return null;
        }
        int count;
        count = o;

        Array array;
        array = this.ExecuteArray(count);
        if (array == null)
        {
            return null;
        }

        int i;
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
        int u;
        u = this.ExecuteIndex();
        if (u == -1)
        {
            return null;
        }
        int varClass;
        varClass = u;

        u = this.ExecuteSystemClass();
        if (u == -1)
        {
            return null;
        }
        int systemClass;
        systemClass = u;

        u = this.ExecuteByte();
        if (u == -1)
        {
            return null;
        }
        int count;
        count = u;

        long uu;
        uu = this.ExecuteInt();
        if (uu == -1)
        {
            return null;
        }
        int varVirtual;
        varVirtual = (int)uu;

        string name;
        name = this.ExecuteString();
        if (name == null)
        {
            return null;
        }

        Field a;
        a = this.Operate.ExecuteField();
        a.Class = varClass;
        a.SystemInfo = systemClass;
        a.Count = count;
        a.Virtual = varVirtual;
        a.Name = name;
        return a;
    }

    protected virtual Array ExecuteMaideArray()
    {
        int o;
        o = this.ExecuteCount();
        if (o == -1)
        {
            return null;
        }
        int count;
        count = o;

        Array array;
        array = this.ExecuteArray(count);
        if (array == null)
        {
            return null;
        }

        int i;
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
        int u;
        u = this.ExecuteIndex();
        if (u == -1)
        {
            return null;
        }
        int varClass;
        varClass = u;

        u = this.ExecuteSystemClass();
        if (u == -1)
        {
            return null;
        }
        int systemClass;
        systemClass = u;

        u = this.ExecuteByte();
        if (u == -1)
        {
            return null;
        }
        int count;
        count = u;

        long uu;
        uu = this.ExecuteInt();
        if (uu == -1)
        {
            return null;
        }
        int varVirtual;
        varVirtual = (int)uu;

        string name;
        name = this.ExecuteString();
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
        a.SystemInfo = systemClass;
        a.Count = count;
        a.Virtual = varVirtual;
        a.Name = name;
        a.Param = param;
        return a;
    }

    protected virtual Array ExecuteVarArray()
    {
        int o;
        o = this.ExecuteCount();
        if (o == -1)
        {
            return null;
        }
        int count;
        count = o;

        Array array;
        array = this.ExecuteArray(count);
        if (array == null)
        {
            return null;
        }

        int i;
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
        int u;
        u = this.ExecuteIndex();
        if (u == -1)
        {
            return null;
        }
        int varClass;
        varClass = u;

        u = this.ExecuteSystemClass();
        if (u == -1)
        {
            return null;
        }
        int systemClass;
        systemClass = u;

        string name;
        name = this.ExecuteString();
        if (name == null)
        {
            return null;
        }

        Var a;
        a = this.Operate.ExecuteVar();
        a.Class = varClass;
        a.SystemInfo = systemClass;
        a.Name = name;
        return a;
    }

    protected virtual Array ExecuteClassIndexArray()
    {
        int o;
        o = this.ExecuteCount();
        if (o == -1)
        {
            return null;
        }
        int count;
        count = o;

        Array array;
        array = this.ExecuteArray(count);
        if (array == null)
        {
            return null;
        }

        int i;
        i = 0;
        while (i < count)
        {
            ClassIndex a;
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

    protected virtual ClassIndex ExecuteClassIndex()
    {
        int u;
        u = this.ExecuteIndex();
        if (u == -1)
        {
            return null;
        }
        int value;
        value = u;
        ClassIndex a;
        a = this.Operate.ExecuteClassIndex();
        a.Value = value;
        return a;
    }

    protected virtual ModuleRef ExecuteModuleRef()
    {
        string name;
        name = this.ExecuteString();
        if (name == null)
        {
            return null;
        }

        long u;
        u = this.ExecuteInt();
        if (u == -1)
        {
            return null;
        }
        long version;
        version = u;

        ModuleRef a;
        a = this.Operate.ExecuteModuleRef();
        a.Name = name;
        a.Version = version;
        return a;
    }

    protected virtual Array ExecuteArray(int count)
    {
        return this.Operate.ExecuteArray(count);
    }

    protected virtual string ExecuteString()
    {
        int o;
        o = this.ExecuteCount();
        if (o == -1)
        {
            return null;
        }
        int count;
        count = o;
        string a;
        a = this.Operate.ExecuteString(count);
        return a;
    }

    protected virtual int ExecuteSystemClass()
    {
        int u;
        u = this.ExecuteByte();
        if (u == -1)
        {
            return -1;
        }
        int a;
        a = u;
        return a;
    }

    public virtual int ExecuteCount()
    {
        return (int)this.ExecuteInt();
    }

    public virtual int ExecuteIndex()
    {
        return (int)this.ExecuteInt();
    }

    public virtual long ExecuteInt()
    {
        int count;
        count = sizeof(ulong);
        if (!this.CheckCount(count))
        {
            return -1;
        }
        InfraInfra infraInfra;
        infraInfra = this.InfraInfra;
        ReadArg arg;
        arg = this.Arg;
        int index;
        index = arg.Index;
        ulong u;
        u = infraInfra.DataIntGet(this.Data, index);
        long a;
        a = (long)u;
        index = index + count;
        arg.Index = index;
        return a;
    }

    public virtual int ExecuteByte()
    {
        if (!(this.CheckCount(1)))
        {
            return -1;
        }
        ReadArg arg;
        arg = this.Arg;
        int index;
        index = arg.Index;
        int a;
        a = this.Data.Get(index);
        index = index + 1;
        arg.Index = index;
        return a;
    }

    protected virtual bool CheckCount(int count)
    {
        int dataCount;
        dataCount = (int)this.Data.Count;
        return this.InfraInfra.CheckRange(dataCount, this.Arg.Index, count);
    }
}