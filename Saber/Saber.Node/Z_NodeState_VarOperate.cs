namespace Saber.Node;

public class VarOperateNodeState : NodeState
{
    public override bool Execute()
    {
        Range range;
        range = this.Arg as Range;

        this.Result = this.Create.ExecuteVarOperate(range);
        return true;
    }
}