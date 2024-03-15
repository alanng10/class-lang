namespace Class.Node;

public class CompCreateOperateState : CreateOperateState
{
    public override bool Execute()
    {
        Comp node;
        node = (Comp)this.Node;
        return true;
    }
}