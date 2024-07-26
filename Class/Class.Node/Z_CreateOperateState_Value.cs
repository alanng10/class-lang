namespace Class.Node;

public class ValueCreateOperateState : CreateOperateState
{
    public override bool Execute()
    {
        CreateOperateArg arg;
        arg = (CreateOperateArg)this.Arg;
        
        Value node;
        node = (Value)this.Node;
        return true;
    }
}