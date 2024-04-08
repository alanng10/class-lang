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
        return true;
    }

    public virtual Data Data { get; set; }
    public virtual int Index { get; set; }
    public virtual Refer Refer { get; set; }
    public virtual bool SystemClass { get; set; }
    protected virtual InfraInfra InfraInfra { get; set; }
    protected virtual ListInfra ListInfra { get; set; }
    protected virtual TextInfra TextInfra { get; set; }
    protected virtual ReadOperate Operate { get; set; }
    protected virtual CountReadOperate CountOperate { get; set; }
    protected virtual StringReadOperate StringOperate { get; set; }
    protected virtual SetReadOperate SetOperate { get; set; }
    protected virtual Range Range { get; set; }
    public virtual int StringIndex { get; set; }
    public virtual Data StringCountData { get; set; }
    public virtual int StringTextIndex { get; set; }
    public virtual Data StringTextData { get; set; }
    public virtual Array StringArray { get; set; }
    public virtual int ArrayIndex { get; set; }
    public virtual Array ArrayArray { get; set; }
    public virtual int FieldIndex { get; set; }
    public virtual Array FieldArray { get; set; }

    public virtual bool Execute()
    {
        this.Operate = this.CountOperate;

        this.Index = 0;
        this.StringIndex = 0;
        this.StringTextIndex = 0;
        this.ArrayIndex = 0;
        this.FieldIndex = 0;

        this.ExecuteStage();

        int stringCount;
        int stringTextCount;
        int arrayCount;
        int fieldCount;
        stringCount = this.StringIndex;
        stringTextCount = this.StringTextIndex;
        arrayCount = this.ArrayIndex;
        fieldCount = this.FieldIndex;

        this.StringCountData = new Data();
        this.StringCountData.Count = stringCount * sizeof(int);
        this.StringCountData.Init();

        this.StringTextData = new Data();
        this.StringTextData.Count = stringTextCount * sizeof(char);
        this.StringTextData.Init();

        this.Operate = this.StringOperate;

        this.Index = 0;
        this.StringIndex = 0;
        this.StringTextIndex = 0;
        this.ArrayIndex = 0;
        this.FieldIndex = 0;

        this.ExecuteStage();

        this.StringArray = this.ListInfra.ArrayCreate(stringCount);
        this.ArrayArray = this.ListInfra.ArrayCreate(arrayCount);
        this.FieldArray = this.ListInfra.ArrayCreate(fieldCount);

        this.ExecuteStringCreate();

        return true;
    }

    protected virtual bool ExecuteStage()
    {
        return true;
    }

    protected virtual bool ExecuteStringCreate()
    {
        InfraInfra infraInfra;
        infraInfra = this.InfraInfra;
        TextInfra textInfra;
        textInfra = this.TextInfra;

        Array array;
        array = this.StringArray;

        Data countData;
        countData = this.StringCountData;

        TextSpan span;
        span = new TextSpan();
        span.Init();
        span.Range = new Range();
        span.Range.Init();
        span.Data = this.StringTextData;
        int total;
        total = 0;

        int count;
        count = array.Count;
        int i;
        i = 0;
        while (i < count)
        {
            long index;
            index = i * sizeof(int);
            int oa;
            oa = infraInfra.DataMidGet(countData, index);
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

    protected virtual Array ExecuteFieldArray()
    {
        Array array;
        array = this.ExecuteArray();
        int count;
        count = array.Count;
        int i;
        i = 0;
        while (i < count)
        {
            Field field;
            field = this.ExecuteField();
            if (field == null)
            {
                return null;
            }
            this.Operate.ExecuteArrayItemSet(array, i, field);
            i = i + 1;
        }
        return array;
    }

    protected virtual Field ExecuteField()
    {
        int u;
        u = this.ExecuteIndex();
        if (u < 0)
        {
            return null;
        }
        int varClass;
        varClass = u;
        int systemClass;
        systemClass = 0;
        if (this.SystemClass)
        {
            u = this.ExecuteIndex();
            if (u < 0)
            {
                return null;
            }
            systemClass = u;
        }

        u = this.ExecuteByte();
        if (u < 0)
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

    public virtual Array ExecuteArray()
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

    public virtual string ExecuteString()
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
        int index;
        index = this.Index;
        int count;
        count = sizeof(long);
        if (!this.CheckCount(count))
        {
            return -1;
        }

        long a;
        a = this.InfraInfra.DataIntGet(this.Data, index);
        index = index + count;
        this.Index = index;
        return a;
    }

    public virtual int ExecuteByte()
    {
        int index;
        index = this.Index;
        if (!(this.CheckCount(1)))
        {
            return -1;
        }

        int a;
        a = this.Data.Get(index);
        index = index + 1;
        this.Index = index;
        return a;
    }

    public virtual bool CheckCount(int count)
    {
        Range range;
        range = this.Range;
        range.Index = this.Index;
        range.Count = count;
        int dataCount;
        dataCount = (int)this.Data.Count;
        return this.InfraInfra.CheckRange(dataCount, range);
    }
}