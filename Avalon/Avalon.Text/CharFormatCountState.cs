namespace Avalon.Text;

public class CharFormatCountState : FormatCountState
{
    public override bool Execute()
    {
        this.Result = 1;
        return true;
    }
}