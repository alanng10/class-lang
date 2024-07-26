namespace Class.Node;

public class EqualOperateCreateOperateState : CreateOperateState
{
    public override bool Execute()
    {
        CreateOperateArg arg;
        arg = (CreateOperateArg)this.Arg;
        
        EqualOperate node;
        node = (EqualOperate)this.Node;
        node.Left = (Operate)arg.Field00;
        node.Right = (Operate)arg.Field01;
        return true;
    }
}