namespace Saber.Node;

public class MarkCreateSetState : CreateSetState
{
    public override bool Execute()
    {
        CreateSetStateArg arg;
        arg = (CreateSetStateArg)this.Arg;
        CreateSetArg k;
        k = arg.SetArg;

        Mark node;
        node = (Mark)arg.Node;
        return true;
    }
}