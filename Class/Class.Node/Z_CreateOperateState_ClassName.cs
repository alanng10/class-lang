namespace Class.Node;

public class ClassNameCreateOperateState : CreateOperateState
{
    public override bool Execute()
    {
        ClassName node;
        node = (ClassName)this.Node;
        node.Value = (TextSpan)this.Arg.Field00;
        return true;
    }
}