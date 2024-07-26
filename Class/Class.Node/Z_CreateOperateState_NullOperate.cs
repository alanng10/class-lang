namespace Class.Node;

public class NullOperateCreateOperateState : CreateOperateState
{
    public override bool Execute()
    {
        CreateOperateArg arg;
        arg = (CreateOperateArg)this.Arg;
        
        NullOperate node;
        node = (NullOperate)this.Node;
        return true;
    }
}