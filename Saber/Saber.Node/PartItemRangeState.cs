namespace Saber.Node;

public class PartItemRangeState : RangeState
{
    public override bool Execute()
    {
        RangeStateArg arg;
        arg = this.Arg as RangeStateArg;

        this.Result = this.Create.ExecutePartItemRange(arg.Result, arg.Range);
        return true;
    }
}