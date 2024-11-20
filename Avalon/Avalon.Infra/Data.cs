namespace Avalon.Infra;

public class Data : Any
{
    public override bool Init()
    {
        base.Init();
        this.InternIntern = Intern.This;
        this.InfraInfra = Infra.This;
        this.InitValue();
        return true;
    }

    public virtual object Value { get; set; }
    public virtual long Count { get; set; }
    private Intern InternIntern { get; set; }
    protected virtual Infra InfraInfra { get; set; }
    
    protected virtual bool InitValue()
    {
        this.Value = this.InternIntern.DataNew(this.Count);
        return true;
    }

    public virtual long Get(long index)
    {
        if (!this.Valid(index))
        {
            return -1;
        }

        return this.InternIntern.DataGet(this.Value, index);
    }

    public virtual bool Set(long index, long value)
    {
        if (!this.Valid(index))
        {
            return false;
        }

        this.InternIntern.DataSet(this.Value, index, value);
        return true;
    }

    public virtual bool Valid(long index)
    {
        return this.InfraInfra.ValidIndex(this.Count, index);
    }
}