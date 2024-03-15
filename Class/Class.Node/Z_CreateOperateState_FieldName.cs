namespace Class.Node;

public class FieldNameCreateOperateState : CreateOperateState
{
    public override bool Execute()
    {
        FieldName node;
        node = (FieldName)this.Node;
        node.Value = (TextSpan)this.Arg.Field00;
        return true;
    }
}