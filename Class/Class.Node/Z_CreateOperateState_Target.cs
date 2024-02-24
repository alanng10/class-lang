namespace Class.Node;

public class TargetCreateOperateState : CreateOperateState
{
    public override bool Execute()
    {
        Target node;
        node = (Target)this.Node;

        return true;
    }
}