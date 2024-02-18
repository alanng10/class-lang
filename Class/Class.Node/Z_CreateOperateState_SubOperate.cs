namespace Class.Node;





public class SubOperateCreateOperateState : CreateOperateState
{
    public override bool Execute()
    {
        SubOperate node;
        
        node = (SubOperate)this.Node;



        node.Left = (Operate)this.Arg.Field00;


        node.Right = (Operate)this.Arg.Field01;




        return true;
    }
}