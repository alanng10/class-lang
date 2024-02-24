namespace Class.Node;

public class BitNotOperateCreateOperateState : CreateOperateState
{
    public override bool Execute()
    {
        BitNotOperate node;
        node = (BitNotOperate)this.Node;
        node.Value = (Operate)this.Arg.Field00;

        return true;
    }
}