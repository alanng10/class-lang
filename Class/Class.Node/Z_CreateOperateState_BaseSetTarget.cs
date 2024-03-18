namespace Class.Node;

public class BaseSetTargetCreateOperateState : CreateOperateState
{
    public override bool Execute()
    {
        BaseSetTarget node;
        node = (BaseSetTarget)this.Node;
        node.Field = (FieldName)this.Arg.Field00;
        return true;
    }
}