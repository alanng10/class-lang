namespace Class.Node;

public class BitAndOperateCreateOperateState : CreateOperateState
{
    public override bool Execute()
    {
        CreateOperateArg arg;
        arg = (CreateOperateArg)this.Arg;
        
        BitAndOperate node;
        node = (BitAndOperate)this.Node;
        node.Lite = (Operate)arg.Field00;
        node.Rite = (Operate)arg.Field01;
        return true;
    }
}