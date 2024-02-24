namespace Class.Node;

public class OrnOperateCreateOperateState : CreateOperateState
{
    public override bool Execute()
    {
        OrnOperate node;
        node = (OrnOperate)this.Node;
        node.Left = (Operate)this.Arg.Field00;


        node.Right = (Operate)this.Arg.Field01;

        return true;
    }
}