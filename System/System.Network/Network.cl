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
        arg : this.InternIntern.Memory(this);
        this.InternStatusEventState : this.InternInfra.StateCreate(ka, arg);
        this.InternCaseEventState : this.InternInfra.StateCreate(kb, arg);
        this.InternDataEventState : this.InternInfra.StateCreate(kc, arg);

        var Extern extern;
        extern : this.Extern;

        var Bool b;
        b : (this.HostPeer = 0);
        inf (b)
        {
            this.Intern : extern.Network_New();
            extern.Network_Init(this.Intern);
        }
        inf (~b)
        {
            this.Intern : this.HostPeer;

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
}