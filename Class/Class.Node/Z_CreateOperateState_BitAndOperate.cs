namespace Class.Node;

public class BitAndOperateCreateOperateState : CreateOperateState
{
    public override bool Execute()
    {
        CreateOperateArg arg;
        arg = (CreateOperateArg)this.Arg;
        
        BitAndOperate node;
        node = (BitAndOperate)this.Node;
        node.Left = (Operate)arg.Field00;
        node.Right = (Operate)arg.Field01;
        return true;
    }
}