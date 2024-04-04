namespace Class.Refer;

public class CountReadOperate : Any
{
    public override bool Init()
    {
        base.Init();

        this.Array = this.ListInfra.ArrayCreate(0);
        return true;
    }

    public virtual Read Read { get; set; }
    protected virtual ListInfra ListInfra { get; set; }
    protected virtual Array Array { get; set; }

    public virtual string ExecuteString()
    {
        return null;
    }

    public virtual Array ExecuteArray()
    {
        int o;
        o = this.Read.ExecuteCount();
        if (o == -1)
        {
            return null;
        }
        this.Read.ArrayIndex = this.Read.ArrayIndex + 1;
        return this.Array;
    }

    public virtual bool ExecuteArrayItemSet(Array array, int index, object value)
    {
        return true;
    }

    public virtual Field ExecuteField()
    {
        return null;
    }
}