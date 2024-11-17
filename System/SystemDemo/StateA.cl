class StateA : State
{
    maide prusate Bool Init()
    {
        base.Init();

        this.DeA : new DeA;
        this.DeA.Init();
        return true;
    }

    field precate DeA DeA { get { return data; } set { data : value; } }

    maide prusate StateA AddClear()
    {
        this.DeA.AddClear();
        return this;
    }

    maide prusate String AddResult()
    {
        return this.DeA.AddResult();
    }

    maide prusate StateA Add(var String k)
    {
        this.DeA.Add(k);
        return this;
    }

    maide prusate StateA AddLine()
    {
        this.DeA.AddLine();
        return this;
    }
}