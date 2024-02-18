namespace Class.Node;





public class SignLessOperateCreateOperateState : CreateOperateState
{
    public override bool Execute()
    {
        SignLessOperate node;
        
        node = (SignLessOperate)this.Node;



        node.Left = (Operate)this.Arg.Field00;


        node.Right = (Operate)this.Arg.Field01;




        return true;
    }
}