namespace Class.Node;





public class ReturnExecuteCreateOperateState : CreateOperateState
{
    public override bool Execute()
    {
        ReturnExecute node;
        
        node = (ReturnExecute)this.Node;



        node.Result = (Operate)this.Arg.Field00;




        return true;
    }
}