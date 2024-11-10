class Host : Any
{
    maide private Bool PrivateNewPeer()
    {
        this.NewPeer();
        return true;
    }

    maide prusate Bool Init()
    {
        base.Init();
        this.InternIntern : share Intern;
        this.Extern : share Extern;
        this.InternInfra : share InternInfra;

        var Int ka;
        ka : this.InternIntern.StateNetworkHostNewPeer();
        var Int arg;
        arg : this.InternIntern.Memory(this);
        this.InternNewPeerState : this.InternInfra.StateCreate(ka, arg);

        var Extern extern;
        extern : this.Extern;

        this.InternPort : extern.NetworkPort_New();
        extern.NetworkPort_Init(this.InternPort);

        this.Intern : extern.NetworkHost_New();
        extern.NetworkHost_Init(this.Intern);
        extern.NetworkHost_NewPeerStateSet(this.Intern, this.InternNewPeerState);
        extern.NetworkHost_PortSet(this.Intern, this.InternPort);
        return true;
    }
}