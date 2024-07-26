namespace Class.Node;

public class ReturnExecuteCreateOperateState : CreateOperateState
{
    public override bool Execute()
    {
        CreateOperateArg arg;
        arg = (CreateOperateArg)this.Arg;
        
        ReturnExecute node;
        node = (ReturnExecute)this.Node;
        node.Result = (Operate)arg.Field00;
        return true;
    }
}