namespace Saber.Node;

public class VarOperateNodeState : NodeState
{
    public override bool Execute()
    {
        Range range;
        range = (Range)this.Arg;
        
        this.Result = this.Create.ExecuteVarOperate(range);
        return true;
    }
}