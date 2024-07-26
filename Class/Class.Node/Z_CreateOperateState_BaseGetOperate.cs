namespace Class.Node;

public class BaseGetOperateCreateOperateState : CreateOperateState
{
    public override bool Execute()
    {
        CreateOperateArg arg;
        arg = (CreateOperateArg)this.Arg;
        
        BaseGetOperate node;
        node = (BaseGetOperate)this.Node;
        node.Field = (FieldName)arg.Field00;
        return true;
    }
}