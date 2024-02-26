namespace Class.Node;

public class EmitCreateOperateState : CreateOperateState
{
    public override bool Execute()
    {
        Emit node;
        node = (Emit)this.Node;

        return true;
    }
}