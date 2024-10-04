namespace Saber.Node;

public class ValueOperateNewState : InfraState
{
    public override bool Execute()
    {
        this.Result = new ValueOperate();
        return true;
    }
}