namespace Class.Node;

public class InfExecuteCreateOperateState : CreateOperateState
{
    public override bool Execute()
    {
        InfExecute node;
        node = (InfExecute)this.Node;
        node.Cond = (Operate)this.Arg.Field00;
        node.Then = (State)this.Arg.Field01;

        return true;
    }
}