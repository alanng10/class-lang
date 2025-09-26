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

    protected virtual long ExecuteCount()
    {
        return this.ExecuteInt();
    }

    protected virtual long ExecuteMid()
    {
        return this.ExecuteIntCount(sizeof(int));
    }

    protected virtual long ExecuteInt()
    {
        return this.ExecuteIntCount(sizeof(long));
    }

    protected virtual long ExecuteIntCount(long count)
    {
        if (!this.ValidCount(count))
        {
            return -1;
        }

        long k;
        k = 0;

        long i;
        i = 0;
        while (i < count)
        {
            long ka;
            ka = this.ExecuteByte();

            int shift;
            shift = (int)(i * 8);

            ka = ka << shift;

            k = k | ka;

            i = i + 1;
        }

        k = k & (this.InfraInfra.IntCapValue - 1);

        long a;
        a = k;
        return a;
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