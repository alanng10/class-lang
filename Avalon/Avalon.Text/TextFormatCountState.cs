namespace Avalon.Text;

class TextFormatCountState : FormatCountState
{
    public override bool Execute()
    {
        FormatArg arg;
        arg = (FormatArg)this.Arg;

        this.Result = arg.ValueText.Range.Count;
        return true;
    }
}