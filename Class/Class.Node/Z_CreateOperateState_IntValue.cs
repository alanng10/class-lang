namespace Class.Node;

public class IntValueCreateOperateState : CreateOperateState
{
    public override bool Execute()
    {
        IntValue node;
        node = (IntValue)this.Node;
        node.Value = this.Arg.FieldInt;

        return true;
    }
}