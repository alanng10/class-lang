namespace Class.Node;

public class ExecuteCreateOperateState : CreateOperateState
{
    public override bool Execute()
    {
        CreateOperateArg arg;
        arg = (CreateOperateArg)this.Arg;
        
        Execute node;
        node = (Execute)this.Node;
        return true;
    }
}