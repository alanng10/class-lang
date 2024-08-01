namespace Avalon.Infra;

public class StringJoin : Any
{
    public override bool Init()
    {
        base.Init();
        this.InfraInfra = Infra.This;
        this.Builder = new StringBuilder();
        return true;
    }

    protected virtual Infra InfraInfra { get; set; }
    private StringBuilder Builder { get; set; }

    public virtual string Result()
    {
        return this.Builder.ToString();
    }

    public virtual bool Clear()
    {
        this.Builder.Clear();
        return true;
    }

    public virtual bool Append(Data a)
    {
        Infra infraInfra;
        infraInfra = this.InfraInfra;

        int ka;
        ka = sizeof(char);

        long k;
        k = a.Count;
        k = k / ka;

        int count;
        count = (int)k;
        int i;
        i = 0;
        while (i < count)
        {
            long index;
            index = i;
            index = index * ka;

            char oc;
            oc = infraInfra.DataCharGet(a, index);

            this.Builder.Append(oc);

            i = i + 1;
        }
        return true;
    }
}