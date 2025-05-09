class StateA : State
{
    maide prusate Bool Init()
    {
        base.Init();

        this.Demo : new Demo;
        this.Demo.Init();
        return true;
    }

    field precate Demo Demo { get { return data; } set { data : value; } }

    maide prusate String StatusString(var Bool k)
    {
        return this.Demo.StatusString(k);
    }

    maide prusate String StringInt(var Int int)
    {
        return this.Demo.StringInt(int);
    }

    maide prusate StateA AddClear()
    {
        this.Demo.AddClear();
        return this;
    }

    maide prusate String AddResult()
    {
        return this.Demo.AddResult();
    }

    maide prusate StateA Add(var String k)
    {
        this.Demo.Add(k);
        return this;
    }

    maide prusate StateA AddLine()
    {
        this.Demo.AddLine();
        return this;
    }
}