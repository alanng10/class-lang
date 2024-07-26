namespace Class.Node;

public class OperateExecuteCreateOperateState : CreateOperateState
{
    public override bool Execute()
    {
        CreateOperateArg arg;
        arg = (CreateOperateArg)this.Arg;
        
        OperateExecute node;
        node = (OperateExecute)this.Node;
        node.Any = (Operate)arg.Field00;
        return true;
    }
}