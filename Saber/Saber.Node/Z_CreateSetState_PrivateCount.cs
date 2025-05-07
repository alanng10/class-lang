namespace Saber.Node;

public class PrivateCountCreateSetState : CreateSetState
{
    public override bool Execute()
    {
        CreateSetStateArg arg;
        arg = this.Arg as CreateSetStateArg;
        CreateSetArg k;
        k = arg.Arg;

        PrivateCount node;
        node = arg.Node as PrivateCount;
        return true;
    }
}