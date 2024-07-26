namespace Class.Node;

public class FieldCreateOperateState : CreateOperateState
{
    public override bool Execute()
    {
        CreateOperateArg arg;
        arg = (CreateOperateArg)this.Arg;
        
        Field node;
        node = (Field)this.Node;
        node.Class = (ClassName)arg.Field00;
        node.Name = (FieldName)arg.Field01;
        node.Count = (Count)arg.Field02;
        node.Get = (State)arg.Field03;
        node.Set = (State)arg.Field04;
        return true;
    }
}