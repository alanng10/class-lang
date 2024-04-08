namespace Class.Refer;

public class Read : Any
{
    public override bool Init()
    {
        base.Init();
        this.InfraInfra = InfraInfra.This;
        this.ListInfra = ListInfra.This;
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
    protected virtual ReadOperate Operate { get; set; }
    protected virtual CountReadOperate CountOperate { get; set; }
    protected virtual StringReadOperate StringOperate { get; set; }
    protected virtual SetReadOperate SetOperate { get; set; }
    protected virtual Range Range { get; set; }
    public virtual int StringIndex { get; set; }
    public virtual int StringDataIndex { get; set; }
    public virtual Data StringData { get; set; }
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
        this.StringDataIndex = 0;
        this.ArrayIndex = 0;
        this.FieldIndex = 0;

        this.ExecuteStage();

        int stringCount;
        int stringDataCount;
        int arrayCount;
        int fieldCount;
        stringCount = this.StringIndex;
        stringDataCount = this.StringDataIndex;
        arrayCount = this.ArrayIndex;
        fieldCount = this.FieldIndex;

        this.StringData = new Data();
        this.StringData.Count = stringDataCount * sizeof(char);
        this.StringData.Init();

        this.Operate = this.StringOperate;

        this.Index = 0;
        this.StringIndex = 0;
        this.StringDataIndex = 0;
        this.ArrayIndex = 0;
        this.FieldIndex = 0;

        this.ExecuteStage();

        this.StringArray = this.ListInfra.ArrayCreate(stringCount);
        this.ArrayArray = this.ListInfra.ArrayCreate(arrayCount);
        this.FieldArray = this.ListInfra.ArrayCreate(fieldCount);


        return true;
    }

    public virtual bool ExecuteStage()
    {
        return true;
    }

    protected virtual Array ExecuteFieldArray()
    {
        Array array;
        array = this.Operate.ExecuteArray();
        int count;
        count = array.Count;
        int i;
        i = 0;
        while (i < count)
        {
            Field field;
            field = this.ExecuteField();
            if (!(field == null))
            {
                this.Operate.ExecuteArrayItemSet(array, i, field);
            }
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

    public virtual string ExecuteString()
    {
        return this.Operate.ExecuteString();
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