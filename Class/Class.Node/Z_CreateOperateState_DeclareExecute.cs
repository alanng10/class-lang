namespace Class.Node;

public class DeclareExecuteCreateOperateState : CreateOperateState
{
    public override bool Execute()
    {
        DeclareExecute node;
        node = (DeclareExecute)this.Node;
        node.Var = (Var)this.Arg.Field00;
        return true;
    }
}