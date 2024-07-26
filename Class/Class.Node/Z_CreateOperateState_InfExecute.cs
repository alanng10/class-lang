namespace Class.Node;

public class InfExecuteCreateOperateState : CreateOperateState
{
    public override bool Execute()
    {
        CreateOperateArg arg;
        arg = (CreateOperateArg)this.Arg;
        
        InfExecute node;
        node = (InfExecute)this.Node;
        node.Cond = (Operate)arg.Field00;
        node.Then = (State)arg.Field01;
        return true;
    }
}