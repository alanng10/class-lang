namespace Class.Node;

public class VarOperateNodeState : NodeState
{
    public override bool Execute()
    {
        this.Result = this.Create.ExecuteVarOperate(this.Arg);
        return true;
    }
}