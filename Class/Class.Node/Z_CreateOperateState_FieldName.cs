namespace Class.Node;

public class FieldNameCreateOperateState : CreateOperateState
{
    public override bool Execute()
    {
        FieldName node;
        node = (FieldName)this.Node;
        node.Value = (string)this.Arg.Field00;
        return true;
    }
}