namespace Class.Node;

public class VarNameCreateOperateState : CreateOperateState
{
    public override bool Execute()
    {
        CreateOperateArg arg;
        arg = (CreateOperateArg)this.Arg;
        
        VarName node;
        node = (VarName)this.Node;
        node.Value = (string)arg.Field00;
        return true;
    }
}