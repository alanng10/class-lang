namespace Class.Node;

public class BitSignRightOperateCreateOperateState : CreateOperateState
{
    public override bool Execute()
    {
        BitSignRightOperate node;
        node = (BitSignRightOperate)this.Node;
        node.Value = (Operate)this.Arg.Field00;


        node.Count = (Operate)this.Arg.Field01;

        return true;
    }
}