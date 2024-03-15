namespace Class.Node;

public class AssignExecuteCreateOperateState : CreateOperateState
{
    public override bool Execute()
    {
        AssignExecute node;
        node = (AssignExecute)this.Node;
        node.Target = (Target)this.Arg.Field00;
        node.Value = (Operate)this.Arg.Field01;
        return true;
    }
}