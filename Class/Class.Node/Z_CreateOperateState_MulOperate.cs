namespace Class.Node;

public class MulOperateCreateOperateState : CreateOperateState
{
    public override bool Execute()
    {
        CreateOperateArg arg;
        arg = (CreateOperateArg)this.Arg;
        
        MulOperate node;
        node = (MulOperate)this.Node;
        node.Lite = (Operate)arg.Field00;
        node.Rite = (Operate)arg.Field01;
        return true;
    }
}