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

    maide prusate String StatusString(var Bool k)
    {
        return this.DeA.StatusString(k);
    }

    maide prusate String StringInt(var Int int)
    {
        return this.DeA.StringInt(int);
    }

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