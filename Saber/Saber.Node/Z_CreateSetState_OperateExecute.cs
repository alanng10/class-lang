namespace Saber.Node;

public class OperateExecuteCreateSetState : CreateSetState
{
    public override bool Execute()
    {
        CreateSetStateArg arg;
        arg = (CreateSetStateArg)this.Arg;
        CreateSetArg k;
        k = arg.SetArg;

        OperateExecute node;
        node = (OperateExecute)arg.Node;
        node.Any = (Operate)k.Field00;
        return true;
    }
}