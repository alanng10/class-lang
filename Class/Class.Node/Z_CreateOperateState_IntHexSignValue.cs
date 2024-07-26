namespace Class.Node;

public class IntHexSignValueCreateOperateState : CreateOperateState
{
    public override bool Execute()
    {
        CreateOperateArg arg;
        arg = (CreateOperateArg)this.Arg;
        
        IntHexSignValue node;
        node = (IntHexSignValue)this.Node;
        node.Value = arg.FieldInt;
        return true;
    }
}