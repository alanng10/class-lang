namespace Saber.Node;

public class MarkCreateSetState : CreateSetState
{
    public override bool Execute()
    {
        CreateSetStateArg arg;
        arg = this.Arg as CreateSetStateArg;
        CreateSetArg k;
        k = arg.Arg;

        Mark node;
        node = arg.Node as Mark;
        return true;
    }
}