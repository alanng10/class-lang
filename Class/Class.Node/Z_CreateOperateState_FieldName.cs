namespace Class.Node;

public class FieldNameCreateOperateState : CreateOperateState
{
    public override bool Execute()
    {
        CreateOperateArg arg;
        arg = (CreateOperateArg)this.Arg;
        
        FieldName node;
        node = (FieldName)this.Node;
        node.Value = (String)arg.Field00;
        return true;
    }
}