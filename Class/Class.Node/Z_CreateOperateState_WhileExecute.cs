namespace Class.Node;





public class WhileExecuteCreateOperateState : CreateOperateState
{
    public override bool Execute()
    {
        WhileExecute node;
        
        node = (WhileExecute)this.Node;



        node.Cond = (Operate)this.Arg.Field00;


        node.Loop = (State)this.Arg.Field01;




        return true;
    }
}