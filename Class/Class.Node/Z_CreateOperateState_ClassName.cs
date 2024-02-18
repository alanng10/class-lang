namespace Class.Node;





public class ClassNameCreateOperateState : CreateOperateState
{
    public override bool Execute()
    {
        ClassName node;
        
        node = (ClassName)this.Node;



        node.Value = (string)this.Arg.Field00;




        return true;
    }
}