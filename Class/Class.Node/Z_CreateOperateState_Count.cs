namespace Class.Node;

public class CountCreateOperateState : CreateOperateState
{
    public override bool Execute()
    {
        Count node;
        node = (Count)this.Node;
        return true;
    }
}