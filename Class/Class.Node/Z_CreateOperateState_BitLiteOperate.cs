namespace Class.Node;

public class BitLiteOperateCreateOperateState : CreateOperateState
{
    public override bool Execute()
    {
        CreateOperateArg arg;
        arg = (CreateOperateArg)this.Arg;
        
        BitLiteOperate node;
        node = (BitLiteOperate)this.Node;
        node.Value = (Operate)arg.Field00;
        node.Count = (Operate)arg.Field01;
        return true;
    }
}