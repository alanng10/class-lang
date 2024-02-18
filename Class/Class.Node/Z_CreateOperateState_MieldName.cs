namespace Class.Node;





public class MieldNameCreateOperateState : CreateOperateState
{
    public override bool Execute()
    {
        MieldName node;
        
        node = (MieldName)this.Node;



        node.Value = (string)this.Arg.Field00;




        return true;
    }
}