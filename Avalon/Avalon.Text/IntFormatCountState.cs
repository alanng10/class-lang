namespace Avalon.Text;

public class IntFormatCountState : FormatCountState
{
    public override bool Execute()
    {
        FormatArg arg;
        arg = (FormatArg)this.Arg;

        int count;
        count = this.Format.IntDigitCount(arg.ValueInt, arg.Base);
        this.Result = count;
        return true;
    }
}