namespace Class.Node;

public class StateCreateOperateState : CreateOperateState
{
    public override bool Execute()
    {
        CreateOperateArg arg;
        arg = (CreateOperateArg)this.Arg;
        
        State node;
        node = (State)this.Node;
        node.Value = (Array)arg.Field00;
        return true;
    }
}