class Storage : Any
{
    maide prusate Bool Init()
    {
        base.Init();
        this.InternIntern : share Intern;
        this.Extern : share Extern;
        this.InternInfra : share InternInfra;
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
    field precate StatusList StorageStatusList { get { return data; } set { data : value; } }
    field private Int Intern { get { return data; } set { data : value; } }
    field private Int InternPath { get { return data; } set { data : value; } }

    maide prusate Bool Open()
    {
        inf (~(this.Stream = null))
        {
            return true;
        }
        inf (~this.ValidMode(this.Mode))
        {
            return true;
        }

        this.InternPath : this.InternInfra.StringCreate(this.Path);
        var Int modeU;
        modeU : this.InternMode(this.Mode);
        this.DataStream : this.CreateStream();

        this.Extern.Storage_PathSet(this.Intern, this.InternPath);
        this.Extern.Storage_ModeSet(this.Intern, modeU);
        this.Extern.Storage_StreamSet(this.Intern, this.DataStream.Ident);
        this.Extern.Storage_Open(this.Intern);
        inf (this.Status = this.StorageStatusList.NoError)
        {
            this.Stream : this.DataStream;
        }
        return true;
    }

    maide prusate Bool Close()
    {
        this.Extern.Storage_Close(this.Intern);
        this.Extern.Storage_StreamSet(this.Intern, 0);
        this.Extern.Storage_ModeSet(this.Intern, 0);
        this.Extern.Storage_PathSet(this.Intern, 0);

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
            return true;
        }

        this.Extern.Storage_CountSet(this.Intern, value);
        return true;
    }

    maide precate Bool ValidMode(var Mode mode)
    {
        inf (~(mode.Read | mode.Write))
        {
            return false;
        }
        inf (mode.New & mode.Exist)
        {
            return false;
        }
        return true;
    }

    maide precate StreamStream CreateStream()
    {
        var Stream a;
        a : new Stream;
        a.Init();
        var StreamStream o;
        o : a;
        return o;
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
            k : k | extern.Stat_StorageModeRead(stat);
        }
        inf (mode.Write)
        {
            k : k | extern.Stat_StorageModeWrite(stat);
        }
        inf (mode.New)
        {
            k : k | extern.Stat_StorageModeNew(stat);
        }
        inf (mode.Exist)
        {
            k : k | extern.Stat_StorageModeExisting(stat);
        }
        return k;
    }
}