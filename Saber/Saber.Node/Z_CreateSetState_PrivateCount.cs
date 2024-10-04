namespace Saber.Node;

public class PrivateCountCreateSetState : CreateSetState
{
    public override bool Execute()
    {
        CreateSetStateArg arg;
        arg = (CreateSetStateArg)this.Arg;
        CreateSetArg k;
        k = arg.SetArg;

        PrivateCount node;
        node = (PrivateCount)arg.Node;
        return true;
    }
}