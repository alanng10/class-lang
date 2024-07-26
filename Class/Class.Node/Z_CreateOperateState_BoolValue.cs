namespace Class.Node;

public class BoolValueCreateOperateState : CreateOperateState
{
    public override bool Execute()
    {
        CreateOperateArg arg;
        arg = (CreateOperateArg)this.Arg;
        
        BoolValue node;
        node = (BoolValue)this.Node;
        node.Value = arg.FieldBool;
        return true;
    }
}