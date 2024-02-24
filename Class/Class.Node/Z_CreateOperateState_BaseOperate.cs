namespace Class.Node;

public class BaseOperateCreateOperateState : CreateOperateState
{
    public override bool Execute()
    {
        BaseOperate node;
        node = (BaseOperate)this.Node;

        return true;
    }
}