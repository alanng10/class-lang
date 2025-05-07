namespace Saber.Node;

public class WhileExecuteCreateSetState : CreateSetState
{
    public override bool Execute()
    {
        CreateSetStateArg arg;
        arg = this.Arg as CreateSetStateArg;
        CreateSetArg k;
        k = arg.Arg;

        WhileExecute node;
        node = arg.Node as WhileExecute;
        node.Cond = k.Field00 as Operate;
        node.Loop = k.Field01 as State;
        return true;
    }
}