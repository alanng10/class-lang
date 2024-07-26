namespace Class.Node;

public class IntValueCreateOperateState : CreateOperateState
{
    public override bool Execute()
    {
        CreateOperateArg arg;
        arg = (CreateOperateArg)this.Arg;
        
        IntValue node;
        node = (IntValue)this.Node;
        node.Value = arg.FieldInt;
        return true;
    }
}