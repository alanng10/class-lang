namespace Saber.Node;

public class ReferExecuteCreateSetState : CreateSetState
{
    public override bool Execute()
    {
        CreateSetStateArg arg;
        arg = (CreateSetStateArg)this.Arg;
        CreateSetArg k;
        k = arg.SetArg;

        ReferExecute node;
        node = (ReferExecute)arg.Node;
        node.Var = (Var)k.Field00;
        return true;
    }
}