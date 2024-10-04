namespace Saber.Node;

public class InfExecuteCreateSetState : CreateSetState
{
    public override bool Execute()
    {
        CreateSetStateArg arg;
        arg = (CreateSetStateArg)this.Arg;
        CreateSetArg k;
        k = arg.SetArg;

        InfExecute node;
        node = (InfExecute)arg.Node;
        node.Cond = (Operate)k.Field00;
        node.Then = (State)k.Field01;
        return true;
    }
}