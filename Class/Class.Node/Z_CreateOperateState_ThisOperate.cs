namespace Class.Node;

public class ThisOperateCreateOperateState : CreateOperateState
{
    public override bool Execute()
    {
        CreateOperateArg arg;
        arg = (CreateOperateArg)this.Arg;
        
        ThisOperate node;
        node = (ThisOperate)this.Node;
        return true;
    }
}