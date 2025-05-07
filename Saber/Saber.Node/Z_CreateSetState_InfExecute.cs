namespace Saber.Node;

public class InfExecuteCreateSetState : CreateSetState
{
    public override bool Execute()
    {
        CreateSetStateArg arg;
        arg = this.Arg as CreateSetStateArg;
        CreateSetArg k;
        k = arg.Arg;

        InfExecute node;
        node = arg.Node as InfExecute;
        node.Cond = k.Field00 as Operate;
        node.Then = k.Field01 as State;
        return true;
    }
}