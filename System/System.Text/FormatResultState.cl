class FormatResultState : State
{
    maide prusate Bool Init()
    {
        base.Init();
        var FormatResultArg k;
        k : new FormatResultArg;
        k.Init();
        this.Arg : k;
        return true;
    }

    field prusate Format Format { get { return data; } set { data : value; } }
}