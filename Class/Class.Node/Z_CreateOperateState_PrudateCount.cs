namespace Class.Node;

public class PrudateCountCreateOperateState : CreateOperateState
{
    public override bool Execute()
    {
        CreateOperateArg arg;
        arg = (CreateOperateArg)this.Arg;
        
        PrudateCount node;
        node = (PrudateCount)this.Node;
        return true;
    }
}