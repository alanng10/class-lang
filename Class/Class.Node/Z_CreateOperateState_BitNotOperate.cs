namespace Class.Node;

public class BitNotOperateCreateOperateState : CreateOperateState
{
    public override bool Execute()
    {
        CreateOperateArg arg;
        arg = (CreateOperateArg)this.Arg;
        
        BitNotOperate node;
        node = (BitNotOperate)this.Node;
        node.Value = (Operate)arg.Field00;
        return true;
    }
}