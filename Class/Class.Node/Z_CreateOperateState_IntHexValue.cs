namespace Class.Node;

public class IntHexValueCreateOperateState : CreateOperateState
{
    public override bool Execute()
    {
        IntHexValue node;
        node = (IntHexValue)this.Node;
        node.Value = this.Arg.FieldInt;

        return true;
    }
}