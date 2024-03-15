namespace Class.Node;

public class ValueOperateCreateOperateState : CreateOperateState
{
    public override bool Execute()
    {
        ValueOperate node;
        node = (ValueOperate)this.Node;
        node.Value = (Value)this.Arg.Field00;
        return true;
    }
}