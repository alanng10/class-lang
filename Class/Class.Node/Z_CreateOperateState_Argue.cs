namespace Class.Node;

public class ArgueCreateOperateState : CreateOperateState
{
    public override bool Execute()
    {
        CreateOperateArg arg;
        arg = (CreateOperateArg)this.Arg;
        
        Argue node;
        node = (Argue)this.Node;
        node.Value = (Array)arg.Field00;
        return true;
    }
}