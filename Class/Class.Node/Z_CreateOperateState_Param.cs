namespace Class.Node;





public class ParamCreateOperateState : CreateOperateState
{
    public override bool Execute()
    {
        Param node;
        
        node = (Param)this.Node;



        node.Value = (Array)this.Arg.Field00;




        return true;
    }
}