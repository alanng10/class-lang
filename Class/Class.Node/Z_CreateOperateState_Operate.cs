namespace Class.Node;

public class OperateCreateOperateState : CreateOperateState
{
    public override bool Execute()
    {
        Operate node;
        node = (Operate)this.Node;

        return true;
    }
}