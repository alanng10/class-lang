namespace Saber.Console;

public class ClassStringGen : Any
{
    public override bool Init()
    {
        base.Init();
        this.InfraInfra = InfraInfra.This;
        return true;
    }

    public virtual Data State { get; set; }
    public virtual Array Result { get; set; }
    protected virtual InfraInfra InfraInfra { get; set; }
    protected virtual long Index { get; set; }

    public virtual bool Execute()
    {
        return true;
    }

    protected virtual long ExecuteByte()
    {
        if (!this.ValidCount(1))
        {
            return -1;
        }

        long index;
        index = this.Index;
        long a;
        a = this.State.Get(index);
        index = index + 1;
        this.Index = index;
        return a;
    }

    protected virtual bool ValidCount(long count)
    {
        return this.InfraInfra.ValidRange(this.State.Count, this.Index, count);
    }
}