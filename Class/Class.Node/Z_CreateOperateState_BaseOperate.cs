namespace Class.Node;

public class BaseOperateCreateOperateState : CreateOperateState
{
    public override bool Execute()
    {
        CreateOperateArg arg;
        arg = (CreateOperateArg)this.Arg;
        
        BaseOperate node;
        node = (BaseOperate)this.Node;
        return true;
    }
}