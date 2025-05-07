namespace Saber.Node;

public class CountCreateSetState : CreateSetState
{
    public override bool Execute()
    {
        CreateSetStateArg arg;
        arg = this.Arg as CreateSetStateArg;
        CreateSetArg k;
        k = arg.Arg;

        Count node;
        node = arg.Node as Count;
        return true;
    }
}