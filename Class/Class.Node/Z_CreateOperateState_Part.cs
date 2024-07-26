namespace Class.Node;

public class PartCreateOperateState : CreateOperateState
{
    public override bool Execute()
    {
        CreateOperateArg arg;
        arg = (CreateOperateArg)this.Arg;
        
        Part node;
        node = (Part)this.Node;
        node.Value = (Array)arg.Field00;
        return true;
    }
}