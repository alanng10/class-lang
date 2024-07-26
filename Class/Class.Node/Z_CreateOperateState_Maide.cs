namespace Class.Node;

public class MaideCreateOperateState : CreateOperateState
{
    public override bool Execute()
    {
        CreateOperateArg arg;
        arg = (CreateOperateArg)this.Arg;
        
        Maide node;
        node = (Maide)this.Node;
        node.Class = (ClassName)arg.Field00;
        node.Name = (MaideName)arg.Field01;
        node.Count = (Count)arg.Field02;
        node.Param = (Param)arg.Field03;
        node.Call = (State)arg.Field04;
        return true;
    }
}