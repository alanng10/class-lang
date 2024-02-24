namespace Class.Node;

public class VarOperateCreateOperateState : CreateOperateState
{
    public override bool Execute()
    {
        VarOperate node;
        node = (VarOperate)this.Node;
        node.Var = (VarName)this.Arg.Field00;

        return true;
    }
}