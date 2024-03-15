namespace Class.Node;

public class VarTargetCreateOperateState : CreateOperateState
{
    public override bool Execute()
    {
        VarTarget node;
        node = (VarTarget)this.Node;
        node.Var = (VarName)this.Arg.Field00;
        return true;
    }
}