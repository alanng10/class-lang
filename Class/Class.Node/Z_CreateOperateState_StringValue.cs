namespace Class.Node;





public class StringValueCreateOperateState : CreateOperateState
{
    public override bool Execute()
    {
        StringValue node;
        
        node = (StringValue)this.Node;



        node.Value = (string)this.Arg.Field00;




        return true;
    }
}