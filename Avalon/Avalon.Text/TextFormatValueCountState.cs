namespace Avalon.Text;

class TextFormatValueCountState : FormatValueCountState
{
    public override bool Execute()
    {
        FormatArg arg;
        arg = (FormatArg)this.Arg;

        this.Result = arg.ValueText.Range.Count;
        return true;
    }
}