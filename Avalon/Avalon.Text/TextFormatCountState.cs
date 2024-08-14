namespace Avalon.Text;

public class TextFormatCountState : WriteCountState
{
    public override bool Execute()
    {
        WriteArg arg;
        arg = (WriteArg)this.Arg;

        int a;
        a = arg.ValueText.Range.Count;

        Value aa;
        aa = (Value)this.Result;
        aa.Mid = a;
        return true;
    }
}