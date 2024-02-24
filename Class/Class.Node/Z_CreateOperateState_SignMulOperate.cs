namespace Class.Node;

public class SignMulOperateCreateOperateState : CreateOperateState
{
    public override bool Execute()
    {
        SignMulOperate node;
        node = (SignMulOperate)this.Node;
        node.Left = (Operate)this.Arg.Field00;


        node.Right = (Operate)this.Arg.Field01;

        return true;
    }
}