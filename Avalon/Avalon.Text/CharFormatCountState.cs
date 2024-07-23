namespace Avalon.Text;

public class CharFormatCountState : FormatCountState
{
    public override bool Execute()
    {
        Value aa;
        aa = (Value)this.Result;
        aa.Mid = 1;
        return true;
    }
}