namespace Saber.Node;

public class StateItemRangeState : RangeState
{
    public override bool Execute()
    {
        RangeStateArg arg;
        arg = this.Arg as RangeStateArg;

        this.Result = this.Create.ExecuteStateItemRange(arg.Result, arg.Range);
        return true;
    }
}