namespace Class.Node;

public class ReferExecuteCreateOperateState : CreateOperateState
{
    public override bool Execute()
    {
        ReferExecute node;
        node = (ReferExecute)this.Node;
        node.Var = (Var)this.Arg.Field00;
        return true;
    }
}