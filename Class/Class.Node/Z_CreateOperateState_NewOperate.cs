namespace Class.Node;





public class NewOperateCreateOperateState : CreateOperateState
{
    public override bool Execute()
    {
        NewOperate node;
        
        node = (NewOperate)this.Node;



        node.Class = (ClassName)this.Arg.Field00;




        return true;
    }
}