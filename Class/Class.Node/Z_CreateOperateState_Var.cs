namespace Class.Node;

public class VarCreateOperateState : CreateOperateState
{
    public override bool Execute()
    {
        Var node;
        node = (Var)this.Node;
        node.Class = (ClassName)this.Arg.Field00;
        node.Name = (VarName)this.Arg.Field01;

        return true;
    }
}