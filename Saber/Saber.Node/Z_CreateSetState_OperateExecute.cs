namespace Saber.Node;

public class OperateExecuteCreateSetState : CreateSetState
{
    public override bool Execute()
    {
        CreateSetStateArg arg;
        arg = this.Arg as CreateSetStateArg;
        CreateSetArg k;
        k = arg.Arg;

        OperateExecute node;
        node = arg.Node as OperateExecute;
        node.Any = k.Field00 as Operate;
        return true;
    }
}