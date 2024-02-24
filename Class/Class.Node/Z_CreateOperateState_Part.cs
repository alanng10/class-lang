namespace Class.Node;

public class PartCreateOperateState : CreateOperateState
{
    public override bool Execute()
    {
        Part node;
        node = (Part)this.Node;
        node.Value = (Array)this.Arg.Field00;

        return true;
    }
}