namespace Class.Node;

public class TargetCreateOperateState : CreateOperateState
{
    public override bool Execute()
    {
        CreateOperateArg arg;
        arg = (CreateOperateArg)this.Arg;
        
        Target node;
        node = (Target)this.Node;
        return true;
    }
}