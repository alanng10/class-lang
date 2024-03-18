namespace Class.Node;

public class BaseGetOperateCreateOperateState : CreateOperateState
{
    public override bool Execute()
    {
        BaseGetOperate node;
        node = (BaseGetOperate)this.Node;
        node.Field = (FieldName)this.Arg.Field00;
        return true;
    }
}