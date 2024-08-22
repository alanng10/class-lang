namespace Class.Node;

public class SameOperateCreateOperateState : CreateOperateState
{
    public override bool Execute()
    {
        CreateOperateArg arg;
        arg = (CreateOperateArg)this.Arg;
        
        SameOperate node;
        node = (SameOperate)this.Node;
        node.Lite = (Operate)arg.Field00;
        node.Rite = (Operate)arg.Field01;
        return true;
    }
}