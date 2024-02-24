namespace Class.Node;

public class NotOperateCreateOperateState : CreateOperateState
{
    public override bool Execute()
    {
        NotOperate node;
        node = (NotOperate)this.Node;
        node.Value = (Operate)this.Arg.Field00;

        return true;
    }
}