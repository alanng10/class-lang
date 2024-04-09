namespace Class.Refer;

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
    public virtual Refer Refer { get; set; }
    public virtual bool SystemClass { get; set; }
    public virtual ReadArg Arg { get; set; }
    protected virtual InfraInfra InfraInfra { get; set; }
    protected virtual ListInfra ListInfra { get; set; }
    protected virtual TextInfra TextInfra { get; set; }
    protected virtual ReadOperate Operate { get; set; }
    protected virtual CountReadOperate CountOperate { get; set; }
    protected virtual StringReadOperate StringOperate { get; set; }
    protected virtual SetReadOperate SetOperate { get; set; }
    protected virtual Range Range { get; set; }

    public virtual bool Execute()
    {
        ReadArg arg;
        arg = new ReadArg();
        this.Arg = arg;

        this.Operate = this.CountOperate;

        this.ResetStageIndex();
        this.ExecuteStage();

        arg.StringCountData = new Data();
        arg.StringCountData.Count = arg.StringIndex * sizeof(int);
        arg.StringCountData.Init();

        arg.StringTextData = new Data();
        arg.StringTextData.Count = arg.StringTextIndex * sizeof(char);
        arg.StringTextData.Init();

        arg.ArrayCountData = new Data();
        arg.ArrayCountData.Count = arg.ArrayIndex * sizeof(int);
        arg.ArrayCountData.Init();

        this.Operate = this.StringOperate;

        this.ResetStageIndex();
        this.ExecuteStage();

        arg.ReferArray = this.ListInfra.ArrayCreate(arg.ReferIndex);
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

        this.ExecuteReferCreate();
        this.ExecuteClassCreate();
        this.ExecuteImportCreate();
        this.ExecutePartCreate();
        this.ExecuteFieldCreate();
        this.ExecuteMaideCreate();
        this.ExecuteVarCreate();
        this.ExecuteClassIndexCreate();
        this.ExecuteModuleRefCreate();
        this.ExecuteStringCreate();
        this.ExecuteArrayCreate();

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
        a.ReferIndex = 0;
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

    protected virtual bool ExecuteStringCreate()
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

        TextSpan span;
        span = new TextSpan();
        span.Init();
        span.Range = new Range();
        span.Range.Init();
        span.Data = arg.StringTextData;
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
            span.Range.Index = total;
            span.Range.Count = oa;
            string oo;
            oo = textInfra.StringCreate(span);
            array.Set(i, oo);
            total = total + oa;
            i = i + 1;
        }
        return true;
    }

    protected virtual bool ExecuteArrayCreate()
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

    protected virtual bool ExecuteReferCreate()
    {
        Array array;
        array = this.Arg.ReferArray;

        int count;
        count = array.Count;
        int i;
        i = 0;
        while (i < count)
        {
            Refer o;
            o = new Refer();
            o.Init();
            array.Set(i, o);
            i = i + 1;
        }
        return true;
    }

    protected virtual bool ExecuteClassCreate()
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

    protected virtual bool ExecuteImportCreate()
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

    protected virtual bool ExecutePartCreate()
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

    protected virtual bool ExecuteFieldCreate()
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

    protected virtual bool ExecuteMaideCreate()
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

    protected virtual bool ExecuteVarCreate()
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

    protected virtual bool ExecuteClassIndexCreate()
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

    protected virtual bool ExecuteModuleRefCreate()
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
        this.Refer = this.ExecuteRefer();
        return true;
    }

    protected virtual Refer ExecuteRefer()
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

        int u;
        u = this.ExecuteIndex();
        if (u == -1)
        {
            return null;
        }
        int entry;
        entry = u;

        Refer a;
        a = this.Operate.ExecuteRefer();
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
        Array array;
        array = this.ExecuteArray();
        if (array == null)
        {
            return null;
        }

        int count;
        count = array.Count;
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
        Array array;
        array = this.ExecuteArray();
        if (array == null)
        {
            return null;
        }

        int count;
        count = array.Count;
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
        Array array;
        array = this.ExecuteArray();
        if (array == null)
        {
            return null;
        }

        int count;
        count = array.Count;
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
        Array array;
        array = this.ExecuteArray();
        if (array == null)
        {
            return null;
        }

        int count;
        count = array.Count;
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

        string name;
        name = this.ExecuteString();
        if (name == null)
        {
            return null;
        }

        Field a;
        a = this.Operate.ExecuteField();
        a.Class = varClass;
        a.SystemClass = systemClass;
        a.Count = count;
        a.Name = name;
        return a;
    }

    protected virtual Array ExecuteMaideArray()
    {
        Array array;
        array = this.ExecuteArray();
        if (array == null)
        {
            return null;
        }

        int count;
        count = array.Count;
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

        string name;
        name = this.ExecuteString();
        if (name == null)
        {
            return null;
        }

        Maide a;
        a = this.Operate.ExecuteMaide();
        a.Class = varClass;
        a.SystemClass = systemClass;
        a.Count = count;
        a.Name = name;
        return a;
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
        
        int systemClass;
        systemClass = 0;
        if (this.SystemClass)
        {
            u = this.ExecuteByte();
            if (u == -1)
            {
                return null;
            }
            systemClass = u;
        }

        string name;
        name = this.ExecuteString();
        if (name == null)
        {
            return null;
        }

        Var a;
        a = this.Operate.ExecuteVar();
        a.Class = varClass;
        a.SystemClass = systemClass;
        a.Name = name;
        return a;
    }

    protected virtual Array ExecuteClassIndexArray()
    {
        Array array;
        array = this.ExecuteArray();
        if (array == null)
        {
            return null;
        }

        int count;
        count = array.Count;
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
        long ver;
        ver = u;

        ModuleRef a;
        a = this.Operate.ExecuteModuleRef();
        a.Name = name;
        a.Ver = ver;
        return a;
    }

    protected virtual Array ExecuteArray()
    {
        int o;
        o = this.ExecuteCount();
        if (o == -1)
        {
            return null;
        }
        int count;
        count = o;
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
        return this.Operate.ExecuteString(count);
    }

    protected virtual int ExecuteSystemClass()
    {
        int a;
        a = 0;
        if (this.SystemClass)
        {
            int u;
            u = this.ExecuteByte();
            if (u == -1)
            {
                return -1;
            }
            a = u;
        }
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
        Range range;
        range = this.Range;
        range.Index = this.Arg.Index;
        range.Count = count;
        int dataCount;
        dataCount = (int)this.Data.Count;
        return this.InfraInfra.CheckRange(dataCount, range);
    }
}