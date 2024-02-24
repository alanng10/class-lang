namespace Class.Node;

public class NullOperateCreateOperateState : CreateOperateState
{
    public override bool Execute()
    {
        NullOperate node;
        node = (NullOperate)this.Node;

        return true;
    }
}