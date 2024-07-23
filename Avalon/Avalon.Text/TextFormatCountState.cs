namespace Avalon.Text;

public class TextFormatCountState : FormatCountState
{
    public override bool Execute()
    {
        FormatArg arg;
        arg = (FormatArg)this.Arg;

        int a;
        a = arg.ValueText.Range.Count;

        Value aa;
        aa = (Value)this.Result;
        aa.Mid = a;
        return true;
    }
}