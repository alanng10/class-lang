namespace Class.Node;





public class IntSignHexValueCreateOperateState : CreateOperateState
{
    public override bool Execute()
    {
        IntSignHexValue node;
        
        node = (IntSignHexValue)this.Node;



        node.Value = this.Arg.FieldInt;




        return true;
    }
}