namespace Class.Node;

public class PrudateEmitCreateOperateState : CreateOperateState
{
    public override bool Execute()
    {
        PrudateEmit node;
        node = (PrudateEmit)this.Node;

        return true;
    }
}