namespace Class.Node;

public class CountCreateOperateState : CreateOperateState
{
    public override bool Execute()
    {
        CreateOperateArg arg;
        arg = (CreateOperateArg)this.Arg;
        
        Count node;
        node = (Count)this.Node;
        return true;
    }
}