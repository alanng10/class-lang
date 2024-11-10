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
    }
}