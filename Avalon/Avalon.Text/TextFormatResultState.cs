namespace Avalon.Text;

public class TextFormatResultState : FormatResultState
{
    public override bool Execute()
    {
        FormatArg arg;
        arg = (FormatArg)this.Arg;
        Text result;
        result = this.ArgResult;
        Format format;
        format = this.Format;



        return true;
    }
}