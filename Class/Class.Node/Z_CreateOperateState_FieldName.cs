namespace Class.Node;

public class FieldNameCreateOperateState : CreateOperateState
{
    public override bool Execute()
    {
        CreateOperateArg arg;
        arg = (CreateOperateArg)this.Arg;
        
        FieldName node;
        node = (FieldName)this.Node;
        node.Value = (string)arg.Field00;
        return true;
    }
}