class Storage : Any
{
    maide prusate Bool Init()
    {
        base.Init();
        this.InternIntern : share Intern;
        this.Extern : share Extern;
        this.InternInfra : share InternInfra;
        this.StorageInfra : share Infra;
        this.StorageStatusList : share StatusList;
        
        var Extern extern;
        extern : this.Extern;

        this.Intern : extern.Storage_New();
        extern.Storage_Init(this.Intern);
        return true;
    }

    maide prusate Bool Final()
    {
        var Extern extern;
        extern : this.Extern;

        extern.Storage_Final(this.Intern);
        extern.Storage_Delete(this.Intern);
        return true;
    }

    field prusate String Path { get { return data; } set { data : value; } }
    field prusate Mode Mode { get { return data; } set { data : value; } }
    field prusate StreamStream Stream { get { return data; } set { data : value; } }
    field prusate Status Status
    {
        get
        {
            var Int k;
            k : this.Extern.Storage_StatusGet(this.Intern);
            var Status a;
            a : this.StorageStatusList.Get(k);
            return a;
        }
        set
        {
        }
    }
    field precate StreamStream DataStream { get { return data; } set { data : value; } }
    field private Intern InternIntern { get { return data; } set { data : value; } }
    field private Extern Extern { get { return data; } set { data : value; } }
    field private InternInfra InternInfra { get { return data; } set { data : value; } }
    field precate Infra StorageInfra { get { return data; } set { data : value; } }
    field precate StatusList StorageStatusList { get { return data; } set { data : value; } }
    field private Int Intern { get { return data; } set { data : value; } }
    field private Int InternPath { get { return data; } set { data : value; } }

    maide prusate Bool Open()
    {
        inf (~(this.Stream = null))
        {
            return false;
        }
        inf (~this.StorageInfra.ValidMode(this.Mode))
        {
            return false;
        }

        this.InternPath : this.InternInfra.StringCreate(this.Path);
        var Int modeU;
        modeU : this.InternMode(this.Mode);
        this.DataStream : this.CreateStream();

        var Extern extern;
        extern : this.Extern;

        extern.Storage_PathSet(this.Intern, this.InternPath);
        extern.Storage_ModeSet(this.Intern, modeU);
        extern.Storage_StreamSet(this.Intern, this.DataStream.Ident);
        extern.Storage_Open(this.Intern);
        inf (~(this.Status = this.StorageStatusList.NoError))
        {
            return false;
        }
        
        this.Stream : this.DataStream;
        
        return true;
    }

    maide prusate Bool Close()
    {
        var Extern extern;
        extern : this.Extern;

        extern.Storage_Close(this.Intern);
        extern.Storage_StreamSet(this.Intern, 0);
        extern.Storage_ModeSet(this.Intern, 0);
        extern.Storage_PathSet(this.Intern, 0);

        this.DataStream.Final();
        this.DataStream : null;
        this.Stream : null;

        this.InternInfra.StringDelete(this.InternPath);
        return true;
    }

    maide prusate Bool CountSet(var Int value)
    {
        inf (this.Stream = null)
        {
            return false;
        }

        this.Extern.Storage_CountSet(this.Intern, value);
        return true;
    }

    maide precate StreamStream CreateStream()
    {
        var Stream k;
        k : new Stream;
        k.Init();
        var StreamStream a;
        a : k;
        return a;
    }

    maide private Int InternMode(var Mode mode)
    {
        var Extern extern;
        extern : this.Extern;

        var Int varShare;
        varShare : extern.Infra_Share();
        var Int stat;
        stat : extern.Share_Stat(varShare);

        var Int k;
        k : 0;
        inf (mode.Read)
        {
            k : bit |(k, extern.Stat_StorageModeRead(stat));
        }
        inf (mode.Write)
        {
            k : bit |(k, extern.Stat_StorageModeWrite(stat));
        }
        inf (mode.New)
        {
            k : bit |(k, extern.Stat_StorageModeNew(stat));
        }
        inf (mode.Exist)
        {
            k : bit |(k, extern.Stat_StorageModeExist(stat));
        }
        return k;
    }
}