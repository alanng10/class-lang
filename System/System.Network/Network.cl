class Network : Any
{
    maide private Bool PrivateStatusEvent()
    {
        this.StatusEvent();
        return true;
    }

    maide private Bool PrivateCaseEvent()
    {
        inf (this.Case = this.NetworkCaseList.Connected)
        {
            this.Stream : this.DataStream;
            this.LoadOpen : false;
        }

        this.CaseEvent();
        return true;
    }

    maide private Bool PrivateDataEvent()
    {
        this.DataEvent();
        return true;
    }
    
    maide prusate Bool Init()
    {
        base.Init();
        this.InternIntern : share Intern;
        this.Extern : share Extern;
        this.InternInfra : share InternInfra;
        this.NetworkStatusList : share StatusList;
        this.NetworkCaseList : share CaseList;
        
        var Int ka;
        var Int kb;
        var Int kc;
        ka : this.InternIntern.StateNetworkStatusEvent();
        kb : this.InternIntern.StateNetworkCaseEvent();
        kc : this.InternIntern.StateNetworkDataEvent();
        var Int arg;
        arg : this.InternIntern.StateArgMemory(this);
        this.InternStatusEventState : this.InternInfra.StateCreate(ka, arg);
        this.InternCaseEventState : this.InternInfra.StateCreate(kb, arg);
        this.InternDataEventState : this.InternInfra.StateCreate(kc, arg);

        var Extern extern;
        extern : this.Extern;

        var Bool b;
        b : (this.HostPeer = null);
        inf (b)
        {
            this.Intern : extern.Network_New();
            extern.Network_Init(this.Intern);
        }
        inf (~b)
        {
            this.Intern : cast Int(this.HostPeer);

            var Int ident;
            ident : extern.Network_StreamGet(this.Intern);

            this.DataStream : this.StreamCreateSet(ident);
            this.Stream : this.DataStream;
        }

        extern.Network_StatusEventStateSet(this.Intern, this.InternStatusEventState);
        extern.Network_CaseEventStateSet(this.Intern, this.InternCaseEventState);
        extern.Network_DataEventStateSet(this.Intern, this.InternDataEventState);
        return true;        
    }

    maide prusate Bool Final()
    {
        var Extern extern;
        extern : this.Extern;

        var Bool b;
        b : (this.HostPeer = null);
        inf (b)
        {
            extern.Network_Final(this.Intern);
            extern.Network_Delete(this.Intern);
        }
        inf (~b)
        {
            this.DataStream.Final();
            this.Stream : null;
        }

        this.InternInfra.StateDelete(this.InternDataEventState);
        this.InternInfra.StateDelete(this.InternCaseEventState);
        this.InternInfra.StateDelete(this.InternStatusEventState);
        return true;
    }

    field prusate Any HostPeer { get { return data; } set { data : value; } }
    field prusate String HostName { get { return data; } set { data : value; } }
    field prusate Int HostPort { get { return data; } set { data : value; } }
    field prusate StreamStream Stream { get { return data; } set { data : value; } }
    field precate StreamStream DataStream { get { return data; } set { data : value; } }
    field prusate Bool LoadOpen { get { return data; } set { data : value; } }
    
    field prusate Status Status
    {
        get
        {
            var Int k;
            k : this.Extern.Network_StatusGet(this.Intern);
            var Status a;
            a : this.NetworkStatusList.Get(k);
            return a;
        }
        set
        {
        }
    }

    field prusate Case Case
    {
        get
        {
            var Int k;
            k : this.Extern.Network_CaseGet(this.Intern);
            inf (k = 0)
            {
                return null;
            }
            k : k - 1;
            var Case a;
            a : this.NetworkCaseList.Get(k);
            return a;
        }
        set
        {
        }
    }

    field prusate Int ReadyCount
    {
        get
        {
            var Int a;
            a : this.Extern.Network_ReadyCountGet(this.Intern);
            return a;
        }
        set
        {
        }
    }

    field private Intern InternIntern { get { return data; } set { data : value; } }
    field private Extern Extern { get { return data; } set { data : value; } }
    field private InternInfra InternInfra { get { return data; } set { data : value; } }
    field precate StatusList NetworkStatusList { get { return data; } set { data : value; } }
    field precate CaseList NetworkCaseList { get { return data; } set { data : value; } }
    field private Int Intern { get { return data; } set { data : value; } }
    field private Int InternDataEventState { get { return data; } set { data : value; } }
    field private Int InternCaseEventState { get { return data; } set { data : value; } }
    field private Int InternStatusEventState { get { return data; } set { data : value; } }
    field private Int InternHostName { get { return data; } set { data : value; } }

    maide prusate Bool Open()
    {
        inf (~(this.Stream = null))
        {
            return false;
        }
        inf (this.LoadOpen)
        {
            return false;
        }

        this.LoadOpen : true;

        this.InternHostName : this.InternInfra.StringCreate(this.HostName);
        this.DataStream : this.StreamCreate();
        var Int streamK;
        streamK : cast Int(this.DataStream.Ident);

        var Extern extern;
        extern : this.Extern;

        extern.Network_HostNameSet(this.Intern, this.InternHostName);
        extern.Network_HostPortSet(this.Intern, this.HostPort);
        extern.Network_StreamSet(this.Intern, streamK);
        extern.Network_Open(this.Intern);
        return true;
    }

    maide prusate Bool Close()
    {
        this.LoadOpen : false;

        var Extern extern;
        extern : this.Extern;

        extern.Network_Close(this.Intern);
        
        extern.Network_StreamSet(this.Intern, 0);
        extern.Network_HostPortSet(this.Intern, 0);
        extern.Network_HostNameSet(this.Intern, 0);

        this.DataStream.Final();
        this.DataStream : null;
        this.Stream : null;

        this.InternInfra.StringDelete(this.InternHostName);
        return true;
    }

    maide precate StreamStream StreamCreateSet(var Any ident)
    {
        var Stream k;
        k : new Stream;
        k.InitIdent : ident;
        k.Init();
        var StreamStream a;
        a : k;
        return a;
    }

    maide precate StreamStream StreamCreate()
    {
        var Stream k;
        k : new Stream;
        k.Init();
        var StreamStream a;
        a : k;
        return a;
    }

    maide prusate Bool StatusEvent()
    {
    }

    maide prusate Bool CaseEvent()
    {
    }

    maide prusate Bool DataEvent()
    {
    }
}