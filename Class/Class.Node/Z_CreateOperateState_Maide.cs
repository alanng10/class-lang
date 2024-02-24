namespace Class.Node;

public class MaideCreateOperateState : CreateOperateState
{
    public override bool Execute()
    {
        Maide node;
        node = (Maide)this.Node;
        node.Class = (ClassName)this.Arg.Field00;


        node.Name = (MaideName)this.Arg.Field01;


        node.Access = (Access)this.Arg.Field02;


        node.Param = (Param)this.Arg.Field03;


        node.Call = (State)this.Arg.Field04;

        return true;
    }
}