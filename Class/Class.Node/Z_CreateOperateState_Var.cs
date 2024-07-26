namespace Class.Node;

public class VarCreateOperateState : CreateOperateState
{
    public override bool Execute()
    {
        CreateOperateArg arg;
        arg = (CreateOperateArg)this.Arg;
        
        Var node;
        node = (Var)this.Node;
        node.Class = (ClassName)arg.Field00;
        node.Name = (VarName)arg.Field01;
        return true;
    }
}