namespace Class.Node;

public class ValueOperateCreateOperateState : CreateOperateState
{
    public override bool Execute()
    {
        CreateOperateArg arg;
        arg = (CreateOperateArg)this.Arg;
        
        ValueOperate node;
        node = (ValueOperate)this.Node;
        node.Value = (Value)arg.Field00;
        return true;
    }
}