namespace Class.Node;





public class ComposeCreateOperateState : CreateOperateState
{
    public override bool Execute()
    {
        Compose node;
        
        node = (Compose)this.Node;



        node.Value = (Array)this.Arg.Field00;




        return true;
    }
}