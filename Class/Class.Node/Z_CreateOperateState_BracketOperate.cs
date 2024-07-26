namespace Class.Node;

public class BracketOperateCreateOperateState : CreateOperateState
{
    public override bool Execute()
    {
        CreateOperateArg arg;
        arg = (CreateOperateArg)this.Arg;
        
        BracketOperate node;
        node = (BracketOperate)this.Node;
        node.Any = (Operate)arg.Field00;
        return true;
    }
}