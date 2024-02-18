namespace Class.Node;






public class PartItemRangeState : RangeState
{
    public override bool Execute()
    {
        Range a;



        a = this.Create.ExecuteCompRange(this.Arg.Result, this.Arg.Range);




        this.Result = a;



        return true;
    }
}