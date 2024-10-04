namespace Saber.Node;

public class WhileExecuteCreateSetState : CreateSetState
{
    public override bool Execute()
    {
        CreateSetStateArg arg;
        arg = (CreateSetStateArg)this.Arg;
        CreateSetArg k;
        k = arg.SetArg;

        WhileExecute node;
        node = (WhileExecute)arg.Node;
        node.Cond = (Operate)k.Field00;
        node.Loop = (State)k.Field01;
        return true;
    }
}