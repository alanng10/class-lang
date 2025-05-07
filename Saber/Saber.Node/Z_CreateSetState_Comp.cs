namespace Saber.Node;

public class CompCreateSetState : CreateSetState
{
    public override bool Execute()
    {
        CreateSetStateArg arg;
        arg = this.Arg as CreateSetStateArg;
        CreateSetArg k;
        k = arg.Arg;

        Comp node;
        node = arg.Node as Comp;
        return true;
    }
}