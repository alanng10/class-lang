namespace Class.Node;

public class PronateCountCreateOperateState : CreateOperateState
{
    public override bool Execute()
    {
        CreateOperateArg arg;
        arg = (CreateOperateArg)this.Arg;
        
        PronateCount node;
        node = (PronateCount)this.Node;
        return true;
    }
}