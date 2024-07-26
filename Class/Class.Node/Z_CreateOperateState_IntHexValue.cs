namespace Class.Node;

public class IntHexValueCreateOperateState : CreateOperateState
{
    public override bool Execute()
    {
        CreateOperateArg arg;
        arg = (CreateOperateArg)this.Arg;
        
        IntHexValue node;
        node = (IntHexValue)this.Node;
        node.Value = arg.FieldInt;
        return true;
    }
}