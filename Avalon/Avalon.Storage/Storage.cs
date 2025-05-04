namespace Avalon.Storage;

public class Storage : Any
{
    public override bool Init()
    {
        base.Init();
        this.InternIntern = global::Avalon.Infra.Intern.This;
        this.InternInfra = InternInfra.This;
        this.StorageInfra = Infra.This;
        this.StorageStatusList = StatusList.This;
        this.Intern = Extern.Storage_New();
        Extern.Storage_Init(this.Intern);
        return true;
    }

    public virtual bool Final()
    {
        Extern.Storage_Final(this.Intern);
        Extern.Storage_Delete(this.Intern);
        return true;
    }

    public virtual String Path { get; set; }
    public virtual Mode Mode { get; set; }
    public virtual StreamStream Stream { get; set; }
    public virtual Status Status
    {
        get
        {
            ulong u;
            u = Extern.Storage_StatusGet(this.Intern);
            long k;
            k = (long)u;
            Status a;
            a = this.StorageStatusList.Get(k);
            return a;
        }
        set
        {
        }
    }
    protected virtual StreamStream DataStream { get; set; }
    private Intern InternIntern { get; set; }
    private InternInfra InternInfra { get; set; }
    protected virtual Infra StorageInfra { get; set; }
    protected virtual StatusList StorageStatusList { get; set; }
    private ulong Intern { get; set; }
    private ulong InternPath { get; set; }

    public virtual bool Open()
    {
        if (!(this.Stream == null))
        {
            return false;
        }
        if (!this.StorageInfra.ValidMode(this.Mode))
        {
            return false;
        }

        this.InternPath = this.InternInfra.StringCreate(this.Path);
        ulong modeU;
        modeU = this.InternMode(this.Mode);
        this.DataStream = this.CreateStream();

        ulong k;
        k = (ulong)this.DataStream.Ident;

        Extern.Storage_PathSet(this.Intern, this.InternPath);
        Extern.Storage_ModeSet(this.Intern, modeU);
        Extern.Storage_StreamSet(this.Intern, k);
        Extern.Storage_Open(this.Intern);
        if (!(this.Status == this.StorageStatusList.NoError))
        {
            return false;
        }

        this.Stream = this.DataStream;

        return true;
    }

    public virtual bool Close()
    {
        Extern.Storage_Close(this.Intern);
        Extern.Storage_StreamSet(this.Intern, 0);
        Extern.Storage_ModeSet(this.Intern, 0);
        Extern.Storage_PathSet(this.Intern, 0);

        this.DataStream.Final();
        this.DataStream = null;
        this.Stream = null;

        this.InternInfra.StringDelete(this.InternPath);
        return true;
    }

    public virtual bool CountSet(long value)
    {
        if (this.Stream == null)
        {
            return false;
        }

        ulong u;
        u = (ulong)value;
        Extern.Storage_CountSet(this.Intern, u);
        return true;
    }

    protected virtual StreamStream CreateStream()
    {
        Stream k;
        k = new Stream();
        k.Init();
        StreamStream a;
        a = k;
        return a;
    }

    private ulong InternMode(Mode mode)
    {
        ulong share;
        share = Extern.Infra_Share();
        ulong stat;
        stat = Extern.Share_Stat(share);

        ulong k;
        k = 0;
        if (mode.Read)
        {
            k = k | Extern.Stat_StorageModeRead(stat);
        }
        if (mode.Write)
        {
            k = k | Extern.Stat_StorageModeWrite(stat);
        }
        if (mode.New)
        {
            k = k | Extern.Stat_StorageModeNew(stat);
        }
        if (mode.Exist)
        {
            k = k | Extern.Stat_StorageModeExist(stat);
        }
        return k;
    }
}