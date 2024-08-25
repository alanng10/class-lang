namespace Avalon.Infra;

public class StringAdd : Any
{
    public override bool Init()
    {
        base.Init();
        this.InfraInfra = Infra.This;
        this.StringComp = StringComp.This;

        this.Range = new Range();
        this.Range.Init();

        long capacity;
        capacity = 16;

        Data data;
        data = new Data();
        data.Count = capacity * sizeof(uint);
        data.Init();

        this.Data = data;
        this.Capacity = capacity;
        return true;
    }

    protected virtual Infra InfraInfra { get; set; }
    protected virtual StringComp StringComp { get; set; }
    protected virtual Range Range { get; set; }
    private Data Data { get; set; }
    private long Count { get; set; }
    private long Capacity { get; set; }

    public virtual String Result()
    {
        this.Range.Index = 0;
        this.Range.Count = this.Count;

        String a;
        a = this.StringComp.CreateData(this.Data, this.Range);
        return a;
    }

    public virtual bool Clear()
    {
        this.Count = 0;
        return true;
    }

    public virtual bool Add(uint n)
    {
        Infra infraInfra;
        infraInfra = this.InfraInfra;

        long count;
        long capacity;
        count = this.Count;
        capacity = this.Capacity;

        Data data;
        data = this.Data;

        long kka;
        kka = sizeof(uint);

        if (!(count < capacity))
        {
            long ka;
            ka = capacity * 2;
            
            long kd;
            kd = ka * kka;

            Data k;
            k = new Data();
            k.Count = kd;
            k.Init();

            long i;
            i = 0;
            while (i < count)
            {
                long index;
                index = i * kka;

                uint nn;
                nn = infraInfra.DataCharGet(data, index);

                infraInfra.DataCharSet(k, index, nn);

                i = i + 1;
            }

            data = k;

            capacity = ka;

            this.Data = data;

            this.Capacity = capacity;
        }

        long ke;
        ke = count * kka;

        infraInfra.DataCharSet(data, ke, n);

        count = count + 1;

        this.Count = count;

        return true;
    }
}