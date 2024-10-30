namespace Avalon.Text;

public class TextFormatCountState : FormatCountState
{
    public override bool Execute()
    {
        FormatArg arg;
        arg = this.Arg as FormatArg;

        Text text;
        text = arg.Value.Any as Text;

        long a;
        a = text.Range.Count;

        Value aa;
        aa = (Value)this.Result;
        aa.Int = a;
        return true;
    }
}