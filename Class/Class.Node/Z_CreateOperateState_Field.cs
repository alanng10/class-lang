namespace Class.Node;





public class FieldCreateOperateState : CreateOperateState
{
    public override bool Execute()
    {
        Field node;
        
        node = (Field)this.Node;



        node.Class = (ClassName)this.Arg.Field00;


        node.Name = (FieldName)this.Arg.Field01;


        node.Access = (Access)this.Arg.Field02;


        node.Get = (State)this.Arg.Field03;


        node.Set = (State)this.Arg.Field04;




        return true;
    }
}