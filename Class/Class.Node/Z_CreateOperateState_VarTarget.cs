namespace Class.Node;

public class VarTargetCreateOperateState : CreateOperateState
{
    public override bool Execute()
    {
        CreateOperateArg arg;
        arg = (CreateOperateArg)this.Arg;
        
        VarTarget node;
        node = (VarTarget)this.Node;
        node.Var = (VarName)arg.Field00;
        return true;
    }
}