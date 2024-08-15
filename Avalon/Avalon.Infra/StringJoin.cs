namespace Avalon.Infra;

public class StringJoin : Any
{
    public override bool Init()
    {
        base.Init();
        this.InfraInfra = Infra.This;

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
    private Data Data { get; set; }
    private long Count { get; set; }
    private long Capacity { get; set; }

    public virtual String Result()
    {
        return null;
    }

    public virtual bool Clear()
    {
        this.Count = 0;
        return true;
    }

    public virtual bool Append(uint n)
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

            Data k;
            k = new Data();
            k.Count = ka;
            k.Init();

            long i;
            i = 0;
            while (i < count)
            {
                long index;
                index = i * kka;

                uint oc;
                oc = infraInfra.DataCharGet(data, index);

                infraInfra.DataCharSet(k, index, oc);  

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