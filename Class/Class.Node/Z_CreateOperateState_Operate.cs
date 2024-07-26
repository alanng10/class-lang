namespace Class.Node;

public class OperateCreateOperateState : CreateOperateState
{
    public override bool Execute()
    {
        CreateOperateArg arg;
        arg = (CreateOperateArg)this.Arg;
        
        Operate node;
        node = (Operate)this.Node;
        return true;
    }
}