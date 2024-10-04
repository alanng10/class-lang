namespace Class.Node;

public class PartItemRangeState : RangeState
{
    public override bool Execute()
    {
        RangeStateArg arg;
        arg = (RangeStateArg)this.Arg;

        Range a;
        a = this.Create.ExecuteCompRange(arg.Result, arg.Range);
        this.Result = a;
        return true;
    }
}