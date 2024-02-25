namespace Class.Node;

public class ArgueItemRangeState : RangeState
{
    public override bool Execute()
    {
        Range a;
        a = this.Create.ExecuteArgueItemRange(this.Arg.Result, this.Arg.Range);
        this.Result = a;
        return true;
    }
}