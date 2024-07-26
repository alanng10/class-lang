namespace Class.Node;

public class BitRightOperateCreateOperateState : CreateOperateState
{
    public override bool Execute()
    {
        CreateOperateArg arg;
        arg = (CreateOperateArg)this.Arg;
        
        BitRightOperate node;
        node = (BitRightOperate)this.Node;
        node.Value = (Operate)arg.Field00;
        node.Count = (Operate)arg.Field01;
        return true;
    }
}