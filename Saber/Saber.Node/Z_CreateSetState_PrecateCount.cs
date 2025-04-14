namespace Saber.Node;

public class PrecateCountCreateSetState : CreateSetState
{
    public override bool Execute()
    {
        CreateSetStateArg arg;
        arg = this.Arg as CreateSetStateArg;
        CreateSetArg k;
        k = arg.SetArg;

        PrecateCount node;
        node = arg.Node as PrecateCount;
        return true;
    }
}