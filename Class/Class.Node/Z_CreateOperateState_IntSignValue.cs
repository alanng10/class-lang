namespace Class.Node;

public class IntSignValueCreateOperateState : CreateOperateState
{
    public override bool Execute()
    {
        CreateOperateArg arg;
        arg = (CreateOperateArg)this.Arg;
        
        IntSignValue node;
        node = (IntSignValue)this.Node;
        node.Value = arg.FieldInt;
        return true;
    }
}