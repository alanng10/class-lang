namespace Class.Node;

public class ReferExecuteCreateOperateState : CreateOperateState
{
    public override bool Execute()
    {
        CreateOperateArg arg;
        arg = (CreateOperateArg)this.Arg;
        
        ReferExecute node;
        node = (ReferExecute)this.Node;
        node.Var = (Var)arg.Field00;
        return true;
    }
}