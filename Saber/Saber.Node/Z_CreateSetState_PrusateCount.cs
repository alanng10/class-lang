namespace Saber.Node;

public class PrusateCountCreateSetState : CreateSetState
{
    public override bool Execute()
    {
        CreateSetStateArg arg;
        arg = (CreateSetStateArg)this.Arg;
        CreateSetArg k;
        k = arg.SetArg;

        PrusateCount node;
        node = (PrusateCount)arg.Node;
        return true;
    }
}