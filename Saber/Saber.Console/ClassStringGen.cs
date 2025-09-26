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
        this.Index = 0;

        long count;
        count = this.ExecuteCount();

        this.Index = sizeof(long);

        long totalTextCount;
        totalTextCount = 0;

        long i;
        i = 0;

        while (i < count)
        {
            long ka;
            ka = this.ExecuteCount();

            this.Index = this.Index + sizeof(long);

            this.Index = this.Index + ka * sizeof(int);

            totalTextCount = totalTextCount + ka;

            i = i + 1;
        }

        Data textData;
        textData = new Data();
        textData.Count = totalTextCount * sizeof(int);
        textData.Init();

        this.Index = sizeof(long);

        i = 0;

        while (i < count)
        {
            long countK;
            countK = this.ExecuteCount();

            this.Index = this.Index + sizeof(long);

            this.Index = this.Index + countK * sizeof(int);

            i = i + 1;
        }

        return true;
    }

    protected virtual long ExecuteCount()
    {
        return this.ExecuteInt();
    }

    protected virtual long ExecuteMid()
    {
        return this.InfraInfra.DataMidGet(this.State, this.Index);
    }

    protected virtual long ExecuteInt()
    {
        return this.InfraInfra.DataIntGet(this.State, this.Index);
    }
}