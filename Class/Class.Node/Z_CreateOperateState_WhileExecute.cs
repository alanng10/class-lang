namespace Class.Node;

public class WhileExecuteCreateOperateState : CreateOperateState
{
    public override bool Execute()
    {
        CreateOperateArg arg;
        arg = (CreateOperateArg)this.Arg;
        
        WhileExecute node;
        node = (WhileExecute)this.Node;
        node.Cond = (Operate)arg.Field00;
        node.Loop = (State)arg.Field01;
        return true;
    }
}