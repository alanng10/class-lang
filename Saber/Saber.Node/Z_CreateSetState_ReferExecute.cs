namespace Saber.Node;

public class ReferExecuteCreateSetState : CreateSetState
{
    public override bool Execute()
    {
        CreateSetStateArg arg;
        arg = this.Arg as CreateSetStateArg;
        CreateSetArg k;
        k = arg.SetArg;

        ReferExecute node;
        node = arg.Node as ReferExecute;
        node.Var = k.Field00 as Var;
        return true;
    }
}