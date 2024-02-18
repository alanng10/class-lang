namespace Class.Node;





public class SignDivOperateCreateOperateState : CreateOperateState
{
    public override bool Execute()
    {
        SignDivOperate node;
        
        node = (SignDivOperate)this.Node;



        node.Left = (Operate)this.Arg.Field00;


        node.Right = (Operate)this.Arg.Field01;




        return true;
    }
}