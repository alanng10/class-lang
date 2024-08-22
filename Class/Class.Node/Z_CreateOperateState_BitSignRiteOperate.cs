namespace Class.Node;

public class BitSignRiteOperateCreateOperateState : CreateOperateState
{
    public override bool Execute()
    {
        CreateOperateArg arg;
        arg = (CreateOperateArg)this.Arg;
        
        BitSignRiteOperate node;
        node = (BitSignRiteOperate)this.Node;
        node.Value = (Operate)arg.Field00;
        node.Count = (Operate)arg.Field01;
        return true;
    }
}