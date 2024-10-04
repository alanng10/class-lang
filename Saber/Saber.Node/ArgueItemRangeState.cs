namespace Class.Node;

public class ArgueItemRangeState : RangeState
{
    public override bool Execute()
    {
        RangeStateArg arg;
        arg = (RangeStateArg)this.Arg;

        Range a;
        a = this.Create.ExecuteArgueItemRange(arg.Result, arg.Range);
        this.Result = a;
        return true;
    }
}