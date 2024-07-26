namespace Class.Node;

public class StringValueCreateOperateState : CreateOperateState
{
    public override bool Execute()
    {
        CreateOperateArg arg;
        arg = (CreateOperateArg)this.Arg;
        
        StringValue node;
        node = (StringValue)this.Node;
        node.Value = (string)arg.Field00;
        return true;
    }
}