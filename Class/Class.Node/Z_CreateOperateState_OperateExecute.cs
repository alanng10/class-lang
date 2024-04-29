namespace Class.Node;

public class OperateExecuteCreateOperateState : CreateOperateState
{
    public override bool Execute()
    {
        OperateExecute node;
        node = (OperateExecute)this.Node;
        node.Any = (Operate)this.Arg.Field00;
        return true;
    }
}