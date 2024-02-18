namespace Class.Node;





public class VarNameCreateOperateState : CreateOperateState
{
    public override bool Execute()
    {
        VarName node;
        
        node = (VarName)this.Node;



        node.Value = (string)this.Arg.Field00;




        return true;
    }
}