namespace Class.Node;

public class ParamCreateOperateState : CreateOperateState
{
    public override bool Execute()
    {
        CreateOperateArg arg;
        arg = (CreateOperateArg)this.Arg;
        
        Param node;
        node = (Param)this.Node;
        node.Value = (Array)arg.Field00;
        return true;
    }
}