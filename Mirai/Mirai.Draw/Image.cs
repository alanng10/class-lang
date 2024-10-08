namespace Mirai.Draw;

public class Image : Any
{
    public override bool Init()
    {
        base.Init();
        this.InternIntern = InternIntern.This;
        this.InfraInfra = InfraInfra.This;
        this.DrawInfra = Infra.This;

        this.Size = new Size();
        this.Size.Init();

        this.InternSize = Extern.Size_New();
        Extern.Size_Init(this.InternSize);
        this.InternData = Extern.Data_New();
        Extern.Data_Init(this.InternData);
        this.Intern = Extern.Image_New();
        Extern.Image_SizeSet(this.Intern, this.InternSize);
        Extern.Image_DataSet(this.Intern, this.InternData);
        Extern.Image_Init(this.Intern);
        this.Ident = this.Intern;
        return true;
    }

    public virtual bool Final()
    {
        Extern.Image_Final(this.Intern);
        Extern.Image_Delete(this.Intern);

        Extern.Data_Final(this.InternData);
        Extern.Data_Delete(this.InternData);

        Extern.Size_Final(this.InternSize);
        Extern.Size_Delete(this.InternSize);
        return true;
    }
    
    public virtual Size Size { get; set; }
    public virtual ulong Out
    {
        get
        {
            return Extern.Image_VideoOut(this.Intern);
        }
        set
        {
        }
    }
    public virtual ulong Ident { get; set; }

    private InternIntern InternIntern { get; set; }
    protected virtual InfraInfra InfraInfra { get; set; }
    protected virtual Infra DrawInfra { get; set; }
    internal virtual ulong Intern { get; set; }
    private ulong InternData { get; set; }
    private ulong InternSize { get; set; }
    
    public virtual bool DataCreate()
    {
        long wed;
        long het;
        wed = this.Size.Wed;
        het = this.Size.Het;
        ulong w;
        ulong h;
        w = (ulong)wed;
        h = (ulong)het;
        Extern.Size_WedSet(this.InternSize, w);
        Extern.Size_HetSet(this.InternSize, h);

        Extern.Image_DataCreate(this.Intern);
        return true;
    }

    public virtual bool DataGet(Data data, long index)
    {
        long w;
        long h;
        w = this.Size.Wed;
        h = this.Size.Het;
        long k;
        k = this.DrawInfra.PixelByteCount;

        long ka;
        ka = w;
        ka = ka * h;
        ka = ka * k;

        long count;
        count = ka;

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
        long w;
        long h;
        w = this.Size.Wed;
        h = this.Size.Het;
        long k;
        k = this.DrawInfra.PixelByteCount;

        long ka;
        ka = w;
        ka = ka * h;
        ka = ka * k;

        long count;
        count = ka;

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