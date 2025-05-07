namespace Saber.Node;

public class PrusateCountCreateSetState : CreateSetState
{
    public override bool Execute()
    {
        CreateSetStateArg arg;
        arg = this.Arg as CreateSetStateArg;
        CreateSetArg k;
        k = arg.Arg;

        PrusateCount node;
        node = arg.Node as PrusateCount;
        return true;
    }
}