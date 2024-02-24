namespace Class.Node;

public class BracketOperateCreateOperateState : CreateOperateState
{
    public override bool Execute()
    {
        BracketOperate node;
        node = (BracketOperate)this.Node;
        node.Operate = (Operate)this.Arg.Field00;

        return true;
    }
}