namespace Class.Node;

public class StateCreateOperateState : CreateOperateState
{
    public override bool Execute()
    {
        State node;
        node = (State)this.Node;
        node.Value = (Array)this.Arg.Field00;
        return true;
    }
}