class StringOut : Out
{
    maide prusate Bool Init()
    {
        base.Init();
        this.InfraInfra : share InfraInfra;
        this.Join : new StringJoin;
        this.Join.Init();
        return true;
    }

    field precate InfraInfra InfraInfra { get { return data; } set { data : value; } }
    field precate StringJoin Join { get { return data; } set { data : value; } }

    maide prusate Bool Write(var String o)
    {
        this.InfraInfra.StringJoinString(this.Join, o);
        return true;
    }

    maide prusate Bool Clear()
    {
        this.Join.Clear();
        return true;
    }

    maide prusate String Result()
    {
        return this.Join.Result();
    }
}