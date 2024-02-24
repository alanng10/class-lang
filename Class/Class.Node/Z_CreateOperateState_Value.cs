namespace Class.Node;

public class ValueCreateOperateState : CreateOperateState
{
    public override bool Execute()
    {
        Value node;
        node = (Value)this.Node;

        return true;
    }
}