namespace Class.Node;

public class VarOperateCreateOperateState : CreateOperateState
{
    public override bool Execute()
    {
        CreateOperateArg arg;
        arg = (CreateOperateArg)this.Arg;
        
        VarOperate node;
        node = (VarOperate)this.Node;
        node.Var = (VarName)arg.Field00;
        return true;
    }
}