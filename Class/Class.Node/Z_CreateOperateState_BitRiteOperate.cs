namespace Class.Node;

public class BitRiteOperateCreateOperateState : CreateOperateState
{
    public override bool Execute()
    {
        CreateOperateArg arg;
        arg = (CreateOperateArg)this.Arg;
        
        BitRiteOperate node;
        node = (BitRiteOperate)this.Node;
        node.Value = (Operate)arg.Field00;
        node.Count = (Operate)arg.Field01;
        return true;
    }
}