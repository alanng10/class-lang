namespace Class.Node;

public class PrecateCountCreateSetState : CreateSetState
{
    public override bool Execute()
    {
        CreateSetStateArg arg;
        arg = (CreateSetStateArg)this.Arg;
        CreateSetArg k;
        k = arg.SetArg;

        PrecateCount node;
        node = (PrecateCount)arg.Node;
        return true;
    }
}