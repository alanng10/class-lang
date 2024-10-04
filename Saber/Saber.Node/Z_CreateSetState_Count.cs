namespace Saber.Node;

public class CountCreateSetState : CreateSetState
{
    public override bool Execute()
    {
        CreateSetStateArg arg;
        arg = (CreateSetStateArg)this.Arg;
        CreateSetArg k;
        k = arg.SetArg;

        Count node;
        node = (Count)arg.Node;
        return true;
    }
}