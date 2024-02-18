namespace Class.Node;





public class BoolValueCreateOperateState : CreateOperateState
{
    public override bool Execute()
    {
        BoolValue node;
        
        node = (BoolValue)this.Node;



        node.Value = this.Arg.FieldBool;




        return true;
    }
}