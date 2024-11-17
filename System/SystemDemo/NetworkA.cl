class NetworkA : Network
{
    maide prusate Bool Init()
    {
        base.Init();
        this.NetworkStatusList : share NetworkStatusList;
        return true;
    }

    field prusate ThreadNetworkState ThreadNetworkState { get { return data; } set { data : value; } }
    field precate NetworkStatusList NetworkStatusList { get { return data; } set { data : value; } }

    maide prusate Bool CaseEvent()
    {

    }

    maide prusate Bool StatusEvent()
    {
        var Bool b;
        b : this.StatusExecute();
        inf (!b)
        {
            this.ThreadState.ExitNetwork(this.StatusCode);
        }
        return true;
    }

    maide private Bool StatusExecute()
    {
        inf (!(this.Status == this.NetworkStatusList.NoError))
        {
            this.StatusCode : 4000 + this.Status.Index;
            return false;
        }

        return true;
    }
}