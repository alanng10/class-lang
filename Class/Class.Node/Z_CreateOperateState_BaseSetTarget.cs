namespace Class.Node;

public class BaseSetTargetCreateOperateState : CreateOperateState
{
    public override bool Execute()
    {
        CreateOperateArg arg;
        arg = (CreateOperateArg)this.Arg;
        
        BaseSetTarget node;
        node = (BaseSetTarget)this.Node;
        node.Field = (FieldName)arg.Field00;
        return true;
    }
}