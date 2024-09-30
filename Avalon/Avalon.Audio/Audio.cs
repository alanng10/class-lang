namespace Avalon.Audio;

public class Audio : Any
{
    public override bool Init()
    {
        base.Init();
        this.InternIntern = InternIntern.This;
        this.InfraInfra = InfraInfra.This;
        this.AudioInfra = Infra.This;

        this.InternData = Extern.Data_New();
        Extern.Data_Init(this.InternData);

        // this.Intern = Extern.Audio_New();
        // Extern.Audio_DataSet(this.Intern, this.InternData);
        // Extern.Audio_Init(this.Intern);
        this.Ident = this.Intern;
        return true;
    }

    public virtual bool Final()
    {
        Extern.Image_Final(this.Intern);
        Extern.Image_Delete(this.Intern);

        Extern.Data_Final(this.InternData);
        Extern.Data_Delete(this.InternData);
        return true;
    }

    public virtual long Count { get; set; }
    public virtual ulong Out
    {
        get
        {
            // return Extern.Audio_AudioOut(this.Intern);
            return 0;
        }
        set
        {
        }
    }
    public virtual ulong Ident { get; set; }
    private InternIntern InternIntern { get; set; }
    protected virtual InfraInfra InfraInfra { get; set; }
    protected virtual Infra AudioInfra { get; set; }
    private ulong Intern { get; set; }
    private ulong InternData { get; set; }

    public virtual bool DataCreate()
    {
        long count;
        count = this.Count;

        ulong countU;
        countU = (ulong)count;
        // Extern.Audio_CountSet(this.Intern, countU);

        // Extern.Audio_DataCreate(this.Intern);
        return true;
    }

    public virtual bool DataGet(Data data, long index)
    {
        long pointCount;
        pointCount = this.Count;
        long k;
        k = this.AudioInfra.PointByteCount;

        long count;
        count = pointCount;
        count = count * k;

        if (!this.InfraInfra.ValidRange(data.Count, index, count))
        {
            return false;
        }

        ulong a;
        a = Extern.Data_ValueGet(this.InternData);

        ulong indexU;
        ulong countU;
        indexU = (ulong)index;
        countU = (ulong)count;

        this.InternIntern.CopyToByteArray(a, data.Value, indexU, countU);
        return true;
    }

    public virtual bool DataSet(Data data, long index)
    {
        long pointCount;
        pointCount = this.Count;
        long k;
        k = this.AudioInfra.PointByteCount;

        long count;
        count = pointCount;
        count = count * k;

        if (!this.InfraInfra.ValidRange(data.Count, index, count))
        {
            return false;
        }

        ulong a;
        a = Extern.Data_ValueGet(this.InternData);

        ulong indexU;
        ulong countU;
        indexU = (ulong)index;
        countU = (ulong)count;

        this.InternIntern.CopyFromByteArray(a, data.Value, indexU, countU);
        return true;
    }
}