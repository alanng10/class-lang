namespace Class.Node;

public class IntHexSignValueCreateOperateState : CreateOperateState
{
    public override bool Execute()
    {
        IntHexSignValue node;
        node = (IntHexSignValue)this.Node;
        node.Value = this.Arg.FieldInt;
        return true;
    }
}