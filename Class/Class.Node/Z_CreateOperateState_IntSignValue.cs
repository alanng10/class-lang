namespace Class.Node;





public class IntSignValueCreateOperateState : CreateOperateState
{
    public override bool Execute()
    {
        IntSignValue node;
        
        node = (IntSignValue)this.Node;



        node.Value = this.Arg.FieldInt;




        return true;
    }
}