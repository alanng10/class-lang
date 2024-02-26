namespace Class.Node;

public class PrecateEmitCreateOperateState : CreateOperateState
{
    public override bool Execute()
    {
        PrecateEmit node;
        node = (PrecateEmit)this.Node;

        return true;
    }
}