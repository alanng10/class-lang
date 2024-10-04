namespace Saber.Node;

public class StateItemRangeState : RangeState
{
    public override bool Execute()
    {
        RangeStateArg arg;
        arg = (RangeStateArg)this.Arg;

        Range a;
        a = this.Create.ExecuteExecuteRange(arg.Result, arg.Range);
        this.Result = a;
        return true;
    }
}