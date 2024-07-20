namespace Avalon.Storage;

public class Storage : Any
{
    public override bool Init()
    {
        base.Init();
        this.InternIntern = InternIntern.This;
        this.InternInfra = InternInfra.This;
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

    public virtual string Path { get; set; }
    public virtual Mode Mode { get; set; }
    public virtual bool AnyNode { get; set; }
    public virtual StreamStream Stream { get; set; }
    protected virtual StreamStream DataStream { get; set; }

    private InternIntern InternIntern { get; set; }
    private InternInfra InternInfra { get; set; }
    protected virtual StatusList StorageStatusList { get; set; }
    
    private ulong Intern { get; set; }
    private ulong InternPath { get; set; }

    public virtual Status Status
    {
        get
        {
            ulong u;
            u = Extern.Storage_StatusGet(this.Intern);
            int o;
            o = (int)u;
            Status a;
            a = this.StorageStatusList.Get(o);
            return a;
        }
        set
        {
        }
    }

    public virtual bool Open()
    {
        if (!(this.Stream == null))
        {
            return true;
        }
        if (!this.CheckMode(this.Mode))
        {
            return true;
        }

        this.InternPath = this.InternInfra.StringCreate(this.Path);
        ulong modeU;
        modeU = this.GetInternMode(this.Mode);
        this.DataStream = this.CreateStream();

        Extern.Storage_PathSet(this.Intern, this.InternPath);
        Extern.Storage_ModeSet(this.Intern, modeU);
        Extern.Storage_StreamSet(this.Intern, this.DataStream.Ident);
        Extern.Storage_Open(this.Intern);
        if (this.Status == this.StorageStatusList.NoError)
        {
            this.Stream = this.DataStream;
        }
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
            return true;
        }

        ulong u;
        u = (ulong)value;
        Extern.Storage_CountSet(this.Intern, u);
        return true;
    }

    protected virtual bool CheckMode(Mode mode)
    {
        if (!(mode.Read | mode.Write))
        {
            return false;
        }
        if (mode.New & mode.Exist)
        {
            return false;
        }
        return true;
    }

    protected virtual StreamStream CreateStream()
    {
        Stream a;
        a = new Stream();
        a.Init();
        StreamStream o;
        o = a;
        return o;
    }

    private ulong GetInternMode(Mode mode)
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
            k = k | Extern.Stat_StorageModeExisting(stat);
        }
        return k;
    }
}