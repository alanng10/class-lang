namespace Class.Node;





public class CallOperateCreateOperateState : CreateOperateState
{
    public override bool Execute()
    {
        CallOperate node;
        
        node = (CallOperate)this.Node;



        node.This = (Operate)this.Arg.Field00;


        node.Mield = (MieldName)this.Arg.Field01;


        node.Argue = (Argue)this.Arg.Field02;




        return true;
    }
}