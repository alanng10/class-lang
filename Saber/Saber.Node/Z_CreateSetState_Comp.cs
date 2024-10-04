namespace Saber.Node;

public class CompCreateSetState : CreateSetState
{
    public override bool Execute()
    {
        CreateSetStateArg arg;
        arg = (CreateSetStateArg)this.Arg;
        CreateSetArg k;
        k = arg.SetArg;

        Comp node;
        node = (Comp)arg.Node;
        return true;
    }
}